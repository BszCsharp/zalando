<%@ Page Language="C#" AutoEventWireup="true" CodeFile="landzano2.aspx.cs" Inherits="landzano2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>landzano-Mode</title>
    <link href="format.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="outerDiv ">
            <div id="header">
                <img src="Images/logo.png" class="style1" />
                Entdecke landzano. Die neue Welt der Mode
            </div>
            <div id="mainColumn">
                <p>
                    <asp:LinkButton ID="LinkButtonRegister" runat="server" OnCommand="Link_Command" CommandName="Register">Registrieren</asp:LinkButton>
                    - 
                <asp:LinkButton ID="LinkButtonBestellung" runat="server" OnCommand="Link_Command" CommandName="Bestellung">Bestellung</asp:LinkButton>
                    - 
                <asp:LinkButton ID="LinkButtonSend" runat="server" OnCommand="Link_Command" CommandName="Send">Absenden</asp:LinkButton>
                </p>
                <asp:MultiView ID="MultiViewLandzano" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewRegister" runat="server">
                        <table>
                            <tr>
                                <td>Emial</td>
                                <td>
                                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Kennwort</td>
                                <td>
                                    <asp:TextBox ID="TextBoxKennwort" runat="server" TextMode="Password"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Button1" runat="server" Text="speichern" OnClick="Button1_Click" /></td>

                            </tr>

                        </table>
                    </asp:View>
                    <asp:View ID="ViewBestellung" runat="server">
                        <asp:CheckBoxList ID="CheckBoxListAngebote" runat="server">
                        </asp:CheckBoxList>
                        <p>
                            <asp:LinkButton ID="LinkButtonReady" runat="server" OnClick="LinkButtonReady_Click">Fertig</asp:LinkButton>
                        </p>
                    </asp:View>
                    <asp:View ID="ViewSend" runat="server">
                        <asp:Repeater ID="RepeaterSelList" runat="server">
                            <HeaderTemplate><table border="1"></HeaderTemplate>
                            <ItemTemplate> <tr> <td> <%# Container.DataItem %> </td></tr></ItemTemplate>
                            <FooterTemplate></table></FooterTemplate>
                        </asp:Repeater>
                        <asp:Label ID="LabelMeldung" runat="server" Text=""></asp:Label>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>

    </form>
</body>
</html>
