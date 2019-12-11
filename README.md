### i将iOS项目UnityBridge中的Bridge文件夹，拖入Unity项目Bridge导出的Xcode工程即可测试。

### Unity端
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;//iOS

public class ASXBridgePanelController : MonoBehaviour
{
    public Text iOSText;
    public Button iOSButton;
    public Button dialogButton;

    [DllImport("__Internal")] 
    private static extern void _enterBridgeController(); //该方法为oc 中mm文件方法名称
    [DllImport("__Internal")] 
    private static extern void _showDialog(string title, string message);

    void Start()
    {
        iOSButton.onClick.AddListener(oniOSButtonClick);
        dialogButton.onClick.AddListener(onDialogButtonClick);
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
}

```
### iOS端
```
#import "ASXBridgeManager.h"
#import "ASXRouteManager.h"

@implementation ASXBridgeManager

extern "C" void _initializeBridge() {
    
}

extern "C" void _enterBridgeController() {
    [ASXRouteManager enterBridgeController];
}

//接收Unity消息
extern "C" void _showDialog(const char *title, const char *msg) {
    [ASXRouteManager showDialog:[NSString stringWithUTF8String:title] message:[NSString stringWithUTF8String:msg]];
}

//发送消息给Unity
UnitySendMessage("ASXBridgePanel", "iOSCallback", "{\"name\":\"Jack\",\"icon\":\"lufy.png\"}");
@end

```

