using System.Collections.Generic;

namespace AutoTranslate.Services
{
    internal interface ITranslationService
    {
        bool Translate(string text, out string result, string sourceCulture, string targetCulture);
        List<string> SupportedLanguages();
    }
}
