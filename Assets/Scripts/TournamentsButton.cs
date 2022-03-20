using UnityEngine;
public class TournamentsButton : MonoBehaviour
{
    // Fields
    private bool useFlyout;
    private UGUINetworkedButton button_tournaments;
    private UnityEngine.UI.Text text_tournament_place;
    public System.Action<bool> ExternalClickCallback;
    
    // Methods
    private void Start()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_5;
        }
        
        if((MonoSingleton<TournamentsManager>.Instance) != 0)
        {
            goto label_10;
        }
        
        UnityEngine.Debug.LogError(message:  "TournamentsButton: TournamentsManager.Instance is null. Disabling");
        label_5:
        this.button_tournaments.gameObject.SetActive(value:  false);
        return;
        label_10:
        TournamentsManager val_5 = MonoSingleton<TournamentsManager>.Instance;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnTournamentUpdate, b:  new System.Action(object:  this, method:  System.Void TournamentsButton::UpdateButton()));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        val_5.OnTournamentUpdate = val_7;
        this.button_tournaments.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void TournamentsButton::HandleButtonClicked(bool isConnected));
        this.UpdateButton();
        return;
        label_19:
    }
    private void OnDestroy()
    {
        if((MonoSingleton<TournamentsManager>.Instance) == 0)
        {
                return;
        }
        
        TournamentsManager val_3 = MonoSingleton<TournamentsManager>.Instance;
        1152921504893161472 = val_3.OnTournamentUpdate;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action(object:  this, method:  System.Void TournamentsButton::UpdateButton()));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_3.OnTournamentUpdate = val_5;
        return;
        label_10:
    }
    private void HandleButtonClicked(bool isConnected)
    {
        var val_13;
        var val_14;
        string val_16;
        val_13 = this;
        if(this.ExternalClickCallback != null)
        {
                isConnected = isConnected;
            this.ExternalClickCallback.Invoke(obj:  isConnected);
            return;
        }
        
        if(isConnected == false)
        {
            goto label_2;
        }
        
        TournamentsManager val_1 = MonoSingleton<TournamentsManager>.Instance;
        if(val_1.currentTournamentInfo == null)
        {
            goto label_6;
        }
        
        if(this.useFlyout == false)
        {
            goto label_7;
        }
        
        GameBehavior val_2 = App.getBehavior;
        val_13 = ???;
        goto mem[(1152921504946249728 + (public TournamentsPopup MetaGameBehavior::ShowUGUIFlyOut<TournamentsPopup>().__il2cppRuntimeField_48) << 4) + 312];
        label_2:
        val_14 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        UnityEngine.GameObject val_6 = val_13.gameObject;
        val_16 = "Internet connection required. Please check your connection and try again!";
        goto label_16;
        label_6:
        val_14 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_16 = "Currently processing tournament results! Try again in a few minutes.";
        label_16:
        val_14.ShowToolTip(objToToolTip:  this.gameObject, text:  val_16, topToolTip:  true, displayDuration:  3.5f, width:  700f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
        return;
        label_7:
        GameBehavior val_10 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TournamentsPopup MetaGameBehavior::ShowUGUIMonolith<TournamentsPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    private void UpdateButton()
    {
        var val_11;
        var val_12;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_12 = null;
            val_12 = null;
            if(TournamentsManager.pp_last_tournament != null)
        {
                val_11 = 1152921504893161472;
            if((MonoSingleton<TournamentsManager>.Instance) != 0)
        {
                TournamentsManager val_4 = MonoSingleton<TournamentsManager>.Instance;
            if(val_4.currentTournamentInfo != null)
        {
                this.button_tournaments.gameObject.SetActive(value:  true);
            TournamentsManager val_6 = MonoSingleton<TournamentsManager>.Instance;
            int val_7 = val_6.currentTournamentInfo.myRank + 1;
            string val_9 = System.String.Format(format:  "{0}{1}", arg0:  val_7, arg1:  Ordinal.AddOrdinal(num:  val_7));
            return;
        }
        
        }
        
        }
        
        }
        
        this.button_tournaments.gameObject.SetActive(value:  false);
    }
    public TournamentsButton()
    {
    
    }

}
