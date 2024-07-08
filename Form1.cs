using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("[smtp server name]", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("[username]", "[password]");
                smtp.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("[username]"),
                    Subject = txtSubject.Text,
                    IsBodyHtml = true,
                    Body = $"<h1>{rtxtMessage.Text}</h1>",
                };
                mailMessage.To.Add(txtTo.Text.Trim());

                smtp.Send(mailMessage);
                MessageBox.Show("Email Sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
