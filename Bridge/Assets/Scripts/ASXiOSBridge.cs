using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.InteropServices;//iOS
public class ASXiOSBridge
{
    [DllImport("__Internal")]
    private static extern void _iOSSendMessage(int type, int subType, string msg);//该方法为oc中mm文件方法名称

    public static void sendMessage(int type, int subType, Dictionary<string, string> msg)
    {
        string json = null;
        if (msg != null)
        {
            json = JsonConvert.SerializeObject(msg);
        }
        ASXiOSBridge._iOSSendMessage(type, subType, json);
    }
}
