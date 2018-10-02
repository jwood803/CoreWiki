using CoreWiki.Core.CognitiveServices;
using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace CoreWiki.Test.CognitiveServices
{
	public class TextSentimentTests
	{
		[Fact]
		public void TestSentiment()
		{
			var cognitiveServiceMock = new Mock<ICognitiveService>(MockBehavior.Strict);
			var service = new TextAnalyticsService("This is really good code");

			var response = new HttpOperationResponse { Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK) };

			cognitiveServiceMock.Setup(m => m.SentimentWithHttpMessagesAsync()).Returns(Task.FromResult(response));

			var result = service.CallCognitiveService();
		}
	}
}
