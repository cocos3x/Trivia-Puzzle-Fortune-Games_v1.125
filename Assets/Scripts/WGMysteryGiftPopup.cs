using UnityEngine;
public class WGMysteryGiftPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Button collectButton;
    protected UnityEngine.UI.Text coinAmountText;
    protected GridCoinCollectAnimationInstantiator coinsAnim;
    
    // Methods
    protected virtual void Awake()
    {
        this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  typeof(WGMysteryGiftPopup).__il2cppRuntimeField_1B8);
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGMysteryGiftPopup).__il2cppRuntimeField_198));
    }
    protected virtual void OnEnable()
    {
        UnityEngine.Debug.LogError(message:  "Override me, I am virtual");
        GameEcon val_1 = App.getGameEcon;
        string val_2 = val_1.mysteryGiftReward.ToString();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    protected virtual void OnCollect()
    {
        UnityEngine.Debug.LogError(message:  "Override me, I am virtual");
        GameEcon val_2 = App.getGameEcon;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_2.mysteryGiftReward);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, source:  "Mystery Gift", subSource:  0, externalParams:  0, doTrack:  true);
        Player val_4 = App.Player;
        val_4.properties.MysteryGiftReceived = true;
        Player val_5 = App.Player;
        val_5.properties.Save(writePrefs:  true);
        this.Invoke(methodName:  "PlayCoinsAnim", time:  1.5f);
    }
    protected virtual void PlayCoinsAnim()
    {
        Player val_1 = App.Player;
        GameEcon val_2 = App.getGameEcon;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_2.mysteryGiftReward);
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        Player val_5 = App.Player;
        this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    protected virtual void OnCoinsAnimFinished()
    {
        CurrencyController.HandleBalanceChanged(type:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGMysteryGiftPopup()
    {
    
    }

}
