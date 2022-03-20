using UnityEngine;
private sealed class WGHelpMenuPopup.<>c__DisplayClass9_0
{
    // Fields
    public System.Action prevOnClose;
    public System.Action <>9__1;
    
    // Methods
    public WGHelpMenuPopup.<>c__DisplayClass9_0()
    {
    
    }
    internal void <OnClickHowToPlay>b__0()
    {
        System.Action val_5;
        WGWindow val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGHelpMenuPopup>(showNext:  false).GetComponent<WGWindow>();
        val_5 = this.<>9__1;
        if(val_5 == null)
        {
                System.Action val_4 = null;
            val_5 = val_4;
            val_4 = new System.Action(object:  this, method:  System.Void WGHelpMenuPopup.<>c__DisplayClass9_0::<OnClickHowToPlay>b__1());
            this.<>9__1 = val_5;
        }
        
        mem2[0] = val_5;
    }
    internal void <OnClickHowToPlay>b__1()
    {
        GameBehavior val_1 = App.getBehavior;
        SLCWindow val_2 = val_1.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_2.Action_OnClose = this.prevOnClose;
    }

}
