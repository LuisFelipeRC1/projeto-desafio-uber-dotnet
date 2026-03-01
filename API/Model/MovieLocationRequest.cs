using System.Text.Json.Serialization;

namespace API.Model
{
    public record MovieLocationRequest
    {
        public string? title { get; init; }
        public string? release_year { get; init; }
        public string? locations { get; init; }
        public string? director { get; init; }
        public string? actor_1 { get; init; }
        public string? actor_2 { get; init; }
        public string? actor_3 { get; init; }
    }
}
