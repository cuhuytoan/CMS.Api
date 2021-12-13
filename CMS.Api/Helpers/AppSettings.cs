namespace CMS.Api.Helpers
{
    public record AppSettings
    {
        public string? Secret { get; init; }
        public string? Isser { get; init; }
        public string? Audience { get; init; }

        // refresh token time to live (in days), inactive tokens are
        // automatically deleted from the database after this time
        public int RefreshTokenTTL { get; set; }
    }
}