using DeepL;
using System.Configuration;
using System.Threading.Tasks;

namespace TextTranslator.Translators
{
    public class DeepLTranslator : ITranslator
    {
        private readonly Translator translator;

        public DeepLTranslator()
        {
            string authKey = ConfigurationManager.AppSettings["DeepLAuthKey"];
            this.translator = new Translator(authKey);
        }

        public async Task<string> Translate(string lang, string text)
        {
            var translatedText = await translator.TranslateTextAsync(
                  text,
                  LanguageCode.Japanese,
                  LanguageCode.English);
            return translatedText.Text;
        }
    }
}
