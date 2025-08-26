using Microsoft.EntityFrameworkCore;
using SendEmailApplication.Interfaces.Contexts;
using SendEmailDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailPersistence.Contexts
{
    public class LoginEmailService : ILoginEmailService
    {
        private readonly EmailDbContext _context;
        private readonly IEmailSender _emailSender;

        public LoginEmailService(EmailDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async Task SendLoginEmailAsync(string userId, string userName, string userEmail, DateTime loginTime)
        {
            // بررسی وجود کاربر
            var user = await _context.UserForEmails.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                user = new UserForEmail
                {
                    UserId = userId,
                    UserName = userName,
                    UserEmail = userEmail
                };
                _context.UserForEmails.Add(user);
                await _context.SaveChangesAsync();
            }

            // ساخت ایمیل
            var subject = "Login Successful";
            var body = $"سلام {userName}، ورود شما در {loginTime} ثبت شد.";

            var emailMessage = new EmailMessageLogin
            {
                UserId = user.Id,
                Subject = subject,
                Body = body,
                IsHtml = false,
                Created = DateTime.UtcNow
            };

            _context.EmailMessageLogins.Add(emailMessage);
            await _context.SaveChangesAsync();

            // ارسال ایمیل
            await _emailSender.SendEmailAsync(userEmail, subject, body);
        }
    }
}
