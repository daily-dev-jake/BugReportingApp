using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BugRIP.API.Features.ReportBug.Github;
using BugRIP.API.Features.ReportBug;

namespace BugRIP.API.Functions
{
    public class ReportBugFunction
    {
        private readonly ILogger<ReportBugFunction> _logger;
        private readonly CreateGithubIssueCommand _createGithubIssueCommand;
        
		public ReportBugFunction(ILogger<ReportBugFunction> logger, CreateGithubIssueCommand createGithubIssueCommand)
		{
			_logger = logger;
			_createGithubIssueCommand = createGithubIssueCommand;
		}

		[FunctionName("ReportBugFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bugs")] HttpRequest req)
        {

			NewBug newBug = new NewBug("Bad bug", "The div on page is not centered");

			ReportedBug reportedBug = await _createGithubIssueCommand.Execute(newBug);

			return new OkObjectResult(reportedBug);
        }
    }
}
