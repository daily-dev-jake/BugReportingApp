using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRIP.API.Functions
{
	public class ReportedBugResponse
	{
		public ReportedBugResponse()
		{
		}

		public string Id { get; set; }
		public string Summary { get; set; }
		public string Description { get; set; }
	}
}
