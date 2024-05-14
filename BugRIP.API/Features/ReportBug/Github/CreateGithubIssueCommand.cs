using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRIP.API.Features.ReportBug.Github
{
	public class CreateGithubIssueCommand
	{
		private readonly ILogger<CreateGithubIssueCommand> _logger;

		public CreateGithubIssueCommand(ILogger<CreateGithubIssueCommand> logger)
		{
			_logger = logger;
		}
		const string _commandType = "Create Github issue";
		bool isSuccessful = true;
		public async Task<ReportedBug> Execute(NewBug newBug)
		{
			_logger.LogInformation($"{_commandType}");

			//TODO: Create Github Issue
			ReportedBug reportedBug = new ReportedBug("1", newBug.Summary, newBug.Description);

			string successState = isSuccessful ? "Successful" : "Not Successful";
			_logger.LogInformation($"{_commandType} # {reportedBug.Id} is " + successState);

			return reportedBug;
		}
	}
}
