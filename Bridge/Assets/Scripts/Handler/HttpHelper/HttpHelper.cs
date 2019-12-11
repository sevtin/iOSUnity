using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpHelper
{
    public enum MethodType
    {
        GET,
        POST
    }

    public class DownloadHanlderType
    {
        public const string kHttpBYTE = "BYTE";
        public const string kHttpTEXT = "TEXT";
    }


    public static void Request(MonoBehaviour mono, string url, MethodType method, Dictionary<string, object> form, string responseType, Action<bool, object> callback)
    {
        if (method == MethodType.GET)
        {
            url = CreateGetData(url, form);
            mono.StartCoroutine(Request(url, null, responseType, callback));
        }
        else if (method == MethodType.POST)
        {
            WWWForm formData = CreatePostData(form);
            mono.StartCoroutine(Request(url, formData, responseType, callback));
        }
        else
        {
            Debug.LogError("Type Error");
        }
    }

    static IEnumerator Request(string url, WWWForm form, string dateType, Action<bool, object> callback)
    {
        UnityWebRequest request = null;
        if (form == null)
            request = UnityWebRequest.Get(url);
        else
            request = UnityWebRequest.Post(url, form);

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.LogErrorFormat("Request Error: {0}", request.error);
            callback.Invoke(false, request.error);
        }
        else if (request.isDone)
        {
            if (dateType == DownloadHanlderType.kHttpTEXT)
            {
                callback?.Invoke(true, request.downloadHandler.text);
            }
            else if (dateType == DownloadHanlderType.kHttpBYTE)
            {
                callback?.Invoke(true, request.downloadHandler.data);
            }
            else
            {
                Debug.LogError("Request Error");
            }
        }
    }

    private static string CreateGetData(string url, Dictionary<string, object> form)
    {
        string data = "";
        if (form != null && form.Count > 0)
        {
            foreach (var item in form)
            {
                data += item.Key + "=";
                data += item.Value.ToString() + "&";
            }
        }
        if (url.IndexOf("?") == -1)
            url += "?";
        else
            url += "&";

        url += data.TrimEnd(new char[] { '&' });
        return url;
    }

    private static WWWForm CreatePostData(Dictionary<string, object> formData)
    {
        WWWForm form = new WWWForm();
        if (formData != null && formData.Count > 0)
        {
            foreach (var item in formData)
            {
                if (item.Value is byte[])
                    form.AddBinaryData(item.Key, item.Value as byte[]);
                else
                    form.AddField(item.Key, item.Value.ToString());
            }
        }
        return form;
    }
}
