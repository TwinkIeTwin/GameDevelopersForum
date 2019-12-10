using GameDevelopersForum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameDevelopersForum.ViewModels
{
	public class TopicEditModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
