using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using IdentityApi.Application.Dtos;
using IdentityApi.Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<bool> CreateUserAsync(CreateUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
        {
            return true;
        }
        return false;
    }

    public async Task<UserDto?> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return null;
        }
        return _mapper.Map<UserDto>(user);
    }

    public async Task<string> LoginAsync(LoginDto request)
    {
        if (request.UserName == null || request.Password == null)
        {
            throw new ApplicationException("Invalid login request");
        }

        var result = await _signInManager.PasswordSignInAsync(request.UserName!, request.Password!, false, false);
        if (!result.Succeeded)
        {
            throw new ApplicationException("User not authenticated");
        }

        var user = await _userManager.FindByNameAsync(request.UserName);

        return _tokenService.GenerateToken(user!);
    }

    public async Task<UserDto?> UpdateUserAsync(string id, UpdateUserDto request)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return null;
        }

        if (!string.IsNullOrEmpty(request.Email))
        {
            user.Email = request.Email;
        }

        if (request.DataNascimento.Ticks != 0)
        {
            user.DataNascimento = request.DataNascimento;
        }

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return _mapper.Map<UserDto>(user);
        }
        return null;
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return false;
        }

        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return true;
        }
        return false;
    }
}