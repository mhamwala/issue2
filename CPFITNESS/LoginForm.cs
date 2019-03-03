using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CPFITNESS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"server=localhost;user id=root;database=cpfitness;allowuservariables=True");
            string query = "Select * from users where username = '" + txtUsername.Text.Trim() + "'and password = '" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sds = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sds.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                CpMain objcpMain = new CpMain();
                this.Hide();
                objcpMain.Show();
            }
            else
            {
                MessageBox.Show("Retry");
            }
        }
    }
}
