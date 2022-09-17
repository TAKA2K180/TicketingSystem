using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TicketingSystem.Model;

namespace TicketingSystem
{
    public partial class Signup : MaterialForm
    {
        string command;
        SqlConnection con = new SqlConnection(DbConnection.cs);
        public Signup()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (cbDept.Text == "" || txtEmail.Text == "" || txtID.Text == "" || txtName.Text == "" || txtUsername.Text == "")
            {
                MaterialMessageBox.Show("Please fill up required fields.");
            }
            else
            {
                con.Close();
                command = "select * from tblUserLogin where EmpiID = '" + txtID.Text + "'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    MaterialMessageBox.Show("You already have an account.");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Please confirm all your details before proceeding", "Are you sure?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        insert();
                    }
                }
            }
        }
        public void insert()
        {
            try
            {
                con.Close();
                command = "insert into tblUserLogin (EmpiID,Username,Department, Email, Userrole)values('" + txtID.Text + "','" + txtUsername.Text + "','" + cbDept.Text + "','" + txtEmail.Text + "','" + "User" + "')";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MaterialMessageBox.Show("Account created.");
            }
            catch (Exception)
            {
                MaterialMessageBox.Show("Error signing up.");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            command = "select Department from dbo.tblDepartments";
            SqlConnection con = new SqlConnection(@"Data Source = PHMS0011\SQLEXPRESS; Initial Catalog = db_Timekeeping; Persist Security Info = True; User ID = sa; Password = p@ssw0rd");
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
    }
}
