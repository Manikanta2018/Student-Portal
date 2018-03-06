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
    public partial class New_Department : Form
    {
        SqlConnection con;
        SqlCommand cmdcourse, cmdDept;
        SqlDataReader dr;

        public New_Department()
        {
            InitializeComponent();
            con = new SqlConnection("data source= LAPTOP-1CC0RIGA; initial catalog=test; integrated security=True ");
            cmdcourse = new SqlCommand("select * from new_course", con);
            con.Open();
            dr = cmdcourse.ExecuteReader();
            while (dr.Read())
                cmbCourse.Items.Add(dr["course_name"].ToString());
            con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtdeptId.Text = "";
            txtdeptName.Text = "";
            txtdeptId.Focus();
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String deptid = txtdeptId.Text;
            String dept_name = txtdeptName.Text;
            String course_name = cmbCourse.Text;
            cmdDept = new SqlCommand("insert into new_department values('" + deptid + "','" + dept_name + "','" + course_name + "') ", con);
            con.Open();
            int i = cmdDept.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("New department Entry has been saved successfully");
        }
    }
}
