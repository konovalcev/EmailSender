using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
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

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            var listStrMails = new List<string> { "konovalcev@me.com", "akonovalcev@gmail.com" }; // Список email'ов //кому мы отправляем письмо
            string strPassword = passwordBox.Password;
            foreach (var email in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage("sender@yandex.ru", email))
                {
                    // Формируем письмо
                    mm.Subject = "Привет из C#"; // Заголовок письма
                    mm.Body = "Hello, world!"; // Тело письма
                    mm.IsBodyHtml = false; // Не используем html в теле письма                                           
                    using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25)) // Авторизуемся на smtp-сервере и отправляем письмо
                                                                                 // Оператор using гарантирует вызов метода Dispose, даже если при вызове
                                                                                 // методов в объекте происходит исключение.
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("aleksandr.konovaltcev@yandex.ru", strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                }
            }
            MessageBox.Show("Работа завершена.");
        }
    }
}