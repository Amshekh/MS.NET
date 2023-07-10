<%@ Page Inherits="BasicWebApp.WebFormTest2" %> 
<html>
	<head>
		<title>WebFormTest1 - BasicWebApp</title>
	</head>
	<body>
		<p>
			<asp:Label Id="greetLabel" Text="Welcome Visitor" Font-Size="XX-Large"  runat="server"/>
		</p>
		
		<form id="WebForm" runat="server">
			<asp:Label Text="YourName:" runat="server" />
			<asp:TextBox Id="nameTextBox" runat="server" />
			<asp:Button Id="greenButton" Text="Greet!" OnClick="greetButton_Click" runat="server" />
		</form>
	</body>
</html>