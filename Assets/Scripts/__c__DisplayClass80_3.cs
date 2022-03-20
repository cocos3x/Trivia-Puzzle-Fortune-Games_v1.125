using UnityEngine;
private sealed class WordHuntEvent.<>c__DisplayClass80_3
{
    // Fields
    public UnityEngine.UI.Image icon;
    public DG.Tweening.Sequence seq;
    public WordHuntEvent.<>c__DisplayClass80_2 CS$<>8__locals3;
    
    // Methods
    public WordHuntEvent.<>c__DisplayClass80_3()
    {
    
    }
    internal void <DoLevelCompleteEventProgressAnimation>b__1()
    {
        WordHuntEvent.<>c__DisplayClass80_2 val_6;
        this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.<collectedWords>k__BackingField.Add(item:  32617.CacheCollectedWords[this.CS$<>8__locals3.i]);
        val_6 = this.CS$<>8__locals3;
        int val_7 = this.CS$<>8__locals3.CS$<>8__locals2.iconCount;
        val_7 = val_7 - 1;
        if((this.CS$<>8__locals3.i) == val_7)
        {
                DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.eventProgressUI.canvasGroup, endValue:  0f, duration:  1f);
            EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.eventProgressData, key:  "collected", newValue:  this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.<collectedWords>k__BackingField);
            this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.cacheOverallWordFound = this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.<collectedWords>k__BackingField;
            this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.currLevelEventWordsTotal.Clear();
            this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.tempCacheCollecteWords.Clear();
            T[] val_3 = this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.tempCacheCollecteWords.ToArray();
            val_3.CacheCollectedWords = val_3;
            this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.SaveData();
            val_6 = this.CS$<>8__locals3;
        }
        
        this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.eventButton.efxUpdate.gameObject.SetActive(value:  true);
        this.CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.eventButton.efxUpdate.Play();
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
