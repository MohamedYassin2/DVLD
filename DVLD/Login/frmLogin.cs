using DVLD.Classes;
using DVLD.Global_Classes;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Hash the entered password for comparison
            string hashedPassword = clsCryptography.EncryptUsingHashing(txtPassword.Text.Trim());

            // Find user by username and hashed password
            clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), hashedPassword);

            if (user != null)
            {
                // Check if the account is active
                if (!user.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your account is not active. Contact Admin.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Handle "Remember Me" functionality
                if (chkRememberMe.Checked)
                {
                    // Save hashed password to registry
                    if (!clsGlobal.SaveCredentialsToRegistry(txtUserName.Text.Trim(), hashedPassword))
                        return;
                }
                else
                {
                    // Clear saved credentials
                    if (!clsGlobal.SaveCredentialsToRegistry("", ""))
                    {
                        chkRememberMe.Checked = false;
                        return;
                    }
                       
                }

                // Set the current user and show the main form
                frmLogin_Load(null, null);
                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.RetrieveCredentialsFromRegistry(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = string.Empty;
                chkRememberMe.Checked = true;
            }
            else
            {
                txtPassword.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkRememberMe.Checked = false;
            }

          
        }
    }
}
