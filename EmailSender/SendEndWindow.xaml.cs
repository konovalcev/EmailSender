﻿using System.Windows;


namespace EmailSender
{
    /// <summary>
    /// Interaction logic for SendEndWindow.xaml
    /// </summary>
    public partial class SendEndWindow : Window
    {
        public SendEndWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}