using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IEmailVerificationService
    {
        string GenerateToken(User payload);

        Task<bool> SendEmail(User payload);

        Task<User> VerifyAndDecodePayload(string token);
        Task<List<User>> GetUsers();
    }
}
