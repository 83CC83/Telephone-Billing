using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Windows.Forms;

public partial class Default2 : System.Web.UI.Page
{
    static string connectionString = "Data Source = wupeixideMacBook-Air\\localhost,1433; " +
                                     "Initial Catalog = myDatabase; " +
                                     "User ID = SA; " +
                                     "Password = qPei@W031";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        BindDataToGridView_totalUsers();
        
    }
    protected void BindDataToGridView_totalUsers()
    {
        string query = "SELECT * FROM totalUsers";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                UsersInfo.DataSource = dataTable;
                UsersInfo.DataBind();
            }
        }
    }
    protected void insert_Click(object sender, EventArgs e)
    {
        warning.Text = "";
        telNo_lbl.Visible = true;
        telNo_text.Visible = true;
        customerName_lbl.Visible = true;
        customerName_text.Visible = true;
        contractID_lbl.Visible = true;
        contractID_text.Visible = true;
        contractStartDate_lbl.Visible = true;
        contractStartDate_text.Visible = true;
        cutBillDate_lbl.Visible = true;
        cutBillDate_text.Visible = true;

        telNo_text.Text = "";
        customerName_text.Text = "";
        contractID_text.Text = "";
        contractStartDate_text.Text = "";
        cutBillDate_text.Text = "";

        Update_confirm.Visible = false;
        Delete_confirm.Visible = false;
        Insert_confirm.Visible = true;

        string query = "SELECT customerID FROM totalUsers";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            string cID = reader["customerID"].ToString();
                            if (cID == customerID_text.Text)
                            {
                                warning.Text = "顧客ID 重複 !";
                                customerID_text.Text = "";

                                telNo_lbl.Visible = false;
                                telNo_text.Visible = false;
                                customerName_lbl.Visible = false;
                                customerName_text.Visible = false;
                                contractID_lbl.Visible = false;
                                contractID_text.Visible = false;
                                contractStartDate_lbl.Visible = false;
                                contractStartDate_text.Visible = false;
                                cutBillDate_lbl.Visible = false;
                                cutBillDate_text.Visible = false;

                                Insert_confirm.Visible = false;
                            }

                        }
                    }
                }
            }
        }
    }

    protected void update_Click(object sender, EventArgs e)
    {
        warning.Text = "";

        telNo_lbl.Visible = true;
        telNo_text.Visible = true;
        customerName_lbl.Visible = true;
        customerName_text.Visible = true;
        contractID_lbl.Visible = true;
        contractID_text.Visible = true;
        contractStartDate_lbl.Visible = true;
        contractStartDate_text.Visible = true;
        cutBillDate_lbl.Visible = true;
        cutBillDate_text.Visible = true;

        telNo_text.Text = "";
        customerName_text.Text = "";
        contractID_text.Text = "";
        contractStartDate_text.Text = "";
        cutBillDate_text.Text = "";

        Insert_confirm.Visible = false;
        Delete_confirm .Visible = false;
        Update_confirm.Visible = true;
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        telNo_lbl.Visible = true;
        telNo_text.Visible = true;
        customerName_lbl.Visible = true;
        customerName_text.Visible = true;
        contractID_lbl.Visible = true;
        contractID_text.Visible = true;
        contractStartDate_lbl.Visible = true;
        contractStartDate_text.Visible = true;
        cutBillDate_lbl.Visible = true;
        cutBillDate_text.Visible = true;

        Insert_confirm .Visible = false;
        Update_confirm.Visible = false;
        Delete_confirm.Visible = true;

        string query = "SELECT * FROM totalUsers WHERE customerID = @customerID";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@customerID", customerID_text.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            telNo_text.Text = reader["telNo"].ToString();
                            customerName_text.Text = reader["customerName"].ToString();
                            contractID_text.Text = reader["contractID"].ToString();
                            contractStartDate_text.Text = reader["contractStartDate"].ToString();
                            cutBillDate_text.Text = reader["cutBillDate"].ToString();
                        }
                    }
                }
            }
        }
    }

    protected void Insert_confirm_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO totalUsers (customerID, telNo, customerName, contractID, contractStartDate, cutBillDate) VALUES " +
            "(@customerID, @telNo, @customerName, @contractID, @contractStartDate, @cutBillDate)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@customerID", customerID_text.Text);
                cmd.Parameters.AddWithValue("@telNo", telNo_text.Text);
                cmd.Parameters.AddWithValue("@customerName", customerName_text.Text);
                cmd.Parameters.AddWithValue("@contractID", contractID_text.Text);
                cmd.Parameters.AddWithValue("@contractStartDate", contractStartDate_text.Text);
                cmd.Parameters.AddWithValue("@cutBillDate", cutBillDate_text.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    BindDataToGridView_totalUsers();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "無法新增");
                }

                telNo_text.Text = "";
                customerName_text.Text = "";
                contractID_text.Text = "";
                contractStartDate_text.Text = "";
                cutBillDate_text.Text = "";

                telNo_lbl.Visible = false;
                telNo_text.Visible = false;
                customerName_lbl.Visible = false;
                customerName_text.Visible = false;
                contractID_lbl.Visible = false;
                contractID_text.Visible = false;
                contractStartDate_lbl.Visible = false;
                contractStartDate_text.Visible = false;
                cutBillDate_lbl.Visible = false;
                cutBillDate_text.Visible = false;

                Insert_confirm.Visible = false;
                customerID_text.Text = "";
            }
        }
    }

    protected void Update_confirm_Click(object sender, EventArgs e)
    {
        string query = "UPDATE totalUsers SET ";

        // 檢查每個欄位是否有值，如果有值就加入UPDATE語句
        if (!string.IsNullOrWhiteSpace(telNo_text.Text))
        {
            query += "telNo = @telNo, ";
        }

        if (!string.IsNullOrWhiteSpace(customerName_text.Text))
        {
            query += "customerName = @customerName, ";
        }

        if (!string.IsNullOrWhiteSpace(contractID_text.Text))
        {
            query += "contractID = @contractID, ";
        }

        if (!string.IsNullOrWhiteSpace(contractStartDate_text.Text))
        {
            query += "contractStartDate = @contractStartDate, ";
        }

        if (!string.IsNullOrWhiteSpace(cutBillDate_text.Text))
        {
            query += "cutBillDate = @cutBillDate, ";
        }

        // 移除最後一個逗號和空格
        query = query.TrimEnd(' ', ',');
        query += " WHERE customerID = @customerID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@customerID", customerID_text.Text);

                // 添加有值的參數
                if (!string.IsNullOrWhiteSpace(telNo_text.Text))
                {
                    cmd.Parameters.AddWithValue("@telNo", telNo_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(customerName_text.Text))
                {
                    cmd.Parameters.AddWithValue("@customerName", customerName_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(contractID_text.Text))
                {
                    cmd.Parameters.AddWithValue("@contractID", contractID_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(contractStartDate_text.Text))
                {
                    cmd.Parameters.AddWithValue("@contractStartDate", contractStartDate_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(cutBillDate_text.Text))
                {
                    cmd.Parameters.AddWithValue("@cutBillDate", cutBillDate_text.Text);
                }

                try
                {
                    cmd.ExecuteNonQuery();
                    BindDataToGridView_totalUsers();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error Message");
                }

                telNo_lbl.Visible = false;
                telNo_text.Visible = false;
                customerName_lbl.Visible = false;
                customerName_text.Visible = false;
                contractID_lbl.Visible = false;
                contractID_text.Visible = false;
                contractStartDate_lbl.Visible = false;
                contractStartDate_text.Visible = false;
                cutBillDate_lbl.Visible = false;
                cutBillDate_text.Visible = false;

                Update_confirm.Visible = false;
                customerID_text.Text = "";
            }
        }
    }

    protected void Delete_confirm_Click(object sender, EventArgs e)
    {
        string query = "DELETE FROM totalUsers WHERE customerID = @customerID";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@customerID", customerID_text.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    BindDataToGridView_totalUsers();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error Message");
                }

                telNo_lbl.Visible = false;
                telNo_text.Visible = false;
                customerName_lbl.Visible = false;
                customerName_text.Visible = false;
                contractID_lbl.Visible = false;
                contractID_text.Visible = false;
                contractStartDate_lbl.Visible = false;
                contractStartDate_text.Visible = false;
                cutBillDate_lbl.Visible = false;
                cutBillDate_text.Visible = false;

                Delete_confirm.Visible = false;
                customerID_text.Text = "";
            }
        }
    }
}