<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F1000.aspx.cs" Inherits="Finance.Analysis.F1000" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="width: 1000px; height: 1000px;">
        <form id="form1" runat="server">
            <div style="width: 1000px; height: 1000px;">
                <asp:GridView ID="gv_Show" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="代碼">
                            <ItemTemplate>
                                <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公司">
                            <ItemTemplate>
                                <div style="width: 100px;">
                                    <asp:Label ID="lbl_Company" runat="server" Text='<%# Eval("Company") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="股價">

                            <ItemTemplate>
                                <div style="width: 100px;">
                                    <asp:Label ID="lbl_Price" runat="server" Text='<%# Convert.ToDecimal(Eval("StockPrice")) %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="配息">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Price" runat="server" Text='<%# Convert.ToDecimal(Eval("Dividend")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="配股">
                            <ItemTemplate>
                                <asp:Label ID="lbl_StockDividend" runat="server" Text='<%# Convert.ToDecimal(Eval("StockDividend")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="殖利率">
                            <ItemTemplate>
                                <asp:Label ID="lbl_DIVIDEND_YIELD" runat="server" Text='<%# Convert.ToDecimal(Eval("DIVIDEND_YIELD")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="10年股利次數">
                            <ItemTemplate>
                                <asp:Label ID="lbl_10DividendFequence" runat="server" Text='<%# Convert.ToInt32(Eval("DecadeDividendFequence")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="去年EPS">
                            <ItemTemplate>
                                <asp:Label ID="lbl_LastEPS" runat="server" Text='<%# Convert.ToDecimal(Eval("LAST_EPS")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>