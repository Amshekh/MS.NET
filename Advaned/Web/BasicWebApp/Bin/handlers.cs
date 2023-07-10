using System;
using System.IO;
using System.Web;

namespace BasicWebApp
{
	public class GreetingHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string name = context.Request.QueryString["name"];
			TextWriter writer = context.Response.Output;

			writer.WriteLine("<html>");
			writer.WriteLine("<head><title>Greetings</title></head>");
			writer.WriteLine("<body>");
			writer.WriteLine("<h1>Welcome Visitor {0}</h1>", name);
			writer.WriteLine("<b>Time on server: </b>{0}", DateTime.Now);
			writer.WriteLine("</body>");
			writer.WriteLine("</html>");
		}

		public bool IsReusable
		{
			get { return true; }
		}
	}
}















