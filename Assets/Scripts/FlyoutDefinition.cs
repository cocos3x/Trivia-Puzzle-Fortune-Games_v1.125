using UnityEngine;
public class FlyoutDefinition : DisplayWordDefinition
{
    // Fields
    private float timeToDisplayDefinition;
    private float timeToDisplayInternetConnection;
    private float timeToDisplayTutorialMessage;
    private float timeToDisplay;
    private float currentDisplayTime;
    private UnityEngine.GameObject definitionGroup;
    private UnityEngine.GameObject InternetConnectionGroup;
    private UnityEngine.GameObject tutorialGroup;
    private DG.Tweening.Sequence curSeq;
    private bool setUp;
    
    // Properties
    protected override bool checkTouchedMe { get; }
    
    // Methods
    protected override void OnEnable()
    {
        FlyoutDefinition.<>c__DisplayClass10_0 val_1 = new FlyoutDefinition.<>c__DisplayClass10_0();
        this.OnEnable();
        UnityEngine.CanvasGroup val_3 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        .cg = val_3;
        if(this.setUp != false)
        {
                val_3.alpha = 1f;
            return;
        }
        
        val_3.alpha = 0f;
        DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions> val_6 = DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single FlyoutDefinition.<>c__DisplayClass10_0::<OnEnable>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void FlyoutDefinition.<>c__DisplayClass10_0::<OnEnable>b__1(float x)), endValue:  1f, duration:  0.3f);
        this.setUp = true;
    }
    public override void OpenButLoad(string word)
    {
        this.SetUp();
        this.OpenButLoad(word:  word);
        if((UnityEngine.Object.op_Implicit(exists:  this.tutorialGroup)) == false)
        {
                return;
        }
        
        this.tutorialGroup.gameObject.SetActive(value:  false);
    }
    public override void ShowFTUXMessage()
    {
        this.definitionGroup.gameObject.SetActive(value:  false);
        this.InternetConnectionGroup.gameObject.SetActive(value:  false);
        if((UnityEngine.Object.op_Implicit(exists:  this.tutorialGroup)) != false)
        {
                this.tutorialGroup.gameObject.SetActive(value:  true);
        }
        
        this.timeToDisplay = this.timeToDisplayTutorialMessage;
    }
    public override void Init(System.Collections.Generic.Dictionary<string, object> defToDisplay)
    {
        this.SetUp();
        this.Init(defToDisplay:  defToDisplay);
    }
    private void SetUp()
    {
        var val_5;
        float val_6;
        if(this.curSeq != null)
        {
                if((DG.Tweening.TweenExtensions.IsPlaying(t:  this.curSeq)) != false)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.curSeq, complete:  false);
        }
        
        }
        
        this.enabled = true;
        val_5 = null;
        val_5 = null;
        UnityEngine.GameObject val_2 = this.definitionGroup.gameObject;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null)
        {
                val_2.SetActive(value:  true);
            this.InternetConnectionGroup.gameObject.SetActive(value:  false);
            val_6 = this.timeToDisplayDefinition;
        }
        else
        {
                val_2.SetActive(value:  false);
            this.InternetConnectionGroup.gameObject.SetActive(value:  true);
            val_6 = this.timeToDisplayInternetConnection;
        }
        
        this.timeToDisplay = val_6;
        this.currentDisplayTime = 0f;
    }
    private void FixedUpdate()
    {
        if(this.currentDisplayTime < 0)
        {
                float val_1 = UnityEngine.Time.fixedDeltaTime;
            val_1 = this.currentDisplayTime + val_1;
            this.currentDisplayTime = val_1;
            return;
        }
        
        this.enabled = false;
        goto typeof(FlyoutDefinition).__il2cppRuntimeField_1B0;
    }
    protected override bool get_checkTouchedMe()
    {
        if(UnityEngine.Input.touchCount <= 0)
        {
                return UnityEngine.Input.GetMouseButtonDown(button:  0);
        }
        
        return true;
    }
    protected override void DisableMe()
    {
        FlyoutDefinition.<>c__DisplayClass18_0 val_1 = new FlyoutDefinition.<>c__DisplayClass18_0();
        if(this.curSeq != null)
        {
                if((DG.Tweening.TweenExtensions.IsPlaying(t:  this.curSeq)) != false)
        {
                return;
        }
        
        }
        
        .cg = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
        this.curSeq = val_5;
        DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single FlyoutDefinition.<>c__DisplayClass18_0::<DisableMe>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void FlyoutDefinition.<>c__DisplayClass18_0::<DisableMe>b__1(float x)), endValue:  1f, duration:  0.1f));
        DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.curSeq, t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single FlyoutDefinition.<>c__DisplayClass18_0::<DisableMe>b__2()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void FlyoutDefinition.<>c__DisplayClass18_0::<DisableMe>b__3(float x)), endValue:  0f, duration:  0.3f));
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.curSeq, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void FlyoutDefinition::Disable()));
    }
    private void Disable()
    {
        UnityEngine.GameObject val_4 = this.gameObject;
        if((this.gameObject.GetComponent<DestroyOnDisable>()) != 0)
        {
                val_4.SetActive(value:  false);
            return;
        }
        
        UnityEngine.Object.Destroy(obj:  val_4);
    }
    public FlyoutDefinition()
    {
        this.timeToDisplayDefinition = ;
        this.timeToDisplayInternetConnection = ;
        this.timeToDisplayTutorialMessage = 2.5f;
        this.timeToDisplay = 5f;
    }

}
