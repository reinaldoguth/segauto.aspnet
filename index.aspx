<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SegAuto_CRUD_MySQL.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hfApoliceID" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label Text="Número da apólice" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtNrApolice" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="CPF/CNPJ do Segurado" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDocSegurado" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Placa do Veículo" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPlacaVeiculo" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Valor Prêmio" runat="server" />
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtValorPremio" runat="server" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td  colspan="2">
                    <asp:Button Text="Salvar" ID="btnSave" runat="server" OnClick="btnSave_Click" />
                    <asp:Button Text="Apagar" ID="btnDelete" runat="server" OnClick="btnDelete_Click" />
                    <asp:Button Text="Limpar" ID="btnClear" runat="server" OnClick="btnClear_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td  colspan="2">
                    <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td  colspan="2">
                    <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red" />
                </td>
            </tr>
        </table>
        <br/>
        <asp:GridView ID="gvApolices" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="tb10_nr" HeaderText="Apólice" />
                <asp:BoundField DataField="tb10_cpfcnpj" HeaderText="CPF/CNPJ" />
                <asp:BoundField DataField="tb10_placa" HeaderText="Placa" />
                <asp:BoundField DataField="tb10_valor_premio" HeaderText="Valor Prêmio" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Selecione" ID="lnkSelect" CommandArgument='<%# Eval("tb10_id") %>' runat="server" OnClick="lnkSelect_OnClick" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
