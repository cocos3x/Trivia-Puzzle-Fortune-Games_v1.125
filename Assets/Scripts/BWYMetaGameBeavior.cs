using UnityEngine;
public class BWYMetaGameBeavior : MetaGameBehavior
{
    // Properties
    public override string NotifImgUrlDailyBonus { get; }
    public override string NotifImgUrlPostAd { get; }
    public override bool supportsEvents { get; }
    public override bool supportsChallenges { get; }
    public override bool supportsGOTDPopup { get; }
    public override bool supportsSubscriptions { get; }
    public override bool supportsFriendInviter { get; }
    public override bool supportsRecaptureNotifications { get; }
    
    // Methods
    public override string GetShareTextScreenShot()
    {
        return "I found a new puzzle game! {0}";
    }
    public override string GetUrlSharePrefix()
    {
        return "https://{0}/";
    }
    public override bool AdsAllowedByScene()
    {
        var val_2;
        if(this != 2)
        {
                return (bool)(this == 9) ? 1 : 0;
        }
        
        val_2 = 1;
        return (bool)(this == 9) ? 1 : 0;
    }
    public override bool BannerAdsSkipPlayerLevelCheck()
    {
        var val_5;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) != 0)
        {
                if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CurrentGameMode) == 1)
        {
                return (bool)val_5;
        }
        
        }
        
        val_5 = 0;
        return (bool)val_5;
    }
    public override bool UsesSingleScene()
    {
        return false;
    }
    public override void OnClickHome()
    {
        goto typeof(BWYMetaGameBeavior).__il2cppRuntimeField_3D0;
    }
    public override string GetSceneNameFromSceneType(SceneType sceneType)
    {
        var val_2;
        var val_3;
        if(sceneType > 2)
        {
            goto label_1;
        }
        
        if(sceneType == 1)
        {
            goto label_2;
        }
        
        if(sceneType != 2)
        {
            goto label_6;
        }
        
        val_2 = "BlockBuilder_Game";
        return (string)val_2;
        label_1:
        if(sceneType == 6)
        {
            goto label_5;
        }
        
        if(sceneType == 9)
        {
                val_2 = "BlockBuilder_Zen";
            return (string)val_2;
        }
        
        label_6:
        val_3 = sceneType.ToString();
        return (string)val_2;
        label_2:
        val_2 = "BlockBuilder_Main";
        return (string)val_2;
        label_5:
        val_2 = "GameStoreScene";
        return (string)val_2;
    }
    public override SceneType getActiveSceneType()
    {
        var val_3;
        UnityEngine.SceneManagement.Scene val_1 = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        if(val_1.m_Handle.buildIndex < 4)
        {
                val_3 = mem[32560528 + (val_2) << 2];
            val_3 = 32560528 + (val_2) << 2;
            return (SceneType)val_3;
        }
        
        UnityEngine.Debug.LogError(message:  "unknown scene type!");
        val_3 = 3;
        return (SceneType)val_3;
    }
    public override string get_NotifImgUrlDailyBonus()
    {
        return "https://cdn.12gigs.com/BBL_RPNS/DailyReward.png";
    }
    public override string get_NotifImgUrlPostAd()
    {
        return "https://cdn.12gigs.com/BBL_RPNS/PostAdClick.png";
    }
    public override bool get_supportsEvents()
    {
        return false;
    }
    public override bool get_supportsChallenges()
    {
        return false;
    }
    public override bool get_supportsGOTDPopup()
    {
        return false;
    }
    public override bool get_supportsSubscriptions()
    {
        return false;
    }
    public override bool get_supportsFriendInviter()
    {
        return false;
    }
    public override bool get_supportsRecaptureNotifications()
    {
        return false;
    }
    public override void LoadScene(SceneType sceneToLoad, bool immediate = False)
    {
        CUtils.LoadSceneImmediate(sceneName:  this);
    }
    public override void AppendUserProperties(string eventName, ref System.Collections.Generic.Dictionary<string, object> userProperties)
    {
        if((System.String.IsNullOrEmpty(value:  "Android")) != true)
        {
                userProperties.Add(key:  "custom platform", value:  "Android");
        }
        
        BestBlocksPlayer val_2 = BestBlocksPlayer.Instance;
        userProperties.Add(key:  "Lifetime ZM Score", value:  val_2.zenModeScoreLifetime);
        userProperties.Add(key:  "Best ZM Score", value:  val_2.zenModeScoreBest);
        userProperties.Add(key:  "Lifetime Rotations Used", value:  val_2.lifetimeRotationsUsed);
    }
    public override void AppendCommonEventProperties(string eventName, ref System.Collections.Generic.Dictionary<string, object> eventProperties)
    {
        BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
        eventProperties.Add(key:  "Lives", value:  val_1.livesBalance);
    }
    public override bool GemsUnlocked()
    {
        return false;
    }
    public override System.Collections.Generic.List<PurchaseModel> FilterStoreCreditPacksPerGame(System.Collections.Generic.List<PurchaseModel> unfiltered)
    {
        var val_2;
        System.Predicate<PurchaseModel> val_4;
        val_2 = null;
        val_2 = null;
        val_4 = BWYMetaGameBeavior.<>c.<>9__28_0;
        if(val_4 != null)
        {
                return unfiltered.FindAll(match:  System.Predicate<PurchaseModel> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Predicate<PurchaseModel>(object:  BWYMetaGameBeavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean BWYMetaGameBeavior.<>c::<FilterStoreCreditPacksPerGame>b__28_0(PurchaseModel p));
        BWYMetaGameBeavior.<>c.<>9__28_0 = val_4;
        return unfiltered.FindAll(match:  val_1);
    }
    public BWYMetaGameBeavior()
    {
    
    }

}
