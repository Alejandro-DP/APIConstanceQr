namespace ValidaTecAPI.DTO
{
    public class LoginCTDO
    {
        public bool isLogged { get; set; }
        public string role { get; set; }
        public string userName { get; set; }
        
        public string token { get; set; }
    }
}
