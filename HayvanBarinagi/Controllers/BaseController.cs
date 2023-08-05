using Microsoft.AspNetCore.Mvc;

namespace HayvanBarinagi.Controllers
{
    public class BaseController : Controller
    {
       public string LANGUAGE_CODE()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }
      
    }
}
