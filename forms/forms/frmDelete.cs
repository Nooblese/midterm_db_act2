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
    public partial class frmDelete : Form
    {
        OleDbConnection _conn;
        public frmDelete(OleDbConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string query = "DELETE from employee where name = @name and sex = @sex";
            OleDbCommand cmd = new OleDbCommand(query,_conn);
            if (_conn.State != ConnectionState.Open) 
            {
                _conn.Open();
            }
            cmd.Parameters.AddWithValue("@name" , txtID.Text);
            cmd.Parameters.AddWithValue("@sex" , cmbSex.Text);
            cmd.ExecuteNonQuery();
            _conn.Close();

            MessageBox.Show("Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
