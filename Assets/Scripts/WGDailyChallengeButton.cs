using UnityEngine;
public class WGDailyChallengeButton : MonoBehaviour
{
    // Fields
    private UGUINetworkedButton Button_DailyChallenge;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.UI.Image iconImage;
    private UnityEngine.GameObject checkMark;
    private UnityEngine.Sprite sunIcon;
    private UnityEngine.Sprite moonIcon;
    private const string DAILY_CHALLENGE = "DAILY CHALLENGE";
    private bool inRequest;
    
    // Methods
    private void Awake()
    {
        System.Action<SceneType> val_13;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDailyChallengeDataUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        this.Button_DailyChallenge.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyChallengeButton::<Awake>b__8_0(bool success));
        string val_4 = Localization.Localize(key:  "daily_challenge_upper", defaultValue:  "DAILY CHALLENGE", useSingularKey:  false);
        val_13 = 1152921504893267968;
        if((MonoSingletonSelfGenerating<SceneDictator>.Instance) != 0)
        {
                SceneDictator val_7 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            val_13 = val_7.OnSceneLoaded;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_13, b:  new System.Action<SceneType>(object:  this, method:  System.Void WGDailyChallengeButton::OnSceneLoaded(SceneType scene)));
            if(val_9 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
            val_7.OnSceneLoaded = val_9;
        }
        
        if(this.iconImage != 0)
        {
                this.iconImage.gameObject.SetActive(value:  false);
        }
        
        if(this.checkMark == 0)
        {
                return;
        }
        
        this.checkMark.SetActive(value:  false);
        return;
        label_16:
    }
    private void OnEnable()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateState());
    }
    private System.Collections.IEnumerator UpdateState()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyChallengeButton.<UpdateState>d__10();
    }
    private void OnDestroy()
    {
        System.Delegate val_11;
        if(UnityEngine.Application.isPlaying == false)
        {
                return;
        }
        
        if((MonoSingletonSelfGenerating<SceneDictator>.InstanceExists) != false)
        {
                SceneDictator val_3 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void WGDailyChallengeButton::OnSceneLoaded(SceneType scene)));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
            val_3.OnSceneLoaded = val_5;
        }
        
        val_11 = 1152921504893161472;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return;
        }
        
        WGDailyChallengeManager val_8 = MonoSingleton<WGDailyChallengeManager>.Instance;
        System.Action<System.Boolean> val_9 = null;
        val_11 = val_9;
        val_9 = new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyChallengeButton::OnComplete(bool success));
        if((System.Delegate.op_Equality(d1:  val_8.currentRequestCallback, d2:  val_9)) == false)
        {
                return;
        }
        
        val_8.currentRequestCallback = 0;
        return;
        label_9:
    }
    private void OnSceneLoaded(SceneType scene)
    {
        if(scene != 1)
        {
                return;
        }
        
        if(this.gameObject.activeSelf == false)
        {
                return;
        }
        
        this.UpdateButtonState();
    }
    private void OnClick_DailyChallenge()
    {
        if(this.inRequest != false)
        {
                return;
        }
        
        this.inRequest = true;
        this.Button_DailyChallenge.WaitingStatus(waiting:  true);
        val_1.currentRequestCallback = new System.Action<System.Boolean>(object:  this, method:  System.Void WGDailyChallengeButton::OnComplete(bool success));
        MonoSingleton<WGDailyChallengeManager>.Instance.DoRequest();
    }
    private void OnComplete(bool success)
    {
        var val_5;
        var val_6;
        FeatureAccessPoints val_7;
        val_5 = this;
        this.inRequest = false;
        this.Button_DailyChallenge.WaitingStatus(waiting:  false);
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false)
        {
            goto label_2;
        }
        
        val_5 = 1152921504887996416;
        val_6 = null;
        val_6 = null;
        val_7 = 5;
        goto label_8;
        label_2:
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
            goto label_9;
        }
        
        val_5 = 1152921504887996416;
        val_6 = null;
        val_6 = null;
        val_7 = 8;
        label_8:
        AmplitudePluginHelper.lastFeatureAccessPoint = val_7;
        label_9:
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeV2Popup>(showNext:  false);
    }
    private void OnDailyChallengeDataUpdate()
    {
        this.UpdateButtonState();
    }
    private void UpdateButtonState()
    {
        if((((MonoSingleton<WGDailyChallengeManager>.Instance) == 0) || ((MonoSingleton<WGDailyChallengeManager>.Instance.FeatureAvailable) == false)) || ((MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLanguageSupported()) == false))
        {
            goto label_13;
        }
        
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() == false)
        {
            goto label_14;
        }
        
        this.iconImage.sprite = this.sunIcon;
        this.iconImage.gameObject.SetActive(value:  true);
        WGDailyChallengeManager val_9 = MonoSingleton<WGDailyChallengeManager>.Instance;
        label_35:
        this.checkMark.SetActive(value:  val_9.todaysProgress.morningChallenge.done);
        goto label_27;
        label_13:
        this.Button_DailyChallenge.gameObject.SetActive(value:  false);
        return;
        label_14:
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
            goto label_27;
        }
        
        this.iconImage.sprite = this.moonIcon;
        this.iconImage.gameObject.SetActive(value:  true);
        WGDailyChallengeManager val_13 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_13.todaysProgress.eveningChallenge != null)
        {
            goto label_35;
        }
        
        label_27:
        string val_14 = Localization.Localize(key:  "daily_challenge_upper", defaultValue:  "DAILY CHALLENGE", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private string GetTimeStringToNextChallenge()
    {
        int val_10;
        int val_11;
        System.TimeSpan val_1 = WGDailyChallengeManagerHelper.GetTimeSpanToNextChallenge();
        string[] val_2 = new string[5];
        val_10 = val_2.Length;
        val_2[0] = val_1._ticks.Hours.ToString(format:  "00");
        val_10 = val_2.Length;
        val_2[1] = ":";
        val_11 = val_2.Length;
        val_2[2] = val_1._ticks.Minutes.ToString(format:  "00");
        val_11 = val_2.Length;
        val_2[3] = ":";
        val_2[4] = val_1._ticks.Seconds.ToString(format:  "00");
        return (string)+val_2;
    }
    private void OnLocalize()
    {
        this.UpdateButtonState();
    }
    public WGDailyChallengeButton()
    {
    
    }
    private void <Awake>b__8_0(bool success)
    {
        this.OnClick_DailyChallenge();
    }

}
