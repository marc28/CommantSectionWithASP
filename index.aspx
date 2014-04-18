<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title></title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 67%;
        }
        .style2
        {
            width: 135px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="images/vslogo.jpg" />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Name:
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="161px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Comment:
                </td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="165px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="btnComment" type="button" value="Send Comment" />
                    <%--<input id="btnShowComment" type="button" value="Show Comments" />--%>
                </td>
            </tr>
        </table>
        <div id="error"></div>
        <div id="resultAjax"></div>
    </div>
    </form>

    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="ajax.js" type="text/javascript"></script>
</body>
</html>
