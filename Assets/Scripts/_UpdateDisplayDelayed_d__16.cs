using UnityEngine;
private sealed class WFOEventButton.<UpdateDisplayDelayed>d__16 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WFOEventButton <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WFOEventButton.<UpdateDisplayDelayed>d__16(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        GameEventV2 val_10;
        int val_11;
        MetaGameBehavior val_32;
        WFOEventButton val_33;
        int val_34;
        var val_35;
        val_33 = this.<>4__this;
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
            goto label_83;
        }
        
        this.<>1__state = 0;
        val_32 = 0;
        bool val_1 = WordGameEventsController.EventsEnabled;
        if(val_1 == false)
        {
            goto label_6;
        }
        
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this.isInSneakPreviewMode = false;
        this.<>2__current = val_33.UpdateDisplayDelayed();
        val_34 = 1;
        this.<>1__state = val_34;
        return (bool)val_34;
        label_2:
        this.<>1__state = 0;
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        if(32928 == 0)
        {
                return (bool)val_34;
        }
        
        string val_3 = 32928.EventType;
        goto label_83;
        label_1:
        this.<>1__state = 0;
        val_32 = 0;
        bool val_4 = WordGameEventsController.EventsEnabled;
        if(val_4 == true)
        {
            goto label_83;
        }
        
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_4 == false)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_5 = val_4.gameObject;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_5.SetActive(value:  false);
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_5.SetActive(value:  false);
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_32 = val_6.<metaGameBehavior>k__BackingField;
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_32 & 1) == 0)
        {
            goto label_83;
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_32 = val_7.<metaGameBehavior>k__BackingField;
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_32 & 1) != 0)
        {
            goto label_83;
        }
        
        if((MonoSingleton<GameEventsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_32 = val_8.eventList;
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_9 = val_32.GetEnumerator();
        label_70:
        if(val_11.MoveNext() == false)
        {
            goto label_33;
        }
        
        WFOEventButton.<>c__DisplayClass16_0 val_13 = new WFOEventButton.<>c__DisplayClass16_0();
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        .ge = val_10;
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_32 = this.<>4__this.eventsToSkipProcessing;
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_32.Contains(item:  val_10 + 72)) == true)
        {
            goto label_70;
        }
        
        if(((WFOEventButton.<>c__DisplayClass16_0)[1152921517422117408].ge) == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
        if(((WFOEventButton.<>c__DisplayClass16_0)[1152921517422117408].ge.minPlayerLevel) > val_15.events_unlockLevel)
        {
            goto label_70;
        }
        
        if((this.<>4__this.sneakPreviewLockedEventList) == null)
        {
                throw new NullReferenceException();
        }
        
        WGEventHandler val_17 = this.<>4__this.sneakPreviewLockedEventList.Find(match:  new System.Predicate<WGEventHandler>(object:  val_13, method:  System.Boolean WFOEventButton.<>c__DisplayClass16_0::<UpdateDisplayDelayed>b__0(WGEventHandler x)));
        if(val_17 != null)
        {
            goto label_44;
        }
        
        WordGameEventsController val_18 = MonoSingleton<WordGameEventsController>.Instance;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        WGEventHandler val_19 = val_18.ForceInitNewHandlerForEvent(eventV2:  (WFOEventButton.<>c__DisplayClass16_0)[1152921517422117408].ge);
        if(val_19 == null)
        {
            goto label_49;
        }
        
        val_32 = val_19;
        if((val_32 & 1) == 0)
        {
            goto label_49;
        }
        
        if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 <= val_20.events_unlockLevel)
        {
            goto label_53;
        }
        
        label_49:
        if(((WFOEventButton.<>c__DisplayClass16_0)[1152921517422117408].ge) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.eventsToSkipProcessing) == null)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this.eventsToSkipProcessing.Add(item:  (WFOEventButton.<>c__DisplayClass16_0)[1152921517422117408].ge.type);
        val_35 = 0 + 1;
        mem2[0] = 447;
        if(val_19 != null)
        {
            goto label_56;
        }
        
        goto label_57;
        label_53:
        val_32 = this.<>4__this.sneakPreviewLockedEventList;
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        val_32.Add(item:  val_19);
        val_35 = 0 + 1;
        mem2[0] = 447;
        label_56:
        var val_32 = 0;
        val_32 = val_32 + 1;
        val_19.Dispose();
        label_57:
        val_32 = 0;
        if(val_32 != 0)
        {
                throw val_1;
        }
        
        if((val_35 == 1) || ((1152921517422032272 + ((0 + 1)) << 2) != 447))
        {
            goto label_65;
        }
        
        var val_33 = 0;
        val_33 = val_33 ^ (val_35 >> 31);
        val_35 = val_35 + val_33;
        goto label_66;
        label_65:
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        label_44:
        label_66:
        if((this.<>4__this.sneakPreviewLockedEventList) < 1)
        {
            goto label_70;
        }
        
        this.<>4__this.isInSneakPreviewMode = true;
        goto label_70;
        label_6:
        UnityEngine.WaitForSeconds val_22 = null;
        val_33 = val_22;
        val_22 = new UnityEngine.WaitForSeconds(seconds:  0.1f);
        this.<>2__current = val_33;
        this.<>1__state = 2;
        val_34 = 1;
        return (bool)val_34;
        label_33:
        var val_23 = 0 + 1;
        mem2[0] = 496;
        val_11.Dispose();
        if((this.<>4__this.isInSneakPreviewMode) != false)
        {
                if(val_11 == 0)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_24 = val_11.gameObject;
            if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
            val_24.SetActive(value:  true);
            if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
            val_24.SetActive(value:  true);
            val_32 = this.<>4__this.iconLocked;
            if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_25 = val_32.gameObject;
            if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
            val_25.SetActive(value:  true);
            if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
            val_11 = val_26.events_unlockLevel;
            string val_27 = System.String.Format(format:  "Unlock at Forest {0}", arg0:  val_11);
            if((this.<>4__this.lockedLabel) == null)
        {
                throw new NullReferenceException();
        }
        
            val_32 = this.<>4__this.lockedLabel;
            if(val_32 != 0)
        {
                string val_29 = Localization.Localize(key:  "events_x_upper", defaultValue:  "EVENTS ({0})", useSingularKey:  false);
            if((this.<>4__this.sneakPreviewLockedEventList) == null)
        {
                throw new NullReferenceException();
        }
        
            val_11 = this.<>4__this.sneakPreviewLockedEventList;
            string val_30 = System.String.Format(format:  val_29, arg0:  val_11);
            if((this.<>4__this.lockedLabel) == null)
        {
                throw new NullReferenceException();
        }
        
            val_32 = this.<>4__this.lockedLabel;
        }
        
            if((this.<>4__this.sneakPreviewLockedEventList) == null)
        {
                throw new NullReferenceException();
        }
        
            if(null <= val_29)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.UI.Text val_31 = 1152921504814993408 + ((val_29) << 3);
            val_33.SetButtonContent(evtHandler:  mem[(1152921504814993408 + (val_29) << 3) + 32]);
        }
        
        label_83:
        val_34 = 0;
        return (bool)val_34;
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
