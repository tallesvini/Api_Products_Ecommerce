namespace ProductsAPI.DTOs
{
    public class UserTokenDTO
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string? UserToken { get; set; }
        public string? Message { get; set; }
    }
}
