namespace BL
{
    public interface IJwtTokenBL
    {
        string GenerateJwtToken(string id, string role);
        //string GenerateToken(string username);
    }
}