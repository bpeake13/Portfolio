using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace Portfolio.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Email(string fromEmail, string subject, string message)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("bennypeake.website@gmail.com", "pwmfpuiw15");
            smtpClient.Host = "smtp.gmail.com";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add("bennypeake@gmail.com");
            mail.Subject = string.Format("[Website] {0}", subject);
            mail.IsBodyHtml = false;

            JsonResult result = new JsonResult();

            try
            {
                smtpClient.Send(mail);

                result.Data = true;
            }
            catch
            {
                result.Data = false;
            }

            return result;
        }
    }
}
