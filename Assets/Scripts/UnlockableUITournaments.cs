using UnityEngine;
public class UnlockableUITournaments : WGUnlockableUIElement
{
    // Fields
    private UnityEngine.UI.Text text_tournament_place;
    private UnityEngine.GameObject placeTextBackground;
    private UGUINetworkedButton networkedButton;
    
    // Properties
    protected override int UnlockLevel { get; }
    protected override bool FeatureHidden { get; }
    
    // Methods
    private void Awake()
    {
        var val_4 = 0;
        this.networkedButton = ;
        if( == 0)
        {
                UnityEngine.Debug.LogError(message:  "Could not cast buttonToLock as a networked button!");
            return;
        }
        
        this.networkedButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void UnlockableUITournaments::OnNetworkedClick(bool isConnected));
    }
    protected override int get_UnlockLevel()
    {
        return 50;
    }
    protected override bool get_FeatureHidden()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return true;
        }
        
        return UnityEngine.Object.op_Equality(x:  MonoSingleton<TournamentsManager>.Instance, y:  0);
    }
    protected override void OnClickUnlocked()
    {
    
    }
    private void OnNetworkedClick(bool isConnected)
    {
        var val_12;
        var val_13;
        string val_15;
        string val_16;
        val_12 = this;
        if(isConnected == false)
        {
            goto label_1;
        }
        
        TournamentsManager val_1 = MonoSingleton<TournamentsManager>.Instance;
        if(val_1.currentTournamentInfo == null)
        {
            goto label_5;
        }
        
        GameBehavior val_2 = App.getBehavior;
        val_12 = ???;
        goto mem[(1152921504946249728 + (public TournamentsPopup MetaGameBehavior::ShowUGUIMonolith<TournamentsPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
        label_1:
        val_13 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        UnityEngine.GameObject val_6 = val_12.gameObject;
        val_15 = "tournament_connection";
        val_16 = "Internet connection required. Please check your connection and try again!";
        goto label_13;
        label_5:
        val_13 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_15 = "tournament_processing";
        val_16 = "Currently processing tournament results! Try again in a few minutes.";
        label_13:
        val_13.ShowToolTip(objToToolTip:  this.gameObject, text:  Localization.Localize(key:  val_15, defaultValue:  val_16, useSingularKey:  false), topToolTip:  true, displayDuration:  3.5f, width:  700f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }
    protected override void UpdateButton()
    {
        int val_10;
        var val_11;
        this.UpdateButton();
        string val_1 = Localization.Localize(key:  "tournament_upper", defaultValue:  "TOURNAMENT", useSingularKey:  false);
        this.placeTextBackground.SetActive(value:  false);
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        val_11 = null;
        val_11 = null;
        if(TournamentsManager.pp_last_tournament == null)
        {
                return;
        }
        
        val_10 = 1152921504893161472;
        if((MonoSingleton<TournamentsManager>.Instance) == 0)
        {
                return;
        }
        
        TournamentsManager val_5 = MonoSingleton<TournamentsManager>.Instance;
        if(val_5.currentTournamentInfo == null)
        {
                return;
        }
        
        TournamentsManager val_6 = MonoSingleton<TournamentsManager>.Instance;
        val_10 = val_6.currentTournamentInfo.myRank + 1;
        string val_8 = System.String.Format(format:  "{0}{1}", arg0:  val_10, arg1:  Ordinal.AddOrdinal(num:  val_10));
        this.placeTextBackground.SetActive(value:  true);
    }
    public UnlockableUITournaments()
    {
    
    }

}
