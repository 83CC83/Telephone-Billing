<%@ Page Language="C#" AutoEventWireup="true" CodeFile="clerk.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>員工畫面</title>
    <style>
       header nav ul {
           display: flex;
           list-style-type: none;
       }
       header nav ul li {
           padding: 0.8rem 1.2rem;
       }
       nav ul li a {
           text-decoration: none;
           font-size: 1rem;
       }
       nav ul li a:hover {
           font-weight:800;
           font-size: 1.5rem;
       }
       .active {
           padding: 0;
           margin-left: -2.5rem;
       }
       form {
           text-align: center;
           font-size: 18px;
       }
       .GridPosition
       {
           position: center;
           display: inline-block;
       }
       #customerID_text {
           width: 250px;
       }
       #user_block {
           text-align: center;
       }
       #warning {
           font-size: large;
           color: red;
       }
    </style>
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a class="active" href="#">顧客資料</a></li>
                <li><a href="../首頁/index(main_page).aspx">返回首頁</a></li>
            </ul>
        </nav>
    </header>
    <form id="form1" runat="server">
        <div>
            <h3>顧客資料</h3>
            <div>
                <asp:GridView ID="UsersInfo" runat="server" AutoGenerateColumns="False" class="GridPosition">
                    <Columns>
                        <asp:BoundField DataField="customerID" HeaderText="顧客ID" />
                        <asp:BoundField DataField="telNo" HeaderText="電話號碼" />
                        <asp:BoundField DataField="customerName" HeaderText="顧客姓名" />
                        <asp:BoundField DataField="contractID" HeaderText="合約號碼" />
                        <asp:BoundField DataField="contractStartDate" HeaderText="合約起始時間"/>
                        <asp:BoundField DataField="cutBillDate" HeaderText="每月切帳日期"/>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div>
                <asp:Label ID="customerID_label" runat="server" Text="顧客ID"></asp:Label> 
                &nbsp;
                <asp:TextBox ID="customerID_text" runat="server" placeholder="新增時請勿輸入相同的顧客ID"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="insert" runat="server" Text="新增" OnClick="insert_Click"/>
                &nbsp;
                <asp:Button ID="update" runat="server" Text="修改" OnClick="update_Click"/>
                &nbsp;
                <asp:Button ID="delete" runat="server" Text="刪除" OnClick="delete_Click" />
                <br />
                <asp:Label ID="warning" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <div id="user_block">
                    <asp:Label ID="telNo_lbl" runat="server" Text="電話號碼" Visible="false"></asp:Label>&nbsp;
                    <asp:TextBox ID="telNo_text" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="customerName_lbl" runat="server" Text="顧客姓名" Visible="false"></asp:Label>&nbsp;
                    <asp:TextBox ID="customerName_text" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="contractID_lbl" runat="server" Text="合約號碼" Visible="false"></asp:Label>&nbsp;
                    <asp:TextBox ID="contractID_text" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="contractStartDate_lbl" runat="server" Text="合約起始時間" Visible="false"></asp:Label>&nbsp;
                    <asp:TextBox ID="contractStartDate_text" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="cutBillDate_lbl" runat="server" Text="每月切帳日期" Visible="false"></asp:Label>&nbsp;
                    <asp:TextBox ID="cutBillDate_text" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Insert_confirm" runat="server" Text="確認新增" Visible="false" OnClick="Insert_confirm_Click"/>
                    &nbsp;
                    <asp:Button ID="Update_confirm" runat="server" Text="確認修改" Visible="false" OnClick="Update_confirm_Click"/>
                    &nbsp;
                    <asp:Button ID="Delete_confirm" runat="server" Text="確認刪除" Visible="false" OnClick="Delete_confirm_Click"/>
                </div>
            </div>
        </div>
        <div>

        </div>
    </form>
</body>
</html>
