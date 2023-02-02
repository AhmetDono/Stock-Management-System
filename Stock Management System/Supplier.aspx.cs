using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Stock_Management_System
{
    public partial class Supplier : System.Web.UI.Page
    {
        DataBase.MicrosoftSQL returnConn = new DataBase.MicrosoftSQL();
        SqlConnection sqlcon = new SqlConnection();
        DataTable dtlb = new DataTable();
        
        //pagelaod
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {   //load gridview on page_load
                //open connection
                returnConn.baglantı();
                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM SUPPLIER_TABLE", returnConn.baglantı());
                DataTable dtlb = new DataTable();
                sqlData.Fill(dtlb);
                Supplier_Grid.DataSource = dtlb;
                Supplier_Grid.DataBind();
                returnConn.baglantı_kes();
            }

        }

        //save data
        protected void Save_Supplier_Click(object sender, EventArgs e)
        {
            if (Supplier_Name.Text=="" || Supplier_Address.Text=="" || Supplier_Mail.Text=="" || Supplier_Phone.Text=="" || Supplier_Join_Date.Text=="")
            {
                Saved_Or_Not_label.Text = "No value can be left null";
            }

            else
            {
                if (Supplier_Name.Text.Length > 50 || Supplier_Address.Text.Length > 200 || Supplier_Mail.Text.Length > 50)
                {
                    Saved_Or_Not_label.Text = "Supplier Name Supplier Mail can't be more than 50 letter and Supplier Adress can't be more than 200 letter";
                }
                                                              
                else if (Convert.ToInt64(Supplier_Phone.Text) > 10000000000 || Convert.ToInt64(Supplier_Phone.Text) < 999999999)
                {
                    Saved_Or_Not_label.Text = "Phone number must be 10 digits";
                }
                else if (Supplier_Join_Date.GetType() != typeof(DateTime))
                {
                    returnConn.baglantı();

                    DateTime enteredDate = DateTime.Parse(Supplier_Join_Date.Text);
                    DateTime a = enteredDate;

                    string query = "INSERT INTO SUPPLIER_TABLE(SUPPLIER_NAME,SUPPLIER_ADDRESS,SUPPLIER_PHONE,SUPPLIER_MAIL,SUPPLIER_JOIN_DATE) VALUES (@SUPPLIER_NAME, @SUPPLIER_ADDRESS, @SUPPLIER_PHONE,@SUPPLIER_MAIL,@SUPPLIER_JOIN_DATE)";

                    SqlCommand command = new SqlCommand(query, returnConn.baglantı());
                    command.Parameters.Add("@SUPPLIER_NAME", Supplier_Name.Text);
                    command.Parameters.Add("@SUPPLIER_ADDRESS", Supplier_Address.Text);
                    command.Parameters.Add("@SUPPLIER_PHONE",Convert.ToInt64(Supplier_Phone.Text));
                    command.Parameters.Add("@SUPPLIER_MAIL", Supplier_Mail.Text);
                    command.Parameters.Add("@SUPPLIER_JOIN_DATE", enteredDate);
                    command.ExecuteNonQuery();
                    
                    //databind
                    SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM SUPPLIER_TABLE", returnConn.baglantı());
                    sqlData.Fill(dtlb);
                    Supplier_Grid.DataSource = dtlb;
                    Supplier_Grid.DataBind();
                    returnConn.baglantı_kes();
                }
                else
                {
                    //hiç bir zaman buraya girmeyecek
                }
            }
        }

        //Delete
        protected void Supplier_Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            returnConn.baglantı();
            int ID = Convert.ToInt32(Supplier_Grid.DataKeys[e.RowIndex].Values[0]);
            String query = "DELETE FROM SUPPLIER_TABLE WHERE ID='" +ID+ "' ";
            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            int t = command.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Data Has Deleted');", true);
                Supplier_Grid.EditIndex = -1;

                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM SUPPLIER_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Supplier_Grid.DataSource = dtlb;
                Supplier_Grid.DataBind();
                returnConn.baglantı_kes();
            }
        }

        //edit
        protected void Supplier_Grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            returnConn.baglantı();
            Supplier_Grid.EditIndex = e.NewEditIndex;

            //databind
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM SUPPLIER_TABLE", returnConn.baglantı());
            DataTable dtlb = new DataTable();
            sqlData.Fill(dtlb);
            Supplier_Grid.DataSource = dtlb;
            Supplier_Grid.DataBind();
            returnConn.baglantı_kes();
        }

        //updating
        protected void Supplier_Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            returnConn.baglantı();
            int ID = Convert.ToInt32(Supplier_Grid.DataKeys[e.RowIndex].Values[0]);
            string name = ((TextBox)Supplier_Grid.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string adress = ((TextBox)Supplier_Grid.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            int phone = int.Parse(((TextBox)Supplier_Grid.Rows[e.RowIndex].Cells[3].Controls[0]).Text);
            string mail = ((TextBox)Supplier_Grid.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            DateTime join_date = DateTime.Parse(((TextBox)Supplier_Grid.Rows[e.RowIndex].Cells[5].Controls[0]).Text);

            string query = "UPDATE SUPPLIER_TABLE SET SUPPLIER_NAME='" + name + "',SUPPLIER_ADDRESS='" + adress + "',SUPPLIER_PHONE='" + Convert.ToInt64(phone) + "',SUPPLIER_MAIL='" + mail + "',SUPPLIER_JOIN_DATE='" + join_date + "' WHERE ID='" + ID + "'";

            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
                int t = command.ExecuteNonQuery();
                if (t > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Data Has Updated');", true);
                    Supplier_Grid.EditIndex = -1;

                    //databind
                    SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM SUPPLIER_TABLE", returnConn.baglantı());
                    sqlData.Fill(dtlb);
                    Supplier_Grid.DataSource = dtlb;
                    Supplier_Grid.DataBind();
                    returnConn.baglantı_kes();
                }
        }

        //cancel update
        protected void Supplier_Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            returnConn.baglantı();
            Supplier_Grid.EditIndex = -1;

            //databind
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM SUPPLIER_TABLE", returnConn.baglantı());
            sqlData.Fill(dtlb);
            Supplier_Grid.DataSource = dtlb;
            Supplier_Grid.DataBind();
            returnConn.baglantı_kes();
        }

    }
}