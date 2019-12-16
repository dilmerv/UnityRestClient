using System.Collections.Generic;
using RestClient.Core;
using RestClient.Core.Models;
using UnityEngine;

public class RestClientHeadExample : MonoBehaviour
{
    [SerializeField]
    private string baseUrl = "https://localhost:5000";

    void Start()
    {
        // send a head request
        StartCoroutine(RestWebClient.Instance.HttpHead($"{baseUrl}", (r) => OnRequestHeadComplete(r)));
    }

    void OnRequestHeadComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Headers: {response.Headers}");
        Debug.Log($"Error: {response.Error}");
    }

    public class Player
    {
        public string FullName;
    }
}
