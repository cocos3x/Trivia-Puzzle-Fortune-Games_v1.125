using UnityEngine;
private sealed class WordRegion.<LoadCoroutine>d__70 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordRegion <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordRegion.<LoadCoroutine>d__70(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        string val_13;
        var val_14;
        object val_54;
        System.Collections.Generic.List<System.String> val_55;
        int val_56;
        var val_58;
        var val_59;
        System.Func<System.String, System.Boolean> val_61;
        var val_62;
        System.Collections.Generic.List<System.String> val_63;
        System.Collections.Generic.List<System.String> val_64;
        var val_65;
        var val_67;
        var val_68;
        var val_69;
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
        val_54 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_56 = 1;
        this.<>2__current = val_54;
        this.<>1__state = val_56;
        return (bool)val_56;
        label_1:
        val_54 = this.<>4__this;
        this.<>1__state = 0;
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.gameLevel) == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<T> val_2 = CUtils.BuildListFromString<System.String>(values:  this.<>4__this.gameLevel.answers, split:  '|');
        this.<>4__this.ExtraRequiredList = new System.Collections.Generic.List<System.String>();
        if((this.<>4__this.gameLevel) == null)
        {
                throw new NullReferenceException();
        }
        
        char[] val_4 = new char[1];
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_4[0] = 124;
        if((this.<>4__this.gameLevel.extraRequiredWords) == null)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this.ExtraRequiredList = System.Linq.Enumerable.ToList<System.String>(source:  this.<>4__this.gameLevel.extraRequiredWords.Split(separator:  val_4));
        if((this.<>4__this.gameLevel) == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_7 = this.<>4__this.gameLevel.GetLevelProgress();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.gameLevel) == null)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this.validWords = CUtils.BuildListFromString<System.String>(values:  this.<>4__this.gameLevel.extraWords, split:  '|');
        if((this.<>4__this.gameLevel) == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<T> val_10 = CUtils.BuildListFromString<System.String>(values:  this.<>4__this.gameLevel.availExtraReq, split:  '|');
        System.Collections.Generic.List<System.String> val_11 = new System.Collections.Generic.List<System.String>();
        val_55 = this.<>4__this.validWords;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_12 = val_55.GetEnumerator();
        label_20:
        if(val_14.MoveNext() == false)
        {
            goto label_17;
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_11.Contains(item:  val_13)) == true)
        {
            goto label_20;
        }
        
        val_11.Add(item:  val_13);
        goto label_20;
        label_17:
        val_14.Dispose();
        this.<>4__this.validWords = val_11;
        System.Collections.Generic.List<System.String> val_17 = new System.Collections.Generic.List<System.String>();
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_58 = 1152921513250984896;
        List.Enumerator<T> val_18 = val_2.GetEnumerator();
        label_25:
        if(val_14.MoveNext() == false)
        {
            goto label_22;
        }
        
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_17.Contains(item:  val_13)) == true)
        {
            goto label_25;
        }
        
        val_17.Add(item:  val_13);
        goto label_25;
        label_22:
        val_14.Dispose();
        val_59 = null;
        val_59 = null;
        val_61 = WordRegion.<>c.<>9__70_0;
        if(val_61 == null)
        {
                System.Func<System.String, System.Boolean> val_22 = null;
            val_61 = val_22;
            val_22 = new System.Func<System.String, System.Boolean>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordRegion.<>c::<LoadCoroutine>b__70_0(string w));
            WordRegion.<>c.<>9__70_0 = val_61;
            val_58 = 1152921513250984896;
        }
        
        val_55 = this.<>4__this.ExtraRequiredList;
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_21.<ExtraRequiredWordsUsed>k__BackingField = System.Linq.Enumerable.Count<System.String>(source:  val_55, predicate:  val_22);
        System.Func<System.String, System.String> val_26 = null;
        val_62 = public System.Void System.Func<System.String, System.String>::.ctor(object object, IntPtr method);
        val_26 = new System.Func<System.String, System.String>(object:  val_54, method:  System.String WordRegion::<LoadCoroutine>b__70_2(string x));
        System.Collections.Generic.List<TSource> val_28 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.ThenBy<System.String, System.String>(source:  System.Linq.Enumerable.OrderBy<System.String, System.Int32>(source:  val_17, keySelector:  new System.Func<System.String, System.Int32>(object:  val_54, method:  System.Int32 WordRegion::<LoadCoroutine>b__70_1(string x))), keySelector:  val_26));
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        val_63 = val_28;
        mem2[0] = 1152921510375394352;
        val_54.SetupHackedWordsLists(wordList:  val_63);
        var val_30 = ((this.<>4__this.ExtraRequiredList) >= 5) ? (((this.<>4__this.ExtraRequiredList) >= 11) ? (2 + 1) : 2) : (0 + 1);
        mem2[0] = val_30;
        val_55 = null;
        val_64 = this.<>4__this.ExtraRequiredList;
        float val_53 = (float)this.<>4__this.ExtraRequiredList;
        val_53 = val_53 / (float)val_30;
        val_53 = (val_53 == Infinityf) ? (-(double)val_53) : ((double)val_53);
        val_65 = 0;
        mem2[0] = (int)val_53;
        mem2[0] = 0;
        if( >= (int)val_53)
        {
                val_30 = (int)val_53 - 1;
            if( <= val_30)
        {
                val_55 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
             =  + (val_30 << 3);
            if( == null)
        {
                throw new NullReferenceException();
        }
        
            val_65 = 30105600;
            mem2[0] = val_65;
        }
        
        System.Collections.Generic.List<System.String> val_32 =  - (( / 30105600) * 30105600);
        if(val_32 != null)
        {
                System.Collections.Generic.List<System.String> val_33 =  - 1;
            if(val_32 <= val_33)
        {
                val_55 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
             =  + (val_33 << 3);
            if( == null)
        {
                throw new NullReferenceException();
        }
        
             =  + val_65;
            mem2[0] = ;
        }
        
        val_55 = val_54;
        val_55.RecalculateCellSize();
        if(val_7.ToArray() == null)
        {
                throw new NullReferenceException();
        }
        
        if( != val_8.Length)
        {
                System.String[] val_34 = val_54.GetAncientLevelProgress();
            if(((val_34 != null) && (val_34.Length != 0)) && (val_8.Length == val_34.Length))
        {
                val_34.ClearAncientLevelProgress();
        }
        else
        {
                string[] val_35 = new string[0];
        }
        
        }
        
        List.Enumerator<T> val_36 = val_63.GetEnumerator();
        val_67 = 0;
        goto label_51;
        label_71:
        if(MonoUtils.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_68 = val_13;
        if(val_68 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_63 = UnityEngine.Object.Instantiate<LineWord>(original:  MonoUtils.instance.lineWord);
        if((val_68.StartsWith(value:  "*")) != false)
        {
                val_68 = val_68.Remove(startIndex:  0, count:  1);
            val_69 = 1;
        }
        else
        {
                val_69 = 0;
        }
        
        if(val_63 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37.answer = val_68.ToUpper();
        val_37.cellSize = "*";
        val_63.SetLineWidth();
        val_55 = MonoUtils.instance;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_55 = val_63;
        val_62 = 0;
        val_55.Build(cellType:  val_55.cell, clickable:  true);
        if((val_69 & 1) != 0)
        {
                val_55 = val_63;
            val_55.SetStarred();
        }
        
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_35.Length != 0)
        {
                if(val_67 >= val_35.Length)
        {
                throw new IndexOutOfRangeException();
        }
        
            val_63.SetProgress(progress:  val_35[val_67]);
        }
        
        UnityEngine.Transform val_42 = val_63.transform;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_42.SetParent(p:  val_54.transform);
        UnityEngine.Transform val_44 = val_63.transform;
        val_55 = 0;
        UnityEngine.Vector3 val_45 = UnityEngine.Vector3.one;
        if(val_44 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44.localScale = new UnityEngine.Vector3() {x = val_45.x, y = val_45.y, z = val_45.z};
        UnityEngine.Transform val_46 = val_63.transform;
        val_55 = 0;
        UnityEngine.Vector3 val_47 = UnityEngine.Vector3.zero;
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        val_46.localPosition = new UnityEngine.Vector3() {x = val_47.x, y = val_47.y, z = val_47.z};
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        val_46.Add(item:  val_63);
        val_67 = 1;
        label_51:
        if(val_14.MoveNext() == true)
        {
            goto label_71;
        }
        
        val_14.Dispose();
        UnityEngine.Coroutine val_50 = val_54.StartCoroutine(routine:  val_54.ScaleToPositionAndFitLate());
        UnityEngine.Coroutine val_52 = val_54.StartCoroutine(routine:  val_54.LevelLoadCompleteActionCoroutine());
        val_54.NotifyLevelLoaded(level:  this.<>4__this.gameLevel);
        val_54.CheckGameComplete();
        label_2:
        val_56 = 0;
        return (bool)val_56;
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
