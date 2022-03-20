using UnityEngine;
private sealed class DailyChallengeTutorialLobbyHelper.<WaitAndShowOverlay>d__5 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public DailyChallengeTutorialLobbyHelper <>4__this;
    public System.Collections.Generic.List<UnityEngine.Transform> overlayContents;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DailyChallengeTutorialLobbyHelper.<WaitAndShowOverlay>d__5(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_15;
        int val_16;
        var val_17;
        val_15 = this;
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
            goto label_28;
        }
        
        this.<>1__state = 0;
        val_16 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_16;
        return (bool)val_16;
        label_2:
        this.<>1__state = 0;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = 2;
        val_16 = 1;
        return (bool)val_16;
        label_1:
        this.<>1__state = 0;
        GameBehavior val_3 = App.getBehavior;
        val_17 = val_3.<metaGameBehavior>k__BackingField;
        GameBehavior val_4 = App.getBehavior;
        if((val_17 == 1) && (((val_4.<metaGameBehavior>k__BackingField) & 1) == 0))
        {
                DynamicToolTip val_6 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
            this.<>4__this.TT = val_6;
            val_17 = val_6.gameObject;
            this.<>4__this.TT.ShowToolTip(objToToolTip:  this.<>4__this.dailyChallengeButton.gameObject, text:  Localization.Localize(key:  "dc_ftux_home", defaultValue:  "Play a new puzzle twice a day and earn rewards!", useSingularKey:  false), topToolTip:  true, displayDuration:  -1f, width:  800f, height:  250f, tooltipOffsetX:  35f, tooltipOffsetY:  10f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
            this.overlayContents.Add(item:  val_17.gameObject.transform);
            val_15 = MonoSingleton<GameMaskOverlay>.Instance;
            val_15.ShowOverlay(contentToOverlay:  this.overlayContents.ToArray());
        }
        else
        {
                SLCWindow.CloseWindow(window:  this.<>4__this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        
        label_28:
        val_16 = 0;
        return (bool)val_16;
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
