using UnityEngine;
public class ChallengeFriendResultPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text text_message;
    private UnityEngine.UI.Text text_reward;
    private UnityEngine.UI.Button button_lose;
    private UnityEngine.UI.Button button_collect;
    private CoinCurrencyCollectAnimationInstantiator coinsAnim;
    private System.Action callback_window_conclusion;
    private decimal playerReward;
    
    // Methods
    private void Awake()
    {
        this.button_collect.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ChallengeFriendResultPopup::OnClick()));
        this.button_lose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void ChallengeFriendResultPopup::OnClick()));
    }
    public void Setup(decimal reward, string message, System.Action windowConclusionCallback)
    {
        var val_7;
        this.playerReward = reward;
        mem[1152921516148793456] = reward.lo;
        mem[1152921516148793460] = reward.mid;
        string val_1 = this.playerReward.ToString();
        this.callback_window_conclusion = windowConclusionCallback;
        val_7 = null;
        val_7 = null;
        bool val_2 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = reward.flags, hi = reward.hi, lo = reward.lo, mid = reward.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.button_lose.gameObject.SetActive(value:  (~val_2) & 1);
        this.button_collect.gameObject.SetActive(value:  val_2);
    }
    private void OnClick()
    {
        decimal val_10;
        var val_11;
        val_10 = this.playerReward;
        val_11 = null;
        val_11 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = val_10, hi = val_10, lo = 41971712}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            if(this.callback_window_conclusion == null)
        {
                return;
        }
        
            this.callback_window_conclusion.Invoke();
            return;
        }
        
        val_10 = 1152921504765632512;
        if(this.coinsAnim != 0)
        {
                mem2[0] = new System.Action(object:  this, method:  System.Void ChallengeFriendResultPopup::OnCoinsAnimFinished());
        }
        
        if(this.coinsAnim == 0)
        {
                return;
        }
        
        Player val_6 = App.Player;
        decimal val_7 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits, lo = 1152921504617017344}, d2:  new System.Decimal() {flags = this.playerReward, hi = this.playerReward, lo = -1342768736, mid = 268435458});
        Player val_9 = App.Player;
        this.coinsAnim.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}), toValue:  new System.Decimal() {flags = val_9._credits, hi = val_9._credits, lo = -1342768736, mid = 268435458}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void OnCoinsAnimFinished()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(this.callback_window_conclusion == null)
        {
                return;
        }
        
        this.callback_window_conclusion.Invoke();
    }
    public ChallengeFriendResultPopup()
    {
    
    }

}
