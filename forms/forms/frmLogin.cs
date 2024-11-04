using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace forms
{
    public partial class frmLogin : Form
    {
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"D:\\School Works\\AppDev\\data.mdb\"";
        OleDbConnection conn;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "select username, password from account where username =@username and password =@password ";
            conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query,conn);
            cmd.Parameters.AddWithValue("@username",txtUname.Text);
            cmd.Parameters.AddWithValue("@password",txtPass.Text);
            OleDbDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                string username = rdr["username"].ToString();
                frmMain frm = new frmMain(username, conn);
                frm.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Credentials are Incorrect!", "Credentials");
            }
            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUname.Clear();
            txtPass.Clear();
            
        }
    }
}
