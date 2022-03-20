using UnityEngine;
public class ForestMasterRewardPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text coinsRewardText;
    private UnityEngine.UI.Text acornsRewardText;
    private UnityEngine.UI.Button collectButton;
    private GridCoinCollectAnimationInstantiator coinsAnim;
    private GoldenCurrencyCollectAnimationInstantiator acornsAnim;
    
    // Methods
    private void Start()
    {
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ForestMasterRewardPopup::OnCollectClicked()));
        decimal val_2 = ForestMasterEventHandler.<Instance>k__BackingField.GetCoinReward(showCurrentLevel:  false);
        GameEcon val_3 = App.getGameEcon;
        string val_4 = val_2.flags.ToString(format:  val_3.numberFormatInt);
        GameEcon val_6 = App.getGameEcon;
        string val_7 = ForestMasterEventHandler.<Instance>k__BackingField.GetAcornReward(showCurrentLevel:  false).ToString(format:  val_6.numberFormatInt);
    }
    private void OnCollectClicked()
    {
        this.collectButton.interactable = false;
        decimal val_1 = ForestMasterEventHandler.<Instance>k__BackingField.GetCoinReward(showCurrentLevel:  false);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, source:  "Forest Master Reward", subSource:  0, externalParams:  0, doTrack:  true);
        GoldenApplesManager val_4 = MonoSingleton<GoldenApplesManager>.Instance;
        Player val_5 = App.Player;
        decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = X24, mid = X24}, d2:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
        Player val_7 = App.Player;
        this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, toValue:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        Player val_8 = App.Player;
        Player val_9 = App.Player;
        decimal val_10 = System.Decimal.op_Implicit(value:  val_9._stars);
        this.acornsAnim.Play(fromValue:  val_8._stars - (ForestMasterEventHandler.<Instance>k__BackingField.GetAcornReward(showCurrentLevel:  false)), toValue:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        System.Delegate val_13 = System.Delegate.Combine(a:  this.coinsAnim.OnCompleteCallback, b:  new System.Action(object:  this, method:  System.Void ForestMasterRewardPopup::Close()));
        if(val_13 != null)
        {
                if(null != null)
        {
            goto label_22;
        }
        
        }
        
        this.coinsAnim.OnCompleteCallback = val_13;
        return;
        label_22:
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if((ForestMasterEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(((ForestMasterEventHandler.<Instance>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnGameEventHandlerProgress");
    }
    public ForestMasterRewardPopup()
    {
    
    }

}
