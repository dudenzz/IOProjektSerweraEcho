namespace ServerEchoLibrary
{
    public class LoginStatus
    {
        public enum StatusCode
        {
            not_logged,
            logged,
            invalid_un,
            invalid_pwd,
            logged_out
        }

        public StatusCode Status { get; set; }
        public string GivenLogin { get => givenLogin; set => givenLogin = value; }
        public string GivenPassword { get => givenPassword; set => givenPassword = value; }

        string givenLogin;

        string givenPassword;

        public void Login()
        {
            if (GivenLogin == "kuba" && GivenPassword == "haslo")
                Status = StatusCode.logged;
        }
    }
}