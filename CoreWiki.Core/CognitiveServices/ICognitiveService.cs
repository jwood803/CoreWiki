using Microsoft.Rest;
using System.Threading.Tasks;

namespace CoreWiki.Core.CognitiveServices
{
	public interface ICognitiveService
	{
		Task<HttpOperationResponse> SentimentWithHttpMessagesAsync();
	}
}
