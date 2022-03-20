using UnityEngine;
public class FPHLevelFailDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.CanvasGroup canvasGroup;
    private UnityEngine.UI.Text starsEarnedLabel;
    private UnityEngine.UI.Button buttonQuit;
    private UnityEngine.UI.Button buttonPlayAgain;
    
    // Properties
    private int entryCost { get; }
    
    // Methods
    private int get_entryCost()
    {
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        return (int)val_1.levelEntryFee;
    }
    private void Start()
    {
        this.buttonQuit.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void FPHLevelFailDisplay::OnButtonQuit()));
        this.buttonPlayAgain.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void FPHLevelFailDisplay::OnButtonPlayAgain()));
        this.Hide();
    }
    public void Show()
    {
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        string val_2 = System.String.Format(format:  "+ {0}", arg0:  val_1.currentGame.starsEarned);
        this.gameObject.SetActive(value:  true);
        this.canvasGroup.blocksRaycasts = true;
        this.canvasGroup.interactable = true;
        this.canvasGroup.alpha = 0f;
        DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  1f, duration:  0.2f);
    }
    public void Hide()
    {
        this.canvasGroup.blocksRaycasts = false;
        this.canvasGroup.interactable = false;
        this.canvasGroup.alpha = 0f;
        this.gameObject.SetActive(value:  false);
    }
    public void OnButtonQuit()
    {
        bool val_2 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        GameBehavior val_3 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public void OnButtonPlayAgain()
    {
        decimal val_3 = System.Decimal.op_Implicit(value:  App.Player.entryCost);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid})) == false)
        {
                return;
        }
        
        this.canvasGroup.interactable = false;
        this.canvasGroup.blocksRaycasts = false;
    }
    public FPHLevelFailDisplay()
    {
    
    }

}
