using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Net.Mail;
using AguasApp.Data.Entities;
using AguasApp.Models;

namespace AguasApp.Controllers
{
    public class ContactSitesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact() 
        {
            return View();

        }

        [HttpPost]
        public ActionResult SendEmailContact(EmailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["message"] = "Information not Valid!";
                return View("Contact", model);
            }

            // Construir e enviar a mensagem por email
            var emailMessage = new MailMessage();
            emailMessage.Subject = "Contact From" + model.Email;
            emailMessage.From = new MailAddress("cazolasimao@gmail.com");
            emailMessage.To.Add("cazolasimao@gmail.com");
            emailMessage.IsBodyHtml = true;

            //Corpo da Mensagem
            emailMessage.Body = "<p>Name: " + model.Name + "</p><p>E-mail: " + model.Email + "</p>" +
                "<p>Message: " + model.Message;

            // Criar A porta e a forma de entrada da mensagem
            var client = new SmtpClient("smtp.Outlook.com", 587);

            client.Credentials = new NetworkCredential("cazolasimao@gmail.com", "cinel123!");
            client.EnableSsl = true;

            // Enviar a Mensagem

            try
            {
                client.Send(emailMessage);
            }
            catch (Exception ex)
            {

                ViewData["message"] = "The Message has fail:" + ex.Message;
            }


            return View("SendEmailContact");
        }



    }
}
