using UnityEngine;
private sealed class TRVCategoryRankPopup.<AnimateRankup>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVCategoryRankPopup <>4__this;
    private UnityEngine.CanvasGroup <cg>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVCategoryRankPopup.<AnimateRankup>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_8;
        if((this.<>1__state) != 1)
        {
                val_8 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_8;
        }
        
            this.<>1__state = 0;
            UnityEngine.CanvasGroup val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.<>4__this.rank.gameObject);
            this.<cg>5__2 = val_2;
            DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  val_2, endValue:  0f, duration:  0.5f);
            val_8 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
            this.<>1__state = val_8;
            return (bool)val_8;
        }
        
        this.<>1__state = 0;
        string val_6 = (this.<>4__this.currentRank) + 1.ToString();
        DG.Tweening.Tweener val_7 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<cg>5__2, endValue:  1f, duration:  0.5f);
        val_8 = 0;
        return (bool)val_8;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
