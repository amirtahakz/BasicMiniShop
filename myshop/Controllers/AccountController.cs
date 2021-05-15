using myshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;

namespace myshop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Models.db db = new Models.db();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register(Models.MyUser u1)
        {
            if (db.myusers.Any(x => x.Email == u1.Email))
            {
                var alert = "ایمیل شما موجود است";
                return Json(alert, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var alert2 = "لطفا ایمیل خود را تایید کنید";
                u1.ConfirmEmail = false;
                u1.IdRole = 1;
                var NewUser = db.myusers.Add(u1);
                db.SaveChanges();
                BuildEmailTemplate(u1.UserId);
                return Json(alert2, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Confirm(int regId)
        {
            ViewBag.regID = regId;
            return View();
        }
        public JsonResult RegisterConfirm(int regId)
        {
            Models.MyUser Data = db.myusers.Where(x => x.UserId == regId).FirstOrDefault();
            Data.ConfirmEmail = true;
            db.SaveChanges();
            var msg = "ایمیل شما با موفقیت تایید شد";

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public void BuildEmailTemplate(int regID)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
            var regInfo = db.myusers.Where(x => x.UserId == regID).FirstOrDefault();
            var url = "https://localhost:44333/" + "Account/Confirm?regId=" + regID;
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate("Your Account Is Successfully Created", body, regInfo.Email);
        }
        public static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "amirtahakazemtabarzahraei@gmail.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }
        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("amirtahakazemtabarzahraei@gmail.com", "amirtahafilm");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Login(Models.MyUser u1)
        {
            var alert2 = "رمز عبور با نام کاربری مطابقت ندارد";
            var CheckVerify = db.myusers.FirstOrDefault(t => t.ConfirmEmail == true && t.Email == u1.Email && t.Password == u1.Password);
            if (CheckVerify != null)
            {
                if (CheckVerify.IdRole == 2)
                {
                    Session["UserIdAdmin"] = CheckVerify.UserId;
                    Session["EmailAdmin"] = CheckVerify.Email.ToString();
                    Session["NameFamilyAdmin"] = CheckVerify.NameFamily.ToString();
                    return Json(new { redirectUrl = "https://localhost:44333/Admin/HomeAdmin/Index" });
                }
                else
                {
                    Session["UserId"] = CheckVerify.UserId;
                    Session["Email"] = CheckVerify.Email.ToString();
                    Session["NameFamily"] = CheckVerify.NameFamily.ToString();
                    return Json(new { redirectUrl2 = "https://localhost:44333/Home/Index" });
                }
            }
            else
            {
                return Json(alert2, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            string resetCode = Guid.NewGuid().ToString();
            var verifyUrl = "/Account/ResetPassword/" + resetCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            using (var context = new Models.db())
            {
                var getUser = (from s in context.myusers where s.Email == EmailID select s).FirstOrDefault();
                if (getUser != null)
                {
                    getUser.ResetPasswordCode = resetCode;

                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 

                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();

                    var subject = "Password Reset Request";
                    var body = "Hi " + getUser.NameFamily + ", <br/> You recently requested to reset your password for your account. Click the link below to reset it. " +

                         " <br/><br/><a href='" + link + "'>" + link + "</a> <br/><br/>" +
                         "If you did not request a password reset, please ignore this email or reply to let us know.<br/><br/> Thank you";

                    SendEmail(getUser.Email, body, subject);

                    ViewBag.Message = "Reset password link has been sent to your email id.";
                }
                else
                {
                    ViewBag.Message = "User doesn't exists.";
                    return View();
                }
            }

            return View();
        }
        private void SendEmail(string emailAddress, string body, string subject)
        {
            using (MailMessage mm = new MailMessage("amirtahakazemtabarzahraei@gmail.com", emailAddress))
            {
                mm.Subject = subject;
                mm.Body = body;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("amirtahakazemtabarzahraei@gmail.com", "amirtahafilm");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }
        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            using (var context = new Models.db())
            {
                var user = context.myusers.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            //if (ModelState.IsValid)
            //{
            using (var context = new Models.db())
            {
                var user = context.myusers.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    //you can encrypt password here, we are not doing it
                    user.Password = model.NewPassword;
                    //make resetpasswordcode empty string now
                    user.ResetPasswordCode = "";
                    //to avoid validation issues, disable it
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();
                    message = "New password updated successfully";
                }
                //}
            }
            //else
            //{
            //    message = "Something invalid";
            //}
            ViewBag.Message = message;
            return View(model);
        }
    }
}