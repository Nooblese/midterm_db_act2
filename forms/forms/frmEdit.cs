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
    public partial class frmEdit : Form
    {
        OleDbConnection _conn;
        public frmEdit(OleDbConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "UPDATE employee set name =@name, email =@email, address =@address where Empid ="+txtID.Text+"";
            OleDbCommand cmd = new OleDbCommand(query,_conn);
            if (_conn.State != ConnectionState.Open) 
            {
                _conn.Open();
            }

            cmd.Parameters.AddWithValue("@name" , txtName.Text);
            cmd.Parameters.AddWithValue("@email" , txtEmail.Text);
            cmd.Parameters.AddWithValue("@address" , txtAddress.Text);
            cmd.ExecuteNonQuery();

            _conn.Close();

            MessageBox.Show("Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
