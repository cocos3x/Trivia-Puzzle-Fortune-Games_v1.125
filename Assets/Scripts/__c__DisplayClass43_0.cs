using UnityEngine;
private sealed class AttackScreenMain.<>c__DisplayClass43_0
{
    // Fields
    public WordForest.AttackScreenMain <>4__this;
    public WordForest.WFOTree attackedTree;
    
    // Methods
    public AttackScreenMain.<>c__DisplayClass43_0()
    {
    
    }
    internal void <EndAttack>b__0()
    {
        string val_11;
        this.<>4__this.efxChopAction.gameObject.SetActive(value:  true);
        this.<>4__this.efxChopAction.Play();
        if((this.<>4__this.isSuccessful) != false)
        {
                DG.Tweening.Sequence val_2 = this.attackedTree.SetGrowthState(state:  2, instant:  true, delayGrowth:  false, shadowParent:  0);
            WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_11 = "attackSuccess";
        }
        else
        {
                UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
            this.<>4__this.blockShieldImage.transform.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
            this.<>4__this.blockShieldImage.gameObject.SetActive(value:  true);
            DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.blockShieldImage.transform, endValue:  1f, duration:  0.125f), ease:  6);
            WGAudioController val_10 = MonoSingleton<WGAudioController>.Instance;
            val_11 = "ThwartedShield";
        }
        
        val_10.sound.PlayGameSpecificSound(id:  val_11, clipIndex:  0);
    }

}
