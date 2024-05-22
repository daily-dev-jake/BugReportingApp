using BugRIP.API.Features.ReportBug.Github;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(BugRIP.API.Startup))]
namespace BugRIP.API
{
	public class Startup : FunctionsStartup
	{

		public override void Configure(IFunctionsHostBuilder builder)
		{
			IConfiguration configuration = builder.GetContext().Configuration;

			string githubToken = configuration.GetValue<string>("GITHUB_TOKEN");
			
			string firebaseConfig = configuration.GetValue<string>("FIREBASE_CONFIG");
			FirebaseApp firebaseApp = FirebaseApp.Create(new AppOptions()
			{
				Credential = GoogleCredential.FromJson(firebaseConfig),
			});
			builder.Services.AddSingleton(firebaseApp);
			builder.Services.AddFirebaseAuthentication();
			builder.Services.Configure((Action<GithubRepositoryOptions>)(options =>
			{
				options.Owner = configuration.GetValue<string>("GITHUB_REPOSITORY_OWNER");
				options.Name = configuration.GetValue<string>("GITHUB_REPOSITORY_NAME");
			}));
			builder.Services.AddSingleton(new GitHubClient(new ProductHeaderValue("bugrip-api"))
			{
				Credentials = new Credentials(githubToken)
			});
			builder.Services.AddSingleton<CreateGithubIssueCommand>();
		}
	}
}
