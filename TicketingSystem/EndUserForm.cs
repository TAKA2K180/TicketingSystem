using MaterialSkin;
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
    /*
     Dear maintainer:
    *
    /* When I wrote this, only God and I understood what I was doing
    /* Now, God only knows
    /*
    * You may think you know what the following code does.
    * But you dont. Trust me.
    * Fiddle with it, and youll spend many a sleepless
    * night cursing the moment you thought youd be clever
    * enough to "optimize" the code below.
    * Now close this file and go play with something else.
    *
    *
    * Once you are done trying to 'optimize' this routine,
    * and have realized what a terrible mistake that was,
    * please increment the following counter as a warning
    * to the next guy:
    *
    * total_hours_wasted_here = 0
    */
    public partial class EndUserForm : MaterialForm
    {
        SqlConnection con = new SqlConnection(DbConnection.cs);
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        string fileName;
        string filepath;
        string file;
        string command;
        string messageBody = default;
        string messageBody2 = default;
        string emailadd = default;
        string emailSubject = default;
        int ngi = 0;
        string wow = default;
        string ticket;
        int yeah = 0;
        string tag;
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] stringChars = new char[5];
        Random random = new Random();
        String finalString;
        public EndUserForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Blue400, TextShade.WHITE);
        }

        private void EndUserForm_Load(object sender, EventArgs e)
        {
            dgvOverview.ClearSelection();
            GetOverview();
            Tab2();
            FindLink();
            QTimer();
            //EmailNotif();
            Announce();
            TechValid();
            Timer timer1 = new Timer
            {
                Interval = 30000
            };
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(OnTimerEvent);
        }
        public void OnTimerEvent(object source, EventArgs e)
        {
            QTimer();
            TechValid();
        }
        public void TechValid()
        {
            con.Close();
            command = "SELECT Available FROM [db_TicketingSystem].[dbo].[tblTechValid]";
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr["Available"] != null)
                {
                    lblTechValid.Text = "Tech available: " + sdr["Available"].ToString() + "";
                }
                else
                {
                    lblTechValid.Visible = false;
                }
            }
        }
        public void QTimer()
        {
            int qnumber = 0;
            int snumber = 0;
            con.Close();
            command = "SELECT * FROM [db_TicketingSystem].[dbo].[tblJobReq] where DateFiled >= DATEADD(day, -5, GETDATE()) and CurrentStat = 'Pending' order by LastEdit asc";
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (Convert.ToInt32(sdr["EmpiID"]) == GlobalLogin.EmpiID)
                {
                    snumber++;
                }
                else
                {
                    lblQu.Visible = false;
                    qnumber++;
                }
            }
            lblQu.Text = "My queue: " + Convert.ToString(qnumber + snumber) + "";
        }
        public void EmailNotif()
        {
            int count = 0;
            if (count > 0)
            {
                if (DateTime.Now.Day == 15 || DateTime.Now.Day == 30)
                {
                    int taecount = 0;
                    con.Close();
                    command = "select * from tblFullDetails where EmpiID = '" + GlobalLogin.EmpiID + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            emailadd = sdr["Email"].ToString();
                            SqlConnection con2 = new SqlConnection(DbConnection.cs);
                            con2.Close();
                            command = "SELECT count (*) as 'tae' FROM [db_TicketingSystem].[dbo].[tblJobReq] where CurrentStat = 'Done' and EmpiID = '" + GlobalLogin.EmpiID + "'";
                            con2.Open();
                            SqlCommand cmd2 = new SqlCommand(command, con2);
                            cmd2.ExecuteNonQuery();
                            SqlDataReader sdr2 = cmd2.ExecuteReader();
                            if (sdr.HasRows)
                            {
                                while (sdr2.Read())
                                {
                                    taecount = Convert.ToInt32(sdr2["tae"]);
                                    if (taecount > 0)
                                    {
                                        messageBody = "Hello " + sdr["FirstName"].ToString().ToLower() + ", \nYou have " + taecount + " pending tickets to approve. \nThank you.";
                                        emailSubject = "Ticketing system notification";
                                        EmailAPI();
                                    }
                                }
                            }
                        }
                        count++;
                    }
                }
            }
        }
        public void GetOverview()
        {
            dgvOverview.ClearSelection();
            command = "Select EmpiID as 'ID', Requestor,[Prio],[CurrentStat] as 'Status',Subject,[Department], DateFiled as 'Date Filed',TimeFiled as 'Time Filed', Technician, Assigned,[TicketTag] AS 'Ticket Tag' from tblJobReq WHERE EmpiID = "+GlobalLogin.EmpiID+" and DateFiled >= DATEADD(day, -30, GETDATE()) order by case " +
                "when lower(CurrentStat) like '%Pending%' then 1 " +
                "when lower(CurrentStat) like '%Ongoing%' then 2 " +
                "when lower(CurrentStat) like '%Done%' then 3 " +
                "when lower(CurrentStat) like '%Approved%' then 4 " +
                "when lower(CurrentStat) like '%Cancelled%' then 5 " +
                "when lower(Prio) = 1 then 1 " +
                "when lower(Prio) = 2 then 2 " +
                "when lower(Prio) = 3 then 3 " +
                "when lower(Prio) = 4 then 4 " +
                "when lower(Prio) = 5 then 5 " +
                "else 6 end, DateFiled desc";
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet datset = new DataSet();
            con.Close();
            datset.Clear();
            datset.Tables.Clear();
            con.Open();
            cmd.ExecuteNonQuery();
            dAdapter.Fill(datset);
            dgvOverview.DataSource = datset.Tables[0];
            dgvOverview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOverview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvOverview.Columns["ID"].Visible = false;
            dgvOverview.Columns["Time Filed"].Visible = false;
            //dgvOverview.Columns["Condition"].Visible = false;
            dgvOverview.Columns["Department"].Visible = false;
            this.dgvOverview.DefaultCellStyle.Font = new Font("Poppins", 15);
            this.dgvOverview.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 10);
            this.dgvOverview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOverview.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            ChangeColor();
        }
        private void ChangeColor()
        {
            foreach (DataGridViewRow dgvr in dgvOverview.Rows)
            {
                if (dgvr.Cells["Status"].Value.ToString() == "Pending")
                {
                    dgvr.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e57373");
                    dgvr.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#e57373");
                }
                else if (dgvr.Cells["Status"].Value.ToString() == "Ongoing")
                {
                    dgvr.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00695c");
                }
                else if (dgvr.Cells["Status"].Value.ToString() == "Done" || dgvr.Cells["Status"].Value.ToString() == "Approved")
                {
                    dgvr.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0288d1");
                }
                else if (dgvr.Cells["Status"].Value.ToString() == "Cancelled")
                {
                    dgvr.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#455a64");
                }
                dgvr.Height = 50;
            }
            DataGridViewColumn column2 = dgvOverview.Columns["Prio"];
            DataGridViewColumn column1 = dgvOverview.Columns["Ticket Tag"];
            DataGridViewColumn column3 = dgvOverview.Columns["ID"];
            DataGridViewColumn column4 = dgvOverview.Columns["Date Filed"];
            column2.Width = 50;
            column1.Width = 100;
            column3.Width = 70;
        }
        public void Tab2()
        {
            {
                txtID.Text = Convert.ToString(GlobalLogin.EmpiID);
                txtName.Text = GlobalLogin.FirstName + " " + GlobalLogin.LastName;
                txtDepartment.Text = GlobalLogin.Department;
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

        private void btnTab2Attach_Click(object sender, EventArgs e)
        {
            try
            {
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
                    lblFile.Text = open.FileName;
                    materialProgressBar1.Value = 100;
                    filepath = LinkModel.Link + fileName;
                    //upload();
                }
            }
            catch (Exception)
            {
                MaterialMessageBox.Show("Error uploading image.");
            }

        }
        public void Upload()
        {
            try
            {
                string fileToCopy = fileName;
                string destinationDirectory = LinkModel.Link;

                File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSubject.Text == "" || txtName.Text == "" || txtID.Text == "" || txtDepartment.Text == "" || txtDescription.Text == "" || cbPrio.Text == "" || cbIssue.Text == "")
            {
                MaterialMessageBox.Show("Please fill up required fields");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are your sure about the data you entered? \nPlease double check", "Ticket file", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (pictureBox1.Image == null)
                        {
                            LinkModel.linkFinal = null;
                        }
                        else
                        {
                            LinkModel.linkFinal = LinkModel.Link;
                            Upload();
                        }
                        TagGenerator();
                        tag = "TM" + GlobalLogin.EmpiID + DateTime.Now.Year + finalString + "GGEZ";
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
                                    TagGenerator();
                                    tag = "TM" + GlobalLogin.EmpiID + DateTime.Now.Year + finalString + "GGEZ";
                                }
                            }
                        }
                        ticket = tag;
                        con.Close();
                        string descript;
                        descript = txtDescription.Text.Replace("\"", "").Replace("'", "");
                        command = "insert into tblJobReq ([EmpiID],[TicketTag],[Description],[Prio],[CurrentStat],[Department],[IssueType],[Imagepath],DateFiled,Requestor,TimeFiled,Name, Subject,LastEdit,Assigned,Category,DateRequired)values('" + txtID.Text + "','" + tag + "','" + descript + "','" + cbPrio.Text + "','" + "Pending" + "','" + txtDepartment.Text + "','" + cbIssue.Text + "','" + LinkModel.linkFinal + file + "','" + DateTime.Now + "','" + GlobalLogin.Username + "','" + DateTime.Now.ToString("hh:mm") + "','" + txtName.Text + "','" + txtSubject.Text + "','" + DateTime.Now + "',0,'" + cbCategory.Text + "','" + dtDateRequired.Value.ToShortDateString() + "')";
                        SqlCommand cmd = new SqlCommand(command, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MaterialMessageBox.Show("Ticket filed.");
                        pictureBox1.Image = null;
                        txtDescription.Text = "";
                        txtSubject.Text = "";
                        cbIssue.Text = "";
                        cbPrio.Text = "";
                        dgvOverview.Update();
                        dgvOverview.Refresh();
                        GetOverview();
                        FindDetails();
                        FindEmail();
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show(ex.Message);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //hehe no
                }
                materialTabControl1.SelectedTab = materialTabControl1.TabPages["tabPage1"];
            }
        }
        public void TagGenerator()
        {
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            finalString = new String(stringChars);
        }
        public void FindEmail()
        {
            try
            {
                //con.Close();
                //command = "SELECT * FROM[db_TicketingSystem].[dbo].[tblUserLogin] ul left join tblTechnicianList tl on tl.EmpiID = ul.EmpiID where Userrole = 'SuperAdmin'";
                //con.Open();
                //SqlCommand cmd = new SqlCommand(command, con);
                //SqlDataReader sdr = cmd.ExecuteReader();
                //while (sdr.Read())
                //{
                    emailadd = "ph-empi-it-support@essilor.com";
                    messageBody = "Hello, \nYou have new ticket notification with following details. \nID: " + TicketModel.ID + "\nName: " + TicketModel.Name + "\nPriority level: " + TicketModel.Priority + "\nIssue type: " + TicketModel.IssueType + "\nSubject: " + TicketModel.Subject + "\nDescription: " + TicketModel.Description + "\n\n hehe";
                    messageBody2 = "";
                    emailSubject = "New ticket notification";
                    SendEmail();
                //}
            }
            catch (Exception)
            {
            }
        }
        public void SendEmail()
        {
            EmailAPI();
        }
        public void EmailAPI()
        {
            try
            {
                MailMessage msg = new MailMessage("TicketingSystem_NO_REPLY@essilor.com.ph", emailadd);
                msg.From = new MailAddress("TicketingSystem_NO_REPLY@essilor.com.ph");
                msg.To.Add(new MailAddress(emailadd));
                msg.Subject = emailSubject;
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
                smt.SendCompleted += new SendCompletedEventHandler(smt_SendCompleted);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
                ngi++;
                wow = ex.ToString();
            }
            Final();
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

        public void Final()
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

        private void btnTab1Refresh_Click(object sender, EventArgs e)
        {
            GetOverview();
        }

        private void btnTab1Details_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                TicketPreview tp = new TicketPreview();
                tp.Show();
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void dgvOverview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime ez;
            try
            {
                int indexRow = e.RowIndex;
                if (indexRow >= 0)
                {
                    DataGridViewRow row = dgvOverview.Rows[indexRow];
                    TicketModel.TicketTag = dgvOverview.Rows[e.RowIndex].Cells["Ticket Tag"].Value.ToString();

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
                            TicketModel.ID = sdr["EmpiID"].ToString();
                            TicketModel.Name = sdr["FirstName"].ToString() + " " + sdr["LastName"].ToString();
                            TicketModel.Department = sdr["Department"].ToString();
                            TicketModel.Subject = sdr["Subject"].ToString();
                            TicketModel.Description = sdr["Description"].ToString();
                            TicketModel.Priority = Convert.ToInt32(sdr["Prio"].ToString());
                            TicketModel.IssueType = sdr["IssueType"].ToString();
                            TicketModel.Condition = sdr["Condition"].ToString();
                            TicketModel.Currentstat = sdr["CurrentStat"].ToString();
                            ez = Convert.ToDateTime(sdr["DateFiled"].ToString());
                            TicketModel.DateFiled = Convert.ToDateTime(ez.ToShortDateString() + " " + string.Format("{0:t}", sdr["TimeFiled"].ToString()));
                            TicketModel.ImagePath = sdr["ImagePath"].ToString();
                            TicketModel.TimeFiled = TimeSpan.Parse(sdr["TimeFiled"].ToString());
                            TicketModel.Rootcause = sdr["RootCause"].ToString();
                            TicketModel.Technician = sdr["Technician"].ToString();
                            TicketModel.Requestor = sdr["Requestor"].ToString();
                            TicketModel.DateRequired = Convert.ToDateTime(sdr["DateRequired"].ToString());
                            TicketModel.ActionsTaken = sdr["PreventiveActions"].ToString();
                            txtOverviewTag.Text = TicketModel.TicketTag;
                            txtOverviewDescription.Text = sdr["Description"].ToString();
                            txtOverviewSubject.Text = sdr["Subject"].ToString();
                            txtOverviewStatus.Text = TicketModel.Currentstat;
                            txtAction.Text = sdr["PreventiveActions"].ToString();
                        }
                        this.dgvOverview.DefaultCellStyle.Font = new Font("Poppins", 15);
                        txtOverviewTag.Text = TicketModel.TicketTag;
                        txtOverviewStatus.Text = TicketModel.Currentstat;
                        txtAction.Text = TicketModel.ActionsTaken;
                    }
                    else
                    {
                        MessageBox.Show("Error loading ticket");
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void btnTab1Export_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are your sure?", "Ticket already done?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Close();
                    command = "update tblJobReq set CurrentStat = '" + "Done" + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated.");
                    GetOverview();
                }
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                if (TicketModel.Currentstat == "Ongoing")
                {
                    MaterialMessageBox.Show("Ticket is already ongoing");
                }
                DialogResult dialogResult = MessageBox.Show("Are your sure?", "Update ticket", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Close();
                    command = "update tblJobReq set CurrentStat = '" + "Pending" + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated.");
                    GetOverview();
                }
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are your sure?", "Update ticket", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Close();
                    command = "command = update tblJobReq set CurrentStat = '" + "Done" + "', DateDone = '" + DateTime.Now.ToShortDateString() + "', TimeDone = '" + DateTime.Now.ToShortTimeString() + "', LastEdit = '" + DateTime.Now + "', DateApproved = '" + DateTime.Now + "', ApprovedBy = '" + GlobalLogin.Username + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated.");
                    GetOverview();
                }
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are your sure?", "Update ticket", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Close();
                    command = "update tblJobReq set CurrentStat = '" + "Ongoing" + "', LastEdit = '" + DateTime.Now + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated.");
                    GetOverview();
                }
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                if (TicketModel.Currentstat == "Done")
                {
                    MaterialMessageBox.Show("Ticket is already done.");
                }
                else if (TicketModel.Currentstat == "Cancelled")
                {
                    MaterialMessageBox.Show("Ticket is already cancelled.");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are your sure?", "Update ticket", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        con.Close();
                        command = "update tblJobReq set CurrentStat = '" + "Cancelled" + "', LastEdit = '" + DateTime.Now + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                        SqlCommand cmd = new SqlCommand(command, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MaterialMessageBox.Show("Ticket updated.");
                        GetOverview();
                    }
                }
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void materialTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            txtName.Text = GlobalLogin.FirstName + " " + GlobalLogin.LastName;
            txtDepartment.Text = GlobalLogin.Department;
            txtID.Text = Convert.ToString(GlobalLogin.EmpiID);
        }

        private void cbPrio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                if (TicketModel.Requestor != GlobalLogin.Username)
                {
                    MaterialMessageBox.Show("You are not the requestor of this ticket.");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are your sure?", "Approve ticket?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        con.Close();
                        command = "update tblJobReq set CurrentStat = '" + "Approved" + "' , DateApproved = '" + DateTime.Now + "', ApprovedBy = '" + GlobalLogin.Username + "',LastEdit = '" + DateTime.Now + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                        SqlCommand cmd = new SqlCommand(command, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MaterialMessageBox.Show("Ticket approved.");
                        GetOverview();
                    }
                }
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }
        public void FindLink()
        {
            con.Close();
            command = "select Link from tblLink";
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                LinkModel.Link = sdr["Link"].ToString();
            }
        }
        public void FindDetails()
        {
            con.Close();
            command = "select * FROM [db_TicketingSystem].[dbo].[tblJobReq] where TicketTag = '" + ticket + "'";
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TicketModel.ID = sdr["EmpiID"].ToString();
                TicketModel.Name = sdr["Name"].ToString();
                TicketModel.Subject = sdr["Subject"].ToString();
                TicketModel.Description = sdr["Description"].ToString();
                TicketModel.Priority = Convert.ToInt32(sdr["Prio"].ToString());
                TicketModel.IssueType = sdr["IssueType"].ToString();
            }
        }

        private void dgvOverview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            emailRequest er = new emailRequest();
            er.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                GetOverview();
            }
            else
            {
                try
                {
                    (dgvOverview.DataSource as DataTable).DefaultView.RowFilter = string.Format("'Subject' LIKE '%{0}%'", (txtSearch.Text));
                    // (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("EmpiID = " + txtID.Text + "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
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
                txtDepartment.Text = sdr["Department"].ToString();
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
        public void Announce()
        {
            lblAnnounce.Text = "Priority level: \n1 - Highest priority (Critical)\n2 - Medium priority(Important)\n3 - Low priority(Important but not urgent)\n4 - Very low priority(Not urgent and important)\n5 - Planned for future";
            //command = "SELECT max([id]) as id, [Announcement] FROM [db_TicketingSystem].[dbo].[tblAnnounceString] group by id, Announcement";
            //con.Close();
            //SqlCommand cmd = new SqlCommand(command, con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //SqlDataReader sdr = cmd.ExecuteReader();
            //if (sdr.HasRows)
            //{
            //    while (sdr.Read())
            //    {
            //        txtAnnounce.Text = sdr["Announcement"].ToString();
            //    }
            //}
            //else
            //{
            //    txtAnnounce.Text = "Note: Please double check details before submitting your ticket to prevent misunderstanding. Thank you.";
            //}
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are your sure about the data you entered? \nPlease double check", "Ticket file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    TagGenerator();
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
                                TagGenerator();
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
                    FindEmailReq();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("Error, " + ex.Message + "");
                }
            }
        }
        public void FindEmailReq()
        {
            //emailadd = sdr["Email"].ToString();
            messageBody = "Hello all, \nPlease be informed that " + GlobalLogin.Username + " has requested for a new email account with the following details. \nID: " + txtID.Text + "\nName: " + txtFirst.Text + " " + txtLast.Text + "\nDepartment: " + cbDept.Text + "\nReason: " + txtReason.Text + "\nThank you.";
            messageBody2 = "";

            SendEmailReq();
        }
        public void SendEmailReq()
        {
            EmailReqAPI();
        }
        public void EmailReqAPI()
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

                smt.SendCompleted += new SendCompletedEventHandler(smt_SendCompleted2);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
                ngi++;
                wow = ex.ToString();
            }
            final();
        }
        void smt_SendCompleted2(object sender, AsyncCompletedEventArgs e)
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

        private void txtAnnounce_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbDept_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (count == 0)
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
                count++;
            }
            
        }
    }
}
