using UnityEngine;
private sealed class WGEventButton.<UpdateDisplayDelayed>d__56 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButton <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGEventButton.<UpdateDisplayDelayed>d__56(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WGEventButton val_33;
        int val_34;
        string val_35;
        val_33 = this;
        if((this.<>1__state) != 1)
        {
                val_34 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_34;
        }
        
            this.<>1__state = 0;
            val_34 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.1f);
            this.<>1__state = val_34;
            return (bool)val_34;
        }
        
        this.<>1__state = 0;
        val_33 = this.<>4__this;
        if(WordGameEventsController.EventsEnabled == false)
        {
            goto label_7;
        }
        
        this.<>4__this.event_text.gameObject.SetActive(value:  true);
        val_35 = 1152921504893161472;
        if(((MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) >= 2) && ((this.<>4__this.LeftButton) != 0))
        {
                if((this.<>4__this.RightButton) != 0)
        {
                this.<>4__this.LeftButton.gameObject.SetActive(value:  true);
            this.<>4__this.RightButton.gameObject.SetActive(value:  true);
        }
        
        }
        
        if((this.<>4__this.showingAllEventsButton) != true)
        {
                WGEventHandler val_11 = MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlersByIndex(index:  this.<>4__this.CurrentEventIndex);
            this.<>4__this.currentEventHandler = val_11;
            if(val_11 == null)
        {
                if((this.<>4__this.CurrentEventIndex) == 0)
        {
            goto label_29;
        }
        
        }
        
        }
        
        this.<>4__this.event_button.gameObject.SetActive(value:  true);
        if((this.<>4__this.eventsCointainer) != 0)
        {
                this.<>4__this.eventsCointainer.SetActive(value:  true);
        }
        
        if((this.<>4__this.opposingButton) != 0)
        {
                this.<>4__this.opposingButton.SetActive(value:  false);
        }
        
        if((this.<>4__this.eventsCounter) != 0)
        {
                val_35 = Localization.Localize(key:  "events_x_upper", defaultValue:  "EVENTS ({0})", useSingularKey:  false);
            string val_20 = System.String.Format(format:  val_35, arg0:  MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount.ToString());
        }
        
        if((this.<>4__this.currentEventHandler) == null)
        {
            goto label_47;
        }
        
        if((this.<>4__this.showingAllEventsButton) == true)
        {
            goto label_48;
        }
        
        val_33.SetButtonContent(evtHandler:  this.<>4__this.currentEventHandler);
        goto label_69;
        label_7:
        this.<>4__this.event_button.gameObject.SetActive(value:  false);
        label_68:
        this.<>4__this.eventsCointainer.SetActive(value:  false);
        goto label_69;
        label_47:
        this.<>4__this.showingAllEventsButton = true;
        label_48:
        this.<>4__this.button_prefix.gameObject.SetActive(value:  false);
        UnityEngine.Vector2 val_24 = new UnityEngine.Vector2(x:  1f, y:  1f);
        this.<>4__this.button_prefix.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_24.x, y = val_24.y};
        string val_25 = Localization.Localize(key:  "view_all_events_upper", defaultValue:  "VIEW ALL EVENTS", useSingularKey:  false);
        this.<>4__this.event_text.resizeTextMaxSize = 44;
        UnityEngine.Vector2 val_28 = this.<>4__this.event_text.rectTransform.sizeDelta;
        UnityEngine.Vector2 val_30 = new UnityEngine.Vector2(x:  (this.<>4__this.defaultTextWidth) + (this.<>4__this.defaultIconWidth), y:  val_28.y);
        this.<>4__this.event_text.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_30.x, y = val_30.y};
        label_69:
        val_34 = 0;
        return (bool)val_34;
        label_29:
        this.<>4__this.event_button.gameObject.SetActive(value:  false);
        if((this.<>4__this.eventsCointainer) != 0)
        {
            goto label_68;
        }
        
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
