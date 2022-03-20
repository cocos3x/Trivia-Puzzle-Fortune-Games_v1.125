using UnityEngine;
private sealed class WGAlphabetCollectionBoxPopup.<SetupUI>d__32 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGAlphabetCollectionBoxPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGAlphabetCollectionBoxPopup.<SetupUI>d__32(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_32;
        int val_33;
        UnityEngine.RectTransform val_34;
        System.Collections.Generic.List<System.String> val_35;
        var val_36;
        System.Func<System.String, System.Int32> val_38;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        this.<>4__this.skip = false;
        31693.Clear();
        MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.<>4__this.wordRegion.transform);
        var val_33 = 0;
        label_12:
        if(val_33 >= (this.<>4__this.boxItemsParentRows.Length))
        {
            goto label_9;
        }
        
        MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.<>4__this.boxItemsParentRows[val_33].transform);
        val_33 = val_33 + 1;
        if((this.<>4__this.boxItemsParentRows) != null)
        {
            goto label_12;
        }
        
        label_1:
        this.<>1__state = 0;
        val_32 = 1152921515419469536;
        decimal val_4 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentRewardAmount;
        this.<>4__this.currentCollectionRewardAmount = val_4;
        mem2[0] = val_4.lo;
        mem[4] = val_4.mid;
        this.<>4__this.rewardAmount.GetComponent<TweenCoinsText>().Set(instantValue:  new System.Decimal() {flags = this.<>4__this.currentCollectionRewardAmount, hi = this.<>4__this.currentCollectionRewardAmount});
        decimal val_7 = MonoSingleton<Alphabet2Manager>.Instance.GetRedrawCost;
        GameEcon val_8 = App.getGameEcon;
        string val_9 = val_7.flags.ToString(format:  val_8.numberFormatInt);
        this.<>4__this.continueButton.gameObject.SetActive(value:  false);
        this.<>4__this.redrawButton.gameObject.SetActive(value:  false);
        System.Collections.Generic.List<System.String> val_13 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionProgress;
        if(null == null)
        {
                if((this.<>4__this.hasDrawn) == false)
        {
            goto label_32;
        }
        
        }
        
        label_69:
        UnityEngine.Coroutine val_15 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.AnimateCollecting());
        label_3:
        val_33 = 0;
        return (bool)val_33;
        label_2:
        this.<>1__state = 0;
        val_33 = 1;
        this.<>4__this.coinRewardGroup.SetActive(value:  true);
        UnityEngine.WaitForEndOfFrame val_16 = null;
        val_32 = val_16;
        val_16 = new UnityEngine.WaitForEndOfFrame();
        this.<>2__current = val_32;
        this.<>1__state = 2;
        return (bool)val_33;
        label_9:
        val_34 = 1152921504893161472;
        this.<>4__this.wordRegion.Setup(requiredWords:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollection, progressWords:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionProgress);
        val_35 = this.<>4__this.CurrentCollectionBoxLetters;
        if(val_35 == null)
        {
                System.Collections.Generic.List<System.String> val_22 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox;
            val_35 = val_22;
            this.<>4__this.CurrentCollectionBoxLetters = val_22;
        }
        
        val_36 = null;
        val_36 = null;
        val_38 = WGAlphabetCollectionBoxPopup.<>c.<>9__32_0;
        if(val_38 == null)
        {
                System.Func<System.String, System.Int32> val_23 = null;
            val_38 = val_23;
            val_23 = new System.Func<System.String, System.Int32>(object:  WGAlphabetCollectionBoxPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WGAlphabetCollectionBoxPopup.<>c::<SetupUI>b__32_0(string x));
            WGAlphabetCollectionBoxPopup.<>c.<>9__32_0 = val_38;
        }
        
        val_32 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.OrderBy<System.String, System.Int32>(source:  val_35, keySelector:  val_23));
        if(1152921510375394352 >= 1)
        {
                var val_35 = 0;
            int val_34 = this.<>4__this.boxItemsPerRow;
            val_34 = val_35 / val_34;
            val_34 = this.<>4__this.boxItemsParentRows[val_34];
            AlphabetBoxItem val_27 = UnityEngine.Object.Instantiate<AlphabetBoxItem>(original:  this.<>4__this.alphabetBoxItemPrefabLoaded, parent:  val_34);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_27.Setup(letter:  (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32);
            this.<>4__this.alphabetBoxItems.Add(item:  val_27);
            val_35 = val_35 + 1;
        }
        
        var val_38 = 0;
        label_66:
        if(val_38 >= (this.<>4__this.boxItemsParentRows.Length))
        {
            goto label_62;
        }
        
        int val_37 = this.<>4__this.boxItemsPerRow;
        val_37 = val_37 * val_38;
        this.<>4__this.boxItemsParentRows[val_38].gameObject.SetActive(value:  ((this.<>4__this.boxItemsParentRows.Length) > val_37) ? 1 : 0);
        val_38 = val_38 + 1;
        if((this.<>4__this.boxItemsParentRows) != null)
        {
            goto label_66;
        }
        
        label_62:
        this.<>4__this.currentCollectedLetters.Clear();
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        val_33 = 1;
        this.<>1__state = val_33;
        return (bool)val_33;
        label_32:
        System.Collections.IEnumerator val_31 = this.<>4__this.ShowTooltipBeforeAnimating();
        goto label_69;
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
