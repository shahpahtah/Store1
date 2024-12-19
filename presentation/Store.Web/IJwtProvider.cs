namespace Store.Web
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
        
    }
}