using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Models
{
	public class News
	{
		public string Name { get; set; }
		public string PreviewImageName { get; set; }
		public string Description { get; set; }
		public DateTime PublishingDate { get; set; }
		public string Info { get; set; }
		public int Id { get; set; }
	}
}
