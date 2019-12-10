using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.Models
{
	public class Message
	{
		public System.DateTime Time { get; set; }
		public string Text { get; set; }
		public int Id { get; set; }
		public Topic Topic { get; set; }
		public int? TopicId { get; set; }
		public User User { get; set; }
		public int? UserId { get; set; }
	}
}
