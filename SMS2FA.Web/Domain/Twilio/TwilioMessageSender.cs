﻿using System.Threading.Tasks;
using SMS2FA.Web.Domain;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AirTNG.Web.Domain.Reservations
{
    public interface ITwilioMessageSender
    {
        Task SendMessageAsync(string to, string from, string body);
    }
    public class TwilioMessageSender : ITwilioMessageSender
    {
        public TwilioMessageSender()
        {
            TwilioClient.Init(Config.AccountSid, Config.AuthToken);
        }

        public async Task SendMessageAsync(string to, string from, string body)
        {
            await MessageResource.CreateAsync(new PhoneNumber(to),
                                              from: new PhoneNumber(from),
                                              body: body);
        }
    }
}