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
    public partial class New_Course : Form
    {
        SqlConnection con;
        SqlCommand cmdCourse;

        public New_Course()
        {
            InitializeComponent();
            con = new SqlConnection("data source= LAPTOP-1CC0RIGA; initial catalog= test; integrated security = True");
        }
        private void New_Course_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String id, name;
            int sem;
            name = txtCoursename.Text;
            id = txtCourseid.Text;
            sem = Convert.ToInt32(txtSem.Text);
            con = new SqlConnection("data source = LAPTOP-1CC0RIGA; initial catalog = test; integrated security = True");
            cmdCourse = new SqlCommand("insert into New_Course values('" + id + "','" + name + "'," + sem + ")", con);
            con.Open();
            int i = cmdCourse.ExecuteNonQuery();
            MessageBox.Show("Data has been saved successfully");
            con.Close();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCourseid.Text = "";
            txtCoursename.Text = "";
            txtSem.Text = "";
            txtCourseid.Focus();

        }
    }
}
