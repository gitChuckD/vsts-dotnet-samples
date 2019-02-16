using Microsoft.TeamFoundation.SourceControl.WebApi;

using Microsoft.VisualStudio.Services.WebApi;

using Microsoft.TeamFoundation.Policy.WebApi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Policy.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;

namespace Microsoft.TeamServices.Samples.Client.Policy
{
    [ClientSample(Microsoft.TeamFoundation.Policy.WebApi.PolicyWebApiConstants.AreaName, PolicyWebApiConstants.ConfigurationResource)]
    public class PoliciesSample : ClientSample
    {
        [ClientSampleMethod]
        public IEnumerable<PolicyConfiguration> ListPolicyConfigurations()
        {
            // This assumes that a policy has been added to a project
            VssConnection connection = this.Context.Connection;
            PolicyHttpClient policyClient = connection.GetClient<PolicyHttpClient>();
            
            TeamProjectReference project = ClientSampleHelpers.FindAnyProject(this.Context);
            Console.WriteLine("Looking for branch policies on project {0}:, {1}", project.Name, project.Description);

            Guid projectId = project.Id;
            
            List<PolicyConfiguration> configs = policyClient.GetPolicyConfigurationsAsync(projectId).Result;

            foreach (PolicyConfiguration config in configs)
            {
                Console.WriteLine("{0} {1} {2}", config.Id, config.GetType(), config.Url);
            }

            return configs;
        }

    }
}
