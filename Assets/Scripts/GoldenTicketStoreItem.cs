using UnityEngine;
public class GoldenTicketStoreItem : WGStoreItem
{
    // Fields
    private UnityEngine.UI.Text coinsPerDayText;
    private UnityEngine.UI.Text applesText;
    private UGUINetworkedButton itemButton;
    private WGSubscriptionButton subButtonComponent;
    private SubscriptionHandler.SubScriptionType subPackage;
    
    // Methods
    private void OnEnable()
    {
        GameEcon val_4 = App.getGameEcon;
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "x_coins_per_day", defaultValue:  "{0}/Day", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  this.subPackage).ToString(format:  val_4.numberFormatInt));
        if(this.applesText != 0)
        {
                string val_11 = System.String.Format(format:  Localization.Localize(key:  "x_all_upper", defaultValue:  "{0}X ALL", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.pointMultiplier);
        }
        
        this.itemButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void GoldenTicketStoreItem::ClickSubButton(bool result));
    }
    public override void Awake()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Combine(a:  GameStoreUI.OnRefreshDisplay, b:  new System.Action(object:  this, method:  System.Void GoldenTicketStoreItem::OnStoreRefreshDisplay()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        GameStoreUI.OnRefreshDisplay = val_2;
        return;
        label_4:
    }
    private void OnStoreRefreshDisplay()
    {
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        SubscriptionHandler.SubScriptionType val_23;
        val_19 = 1152921504884269056;
        val_20 = null;
        val_20 = null;
        if(App.game == 17)
        {
            goto label_6;
        }
        
        val_21 = null;
        val_21 = null;
        if(App.game != 19)
        {
            goto label_12;
        }
        
        label_6:
        val_22 = 1152921504893161472;
        val_19 = 1152921504765632512;
        if((((MonoSingleton<WGSubscriptionManager>.Instance) == 0) || (this.gameObject == 0)) || ((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  1)) == true))
        {
            goto label_50;
        }
        
        label_52:
        if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0)) == true)
        {
            goto label_50;
        }
        
        return;
        label_12:
        val_22 = 1152921504893161472;
        if(((MonoSingleton<WGSubscriptionManager>.Instance) == 0) || (this.gameObject == 0))
        {
            goto label_50;
        }
        
        GameBehavior val_13 = App.getBehavior;
        if(((val_13.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_50;
        }
        
        val_23 = this.subPackage;
        if(val_23 != 1)
        {
            goto label_42;
        }
        
        if(((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  1)) == true) || ((MonoSingleton<WGSubscriptionManager>.Instance.silverTicketUnlocked) == false))
        {
            goto label_50;
        }
        
        val_23 = this.subPackage;
        label_42:
        if(val_23 != 0)
        {
                return;
        }
        
        goto label_52;
        label_50:
        this.gameObject.SetActive(value:  false);
    }
    private void ClickSubButton(bool result = False)
    {
        if(this.gameObject == 0)
        {
                return;
        }
        
        this.subButtonComponent.onClickButton(result:  result);
    }
    private void OnDisable()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  GameStoreUI.OnRefreshDisplay, value:  new System.Action(object:  this, method:  System.Void GoldenTicketStoreItem::OnStoreRefreshDisplay()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        GameStoreUI.OnRefreshDisplay = val_2;
        this.itemButton.OnConnectionClick = 0;
        return;
        label_4:
    }
    public GoldenTicketStoreItem()
    {
    
    }

}
