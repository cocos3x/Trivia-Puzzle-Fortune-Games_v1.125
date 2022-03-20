using UnityEngine;
private sealed class WordRegionCrossword.<LoadCoroutine>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordRegionCrossword <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordRegionCrossword.<LoadCoroutine>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        string val_12;
        int val_13;
        object val_74;
        System.Collections.Generic.IEnumerable<TSource> val_75;
        int val_76;
        var val_77;
        System.Func<System.String, System.Boolean> val_79;
        System.Collections.Generic.List<Vector2Int> val_80;
        var val_81;
        var val_82;
        var val_83;
        var val_84;
        var val_86;
        UnityEngine.UI.GridLayoutGroup val_87;
        var val_89;
        int val_90;
        int val_91;
        if((this.<>1__state) != 1)
        {
                val_76 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_76;
        }
        
            this.<>1__state = 0;
            UnityEngine.WaitForEndOfFrame val_1 = null;
            val_74 = val_1;
            val_1 = new UnityEngine.WaitForEndOfFrame();
            val_76 = 1;
            this.<>2__current = val_74;
            this.<>1__state = val_76;
            return (bool)val_76;
        }
        
        val_74 = this.<>4__this;
        this.<>1__state = 0;
        if(val_74 == null)
        {
                throw new NullReferenceException();
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<T> val_2 = CUtils.BuildListFromString<System.String>(values:  0, split:  '|');
        mem2[0] = CUtils.BuildListFromString<System.String>(values:  CUtils.__il2cppRuntimeField_cctor_finished + 80, split:  '|');
        mem2[0] = new System.Collections.Generic.List<System.String>();
        if((public System.Void System.Collections.Generic.List<System.String>::.ctor()) == 0)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = CUtils.BuildListFromString<System.String>(values:  "com.facebook.ads.RewardData", split:  '|');
        if((public System.Void System.Collections.Generic.List<System.String>::.ctor()) == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_6 = GetLevelProgress();
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        T[] val_7 = val_6.ToArray();
        val_77 = null;
        val_77 = null;
        val_79 = WordRegionCrossword.<>c.<>9__8_0;
        if(val_79 == null)
        {
                System.Func<System.String, System.Boolean> val_9 = null;
            val_79 = val_9;
            val_9 = new System.Func<System.String, System.Boolean>(object:  WordRegionCrossword.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordRegionCrossword.<>c::<LoadCoroutine>b__8_0(string w));
            WordRegionCrossword.<>c.<>9__8_0 = val_79;
        }
        
        val_75 = X23;
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.<ExtraRequiredWordsUsed>k__BackingField = System.Linq.Enumerable.Count<System.String>(source:  val_75, predicate:  val_9);
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = 1152921515475089600;
        val_74.SetupHackedWordsLists(wordList:  val_2);
        List.Enumerator<T> val_11 = val_2.GetEnumerator();
        val_80 = 1152921515475156160;
        goto label_21;
        label_43:
        if(MonoUtils.instance == null)
        {
                throw new NullReferenceException();
        }
        
        LineWord val_14 = UnityEngine.Object.Instantiate<LineWord>(original:  MonoUtils.instance.lineWord);
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_12.Chars[0] & 65535) == ('*'))
        {
                val_81 = 1;
            string val_17 = val_12.Substring(startIndex:  1);
            if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
            val_81 = 0;
            string val_18 = val_17.ToUpper();
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            val_82 = 1;
        }
        else
        {
                val_81 = 0;
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            val_82 = 0;
        }
        
        val_14.answer = val_12.ToUpper();
        val_75 = MonoUtils.instance;
        if(val_75 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.Build(cellType:  val_75.cell, clickable:  true);
        if((val_82 & 1) != 0)
        {
                val_75 = val_14;
            val_75.SetStarred();
        }
        
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_7.Length != 0)
        {
                val_14.SetProgress(progress:  val_7[0]);
        }
        
        UnityEngine.Transform val_21 = val_14.transform;
        UnityEngine.Transform val_22 = val_74.transform;
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21.SetParent(p:  val_22.parent);
        UnityEngine.Transform val_24 = val_14.transform;
        val_75 = 0;
        UnityEngine.Vector3 val_25 = UnityEngine.Vector3.one;
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24.localScale = new UnityEngine.Vector3() {x = val_25.x, y = val_25.y, z = val_25.z};
        UnityEngine.Transform val_26 = val_14.transform;
        val_75 = 0;
        UnityEngine.Vector3 val_27 = UnityEngine.Vector3.zero;
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.localPosition = new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z};
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.Add(item:  val_14);
        label_21:
        if(val_13.MoveNext() == true)
        {
            goto label_43;
        }
        
        val_13.Dispose();
        if((public System.Void List.Enumerator<System.String>::Dispose()) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((CUtils.BuildListFromString<System.Int32>(values:  null, split:  '|')) == null)
        {
                throw new NullReferenceException();
        }
        
        if((public static System.Collections.Generic.List<T> CUtils::BuildListFromString<System.Int32>(string values, char split)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.<>4__this.height = public System.Int32 System.Text.UTF7Encoding::GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex);
        if((public System.Int32 System.Text.UTF7Encoding::GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.<>4__this.width = public System.Int32 System.Text.UTF7Encoding::GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex).__il2cppRuntimeField_24;
        System.Collections.Generic.List<Vector2Int> val_30 = new System.Collections.Generic.List<Vector2Int>();
        if((public System.Void System.Collections.Generic.List<Vector2Int>::.ctor()) == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<T> val_31 = CUtils.BuildListFromString<System.String>(values:  UnityEngine.Vector3 ShortcutExtensions.<>c__DisplayClass46_0::<DOLocalMoveX>b__0(), split:  '|');
        System.Collections.Generic.List<System.Int32> val_32 = new System.Collections.Generic.List<System.Int32>();
        int val_36 = 0;
        if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_33 = val_31.GetEnumerator();
        val_83 = 1152921515481001808;
        val_84 = "not able to parse ";
        label_66:
        if(val_13.MoveNext() == false)
        {
            goto label_52;
        }
        
        if((CUtils.BuildListFromString<System.String>(values:  val_12, split:  ',')) == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((System.Int32.TryParse(s:  CUtils.__il2cppRuntimeField_cctor_finished + 32, result: out  val_36)) == false)
        {
            goto label_59;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_75 = mem[CUtils.__il2cppRuntimeField_cctor_finished + 40];
        val_75 = CUtils.__il2cppRuntimeField_cctor_finished + 40;
        if((System.Int32.TryParse(s:  val_75, result: out  val_36)) == false)
        {
            goto label_59;
        }
        
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        val_30.Add(item:  new Vector2Int());
        if(0 <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_32.Add(item:  System.Int32.Parse(s:  0));
        goto label_66;
        label_59:
        UnityEngine.Debug.LogError(message:  "not able to parse " + val_12);
        goto label_66;
        label_52:
        val_13.Dispose();
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        if(1152921515481015232 >= 1)
        {
                var val_76 = 0;
            System.Collections.Generic.List<Vector2Int> val_42 = null;
            val_80 = val_42;
            val_42 = new System.Collections.Generic.List<Vector2Int>();
            if(1152921515480992592 <= val_76)
        {
                val_75 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_80 == null)
        {
                throw new NullReferenceException();
        }
        
            val_75 = val_80;
            val_42.Add(item:  new Vector2Int() {x = -2010728512, y = 268435458});
            if(val_32 == 0)
        {
                throw new NullReferenceException();
        }
        
            if(mem[1152921515481287928] <= val_76)
        {
                val_75 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((public static System.Collections.Generic.List<T> CUtils::BuildListFromString<System.String>(string values, char split)) == 0)
        {
                throw new NullReferenceException();
        }
        
            val_84 = 1;
            var val_75 = mem[1152921515481287920];
            val_75 = val_75 + 0;
            if("padding" <= val_76)
        {
                val_75 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_86 = (CUtils.__il2cppRuntimeField_12F + 0) + 32;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_86 = val_86 + 0;
            val_86 = mem[((CUtils.__il2cppRuntimeField_12F + 0) + 32 + 0) + 32];
            val_86 = ((CUtils.__il2cppRuntimeField_12F + 0) + 32 + 0) + 32;
            val_86 = val_86 >> 32;
            var val_44 = (((mem[1152921515481287920] + 0) + 32) == 0) ? (val_84) : 0;
            val_86 = ((((mem[1152921515481287920] + 0) + 32) == 0) ? 0 : (val_84)) + val_86;
            val_75 = val_80;
            val_42.Add(item:  new Vector2Int() {x = ((mem[1152921515481287920] + 0) + 32 == 0x0 ? val_84 : 0 + (CUtils.__il2cppRuntimeField_12F + 0) + 32), y = ((mem[1152921515481287920] + 0) + 32 == 0x0 ? val_84 : 0 + (CUtils.__il2cppRuntimeField_12F + 0) + 32)});
            val_84 = val_84 + 1;
            throw new NullReferenceException();
        }
        
        val_75 = this.<>4__this.grid;
        if(val_75 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75.constraintCount = this.<>4__this.width;
        val_87 = this.<>4__this.grid;
        UnityEngine.Vector2 val_46 = UnityEngine.Vector2.one;
        val_75 = 0;
        UnityEngine.Vector2 val_47 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_46.x, y = val_46.y}, d:  80f);
        if(val_87 == null)
        {
                throw new NullReferenceException();
        }
        
        val_87.cellSize = new UnityEngine.Vector2() {x = val_47.x, y = val_47.y};
        val_75 = null;
        val_13 = this.<>4__this.width;
        int val_77 = this.<>4__this.width;
        if((this.<>4__this.height) < 1)
        {
            goto label_87;
        }
        
        val_84 = "cell ";
        val_87 = val_75;
        label_187:
        if(val_77 < 1)
        {
            goto label_88;
        }
        
        if((new System.Collections.Generic.List<System.Collections.Generic.List<Vector2Int>>()) == null)
        {
                throw new NullReferenceException();
        }
        
        object val_89 = 0;
        label_186:
        if(val_77 < 1)
        {
            goto label_90;
        }
        
        val_80 = 1;
        val_89 = 0;
        if(1152921515481054496 <= 0)
        {
                val_75 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_64 = 0 + 1;
        val_84 = "cell ";
        if(( & 1) == 0)
        {
            goto label_165;
        }
        
        label_90:
        UnityEngine.GameObject val_66 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.<>4__this.emptyCellPrefab, parent:  val_74.transform);
        object[] val_67 = new object[5];
        if(val_67 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = val_67;
        if(val_67.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_80[0] = "cell ";
        val_13 = val_89;
        val_90 = val_67.Length;
        if(val_90 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_80[1] = val_13;
        val_75 = ",";
        val_90 = val_67.Length;
        if(val_90 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_80[2] = ",";
        val_91 = val_67.Length;
        if(val_91 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_80[3] = 0;
        val_75 = " (empty)";
        val_91 = val_67.Length;
        if(val_91 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_80[4] = " (empty)";
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_66.name = +val_67;
        UnityEngine.Transform val_69 = val_66.transform;
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        val_69.SetAsLastSibling();
        label_165:
        val_89 = val_89 + 1;
        if(val_89 < (this.<>4__this.width))
        {
            goto label_186;
        }
        
        label_88:
        val_83 = 0 + 1;
        if(val_83 < (this.<>4__this.height))
        {
            goto label_187;
        }
        
        label_87:
        val_74.SaveLevelProgress();
        UnityEngine.Coroutine val_71 = val_74.StartCoroutine(routine:  val_74.ScaleToFitLate());
        System.Collections.IEnumerator val_72 = val_74.LevelLoadCompleteActionCoroutine();
        UnityEngine.Coroutine val_73 = val_74.StartCoroutine(routine:  val_72);
        val_74.NotifyLevelLoaded(level:  val_72);
        val_74.CheckGameComplete();
        val_76 = 0;
        return (bool)val_76;
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
