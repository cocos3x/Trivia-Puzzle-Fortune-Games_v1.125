using UnityEngine;
public class WGExtraWordsPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Button button_info;
    protected UnityEngine.UI.Button button_close;
    protected UnityEngine.UI.Text rewardAmount;
    protected UnityEngine.UI.Button button_collect;
    protected GridCoinCollectAnimationInstantiator coinsAnim;
    protected ExtraProgress progress;
    protected UnityEngine.UI.Text text_progress;
    protected UnityEngine.GameObject[] collectable_objects;
    protected UnityEngine.GameObject[] uncollectable_objects;
    protected UnityEngine.GameObject idleAnimation;
    protected UnityEngine.GameObject collectAnimation;
    protected decimal curr_reward;
    
    // Methods
    private void Awake()
    {
        this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGExtraWordsPopup::OnCoinsAnimFinished());
        this.button_collect.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGExtraWordsPopup).__il2cppRuntimeField_188));
        this.button_info.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGExtraWordsPopup::OnClick_Info()));
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGExtraWordsPopup::OnClick_Close()));
    }
    public void OnEnable()
    {
        goto typeof(WGExtraWordsPopup).__il2cppRuntimeField_170;
    }
    protected virtual void UpdateUI()
    {
        var val_15;
        GameEcon val_1 = App.getGameEcon;
        this.curr_reward = val_1.ExtraWordsReward.flags;
        this.button_collect.interactable = true;
        GameEcon val_2 = App.getGameEcon;
        string val_3 = this.curr_reward.ToString(format:  val_2.numberFormatInt);
        this.progress.target = (float)App.getGameEcon.ExtraWordsTarget;
        this.progress.current = (float)Prefs.extraProgress;
        string val_7 = this.progress._current + "/"("/") + this.progress.target;
        var val_16 = 0;
        label_18:
        if(val_16 >= this.collectable_objects.Length)
        {
            goto label_15;
        }
        
        this.collectable_objects[val_16].SetActive(value:  (this.progress._current >= this.progress.target) ? 1 : 0);
        val_16 = val_16 + 1;
        if(this.collectable_objects != null)
        {
            goto label_18;
        }
        
        label_15:
        val_15 = 0;
        label_24:
        if(val_15 >= this.uncollectable_objects.Length)
        {
            goto label_21;
        }
        
        this.uncollectable_objects[val_15].SetActive(value:  (this.progress._current < this.progress.target) ? 1 : 0);
        val_15 = val_15 + 1;
        if(this.uncollectable_objects != null)
        {
            goto label_24;
        }
        
        label_21:
        if(this.button_collect.gameObject.activeSelf != false)
        {
                val_15 = 1152921504765632512;
            if((UnityEngine.Object.op_Implicit(exists:  this.idleAnimation)) != false)
        {
                this.idleAnimation.GetComponent<UnityEngine.CanvasGroup>().alpha = 0f;
        }
        
            if((UnityEngine.Object.op_Implicit(exists:  this.collectAnimation)) == false)
        {
                return;
        }
        
            this.collectAnimation.SetActive(value:  true);
            return;
        }
        
        this.StopExtraAnimation();
        this.ShowIdleAnimation();
    }
    public virtual void OnClick_Collect()
    {
        this.button_collect.interactable = false;
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = this.curr_reward, hi = this.curr_reward}, source:  "Extra Words", externalParams:  0, animated:  false);
        MainController.instance.UpdateExtraWordProgress();
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = this.curr_reward, hi = this.curr_reward, lo = 344867040, mid = 268435459});
        Player val_4 = App.Player;
        this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, toValue:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    public void OnClick_Info()
    {
        var val_5;
        System.Action val_7;
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGExtraWordsInfoPopup>(showNext:  false);
        val_5 = null;
        val_5 = null;
        val_7 = WGExtraWordsPopup.<>c.<>9__16_0;
        if(val_7 == null)
        {
                System.Action val_3 = null;
            val_7 = val_3;
            val_3 = new System.Action(object:  WGExtraWordsPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGExtraWordsPopup.<>c::<OnClick_Info>b__16_0());
            WGExtraWordsPopup.<>c.<>9__16_0 = val_7;
        }
        
        mem2[0] = val_7;
        this.gameObject.SetActive(value:  false);
    }
    public void OnClick_Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnCoinsAnimFinished()
    {
        goto typeof(WGExtraWordsPopup).__il2cppRuntimeField_170;
    }
    private void StopExtraAnimation()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.collectAnimation)) == false)
        {
                return;
        }
        
        this.collectAnimation.transform.Find(n:  "Spine GameObject (skeleton)").GetComponent<ExtraWordsAnimationControl>().StopAnimation();
    }
    private void ShowIdleAnimation()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.idleAnimation)) == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.showAnima(cg:  this.idleAnimation.transform.GetComponent<UnityEngine.CanvasGroup>()));
    }
    private System.Collections.IEnumerator showAnima(UnityEngine.CanvasGroup cg)
    {
        .cg = cg;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGExtraWordsPopup.<showAnima>d__21(<>1__state:  0);
    }
    public WGExtraWordsPopup()
    {
    
    }

}
