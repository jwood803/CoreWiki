using Microsoft.Rest;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWiki.Core.CognitiveServices
{
	public class CognitiveServicesApiCrentials : ServiceClientCredentials
	{
		public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			request.Headers.Add("Ocp-Apim-Subscription-Key", "a6fc3b04ed3e40a2960d4bd040627d57");
			return base.ProcessHttpRequestAsync(request, cancellationToken);
		}
	}
}
