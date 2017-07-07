using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService, 
            IConfigurationRoot config, 
            IWorldRepository repo,
            ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repo;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
            var data = _repository.GetAllTrips();
            return View(data);

            }
            catch(Exception ex)
            {
                _logger.LogError($"failed to get trips in index page: {ex.Message}");
                return Redirect("");
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("Email", "We don't accept AOL address");
            }
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "subject", model.Message);

                ModelState.Clear();
                ViewBag.UserMessage = "Message is sent.";
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
