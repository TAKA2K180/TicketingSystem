using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TimeKeeping_System_v1._0._0._2.Model;


namespace TicketingSystem
{
    // If you're reading this, that means you have been put in charge of my
    //  previous project. I am so, so sorry for you. God speed.
    public partial class Login : MaterialForm
    {
        string userName = Environment.UserName;
        public const int ERROR_PASSWORD_MUST_CHANGE = 1907;
        public const int ERROR_LOGON_FAILURE = 1326;
        public const int ERROR_ACCOUNT_RESTRICTION = 1327;
        public const int ERROR_ACCOUNT_DISABLED = 1331;
        public const int ERROR_INVALID_LOGON_HOURS = 1328;
        public const int ERROR_NO_LOGON_SERVERS = 1311;
        public const int ERROR_INVALID_WORKSTATION = 1329;
        public const int ERROR_ACCOUNT_LOCKED_OUT = 1909;      //It gives this error if the account is locked, REGARDLESS OF WHETHER VALID CREDENTIALS WERE PROVIDED!!!
        public const int ERROR_ACCOUNT_EXPIRED = 1793;
        public const int ERROR_PASSWORD_EXPIRED = 1330;
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(string principal, string authority, string password, LogonTypes logonType, LogonProviders logonProvider, out IntPtr token);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        string username;
        string password;
        string domain_fqdn;
        string command;
        SqlConnection con = new SqlConnection(Model.DbConnection.cs);
        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //txtUsername.Text = userName;
            if (userName == "MANALORR")
            {
                txtPw.Text = "p@ssw0rd01";
                //button2.Enabled = false;
            }
            else if (userName == "_ADM_MANALOR")
            {
                txtPw.Text = "Essilor2022!";
            }
            else
            {
                txtUsername.Text = username;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPw.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please fill blank fields");
            }
            else
            {
                Userlogin();
            }
        }
        public void Userlogin()
        {
            con.Close();
            command = "select ts.EmpiID,Username,[Email],[Userrole], tk.FirstName, tk.LastName, tk.Department from dbo.tblUserLogin ts left join tblUserlist tk on tk.EmpiID = ts.EmpiID where Username = '" + txtUsername.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    GlobalLogin.Username = sdr["Username"].ToString();
                    GlobalLogin.UserRole = sdr["Userrole"].ToString();
                    GlobalLogin.Department = sdr["Department"].ToString();
                    GlobalLogin.FirstName = sdr["FirstName"].ToString();
                    GlobalLogin.LastName = sdr["LastName"].ToString();
                    GlobalLogin.EmpiID = Convert.ToInt32(sdr["EmpiID"]);
                    GlobalLogin.email = sdr["Email"].ToString();
                }
                CheckUserLogon();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("No account found, go to Sign up?", "Account not found", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Signup sign = new Signup();
                    sign.Show();
                    this.Hide();
                }
            }
        }
        public int CheckUserLogon()
        {
            int errorCode = 0;
            username = txtUsername.Text;
            password = txtPw.Text;
            domain_fqdn = "ASIA";
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain_fqdn, username, password))
            {
                if (!pc.ValidateCredentials(username, password))
                {
                    IntPtr token = new IntPtr();
                    try
                    {
                        if (!LogonUser(username, domain_fqdn, password, LogonTypes.Network, LogonProviders.Default, out token))
                        {
                            errorCode = Marshal.GetLastWin32Error();
                            //MessageBox.Show("ERROR" + errorCode);
                            if (errorCode == 1326)
                            {
                                MessageBox.Show("Login failed, please check your password");
                            }
                            else if (errorCode == 1909)
                            {
                                MessageBox.Show("Your account is now locked, please contact MIS");
                            }
                            else if (errorCode == 1331)
                            {
                                MessageBox.Show("Your account is disabled, please contact MIS");
                            }
                            else if (errorCode == 1330)
                            {
                                MessageBox.Show("Your account password has expired, please contact MIS");
                            }
                            else if (errorCode == 1311)
                            {
                                MessageBox.Show("Server is down, please check your internet connection");
                            }
                            else
                            {
                                MessageBox.Show("Invalid account");
                            }
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //throw;
                    }
                    finally
                    {
                        CloseHandle(token);
                    }
                }
                else
                {
                    AdminForm frm = new AdminForm();
                    EndUserForm frm2 = new EndUserForm();
                    if (GlobalLogin.UserRole == "SuperAdmin")
                    {
                        frm.Show();
                    }
                    else if (GlobalLogin.UserRole == "User")
                    {
                        frm2.Show();
                    }
                    //frm.Show();
                    this.Hide();
                }
            }
            return errorCode;
        }
        private enum LogonProviders : uint
        {
            Default = 0, // default for platform (use this!)
            WinNT35,     // sends smoke signals to authority
            WinNT40,     // uses NTLM
            WinNT50      // negotiates Kerb or NTLM
        }
        private enum LogonTypes : uint
        {
            Interactive = 2,
            Network = 3,
            Batch = 4,
            Service = 5,
            Unlock = 7,
            NetworkCleartext = 8,
            NewCredentials = 9
        }

        private void txtPw_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Signup sn = new Signup();
            sn.Show();
            this.Hide();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPw_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPw.Text == "" || txtUsername.Text == "")
                {
                    MessageBox.Show("Please provide Username and Password");
                    return;
                }
                Userlogin();
            }
        }
    }
}
