<%@ WebService Language="C#" Class="GreeterService" %>

using System;
using System.Web.Services;

public class GreetInfo
{
	public string Message;
	public string Time;
}

[WebService(Namespace="http://adsd.met.edu/2011/BasicWinApp")] // accidently you named your web service name as BasicWinApp which was supposed to be BasicWebApp
public class GreeterService : WebService
{

	[WebMethod]
	public GreetInfo Meet(string name, int age)
	{
		GreetInfo info = new GreetInfo();
		info.Message = (age > 20 ? "Hi " : "Hello " ) + name;
		info.Time = DateTime.Now.ToString();

		return info;
	}

	[WebMethod]
	public string Leave(string name)
	{
		return "Goodbye " + name;
	}
}

/*
after coding this
put on cmdprompt wsdl http://localhost/BasicWinApp/websvctest.asmx?WSDL it will generate GreeterService.cs
now write client prg. websvcclient.cs
compile it as csc websvcclient.cs GreeterService.cs
to execute websvcclient.exe name age
*/