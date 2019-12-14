### 将iOS项目UnityBridge中的Bridge文件夹，拖入Unity项目Bridge导出的Xcode工程即可测试。
![image](https://github.com/saeipi/iOSUnity/blob/master/Image/IMG_1949.PNG)

### Unity端
```

    void oniOSButtonClick()
    {
        ASXiOSBridge.sendMessage(ASXConst.Uniquely_Identified_Type_EnterCtrl, ASXConst.Uniquely_Identified_Type_EnterCtrl_Bridge, null);
    }

    void onDialogButtonClick()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("title", "提示");
        dictionary.Add("desc", "这是Unity传入的提示文本");
        ASXiOSBridge.sendMessage(ASXConst.Uniquely_Identified_Type_Dialog, ASXConst.Uniquely_Identified_Type_Dialog_Nomarl, dictionary);
    }

```
### iOS端
```
extern "C" void _iOSSendMessage(int type, int subType,const char *msg) {
    NSDictionary *dictionary;
    if (msg != NULL) {
        dictionary = [ASXMessageHandler dictionaryWithJsonString:[NSString stringWithUTF8String:msg]];
    }
    switch (type) {
        case Uniquely_Identified_Type_Dialog:
            [ASXMessageHandler dialogWithSubType:subType msg:dictionary];
            break;
        case Uniquely_Identified_Type_EnterCtrl:
            [ASXMessageHandler enterCtrlWithSubType:subType msg:dictionary];
        break;
        default:
            break;
    }
}

+ (void)sendMessageToObj:(NSString* )obj method:(NSString* )method message:(NSMutableDictionary *)message {
    UnitySendMessage([obj UTF8String], [method UTF8String], [[ASXMessageHandler stringWithJSONObject:message] UTF8String]);
}

```

