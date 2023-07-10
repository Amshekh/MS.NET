<%@ Register TagPrefix="app" Namespace="BasicWebApp" Assembly="controls" %>

<script language="C#" runat="server">

	private void Page_Load(object sender, EventArgs e)
	{	
		greetLabel.Text = "Welcome Visitor " + Request.QueryString["name"];
		timeLabel.Text = DateTime.Now.ToString();
	}

</script>

<html>
	<head>
		<title>Greetings</title>
	</head>
	<body>
		<h1><app:ColorfulLabel Id="greetLabel" Text="Welcome Visitor"
			Colors="red,cyan,magenta,yellow,green,orange,blue" runat="server" /></h1>
		<b>Time on server: </b><asp:Label Id="timeLabel" runat="server" />
	</body>

</html>