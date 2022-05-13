namespace ProductQLDotnet6.GraphQL
{
    public record RegisterUser
    (
        string FullName,
        string Email,
        string UserName,
        string Password
    );
}
