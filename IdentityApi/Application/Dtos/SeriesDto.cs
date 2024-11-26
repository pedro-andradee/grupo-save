namespace IdentityApi.Application.Dtos;

public class SeriesDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Genre { get; set; }
    public int CurrentSeason { get; set; }
    public int CurrentEpisode { get; set; }
    public bool IsCompleted { get; set; }
}