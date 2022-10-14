using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

    public partial class AdminForm : MaterialForm
    {
        SqlConnection con = new SqlConnection(DbConnection.cs);
        string command;
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        string messageBody;
        DateTime ez;
        DateTime edited = default;
        string fileName;
        string fileonly;
        TimeSpan down;
        string Elapsed;
        string issueType = default;
        int techcount = 0;
        public AdminForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Blue400, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TicketModel.adminFile = 0;
            //WindowState = FormWindowState.Maximized;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            Overview();
            Timer timer1 = new Timer
            {
                Interval = 30000
            };
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(OnTimerEvent);
            if (dataGridView1.SelectedRows.Count == 0) return;
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
        }
        public void OnTimerEvent(object source, EventArgs e)
        {
            Overview();
        }
        public void DingSound()
        {
            if (DingSoundModel.Present != DingSoundModel.Previous)
            {
                if (DingSoundModel.Previous != "")
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"\\phms0011\TicketingSystem\dingSound\play.wav");
                    player.Play();
                }
            }
            DingSoundModel.Previous = DingSoundModel.Present;
        }
        public void Overview()
        {
            con.Close();
            command = "Select Requestor,[Prio],[CurrentStat] as 'Status',Subject,[Department], DateFiled as 'Date Filed',TimeFiled as 'Time Filed', Technician, Assigned,[TicketTag] AS 'Ticket Tag' from tblJobReq WHERE DateFiled >= DATEADD(day, -30, GETDATE()) order by case " +
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
            cmd.CommandTimeout = 0;
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr["Assigned"].ToString() == "")
                {
                    TicketModel.Assigned = 0;
                }
                else
                {
                    TicketModel.Assigned = Convert.ToInt32(sdr["Assigned"].ToString());
                }
            }
            DataSet datset = new DataSet();
            con.Close();
            datset.Clear();
            datset.Tables.Clear();
            //dgvOverview.Rows.Clear();
            con.Open();
            cmd.ExecuteNonQuery();
            dAdapter.Fill(datset);
            dgvOverview.DataSource = datset.Tables[0];
            //dAdapter.Fill(datset.Tables[0]);
            dgvOverview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOverview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvOverview.Columns["Assigned"].Visible = false;
            dgvOverview.Columns["Time Filed"].Visible = false;
            this.dgvOverview.DefaultCellStyle.Font = new Font("Poppins", 15);
            this.dgvOverview.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 12);
            dgvOverview.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvOverview_RowPrePaint();
            ChangeColor();
        }
        private void ChangeColor()
        {
            foreach (DataGridViewRow dgvr in dgvOverview.Rows)
            {
                if (dgvr.Cells["Status"].Value.ToString() == "Pending")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
                else if (dgvr.Cells["Status"].Value.ToString() == "Pending" && TicketModel.Assigned == 1)
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
                //dgvr.DefaultCellStyle.ForeColor = Color.White;
            }
            DataGridViewColumn column2 = dgvOverview.Columns["Prio"];
            DataGridViewColumn column1 = dgvOverview.Columns["Ticket Tag"];
            column2.Width = 50;
            column1.Width = 300;
        }

        private void dgvOverview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOverview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TicketModel.adminFile = 0;
            DateTime ez;
            try
            {
                int indexRow = e.RowIndex;
                if (indexRow >= 0)
                {
                    DataGridViewRow row = dgvOverview.Rows[indexRow];
                    TicketModel.TicketTag = dgvOverview.Rows[e.RowIndex].Cells["Ticket Tag"].Value.ToString();
                    DingSoundModel.Present = TicketModel.TicketTag;

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
                            ez = DateTime.Parse(sdr["DateFiled"].ToString());
                            TicketModel.DateFiled = Convert.ToDateTime(ez.ToShortDateString() + " " + string.Format("{0:t}", sdr["TimeFiled"].ToString()));
                            TicketModel.ImagePath = sdr["ImagePath"].ToString();
                            TicketModel.TimeFiled = TimeSpan.Parse(sdr["TimeFiled"].ToString());
                            TicketModel.Rootcause = sdr["RootCause"].ToString();
                            TicketModel.Technician = sdr["Technician"].ToString();
                            TicketModel.Requestor = sdr["Requestor"].ToString();
                            TicketModel.DateRequired = Convert.ToDateTime(sdr["DateRequired"]);
                            TicketModel.Findings = sdr["Findings"].ToString();
                            TicketModel.Actions = sdr["PreventiveActions"].ToString();
                            this.dgvOverview.DefaultCellStyle.Font = new Font("Poppins", 15);
                        }

                        //cbPrio.Items.Add(Convert.ToString(TicketModel.Priority));
                        //cbPrio.SelectedIndex = 0;
                        txtTag.Text = TicketModel.TicketTag;
                        txtDescription.Text = TicketModel.Description;
                        txtSubject.Text = TicketModel.Subject;
                        txtStatus.Text = TicketModel.Currentstat;
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
                //MaterialMessageBox.Show(ex.Message);
            }
        }

        private void btnTab1Export_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                TicketPreviewAdmin admin = new TicketPreviewAdmin();
                admin.Show();
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void materialTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            SelectedTab3();
            SelectTech();
        }

        public void SelectedTab2()
        {
            con.Close();
            command = "Select * from tblJobReq WHERE DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "' order by DateFiled desc";
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet datset = new DataSet();
            dAdapter.Fill(datset);
            dataGridView1.DataSource = datset.Tables[0];
            con.Close();
        }

        public void SelectedTab3()
        {
            TechCrud();
            IssueTypeCrud();
        }

        public void TechCrud()
        {
            con.Close();
            command = "select * from tblTechListFull";
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet datset = new DataSet();
            con.Close();
            datset.Clear();
            datset.Tables.Clear();
            //dgvOverview.Rows.Clear();
            con.Open();
            cmd.ExecuteNonQuery();
            dAdapter.Fill(datset);
            dgvTech.DataSource = datset.Tables[0];
            //dAdapter.Fill(datset.Tables[0]);
            dgvTech.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTech.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvTech.RowTemplate.Height = 35;
        }
        public void IssueTypeCrud()
        {
            con.Close();
            command = "SELECT [IssueType],[RootCause] FROM [db_TicketingSystem].[dbo].[tblIssueType]";
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet datset = new DataSet();
            con.Close();
            datset.Clear();
            datset.Tables.Clear();
            //dgvOverview.Rows.Clear();
            con.Open();
            cmd.ExecuteNonQuery();
            dAdapter.Fill(datset);
            dgvIssue.DataSource = datset.Tables[0];
            //dAdapter.Fill(datset.Tables[0]);
            dgvIssue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIssue.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvIssue.RowTemplate.Height = 35;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (txtSearch.Text == "")
                {
                    SelectedTab2();
                }
                else
                {
                    command = "Select * from tblJobReq " +
                                   "WHERE TicketTag = '" + txtSearch.Text + "' and DateFiled between '" + dateTimePicker2.Value + "' and '" + dateTimePicker1.Value + "'" +
                                   "order by DateFiled desc";
                    con.Close();
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter da = new SqlDataAdapter(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ds.Clear();
                    ds.Tables.Clear();
                    DataTable dt2 = new DataTable();
                    dAdapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    //dAdapter.Fill(datset.Tables[0]);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    this.dgvOverview.DefaultCellStyle.Font = new Font("Poppins", 12);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are your sure?", "Update ticket", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Close();
                    command = "update tblJobReq set CurrentStat = '" + "Pending" + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated.");
                    Overview();
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
                                Elapsed = ((int)Math.Round(down.TotalHours, MidpointRounding.AwayFromZero)).ToString();
                                if (sdr["Technician"].ToString().ToUpper() == GlobalLogin.FirstName + " " + GlobalLogin.LastName)
                                {
                                    SqlConnection con2 = new SqlConnection(DbConnection.cs);
                                    con2.Close();
                                    command = "update tblJobReq set CurrentStat = '" + "Done" + "', DateDone = '" + DateTime.Now.ToShortDateString() + "', TimeDone = '" + DateTime.Now.ToShortTimeString() + "', Elapsed = '" + Elapsed + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                                    SqlCommand cmd2 = new SqlCommand(command, con2);
                                    con2.Open();
                                    cmd2.ExecuteNonQuery();
                                    MaterialMessageBox.Show("Ticket updated.");
                                    Overview();
                                }
                                else
                                {
                                    MaterialMessageBox.Show("You are not the assigned technician");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error loading ticket");
                        }
                    }
                    catch (Exception)
                    {
                    }
                    
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
                    command = "update tblJobReq set CurrentStat = '" + "Ongoing" + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated.");
                    Overview();
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
                DialogResult dialogResult = MessageBox.Show("Are your sure?", "Update ticket", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Close();
                    command = "update tblJobReq set CurrentStat = '" + "Cancelled" + "' where TicketTag = '" + TicketModel.TicketTag + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MaterialMessageBox.Show("Ticket updated.");
                    Overview();
                }
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (cbTechReportGen.Text == "")
            {
                MaterialMessageBox.Show("Select technician first");
            }
            else
            {
                panelExtract.Visible = true;
                if (dateTimePicker1.Value.ToString("MMM") == dateTimePicker2.Value.ToString("MMM"))
                {
                    txtMonth.Text = dateTimePicker1.Value.ToString("MMMM");
                }
                else
                {
                    txtMonth.Text = dateTimePicker1.Value.ToString("MMM") + " - " + dateTimePicker2.Value.ToString("MMM");
                }
                SelectTech();
                HoursCompute();
                WorkDone();
                WorkUndone();
                AverageDowntime();
            }
        }
        public void SelectTech()
        {
            if (techcount == 0)
            {
                con.Close();
                command = "select Name from tblTechnicianList";
                SqlCommand cmd2 = new SqlCommand(command, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                techcount++;
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                while (sdr2.Read())
                {
                    cbTechReportGen.Items.Add(sdr2["Name"].ToString());
                }
            }
        }
        public void HoursCompute()
        {
            try
            {
                con.Close();
                if (cbTechReportGen.Text == "All")
                {
                    command = "SELECT sum(Elapsed) as 'hours' FROM [db_TicketingSystem].[dbo].[tblJobReq] where DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'";
                }
                else
                {
                    command = "SELECT sum(Elapsed) as 'hours' FROM [db_TicketingSystem].[dbo].[tblJobReq] where Technician = '" + cbTechReportGen.Text + "' and DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'";
                }
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        TimeSpan total = dateTimePicker2.Value - dateTimePicker1.Value;
                        int divide = total.Days;
                        ComputeModel.numberofHours = Convert.ToInt32(sdr["hours"].ToString()) / divide;
                        txtNoofHours.Text = ComputeModel.numberofHours.ToString();
                    }
                }
            }
            catch (Exception)
            {
                //Who cares?
            }
        }
        public void WorkDone()
        {
            con.Close();
            if (cbTechReportGen.Text == "All")
            {
                //AFAB00811722E
                command = "SELECT count(CurrentStat) as 'workdone' FROM [db_TicketingSystem].[dbo].[tblJobReq] where CurrentStat = 'Approved' or CurrentStat = 'Done' and DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'";
            }
            else
            {
                command = "SELECT count(CurrentStat) as 'workdone' FROM [db_TicketingSystem].[dbo].[tblJobReq] where Technician = '" + cbTechReportGen.Text + "' and CurrentStat = 'Approved' and CurrentStat = 'Done' and DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'";
            }

            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    ComputeModel.numberofWorkDone = Convert.ToInt32(sdr["workdone"].ToString());
                    txtWorkDone.Text = ComputeModel.numberofWorkDone.ToString();
                }
            }
        }
        public void WorkUndone()
        {
            if (cbTechReportGen.Text == "All")
            {
                command = "SELECT count(CurrentStat) as 'workUndone' FROM [db_TicketingSystem].[dbo].[tblJobReq] where CurrentStat = 'Pending' or DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'";
            }
            else
            {
                command = "SELECT count(CurrentStat) as 'workUndone' FROM [db_TicketingSystem].[dbo].[tblJobReq] where Technician = '" + cbTechReportGen.Text + "' and CurrentStat = 'Pending' and DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'";
            }
            con.Close();
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    ComputeModel.numberofWorkUndone = Convert.ToInt32(sdr["workUndone"].ToString());
                    txtWorkNotDone.Text = ComputeModel.numberofWorkUndone.ToString();
                }
            }
        }
        public void AverageDowntime()
        {
            try
            {
                con.Close();
                if (cbTechReportGen.Text == "All")
                {
                    command = "SELECT count(*) as 'tickets' FROM [db_TicketingSystem].[dbo].[tblJobReq] where DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'";
                }
                else
                {
                    command = "SELECT count(*) as 'tickets' FROM [db_TicketingSystem].[dbo].[tblJobReq] where Technician = '" + cbTechReportGen.Text + "' and DateFiled between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'";
                }
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ComputeModel.downtimeSum = Convert.ToInt32(sdr["tickets"].ToString());
                        ComputeModel.downtimeTotal = ComputeModel.downtimeSum/ComputeModel.numberofHours;
                        txtAveDowntime.Text = ComputeModel.downtimeTotal.ToString();
                    }
                }
            }
            catch (Exception)
            {
                //Who cares?
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (dgvOverview.CurrentCell != null)
            {
                TicketModel.adminFile = 0;
                TicketPreviewAdmin admin = new TicketPreviewAdmin();
                admin.Show();
            }
            else
            {
                MaterialMessageBox.Show("Please select a ticket first.");
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Overview();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            TicketModel.adminFile = 1;
            TicketPreviewAdmin admin = new TicketPreviewAdmin();
            admin.Show();
        }

        private void dgvTech_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indexRow = e.RowIndex;
                if (indexRow >= 0)
                {
                    DataGridViewRow row = dgvTech.Rows[indexRow];
                    dgvTech.Rows[e.RowIndex].Cells["EmpiID"].Value.ToString();
                    con.Close();
                    command = "SELECT*FROM [db_TicketingSystem].[dbo].[tblTechListFull] where EmpiID = '" + dgvTech.Rows[e.RowIndex].Cells["EmpiID"].Value.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            txtID.Text = sdr["EmpiID"].ToString();
                            txtFirstName.Text = sdr["FirstName"].ToString();
                            txtLastname.Text = sdr["LastName"].ToString();
                            txtEmail.Text = sdr["Email"].ToString();
                            cbDepartment.Items.Clear();
                            //cbDepartment.Text = sdr["Department"].ToString();
                            cbDepartment.Items.Add(sdr["Department"].ToString());
                            cbDepartment.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error loading technician");
                    }
                }
            }
            catch (Exception ex)
            {
                //MaterialMessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastname.Text = "";
            cbDepartment.Text = "";
            txtEmail.Text = "";
            // txtReason.Text = "";
            cbDepartment.Items.Clear();
            cbDepartmentItems();
        }
        public void cbDepartmentItems()
        {
            command = "select Department from dbo.tblDepartments";
            SqlConnection con = new SqlConnection(DbConnection.db);
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataSet ds2 = new DataSet();
            con.Open();
            cmd.ExecuteNonQuery();
            da.Fill(ds2);

            SqlDataReader sdr2 = cmd.ExecuteReader();

            while (sdr2.Read())
            {
                cbDepartment.Items.Add(sdr2[0].ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            command = "SELECT*FROM [db_TicketingSystem].[dbo].[tblUserlist] ul left join tblTechnicianList tl on tl.EmpiID = ul.EmpiID left join tblUserLogin logi on logi.EmpiID = tl.EmpiID where tl.EmpiID = '" + txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataSet ds2 = new DataSet();
            con.Open();
            cmd.ExecuteNonQuery();
            da.Fill(ds2);

            SqlDataReader sdr2 = cmd.ExecuteReader();

            while (sdr2.Read())
            {
                if (!sdr2.HasRows)
                {
                    newTech();
                }
            }
        }
        public void newTech()
        {
            try
            {
                con.Close();
                command = "insert into tblTechnicianList (EmpiID,Name)values(" + txtID.Text + ",'" + txtFirstName.Text + " " + txtLastname.Text + "')";
                string command2 = "insert into tblUserlist (EmpiID,FirstName,LastName,Department)values(" + txtID.Text + ",'" + txtFirstName.Text + "','" + txtLastname.Text + "','" + cbDepartment.Text + "')";
                string command3 = "insert into tblUserLogin (EmpiID,Username,Department,Email,Userrole)values(" + txtID.Text + ",'" + txtUsername.Text + "','" + cbDepartment.Text + "','" + txtEmail.Text + "','" + "SuperAdmin" + "')";
                SqlCommand cmd = new SqlCommand(command, con);
                SqlCommand cmd2 = new SqlCommand(command2, con);
                SqlCommand cmd3 = new SqlCommand(command3, con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                MaterialMessageBox.Show("Upload complete");
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Error, " + ex.ToString() + "");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            SelectedTab2();
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            SelectedTab2();
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            panelExtract.Visible = false;
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to extract?", "Extract", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }
                    worksheet.Columns.WrapText = false;
                    worksheet.Columns.AutoFit();
                    worksheet.Cells[dataGridView1.Rows.Count + 2, 1] = "Technician: " + cbTechReportGen.Text;
                    worksheet.Cells[dataGridView1.Rows.Count + 3, 1] = "Month: " + txtMonth.Text;
                    worksheet.Cells[dataGridView1.Rows.Count + 4, 1] = "Number of Hours: " + txtNoofHours.Text;
                    worksheet.Cells[dataGridView1.Rows.Count + 5, 1] = "Number of work done: " + txtWorkDone.Text;
                    worksheet.Cells[dataGridView1.Rows.Count + 6, 1] = "Number of work not done: " + txtWorkNotDone.Text;
                    worksheet.Cells[dataGridView1.Rows.Count + 7, 1] = "Average downtime: " + txtAveDowntime.Text;
                }
                catch (Exception)
                {
                }
            }
        }

        private void dgvIssue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indexRow = e.RowIndex;
                if (indexRow >= 0)
                {
                    DataGridViewRow row = dgvIssue.Rows[indexRow];
                    issueType =
                    dgvIssue.Rows[e.RowIndex].Cells["IssueType"].Value.ToString();
                    con.Close();
                    command = "SELECT [IssueType],[RootCause] FROM [db_TicketingSystem].[dbo].[tblIssueType] where IssueType = '" + dgvIssue.Rows[e.RowIndex].Cells["IssueType"].Value.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            txtIssueCrud.Text = sdr["IssueType"].ToString();
                            //cbRootcauseCrud.Text = sdr["RootCause"].ToString();
                            cbRootcauseCrud.Items.Clear();
                            //cbDepartment.Text = sdr["Department"].ToString();
                            cbRootcauseCrud.Items.Add(sdr["RootCause"].ToString());
                            cbRootcauseCrud.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error loading technician");
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            command = "SELECT [IssueType],[RootCause] FROM [db_TicketingSystem].[dbo].[tblIssueType] where IssueType = '" + txtIssueCrud.Text + "'";
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataSet ds2 = new DataSet();
            con.Open();
            cmd.ExecuteNonQuery();
            da.Fill(ds2);

            SqlDataReader sdr2 = cmd.ExecuteReader();

            while (sdr2.Read())
            {
                if (sdr2.HasRows)
                {
                    MaterialMessageBox.Show("This issue is already existing.");
                }
                else
                {
                    insertIssue();
                }
            }
        }

        public void insertIssue()
        {
            try
            {
                con.Close();
                command = "insert into tblIssueType ([IssueType],[RootCause])values('" + txtIssueCrud.Text + "','" + cbRootcauseCrud.Text + "')";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MaterialMessageBox.Show("Upload complete");
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Error, " + ex.ToString() + "");
            }
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {

        }

        private void txtTechValid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                try
                {
                    if (Int32.TryParse(txtTechValid.Text, out var outParse))
                    {
                        con.Close();
                        command = "update tblTechValid set Available = '" + txtTechValid.Text + "'";
                        SqlCommand cmd = new SqlCommand(command, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MaterialMessageBox.Show("Upload complete");
                    }
                    else
                    {
                        MaterialMessageBox.Show("Please enter number only");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
