  using Entities;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmailVerificationService : IEmailVerificationService
    {
        private string _secret;
        private string _senderEmail;
        private string _senderEmailPassword;

        public readonly IUserService _userService;

        public EmailVerificationService(IConfiguration configuration, IUserService user)
        {
            _userService = user;
            this._secret = configuration["Jwt:secret"];
            this._senderEmail = configuration["Jwt:senderemail"];
            this._senderEmailPassword = configuration["Jwt:senderpassword"];
        }

        // Genrating Token.
        public string GenerateToken(User payload)
        {
            
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var Token = encoder.Encode(payload, this._secret);
            return Token;

        }

        // Method Call genrateToken method which will generate token and send verification mail with that token.
        public async Task<bool> SendEmail(User payload)
        {
            var Flag = await _userService.ValidateUser(payload);
            if (Flag)
            {
                var token = GenerateToken(payload);
                // Instantiate mimemessage()
                var message = new MimeMessage();
                // from.. sender's email address. 
                message.From.Add(new MailboxAddress(this._senderEmail));
                // To..  Reciever's Email address.
                message.To.Add(new MailboxAddress(payload.EmailId));
                // subject of the mail.
                message.Subject = "This is the Verification mail.";
                // body of email.
                Console.WriteLine($"{Environment.GetEnvironmentVariable("ONBOARDING_URL")}");
                message.Body = new TextPart(TextFormat.Plain)
                {
                    Text = $@"Thanks For Registering With Us.Click on the link to confirm 
                your email account http://{Environment.GetEnvironmentVariable("ONBOARDING_URL")}/api/user/Verification?token={token}"
                };

                // Configure and send verification email.
                using (var Client = new MailKit.Net.Smtp.SmtpClient())
                {
                    // connecting to server.
                    //Client.Connect("smtp.gmail.com", 587, false);
                    Client.Connect("smtp.gmail.com", 465, true);
                    // remove Oauth
                    Client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // getting sender's authentication.
                    Client.Authenticate(this._senderEmail, this._senderEmailPassword);
                    // send mail.
                    Client.Send(message);
                    // disconnect connection  after sending an email.
                    Client.Disconnect(true);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // Decoding verification Token and verifying user.
        public Task<User> VerifyAndDecodePayload(string token)    
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            var json = decoder.Decode(token, this._secret, verify: true);
            User payload = JsonConvert.DeserializeObject<User>(json);
                
            return _userService.CreateUser(payload);
        }
        public Task<List<User>> GetUsers()
        {
            return _userService.GetUsers();
        }
    }
}
