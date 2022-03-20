using UnityEngine;
public class WGInvitePopupButton : MyButton
{
    // Fields
    private UnityEngine.UI.Slider tierProgression;
    private UnityEngine.UI.Text invitesProgressionText;
    private UnityEngine.GameObject notificationIcon;
    private UnityEngine.GameObject completedGroup;
    
    // Methods
    protected override void Start()
    {
        this.Start();
        bool val_1 = WGInviteManager.IsEnabled;
        if(val_1 != false)
        {
                NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnInvitesReady");
            if(WGInviteManager.isV2 == false)
        {
                return;
        }
        
            this.SetupProgression();
            return;
        }
        
        val_1.gameObject.SetActive(value:  false);
    }
    private void OnInvitesReady()
    {
        if(WGInviteManager.isV2 == false)
        {
                return;
        }
        
        this.SetupProgression();
    }
    private void SetupProgression()
    {
        UnityEngine.GameObject val_20;
        object val_21;
        val_20 = this;
        WGInviteManager val_3 = MonoSingleton<WGInviteManager>.Instance;
        val_21 = MonoSingleton<WGInviteManager>.Instance.NextTargetTierInvites();
        WGInviteManager val_6 = MonoSingleton<WGInviteManager>.Instance;
        int val_7 = (MonoSingleton<WGInviteManager>.Instance.InvitesCollected) - (val_3.<LastInviteTierCollected>k__BackingField);
        int val_8 = val_21 - (val_6.<LastInviteTierCollected>k__BackingField);
        if(this.tierProgression != 0)
        {
                float val_20 = (float)val_7;
            val_20 = val_20 / (float)val_8;
        }
        
        if(this.invitesProgressionText != 0)
        {
                val_21 = val_7;
            string val_11 = System.String.Format(format:  "{0}/{1}", arg0:  val_7, arg1:  val_8);
        }
        
        if(this.notificationIcon != 0)
        {
                this.notificationIcon.SetActive(value:  MonoSingleton<WGInviteManager>.Instance.TierRewardAvailable());
        }
        
        if(this.completedGroup == 0)
        {
                return;
        }
        
        val_20 = this.completedGroup;
        val_20.SetActive(value:  MonoSingleton<WGInviteManager>.Instance.TierRewardAvailable());
    }
    private void OnDeferredReady()
    {
        this.gameObject.SetActive(value:  WGInviteManager.IsEnabled);
    }
    public override void OnButtonClick()
    {
        WGInvite val_1 = WGInviteManager.ShowInvitePopup(status:  0);
        this.OnButtonClick();
    }
    public WGInvitePopupButton()
    {
    
    }

}
