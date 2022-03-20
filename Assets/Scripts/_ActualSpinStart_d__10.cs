using UnityEngine;
private sealed class SpinKingReelsController.<ActualSpinStart>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SpinKingReelsController <>4__this;
    private int <reel>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SpinKingReelsController.<ActualSpinStart>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_16;
        int val_17;
        var val_18;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        val_16 = this;
        this.<reel>5__2 = 0;
        this.<>1__state = 0;
        goto label_4;
        label_1:
        val_16 = this;
        int val_16 = this.<reel>5__2;
        val_16 = val_16 + 1;
        this.<>1__state = 0;
        this.<reel>5__2 = val_16;
        if(val_16 < 3)
        {
            goto label_4;
        }
        
        label_2:
        val_17 = 0;
        return (bool)val_17;
        label_4:
        .<>4__this = this.<>4__this;
        System.Collections.Generic.List<SpinKingSymbolItemData> val_2 = new System.Collections.Generic.List<SpinKingSymbolItemData>();
        if((this.<reel>5__2) == 2)
        {
                var val_3 = ((this.<>4__this.ReelData[1]) == (this.<>4__this.ReelData[(X11 + 16) << 2])) ? 1 : 0;
        }
        else
        {
                val_18 = 0;
        }
        
        var val_21 = 0;
        label_20:
        var val_19 = (long)this.<reel>5__2;
        val_19 = val_21 + ((X10 + 16) * val_19);
        val_2.Add(item:  this.<>4__this.GetRESSymbolItemDataObject(symbol:  this.<>4__this.previousReelData[((X10 + 16 * (long)(int)((this.<reel>5__2 + 1))) + 0) << 2]));
        if(val_21 > 3)
        {
            goto label_19;
        }
        
        val_21 = val_21 + 1;
        if((this.<>4__this.previousReelData) != null)
        {
            goto label_20;
        }
        
        label_19:
        int val_5 = (val_18 != 0) ? 90 : 70;
        int val_6 = (val_18 != 0) ? 100 : 80;
        if((UnityEngine.Random.Range(min:  val_5, max:  val_6)) >= 1)
        {
                var val_22 = 0;
            do
        {
            val_2.Add(item:  this.<>4__this.GetRESSymbolItemDataObject(symbol:  SpinKingSlotMachine.GetRandomSymbol(except:  0)));
            val_22 = val_22 + 1;
        }
        while(val_22 < (UnityEngine.Random.Range(min:  val_5, max:  val_6)));
        
        }
        
        var val_25 = 0;
        do
        {
            int val_23 = this.<reel>5__2;
            val_23 = val_25 + (37794084 * val_23);
            val_2.Add(item:  this.<>4__this.GetRESSymbolItemDataObject(symbol:  this.<>4__this.ReelData[((37794084 * (this.<reel>5__2 + 1)) + 0) << 2]));
            val_25 = val_25 + 1;
        }
        while(val_25 < 4);
        
        this.<>4__this.reels[this.<reel>5__2].SetData<SpinKingSymbolItemData>(data:  val_2, invert:  true, windStartDis:  -1f, windEndDis:  -1f);
        .stopReel = this.<reel>5__2;
        float val_28 = 0.1f;
        float val_29 = 0.7f;
        val_28 = ((float)this.<reel>5__2) * val_28;
        float val_14 = (val_18 != 0) ? (val_29) : 0f;
        val_29 = val_28 + val_29;
        val_14 = val_14 + val_29;
        this.<>4__this.reels[this.<reel>5__2].StartSpin(scrollCount:  val_6 - 5, duration:  val_14, callback:  new DG.Tweening.TweenCallback(object:  new SpinKingReelsController.<>c__DisplayClass10_0(), method:  System.Void SpinKingReelsController.<>c__DisplayClass10_0::<ActualSpinStart>b__0()));
        val_17 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.05f);
        this.<>1__state = val_17;
        return (bool)val_17;
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
