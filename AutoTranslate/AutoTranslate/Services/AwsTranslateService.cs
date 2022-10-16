using Amazon;
using Amazon.Runtime;
using Amazon.Translate;
using Amazon.Translate.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AutoTranslate.Services
{
    /*
     * Amazon language codes...
     * https://docs.aws.amazon.com/translate/latest/dg/what-is-languages.html
     * 
     * Region endpoints for translation service...
     * https://docs.aws.amazon.com/general/latest/gr/translate-service.html
     * 
     * Documentation...
     * https://docs.aws.amazon.com/translate/latest/APIReference/API_TranslateText.html
     */

    internal class AwsTranslateService : ITranslationService
    {
        public List<string> SupportedLanguages()
        {
            throw new NotImplementedException();
        }

        public bool Translate(string text, out string result, string sourceCulture, string targetCulture)
        {
            try
            {
                AmazonTranslateClient client = new AmazonTranslateClient(new BasicAWSCredentials("accessKey", "secretKey"), RegionEndpoint.USEast2);
                client.TranslateTextAsync(new TranslateTextRequest
                {
                    Settings = new TranslationSettings 
                    { 
                        Formality = Formality.INFORMAL,
                        Profanity = Profanity.MASK
                    },
                    SourceLanguageCode = sourceCulture, 
                    TargetLanguageCode = targetCulture,
                    Text = text
                });

                result = "";

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred attempting to translate the text.{Environment.NewLine}{ex}");

                result = Properties.Strings.FailedTranslation;

                return false;
            }
        }
    }
}
