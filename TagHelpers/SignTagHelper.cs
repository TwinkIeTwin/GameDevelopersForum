using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.TagHelpers
{
	public class SignTagHelper : TagHelper
	{
		public string Sender { get; set; }
		public DateTime Time { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";
			output.Content.SetContent("Created by " + Sender + " at " + Time);
		}
	}
}
