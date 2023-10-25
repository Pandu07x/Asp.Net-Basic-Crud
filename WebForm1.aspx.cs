using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.LinkButton;

namespace CRUD_Applicatuions
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowData();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=HPLIT03;Initial Catalog=Testing;Integrated Security=True");
            con.Open();
            SqlCommand sql = new SqlCommand("Insert Into Test3(name) Values('"+TextBox1.Text+"')",con);
            sql.ExecuteNonQuery();
            con.Close();
            Response.Write("Data Saved");
            ShowData();
            TextBox1.Text = "";
            


        }
        public void ShowData()
        {
            SqlConnection con = new SqlConnection("Data Source=HPLIT03;Initial Catalog=Testing;Integrated Security=True");
            con.Open();
            SqlCommand sql = new SqlCommand("SELECt * From test3",con);
            SqlDataAdapter sda = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            sda.Fill(ds);
            sql.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text=="" || TextBox1.Text == null)
            {
                Response.Write("Fill Cheiyra Erripuka");
            }
            else
            {
                SqlConnection sql = new SqlConnection("Data Source=HPLIT03;Initial Catalog=Testing;Integrated Security=True");
                sql.Open();
                SqlCommand sqla = new SqlCommand("delete from test3 where name='"+TextBox1.Text+"'",sql);
                sqla.ExecuteNonQuery();
                sql.Close();
                Response.Write("Deleted Successfully");
                TextBox1.Text = "";
                ShowData();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)

        {
            if(TextBox1.Text=="" || TextBox2.Text == "")
            {
                Response.Write("Fill Chaiya Ra Erripuka");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=HPLIT03;Initial Catalog=Testing;Integrated Security=True");
                con.Open();
                SqlCommand sqla = new SqlCommand("Update test3 set name='"+TextBox2.Text+"' Where ID="+int.Parse(TextBox1.Text), con);
                sqla.ExecuteNonQuery();
                con.Close();
                Response.Write("Updated Successfully");
                TextBox1.Text = "";
                TextBox2.Text = "";
                ShowData();

            }

        }
    }
}