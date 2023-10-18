using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Application.Abstractions;
using System.Diagnostics;
using Twilio.TwiML.Voice;
using Domain.Entity.Identity;

namespace Persistence.SMS
{
    public class SMSService : ISMSService
    {
        private readonly IConfiguration _configuration;
        public string _accountSid;
        public string _authToken;
        public SMSService(IConfiguration configuration)
        {
            _configuration = configuration;
            _accountSid = _configuration.GetSection("SMSConfig")["accountSid"];
            _authToken = _configuration.GetSection("SMSConfig")["authToken"];
        }
        public bool SendSmsAsync(string toNumber, string fromNumber, string body)
        {
            try
            {
                var accountSid = _accountSid;
                var authToken = _authToken;
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                  new PhoneNumber(toNumber));
                messageOptions.From = new PhoneNumber(fromNumber);
                messageOptions.Body = body;

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public void SendBulkySms(List<Domain.Entity.Student> students, string fromNumber)
        {
            foreach (var student in students)
            {
                string body = $"Congratulations! Your admission number is {student.AdmissionNo} and " +
               $"your password is {student.User.Password}. To complete your profile and change your password please visit <url>";
                try
                {
                    var accountSid = _accountSid;
                    var authToken = _authToken;
                    TwilioClient.Init(accountSid, authToken);

                    var messageOptions = new CreateMessageOptions(
                      new PhoneNumber(student.User.PhoneNumber));
                    messageOptions.From = new PhoneNumber(fromNumber);
                    messageOptions.Body = body;

                    var message = MessageResource.Create(messageOptions);
                    Console.WriteLine(message.Body);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
