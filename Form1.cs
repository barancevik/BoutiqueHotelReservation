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


namespace Boutique_Hotel_1._0
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OBRQ06S;Initial Catalog=Boutique;Integrated Security=True;");
        
        private void ShowData()
        {
            listView1.Items.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Customers",conn);
            SqlDataReader read = cmd.ExecuteReader();

            while(read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["id"].ToString();
                add.SubItems.Add(read["Name"].ToString());
                add.SubItems.Add(read["Surname"].ToString());
                add.SubItems.Add(read["RoomNo"].ToString());
                add.SubItems.Add(read["EDate"].ToString());
                add.SubItems.Add(read["PhoneNo"].ToString());
                add.SubItems.Add(read["Account"].ToString());
                add.SubItems.Add(read["CDate"].ToString());
                listView1.Items.Add(add);


            }
            conn.Close();
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            ShowData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Customers(id,Name,Surname,RoomNo,EDate,PhoneNo,Account,CDate) values ('"+txtID.Text.ToString() + "','"+txtName.Text.ToString()+ "','"+txtSurname.Text.ToString()+"','"+txtRoomNo.Text.ToString()+"','"+dtEntry.Text.ToString()+"','"+txtPhoneNo.Text.ToString()+"','"+txtAccount.Text.ToString()+"','"+dtCDate.Text.ToString()+"')",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowData();

            txtID.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtRoomNo.Clear();
            txtPhoneNo.Clear();
            txtAccount.Clear();


        }


        int id = 0;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Customers where id=("+id+")",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowData();



        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            txtID.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtSurname.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtRoomNo.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dtEntry.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txtPhoneNo.Text = listView1.SelectedItems[0].SubItems[5].Text;
            txtAccount.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dtCDate.Text = listView1.SelectedItems[0].SubItems[7].Text;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Customers set id='" + txtID.Text.ToString() + "', Name='" + txtName.Text.ToString() + "', Surname ='" + txtSurname.Text.ToString() + "', RoomNo='" + txtRoomNo.Text.ToString() + "', EDate='" + dtEntry.Text.ToString() + "',PhoneNo='" + txtPhoneNo.Text.ToString() + "',Account='" + txtAccount.Text.ToString()+"', CDate='"+dtCDate.Text.ToString()+"'where id ="+id+"",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowData();



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Customers where Name like '%" + txtSearch.Text + "%'", conn);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["id"].ToString();
                add.SubItems.Add(read["Name"].ToString());
                add.SubItems.Add(read["Surname"].ToString());
                add.SubItems.Add(read["RoomNo"].ToString());
                add.SubItems.Add(read["EDate"].ToString());
                add.SubItems.Add(read["PhoneNo"].ToString());
                add.SubItems.Add(read["Account"].ToString());
                add.SubItems.Add(read["CDate"].ToString());
                listView1.Items.Add(add);


            }
            conn.Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
