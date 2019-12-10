using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Models
{
	public class Topic
	{
		public string Name { get; set; }
		public string PreviewImageName { get; set; }
		public DateTime CreationDate { get; set; }
		public string Description { get; set; }
		public User Creator { get; set; }
		public int? CreatorId { get; set; }

		public List<Message> Messages { get; set; }
		public Topic()
		{
			Messages = new List<Message>();
		}
		public int Id { get; set; }
	}
}
