using UnityEngine;
public class LightningWordsUIController : MonoSingleton<LightningWordsUIController>
{
    // Fields
    private UnityEngine.Transform mainLayout;
    private UnityEngine.Rect wordRegion;
    private UnityEngine.GameObject eventButton;
    private UnityEngine.Transform eventButtonParent;
    private UnityEngine.GameObject wordLightningEffectPrefab;
    private UnityEngine.GameObject lightningCountdownButtonPrefab;
    private UnityEngine.GameObject glowPrefab;
    private UnityEngine.Transform word;
    private System.Collections.Generic.List<UnityEngine.Transform> wordEffects;
    private LightningCountdownButton countdownButton;
    private FrameSkipper frameSkipper;
    private int countdownTimer;
    private bool pausedCountdownTimer;
    private bool isAppPaused;
    private WGLightningProgressPopup lightningStrikeFlyout;
    private bool closedPreviousFlyout;
    private UnityEngine.ParticleSystem glowEffect;
    
    // Properties
    public System.Collections.Generic.List<UnityEngine.Transform> GetWordEffectsTransform { get; }
    
    // Methods
    public System.Collections.Generic.List<UnityEngine.Transform> get_GetWordEffectsTransform()
    {
        return (System.Collections.Generic.List<UnityEngine.Transform>)this.wordEffects;
    }
    public void ApplyLightningEffects(int wordIndex)
    {
        FrameSkipper val_15;
        this.DestroyLightningEffects();
        if(wordIndex == 1)
        {
                return;
        }
        
        if(this.eventButton != 0)
        {
                this.eventButton.SetActive(value:  false);
        }
        
        WordRegion val_2 = WordRegion.instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Transform val_3 = (WordRegion.__il2cppRuntimeField_cctor_finished + (wordIndex) << 3) + 32.transform;
        this.word = val_3;
        var val_15 = 0;
        label_22:
        if(val_15 >= val_3.childCount)
        {
            goto label_13;
        }
        
        UnityEngine.Transform val_7 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.wordLightningEffectPrefab, parent:  this.word.GetChild(index:  0)).transform;
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.one;
        val_7.localScale = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
        val_7.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        this.wordEffects.Add(item:  val_7);
        val_15 = val_15 + 1;
        if(this.word != null)
        {
            goto label_22;
        }
        
        label_13:
        this.countdownButton = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.lightningCountdownButtonPrefab, parent:  this.eventButtonParent).GetComponent<LightningCountdownButton>();
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_13.updateLogic = 0;
        val_15 = this.frameSkipper;
        this.frameSkipper.updateLogic = new System.Action(object:  this, method:  System.Void LightningWordsUIController::UpdateEffects());
    }
    public void ShowFTUX()
    {
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLightningWordsFTUXFlyout>(showNext:  false).ShowFTUX(word:  this.word, firstLetter:  this.word.GetChild(index:  0), mainLayout:  this.mainLayout, wordRegion:  new UnityEngine.Rect() {m_XMin = this.wordRegion});
    }
    public void ShowLightningStrikeFlyout()
    {
        if((this.lightningStrikeFlyout != 0) && (this.closedPreviousFlyout != true))
        {
                this.lightningStrikeFlyout.ClosePopup();
            this.closedPreviousFlyout = true;
        }
        
        GameBehavior val_2 = App.getBehavior;
        this.lightningStrikeFlyout = val_2.<metaGameBehavior>k__BackingField;
        val_2.<metaGameBehavior>k__BackingField.Setup(e:  0);
    }
    public void PlayLightningSFX()
    {
        null = null;
        MonoSingleton<T>.searchedFailed + 24.PlayGameSpecificSound(id:  "LightningSoundEffect", randomIndex:  false, vol:  1f);
    }
    public void UpdateEventButton()
    {
        if(this.eventButton != 0)
        {
                this.eventButton.SetActive(value:  true);
        }
        
        this.StartProgressHighlightingAnim();
    }
    private void DestroyLightningEffects()
    {
        bool val_11 = true;
        if(val_11 >= 1)
        {
                var val_12 = 0;
            do
        {
            if(val_11 <= val_12)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_11 = val_11 + 0;
            if(((true + 0) + 32.gameObject) != 0)
        {
                if(null <= val_12)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Object.Destroy(obj:  UnityEngine.Object.__il2cppRuntimeField_byval_arg.gameObject);
        }
        
            val_12 = val_12 + 1;
        }
        while(val_12 < null);
        
            this.wordEffects = new System.Collections.Generic.List<UnityEngine.Transform>();
        }
        
        if(this.countdownButton != 0)
        {
                if(this.countdownButton.gameObject != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.countdownButton.gameObject);
            this.countdownButton = 0;
        }
        
        }
        
        if(this.lightningStrikeFlyout != 0)
        {
                if(this.closedPreviousFlyout != true)
        {
                this.lightningStrikeFlyout.ClosePopup();
            this.lightningStrikeFlyout = 0;
        }
        
            this.closedPreviousFlyout = false;
        }
        
        if(this.frameSkipper == 0)
        {
                return;
        }
        
        this.frameSkipper.updateLogic = 0;
    }
    private bool HasValidQueuedWindows()
    {
        var val_7;
        if((MonoSingleton<WGWindowManager>.Instance.HasQueuedWindows()) != false)
        {
                val_7 = (MonoSingleton<WGWindowManager>.Instance.GetWindow<WGChallengeFlyout>().isActiveAndEnabled) ^ 1;
            return (bool)val_7 & 1;
        }
        
        val_7 = 0;
        return (bool)val_7 & 1;
    }
    private void UpdateEffects()
    {
        if(LightningWordsHandler.DEFAULT_REWARD_VALUE == 0)
        {
            goto label_2;
        }
        
        if(this.isAppPaused != true)
        {
                this.HandleTimerPause(paused:  this.HasValidQueuedWindows());
        }
        
        if((LightningWordsHandler.DEFAULT_REWARD_VALUE + 40 + 64) == 0)
        {
            goto label_7;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.countdownButton)) == false)
        {
                return;
        }
        
        label_32:
        this.countdownButton.SetupCountdownText(text:  ":"(":") + this.countdownTimer.ToString(format:  "00")(this.countdownTimer.ToString(format:  "00")), size:  0);
        return;
        label_2:
        this.DestroyLightningEffects();
        return;
        label_7:
        if(((LightningWordsHandler.DEFAULT_REWARD_VALUE.GetLightningCountDown() & 2147483648) == 0) && ((LightningWordsHandler.DEFAULT_REWARD_VALUE + 32 + 31) == 0))
        {
                if(LightningWordsHandler.DEFAULT_REWARD_VALUE.InExpireInterval() == false)
        {
            goto label_19;
        }
        
        }
        
        this.DestroyLightningEffects();
        LightningWordsHandler.DEFAULT_REWARD_VALUE.ResetLightningWordJustFoundStatus();
        this = true;
        this.eventButton.SetActive(value:  true);
        return;
        label_19:
        this.eventButton.SetActive(value:  false);
        if((UnityEngine.Object.op_Implicit(exists:  this.countdownButton)) == false)
        {
                return;
        }
        
        string val_11 = ":"(":") + LightningWordsHandler.DEFAULT_REWARD_VALUE.GetLightningCountDown().ToString(format:  "00")(LightningWordsHandler.DEFAULT_REWARD_VALUE.GetLightningCountDown().ToString(format:  "00"));
        goto label_32;
    }
    private void HandleTimerPause(bool paused)
    {
        if(LightningWordsHandler.DEFAULT_REWARD_VALUE == 0)
        {
                return;
        }
        
        if(paused != false)
        {
                if(LightningWordsHandler.DEFAULT_REWARD_VALUE.GetLightningCountDown() < 1)
        {
                return;
        }
        
            LightningWordsHandler.DEFAULT_REWARD_VALUE.PauseLightningCountDownTimer();
            if(this.pausedCountdownTimer == true)
        {
                return;
        }
        
            this.pausedCountdownTimer = true;
            this.countdownTimer = LightningWordsHandler.DEFAULT_REWARD_VALUE.GetLightningCountDown();
            return;
        }
        
        this.pausedCountdownTimer = false;
        LightningWordsHandler.DEFAULT_REWARD_VALUE.ResumeLightningCountDownTimer();
    }
    private void StartProgressHighlightingAnim()
    {
        UnityEngine.ParticleSystem val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.glowPrefab, parent:  this.eventButton.transform).GetComponent<UnityEngine.ParticleSystem>();
        this.glowEffect = val_3;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
        val_3.transform.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        this.glowEffect.Play();
        MainModule val_6 = this.glowEffect.main;
        this.Invoke(methodName:  "OnProgressHighlightingAnimFinished", time:  val_6.m_ParticleSystem.duration);
    }
    private void OnProgressHighlightingAnimFinished()
    {
        if(this.glowEffect != 0)
        {
                if(this.glowEffect.gameObject != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.glowEffect.gameObject);
        }
        
        }
    
    }
    private void Start()
    {
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        UnityEngine.Rect val_4 = WordRegion.instance.getSafeAreaRect;
        this.wordRegion = val_4;
        mem[1152921517601571764] = val_4.m_YMin;
        mem[1152921517601571768] = val_4.m_Width;
        mem[1152921517601571772] = val_4.m_Height;
    }
    private void OnApplicationPause(bool pause)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        bool val_3 = pause;
        this.HandleTimerPause(paused:  val_3);
        this.isAppPaused = val_3;
    }
    private void OnApplicationFocus(bool focus)
    {
        bool val_3 = focus;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        val_3 = (~val_3) & 1;
        this.HandleTimerPause(paused:  val_3);
        this.isAppPaused = val_3;
    }
    private void OnDestroy()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        }
        
        this.HandleTimerPause(paused:  true);
    }
    public LightningWordsUIController()
    {
        UnityEngine.Rect val_1 = UnityEngine.Rect.zero;
        this.wordRegion = val_1;
        mem[1152921517602065844] = val_1.m_YMin;
        mem[1152921517602065848] = val_1.m_Width;
        mem[1152921517602065852] = val_1.m_Height;
        this.wordEffects = new System.Collections.Generic.List<UnityEngine.Transform>();
    }

}
