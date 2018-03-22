<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="ADM.ListView" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/CSS/List.css" rel="stylesheet" />
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
</head>
<body>
    <form runat="server">
        <div id="containerBody" runat="server">
            <p>Product list</p>

            <div id="container-sort-by">
                <asp:DropDownList ID="DDLSortProducts" AutoPostBack="True" runat="server" CssClass="DDLSortProducts">
                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                    <asp:ListItem Value="1">More popular</asp:ListItem>
                    <asp:ListItem Value="2">Less popular</asp:ListItem>
                    <asp:ListItem Value="3">More expensive</asp:ListItem>
                    <asp:ListItem Value="4">Less expensive</asp:ListItem>
                </asp:DropDownList>
                
                <span id="sort-by">Sort by:</span>
                <span>ASC/DESC</span>
            </div>

            <div id="products">
                <asp:Repeater ID="Repeater1" runat="server" ItemType="ADM.ProductList">
                    <ItemTemplate>
                        <div class="product">

                            <div class="container-left">
                                <img src="Content/Images/<%#Item.ProductListParameter3 %>" />
                                <p class="title"><%# Item.ProductListParameter1 %></p>
                                <p class="description"><%#Item.ProductListParameter2 %></p>
                                <asp:Button runat="server" OnCommand="BtnMoreDetails_Click" CommandArgument="<%# Item.ProductListParameter6 %>" Text="More Details" CssClass="btnMoreDetails" />

                            </div>
                            <div class="container-right">
                                <span class="paragraph-style1">Price:</span>
                                <span class="price" data-price="<%# Item.ProductListParameter4 %>"><%# Item.ProductListParameter4 != "0" ? Item.ProductListParameter4 + " EUR" : "Unknown"%> </span>
                                <p class="availability">
                                    <script src="Scripts/ProductAvailability.js"></script>
                                </p>
                                <div class="popular" data-popular="<%# Item.ProductListParameter5 !=""? Item.ProductListParameter5 :"0" %>"><%# Item.ProductListParameter5 %></div>
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <script src="Scripts/SortingMethods/SortByAttrNumericalValue.js"></script>
        <script src="Scripts/SortingMethods/SortProducts.js"></script>
    </form>
</body>
</html>
