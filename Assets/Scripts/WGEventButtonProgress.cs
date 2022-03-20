using UnityEngine;
public class WGEventButtonProgress : WGEventButtonV2
{
    // Methods
    public override void Refresh()
    {
        if(this == null)
        {
                return;
        }
        
        goto X19 + 1504;
    }
    public override void ShowIntroAnimation()
    {
        this.alpha = 0f;
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this, endValue:  1f, duration:  1f);
    }
    public WGEventButtonProgress()
    {
        mem[1152921517496481760] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
