using ProjectBlog.DAL.Models.Request.User;

namespace ProjectBlog.DAL.Models.Request
{
    public class MainRequest
    {
        public RegisterRequest RegisterView { get; set; }

        public LoginRequest LoginView { get; set; }

        public MainRequest()
        {
            RegisterView = new RegisterRequest();
            LoginView = new LoginRequest();
        }
    }
}
