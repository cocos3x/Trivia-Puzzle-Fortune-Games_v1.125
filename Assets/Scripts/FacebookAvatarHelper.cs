using UnityEngine;
public class FacebookAvatarHelper
{
    // Fields
    protected static System.Collections.Generic.Dictionary<string, twelvegigs.net.ImageRequest> imageRequestsByFbid;
    
    // Methods
    public static void RequestProfilePic(string fbid, System.Action<string, UnityEngine.Texture2D> successCallback, System.Action failureCallback)
    {
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        var val_12;
        string val_2 = "fbavatar_" + fbid;
        val_8 = null;
        val_8 = null;
        if((FacebookAvatarHelper.imageRequestsByFbid.ContainsKey(key:  fbid)) != false)
        {
                val_9 = null;
            val_9 = null;
            twelvegigs.net.ImageRequest val_4 = FacebookAvatarHelper.imageRequestsByFbid.Item[fbid];
            if(FacebookAvatarHelper.imageRequestsByFbid != null)
        {
                val_10 = null;
            val_10 = null;
            twelvegigs.net.ImageRequest val_5 = FacebookAvatarHelper.imageRequestsByFbid.Item[fbid];
            successCallback.Invoke(arg1:  val_2, arg2:  val_5.imageTexture);
            return;
        }
        
        }
        
        val_11 = null;
        val_11 = null;
        if((FacebookAvatarHelper.imageRequestsByFbid.ContainsKey(key:  fbid)) != false)
        {
                return;
        }
        
        val_12 = null;
        val_12 = null;
        FacebookAvatarHelper.imageRequestsByFbid.Add(key:  fbid, value:  new twelvegigs.net.ImageRequest(url:  "https://graph.facebook.com/"("https://graph.facebook.com/") + fbid + "/picture?width=256&height=256"("/picture?width=256&height=256"), filename:  val_2, imgComplete:  successCallback, imgError:  failureCallback, showErrors:  false, destroy:  false, cached:  true, save:  false));
    }
    public FacebookAvatarHelper()
    {
    
    }
    private static FacebookAvatarHelper()
    {
        FacebookAvatarHelper.imageRequestsByFbid = new System.Collections.Generic.Dictionary<System.String, twelvegigs.net.ImageRequest>();
    }

}
