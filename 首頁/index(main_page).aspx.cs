using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    static string connectionString = "Data Source = wupeixideMacBook-Air\\localhost,1433; " +
                                     "Initial Catalog = myDatabase; " +
                                     "User ID = SA; " +
                                     "Password = qPei@W031";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_click(object sender, EventArgs e)
    {
        string a = username.Text;
        string b = password.Text;

        if (String.IsNullOrEmpty(a) || String.IsNullOrEmpty(b))
        {
            String errorMessage = " Please enter again, username or password is empty !";
            warning.Text = errorMessage;
        }
        else
        {
            if (a == "EmployeeForTest" && b == "E61253")
                Response.Redirect("../員工/clerk.aspx");
            else if (a == "CustomerForTest" && b == "C30038")
                Response.Redirect("../顧客/customer.aspx");
            else
                warning.Text = "Wrong username or password !";
        }
    }

}