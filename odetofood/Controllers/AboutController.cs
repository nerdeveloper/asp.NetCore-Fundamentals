using Microsoft.AspNetCore.Mvc;

namespace odetofood.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "08106030026";
        }
       public string Address()
        {
            return "Nigeria";
        }
    }
}
