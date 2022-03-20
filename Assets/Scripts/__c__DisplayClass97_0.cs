using UnityEngine;
private sealed class WFOMysteryChestDisplay.<>c__DisplayClass97_0
{
    // Fields
    public WordForest.FtuxId ftuxId;
    public WordForest.WFOMysteryChestDisplay <>4__this;
    public WordForest.WFOPlayer player;
    public UnityEngine.Events.UnityAction <>9__1;
    public UnityEngine.Events.UnityAction <>9__2;
    public UnityEngine.Events.UnityAction <>9__3;
    
    // Methods
    public WFOMysteryChestDisplay.<>c__DisplayClass97_0()
    {
    
    }
    internal void <ShowFtux>b__0()
    {
        WordForest.FtuxId val_28 = this.ftuxId;
        val_28 = val_28 - 8;
        if(val_28 > 3)
        {
                return;
        }
        
        var val_29 = 32561388 + ((this.ftuxId - 8)) << 2;
        val_29 = val_29 + 32561388;
        goto (32561388 + ((this.ftuxId - 8)) << 2 + 32561388);
    }
    internal void <ShowFtux>b__1()
    {
        this.<>4__this.ftuxRoot.transform.parent = this.<>4__this.transform;
        this.<>4__this.ftuxTooltip.transform.parent = this.<>4__this.ftuxRoot.transform;
        this.<>4__this.ftuxRoot.SetActive(value:  false);
        this.<>4__this.ToggleTapToOpenLabel(isVisible:  true);
        RaidAttackScreenUI.ShowAttackScreen();
    }
    internal void <ShowFtux>b__2()
    {
        this.<>4__this.ftuxRoot.transform.parent = this.<>4__this.transform;
        this.<>4__this.ftuxTooltip.transform.parent = this.<>4__this.ftuxRoot.transform;
        this.<>4__this.ftuxRoot.SetActive(value:  false);
        this.<>4__this.ToggleTapToOpenLabel(isVisible:  true);
        this.<>4__this.OnFtuxButtonClicked();
    }
    internal void <ShowFtux>b__3()
    {
        this.<>4__this.ftuxRoot.transform.parent = this.<>4__this.transform;
        this.<>4__this.ftuxTooltip.transform.parent = this.<>4__this.ftuxRoot.transform;
        this.<>4__this.ftuxRoot.SetActive(value:  false);
        this.<>4__this.ToggleTapToOpenLabel(isVisible:  true);
        RaidAttackScreenUI.ShowRaidScreen();
    }

}
