using UnityEngine;
private sealed class GoalDisplayIcon.<>c__DisplayClass25_0
{
    // Fields
    public BlockPuzzleMagic.GoalDisplayIcon <>4__this;
    public int currentDisplayValue;
    
    // Methods
    public GoalDisplayIcon.<>c__DisplayClass25_0()
    {
    
    }
    internal void <RefreshUI>b__0()
    {
        string val_1 = this.currentDisplayValue.ToString();
        if(this.currentDisplayValue >= 1)
        {
                DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.label.transform, endValue:  1f, duration:  0.15f);
            return;
        }
        
        this.<>4__this.label.gameObject.SetActive(value:  false);
        this.<>4__this.checkmarkIcon.gameObject.SetActive(value:  true);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
        this.<>4__this.checkmarkIcon.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        DG.Tweening.Tweener val_10 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.checkmarkIcon.transform, endValue:  1f, duration:  0.25f), ease:  27);
    }

}
