using UnityEngine;
public class TRVQuestionButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text myText;
    private string <myAnswer>k__BackingField;
    private UnityEngine.ParticleSystem questionCorrectEffect;
    private CurrencyParticles rankupEffect;
    private UnityEngine.Color defaultColor;
    private UnityEngine.Color correctColor;
    private UnityEngine.Color incorrectColor;
    private UnityEngine.UI.Image expertSprite;
    
    // Properties
    public string myAnswer { get; set; }
    
    // Methods
    public string get_myAnswer()
    {
        return (string)this.<myAnswer>k__BackingField;
    }
    private void set_myAnswer(string value)
    {
        this.<myAnswer>k__BackingField = value;
    }
    public void SetupButton(string answerToDisplay)
    {
        val_1.m_OnClick.RemoveAllListeners();
        val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionButton::OnButtonClicked()));
        this.GetComponent<UnityEngine.UI.Button>().image.color = new UnityEngine.Color() {r = this.defaultColor};
        this.<myAnswer>k__BackingField = answerToDisplay;
        UnityEngine.Color val_4 = UnityEngine.Color.white;
        this.myText.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
        if((CompanyDevices.Instance.CompanyDevice() != false) && ((CPlayerPrefs.GetBool(key:  "hackAnswer", defaultValue:  false)) != false))
        {
                TRVMainController val_8 = MonoSingleton<TRVMainController>.Instance;
            if((System.String.op_Equality(a:  this.<myAnswer>k__BackingField, b:  val_8.currentGame.currentQuestionData.<answer>k__BackingField)) != false)
        {
                UnityEngine.Color val_10 = UnityEngine.Color.green;
            this.myText.color = new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a};
        }
        
        }
        
        this.expertSprite.gameObject.SetActive(value:  false);
    }
    public void SetAnswerSelectedState(string correctAnswer, string selectedAnswer)
    {
        UnityEngine.Color val_11;
        var val_12;
        var val_13;
        var val_14;
        if((System.String.op_Inequality(a:  this.<myAnswer>k__BackingField, b:  correctAnswer)) != false)
        {
                if((System.String.op_Inequality(a:  this.<myAnswer>k__BackingField, b:  selectedAnswer)) != false)
        {
                this.SetButtonState(state:  false, immediate:  false);
            return;
        }
        
        }
        
        UnityEngine.UI.Image val_4 = this.GetComponent<UnityEngine.UI.Button>().image;
        if((System.String.op_Equality(a:  this.<myAnswer>k__BackingField, b:  correctAnswer)) == false)
        {
            goto label_4;
        }
        
        val_11 = this.correctColor;
        val_12 = 1152921517340563612;
        val_13 = 1152921517340563616;
        val_14 = 1152921517340563620;
        if(val_4 != null)
        {
            goto label_5;
        }
        
        label_4:
        val_11 = this.incorrectColor;
        val_12 = 1152921517340563628;
        val_13 = 1152921517340563632;
        val_14 = 1152921517340563636;
        label_5:
        val_4.color = new UnityEngine.Color() {r = this.incorrectColor.r, g = 3.690607E-26f, b = 3.690607E-26f, a = 3.690607E-26f};
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) == true)
        {
                return;
        }
        
        if((System.String.op_Equality(a:  selectedAnswer, b:  correctAnswer)) == false)
        {
                return;
        }
        
        if((System.String.op_Equality(a:  this.<myAnswer>k__BackingField, b:  selectedAnswer)) == false)
        {
                return;
        }
        
        UnityEngine.Vector3 val_10 = UnityEngine.Vector3.zero;
        this.rankupEffect.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, particleCount:  5, animateStatView:  true);
    }
    public void DisplayExpert(TRVExpert exp)
    {
        this.expertSprite.sprite = exp.mySprite;
        this.expertSprite.gameObject.SetActive(value:  true);
    }
    public void SetButtonState(bool state, bool immediate = False)
    {
        UnityEngine.CanvasGroup val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        float val_3 = (state != true) ? 1f : 0f;
        if(immediate != false)
        {
                val_2.alpha = val_3;
        }
        else
        {
                DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOFade(target:  val_2, endValue:  val_3, duration:  0.35f);
        }
        
        this.GetComponent<UnityEngine.UI.Button>().enabled = state;
    }
    private void OnButtonClicked()
    {
        MonoSingleton<TRVMainController>.Instance.OnAnswerClicked(selectedAnswer:  this.<myAnswer>k__BackingField);
    }
    public TRVQuestionButton()
    {
        UnityEngine.Color val_1 = new UnityEngine.Color(r:  0.968f, g:  0.364f, b:  1f);
        this.defaultColor = val_1.r;
        UnityEngine.Color val_2 = new UnityEngine.Color(r:  0.223f, g:  0.898f, b:  0.662f);
        this.correctColor = val_2.r;
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  0.997f, g:  0.285f, b:  0.462f);
        this.incorrectColor = val_3.r;
    }

}
