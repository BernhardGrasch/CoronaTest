using CoronaTest.Core.Contracts;
using CoronaTest.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CoronaTest.PoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<TwilioSmsService>()
                .AddEnvironmentVariables()
                .Build();

            ISmsService smsService = new TwilioSmsService(
                configuration["Twilio:AccountSid"], configuration["Twilio:AuthToken"]);

            string to = "+436643500902";
            string message = "Hello from Twilio";

            smsService.SendSms(to, message);
        }
    }
}
