using UnityEngine;
public class WGWindowBackgroundHandler : MonoBehaviour
{
    // Fields
    private UnityEngine.CanvasGroup alphaCanvas;
    private UnityEngine.GameObject bg_darken;
    private UnityEngine.GameObject bg_vignette;
    private UnityEngine.GameObject bg_vignette_dark;
    private UnityEngine.GameObject bg_blurred;
    private float fadeDuration;
    private DG.Tweening.Tweener fadingTween;
    private WGWindowBackgroundHandler.WGWindowBackgroundType currentState;
    
    // Methods
    public void HandleWindowShowing(SLCWindowSetting setting)
    {
        WGWindowBackgroundType val_5;
        if(setting != 0)
        {
            goto label_3;
        }
        
        label_11:
        GameBehavior val_2 = App.getBehavior;
        this.SetDarkenedBackgroundAlpha(alpha:  null);
        val_5 = 1;
        goto label_14;
        label_3:
        val_5 = setting.backgroundType;
        if(val_5 != 5)
        {
            goto label_10;
        }
        
        if(UnityEngine.SystemInfo.supportedRenderTargetCount == 1)
        {
            goto label_11;
        }
        
        val_5 = setting.backgroundType;
        label_10:
        if(val_5 == 7)
        {
                if(UnityEngine.SystemInfo.supportedRenderTargetCount == 1)
        {
                val_5 = 6;
        }
        else
        {
                val_5 = setting.backgroundType;
        }
        
        }
        
        label_14:
        this.SetState(nextBackground:  val_5);
    }
    public void CloseBackgrounds()
    {
        this.SetState(nextBackground:  0);
    }
    public void SetDarkenedBackgroundAlpha(float alpha)
    {
        UnityEngine.UI.Image val_1 = this.bg_darken.GetComponent<UnityEngine.UI.Image>();
        if((UnityEngine.Mathf.Approximately(a:  alpha, b:  0f)) != false)
        {
                val_1.enabled = false;
            return;
        }
        
        val_1.enabled = true;
        UnityEngine.Color val_3 = val_1.color;
        UnityEngine.Color val_4 = val_1.color;
        UnityEngine.Color val_5 = val_1.color;
        UnityEngine.Color val_6 = new UnityEngine.Color(r:  val_3.r, g:  val_4.g, b:  val_5.b, a:  alpha);
        val_1.color = new UnityEngine.Color() {r = val_6.r, g = val_6.g, b = val_6.b, a = val_6.a};
    }
    private void OnFadeOutComplete()
    {
        this.alphaCanvas.gameObject.SetActive(value:  false);
    }
    private void SetState(WGWindowBackgroundHandler.WGWindowBackgroundType nextBackground)
    {
        if(this.currentState == nextBackground)
        {
                return;
        }
        
        if((this.FadeOutOldDarkness(oldBackground:  this.currentState, nextBackground:  nextBackground)) != true)
        {
                this.FadeInNextDarkness(nextBackground:  nextBackground, duration:  this.fadeDuration);
        }
        
        this.currentState = nextBackground;
    }
    private bool FadeOutOldDarkness(WGWindowBackgroundHandler.WGWindowBackgroundType oldBackground, WGWindowBackgroundHandler.WGWindowBackgroundType nextBackground)
    {
        WGWindowBackgroundHandler.<>c__DisplayClass14_0 val_10;
        var val_11;
        float val_12;
        WGWindowBackgroundHandler.<>c__DisplayClass14_0 val_1 = null;
        val_10 = val_1;
        val_1 = new WGWindowBackgroundHandler.<>c__DisplayClass14_0();
        .<>4__this = this;
        .nextBackground = nextBackground;
        val_11 = 0;
        .CS$<>8__locals1 = val_10;
        if(oldBackground == 0)
        {
                return (bool)val_11;
        }
        
        if(oldBackground == 4)
        {
                return (bool)val_11;
        }
        
        if(oldBackground == 6)
        {
                this.alphaCanvas.alpha = 0f;
            this.alphaCanvas.gameObject.SetActive(value:  false);
            val_11 = 0;
            return (bool)val_11;
        }
        
        WGWindowBackgroundType val_10 = (WGWindowBackgroundHandler.<>c__DisplayClass14_0)[1152921518003820528].nextBackground;
        val_10 = val_10 | 4;
        if(val_10 == 4)
        {
                val_12 = this.fadeDuration;
        }
        else
        {
                val_12 = 0f;
        }
        
        .fadeTime = val_12;
        val_10 = DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single WGWindowBackgroundHandler.<>c__DisplayClass14_0::<FadeOutOldDarkness>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  (WGWindowBackgroundHandler.<>c__DisplayClass14_1)[1152921518003824624].CS$<>8__locals1, method:  System.Void WGWindowBackgroundHandler.<>c__DisplayClass14_0::<FadeOutOldDarkness>b__1(float x)), endValue:  0f, duration:  (WGWindowBackgroundHandler.<>c__DisplayClass14_1)[1152921518003824624].fadeTime);
        val_11 = 1;
        this.fadingTween = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  val_10, action:  new DG.Tweening.TweenCallback(object:  new WGWindowBackgroundHandler.<>c__DisplayClass14_1(), method:  System.Void WGWindowBackgroundHandler.<>c__DisplayClass14_1::<FadeOutOldDarkness>b__2())), autoKillOnCompletion:  true);
        return (bool)val_11;
    }
    private void FadeInNextDarkness(WGWindowBackgroundHandler.WGWindowBackgroundType nextBackground, float duration)
    {
        if(this.fadingTween != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.fadingTween, complete:  false);
        }
        
        this.ActivateBackgroundType(darkness:  nextBackground);
        if(nextBackground == 0)
        {
                return;
        }
        
        if(nextBackground == 4)
        {
                return;
        }
        
        if(nextBackground == 6)
        {
                this.alphaCanvas.alpha = 0f;
            this.alphaCanvas.gameObject.SetActive(value:  true);
            return;
        }
        
        this.alphaCanvas.alpha = 0f;
        this.alphaCanvas.gameObject.SetActive(value:  true);
        this.fadingTween = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single WGWindowBackgroundHandler::<FadeInNextDarkness>b__15_0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void WGWindowBackgroundHandler::<FadeInNextDarkness>b__15_1(float x)), endValue:  1f, duration:  duration), autoKillOnCompletion:  true);
    }
    private void ActivateBackgroundType(WGWindowBackgroundHandler.WGWindowBackgroundType darkness)
    {
        if(darkness > 7)
        {
                return;
        }
        
        var val_6 = 32497360 + (darkness) << 2;
        val_6 = val_6 + 32497360;
        goto (32497360 + (darkness) << 2 + 32497360);
    }
    public WGWindowBackgroundHandler()
    {
        this.fadeDuration = 0.3f;
    }
    private float <FadeInNextDarkness>b__15_0()
    {
        if(this.alphaCanvas != null)
        {
                return this.alphaCanvas.alpha;
        }
        
        throw new NullReferenceException();
    }
    private void <FadeInNextDarkness>b__15_1(float x)
    {
        if(this.alphaCanvas != null)
        {
                this.alphaCanvas.alpha = x;
            return;
        }
        
        throw new NullReferenceException();
    }

}
