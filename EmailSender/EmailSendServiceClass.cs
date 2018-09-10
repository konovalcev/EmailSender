using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace EmailSender
{
    public class EmailSendServiceClass
    {
        public List<string> AddressesTo { get; set; } // define all necessary service properties to send emails
        public string AddressFrom { get; set; }
        public SmtpClient SmtpClient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public EmailSendServiceClass(List<string> addressesTo, string addressesFrom, SmtpClient client, string subject, string body, string username, string password)
        {
            AddressesTo = addressesTo;
            AddressFrom = addressesFrom;
            SmtpClient = client;
            Subject = subject;
            Body = body;
            Username = username;
            Password = password;
        }

        public void SendEmail()
        {
            foreach (var email in AddressesTo)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage(AddressFrom, email))
                {
                    // Формируем письмо
                    mm.Subject = Subject; // Заголовок письма
                    mm.Body = Body; // Тело письма
                    mm.IsBodyHtml = false; // Не используем html в теле письма                                           
                    using (var sc = SmtpClient) // Авторизуемся на smtp-сервере и отправляем письмо
                                                              // Оператор using гарантирует вызов метода Dispose, даже если при вызове
                                                              // методов в объекте происходит исключение.
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(Config.Username, Password);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            var showException = new MessageBoxException(ex.Message);
                            showException.Show();
                        }
                    }
                }
            }
            var endWindow = new SendEndWindow();
            endWindow.Show();
        }
    }
}