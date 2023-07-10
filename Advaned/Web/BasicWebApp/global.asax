<script language="C#" runat="server">

	private void Application_OnStart(object sender, EventArgs e)
	{
		Application["count"] = 0;
	}

	private void Session_OnStart(object sender, EventArgs e)
	{
		Session["count"] = 0;
		Application.Lock();
		Application["count"] = (int) Application["count"] + 1;
		Application.UnLock();
	}

	private void Session_OnEnd(object sender, EventArgs e)
	{
		Application.Lock();
		Application["count"] = (int) Application["count"] - 1;
		Application.UnLock();
	}

</script>