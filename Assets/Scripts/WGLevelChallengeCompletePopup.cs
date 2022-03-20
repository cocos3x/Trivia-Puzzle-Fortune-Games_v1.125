using UnityEngine;
public class WGLevelChallengeCompletePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text coinsRewardText;
    private UnityEngine.UI.Text goldenCurrencyRewardText;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.GameObject windowGroup;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private GoldenCurrencyCollectAnimationInstantiator goldenCurrencyAnimControl;
    private decimal curr_reward;
    private int curr_goldencurr_reward;
    
    // Methods
    private void Awake()
    {
        mem2[0] = new System.Action(object:  this, method:  System.Void WGLevelChallengeCompletePopup::OnGoldenCurrencyAnimFinished());
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLevelChallengeCompletePopup::OnClick_Collect()));
        this.windowGroup.SetActive(value:  false);
    }
    private void OnEnable()
    {
        this.UpdateUI();
        if(this.windowGroup == 0)
        {
                return;
        }
        
        this.windowGroup.SetActive(value:  true);
    }
    private void UpdateUI()
    {
        if(this.coinsRewardText != 0)
        {
                string val_3 = LevelChallengeHandler.Reward.ToString();
        }
        
        if(this.goldenCurrencyRewardText == 0)
        {
                return;
        }
        
        this = this.goldenCurrencyRewardText;
        string val_6 = LevelChallengeHandler.RewardGoldenCurrency.ToString();
    }
    private void OnClick_Collect()
    {
        this.collectButton.interactable = false;
        decimal val_2 = System.Decimal.op_Implicit(value:  LevelChallengeHandler.Reward);
        this.curr_reward = val_2;
        mem[1152921517901919952] = val_2.lo;
        mem[1152921517901919956] = val_2.mid;
        this.curr_goldencurr_reward = LevelChallengeHandler.RewardGoldenCurrency;
        App.Player.AddCredits(amount:  new System.Decimal() {flags = this.curr_reward, hi = this.curr_reward}, source:  "Level_Challenge", subSource:  0, externalParams:  0, doTrack:  true);
        GoldenApplesManager val_5 = MonoSingleton<GoldenApplesManager>.Instance;
        DG.Tweening.Sequence val_6 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_6, atPosition:  0f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGLevelChallengeCompletePopup::<OnClick_Collect>b__11_0()));
        DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_6, atPosition:  1.1f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGLevelChallengeCompletePopup::<OnClick_Collect>b__11_1()));
    }
    private void OnGoldenCurrencyAnimFinished()
    {
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
    }
    public WGLevelChallengeCompletePopup()
    {
    
    }
    private void <OnClick_Collect>b__11_0()
    {
        Player val_1 = App.Player;
        decimal val_2 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = this.curr_reward, hi = this.curr_reward, lo = 410560256, mid = 268435459});
        Player val_3 = App.Player;
        this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, toValue:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits}, textTickTime:  1f, delayBeforeComplete:  0.5f);
    }
    private void <OnClick_Collect>b__11_1()
    {
        Player val_1 = App.Player;
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_2._stars);
        this.goldenCurrencyAnimControl.Play(fromValue:  val_1._stars - this.curr_goldencurr_reward, toValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, textTickTime:  1f, delayBeforeComplete:  0.5f, destinationObject:  0, originObject:  0);
    }

}
