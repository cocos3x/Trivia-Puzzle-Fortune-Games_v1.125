using UnityEngine;
public class WordIQLineAnim : MonoBehaviour
{
    // Fields
    private bool playOnAwake;
    private UnityEngine.UI.Image imageToTween;
    private UnityEngine.CanvasGroup canvasToTween;
    private float localYMove;
    
    // Methods
    private void Awake()
    {
        if(this.playOnAwake == false)
        {
                return;
        }
        
        this.Play();
    }
    public void Play()
    {
        System.Delegate val_19;
        var val_20;
        var val_21;
        IntPtr val_23;
        val_19 = 1152921504765632512;
        if((UnityEngine.Object.op_Implicit(exists:  this.imageToTween)) != false)
        {
                DG.Tweening.Tweener val_3 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.imageToTween, endValue:  1f, duration:  0.2f), delay:  0.25f);
            DG.Tweening.Tweener val_6 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveY(target:  this.imageToTween.transform, endValue:  this.localYMove, duration:  1f, snapping:  false), delay:  0.25f);
            val_20 = 1152921504797261824;
            val_21 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.imageToTween, endValue:  0f, duration:  0.5f), delay:  1.25f);
            val_23 = 1152921516841583888;
        }
        else
        {
                if((UnityEngine.Object.op_Implicit(exists:  this.canvasToTween)) == false)
        {
                return;
        }
        
            DG.Tweening.Tweener val_11 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasToTween, endValue:  1f, duration:  0.2f), delay:  0.25f);
            DG.Tweening.Tweener val_14 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveY(target:  this.canvasToTween.transform, endValue:  this.localYMove, duration:  1f, snapping:  false), delay:  0.25f);
            val_20 = 1152921504797261824;
            val_21 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasToTween, endValue:  0f, duration:  0.5f), delay:  1.25f);
            DG.Tweening.TweenCallback val_17 = null;
            val_23 = 1152921516841634064;
        }
        
        val_17 = new DG.Tweening.TweenCallback(object:  this, method:  val_23);
        System.Delegate val_18 = System.Delegate.Combine(a:  val_19, b:  val_17);
        if(val_18 != null)
        {
                if(null != val_20)
        {
            goto label_13;
        }
        
        }
        
        mem2[0] = val_18;
        return;
        label_13:
    }
    public void KillYourself()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public WordIQLineAnim()
    {
        this.playOnAwake = true;
        this.localYMove = 50f;
    }
    private void <Play>b__5_0()
    {
        this.KillYourself();
    }
    private void <Play>b__5_1()
    {
        this.KillYourself();
    }

}
