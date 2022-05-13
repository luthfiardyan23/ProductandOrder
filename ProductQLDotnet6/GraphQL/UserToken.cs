namespace ProductQLDotnet6.GraphQL
{
    public record UserToken
    (
        string? Token,
        string? Expired,
        string? Message
    );
}
