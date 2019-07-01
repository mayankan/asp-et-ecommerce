<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AutoSearchControl.ascx.cs" Inherits="UserControl.AutoSearchControl" %>
<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>

<script>
    //function callSrerverMethod() {
    //    PageMethods.GetData();

    //}
    function filter(term, _id, cellNr) {
        var suche = term.value.toLowerCase();
        var table = document.getElementById(_id);
        var ele;
        for (var r = 1; r < table.rows.length; r++) {
            ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
            if (ele.toLowerCase().indexOf(suche) >= 0)
                table.rows[r].style.display = '';
            else table.rows[r].style.display = 'none';
        }
    }
</script>

<asp:TextBox ID="txtSearch" runat="server"  onkeyup="filter(this, 'AutoSearchControl_gvNames', 0)" OnTextChanged="txtSearch_TextChanged" >

</asp:TextBox>
<asp:GridView ID="gvNames" runat="server" Visible="false" ></asp:GridView>