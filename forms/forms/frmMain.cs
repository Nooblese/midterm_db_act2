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
    public partial class frmMain : Form
    {
        string _username;
        OleDbConnection _conn;
        public frmMain(string username,OleDbConnection conn)
        {
            InitializeComponent();
            _username = username;
            _conn = conn;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome " + _username;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Missing Input name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                DataTable dt = new DataTable();
                string query = "select name as NAME, email as EMAIL, address as ADDRESS, sex as SEX from employee where name like '%" + txtName.Text + "%' and '%" + cmbSex.Text + "%'";

                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);
                grdView.DataSource = dt;
                _conn.Close();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query = "select name as NAME, email as EMAIL, address as ADDRESS, sex as SEX from employee where name like '%" + txtName.Text + "%'";

            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
            adapter.Fill(dt);
            grdView.DataSource = dt;
            _conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frm = new frmAdd(_conn);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDelete frm = new frmDelete(_conn);
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEdit frm = new frmEdit(_conn);
            frm.ShowDialog();
        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cmbSex.SelectedIndex == -1)
            {
                string query = "select name as Name, email as EMAIL, address as ADDRESS, sex as SEX from employee";
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);
                grdView.DataSource = dt;
                _conn.Close();



            }
            else if (cmbSex.SelectedIndex == 0)
            {
                string query = "select name as Name, email as EMAIL, address as ADDRESS, sex as SEX from employee where sex ='Male" +
                    "'";
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);
                grdView.DataSource = dt;
                _conn.Close();
            }
            else 
            {
                string query = "select name as Name, email as EMAIL, address as ADDRESS, sex as SEX from employee where sex ='Female'";
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);
                grdView.DataSource = dt;
                _conn.Close();
            }
        }
    }
}
