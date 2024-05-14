using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRIP.API.Functions
{
	public class ReportedBugRequest
	{
		public ReportedBugRequest(string description, string summary)
		{
			Description = description;
			Summary = summary;
		}

		public string Description { get; }
		public string Summary { get; }
	}
}
