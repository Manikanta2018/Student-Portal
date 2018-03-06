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
    public partial class New_SubjectAllocation : Form
    {
        
        SqlConnection con;
        SqlCommand cmdCourse, cmdDept, cmdFac, cmdSub, cmdSubAllocation;
        SqlDataReader dr;
        int index1, index2;

        public New_SubjectAllocation()
        {
            InitializeComponent();
            con = new SqlConnection("data source=LAPTOP-1CC0RIGA;initial catalog=test;integrated security=True ");
            cmdCourse = new SqlCommand("select * from New_Course", con);
            cmdFac = new SqlCommand("select * from New_Faculty", con);
            cmdSubAllocation = new SqlCommand("select * from New_subjectAllocation", con);
            con.Open();
            dr = cmdCourse.ExecuteReader();
            while (dr.Read())
                cmbcourse.Items.Add(dr["course_name"].ToString());
            con.Close();
            con.Open();
            dr = cmdFac.ExecuteReader();
            while (dr.Read())
                cmbFac.Items.Add(dr["name"].ToString());
            con.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index1 = listBox1.SelectedIndex;

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            index2 = listBox2.SelectedIndex;

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            String course, dept, sem;
            course = cmbcourse.Text;
            dept = cmb_Selectdepartment.Text;
            sem = cmb_Selectsemester.Text;
            cmdSub = new SqlCommand("select * from New_Subject", con);
            con.Open();
            dr = cmdSub.ExecuteReader();
            while (dr.Read())
            {
                if (course.Equals(dr["course"].ToString()) && dept.Equals(dr["dept"].ToString()) && sem.Equals(dr["sem"].ToString()))
                    listBox1.Items.Add(dr["subname"].ToString());
            }
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (index1 >= 0)
            {
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
                listBox1.Items.RemoveAt(index1);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String course, dept, sem, faculty_name, sub_name;
            int i, count;
            faculty_name = cmbFac.Text;
            course = cmbcourse.Text;
            dept = cmb_Selectdepartment.Text;
            sem = cmb_Selectsemester.Text;
            count = listBox2.Items.Count;//to count no. of subjects in list2
            for (i = 0; i < count; i++)
            {
                sub_name = listBox2.Items[i].ToString();//storing subject name from list2
                cmdSubAllocation.CommandText = "insert into New_SubjectAllocation values('" + faculty_name + "','" + course + "','" + dept + "','" + sem + "','" + sub_name + "')";
                con.Open();
                int j = cmdSubAllocation.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("new Subjects Have been Allocated successfully");
            Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            cmbcourse.Text = "Select Course";
            cmb_Selectdepartment.Text = "Select Department";
            cmbFac.Text = "Select Faculty Name";
            cmb_Selectsemester.Text = "Select Semester";
            listBox1.Items.Clear();
            listBox2.Items.Clear();

        }
        private void cmb_Selectdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_Selectcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i, sem = 0;
            string course_name = cmbcourse.SelectedItem.ToString();
            cmb_Selectdepartment.Items.Clear();
            cmb_Selectdepartment.Text = "Select department";
            cmb_Selectsemester.Items.Clear();
            cmb_Selectsemester.Text = "Select Semester";
            cmdDept = new SqlCommand("select * from new_department", con);
            con.Open();
            dr = cmdDept.ExecuteReader();
            while (dr.Read())
            {
                if (course_name.Equals(dr["course_name"].ToString()))
                    cmb_Selectdepartment.Items.Add(dr["dept_name"].ToString());
            }
            con.Close();
            con.Open();
            dr = cmdCourse.ExecuteReader();
            while(dr.Read())
            {
                if (cmbcourse.SelectedItem.Equals(dr["course_name"].ToString()))
                    sem = Convert.ToInt32(dr["sem"].ToString());
            }
            for (i = 1; i <= sem; i++)
                cmb_Selectsemester.Items.Add(i + "");
            con.Close();
        }

        private void cmb_Selectsemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_Selectfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {




        }
    }
}
