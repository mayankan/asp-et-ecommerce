<%@ Page Title="" Language="C#" MasterPageFile="~/Buyers.Master" AutoEventWireup="true" CodeBehind="ProductShowcase.aspx.cs" Inherits="etEcom.ProductShowcase" %>

<%@ Register Src="~/ProductList.ascx" TagPrefix="uc1" TagName="ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/GlobalV3.css" rel="stylesheet" />
    <style type="text/css">
        .normal {
            background-color: white;
        }
        .highlight {
            background-color: #cccccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  <form runat="server">--%>
    <div class="normal" style="width: 1200px;">        
            <asp:Table runat="server" ID="tblProducts" Width="1200px" CssClass="table"></asp:Table>      
    </div>
</asp:Content>
