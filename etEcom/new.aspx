<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new.aspx.cs" Inherits="etEcom._new" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .ListControl input[type=checkbox], input[type=radio]
{
    display: none;
}
.ListControl label
{
    display: inline;
    float: left;
    color: #000;
    cursor: pointer;
    text-indent: 20px;
    white-space: nowrap;
}
.ListControl input[type=checkbox] + label
{
    display          : block;
    width            : 1em;
    height           : 1em;
    border           : 0.0625em solid rgb(192,192,192);
    border-radius    : 0.25em;
    background       : rgb(211,168,255);
    background-image : -moz-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -ms-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -o-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -webkit-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : linear-gradient(rgb(240,240,240),rgb(211,168,255));
    vertical-align   : middle;
    line-height      : 1em;
    font-size        : 14px;
}
.ListControl input[type=checkbox]:after + label::before
{
    content         : "\2714";
    color           : #fff;
    height          : 1em;
    line-height     : 1.1em;
    width           : 1em;
    font-weight     : 900;
    margin-right    : 6px;
    margin-left     : -20px;
}
.ListControl input[type=radio] + label  
{
    display          :block;
    width            : 1em;
    height           : 1em;
    border           : 0.0625em solid black;
    border-radius    : 1em;
    background       : rgb(211,168,255);
    background-image : -moz-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -ms-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -o-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : -webkit-linear-gradient(rgb(240,240,240),rgb(211,168,255));
    background-image : linear-gradient(rgb(240,240,240),rgb(211,168,255));
    vertical-align   : middle;
    line-height      : 1em;
    font-size        : 14px;
}
.ListControl input[type=radio]:checked + label::before
{
    content         : "\2716";
    color           : #fff;
    display         : inline;
    width           : 1em;
    height          : 1em;
    margin-right    : 6px;
    margin-left     : -20px;
}
/*Single Radiobutton:*/
.RadioLabel
{
    white-space: nowrap;
}

.SingleRadio input[type=radio]
{
    display: none;
}

.SingleRadio label  
{
    display: block;
    float: left;
    color: #000;
    cursor: pointer;
}
.SingleRadio input[type=radio] + label
{
    display          : block;
    width            : 1em;
    height           : 1em;
    /*border           : 0.0625em solid black;*/
    border-radius    : 1em;
    border           : 2px solid rgb(192,192,192);
    background       : #fff;
    vertical-align   : middle;
    text-indent      : 1.5px;
    font-size: 13px;
    line-height: 14px;
    color: #555555;
    cursor: pointer;
    text-transform: capitalize;
    font-weight: normal;
    top:5px;
}
.SingleRadio input[type=radio]:hover + label:hover
{
    border          : 2px solid #2da5da;
    background      : #fff;
}
.SingleRadio input[type=radio]:checked + label::before
{
    content         : url(Images/tick.png);
    display         : inline;
}
/*Single Checkbox:*/
.CheckBoxLabel
{
    white-space: nowrap;
}

.SingleCheckbox input[type=checkbox]
{
    display: none;
}

.SingleCheckbox label  
{
    display: block;
    float: left;
    color: #000;
    cursor: pointer;
}
.SingleCheckbox input[type=checkbox] + label
{
    display          : block;
    width            : 1em;
    height           : 1em;
    border           : 2px solid rgb(192,192,192);
    background       : #fff;
    vertical-align   : middle;
    text-indent      : 1.5px;
    font-size: 13px;
    line-height: 14px;
    color: #555555;
    cursor: pointer;
    text-transform: capitalize;
    font-weight: normal;
    top:5px;
}
.SingleCheckbox input[type=checkbox]:hover + label:hover
{
    border          : 2px solid #2da5da;
    background      : #fff;
}
.SingleCheckbox input[type=checkbox]:checked + label::before
{
    content         : url(Images/tick.png);
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="SingleCheckbox">
    <asp:CheckBox ID="cbActive" runat="server"></asp:CheckBox>
        <br />
        <br />
    <asp:Label ID="Label3" AssociatedControlID="cbActive" runat="server" 
      Text="" CssClass="CheckBoxLabel"></asp:Label>
    </div>
        <div class="ListControl">
        <asp:RadioButton ID="hello" runat="server" CssClass="SingleRadio"></asp:RadioButton>
            <br />
        <asp:Label ID="Label4" AssociatedControlID="hello" runat="server" Text="" CssClass="RadioLabel"></asp:Label>
            </div>
    </form>
</body>
</html>