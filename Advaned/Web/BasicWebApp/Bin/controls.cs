using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWebApp
{
	public class ColorfulLabel : Label
	{
		private string[] colors = {"violet", "indigo", "blue", "green", "yellow", "orange", "red"};

		public string Colors
		{
			get { return string.Join(",", colors); }
			set { colors = value.Split(','); }
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.RenderBeginTag(writer);

			int i = 0;
			foreach(char ch in this.Text)
			{
				if(char.IsWhiteSpace(ch))
					writer.Write(ch);
				else
					writer.Write("<font color='{0}'>{1}</font>", colors[(i++) % colors.Length], ch);
			}
			
			base.RenderEndTag(writer);
		}
	}
}
