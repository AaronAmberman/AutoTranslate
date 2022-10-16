using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AutoTranslate.Services
{
    /// <summary>A simple wrapper for Libre Translate calls.</summary>
    internal class LibreTranslateService : ITranslationService
    {
        public List<string> SupportedLanguages()
        {
            throw new NotImplementedException();
        }

        public bool Translate(string text, out string result, string sourceCulture, string toCulture)
        {
            try
            {
                //HttpClient client = new HttpClient
                //{
                //    BaseAddress = new Uri(Properties.Settings.Default.LibreTranslateUrl),                
                //};
                //string json = "{" +
                //    $"\"q\": \"{text}\"," +
                //    $"\"source\": \"{sourceCulture}\"," +
                //    $"\"target\": \"{toCulture}\"," +
                //    "\"format\": \"text\"," +
                //    "\"apiKey\": \"\"" +
                //    "}";

                //FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>()
                //{
                //    { "q", text },
                //    { "source", sourceCulture },
                //    { "target", toCulture },
                //    { "format", "text" },
                //    { "api_key", "" }
                //});

                //HttpResponseMessage message = client.PostAsync("translate", content).Result;
                //HttpResponseMessage message = client.Send(new HttpRequestMessage(HttpMethod.Post, "translate")
                //{
                //    Content = content
                //});

                //JsonContent content = JsonContent.Create(json, typeof(string));
                //content.Headers.ContentLength = json.Length;
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                
                //HttpResponseMessage message = client.PostAsync("translate", content).Result;
                //HttpResponseMessage message2 = client.PostAsync($"{Properties.Settings.Default.LibreTranslateUrl}/translate", content).Result;
                //HttpResponseMessage message3 = client.PostAsJsonAsync("translate", json, new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web)).Result;

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
