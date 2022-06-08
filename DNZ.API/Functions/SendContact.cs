using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using SendGrid.Helpers.Mail;

using DNZ.Common.Models;

namespace DNZ.API.Functions
{
    public static class SendContact
    {
        [FunctionName(nameof(SendContact))]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "contact")] ContactModel contactModel,
            [SendGrid(ApiKey = "SendgridKey")] out SendGridMessage message, ILogger log)
        {
            var body = $"Hi,<br><br>Het contactformulier is ingevuld met de volgende gegevens:<br><br>{contactModel.Name}<br>{contactModel.Email}<br>{contactModel.Message.Replace(Environment.NewLine, "<br>")}";
            message = new SendGridMessage();
            message.SetFrom(new EmailAddress("no-reply@dotnetzuid.nl"));
            message.AddTo("info@dotnetzuid.nl");
            message.AddCc(new EmailAddress(contactModel.Email));
            message.SetSubject("Contact form");
            message.AddContent("text/html", body);
            
            return new OkResult();
        }
    }
}
