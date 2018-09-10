using System.Windows;
using System.Net;
using System.Net.Mail;
using System;

namespace EmailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WPFMailSender : Window
    {
        public WPFMailSender()
        {
            InitializeComponent();
        }

        private void BtnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            var subject = "Привет из C#";
            var body = "Hello World!";
            var client = new EmailSendServiceClass(Config.AddressesTo, Config.AddressFrom, Config.SmtpClient, subject, body, Config.Username, passwordBox.Password);
            client.SendEmail();
        }
    }
}