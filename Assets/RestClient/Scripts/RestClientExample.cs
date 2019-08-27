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

    void Start()
    {
        // setup the request header
        RequestHeader clientHeader = new RequestHeader {
            Key = clientId,
            Value = clientSecret
        };
        
        // build image url required by Azure Vision OCR
        ImageUrl imageUrl = new ImageUrl {
            Url = "https://github.com/dilmerv/AzureVisionAPI/blob/master/images/IMG_5301.JPG?raw=true"
        };
        
        // send a post request
        StartCoroutine(RestWebClient.Instance.HttpPost(baseUrl, JsonUtility.ToJson(imageUrl), (r) => OnRequestComplete(r), new List<RequestHeader> 
        {
            clientHeader
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
