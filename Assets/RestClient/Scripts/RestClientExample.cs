using System.Collections;
using System.Collections.Generic;
using System.Text;
using RestClient.Core;
using RestClient.Core.Models;
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
    }

    public class ImageUrl 
    {
        public string Url;
    }
}
