using UnityEngine;
public class ForestFrenzyForestCompleteRewardPopup : MonoBehaviour
{
    // Fields
    private CoinCurrencyCollectAnimationInstantiator coins_anim;
    private UnityEngine.UI.Text text_reward_amount;
    private int fromValue;
    
    // Methods
    private void Awake()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  41963520, b:  new System.Action(object:  this, method:  System.Void ForestFrenzyForestCompleteRewardPopup::Init()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        mem2[0] = val_2;
        return;
        label_3:
    }
    private void Init()
    {
        null = null;
        string val_1 = ToString();
        Player val_2 = App.Player;
        int val_5 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = this.text_reward_amount, mid = this.text_reward_amount})) - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = ForestFrenzyEcon.ForestCompleteReward, hi = ForestFrenzyEcon.ForestCompleteReward, lo = ForestFrenzyEcon.UnlockLevel.__il2cppRuntimeField_14>>0&0xFFFFFFFF, mid = ForestFrenzyEcon.UnlockLevel.__il2cppRuntimeField_14>>32&0x0}));
        this.fromValue = val_5;
        this.coins_anim.SetStatViewValue(instantValue:  val_5);
        mem2[0] = new System.Action(object:  this, method:  System.Void ForestFrenzyForestCompleteRewardPopup::OnCoinsComplete());
        UnityEngine.Coroutine val_8 = this.StartCoroutine(routine:  this.AnimateReward());
    }
    private System.Collections.IEnumerator AnimateReward()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new ForestFrenzyForestCompleteRewardPopup.<AnimateReward>d__5();
    }
    private void OnCoinsComplete()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public ForestFrenzyForestCompleteRewardPopup()
    {
    
    }

}
