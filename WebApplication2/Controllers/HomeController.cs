namespace WebApplication2.Controllers
{
    using Attributes;
    using Models.Enum;
    using Models.Session;
    using Models.User;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Services;

    public class HomeController : Controller
    {
        private readonly UserService userRepository;

        public HomeController(UserService userRepository)
        {
            this.userRepository = userRepository;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            UserInfo userInfo = new UserInfo();

            var user = userRepository.Login(login);

            if(user != null)
            {
                //hash and salt password and compair
                userInfo.UserId = user.UserId;
                userInfo.Username = user.UserName;
                userInfo.Priviledges = userRepository.getPriviledges(user.UserId);
            }
            else
            {
                //user = userRepository.CreateUser(login);
            }

            UserSession.Current.User = userInfo;

            return RedirectToAction("MemberPage", "Home");
        }
            
        [AuthoriseUser(PriviledgeEnum.Admin)]
        public ActionResult MemberPage()
        {
            return View();
        }
    }
}