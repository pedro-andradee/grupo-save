using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class CreateSeriesDto
{
    [Required]
    public required string Title { get; set; }
    public string? Genre { get; set; }
    public int CurrentSeason { get; set; }
    public int CurrentEpisode { get; set; }
    public bool IsCompleted { get; set; }

}