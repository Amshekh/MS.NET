<script language="C#" runat="server">

	private void Page_Load(object sender, EventArgs e)
	{
		userCountLabel.Text = Application["count"].ToString();

		Session["count"] = (int) Session["count"] + 1;
		requestCountLabel.Text = Session["count"].ToString();
		
		ViewState["count"] = (int) (ViewState["count"] ?? -1) + 1;
		submitCountLabel.Text = ViewState["count"].ToString();

		if(Page.IsPostBack)
			greetLabel.Text = "Hello  " + nameTextBox.Text;
	}

</script>

<html>
	<head>
		<title>StateTest - BasicWebApp</title>
	</head>
	<body>
		<p>
			<asp:Label Id="greetLabel" Text="Welcome Visitor" Font-Size="XX-Large" runat="server" />
		</p>
		<form id="WebForm" runat="server">
			<asp:Label Text="Your Name:" runat="server" />
			<asp:TextBox Id="nameTextBox" runat="server" />
			<asp:Button Id="greetButton" Text="Greet!" runat="server" />
		</form>
		<p>
			<b>User Count: </b><asp:Label Id="userCountLabel" runat="server" />
		</p>
		<p>
			<b>Request Count: </b><asp:Label Id="requestCountLabel" runat="server" />
		</p>
		<p>
			<b>Submit Count: </b><asp:Label Id="submitCountLabel" runat="server" />
		</p>
		<a href="statetest.aspx">Reload</a>
	</body>
</html>











