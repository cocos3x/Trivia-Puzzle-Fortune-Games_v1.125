using UnityEngine;
public static class FacebookTrackingBridge
{
    // Methods
    public static void TrackEvent(string eventName)
    {
        FacebookTrackingBridge.SendRequest(externalMethodName:  0.ToString(), eventName:  eventName, jsonData:  0);
    }
    private static void SendRequest(string externalMethodName, string eventName, string jsonData)
    {
        object val_4;
        int val_5;
        string val_6;
        System.Object[] val_7;
        val_4 = eventName;
        string val_1 = System.String.Format(format:  "window.Facebook.{0}", arg0:  externalMethodName);
        if(val_4 != null)
        {
                object[] val_2 = new object[2];
            val_5 = val_2.Length;
            val_2[0] = val_4;
            if(jsonData != null)
        {
                val_5 = val_2.Length;
        }
        
            val_6 = val_1;
            val_7 = val_2;
            val_2[1] = jsonData;
        }
        else
        {
                object[] val_3 = new object[1];
            val_4 = val_3;
            val_4[0] = jsonData;
            val_6 = val_1;
            val_7 = val_4;
        }
        
        UnityEngine.Application.ExternalCall(functionName:  val_6, args:  val_3);
    }

}
