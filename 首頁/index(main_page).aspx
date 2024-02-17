<%@ Page Language="C#" AutoEventWireup="true"
CodeFile="index(main_page).aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登入</title>
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
        font-weight: 800;
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
      #TestBlock {
        border-color: gray;
        border-style: dotted;
        border-width: medium;
      }
      #ForGIF {
        display: flex;
        flex-wrap: wrap;
      }
      #ForGIF img {
        margin-left: 700px;
      }
      #warning {
        font-size: large;
        color: red;
      }
    </style>
  </head>
  <body>
    <header>
      <div id="ForGIF">
        <nav>
          <ul>
            <li><a class="active" href="#">首頁</a></li>
            <li><a>功能選單</a></li>
            <li><a>關於我們</a></li>
          </ul>
        </nav>
        <img src="welcome.gif" alt="welcome" height="100" width="100" />
      </div>
    </header>

    <form id="form1" runat="server">
      <h3>請輸入登入資料</h3>
      <div>
        <asp:Label ID="Label1" runat="server" Text="Label">帳號</asp:Label>
        <asp:TextBox
          ID="username"
          runat="server"
          AutoCompleteType="None"
          placeholder="注意空格與大小寫"
        ></asp:TextBox>
      </div>
      <br />
      <div>
        <div>
          <asp:Label ID="Label2" runat="server" Text="Label">密碼</asp:Label>
          <asp:TextBox
            ID="password"
            runat="server"
            TextMode="Password"
            placeholder="注意空格與大小寫"
          ></asp:TextBox>
        </div>
      </div>

      <br />
      <asp:Label ID="warning" runat="server" Text=""></asp:Label>
      &nbsp;
      <asp:Button
        ID="Login"
        runat="server"
        Text="Login"
        OnClick="Login_click"
      />
      <br />
      <br />
      <div id="TestBlock">
        <asp:Label
          ID="Test1"
          runat="server"
          Text="目前可使用（帳號 / 密碼）："
          Font-Size="Small"
        ></asp:Label>
        <br />
        <asp:Label
          ID="Test2"
          runat="server"
          Text="員工（EmployeeForTest / E61253）"
          Font-Size="Small"
        ></asp:Label>
        <br />
        <asp:Label
          ID="Test3"
          runat="server"
          Text="顧客（CustomerForTest / C30038）"
          Font-Size="Small"
        ></asp:Label>
      </div>
    </form>
  </body>
</html>
