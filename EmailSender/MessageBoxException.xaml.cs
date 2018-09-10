using System.Windows;


namespace EmailSender
{
    /// <summary>
    /// Interaction logic for MessageBoxException.xaml
    /// </summary>
    public partial class MessageBoxException : Window
    {
        public MessageBoxException(string message)
        {
            Content = message;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}