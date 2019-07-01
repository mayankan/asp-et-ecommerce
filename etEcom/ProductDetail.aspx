<%@ Page Title="" Language="C#" MasterPageFile="~/Buyers.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="etEcom.ProductDetail" %>

<%@ Register Src="~/ProductDet.ascx" TagPrefix="uc1" TagName="ProductDet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <uc1:ProductDet runat="server" id="ProductDet" />
            </div>
</asp:Content>
