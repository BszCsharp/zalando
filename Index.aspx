<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>
<link href="format.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                <asp:MultiView ID="MultiViewlandzano" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewRegister" runat="server">
                        <table>
                            <tr>
                                <td>Email</td>
                                <td>
                                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Kennwort</td>
                                <td>
                                    <asp:TextBox ID="TextBoxKennwort" runat="server" TextMode="Password"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button ID="ButtonSpeichern" runat="server" Text="speichern" OnClick="ButtonSpeichern_Click" /></td>
                                <td></td>
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
                        <p>
                            Ihre Bestellungen
                        </p>
                        <asp:Repeater ID="RepeaterSelList" runat="server">

                            <HeaderTemplate>
                                <table border="1">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.DataItem %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                                
                            </FooterTemplate>
                        </asp:Repeater>
                        <p>
                            <asp:Label ID="LabelMeldung" runat="server" Text="Label"></asp:Label>
                        </p>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </form>
</body>
</html>
