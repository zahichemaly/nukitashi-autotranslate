using System.Threading.Tasks;

namespace TextTranslator.Translators
{
    public interface ITranslator
    {
        Task<string> Translate(string lang, string text);
    }
}
