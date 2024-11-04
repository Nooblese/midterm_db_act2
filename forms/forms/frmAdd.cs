using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forms
{

    public partial class frmAdd : Form
    {
        OleDbConnection _conn;
        public frmAdd(OleDbConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "insert into employee(name,email,address,sex) values(@name,@email,@address,@sex)";
            OleDbCommand cmd = new OleDbCommand(query,_conn);
            if (_conn.State != ConnectionState.Open) 
            {
                _conn.Open();
            }

            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@sex", cmbSex.Text);
            cmd.ExecuteNonQuery();
            _conn.Close();

            MessageBox.Show("Successfully Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
