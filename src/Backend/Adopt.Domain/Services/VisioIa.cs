using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Adopt.Domain.Services
{
    public class VisioIa
    {

        public bool Response()
        {
            string responseContent = MakeRequest().GetAwaiter().GetResult();
            dynamic json = JsonConvert.DeserializeObject(responseContent);
            string modelVersion = json.modelVersion;
            Console.WriteLine("Model version: {0}", modelVersion);

            var tagsResult = json.tagsResult;
            bool isDog = false;
            foreach (var tag in tagsResult.values)
            {
                string name = tag.name;
                double confidence = tag.confidence;
                if (name == "cão")
                {
                    isDog = true;
                }
            }
                return isDog;
        }
        private async Task<string> MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Adicione os cabeçalhos da solicitação
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d22b19fb19474ca49436210b7f5cda04");

            // Defina os parâmetros da solicitação
            queryString["features"] = "tags";
            queryString["model-name"] = "";
            queryString["language"] = "pt-br";
            queryString["smartcrops-aspect-ratios"] = "";
            queryString["gender-neutral-caption"] = "False";

            // Construa a URI com os parâmetros
            var uri = "https://ai-vision-dio.cognitiveservices.azure.com/computervision/imageanalysis:analyze?api-version=2023-02-01-preview&" + queryString;

            HttpResponseMessage response;

            // Corpo da solicitação
            byte[] byteData = Encoding.UTF8.GetBytes("{'url': 'https://a-static.mlcdn.com.br/800x560/coca-cola-original-2l/techshedbrasil/7894900027013/3f2bb3ed5940f407986eb3d37d7a78ca.jpeg'}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
