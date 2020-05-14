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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var request = WebRequest.Create(textBox1.Text);
            var content = new MemoryStream();

            using (var responce = request.GetResponse())
            {
                using ( var responceStream = responce.GetResponseStream())
                {
                    responceStream.CopyTo(content);
                }
            }

            label1.Text = content.Length.ToString();
        }

        private Button button1;
        private Label label1;
        private TextBox textBox1;
    }
}

