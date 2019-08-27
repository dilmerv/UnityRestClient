# UnityRestClient

A Restful Client that allows making simple GET, POST, PUT, and DELETE http calls from within Unity3d.

## How to Use It ?

There are two scenes currently in the project that can be used to find out how to use it. Also few snippets below to demo its functionality within Unity3d.


1. Example of how to call Azure Vision API

```csharp
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
```

2. Example of Get and Post
```csharp
// send a get request
StartCoroutine(RestWebClient.Instance.HttpGet($"{baseUrl}api/values", (r) => OnRequestComplete(r)));

// setup the request header
RequestHeader header = new RequestHeader {
    Key = "Content-Type",
    Value = "application/json"
};

// send a post request
StartCoroutine(RestWebClient.Instance.HttpPost($"{baseUrl}api/values", 
JsonUtility.ToJson(new Player { FullName = "John Doe" }), 
    (r) => OnRequestComplete(r), new List<RequestHeader> { header } ));
```
