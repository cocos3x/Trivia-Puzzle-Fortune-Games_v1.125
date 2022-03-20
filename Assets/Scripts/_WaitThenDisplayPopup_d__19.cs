using UnityEngine;
private sealed class StrugglingPlayerFreeHintHandler.<WaitThenDisplayPopup>d__19 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public StrugglingPlayerFreeHintHandler <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public StrugglingPlayerFreeHintHandler.<WaitThenDisplayPopup>d__19(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        StrugglingPlayerFreeHintHandler val_17;
        int val_18;
        object val_19;
        val_17 = this.<>4__this;
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
            goto label_43;
        }
        
        val_18 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_18;
        return (bool)val_18;
        label_2:
        this.<>1__state = 0;
        this.<>4__this.timeWaited = 0f;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_32;
        }
        
        object[] val_3 = new object[4];
        WordRegion val_4 = WordRegion.instance;
        val_3[0] = WordRegion.__il2cppRuntimeField_namespaze;
        GameEcon val_5 = App.getGameEcon;
        val_3[1] = val_5.spHintConstant;
        val_3[2] = this.<>4__this.currentCompletionTime;
        val_3[3] = val_17.TimeToWaitBetweenHints;
        val_19 = System.String.Format(format:  "with {0} lines, {1} second constant, and {2} current avg completion time, we wait {3}", args:  val_3);
        UnityEngine.Debug.LogWarning(message:  val_19);
        goto label_32;
        label_1:
        this.<>1__state = 0;
        label_32:
        float val_8 = val_17.TimeToWaitBetweenHints;
        if((this.<>4__this.timeWaited) < 0)
        {
            goto label_34;
        }
        
        MainController.instance.StruggleHintProvided = true;
        val_19 = 1152921515468090304;
        HintFeatureManager val_10 = MonoSingleton<HintFeatureManager>.Instance;
        if((val_10.<wgHbutton>k__BackingField) != 0)
        {
                this.<>4__this.freeHintAvailableNow = true;
            MonoSingleton<HintFeatureManager>.Instance.UpdateFreeHintEligable();
            HintFeatureManager val_13 = MonoSingleton<HintFeatureManager>.Instance;
            val_13.<wgHbutton>k__BackingField.CheckFreeHinting();
            HintFeatureManager val_14 = MonoSingleton<HintFeatureManager>.Instance;
            val_14.<wgHbutton>k__BackingField.SetPopup(message:  "Try a FREE Hint!", interactablePopup:  true);
        }
        
        label_43:
        val_18 = 0;
        return (bool)val_18;
        label_34:
        GameBehavior val_15 = App.getBehavior;
        if(((val_15.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                float val_17 = this.<>4__this.timeWaited;
            val_17 = val_17 + 1f;
            this.<>4__this.timeWaited = val_17;
        }
        
        UnityEngine.WaitForSeconds val_16 = null;
        val_17 = val_16;
        val_16 = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>2__current = val_17;
        this.<>1__state = 2;
        val_18 = 1;
        return (bool)val_18;
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
