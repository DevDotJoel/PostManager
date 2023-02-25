namespace PostManager.Api.IdentityService
{
    public interface ITokenClaimService
    {
        string GetToken(string email, int userId, string role);
    }
}
