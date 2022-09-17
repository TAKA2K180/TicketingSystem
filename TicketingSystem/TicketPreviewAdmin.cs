using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using TicketingSystem.Model;
using TimeKeeping_System_v1._0._0._2.Model;

namespace TicketingSystem
{
    public partial class TicketPreviewAdmin : MaterialForm //material form inheritance
    {
        /*
         Dear maintainer:
        *
        /* When I wrote this, only God and I understood what I was doing
        /* Now, God only knows
        *
        * Once you are done trying to 'optimize' this routine,
        * and have realized what a terrible mistake that was,
        * please increment the following counter as a warning
        * to the next guy:
        *
        * total_hours_wasted_here = 0
        */

        SqlConnection con = new SqlConnection(DbConnection.cs);
        string command;
        int count = 0;
        int prio = 0;
        int yeah = 0;
        string emailadd;
        string messageBody;
        int ngi = 0;
        string wow = default;
        public TicketPreviewAdmin()
        {
            InitializeComponent();
        }

        private void TicketPreviewAdmin_Load(object sender, EventArgs e)
        {
            if (TicketModel.adminFile == 0)
            {
                Preview();
            }
            else
            {
                txtID.Text = GlobalLogin.EmpiID.ToString();
                txtName.Text = GlobalLogin.FirstName + " " + GlobalLogin.LastName;
                cbDepartment.Text = GlobalLogin.Department;
                btnTransfer.Enabled = false;
                lblDowntime.Text = "";
                lblDate.Text = "";
                lblTag.Text = "";
                AfterLoad();
            }
        }
        private void AfterLoad()
        {
            {
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
        public void Preview()
        {
            DateTime ez;
            DateTime edited = default;
            string fileName;
            string fileonly;
            TimeSpan down;

            try
            {
                con.Close();
                command = "select * from tblJobReq req left join tblUserlist ul on req.EmpiID = ul.EmpiID where TicketTag = '" + TicketModel.TicketTag + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        lblTag.Text = TicketModel.TicketTag;
                        txtID.Text = TicketModel.ID;
                        txtName.Text = TicketModel.Name;
                        cbDepartment.Text = TicketModel.Department;
                        txtDescription.Text = TicketModel.Description;
                        txtSubject.Text = TicketModel.Subject;
                        dtDateRequired.Value = TicketModel.DateRequired;
                        cbIssue.Items.Add(TicketModel.IssueType);
                        cbIssue.SelectedIndex = 0;
                        cbPrio.Items.Add(Convert.ToString(TicketModel.Priority));
                        cbPrio.SelectedIndex = 0;
                        cbStatus.Items.Add(TicketModel.Currentstat);
                        cbStatus.SelectedIndex = 0;
                        cbTech.Items.Add(TicketModel.Technician);
                        cbTech.SelectedIndex = 0;
                        cbCategory.Items.Add(sdr["RootCause"].ToString());
                        cbCategory.SelectedIndex = 0;
                        ez = Convert.ToDateTime(sdr["DateFiled"].ToString());
                        if (sdr["DateApproved"].ToString() != "")
                        {
                            edited = Convert.ToDateTime(sdr["DateApproved"].ToString());
                        }

                        if (edited != default)
                        {
                            down = edited - TicketModel.DateFiled;
                        }
                        else
                        {
                            down = DateTime.Now - TicketModel.DateFiled;
                        }

                        lblDowntime.Text = ((int)Math.Round(down.TotalHours, MidpointRounding.AwayFromZero)).ToString() + " Hours";
                        lblDate.Text = Convert.ToString(TicketModel.DateFiled);
                        txtRequestor.Text = TicketModel.Requestor;
                        cbTech.Text = TicketModel.Technician;
                        if (TicketModel.ImagePath == "")
                        {
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            fileName = TicketModel.ImagePath;
                            fileonly = fileName.Remove(0, 27);
                            lblPath.Text = fileonly;
                            pictureBox1.Image = Image.FromFile(fileName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error loading ticket");
                }
                {
                    con.Close();
                    command = "select Name from tblTechnicianList";
                    SqlCommand cmd2 = new SqlCommand(command, con);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    SqlDataReader sdr2 = cmd2.ExecuteReader();
                    while (sdr2.Read())
                    {
                        cbTech.Items.Add(sdr2["Name"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            OpenFolder(@"\\phms0011\TicketingSystem");
        }

        private void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }

            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath));
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTech.Text == "")
                {
                    MaterialMessageBox.Show("Please select a technician first");
                }
                else
                {
                    con.Close();
                    if (cbStatus.Text == "Done")
                    {
                        command = "update tblJobReq set Prio = '" + cbPrio.Text + "', CurrentStat = '" + cbStatus.Text + "',Category = '" + cbCategory.Text + "', IssueType = '" + cbIssue.Text + "', RootCause = '" + txtRootCause.Text + "', PreventiveActions = '" + txtPreventive.Text + "', Technician = '" + cbTech.Text + "', DateDone = '" + DateTime.Now + "', TimeDone = '" + DateTime.Now.ToShortTimeString() + "', Assigned = 1, Findings = '"+txtDescription.Text+"', Category = '"+cbCategory.Text+"' where TicketTag = '" + lblTag.Text + "'";
                    }
                    else if (cbStatus.Text == "Ongoing")
                    {
                        command = "update tblJobReq set Prio = '" + cbPrio.Text + "', CurrentStat = '" + cbStatus.Text + "',Category = '" + cbCategory.Text + "', IssueType = '" + cbIssue.Text + "', RootCause = '" + txtRootCause.Text + "', PreventiveActions = '" + txtPreventive.Text + "', Technician = '" + cbTech.Text + "', LastEdit = '" + DateTime.Now + "', Assigned = 1, Findings = '" + txtDescription.Text + "', Category = '" + cbCategory.Text + "' where TicketTag = '" + lblTag.Text + "'";
                    }
                    else if (cbStatus.Text == "Pending")
                    {
                        command = "update tblJobReq set Prio = '" + cbPrio.Text + "', CurrentStat = '" + cbStatus.Text + "',Category = '" + cbCategory.Text + "', IssueType = '" + cbIssue.Text + "', RootCause = '" + txtRootCause.Text + "', PreventiveActions = '" + txtPreventive.Text + "', Technician = '" + cbTech.Text + "', LastEdit = '" + DateTime.Now + "', Assigned = 1, Findings = '" + txtDescription.Text + "', Category = '" + cbCategory.Text + "' where TicketTag = '" + lblTag.Text + "'";
                    }
                    else if (cbStatus.Text == "")
                    {
                        MaterialMessageBox.Show("Please select status");
                    }
                    //command = "update tblJobReq set Prio = '" + cbPrio.Text + "', CurrentStat = '"+cbStatus.Text+"', IssueType = '"+cbIssue.Text+"', Condition = '"+cbCondition.Text+"', RootCause = '"+txtRootcause.Text+ "', PreventiveActions = '"+txtPreventive.Text+"', Technician = '"+GlobalLogin.Username+"'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated");
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Error updating, " + ex.Message + "");
            }
        }

        private void cbStatus_Click(object sender, EventArgs e)
        {

        }

        private void cbStatus_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void cbStatus_MouseHover(object sender, EventArgs e)
        {
            if (count == 0)
            {
                DataTable dt = new DataTable();
                con.Close();
                command = "SELECT Status FROM [db_TicketingSystem].[dbo].[tblStatus]";
                SqlCommand cmd2 = new SqlCommand(command, con);
                SqlDataAdapter da2 = new SqlDataAdapter(command, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                da2.Fill(dt);
                SqlDataReader sdr = cmd2.ExecuteReader();
                while (sdr.Read())
                {
                    cbStatus.Items.Add(sdr[0].ToString());
                }
                count++;
            }
        }

        private void cbPrio_MouseHover(object sender, EventArgs e)
        {
            if (prio == 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    cbPrio.Items.Add(i);
                }
                prio++;
            }
        }

        private void materialExpansionPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            con.Close();
            command = "SELECT * FROM[db_TicketingSystem].[dbo].[tblUserLogin] ul left join tblTechnicianList tl on tl.EmpiID = ul.EmpiID where ul.EmpiID = '" + GlobalLogin.EmpiID + "'";
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr.HasRows)
                {
                    if (cbTech.Text != "")
                    {
                        if (sdr["Name"].ToString() == cbTech.Text)
                        {
                            if (panelTransfer.Visible != true)
                            {
                                panelTransfer.Visible = true;
                            }
                            else
                            {
                                panelTransfer.Visible = false;
                            }
                            if (yeah == 0)
                            {
                                SqlConnection con2 = new SqlConnection(DbConnection.cs);
                                con2.Close();
                                command = "select Name from tblTechnicianList";
                                SqlCommand cmd2 = new SqlCommand(command, con2);
                                con2.Open();
                                cmd2.ExecuteNonQuery();
                                SqlDataReader sdr2 = cmd2.ExecuteReader();
                                while (sdr2.Read())
                                {
                                    cbTechnician.Items.Add(sdr2["Name"].ToString());
                                    yeah++;
                                }
                            }
                        }
                        else
                        {
                            MaterialMessageBox.Show("You are not the assigned technician.");
                        }
                    }
                    else
                    {
                        MaterialMessageBox.Show("No assigned tech yet");
                    }
                }
            }
        }
        private void materialButton5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                command = "update tblJobReq set Technician = '" + cbTechnician.Text + "'  where TicketTag = '" + TicketModel.TicketTag + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();

                MaterialMessageBox.Show("Transferred.");
                emailTransfer();
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
        public void emailTransfer()
        {
            int yeah = 0;
            con.Close();
            command = "SELECT * FROM[db_TicketingSystem].[dbo].[tblUserLogin] ul left join tblTechnicianList tl on tl.EmpiID = ul.EmpiID where Name = '" + cbTechnician.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr.HasRows)
                {
                    emailadd = sdr["Email"].ToString();
                    messageBody = "Hello " + sdr["Username"].ToString() + ", \nPlease be informed that ticket " + lblTag.Text + "\nSubject: " + txtSubject.Text + "\nDescription: " + txtDescription.Text + "\nRequestor: " + txtRequestor + " \nhas been transferred to you by " + GlobalLogin.Username + ".\nThank you.";
                }
                else
                {
                    MaterialMessageBox.Show("No technician found.");
                    yeah++;
                }
            }
            if (yeah == 0)
            {
                sendEmail();
            }
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
        public void smt_SendCompleted(object sender, AsyncCompletedEventArgs e)
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
        private void materialButton6_Click(object sender, EventArgs e)
        {
            if (panelTransfer.Visible == true)
            {
                panelTransfer.Visible = false;
            }
            else if (panelTransfer.Visible == false)
            {
                panelTransfer.Visible = true;
            }
        }

        private void cbRootCause_TextChanged(object sender, EventArgs e)
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

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_Validated(object sender, EventArgs e)
        {
            con.Close();
            command = "select * FROM [db_TicketingSystem].[dbo].[tblUserlist] where EmpiID = '" + txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                txtName.Text = sdr["FirstName"].ToString() + " " + sdr["LastName"].ToString();
                cbDepartment.Items.Add(sdr["Department"].ToString());
                cbDepartment.SelectedIndex = 0;
            }
        }
    }
}
