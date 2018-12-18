using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProje.Areas.Admin
{
    public static class AlertBox
    {
        public static void PrimaryMessage(this ControllerBase controller, string message, string title)
        {
            PushMessage(controller, message, title.ToUpper(), "primary");
        }

        public static void SecondaryMessage(this ControllerBase controller, string message, string title)
        {
            PushMessage(controller, message, title.ToUpper(), "secondary");
        }

        public static void ErrorMessage(this ControllerBase controller, string message)
        {
            PushMessage(controller, message, "ERROR", "danger");
        }

        public static void WarningMessage(this ControllerBase controller, string message)
        {
            PushMessage(controller, message, "WARNING", "warning");
        }

        public static void SuccessMessage(this ControllerBase controller, string message)
        {
            PushMessage(controller, message, "SUCCESS", "success");
        }

        public static void InfoMessage(this ControllerBase controller, string message)
        {
            PushMessage(controller, message, "INFO", "info");
        }

        public static void LightMessage(this ControllerBase controller, string message, string title)
        {
            PushMessage(controller, message, title.ToUpper(), "light");
        }

        public static void DarkMessage(this ControllerBase controller, string message, string title)
        {
            PushMessage(controller, message, title.ToUpper(), "dark");
        }

        public static void PushMessage(this ControllerBase controller, string message, string title, string messageType)
        {
            controller.TempData["Alert"] = String.Format("<div class='sufee-alert alert with-close alert-{2} alert-dismissible fade show'> <span class='badge badge-pill badge-{2}'>{1}</span> {0} </div>", message, title, messageType);
        }
    }
}
            
