using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;//iOS

public class ASXBridgePanelController : MonoBehaviour
{
    public Text iOSText;
    public Button iOSButton;
    public Button dialogButton;
    public Button httpButton;


    [DllImport("__Internal")] 
    private static extern void _enterBridgeController(); //该方法为oc 中mm文件方法名称
    [DllImport("__Internal")] 
    private static extern void _showDialog(string title, string message);

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
        _enterBridgeController();
    }

    void onDialogButtonClick() {
        _showDialog("提示","这是Unity传入的提示文本");

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
