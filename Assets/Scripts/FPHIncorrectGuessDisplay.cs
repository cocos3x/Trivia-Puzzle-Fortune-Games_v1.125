using UnityEngine;
public class FPHIncorrectGuessDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.CanvasGroup canvasGroup;
    private UnityEngine.UI.Button buttonGuessAgain;
    private UnityEngine.UI.Button buttonRevealAnswer;
    private bool isShown;
    
    // Methods
    private void Start()
    {
        this.buttonGuessAgain.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void FPHIncorrectGuessDisplay::OnButtonGuessAgain()));
        this.buttonRevealAnswer.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void FPHIncorrectGuessDisplay::OnButtonRevealAnswer()));
        this.canvasGroup.blocksRaycasts = false;
        this.canvasGroup.interactable = false;
        this.canvasGroup.alpha = 0f;
    }
    public void Show()
    {
        if(this.isShown != false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  true);
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        this.isShown = true;
        this.canvasGroup.blocksRaycasts = true;
        this.canvasGroup.interactable = true;
        this.canvasGroup.alpha = 0f;
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  1f, duration:  0.2f);
    }
    public void Hide()
    {
        if(this.isShown == false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
        this.isShown = false;
    }
    public void OnButtonGuessAgain()
    {
        var val_10;
        int val_11;
        var val_12;
        if((MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  0, adCapExempt:  false)) == true)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        val_10 = val_3.<metaGameBehavior>k__BackingField;
        bool[] val_7 = new bool[2];
        val_7[0] = true;
        string[] val_8 = new string[2];
        val_11 = val_8.Length;
        val_8[0] = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
        val_11 = val_8.Length;
        val_8[1] = "NULL";
        val_12 = null;
        val_12 = null;
        val_10.SetupMessage(titleTxt:  Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false), shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void OnVideoResponse(Notification notif)
    {
        if((System.Boolean.Parse(value:  notif.data.ToString())) == false)
        {
                return;
        }
        
        MonoSingleton<FPHGameplayUIController>.Instance.GuessAgain();
    }
    public void OnButtonRevealAnswer()
    {
        this.Hide();
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        goto typeof(FPHGameplayController).__il2cppRuntimeField_1A0;
    }
    public FPHIncorrectGuessDisplay()
    {
    
    }

}
