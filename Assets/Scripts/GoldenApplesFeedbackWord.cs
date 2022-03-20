using UnityEngine;
public class GoldenApplesFeedbackWord : MonoSingleton<GoldenApplesFeedbackWord>
{
    // Fields
    protected UnityEngine.CanvasGroup canvasGroup;
    protected UnityEngine.UI.Text feedbackWord;
    protected TMPro.TextMeshProUGUI feedbackWord_TMPro;
    protected UnityEngine.UI.Text plusApplesText;
    protected UnityEngine.Transform particleSpawnTransform;
    protected UnityEngine.GameObject appleFeedbackGroup;
    public float FadeInDelay;
    public float FadeInTime;
    public float FadeOutDelay;
    public float FadeOutTime;
    public DG.Tweening.Ease FadeInEase;
    public DG.Tweening.Ease FadeOutEase;
    private int applesToEarn;
    protected System.Collections.Generic.Queue<string> wordQueue;
    protected System.Collections.Generic.Queue<int> applesnumQueue;
    private UnityEngine.Transform particleDestinationTransform;
    private GoldenApplesParticles appleParticle;
    private UnityEngine.GameObject appleParticleSystemPrefab;
    
    // Properties
    private WordIQFeedbackWord iqFeedbackWord { get; }
    protected virtual bool extraWordsAllowed { get; }
    public UnityEngine.GameObject AppleParticleSystemPrefab { get; }
    
    // Methods
    private WordIQFeedbackWord get_iqFeedbackWord()
    {
        return MonoSingleton<WordIQFeedbackWord>.Instance;
    }
    protected virtual bool get_extraWordsAllowed()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_B20;
    }
    public UnityEngine.GameObject get_AppleParticleSystemPrefab()
    {
        if(App.ThemesHandler == 0)
        {
                return (UnityEngine.GameObject)this.appleParticleSystemPrefab;
        }
        
        ThemesHandler val_3 = App.ThemesHandler;
        if(val_3.theme == 0)
        {
                return (UnityEngine.GameObject)this.appleParticleSystemPrefab;
        }
        
        ThemesHandler val_5 = App.ThemesHandler;
        return val_5.theme.GoldCurrencyParticleSystem;
    }
    public void OnWordStreakUpdated(bool extra)
    {
        object[] val_2 = new object[2];
        val_2[0] = extra;
        val_2[1] = WordStreak.CurrentStreak;
        UnityEngine.Debug.LogErrorFormat(format:  "onstreakUpdated-- extra: {0} streak: {1}", args:  val_2);
        bool val_4 = extra;
    }
    private void Start()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDragBegin");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFadeOutBegin");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFadeOutComplete");
        GoldenApplesStatView val_4 = UnityEngine.Object.FindObjectOfType<GoldenApplesStatView>();
        if(val_4 != 0)
        {
                this.particleDestinationTransform = val_4.AppleIcon;
        }
        
        if(this.AppleParticleSystemPrefab != 0)
        {
                this.appleParticle = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.AppleParticleSystemPrefab, parent:  this.particleSpawnTransform).GetComponent<GoldenApplesParticles>();
        }
        
        this.canvasGroup.alpha = 0f;
    }
    protected virtual void OnValidWordSubmitted(string validWord, bool isExtra)
    {
        int val_26;
        int val_27;
        var val_28;
        var val_29;
        string val_30;
        string val_31;
        int val_32;
        int val_33;
        val_26 = App.Player;
        GameEcon val_2 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_26, knobValue:  val_2.goldenAppleFtuxLevel)) != true)
        {
                if(GoldenApplesManager.GoldenAppleFtuxShow == false)
        {
                return;
        }
        
        }
        
        if(isExtra != false)
        {
                if((this & 1) == 0)
        {
                return;
        }
        
        }
        
        if((MonoSingleton<GoldenApplesManager>.Instance) == 0)
        {
                UnityEngine.Debug.LogError(message:  "GoldenApplesManager doesn\'t exist");
            return;
        }
        
        val_26 = WordStreak.CurrentStreak;
        GameBehavior val_8 = App.getBehavior;
        if((val_26 < (val_8.<metaGameBehavior>k__BackingField)) && (isExtra != true))
        {
                return;
        }
        
        if(WordStreak.CurrentStreak < 7)
        {
                val_27 = WordStreak.CurrentStreak;
        }
        else
        {
                int val_12 = WordStreak.CurrentStreak - 1;
            val_12 = val_12 - 0;
            val_27 = val_12 + 4;
        }
        
        val_28 = null;
        val_28 = null;
        if((WordStreak.streakFeedback.ContainsKey(key:  val_27)) != false)
        {
                val_29 = null;
            val_29 = null;
            val_30 = WordStreak.streakFeedback.Item[val_27];
        }
        else
        {
                val_30 = "";
        }
        
        if(isExtra != false)
        {
                val_30 = "extra_word_upper";
            val_31 = "EXTRA WORD";
        }
        else
        {
                char[] val_15 = new char[1];
            val_15[0] = '_';
            val_31 = Split(separator:  val_15)[0].ToUpper();
        }
        
        this.wordQueue.Enqueue(item:  Localization.Localize(key:  val_30, defaultValue:  val_31, useSingularKey:  false));
        if((this & 1) != 0)
        {
                val_32 = 0;
            int val_19 = WordStreak.CurrentStreak;
        }
        else
        {
                val_32 = WordStreak.CurrentStreak - 1;
        }
        
        val_33 = UnityEngine.Mathf.Min(a:  val_32, b:  10);
        if(GoldenMultiplierManager.IsAvaialable != true)
        {
                val_33 = (WGSubscriptionManager.GetAdditionalPoints(basePoints:  val_33)) + val_33;
        }
        
        this.applesnumQueue.Enqueue(item:  val_33);
    }
    protected void OnDragBegin()
    {
        if(this.canvasGroup != null)
        {
                this.canvasGroup.alpha = 0f;
            return;
        }
        
        throw new NullReferenceException();
    }
    protected void OnFadeOutBegin()
    {
        if(this.wordQueue <= 0)
        {
            goto label_2;
        }
        
        label_7:
        this.Invoke(methodName:  "FadeIn", time:  this.FadeInDelay);
        return;
        label_2:
        bool val_2 = UnityEngine.Object.op_Inequality(x:  this.iqFeedbackWord, y:  0);
        if(val_2 == false)
        {
                return;
        }
        
        if(val_2.iqFeedbackWord.WantsToShow() == true)
        {
            goto label_7;
        }
    
    }
    protected void OnFadeOutComplete()
    {
        this.Invoke(methodName:  "FadeOut", time:  this.FadeOutDelay);
    }
    protected void FadeIn()
    {
        var val_19;
        if((this.wordQueue >= 1) && (this.applesnumQueue > 0))
        {
                bool val_2 = UnityEngine.Object.op_Inequality(x:  this.iqFeedbackWord, y:  0);
            if(val_2 != false)
        {
                WordIQFeedbackWord val_3 = val_2.iqFeedbackWord;
            val_3.displayGroup.SetActive(value:  false);
        }
        
            val_19 = 1;
            this.appleFeedbackGroup.SetActive(value:  true);
        }
        else
        {
                bool val_5 = UnityEngine.Object.op_Inequality(x:  this.iqFeedbackWord, y:  0);
            if(val_5 != false)
        {
                bool val_7 = val_5.iqFeedbackWord.WantsToShow();
            if(val_7 != false)
        {
                WordIQFeedbackWord val_8 = val_7.iqFeedbackWord;
            val_8.UpdateDisplay();
            WordIQFeedbackWord val_9 = val_8.iqFeedbackWord;
            val_9.displayGroup.SetActive(value:  true);
            this.appleFeedbackGroup.SetActive(value:  false);
        }
        
        }
        
            val_19 = 0;
        }
        
        UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  0.8f, y:  0.8f, z:  1f);
        this.canvasGroup.transform.localScale = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
        UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  1f, y:  1f, z:  1f);
        DG.Tweening.Tweener val_14 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.canvasGroup.transform, endValue:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, duration:  this.FadeInTime);
        if(val_19 == 0)
        {
                return;
        }
        
        DG.Tweening.Tweener val_18 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  1f, duration:  this.FadeInTime), ease:  this.FadeInEase), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void GoldenApplesFeedbackWord::<FadeIn>b__30_0()));
    }
    protected void FadeOut()
    {
        if(this.canvasGroup.alpha == 0f)
        {
                return;
        }
        
        DG.Tweening.Tweener val_3 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  0f, duration:  this.FadeInTime), ease:  this.FadeOutEase);
    }
    protected virtual void UpdateText()
    {
        this.applesToEarn = this.applesnumQueue.Dequeue();
        bool val_3 = UnityEngine.Object.op_Implicit(exists:  this.feedbackWord);
        if((UnityEngine.Object.op_Implicit(exists:  this.feedbackWord_TMPro)) != false)
        {
                this.feedbackWord_TMPro.text = this.wordQueue.Dequeue();
        }
        
        string val_5 = "+"("+") + this.applesToEarn;
    }
    protected virtual void PlayParticles()
    {
        UnityEngine.Vector3 val_1 = this.particleDestinationTransform.position;
        this.appleParticle.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, particleCount:  this.applesToEarn, animateStatView:  true);
    }
    public GoldenApplesFeedbackWord()
    {
        this.FadeInEase = 6;
        this.FadeInDelay = ;
        this.FadeInTime = ;
        this.FadeOutDelay = 0.4f;
        this.FadeOutTime = 0.3f;
        this.wordQueue = new System.Collections.Generic.Queue<System.String>();
        this.applesnumQueue = new System.Collections.Generic.Queue<System.Int32>();
    }
    private void <FadeIn>b__30_0()
    {
        goto typeof(GoldenApplesFeedbackWord).__il2cppRuntimeField_1C0;
    }

}
