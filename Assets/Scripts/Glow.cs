using UnityEngine;
public class Glow : MonoBehaviour
{
    // Fields
    private float cycleDuraton;
    private float maxAlpha;
    private float minAlpha;
    private UnityEngine.CanvasGroup canvasGroup;
    
    // Methods
    private void OnEnable()
    {
        this.canvasGroup = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject);
        this.GlowDown();
    }
    private void GlowUp()
    {
        float val_6 = this.cycleDuraton;
        val_6 = val_6 * 0.5f;
        DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  this.maxAlpha, duration:  val_6), ease:  7);
        DG.Tweening.Tween val_5 = DG.Tweening.DOVirtual.DelayedCall(delay:  this.cycleDuraton * 0.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Glow::GlowDown()), ignoreTimeScale:  true);
    }
    private void GlowDown()
    {
        float val_6 = this.cycleDuraton;
        val_6 = val_6 * 0.5f;
        DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  this.minAlpha, duration:  val_6), ease:  7);
        DG.Tweening.Tween val_5 = DG.Tweening.DOVirtual.DelayedCall(delay:  this.cycleDuraton * 0.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Glow::GlowUp()), ignoreTimeScale:  true);
    }
    public Glow()
    {
        this.minAlpha = 0.5f;
        this.cycleDuraton = 5f;
        this.maxAlpha = 1f;
    }

}
