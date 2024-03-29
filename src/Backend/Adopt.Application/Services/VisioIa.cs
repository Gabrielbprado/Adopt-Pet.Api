﻿using Adopt.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Adopt.Domain.Services;

public class VisioIa : IVisionIA
{
    public  bool Response(byte[] bytes)
    {
        string responseContent = MakeRequest(bytes).GetAwaiter().GetResult();
        dynamic json = JsonConvert.DeserializeObject(responseContent);
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
    public async Task<string> MakeRequest(byte[] bytes)
    {
        var client = new HttpClient();
        var queryString = HttpUtility.ParseQueryString(string.Empty);

      
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "Sua Chave");

        
        queryString["features"] = "tags";
        queryString["model-name"] = "";
        queryString["language"] = "pt-br";
        queryString["smartcrops-aspect-ratios"] = "";
        queryString["gender-neutral-caption"] = "False";

        var uri = "https://ai-vision-dio.cognitiveservices.azure.com/computervision/imageanalysis:analyze?api-version=2023-02-01-preview&" + queryString;

        HttpResponseMessage response;

        using (var content = new ByteArrayContent(bytes))
        {
            
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            
            response = await client.PostAsync(uri, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}

