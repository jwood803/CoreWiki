using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Core.CognitiveServices
{
	public class TextAnalyticsService
	{
		private readonly string _textToAnalyze;
		private const string LANGUAGE = "en";
		private const string ID = "0";

		public TextAnalyticsService(string textToAnalyze)
		{
			_textToAnalyze = textToAnalyze;
		}

		public async Task<string> CallCognitiveService()
		{
			var sentiment = String.Empty;

			var client = new Microsoft.Azure.CognitiveServices.Language.TextAnalytics.TextAnalyticsClient(new CognitiveServicesApiCrentials())
			{
				Endpoint = "https://eastus2.api.cognitive.microsoft.com"
			};

			var result = await client.SentimentWithHttpMessagesAsync(new MultiLanguageBatchInput(
					new List<MultiLanguageInput> { new MultiLanguageInput(LANGUAGE, ID, _textToAnalyze) }));

			var sentimentResult = result.Body.Documents.FirstOrDefault();

			if (sentimentResult != null)
			{
				var sentimentScore = sentimentResult.Score;

				if (sentimentScore > 0.7)
				{
					sentiment = "Positive";
				}
				else if (sentimentScore < 0.7 && sentimentScore > 0.3)
				{
					sentiment = "Neutral";
				}
				else
				{
					sentiment = "Negative";
				}
			}

			return sentiment;
		}

		public string ParseResult<T>(T cognitiveServiceResult)
		{
			return "";
		}
	}
}
