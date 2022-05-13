namespace ProductService.GraphQL
{
    public record UserToken
    (
        string? Token,
        string? Expired,
        string? Message
    );
}
