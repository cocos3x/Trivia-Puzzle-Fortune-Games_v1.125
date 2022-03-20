using UnityEngine;
private sealed class AlphabetWordRegion.<LoadCoroutine>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public AlphabetWordRegion <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public AlphabetWordRegion.<LoadCoroutine>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_13;
        var val_14;
        object val_29;
        int val_30;
        var val_31;
        System.Func<System.String, System.Int32> val_33;
        var val_34;
        System.Func<System.String, System.String> val_36;
        LineWord val_37;
        var val_38;
        var val_39;
        var val_40;
        UnityEngine.Transform val_41;
        var val_42;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_29 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_30 = 1;
        this.<>2__current = val_29;
        this.<>1__state = val_30;
        return (bool)val_30;
        label_1:
        val_29 = this.<>4__this;
        this.<>1__state = 0;
        val_31 = null;
        val_31 = null;
        val_33 = AlphabetWordRegion.<>c.<>9__10_0;
        if(val_33 == null)
        {
                System.Func<System.String, System.Int32> val_2 = null;
            val_33 = val_2;
            val_2 = new System.Func<System.String, System.Int32>(object:  AlphabetWordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 AlphabetWordRegion.<>c::<LoadCoroutine>b__10_0(string x));
            AlphabetWordRegion.<>c.<>9__10_0 = val_33;
        }
        
        val_34 = null;
        val_34 = null;
        val_36 = AlphabetWordRegion.<>c.<>9__10_1;
        if(val_36 == null)
        {
                System.Func<System.String, System.String> val_4 = null;
            val_36 = val_4;
            val_4 = new System.Func<System.String, System.String>(object:  AlphabetWordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.String AlphabetWordRegion.<>c::<LoadCoroutine>b__10_1(string x));
            AlphabetWordRegion.<>c.<>9__10_1 = val_36;
        }
        
        System.Collections.Generic.List<TSource> val_6 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.ThenBy<System.String, System.String>(source:  System.Linq.Enumerable.OrderBy<System.String, System.Int32>(source:  this.<>4__this.words, keySelector:  val_2), keySelector:  val_4));
        val_37 = val_6;
        System.Collections.Generic.List<System.String> val_7 = val_6.GetLevelProgress(savedProgress:  this.<>4__this.progress, orderedWordList:  val_6);
        var val_9 = (1152921504906366976 >= 5) ? ((1152921504906366976 >= 11) ? (2 + 1) : 2) : (0 + 1);
        mem2[0] = 1152921504906366976;
        mem2[0] = val_9;
        val_38 = 1152921504906366976;
        float val_28 = 4.426604E+07f;
        val_28 = val_28 / (float)val_9;
        val_28 = (val_28 == Infinityf) ? (-(double)val_28) : ((double)val_28);
        val_39 = 0;
        mem2[0] = (int)val_28;
        mem2[0] = 0;
        if( >= (int)val_28)
        {
                val_9 = (int)val_28 - 1;
            if( <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
             =  + (val_9 << 3);
            var val_30 = (val_38 + ((4.426604E+07f == Infinityf ? (4.426604E+07f / 1152921504906366976 >= 0x5 ? 1152921504906366976 >= 0xB ? (2 + 1) : 2 : (0 + 1)) : (4.426604E+07f / 1152921504906366976 >= 0x5 ? 1152921504906 + 32;
            var val_29 = (val_38 + ((4.426604E+07f == Infinityf ? (4.426604E+07f / 1152921504906366976 >= 0x5 ? 1152921504906366976 >= 0xB ? (2 + 1) : 2 : (0 + 1)) : (4.426604E+07f / 1152921504906366976 >= 0x5 ? 1152921504906 + 32 + 16;
            val_39 = val_29 + 0;
            mem2[0] = val_39;
        }
        
        val_29 = val_30 - ((val_30 / val_29) * val_29);
        if(val_29 != 0)
        {
                var val_11 = val_30 - 1;
            if(val_29 <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_30 = val_30 + (val_11 << 3);
            var val_31 = ((val_38 + ((4.426604E+07f == Infinityf ? (4.426604E+07f / 1152921504906366976 >= 0x5 ? 1152921504906366976 >= 0xB ? (2 + 1) : 2 : (0 + 1)) : (4.426604E+07f / 1152921504906366976 >= 0x5 ? 115292150490 + 32 + 16;
            val_31 = val_31 + val_39;
            mem2[0] = val_31;
        }
        
        val_29.RecalculateCellSize();
        if(val_31 != val_29)
        {
                UnityEngine.Debug.LogWarning(message:  "Non-matching saved words vs required words, trashing progress!", context:  val_29);
        }
        
        List.Enumerator<T> val_12 = val_37.GetEnumerator();
        val_40 = 0;
        goto label_30;
        label_43:
        val_41 = public static LineWord UnityEngine.Object::Instantiate<LineWord>(LineWord original);
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_37 = UnityEngine.Object.Instantiate<LineWord>(original:  val_29.LineWordPrefabLoaded);
        val_41 = 0;
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_16.answer = val_13.ToUpper();
        val_16.cellSize = UnityEngine.Object.__il2cppRuntimeField_cctor_finished;
        val_37.SetLineWidth();
        val_37.Build(cellType:  val_29.CellPrefabLoaded, clickable:  false);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_37.SetProgress(progress:  (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32);
        UnityEngine.Transform val_19 = val_37.transform;
        val_41 = val_29.transform;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19.SetParent(p:  val_41);
        val_41 = 0;
        UnityEngine.Transform val_21 = val_37.transform;
        val_42 = 0;
        UnityEngine.Vector3 val_22 = UnityEngine.Vector3.one;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21.localScale = new UnityEngine.Vector3() {x = val_22.x, y = val_22.y, z = val_22.z};
        val_41 = 0;
        UnityEngine.Transform val_23 = val_37.transform;
        val_42 = 0;
        UnityEngine.Vector3 val_24 = UnityEngine.Vector3.zero;
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = 0;
        val_23.localPosition = new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z};
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_23.Add(item:  val_37);
        val_40 = 1;
        label_30:
        if(val_14.MoveNext() == true)
        {
            goto label_43;
        }
        
        val_14.Dispose();
        UnityEngine.Coroutine val_27 = val_29.StartCoroutine(routine:  val_29.ScaleToPositionAndFitLate());
        label_2:
        val_30 = 0;
        return (bool)val_30;
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
