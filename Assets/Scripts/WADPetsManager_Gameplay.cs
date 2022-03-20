using UnityEngine;
public class WADPetsManager_Gameplay : MonoSingleton<WADPetsManager_Gameplay>
{
    // Methods
    private void OnSceneLoaded(SceneType sceneType)
    {
        if(sceneType != 2)
        {
                return;
        }
        
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.addOnLevelCompleteAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void WADPetsManager_Gameplay::OnLevelComplete(GameLevel level)));
    }
    private void OnSceneUnloaded(SceneType sceneType)
    {
    
    }
    private void OnLevelComplete(GameLevel level)
    {
        int val_13;
        UnityEngine.Component val_14;
        val_13 = level;
        val_14 = this;
        WADPets.WADPet val_1 = WADPetsManager.GetPetByAbility(ability:  2);
        if((val_1 != null) && (val_1.IsActive() != false))
        {
                val_13 = level.goldenApplesStreaks;
            float val_13 = (float)val_13;
            val_13 = (WADPetsManager.GetLevelCurveModifier(ability:  2)) * val_13;
            int val_4 = UnityEngine.Mathf.RoundToInt(f:  val_13);
            val_1.CachedValueModifier = (float)val_4;
            if(val_4 >= 1)
        {
                GoldenApplesManager val_5 = MonoSingleton<GoldenApplesManager>.Instance;
            float val_14 = val_1.CachedValueModifier;
            val_14 = (val_14 == Infinityf) ? (-(double)val_14) : ((double)val_14);
            val_13 = NotificationCenter.DefaultCenter;
            var val_8 = (val_1.CachedValueModifier == Infinityf) ? (-(double)val_1.CachedValueModifier) : ((double)val_1.CachedValueModifier);
            val_13.PostNotification(aSender:  this, aName:  "Notification_OnExtraGoldenCurrency", aData:  new System.Collections.Hashtable());
        }
        
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        val_14 = 1152921515420564304;
        MonoSingleton<WADPetsManager>.Instance.ResetPetStats();
        MonoSingleton<WADPetsManager>.Instance.SaveLevelTrackingInfo();
    }
    private void OnPetAlphabetTileSpawned()
    {
        var val_11;
        WADPets.WADPet val_12;
        var val_13;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        WADPets.WADPet val_2 = WADPetsManager.GetPetByAbility(ability:  3);
        val_11 = val_2;
        if(val_2.IsActive() == false)
        {
                return;
        }
        
        if(val_2.IsFtuxShown != false)
        {
                return;
        }
        
        val_2.IsFtuxShown = true;
        if((MonoSingleton<WGWindowManager>.Instance.GetWindow<WADPetsFtuxPopup>().isActiveAndEnabled) != false)
        {
                val_12 = val_11;
        }
        else
        {
                val_13 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WADPetsFtuxPopup>(showNext:  false);
            val_12 = WADPetsManager.GetPetByAbility(ability:  3);
        }
        
        val_13.AddPetAlphabetTileFtux(pet:  val_12);
    }
    private void OnAlphabetTileCollected()
    {
        MonoSingleton<WADPetsManager>.Instance.Tracking_GainedBonusAlphabetTile();
    }
    private void OnVideoResponse(Notification notif)
    {
        Notification val_6 = notif;
        if(val_6 == null)
        {
                return;
        }
        
        if(notif.data == null)
        {
                return;
        }
        
        if((notif.data & 1) != 0)
        {
                return;
        }
        
        val_6 = notif.data.ToString();
        if((System.Boolean.Parse(value:  val_6)) == false)
        {
                return;
        }
        
        WADPets.WADPet val_3 = WADPetsManager.GetPetByAbility(ability:  4);
        if(val_3 == null)
        {
                return;
        }
        
        val_6 = val_3;
        if(val_3.IsActive() == false)
        {
                return;
        }
        
        val_3.CachedValueModifier = WADPetsManager.GetLevelCurveModifier(ability:  4);
    }
    public override void InitMonoSingleton()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WADPetsManager_Gameplay::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnSceneUnloaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WADPetsManager_Gameplay::OnSceneUnloaded(SceneType sceneType)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_4.OnSceneUnloaded = val_6;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        return;
        label_8:
    }
    private void Start()
    {
        if((MonoSingleton<Alphabet2Manager>.Instance) == 0)
        {
                return;
        }
        
        Alphabet2Manager val_3 = MonoSingleton<Alphabet2Manager>.Instance;
        System.Delegate val_5 = System.Delegate.Combine(a:  val_3.OnPetAlphabetTileSpawned, b:  new System.Action(object:  this, method:  System.Void WADPetsManager_Gameplay::OnPetAlphabetTileSpawned()));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        val_3.OnPetAlphabetTileSpawned = val_5;
        Alphabet2Manager val_6 = MonoSingleton<Alphabet2Manager>.Instance;
        1152921504893161472 = val_6.OnAlphabetTileCollected;
        System.Delegate val_8 = System.Delegate.Combine(a:  1152921504893161472, b:  new System.Action(object:  this, method:  System.Void WADPetsManager_Gameplay::OnAlphabetTileCollected()));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        val_6.OnAlphabetTileCollected = val_8;
        return;
        label_13:
    }
    private void TrackFreeHints()
    {
        Prefs.UsedHint(free:  true);
    }
    public WADPetsManager_Gameplay()
    {
    
    }

}
