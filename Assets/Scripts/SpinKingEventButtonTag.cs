using UnityEngine;
public class SpinKingEventButtonTag : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image obtained_ring;
    private UnityEngine.GameObject no_new_spins_ring;
    private UnityEngine.GameObject max_tag;
    
    // Methods
    private void Awake()
    {
        PluginExtension.SetColorAlpha(graphic:  this.obtained_ring, a:  0f);
    }
    public void ShowObtainedRing()
    {
        PluginExtension.SetColorAlpha(graphic:  this.obtained_ring, a:  0f);
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.obtained_ring, endValue:  1f, duration:  0.3f));
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  2f);
        DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.obtained_ring, endValue:  0f, duration:  0.3f));
    }
    public void ShowNoNewSpinsRing(bool show)
    {
        if(this.no_new_spins_ring != null)
        {
                this.no_new_spins_ring.SetActive(value:  show);
            return;
        }
        
        throw new NullReferenceException();
    }
    public void ShowMaxTag(bool show)
    {
        if(this.max_tag != null)
        {
                this.max_tag.SetActive(value:  show);
            return;
        }
        
        throw new NullReferenceException();
    }
    public SpinKingEventButtonTag()
    {
    
    }

}
