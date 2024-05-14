using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRIP.API.Features.ReportBug
{
	public class NewBug
	{

		public string Description { get; }
		public string Summary { get; }
		public NewBug(string description, string summary)
		{
			Description = description;
			Summary = summary;
		}


	}
}
