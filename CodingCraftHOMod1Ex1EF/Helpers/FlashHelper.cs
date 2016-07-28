using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingCraftHOMod1Ex1EF.Helpers
{
    public static class FlashHelper
    {
       

            public static void FlashInfo(this Controller controller, string message)
            {
                controller.TempData["info"] = message;
            }
            public static void FlashWarning(this Controller controller, string message)
            {
                controller.TempData["warning"] = message;
            }
            public static void FlashError(this Controller controller, string message)
            {
                controller.TempData["error"] = message;
            }
      
    }
}