using UnityEngine;
public class WGGiftRewardPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Button closedGiftBox;
    private UnityEngine.UI.Text tapToOpen;
    private UnityEngine.GameObject rewardsGroup;
    protected GiftRewardUI giftRewardUi;
    public System.Action OnGiftBoxOpened;
    
    // Methods
    public virtual void Setup(System.Collections.Generic.List<GiftReward> rewards, GiftRewardSource rewardSource)
    {
        this.SetupUI(rewardCount:  rewards);
        goto typeof(WGGiftRewardPopup).__il2cppRuntimeField_180;
    }
    public void Setup(GiftRewardSource rewardSource)
    {
        System.Collections.Generic.List<GiftReward> val_2 = WGGiftRewardManager<WADGiftRewardManager>.Instance.GetRewards(rewardSource:  rewardSource);
        this.SetupUI(rewardCount:  rewardSource);
        goto typeof(WGGiftRewardPopup).__il2cppRuntimeField_180;
    }
    protected void SetupUI(int rewardCount)
    {
        string val_2 = System.String.Format(format:  Localization.Localize(key:  "tap_to_open_num_upper", defaultValue:  "TAP TO OPEN ({0})", useSingularKey:  false), arg0:  rewardCount);
        this.tapToOpen.gameObject.SetActive(value:  true);
        this.closedGiftBox.gameObject.SetActive(value:  true);
        this.rewardsGroup.SetActive(value:  false);
        this.closedGiftBox.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGGiftRewardPopup::OnClick_GiftBox()));
    }
    protected virtual void SetupRewards(System.Collections.Generic.List<GiftReward> rewards, GiftRewardSource rewardSource, bool postCollectLogic = False)
    {
        GiftReward val_5;
        var val_6;
        WGGiftRewardPopup val_44;
        System.Collections.Generic.List<GiftReward> val_45;
        int val_46;
        var val_47;
        var val_48;
        var val_49;
        val_44 = this;
        WGGiftRewardPopup.<>c__DisplayClass8_0 val_1 = null;
        val_46 = 0;
        val_1 = new WGGiftRewardPopup.<>c__DisplayClass8_0();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .rewards = rewards;
        .rewardSource = rewardSource;
        .<>4__this = val_44;
        .postCollectLogic = postCollectLogic;
        System.Collections.Generic.List<GiftRewardUIParams> val_3 = null;
        val_46 = public System.Void System.Collections.Generic.List<GiftRewardUIParams>::.ctor();
        val_3 = new System.Collections.Generic.List<GiftRewardUIParams>();
        val_45 = (WGGiftRewardPopup.<>c__DisplayClass8_0)[1152921517857459200].rewards;
        .rewardsUIParams = val_3;
        if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_4 = val_45.GetEnumerator();
        val_47 = 1152921517168363856;
        val_48 = 32497404;
        label_102:
        val_46 = public System.Boolean List.Enumerator<GiftReward>::MoveNext();
        bool val_7 = val_6.MoveNext();
        if(val_7 == false)
        {
            goto label_3;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_49 = null;
        val_49 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_5 + 40, hi = val_5 + 40, lo = val_5 + 40 + 8, mid = val_5 + 40 + 8}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
        {
            goto label_102;
        }
        
        GiftRewardUIParams val_9 = null;
        val_46 = 0;
        val_9 = new GiftRewardUIParams();
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        .Reward = val_5;
        if((val_5 + 16) > 5)
        {
            goto label_40;
        }
        
        var val_43 = val_48 + (val_5 + 16) << 2;
        val_43 = val_43 + val_48;
        goto (val_48 + (val_5 + 16) << 2 + val_48);
        label_40:
        val_45 = (WGGiftRewardPopup.<>c__DisplayClass8_0)[1152921517857459200].rewardsUIParams;
        if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
        val_45.Add(item:  val_9);
        goto label_102;
        label_3:
        val_6.Dispose();
        label_175:
        System.Delegate val_42 = System.Delegate.Combine(a:  this.OnGiftBoxOpened, b:  new System.Action(object:  val_1, method:  System.Void WGGiftRewardPopup.<>c__DisplayClass8_0::<SetupRewards>b__0()));
        if(val_42 != null)
        {
                val_46 = null;
            if(null != val_46)
        {
            goto label_168;
        }
        
        }
        
        this.OnGiftBoxOpened = val_42;
        return;
        label_168:
        if(val_46 != 1)
        {
            goto label_174;
        }
        
        val_6.Dispose();
        if(val_7 == false)
        {
            goto label_175;
        }
        
        throw val_7;
        label_174:
    }
    private void OnClick_GiftBox()
    {
        this.closedGiftBox.interactable = false;
        this.closedGiftBox.gameObject.SetActive(value:  false);
        this.rewardsGroup.SetActive(value:  true);
        WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
        val_2.sound.PlayGameSpecificSound(id:  "OpenGift", clipIndex:  0);
        if(this.OnGiftBoxOpened == null)
        {
                return;
        }
        
        this.OnGiftBoxOpened.Invoke();
    }
    protected virtual void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGGiftRewardPopup()
    {
    
    }

}
