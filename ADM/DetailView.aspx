<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailView.aspx.cs" Inherits="ADM.DetailView" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/CSS/Detail.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
</head>
<body>
    <form runat="server">
        <p>Product Details</p>
        <asp:Repeater ID="Repeater1" runat="server" ItemType="ADM.DetailList">
            <ItemTemplate>
                <div id="container-product">
                    <p id="name"><%# Item.Detail2 %></p>
                    <img src="Content/Images/<%# Item.Detail4 %>" />
                    <div id="container-description">
                        <p id="price">Price: <%# Item.Detail6 != "0" ? Item.Detail6 + " EUR": "Unknown"%></p>

                        <div>
                            <p id="description"><%# Item.Detail3 %></p>
                        </div>
                    </div>
                    <div id="container-specs">
                        <p>Specifications</p>
                        <p id="spec"><%# Item.Detail7.Any() ? String.Join("</br>", Item.Detail7.Select(specs => (string)specs).ToList()) : "No specifications" %></p>
                            
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
