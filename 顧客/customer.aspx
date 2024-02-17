<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customer.aspx.cs" Inherits="customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>顧客畫面</title>
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
        #Comm_div {
            font-size: 18px;
        }
        .GridPosition
        {
            position: center;
            display: inline-block;
        }
        #totalCallSec, #billAmount {
            text-decoration: underline;
        }

    </style>
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a class="active" href="#">通話紀錄</a></li>
                <li><a href="../首頁/index(main_page).aspx">返回首頁</a></li>
            </ul>
        </nav>
    </header>
    <form id="form1" runat="server">
        <div style="float:right" >
            <asp:Label ID="myInfo" runat="server" Text="個人基本資料" Font-Size="Larger" Font-Bold="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Button ID="Show_myInfo" runat="server" Text="顯示" BorderColor="Black" Font-Bold="true" Font-Size="Medium" OnClick="Show_myInfo_Click"/>
            <div>
                <br />
                <asp:Label ID="myName_lbl" runat="server" Text="姓名" Visible="false"></asp:Label>
                <asp:TextBox ID="myName_text" runat="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="myID_lbl" runat="server" Text="身分證字號" Visible="false"></asp:Label>
                <asp:TextBox ID="myID_text" runat="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="myBirth_lbl" runat="server" Text="出生年月日" Visible="false"></asp:Label>
                <asp:TextBox ID="myBirth_text" runat="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="myAddress_lbl" runat="server" Text="聯絡地址" Visible="false"></asp:Label>
                <asp:TextBox ID="myAddress_text" runat="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="myTel_lbl" runat="server" Text="手機號碼" Visible="false"></asp:Label>
                <asp:TextBox ID="myTel_text" runat="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="myJob_lbl" runat="server" Text="職業" Visible="false"></asp:Label>
                <asp:TextBox ID="myJob_text" runat="server" Visible="false"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="Update_myInfo" runat="server" Text="更新" BorderColor="Black" Font-Bold="true" Font-Size="Medium" Visible="false" OnClick="Update_myInfo_Click"/>
        </div>
        <div id="Comm_div" style="text-align:center">
            <div>
                <asp:Label ID="Comm_Info" runat="server" Text="查詢通話紀錄" Font-Size="Larger" Font-Bold="true" Visible="true"></asp:Label>
                <br /><br />
                <asp:DropDownList ID="BillMonths" runat="server" OnSelectedIndexChanged="Droplist_select">
                    <asp:ListItem Selected="True" Value="Months"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="January"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="Febuary"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="March"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="April"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="May"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="June"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="July"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="August"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="September"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="October"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="November"></asp:ListItem >
                    <asp:ListItem Selected="False" Value="December"></asp:ListItem >
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="Search" />
            </div>
            <br />
            <div>
                <asp:Label ID="noCommunicationValue" runat="server" Text="" OnTextChanged="Droplist_select" Visible="false"></asp:Label>
                <asp:GridView ID="CommunicationInfo" runat="server" AutoGenerateColumns="False" Visible="false" class="GridPosition">
                    <Columns>
                        <asp:BoundField DataField="outTelNo" HeaderText="聯絡人" />
                        <asp:BoundField DataField="callDate" HeaderText="通話日期" />
                        <asp:BoundField DataField="startTime" HeaderText="起始時間"/>
                        <asp:BoundField DataField="endTime" HeaderText="結束時間"/>
                    </Columns>
                </asp:GridView>
                <br />
                <div>
                    <asp:Label ID="totalCallSec_label" runat="server" Text="總通話秒數：" Visible="false"></asp:Label>
                    <asp:Label ID="totalCallSec" runat="server" Visible="false"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="billAmount_label" runat="server" Text="電話費：" Visible="false"></asp:Label>
                    <asp:Label ID="billAmount" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
