using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Domain;

public class Series
{
    public Guid Id { get; set; }

    [Required]
    public required string Title { get; set; }

    public string? Genre { get; set; }

    public int CurrentSeason { get; set; }
    public int CurrentEpisode { get; set; }
    public bool IsCompleted { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }
}