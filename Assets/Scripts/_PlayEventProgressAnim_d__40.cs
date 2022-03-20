using UnityEngine;
private sealed class WUTLevelClearPopup.<PlayEventProgressAnim>d__40 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WUTLevelClearPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WUTLevelClearPopup.<PlayEventProgressAnim>d__40(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        bool val_24;
        WGEventButtonV2 val_25;
        bool val_26;
        WGEventButtonV2 val_27;
        WGEventButtonV2 val_28;
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
                return false;
        }
        
        this.<>1__state = 0;
        val_20 = 0;
        this.<>4__this.evt01_Button = this.<>4__this.eventButtonPanel.GetEventButton(slotIndex:  0);
        val_21 = 0;
        this.<>4__this.evt01_ProgressUI = this.<>4__this.eventProgressPanel.GetEventButton(slotIndex:  0);
        val_22 = 0;
        this.<>4__this.evt02_Button = this.<>4__this.eventButtonPanel.GetEventButton(slotIndex:  1);
        val_23 = 0;
        this.<>4__this.evt02_ProgressUI = this.<>4__this.eventProgressPanel.GetEventButton(slotIndex:  1);
        if((this.<>4__this.evt01_Button) != 0)
        {
            goto label_23;
        }
        
        val_24 = UnityEngine.Object.op_Equality(x:  this.<>4__this.evt01_ProgressUI, y:  0);
        goto label_26;
        label_2:
        this.<>1__state = 0;
        if((this.<>4__this) != null)
        {
            goto label_27;
        }
        
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this) != null)
        {
            goto label_38;
        }
        
        label_23:
        val_24 = false;
        label_26:
        this.<>4__this.isSlotOneEmpty = val_24;
        val_25 = this.<>4__this.evt02_Button;
        if(val_25 == 0)
        {
                val_25 = this.<>4__this.evt02_ProgressUI;
            val_26 = UnityEngine.Object.op_Equality(x:  val_25, y:  0);
        }
        else
        {
                val_26 = false;
        }
        
        this.<>4__this.isSlotTwoEmpty = val_26;
        if((this.<>4__this.isSlotOneEmpty) != false)
        {
                if(val_26 != 0)
        {
            goto label_38;
        }
        
        }
        
        if((this.<>4__this.evt01_Button) != 0)
        {
                this.<>4__this.evt01_Button.canvasGroup.alpha = 0f;
        }
        
        if((this.<>4__this.evt02_Button) != 0)
        {
                this.<>4__this.evt02_Button.canvasGroup.alpha = 0f;
        }
        
        val_25 = this.<>4__this.eventButtonPanel;
        if(val_25 != 0)
        {
                this.<>4__this.eventButtonPanel.rootCanvasGroup.alpha = 1f;
        }
        
        if((this.<>4__this.isSlotOneEmpty) == false)
        {
            goto label_54;
        }
        
        label_27:
        if((this.<>4__this.isSlotTwoEmpty) == false)
        {
            goto label_55;
        }
        
        label_38:
        this.<>4__this.PlayChapterProgressAnim();
        return false;
        label_55:
        if((this.<>4__this.evt02_Button) == 0)
        {
            goto label_58;
        }
        
        val_27 = this.<>4__this.evt02_Button;
        if(val_27 != null)
        {
            goto label_59;
        }
        
        label_58:
        val_27 = this.<>4__this.evt02_ProgressUI;
        label_59:
        this.<>2__current = this.<>4__this.evt02_ProgressUI.eventHandler;
        this.<>1__state = 2;
        return false;
        label_54:
        if((this.<>4__this.evt01_Button) == 0)
        {
            goto label_66;
        }
        
        val_28 = this.<>4__this.evt01_Button;
        if(val_28 != null)
        {
            goto label_67;
        }
        
        label_66:
        val_28 = this.<>4__this.evt01_ProgressUI;
        label_67:
        this.<>2__current = this.<>4__this.evt01_ProgressUI.eventHandler;
        this.<>1__state = 1;
        return false;
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
