using UnityEngine;
public class TextPreview : MonoBehaviour
{
    // Fields
    public const string ON_DRAG_BEGIN = "OnDragBegin";
    public const string ON_FADE_OUT_BEGIN = "OnFadeOutBegin";
    public const string ON_FADE_OUT_COMPLETE = "OnFadeOutComplete";
    public const string ON_FADE_IN_BEGIN = "OnFadeInBegin";
    public UnityEngine.GameObject content;
    public UnityEngine.RectTransform backgroundRT;
    public UnityEngine.RectTransform textRT;
    public float extraBackgroundWidth;
    public System.Collections.Generic.List<string> tileStrings;
    public UnityEngine.UI.Text text;
    private bool useColors;
    private UnityEngine.Color answerColor;
    private UnityEngine.Color validColor;
    private UnityEngine.Color wrongColor;
    private UnityEngine.Color existColor;
    private UnityEngine.Color defaultColor;
    private bool useSprites;
    private UnityEngine.Sprite answerSprite;
    private UnityEngine.Sprite validSprite;
    private UnityEngine.Sprite wrongSprite;
    private UnityEngine.Sprite existSprite;
    private UnityEngine.Sprite defaultSprite;
    private UnityEngine.GameObject submitButton;
    private UnityEngine.GameObject denyButton;
    public static TextPreview instance;
    private UnityEngine.CanvasGroup canvasGroup;
    private UnityEngine.UI.Image backgroundImage;
    private bool isFading;
    
    // Methods
    private void Awake()
    {
        TextPreview.instance = this;
        this.canvasGroup = this.content.GetComponent<UnityEngine.CanvasGroup>();
        this.backgroundImage = this.backgroundRT.GetComponent<UnityEngine.UI.Image>();
        if(this.submitButton != 0)
        {
                UnityEngine.UI.Button val_4 = this.submitButton.GetComponent<UnityEngine.UI.Button>();
            val_4.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TextPreview::OnClick_SubmitButton()));
        }
        
        if(this.denyButton == 0)
        {
                return;
        }
        
        UnityEngine.UI.Button val_7 = this.denyButton.GetComponent<UnityEngine.UI.Button>();
        val_7.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TextPreview::OnClick_DenyButton()));
    }
    private void OnClick_SubmitButton()
    {
        if(LineDrawer.instance == 0)
        {
                return;
        }
        
        if(this.IsInvisibleOrFading() != false)
        {
                return;
        }
        
        LineDrawer.instance.EndDrag(checkAnswer:  true);
    }
    private void OnClick_DenyButton()
    {
        if(LineDrawer.instance == 0)
        {
                return;
        }
        
        if(this.IsInvisibleOrFading() != false)
        {
                return;
        }
        
        LineDrawer.instance.EndDrag(checkAnswer:  false);
    }
    private void Start()
    {
        this.canvasGroup.alpha = 0f;
        this.canvasGroup.blocksRaycasts = false;
        MainController val_1 = MainController.instance;
        val_1.onBeforeLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TextPreview::OnLevelComplete()));
    }
    public void SetIndexes(System.Collections.Generic.List<int> indexes)
    {
        var val_3;
        float val_4;
        string val_12;
        var val_13;
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        List.Enumerator<T> val_2 = indexes.GetEnumerator();
        var val_12 = val_3;
        label_7:
        val_12 = public System.Boolean List.Enumerator<System.Int32>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(this.tileStrings == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_12 <= val_12)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_12 = val_12 + ((val_3) << 3);
        val_13 = mem[(val_3 + (val_3) << 3) + 32];
        val_13 = (val_3 + (val_3) << 3) + 32;
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_12 = val_13.ToUpper();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_7 = val_1.Append(value:  val_12);
        goto label_7;
        label_2:
        val_4.Dispose();
        UnityEngine.UI.Text val_8 = this.textRT.GetComponent<UnityEngine.UI.Text>();
        UnityEngine.Vector2 val_9 = this.backgroundRT.sizeDelta;
        val_4 = 0;
        UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  val_4 + this.extraBackgroundWidth, y:  val_9.y);
        this.backgroundRT.sizeDelta = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
    }
    public void SetActive(bool isActive, bool useButtons = False)
    {
        var val_8;
        if(isActive == false)
        {
            goto label_1;
        }
        
        var val_1 = (null > 0) ? 1 : 0;
        if(this.content != null)
        {
            goto label_4;
        }
        
        label_1:
        val_8 = 0;
        label_4:
        this.content.SetActive(value:  false);
        if(this.submitButton != 0)
        {
                this.submitButton.SetActive(value:  isActive & useButtons);
        }
        
        if(this.denyButton == 0)
        {
                return;
        }
        
        this.denyButton.SetActive(value:  isActive & useButtons);
    }
    public void ClearText()
    {
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void SetText(string textStr)
    {
        if(this.text != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public string GetText()
    {
        if(this.text != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public void SetAnswerColor()
    {
        if(this.useColors != false)
        {
                this.backgroundImage.color = new UnityEngine.Color() {r = this.answerColor};
        }
        
        if(this.useSprites == false)
        {
                return;
        }
        
        this.backgroundImage.sprite = this.answerSprite;
    }
    public void SetValidColor()
    {
        if(this.useColors != false)
        {
                this.backgroundImage.color = new UnityEngine.Color() {r = this.validColor};
        }
        
        if(this.useSprites == false)
        {
                return;
        }
        
        this.backgroundImage.sprite = this.validSprite;
    }
    public void SetWrongColor()
    {
        if(this.useColors != false)
        {
                this.backgroundImage.color = new UnityEngine.Color() {r = this.wrongColor};
        }
        
        if(this.useSprites == false)
        {
                return;
        }
        
        this.backgroundImage.sprite = this.wrongSprite;
    }
    public void SetDefaultColor()
    {
        if(this.useColors != false)
        {
                this.backgroundImage.color = new UnityEngine.Color() {r = this.defaultColor};
        }
        
        if(this.useSprites == false)
        {
                return;
        }
        
        this.backgroundImage.sprite = this.defaultSprite;
    }
    public void SetExistColor()
    {
        if(this.useColors != false)
        {
                this.backgroundImage.color = new UnityEngine.Color() {r = this.existColor};
        }
        
        if(this.useSprites == false)
        {
                return;
        }
        
        this.backgroundImage.sprite = this.existSprite;
    }
    public void FadeOut()
    {
        if(this.canvasGroup.alpha == 0f)
        {
                NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnFadeOutBegin");
            NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnFadeOutComplete");
            return;
        }
        
        this.isFading = true;
        this.canvasGroup.blocksRaycasts = false;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnFadeOutBegin");
        var val_6 = (WordStreak.CurrentStreak > 1) ? 1 : 0;
        DG.Tweening.Tweener val_10 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  0f, duration:  32561584 + val_5 > 1 ? 1 : 0), delay:  0.1f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void TextPreview::<FadeOut>b__42_0()));
    }
    public void FadeIn()
    {
        this.isFading = false;
        int val_1 = DG.Tweening.DOTween.Kill(targetOrId:  this.canvasGroup, complete:  false);
        this.SetDefaultColor();
        this.canvasGroup.alpha = 1f;
        this.canvasGroup.blocksRaycasts = true;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnFadeInBegin");
    }
    public bool IsInvisibleOrFading()
    {
        var val_3;
        if(this.canvasGroup.alpha != 0f)
        {
                var val_2 = (this.isFading == true) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 1;
        return (bool)val_3;
    }
    private void OnLevelComplete()
    {
        this.SetActive(isActive:  false, useButtons:  false);
    }
    public TextPreview()
    {
        this.extraBackgroundWidth = 50f;
        this.tileStrings = new System.Collections.Generic.List<System.String>();
    }
    private void <FadeOut>b__42_0()
    {
        this.isFading = false;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnFadeOutComplete");
        this.ClearText();
    }

}
