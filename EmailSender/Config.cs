using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Controls;

namespace EmailSender
{
    public static class Config
    {
        public static List<string> AddressesTo { get; set; } = new List<string> { "konovalcev@me.com", "akonovalcev@gmail.com" };
        public static string AddressFrom { get; set; } = "akonovalcev@gmail.com";
        public static SmtpClient SmtpClient { get; set; } = new SmtpClient("smtp.gmail.com", 587);
        public static string Username { get; set; } = "akonovalcev@gmail.com";
    }
}