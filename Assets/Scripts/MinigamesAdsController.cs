using UnityEngine;
public class MinigamesAdsController : MonoSingleton<MinigamesAdsController>
{
    // Methods
    public override void InitMonoSingleton()
    {
        ApplovinMaxPlugin val_1 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        val_1.IncentivizedVideoCallback = new System.Action<System.Boolean>(object:  this, method:  public System.Void MinigamesAdsController::OnVideoAdWatched(bool success));
    }
    public bool ShowIncentivizedVideo(HeyZapAdTag heyZapAdTag)
    {
        return MonoSingleton<ApplovinMaxPlugin>.Instance.ShowVideo(heyZapAdTag:  heyZapAdTag);
    }
    public void OnVideoAdWatched(bool success)
    {
        if(success != false)
        {
                MonoSingleton<SLC.Minigames.MinigameManager>.Instance.AdWatched();
        }
        
        bool val_2 = success;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnVideoResponse", aData:  new System.Collections.Hashtable());
    }
    public MinigamesAdsController()
    {
    
    }

}
