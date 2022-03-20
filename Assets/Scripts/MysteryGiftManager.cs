using UnityEngine;
public class MysteryGiftManager : MonoSingleton<MysteryGiftManager>
{
    // Fields
    private bool recentlyLeveledUp;
    
    // Methods
    public void OnPlayerLevelUp()
    {
        this.recentlyLeveledUp = true;
    }
    public void OnSceneChange()
    {
        GameBehavior val_1 = App.getBehavior;
        GameEcon val_2 = App.getGameEcon;
        if((val_1.<metaGameBehavior>k__BackingField) != val_2.mysteryGiftUnlockLevel)
        {
                return;
        }
        
        if(WGSubscriptionManager.WillGetFreeTrial_Golden == false)
        {
                return;
        }
        
        if(WGSubscriptionManager.HasSubscribedGoldenTicket == true)
        {
                return;
        }
        
        Player val_5 = App.Player;
        if(val_5.properties.MysteryGiftReceived != false)
        {
                return;
        }
        
        if(this.recentlyLeveledUp == false)
        {
                return;
        }
        
        WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMysteryGiftPopup>(showNext:  false);
        Player val_8 = App.Player;
        val_8.properties.MysteryGiftReceived = true;
        Player val_9 = App.Player;
        val_9.properties.Save(writePrefs:  true);
    }
    public void OnGameSceneBegan()
    {
        GameBehavior val_1 = App.getBehavior;
        GameEcon val_2 = App.getGameEcon;
        if((val_1.<metaGameBehavior>k__BackingField) < val_2.mysteryGiftUnlockLevel)
        {
                GameEcon val_3 = App.getGameEcon;
            int val_12 = val_3.mysteryGiftFlyoutLevelInterval;
            val_12 = (val_1.<metaGameBehavior>k__BackingField) - (((val_1.<metaGameBehavior>k__BackingField) / val_12) * val_12);
            if((val_12 == null) && (WGSubscriptionManager.WillGetFreeTrial_Golden != false))
        {
                if((WGSubscriptionManager.HasSubscribedGoldenTicket != true) && (this.recentlyLeveledUp != false))
        {
                GameEcon val_9 = App.getGameEcon;
            bool val_11 = MonoSingleton<MysteryGiftFlyoutMessage>.Instance.ShowMessage(message:  System.String.Format(format:  Localization.Localize(key:  "mystery_gift_reach_level", defaultValue:  "Reach Level {0} to receive a Mystery Gift!", useSingularKey:  false), arg0:  val_9.mysteryGiftUnlockLevel));
        }
        
        }
        
        }
        
        this.recentlyLeveledUp = false;
    }
    public MysteryGiftManager()
    {
    
    }

}
