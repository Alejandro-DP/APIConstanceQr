namespace ValidaTecAPI.DTO
{
    public class LoginCTDO
    {
        public bool isLogged { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        
        public string Token { get; set; }
    }
}
