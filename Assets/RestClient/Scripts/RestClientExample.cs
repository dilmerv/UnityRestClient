using System.Collections;
using System.Collections.Generic;
using System.Text;
using RestClient.Core;
using RestClient.Core.Models;
using TMPro;
using UnityEngine;

public class RestClientExample : MonoBehaviour
{
    [SerializeField]
    private string baseUrl = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/ocr?language=unk&detectOrientation=true";

    [SerializeField]
    private string clientId;

    [SerializeField]
    private string clientSecret;

    [SerializeField]
    private string imageToOCR = "";

    [SerializeField]
    private TextMeshProUGUI header;

    [SerializeField]
    private TextMeshProUGUI wordsCapture;
    
    void Start()
    {
        // setup the request header
        RequestHeader clientSecurityHeader = new RequestHeader {
            Key = clientId,
            Value = clientSecret
        };

        // setup the request header
        RequestHeader contentTypeHeader = new RequestHeader {
            Key = "Content-Type",
            Value = "application/json"
        };
        
        // validation
        if(string.IsNullOrEmpty(imageToOCR))
        {
            Debug.LogError("imageToOCR needs to be set through the inspector...");
            return;
        }

        // build image url required by Azure Vision OCR
        ImageUrl imageUrl = new ImageUrl { Url = imageToOCR };
        
        // send a post request
        StartCoroutine(RestWebClient.Instance.HttpPost(baseUrl, JsonUtility.ToJson(imageUrl), (r) => OnRequestComplete(r), new List<RequestHeader> 
        {
            clientSecurityHeader,
            contentTypeHeader
        }));
    }

    void OnRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
        
        if(string.IsNullOrEmpty(response.Error) && !string.IsNullOrEmpty(response.Data))
        {
            AzureOCRResponse azureOCRResponse = JsonUtility.FromJson<AzureOCRResponse>(response.Data);

            header.text = $"Orientation: {azureOCRResponse.orientation} Language: {azureOCRResponse.language} Text Angle: {azureOCRResponse.textAngle}";

            string words = string.Empty;
            foreach (var region in azureOCRResponse.regions)
            {
                foreach (var line in region.lines)
                {
                    foreach (var word in line.words)
                    { 
                        words += word.text + "\n";
                    }
                }
            } 
            wordsCapture.text = words;
        }
    }

    public class ImageUrl 
    {
        public string Url;
    }
}
