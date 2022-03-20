using UnityEngine;
public class GoldenApplesEffectController : MonoSingleton<GoldenApplesEffectController>
{
    // Fields
    private UnityEngine.GameObject effectParent;
    private float tweeningDuration;
    private UnityEngine.UI.Image borderGlow;
    private UnityEngine.ParticleSystem borderParticles;
    private UnityEngine.UI.Image starTexture;
    private CRotate starRotation;
    private const int effectLevelCount = 11;
    private float[] borderAlphaValues;
    private int[] particleRateOverTimeValues;
    private float[] starRotationSpeedValues;
    private UnityEngine.ParticleSystem.EmissionModule emissionModule;
    private DG.Tweening.Sequence mySequence;
    
    // Methods
    public override void InitMonoSingleton()
    {
        null = null;
        if(App.game == 18)
        {
                UnityEngine.Object.Destroy(obj:  this.gameObject);
        }
        
        SceneDictator val_2 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void GoldenApplesEffectController::Instance_OnSceneLoaded(SceneType obj)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        val_2.OnSceneLoaded = val_4;
        SceneDictator val_5 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnSceneUnloaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void GoldenApplesEffectController::Instance_OnSceneUnloaded(SceneType obj)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        val_5.OnSceneUnloaded = val_7;
        return;
        label_16:
    }
    private void Start()
    {
        AdsUIController val_1 = MonoSingleton<AdsUIController>.Instance;
        val_1.onAdToggled.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void GoldenApplesEffectController::OnAdToggled()));
        EmissionModule val_3 = this.borderParticles.emission;
        this.emissionModule = val_3.m_ParticleSystem;
        this.StopEffects();
        this.InitializeGameObjectStates();
        this.ResizeParticleSystem(adsHeight:  0f);
    }
    private void OnDestroy()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void GoldenApplesEffectController::Instance_OnSceneLoaded(SceneType obj)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Remove(source:  val_4.OnSceneUnloaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void GoldenApplesEffectController::Instance_OnSceneUnloaded(SceneType obj)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_4.OnSceneUnloaded = val_6;
        return;
        label_8:
    }
    private void Instance_OnSceneLoaded(SceneType obj)
    {
        if((obj | 2) != 6)
        {
                return;
        }
        
        this.effectParent.SetActive(value:  false);
        this.borderParticles.gameObject.SetActive(value:  false);
    }
    private void Instance_OnSceneUnloaded(SceneType obj)
    {
        if((obj | 2) != 6)
        {
                return;
        }
        
        this.effectParent.SetActive(value:  true);
        this.borderParticles.gameObject.SetActive(value:  true);
    }
    public void StopEffects()
    {
        UnityEngine.ParticleSystemCurveMode val_2;
        UnityEngine.AnimationCurve val_3;
        MinMaxCurve val_1 = ParticleSystem.MinMaxCurve.op_Implicit(constant:  (float)this.particleRateOverTimeValues[0]);
        this.emissionModule.rateOverTime = new MinMaxCurve() {m_Mode = val_2, m_CurveMultiplier = val_2, m_CurveMin = val_3, m_CurveMax = val_3};
        this.effectParent.SetActive(value:  false);
        this.mySequence = DG.Tweening.TweenSettingsExtensions.Join(s:  DG.Tweening.TweenSettingsExtensions.Join(s:  DG.Tweening.TweenSettingsExtensions.Join(s:  DG.Tweening.DOTween.Sequence(), t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single GoldenApplesEffectController::<StopEffects>b__17_0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void GoldenApplesEffectController::<StopEffects>b__17_1(float x)), endValue:  this.borderAlphaValues[0], duration:  this.tweeningDuration)), t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single GoldenApplesEffectController::<StopEffects>b__17_2()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void GoldenApplesEffectController::<StopEffects>b__17_3(float x)), endValue:  this.starRotationSpeedValues[0], duration:  this.tweeningDuration)), t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single GoldenApplesEffectController::<StopEffects>b__17_4()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void GoldenApplesEffectController::<StopEffects>b__17_5(float x)), endValue:  0f, duration:  this.tweeningDuration));
    }
    private void InitializeGameObjectStates()
    {
        var val_6 = 0;
        label_6:
        if(val_6 >= this.effectParent.transform.childCount)
        {
            goto label_2;
        }
        
        this.transform.GetChild(index:  0).gameObject.SetActive(value:  true);
        val_6 = val_6 + 1;
        if(this.effectParent != null)
        {
            goto label_6;
        }
        
        label_2:
        this.effectParent.SetActive(value:  false);
    }
    private void ResizeParticleSystem(float adsHeight = 0)
    {
        ShapeModule val_1 = this.borderParticles.shape;
        UnityEngine.Canvas val_2 = this.GetComponentInParent<UnityEngine.Canvas>();
        UnityEngine.RectTransform val_3 = val_2.GetComponent<UnityEngine.RectTransform>();
        UnityEngine.Vector3 val_5 = val_2.transform.localScale;
        UnityEngine.Vector2 val_6 = val_3.sizeDelta;
        UnityEngine.Vector3 val_8 = val_2.transform.localScale;
        UnityEngine.Vector2 val_9 = val_3.sizeDelta;
        val_9.y = val_9.y - adsHeight;
        float val_10 = val_5.x * val_6.x;
        val_9.y = val_8.y * val_9.y;
        val_10 = val_10 + (-0.2f);
        val_9.y = val_9.y + (-0.2f);
        UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  val_10, y:  val_9.y, z:  0f);
        val_1.m_ParticleSystem.scale = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
    }
    private void OnAdToggled()
    {
        this.OnCanvasResized();
    }
    private void OnCanvasResized()
    {
        if((MonoSingleton<AdsUIController>.Instance) != 0)
        {
                0f = MonoSingleton<AdsUIController>.Instance.GetBannerAdHeight();
        }
        
        UnityEngine.RectTransform val_5 = this.GetComponent<UnityEngine.RectTransform>();
        UnityEngine.Vector2 val_6 = val_5.offsetMin;
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  val_6.x, y:  0f);
        val_5.offsetMin = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        this.ResizeParticleSystem(adsHeight:  0f);
    }
    public void PlayEffects(int streak)
    {
        UnityEngine.ParticleSystemCurveMode val_19;
        UnityEngine.AnimationCurve val_20;
        object val_22;
        DG.Tweening.Sequence val_23;
        DG.Tweening.Core.DOSetter<System.Single> val_24;
        val_22 = this;
        val_23 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) > streak)
        {
                this.StopEffects();
            return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) >= streak)
        {
                this.effectParent.SetActive(value:  true);
            val_23 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Core.DOSetter<System.Single> val_5 = null;
            val_24 = val_5;
            val_5 = new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void GoldenApplesEffectController::<PlayEffects>b__22_1(float x));
            this.mySequence = DG.Tweening.TweenSettingsExtensions.Join(s:  val_23, t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single GoldenApplesEffectController::<PlayEffects>b__22_0()), setter:  val_5, endValue:  0.77f, duration:  this.tweeningDuration));
        }
        
        if(streak > 11)
        {
                return;
        }
        
        DG.Tweening.Core.DOSetter<System.Single> val_10 = null;
        val_24 = val_10;
        val_10 = new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void GoldenApplesEffectController::<PlayEffects>b__22_3(float x));
        DG.Tweening.Core.DOGetter<System.Single> val_14 = null;
        val_23 = val_14;
        val_14 = new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single GoldenApplesEffectController::<PlayEffects>b__22_4());
        this.mySequence = DG.Tweening.TweenSettingsExtensions.Join(s:  DG.Tweening.TweenSettingsExtensions.Join(s:  DG.Tweening.DOTween.Sequence(), t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single GoldenApplesEffectController::<PlayEffects>b__22_2()), setter:  val_10, endValue:  this.borderAlphaValues[(long)streak - 1], duration:  this.tweeningDuration)), t:  DG.Tweening.DOTween.To(getter:  val_14, setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void GoldenApplesEffectController::<PlayEffects>b__22_5(float x)), endValue:  this.starRotationSpeedValues[(long)streak - 1], duration:  this.tweeningDuration));
        val_22 = this.emissionModule;
        MinMaxCurve val_18 = ParticleSystem.MinMaxCurve.op_Implicit(constant:  (float)this.particleRateOverTimeValues[(long)streak - 1]);
        val_22.rateOverTime = new MinMaxCurve() {m_Mode = val_19, m_CurveMultiplier = val_19, m_CurveMin = val_20, m_CurveMax = val_20};
    }
    public GoldenApplesEffectController()
    {
        this.tweeningDuration = 0.5f;
        this.borderAlphaValues = new float[11];
        this.particleRateOverTimeValues = new int[11];
        this.starRotationSpeedValues = new float[11];
    }
    private float <StopEffects>b__17_0()
    {
        UnityEngine.Color val_1 = this.borderGlow.color;
        return (float)val_1.a;
    }
    private void <StopEffects>b__17_1(float x)
    {
        PluginExtension.SetColorAlpha(graphic:  this.borderGlow, a:  x);
    }
    private float <StopEffects>b__17_2()
    {
        if(this.starRotation != null)
        {
                return (float)this.starRotation.speed;
        }
        
        throw new NullReferenceException();
    }
    private void <StopEffects>b__17_3(float x)
    {
        if(this.starRotation != null)
        {
                this.starRotation.speed = x;
            return;
        }
        
        throw new NullReferenceException();
    }
    private float <StopEffects>b__17_4()
    {
        UnityEngine.Color val_1 = this.starTexture.color;
        return (float)val_1.a;
    }
    private void <StopEffects>b__17_5(float x)
    {
        PluginExtension.SetColorAlpha(graphic:  this.starTexture, a:  x);
    }
    private float <PlayEffects>b__22_0()
    {
        UnityEngine.Color val_1 = this.starTexture.color;
        return (float)val_1.a;
    }
    private void <PlayEffects>b__22_1(float x)
    {
        PluginExtension.SetColorAlpha(graphic:  this.starTexture, a:  x);
    }
    private float <PlayEffects>b__22_2()
    {
        UnityEngine.Color val_1 = this.borderGlow.color;
        return (float)val_1.a;
    }
    private void <PlayEffects>b__22_3(float x)
    {
        PluginExtension.SetColorAlpha(graphic:  this.borderGlow, a:  x);
    }
    private float <PlayEffects>b__22_4()
    {
        if(this.starRotation != null)
        {
                return (float)this.starRotation.speed;
        }
        
        throw new NullReferenceException();
    }
    private void <PlayEffects>b__22_5(float x)
    {
        if(this.starRotation != null)
        {
                this.starRotation.speed = x;
            return;
        }
        
        throw new NullReferenceException();
    }

}
