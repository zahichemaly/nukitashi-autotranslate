using Google.Api.Gax.ResourceNames;
using Google.Cloud.Translate.V3;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace TextTranslator.Translators
{
    public class GoogleTranslator : ITranslator
    {
        private readonly string projectId;
        private readonly TranslationServiceClient client;

        public GoogleTranslator()
        {
            string serviceAccountPath = ConfigurationManager.AppSettings["ServiceAccountPath"];
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", serviceAccountPath);
            this.projectId = ConfigurationManager.AppSettings["ProjectId"];
            this.client = TranslationServiceClient.Create();
        }

        public Task<string> Translate(string lang, string text)
        {
            TranslateTextRequest request = new TranslateTextRequest
            {
                Contents = { text },
                TargetLanguageCode = lang,
                Parent = new ProjectName(projectId).ToString()
            };
            TranslateTextResponse response = client.TranslateText(request);
            Translation translation = response.Translations[0];
            string translatedText = translation.TranslatedText;
            return Task.FromResult(translatedText);
        }
    }
}
