using UnityEngine;

namespace twelvegigs.plugins
{
    public class SharePlugin
    {
        // Fields
        private static UnityEngine.AndroidJavaObject plugin;
        
        // Methods
        public static void Share(string text, string url, string subject, string emailBody, string imgPath)
        {
            twelvegigs.plugins.SharePlugin.AndroidShare(text:  text, url:  url, subject:  subject, emailBody:  emailBody, imgPath:  imgPath);
        }
        public static void SendEmail(string subject, string emailBody, string url, string imgPath)
        {
            twelvegigs.plugins.SharePlugin.AndroidSendEmail(subject:  subject, emaiBody:  emailBody, url:  url, imgPath:  imgPath);
        }
        public static void ShareTwitter(string message, string url)
        {
            if(message.m_stringLength >= 281)
            {
                    UnityEngine.Debug.LogWarning(message:  "The length of your passed Tweet text should not exceed 280 ");
            }
            
            UnityEngine.Application.OpenURL(url:  System.String.Format(format:  "https://twitter.com/intent/tweet?text={0}&url={1}", arg0:  UnityEngine.WWW.EscapeURL(s:  message).Replace(oldValue:  "+", newValue:  "%20"), arg1:  UnityEngine.WWW.EscapeURL(s:  url).Replace(oldValue:  "+", newValue:  "%20")));
        }
        public static void OpenURL(string url)
        {
            UnityEngine.Application.OpenURL(url:  url);
        }
        public static void SendSMS(string text, string url)
        {
            twelvegigs.plugins.SharePlugin.AndroidSendSMS(text:  text, url:  url);
        }
        public static void SendWhatsApp(string text)
        {
            UnityEngine.Application.OpenURL(url:  "whatsapp://send?text="("whatsapp://send?text=") + UnityEngine.WWW.EscapeURL(s:  text).Replace(oldValue:  "+", newValue:  "%20")(UnityEngine.WWW.EscapeURL(s:  text).Replace(oldValue:  "+", newValue:  "%20")));
        }
        public static void CopyToClipBoard(string text, string label = "")
        {
            twelvegigs.plugins.SharePlugin.AndroidCopyToClipboard(text:  text, label:  label);
        }
        private static UnityEngine.AndroidJavaObject getPlugin()
        {
            var val_2 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_2 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_2 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_2 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            return new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.SharePlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        private static void AndroidShare(string text, string url, string subject, string emailBody, string imgPath)
        {
            int val_3;
            twelvegigs.plugins.SharePlugin.plugin = twelvegigs.plugins.SharePlugin.getPlugin();
            if(twelvegigs.plugins.SharePlugin.plugin == null)
            {
                    return;
            }
            
            object[] val_2 = new object[5];
            val_3 = val_2.Length;
            val_2[0] = text;
            if(url != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[1] = url;
            if(subject != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[2] = subject;
            if(emailBody != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[3] = emailBody;
            if(imgPath != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[4] = imgPath;
            twelvegigs.plugins.SharePlugin.plugin.Call(methodName:  "shareContent", args:  val_2);
        }
        private static void AndroidCopyToClipboard(string text, string label)
        {
            int val_3;
            twelvegigs.plugins.SharePlugin.plugin = twelvegigs.plugins.SharePlugin.getPlugin();
            if(twelvegigs.plugins.SharePlugin.plugin == null)
            {
                    return;
            }
            
            object[] val_2 = new object[2];
            val_3 = val_2.Length;
            val_2[0] = label;
            if(text != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[1] = text;
            twelvegigs.plugins.SharePlugin.plugin.Call(methodName:  "copyToClipboard", args:  val_2);
        }
        private static void AndroidSendEmail(string subject, string emaiBody, string url, string imgPath)
        {
            int val_3;
            twelvegigs.plugins.SharePlugin.plugin = twelvegigs.plugins.SharePlugin.getPlugin();
            if(twelvegigs.plugins.SharePlugin.plugin == null)
            {
                    return;
            }
            
            object[] val_2 = new object[4];
            val_3 = val_2.Length;
            val_2[0] = subject;
            if(emaiBody != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[1] = emaiBody;
            if(url != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[2] = url;
            if(imgPath != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[3] = imgPath;
            twelvegigs.plugins.SharePlugin.plugin.Call(methodName:  "sendEmail", args:  val_2);
        }
        private static void AndroidSendSMS(string text, string url)
        {
            int val_3;
            twelvegigs.plugins.SharePlugin.plugin = twelvegigs.plugins.SharePlugin.getPlugin();
            if(twelvegigs.plugins.SharePlugin.plugin == null)
            {
                    return;
            }
            
            object[] val_2 = new object[2];
            val_3 = val_2.Length;
            val_2[0] = text;
            if(url != null)
            {
                    val_3 = val_2.Length;
            }
            
            val_2[1] = url;
            twelvegigs.plugins.SharePlugin.plugin.Call(methodName:  "sendSMS", args:  val_2);
        }
        public SharePlugin()
        {
        
        }
    
    }

}
