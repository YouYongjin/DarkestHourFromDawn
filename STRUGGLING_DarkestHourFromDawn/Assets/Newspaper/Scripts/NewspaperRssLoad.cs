using System;
using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.Networking;
using UnityEngine.UI;
public class NewspaperRssLoad : MonoBehaviour
{
    public Text dateHolder;
    public Text titleHolder;
    public Image imageHolder;

    [Header("RSS Feed General")]
    public string rssUrl="http://www.cbc.ca/cmlink/rss-topstories";
    public string baseNode = "item";
   
    [Header("Date Adjustments")]
    public int dateNodeParent = 0;
    public int dateNodeChild = 3;
    public int datefirstIndex = 0;
    public string dateSeperatorString = ":";
    public int dateAdjustment = -3;
    
    [Header("Title Adjustments")]
    public int titleNodeParent = 0;
    public int titleNodeChild = 0;

    [Header("Image Adjustments")]
    public int imageNodeParent = 0;
    public int imageNodeChild = 6;

    
    public void Start()
    {
           StartCoroutine(GetTextFromUrl());
    }

    private IEnumerator GetTextFromUrl() 
     {
        var www = UnityWebRequest.Get(rssUrl);
        yield return www.SendWebRequest();
     
        if(www.isNetworkError) 
            Debug.Log(www.error);
        else 
            ParseData(www.downloadHandler.text);
     }

     private void ParseData(string input)
     {
         var doc = new XmlDocument();
         doc.LoadXml(input);
         XmlNode root = doc.DocumentElement;
         if (root == null) return;
         var nodeList = root.SelectNodes("descendant::"+baseNode);
         dateHolder.text = GetDateFromNode(GetTextFromNode(nodeList,dateNodeParent, dateNodeChild));
         titleHolder.text = GetTextFromNode(nodeList,titleNodeParent, titleNodeChild);
         StartCoroutine(LoadImageFromNode(doc, nodeList));
     }

     private string GetTextFromNode(XmlNodeList nodeList, int parent, int child)
     {
         return nodeList[parent].ChildNodes[child].InnerText;
     }

     private string GetDateFromNode(string date)
     {
         if (dateSeperatorString != null)
             return date.Substring(datefirstIndex,
                 date.IndexOf(dateSeperatorString, StringComparison.Ordinal) + dateAdjustment);
         return date;
     }
     private IEnumerator LoadImageFromNode(XmlDocument doc, XmlNodeList nodeList)
     {
         var frag = doc.CreateDocumentFragment();
         frag.InnerXml = nodeList[imageNodeParent].ChildNodes[imageNodeChild].InnerText;
         var img = frag["img"];

         if (img != null)
         {
             var www = UnityWebRequest.Get(img.GetAttribute("src"));
             www.downloadHandler = new DownloadHandlerTexture();
             yield return www.SendWebRequest();
             var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
             imageHolder.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
         }
         else
             Debug.Log("No image found to load");
     }
} 