using System;

[Serializable]
public class AzureOCRResponse
{
    public string language;

    public decimal textAngle;

    public string orientation;

    public AzureOCRRegion[] regions;
}

[Serializable]
public class AzureOCRRegion
{
    public string boundingBox;
    public AzureOCRLine[] lines;
}

[Serializable]
public class AzureOCRLine
{
    public string boundingBox;

    public AzureOCRWord[] words;
}


[Serializable]
public class AzureOCRWord
{
    public string boundingBox;

    public string text;
}

/* 
{
	"language": "en",
	"textAngle": 0.0,
	"orientation": "Up",
	"regions": [
		{
			"boundingBox": "142,55,214,28",
			"lines": [
				{
					"boundingBox": "142,55,214,28",
					"words": [
						{
							"boundingBox": "142,55,22,28",
							"text": "0"
						},
						{
							"boundingBox": "170,58,20,25",
							"text": "01"
						},
						{
							"boundingBox": "194,55,162,27",
							"text": "STICKMAN"
						}
					]
				}
			]
		}
    ]
}
*/