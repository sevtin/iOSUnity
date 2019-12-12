using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;//iOS
using System.Collections.Generic;
using Newtonsoft.Json;
public class ASXBridgePanelController : MonoBehaviour
{
    public Text iOSText;
    public Button iOSButton;
    public Button dialogButton;
    public Button httpButton;

    [DllImport("__Internal")] 
    private static extern void _iOSSendMessage(int type,int subType,string msg);//该方法为oc中mm文件方法名称

    void Start()
    {
        iOSButton.onClick.AddListener(oniOSButtonClick);
        dialogButton.onClick.AddListener(onDialogButtonClick);
        httpButton.onClick.AddListener(onHttpButtonCallback);

        iOSText.text = "iOS传入内容: ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void oniOSButtonClick() {
        _iOSSendMessage(ASXConst.Uniquely_Identified_Type_EnterCtrl,ASXConst.Uniquely_Identified_Type_EnterCtrl_Bridge,null);
    }

    void onDialogButtonClick() {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("title","提示");
        dictionary.Add("desc","这是Unity传入的提示文本");
        string json = JsonConvert.SerializeObject(dictionary);
        iOSText.text = "传入iOS内容: " + json;
        _iOSSendMessage(ASXConst.Uniquely_Identified_Type_Dialog,ASXConst.Uniquely_Identified_Type_Dialog_Nomarl,json);
    }

    public void iOSCallback(string json) {
        iOSText.text = "iOS传入内容: " + json;
    }

    void onHttpButtonCallback(){
        string url = "https://www.binance.com/api/v1/depth?symbol=BNBBTC&limit=1000";
        HttpHelper.Request(this, url, HttpHelper.MethodType.POST, null, HttpHelper.DownloadHanlderType.kHttpTEXT,delegate (bool isSucceed, object value) {
            // 这个object的封箱和拆箱有什么好办法吗？
            Debug.Log(value.ToString());
        });

        /*
        string url = "http://192.169.19.239:8081/Sim";
        Dictionary<string, object> keyValues = new Dictionary<string, object>();
        keyValues.Add("request", "userInfo");
        HttpHelper.Request(this, url, HttpHelper.MethodType.POST, keyValues, delegate (bool isSucceed, object value) {
            // 这个object的封箱和拆箱有什么好办法吗？
            Debug.Log(value.ToString());
        }, HttpHelper.DownloadHanlderType.kHttpTEXT);
         */

    }

    void webRequestCallback(bool isSucceed,object value){
        Debug.Log(value.ToString());
    }
}
