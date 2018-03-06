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


namespace Data_base_demo
{
    public partial class frm_Registration : Form
    {
        public frm_Registration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String name, user, pass, mail;
            name = txtname.Text;
            user = txtuser.Text;
            pass = txtpass.Text;
            mail = txtmail.Text;
            SqlConnection con = new SqlConnection("data source=LAPTOP-1CC0RIGA;initial catalog=test;integrated security=True ");
            SqlCommand cmd = new SqlCommand("insert into registration values('" + name + "','" + user + "','" + pass + "','" + mail + "')", con);
            if (txtpass.Text.Equals(txtcon.Text) )
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Data has been saved successfully");
                clear();
                con.Close();
            }
            else
            {
                MessageBox.Show("Password and Confirm Paasword are not same ! Please reEnter ");
                txtpass.Text = "";
                txtcon.Text = "";
                txtpass.Focus();
            }
            
        }
        private void clear()
        {
            txtname.Text = "";
            txtpass.Text = "";
            txtcon.Text = "";
            txtmail.Text = "";
            txtuser.Text = "";
            txtname.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
