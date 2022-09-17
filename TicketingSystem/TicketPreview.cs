using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using TicketingSystem.Model;
using TimeKeeping_System_v1._0._0._2.Model;

namespace TicketingSystem
{
    public partial class TicketPreview : MaterialForm
    {
        SqlConnection con = new SqlConnection(DbConnection.cs);
        string command;
        string fileName;
        string file;
        string filepath;
        string requestor;
        string status;
        string messageBody = default;
        string emailadd = default;
        int ngi = 0;
        string wow;
        public TicketPreview()
        {
            InitializeComponent();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TicketPreview_Load(object sender, EventArgs e)
        {
            DateTime ez;
            string fileName;
            string fileonly;
            try
            {
                con.Close();
                command = "select * from tblJobReq where TicketTag = '" + TicketModel.TicketTag + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        lblTag.Text = sdr["TicketTag"].ToString();
                        lblStat.Text = sdr["CurrentStat"].ToString();
                        txtID.Text = sdr["EmpiID"].ToString();
                        txtName.Text = sdr["Name"].ToString();
                        txtDepartment.Text = sdr["Department"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtSubject.Text = sdr["Subject"].ToString();
                        dtDateRequired.Value = DateTime.Parse(sdr["DateRequired"].ToString());
                        cbCategory.Items.Add(sdr["Category"].ToString());
                        cbCategory.SelectedIndex = 0;
                        cbIssue.Items.Add(sdr["IssueType"].ToString());
                        cbIssue.SelectedIndex = 0;
                        cbPrio.Items.Add(sdr["Prio"].ToString());
                        cbPrio.SelectedIndex = 0;
                        ez = Convert.ToDateTime(sdr["DateFiled"].ToString());
                        lblDate.Text = sdr["DateFiled"].ToString();
                        txtRootcause.Text = sdr["RootCause"].ToString();
                        //txtRootcause.Text = sdr["LastEdit"].ToString();
                        txtTech.Text = sdr["Technician"].ToString();
                        txtPreventive.Text = sdr["PreventiveActions"].ToString();
                        if (sdr["Imagepath"].ToString() == "")
                        {
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            fileName = sdr["Imagepath"].ToString();
                            fileonly = fileName.Remove(0, 27);
                            lblPath.Text = fileonly;
                            pictureBox1.Image = Image.FromFile(fileName);
                        }
                        txtTech.Text = sdr["Technician"].ToString();
                        requestor = sdr["Requestor"].ToString();
                        status = sdr["CurrentStat"].ToString();
                        if (lblStat.Text == "Done" || lblStat.Text == "Approved")
                        {
                            btnReopen.Enabled = true;
                        }
                        else
                        {
                            btnReopen.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error loading ticket");
                    this.Hide();
                }
                if (GlobalLogin.UserRole != "SuperAdmin")
                {
                    txtPreventive.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
            afterLoad();
        }
        private void afterLoad()
        {
            {
                DataTable dt = new DataTable();
                con.Close();
                command = "SELECT IssueType FROM [db_TicketingSystem].[dbo].[tblIssueType]";
                SqlCommand cmd2 = new SqlCommand(command, con);
                SqlDataAdapter da2 = new SqlDataAdapter(command, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                da2.Fill(dt);
                SqlDataReader sdr = cmd2.ExecuteReader();

                while (sdr.Read())
                {
                    cbIssue.Items.Add(sdr[0].ToString());
                }
            }
            {
                DataTable dt = new DataTable();
                con.Close();
                command = "SELECT [Condition] FROM [db_TicketingSystem].[dbo].[tblCondition]";
                SqlCommand cmd2 = new SqlCommand(command, con);
                SqlDataAdapter da2 = new SqlDataAdapter(command, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                da2.Fill(dt);
                SqlDataReader sdr = cmd2.ExecuteReader();
            }
            {
                for (int i = 1; i <= 5; i++)
                {
                    cbPrio.Items.Add(i);
                }
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (cbIssue.Text == "" || cbPrio.Text == "" || txtSubject.Text == "" || txtName.Text == "" || txtID.Text == "" || txtDescription.Text == "")
            {
                MaterialMessageBox.Show("Please fill the required information");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Please note that the status will return to 'Pending' if you change details. \nAre your sure?", "Ticket edit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Close();
                    command = "update tblJobReq set CurrentStat = '" + "Pending" + "', Description = '" + txtDescription.Text + "', Prio='" + cbPrio.Text + "',IssueType = '" + cbIssue.Text + "',Subject = '" + txtSubject.Text + "',Imagepath = '" + lblPath.Text + "', Category = '" + cbCategory.Text + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated.");
                    this.Hide();
                    //overview();
                    findEmail();
                }
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            try
            {
                materialProgressBar1.Visible = true;
                pictureBox1.Image = null;
                // open file dialog   
                OpenFileDialog open = new OpenFileDialog();
                materialProgressBar1.Value = 25;
                // image filters  
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box  
                    materialProgressBar1.Value = 55;

                    pictureBox1.Image = new Bitmap(open.FileName);
                    fileName = open.FileName;
                    file = Path.GetFileName(fileName);
                    // image file path 
                    lblPath.Text = open.FileName;
                    materialProgressBar1.Value = 60;
                    filepath = @"\\phms0011\TicketingSystem\" + fileName;
                    upload2();
                }
            }
            catch (Exception)
            {
                MaterialMessageBox.Show("Error uploading image.");
            }
        }
        public void upload2()
        {
            try
            {
                string fileToCopy = Path.GetFileName(fileName);
                string destinationDirectory = @"\\phms0011\TicketingSystem\";
                materialProgressBar1.Value = 65;
                lblPath.Text = @"\\phms0011\TicketingSystem\" + Path.GetFileName(fileName);
                if (File.Exists(destinationDirectory + fileToCopy))
                {
                    DialogResult dialogResult = MessageBox.Show("The file you want to upload is already existing, do you want to overwrite?", "File already exist", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Copy(fileName, destinationDirectory + Path.GetFileName(fileName), true);
                    }
                }
                else
                {
                    File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));
                }
                materialProgressBar1.Value = 75;
                materialProgressBar1.Value = 90;
                MaterialMessageBox.Show("File uploaded");
                materialProgressBar1.Value = 100;
                //pictureBox1.Image = Image.FromFile(destinationDirectory + fileToCopy);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        public void attach()
        {
            try
            {
                pictureBox1.Image = null;
                // open file dialog   
                OpenFileDialog open = new OpenFileDialog();

                // image filters  
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box  


                    pictureBox1.Image = new Bitmap(open.FileName);
                    fileName = open.FileName;
                    file = Path.GetFileName(fileName);
                    // image file path 
                    lblPath.Text = open.FileName;

                    filepath = @"\\phms0011\TicketingSystem\" + fileName;
                    //upload();
                }
            }
            catch (Exception)
            {
                MaterialMessageBox.Show("Error uploading image.");
            }
        }
        public void upload()
        {
            DialogResult dialogResult = MessageBox.Show("Are your sure about the data you entered? \n Please double check", "Ticket file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (pictureBox1.Image == null)
                    {

                    }
                    else
                    {
                        upload();
                    }
                    string tag;
                    con.Close();
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    var stringChars = new char[5];
                    var random = new Random();
                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var finalString = new String(stringChars);

                    tag = "TM" + GlobalLogin.EmpiID + DateTime.Now.Month + DateTime.Now.Year + finalString + "GGEZ";

                    command = "insert into tblJobReq ([EmpiID],[TicketTag],[Description],[Prio],[CurrentStat],[Department],[IssueType],[Imagepath],DateFiled,Requestor,TimeFiled,Name,Category)values('" + txtID.Text + "','" + tag + "','" + txtDescription.Text + "','" + cbPrio.Text + "','" + "Pending" + "','" + txtDepartment.Text + "','" + cbIssue.Text + "','" + @"\\PHMS0011\TicketingSystem\" + file + "','" + DateTime.Now + "','" + GlobalLogin.Username + "','" + DateTime.Now.ToString("hh:mm") + "','" + txtName.Text + "','" + cbCategory.Text + "')";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket filed.");
                    pictureBox1.Image = null;
                    txtDescription.Text = "";
                    txtSubject.Text = "";
                    cbIssue.Text = "";
                    cbPrio.Text = "";

                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("Error uploading ticket.");
                    //MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //hehe no
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are your sure?", "Update ticket", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.Close();
                command = "update tblJobReq set CurrentStat = '" + "Approved" + "', DateDone = '" + DateTime.Now.ToShortDateString() + "', TimeDone = '" + DateTime.Now.ToShortTimeString() + "', LastEdit = '" + DateTime.Now + "', DateApproved = '" + DateTime.Now + "', ApprovedBy = '" + GlobalLogin.Username + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MaterialMessageBox.Show("Ticket updated.");
            }
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            if (requestor != GlobalLogin.Username)
            {
                MaterialMessageBox.Show("You cannot re-open ticket that is not yours");
            }
            else
            {
                if (status == "Done" || status == "Approved" || status == "Cancelled")
                {
                    DialogResult dialogResult = MessageBox.Show("Are your sure?", "Re-open ticket", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        con.Close();
                        command = "update tblJobReq set CurrentStat = '" + "Pending" + "', DateFiled = '" + DateTime.Now.ToShortDateString() + "', TimeFiled = '" + DateTime.Now.ToShortTimeString() + "', LastEdit = '" + DateTime.Now + "', DateApproved = '" + null + "', ApprovedBy = '" + null + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                        SqlCommand cmd = new SqlCommand(command, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MaterialMessageBox.Show("Ticket is re-opened.");
                        findEmail();
                    }
                }
                else
                {
                    MaterialMessageBox.Show("You cannot re-open ticket that is still pending or ongoing");
                }
            }
        }

        private void cbCategory_TextChanged(object sender, EventArgs e)
        {
            cbIssue.Items.Clear();
            DataTable dt = new DataTable();
            con.Close();
            command = "SELECT IssueType FROM [db_TicketingSystem].[dbo].[tblIssueType] where RootCause = '" + cbCategory.Text + "'";
            SqlCommand cmd2 = new SqlCommand(command, con);
            SqlDataAdapter da2 = new SqlDataAdapter(command, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            da2.Fill(dt);
            SqlDataReader sdr = cmd2.ExecuteReader();

            while (sdr.Read())
            {
                cbIssue.Items.Add(sdr[0].ToString());
            }
        }
        public void findEmail()
        {
            con.Close();
            command = "SELECT * FROM[db_TicketingSystem].[dbo].[tblUserLogin] ul left join tblTechnicianList tl on tl.EmpiID = ul.EmpiID where Userrole = 'SuperAdmin'";
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                emailadd = sdr["Email"].ToString();
                messageBody = "Hello " + sdr["Name"].ToString() + ", \nYou have new ticket update notification with following details. \nID: " + txtID.Text + "\nName: " + txtName.Text + "\n Priority level: " + cbPrio.Text + "\nIssue type: " + cbIssue.Text + "\nSubject: " + txtSubject.Text + "\nDescription: " + txtDescription.Text + "\n\n hehe";

            }
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
                MailMessage msg = new MailMessage("TicketingSystem_NO_REPLY@essilor.com.ph", emailadd);
                msg.From = new MailAddress("TicketingSystem_NO_REPLY@essilor.com.ph");
                msg.To.Add(new MailAddress(emailadd));
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
                //smt.Credentials = ntcd;
                //smt.EnableSsl = true;
                //smt.Port = 465;
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
    }
}
