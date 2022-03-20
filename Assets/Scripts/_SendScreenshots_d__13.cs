using UnityEngine;
private sealed class AutopilotRequester.<SendScreenshots>d__13 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public twelvegigs.Autopilot.AutopilotRequester <>4__this;
    private string <actionTimestamp>5__2;
    private UnityEngine.Networking.UnityWebRequest <w>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public AutopilotRequester.<SendScreenshots>d__13(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_17;
        object val_18;
        System.Byte[] val_19;
        if((this.<>1__state) != 1)
        {
                val_17 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_17;
        }
        
            this.<>1__state = 0;
            object[] val_1 = new object[1];
            val_18 = this.<>4__this.screenshots.ToString();
            val_1[0] = val_18;
            twelvegigs.Autopilot.AutopilotTools.LogFormat(format:  "Sending {0} screenshots", args:  val_1);
            this.<>4__this.screenshotRunning = true;
        }
        else
        {
                this.<>1__state = 0;
            if((this.<w>5__3.isNetworkError) != true)
        {
                if((this.<w>5__3.isHttpError) == false)
        {
            goto label_13;
        }
        
        }
        
            object[] val_5 = new object[2];
            val_5[0] = this.<actionTimestamp>5__2;
            val_18 = this.<w>5__3.error;
            val_5[1] = val_18;
            twelvegigs.Autopilot.AutopilotTools.LogErrorFormat(format:  "Error on uploading screenshot: {0}, error: {1}", args:  val_5);
            if((this.<>4__this) == null)
        {
                label_13:
            twelvegigs.Autopilot.AutopilotTools.Log(message:  "Form upload complete!");
        }
        
            this.<>4__this.screenshots.RemoveAt(index:  0);
            this.<actionTimestamp>5__2 = 0;
            this.<w>5__3 = 0;
        }
        
        if(W9 <= 0)
        {
            goto label_27;
        }
        
        this.<actionTimestamp>5__2 = Item["actionTimestamp"];
        UnityEngine.WWWForm val_10 = null;
        val_18 = val_10;
        val_10 = new UnityEngine.WWWForm();
        val_10.AddField(fieldName:  "actionTimestamp", value:  this.<actionTimestamp>5__2);
        val_10.AddField(fieldName:  "startTime", value:  this.<>4__this.startSession.ToString());
        val_10.AddField(fieldName:  "uniqueTag", value:  Item["uniqueTag"]);
        val_10.AddField(fieldName:  "game", value:  Item["game"]);
        val_10.AddField(fieldName:  "valid", value:  "12g");
        if(Item["file"] == null)
        {
            goto label_33;
        }
        
        val_19 = X0;
        if(X0 == true)
        {
            goto label_34;
        }
        
        label_27:
        val_17 = 0;
        this.<>4__this.screenshotRunning = false;
        return (bool)val_17;
        label_33:
        val_19 = 0;
        label_34:
        val_10.AddBinaryData(fieldName:  "fileUpload", contents:  val_19, fileName:  this.<actionTimestamp>5__2(this.<actionTimestamp>5__2) + ".png", mimeType:  "image/png");
        UnityEngine.Networking.UnityWebRequest val_14 = UnityEngine.Networking.UnityWebRequest.Post(uri:  this.<>4__this.screenshotServerUrl, formData:  val_10);
        this.<w>5__3 = val_14;
        twelvegigs.Autopilot.AcceptAllCertificatesSignedWithASpecificKeyPublicKey val_15 = null;
        val_18 = val_15;
        val_15 = new twelvegigs.Autopilot.AcceptAllCertificatesSignedWithASpecificKeyPublicKey();
        val_14.certificateHandler = val_15;
        this.<>2__current = this.<w>5__3.SendWebRequest();
        val_17 = 1;
        this.<>1__state = val_17;
        return (bool)val_17;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
