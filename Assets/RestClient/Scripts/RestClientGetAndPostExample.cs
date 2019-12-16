using System.Collections.Generic;
using RestClient.Core;
using RestClient.Core.Models;
using UnityEngine;

public class RestClientGetAndPostExample : MonoBehaviour
{
    [SerializeField]
    private string baseUrl = "https://localhost:5000";

    void Start()
    {
        // send a get request
        StartCoroutine(RestWebClient.Instance.HttpGet($"{baseUrl}", (r) => OnRequestComplete(r)));

        // setup the request header
         RequestHeader header = new RequestHeader {
            Key = "Content-Type",
            Value = "application/json"
        };

        // send a post request
        StartCoroutine(RestWebClient.Instance.HttpPost($"{baseUrl}api/values", 
        JsonUtility.ToJson(new Player { FullName = "John Doe" }), 
            (r) => OnRequestComplete(r), new List<RequestHeader> { header } ));
    }

    void OnRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
    }

    public class Player
    {
        public string FullName;
    }
}
