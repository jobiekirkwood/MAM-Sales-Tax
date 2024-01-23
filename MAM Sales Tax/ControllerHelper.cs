using Microsoft.AspNetCore.Mvc;

namespace MAM_Sales_Tax
{

    public static class ControllerHelper
    {
        public static string GetControllerName<T>() where T : Controller
        {
            return typeof(T).Name.Replace(nameof(Controller), string.Empty);
        }
    }
}

