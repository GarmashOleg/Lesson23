using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PracticeAsync
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            var request = WebRequest.Create(textBox1.Text);
            var content = new MemoryStream();

            var respoceTask = request.GetResponseAsync();

            using (var responce = await respoceTask)
            {
                using ( var responceStream = responce.GetResponseStream())
                {
                    await responceStream.CopyToAsync(content);
                }
            }

            label1.Text = content.Length.ToString();
        }

        private Button button1;
        private Label label1;
        private TextBox textBox1;
    }
}

