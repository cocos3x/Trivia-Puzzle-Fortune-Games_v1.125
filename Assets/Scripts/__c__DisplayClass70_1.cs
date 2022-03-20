using UnityEngine;
private sealed class RaidMadnessEventHandler.<>c__DisplayClass70_1
{
    // Fields
    public UnityEngine.UI.Image icon;
    public DG.Tweening.Sequence seq;
    public RaidMadnessEventHandler.<>c__DisplayClass70_0 CS$<>8__locals1;
    
    // Methods
    public RaidMadnessEventHandler.<>c__DisplayClass70_1()
    {
    
    }
    internal void <DoLevelCompleteEventProgressAnimation>b__1()
    {
        this.CS$<>8__locals1.<>4__this.<ProgressDisplayPoints>k__BackingField = 0;
        this.CS$<>8__locals1.<>4__this.<EventButtonDisplayPoints>k__BackingField = this.CS$<>8__locals1.<>4__this;
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.CS$<>8__locals1.eventProgressUI.canvasGroup, endValue:  0f, duration:  1f);
        this.CS$<>8__locals1.<>4__this.UpdateProgress();
        this.CS$<>8__locals1.eventButton.efxUpdate.gameObject.SetActive(value:  true);
        this.CS$<>8__locals1.eventButton.efxUpdate.Play();
        UnityEngine.Object.Destroy(obj:  this.icon.gameObject);
    }
    internal bool <DoLevelCompleteEventProgressAnimation>b__2()
    {
        if(this.seq != null)
        {
                return (bool)(this.seq == 0) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}
