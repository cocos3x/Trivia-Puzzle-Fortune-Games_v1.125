using UnityEngine;
public class GoldenApplesManager : MonoSingleton<GoldenApplesManager>
{
    // Fields
    public const string ON_BALANCE_UPDATE = "OnStarsUpdated";
    public static System.Action<int> OnAppleAwarded;
    
    // Properties
    public static bool GoldenAppleFtuxShow { get; }
    private bool goldenAppleFtuxShown { get; set; }
    
    // Methods
    public static bool get_GoldenAppleFtuxShow()
    {
        return MonoSingleton<GoldenApplesManager>.Instance.goldenAppleFtuxShown;
    }
    private bool get_goldenAppleFtuxShown()
    {
        return CPlayerPrefs.GetBool(key:  "gaFtuxShown", defaultValue:  false);
    }
    private void set_goldenAppleFtuxShown(bool value)
    {
        CPlayerPrefs.SetBool(key:  "gaFtuxShown", value:  true);
    }
    public virtual void CreditBalance(int earnedAmount, string source, bool ignoreSubscriptionBonus = False, string subSource, bool skipTrack = False, System.Collections.Generic.Dictionary<string, object> additionalParam)
    {
        string val_7;
        var val_8;
        var val_26;
        var val_27;
        val_26 = skipTrack;
        if((GoldenMultiplierManager.IsAvaialable != true) && (ignoreSubscriptionBonus != true))
        {
                int val_3 = (WGSubscriptionManager.GetAdditionalPoints(basePoints:  earnedAmount)) + earnedAmount;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = null;
        val_27 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor();
        val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(additionalParam == null)
        {
            goto label_39;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_6 = additionalParam.Keys.GetEnumerator();
        label_7:
        if(val_8.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_4.Add(key:  val_7, value:  additionalParam.Item[val_7]);
        goto label_7;
        label_5:
        val_27 = public System.Void Dictionary.KeyCollection.Enumerator<System.String, System.Object>::Dispose();
        val_8.Dispose();
        label_39:
        GameEcon val_12 = App.getGameEcon;
        bool val_13 = GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_12.goldenAppleFtuxLevel);
        if(val_13 != false)
        {
                if(val_13.goldenAppleFtuxShown != true)
        {
                MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGGoldenApplesInfoPopup>(showNext:  false).goldenAppleFtuxShown = false;
        }
        
        }
        
        App.Player.stars = val_3 + val_17._stars;
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGLeaderboardManager>.Instance)) != false)
        {
                MonoSingleton<WGLeaderboardManager>.Instance.UpdateGoldenCurrency(amount:  val_3);
        }
        
        if(((System.String.IsNullOrEmpty(value:  source)) != true) && (val_26 != true))
        {
                val_26 = App.Player;
            val_26.TrackNonCoinReward(source:  source, subSource:  subSource, rewardType:  "Golden Currency", rewardAmount:  val_3.ToString(), additionalParams:  val_4);
        }
        
        GoldenApplesManager.OnAppleAwarded.Invoke(obj:  val_3);
    }
    public void DebitBalance(int debitAmount, string source, System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        debitAmount = val_1._stars - debitAmount;
        App.Player.stars = debitAmount;
        App.Player.TrackGoldenCurrencySpent(amount:  debitAmount, source:  source, additionalParams:  additionalParams);
    }
    public GoldenApplesManager()
    {
    
    }

}
