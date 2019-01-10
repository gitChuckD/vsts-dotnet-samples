using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Policy.WebApi;

namespace Microsoft.TeamServices.Samples.Client.Git
{
    [ClientSample(GitWebApiConstants.AreaName, "policy")]
    public class PoliciesSample : ClientSample
    {
        [ClientSampleMethod]
        public IEnumerable<PolicyConfiguration> ListPolicyConfigurations()
        {
            VssConnection connection = this.Context.Connection;
            PolicyHttpClient policyClient = connection.GetClient<PolicyHttpClient>();

            Guid projectId = ClientSampleHelpers.FindAnyProject(this.Context).Id;

            List<PolicyConfiguration> configs = policyClient.GetPolicyConfigurationsAsync(projectId).Result;

            foreach (PolicyConfiguration config in configs)
            {
                Console.WriteLine("{0} {1} {2}", config.Id, config.GetType(), config.Url);
            }

            return configs;
        }

    }
}
