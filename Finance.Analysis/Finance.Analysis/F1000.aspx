<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F1000.aspx.cs" Inherits="Finance.Analysis.F1000" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gv_Show" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="代碼">
                        <ItemTemplate>
                            <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="公司">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Company" runat="server" Text='<%# Eval("Company") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="股價">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Price" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="配息">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Allotment" runat="server" Text='<%# Eval("Allotment") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="配股">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Dividend" runat="server" Text='<%# Eval("Dividend") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
