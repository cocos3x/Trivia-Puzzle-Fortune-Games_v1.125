using UnityEngine;
private sealed class TRVPickerGameButton.<doReveal>d__14 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVPickerGameButton <>4__this;
    public bool selected;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVPickerGameButton.<doReveal>d__14(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.UI.Image val_8;
        int val_9;
        val_8 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_11;
        }
        
        this.<>1__state = 0;
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions.DOScaleX(target:  this.<>4__this.myImage.transform, endValue:  0f, duration:  0.3f);
        val_9 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.31f);
        this.<>1__state = val_9;
        return (bool)val_9;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.myImage.sprite = this.<>4__this.specificSprite;
        this.<>4__this.chosenOutline.gameObject.SetActive(value:  this.selected);
        DG.Tweening.Tweener val_6 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.myImage.transform, endValue:  1f, duration:  0.3f);
        if(this.selected != true)
        {
                val_8 = this.<>4__this.myImage;
            UnityEngine.Color val_7 = UnityEngine.Color.gray;
            val_8.color = new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a};
        }
        
        label_11:
        val_9 = 0;
        return (bool)val_9;
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
