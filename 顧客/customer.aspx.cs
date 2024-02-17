using System;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

public partial class customer : System.Web.UI.Page
{
    static string connectionString = "Data Source = wupeixideMacBook-Air\\localhost,1433; " +
                                     "Initial Catalog = myDatabase; " +
                                     "User ID = SA; " +
                                     "Password = qPei@W031";

    protected void Droplist_select(object sender, EventArgs e) 
    {
        totalCallSec.Text = "";
        billAmount.Text = "";

        if (BillMonths.SelectedItem.Value == "November")
        {
            BindDataToGridView_Communication("SELECT * FROM communication WHERE callDate LIKE '2023-11%'");
            totalCallSec_label.Visible = true;
            totalCallSec.Visible = true;
            billAmount_label.Visible = true;
            billAmount.Visible = true;
            totalCallSec.Text = calculate_totalSec("SELECT startTime, endTime FROM communication WHERE callDate LIKE '2023-11%'");
            billAmount.Text = calculate_totalBill();
            CommunicationInfo.Visible = true;
            noCommunicationValue.Visible = false;
        }
        else if (BillMonths.SelectedItem.Value == "December")
        {
            BindDataToGridView_Communication("SELECT * FROM communication WHERE callDate LIKE '2023-12%'");
            totalCallSec_label.Visible = true;
            totalCallSec.Visible = true;
            billAmount_label.Visible = true;
            billAmount.Visible = true;
            totalCallSec.Text = calculate_totalSec("SELECT startTime, endTime FROM communication WHERE callDate LIKE '2023-12%'");
            billAmount.Text = calculate_totalBill();
            CommunicationInfo.Visible = true;
            noCommunicationValue.Visible = false;
        }
        else if (BillMonths.SelectedItem.Value == "January")
        {
            BindDataToGridView_Communication("SELECT * FROM communication WHERE callDate LIKE '2023-01%'");
            totalCallSec_label.Visible = true;
            totalCallSec.Visible = true;
            billAmount_label.Visible = true;
            billAmount.Visible = true;
            totalCallSec.Text = calculate_totalSec("SELECT startTime, endTime FROM communication WHERE callDate LIKE '2023-01%'");
            billAmount.Text = calculate_totalBill();
            CommunicationInfo.Visible = true;
            noCommunicationValue.Visible = false;
        }
        else if (BillMonths.SelectedItem.Value == "Febuary")
        {
            BindDataToGridView_Communication("SELECT * FROM communication WHERE callDate LIKE '2023-02%'");
            totalCallSec_label.Visible = true;
            totalCallSec.Visible = true;
            billAmount_label.Visible = true;
            billAmount.Visible = true;
            totalCallSec.Text = calculate_totalSec("SELECT startTime, endTime FROM communication WHERE callDate LIKE '2023-02%'");
            billAmount.Text = calculate_totalBill();
            CommunicationInfo.Visible = true;
            noCommunicationValue.Visible = false;
        }
        else if (BillMonths.SelectedItem.Value == "March")
        {
            BindDataToGridView_Communication("SELECT * FROM communication WHERE callDate LIKE '2023-03%'");
            totalCallSec_label.Visible = true;
            totalCallSec.Visible = true;
            billAmount_label.Visible = true;
            billAmount.Visible = true;
            totalCallSec.Text = calculate_totalSec("SELECT startTime, endTime FROM communication WHERE callDate LIKE '2023-03%'");
            billAmount.Text = calculate_totalBill();
            CommunicationInfo.Visible = true;
            noCommunicationValue.Visible = false;
        }
        else
        {
            CommunicationInfo.Visible = false;
            noCommunicationValue.Text = "查無資料";
            noCommunicationValue.Visible = true;
            totalCallSec_label.Visible = false;
            totalCallSec.Visible = false;
            billAmount_label.Visible = false;
            billAmount.Visible = false;
        }
    }
    private void BindDataToGridView_Communication(string query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))  //建立資料庫連接
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))  //執行 SQL 查詢並把回傳的資料填充到GridView_Select_Course
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                CommunicationInfo.DataSource = dataTable; // 把 dataTable 放在 aspx 中設定的物件名稱 EX: GridView ID = "GridView_Select_Course"
                CommunicationInfo.DataBind();
            }
        }
    }
    private string calculate_totalSec(string query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int totalSec = 0;
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            string s = reader["startTime"].ToString();
                            DateTime startTime = DateTime.ParseExact(s, "HH:mm:ss", CultureInfo.InvariantCulture);
                            string e = reader["endTime"].ToString();
                            DateTime endTime = DateTime.ParseExact(e, "HH:mm:ss", CultureInfo.InvariantCulture);
                            TimeSpan ts = endTime - startTime;
                            string Sec = ts.TotalSeconds.ToString();
                            totalSec += int.Parse(Sec);
                        }
                    }
                    return totalSec.ToString();

                }
            }
        }
    }

    private string calculate_totalBill()
    {
        string query = "SELECT TelcomRates, freeCallSec FROM contracts WHERE contractID = " +
                "(SELECT contractID FROM users WHERE telNo = '0930')";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int totalBill = 0;
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            string r = reader["TelcomRates"].ToString();
                            float telcomRates = float.Parse(r);
                            string f = reader["freeCallSec"].ToString();
                            int freeCallSec = int.Parse(f);

                            string Sec = totalCallSec.Text;
                            int totalSec = int.Parse(Sec);

                            if (freeCallSec < totalSec)
                            {
                                totalBill = (int)((totalSec - freeCallSec) * telcomRates);
                            }
                            else
                            {
                                totalBill = 0;
                            }
                        }
                    }
                    return totalBill.ToString();
                            
                }
            }
        }
    }

    protected void Show_myInfo_Click(object sender, EventArgs e)
    {
        myName_lbl.Visible = true;
        myName_text.Visible = true;
        myID_lbl.Visible=true;
        myID_text.Visible=true;
        myBirth_lbl.Visible=true;
        myBirth_text.Visible=true;
        myAddress_lbl.Visible=true;
        myAddress_text.Visible=true;
        myTel_lbl.Visible=true;
        myTel_text.Visible=true;
        myJob_lbl.Visible=true;
        myJob_text.Visible=true;

        Update_myInfo.Visible=true;
        Show_myInfo.Visible = false;

        string query = "SELECT * FROM Users_Info WHERE myTel = '0930'";
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
                            myName_text.Text = reader["myName"].ToString();
                            myID_text.Text = reader["myID"].ToString();
                            myBirth_text.Text = reader["myBirth"].ToString();
                            myAddress_text.Text = reader["myAddress"].ToString();
                            myTel_text.Text = reader["myTel"].ToString();
                            myJob_text.Text = reader["myJob"].ToString();
                        }
                    }
                }
            }
        }
    }

    protected void Update_myInfo_Click(object sender, EventArgs e)
    {
        string query = "UPDATE Users_Info SET myName = @myName, myID = @myID, myBirth = @myBirth, " +
            "myAddress = @myAddress, myTel = @myTel, myJob = @myJob WHERE myTel = '0930'";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;

                // 添加有值的參數
                if (!string.IsNullOrWhiteSpace(myName_text.Text))
                {
                    cmd.Parameters.AddWithValue("@myName", myName_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(myID_text.Text))
                {
                    cmd.Parameters.AddWithValue("@myID", myID_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(myBirth_text.Text))
                {
                    cmd.Parameters.AddWithValue("@myBirth", myBirth_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(myAddress_text.Text))
                {
                    cmd.Parameters.AddWithValue("@myAddress", myAddress_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(myTel_text.Text))
                {
                    cmd.Parameters.AddWithValue("@myTel", myTel_text.Text);
                }

                if (!string.IsNullOrWhiteSpace(myJob_text.Text))
                {
                    cmd.Parameters.AddWithValue("@myJob", myJob_text.Text);
                }

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("更新成功");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error Message");
                }

                myName_text.Text = "";
                myID_text.Text = "";
                myBirth_text.Text = "";
                myAddress_text.Text = "";
                myTel_text.Text = "";
                myJob_text.Text = "";

                myName_lbl.Visible = false;
                myName_text.Visible = false;
                myID_lbl.Visible = false;
                myID_text.Visible = false;
                myBirth_lbl.Visible = false;
                myBirth_text.Visible = false;
                myAddress_lbl.Visible = false;
                myAddress_text.Visible = false;
                myTel_lbl.Visible = false;
                myTel_text.Visible = false;
                myJob_lbl.Visible = false;
                myJob_text.Visible = false;

                Update_myInfo.Visible = false;
                Show_myInfo.Visible = true;
            }
        }
    }
}

    

