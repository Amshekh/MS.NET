using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace SilverlightTest
{
    using Backend;

    public partial class MainPage : UserControl
    {
        private ToDServiceClient client;
        private string format;

        public MainPage()
        {
            InitializeComponent();

            string tf = (string)App.Current.Resources["timeFormat"];
            format = tf ?? "dd-MMM-yyyy HH:mm:ss";

            client = new ToDServiceClient();
            client.GetServerTimeCompleted += client_GotTime;

            HtmlPage.RegisterScriptableObject("MainPage", this);
        }

        private void timeButton_Click(object sender, RoutedEventArgs e)
        {
            // outputTextBlock.Text = DateTime.Now.ToString();
            client.GetServerTimeAsync(format);
        }

        private void client_GotTime(object sender, GetServerTimeCompletedEventArgs e)
        {
            if (e.Error == null)
                outputTextBlock.Text = e.Result;
            else
                outputTextBlock.Text = e.Error.Message;
        }

        [ScriptableMember]
        public void ResetOutput(string text)
        {
            outputTextBlock.Text = text;
        }
    }
}
