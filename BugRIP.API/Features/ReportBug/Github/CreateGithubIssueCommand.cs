using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRIP.API.Features.ReportBug.Github
{
	public class CreateGithubIssueCommand
	{
		private readonly GitHubClient _gitHubClient;
		private readonly GithubRepositoryOptions githubRepositoryOptions;
		private readonly ILogger<CreateGithubIssueCommand> _logger;
		public CreateGithubIssueCommand(ILogger<CreateGithubIssueCommand> logger, GitHubClient gitHubClient, IOptions<GithubRepositoryOptions> githubRepositoryOptions)
		{
			_logger = logger;
			_gitHubClient = gitHubClient;
			this.githubRepositoryOptions = githubRepositoryOptions.Value;
		}
		const string _commandType = "Create Github issue";
		bool isSuccessful = true;
		public async Task<ReportedBug> Execute(NewBug newBug)
		{
			_logger.LogInformation($"{_commandType}");

			//TODO: Create Github Issue
			NewIssue newIssue = new NewIssue(newBug.Summary)
			{
				Body = newBug.Description
			};
			var createdIssue = await _gitHubClient.Issue.Create(
				githubRepositoryOptions.Owner,
				githubRepositoryOptions.Name,
				newIssue);

			string successState = isSuccessful ? "Successful" : "Not Successful";
			_logger.LogInformation($"{_commandType} # {createdIssue.Number} is " + successState);

			return new ReportedBug(createdIssue.Number.ToString(), createdIssue.Title, createdIssue.Body);
		}
	}
}
