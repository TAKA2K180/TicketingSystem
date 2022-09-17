using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;
using TimeKeeping_System_v1._0._0._2.Model;

namespace TicketingSystem
{
    public partial class emailRequest : MaterialForm
    {
        SqlConnection con = new SqlConnection(Model.DbConnection.cs);
        //MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        string fileName;
        string filepath;
        string file;
        string command;
        string messageBody = default;
        string messageBody2 = default;
        string emailadd = default;
        MailMessage message;
        SmtpClient smtp;
        int ngi = 0;
        string wow = default;
        string ticket;
        int yeah = 0;
        string tag;
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] stringChars = new char[5];
        Random random = new Random();
        String finalString;
        public emailRequest()
        {
            InitializeComponent();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are your sure about the data you entered? \nPlease double check", "Ticket file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    tagGenerator();
                    tag = "EM" + GlobalLogin.EmpiID + DateTime.Now.Year + finalString + "GGEZ";
                    {
                        con.Close();
                        command = "Select * from tblJobReq where TicketTag = '" + tag + "'";
                        SqlCommand cmd2 = new SqlCommand(command, con);
                        SqlDataAdapter da = new SqlDataAdapter(command, con);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        SqlDataReader sdr = cmd2.ExecuteReader();
                        while (sdr.Read())
                        {
                            if (sdr.HasRows)
                            {
                                tagGenerator();
                                tag = "EM" + GlobalLogin.EmpiID + DateTime.Now.Year + finalString + "GGEZ";
                            }
                        }
                    }
                    ticket = tag;
                    con.Close();
                    command = "insert into tblJobReq ([EmpiID],[TicketTag],[Description],[Prio],[CurrentStat],[Department],[IssueType],[Imagepath],DateFiled,Requestor,TimeFiled,Name,Condition, Subject, RootCause,LastEdit,Assigned)values('" + GlobalLogin.EmpiID + "','" + tag + "','" + txtReason.Text + "','" + 5 + "','" + "Pending" + "','" + cbDept.Text + "','" + null + "','" + null + "','" + DateTime.Now + "','" + GlobalLogin.Username + "','" + DateTime.Now.ToString("hh:mm") + "','" + txtFirst.Text + " " + txtLast.Text + "','" + null + "','" + "email request" + "','" + null + "','" + DateTime.Now + "',0)";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket filed.");
                    //findDetails();
                    findEmail();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("Error, " + ex.Message + "");
                }
            }
        }

        private void emailRequest_Load(object sender, EventArgs e)
        {
            command = "select Department from dbo.tblDepartments";
            SqlConnection con = new SqlConnection(Model.DbConnection.db);
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataSet ds2 = new DataSet();
            con.Open();
            cmd.ExecuteNonQuery();
            da.Fill(ds2);

            SqlDataReader sdr2 = cmd.ExecuteReader();

            while (sdr2.Read())
            {
                cbDept.Items.Add(sdr2[0].ToString());
            }
        }
        public void tagGenerator()
        {
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            finalString = new String(stringChars);
        }
        public void findEmail()
        {
            //emailadd = sdr["Email"].ToString();
            messageBody = "Hello all, \nPlease be informed that " + GlobalLogin.Username + " has requested for a new email account with the following details. \nID: " + txtID.Text + "\nName: " + txtFirst.Text + " " + txtLast.Text + "\nDepartment: " + cbDept.Text + "\nReason: " + txtReason.Text + "\nThank you.";
            messageBody2 = "";

            sendEmail();
        }
        public void sendEmail()
        {
            emailAPI();
        }
        public void emailAPI()
        {
            try
            {
                string cc = "manalorr@essilor.com.ph";
                emailadd = "alfaroj@essilor.com.ph";
                MailMessage msg = new MailMessage("TicketingSystem_NO_REPLY@essilor.com.ph", emailadd);
                msg.From = new MailAddress("TicketingSystem_NO_REPLY@essilor.com.ph");
                msg.To.Add(new MailAddress(emailadd));
                msg.CC.Add(new MailAddress(cc));
                msg.Subject = "New ticket notification";
                msg.Body = messageBody;

                SmtpClient smt = new SmtpClient();
                {
                    ref var withBlock = ref smt;
                    withBlock.Host = "smtprelay.essilor.corp";
                    withBlock.Port = 465; // port use by gmail to send mail
                    withBlock.UseDefaultCredentials = false;
                }
                smt.Host = "smtprelay.essilor.corp";
                smt = new SmtpClient("smtprelay.essilor.corp");
                smt.Send(msg);

                //smt.SendAsync(msg, msg.Subject);

                smt.SendCompleted += new SendCompletedEventHandler(smt_SendCompleted);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
                ngi++;
                wow = ex.ToString();
            }
            final();
        }
        void smt_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MaterialMessageBox.Show("Email sending cancelled!");
            }
            else if (e.Error != null)
            {
                MaterialMessageBox.Show(e.Error.Message);
            }
            else
            {
                MaterialMessageBox.Show("Email sent sucessfully!");
                this.Close();
            }
        }

        public void final()
        {
            if (ngi == 0)
            {
                MaterialMessageBox.Show("Email sent!");

            }
            else
            {
                MaterialMessageBox.Show("Error sending, " + wow + "");
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
