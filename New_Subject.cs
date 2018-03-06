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
    public partial class New_Subject : Form
    {
        SqlConnection con;
        SqlCommand cmdCourse, cmdDept, cmdSub;
        SqlDataReader dr;

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i, sem = 0;
            
            cmbDept.Items.Clear();
            cmbDept.Text = "Select Department";
            cmbSem.Items.Clear();
            cmbSem.Text = "select Semester";

            con.Open();
            dr = cmdDept.ExecuteReader();
            while (dr.Read())
            {
                if (cmbCourse.SelectedItem.Equals(dr["course_name"].ToString()))
                    cmbDept.Items.Add(dr["dept_name"].ToString());

            }
            con.Close();
            //adding semester to combo
            con.Open();
            dr = cmdCourse.ExecuteReader();
            while (dr.Read())
            {
                if (cmbCourse.SelectedItem.Equals(dr["course_name"].ToString()))
                    sem = Convert.ToInt32(dr["sem"].ToString());
            }
            con.Close();
            for (i = 1; i <= sem; i++)
                cmbSem.Items.Add(i.ToString());
            

        }

        private void New_Subject_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void New_Subject_Load_1(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        public New_Subject()
        {
             InitializeComponent();
             con = new SqlConnection("data source= LAPTOP-1CC0RIGA; initial catalog=test; integrated security=True ");
             cmdCourse = new SqlCommand("select * from New_Course", con);
             cmdDept = new SqlCommand("select * from New_Department", con);
            cmdSub = new SqlCommand("select * from new_subject",con);
             con.Open();
             dr = cmdCourse.ExecuteReader();

          while (dr.Read())
            cmbCourse.Items.Add(dr["course_name"].ToString());
          con.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string Dept, Subject_Id, Subject_Name, Course_Name;
            int Sem;
            Subject_Id = txtId.Text;
            Subject_Name = txtName.Text;
            Course_Name = cmbCourse.Text;
            Dept = cmbDept.Text;
            Sem = Convert.ToInt32(cmbSem.Text);

            cmdSub.CommandText = "insert into New_Subject values('" + Subject_Id + "','" + Subject_Name + "','" + Course_Name + "','" + Dept + "'," + Sem + ")";
            con.Open();
            int i = cmdSub.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("New data has been saved successfully");
            Clear();
        }
        private void Clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            cmbCourse.Text = "Select Course";
            cmbDept.Text = "Select Department";
            cmbSem.Text = "Select Semester";
        }





    }
}
