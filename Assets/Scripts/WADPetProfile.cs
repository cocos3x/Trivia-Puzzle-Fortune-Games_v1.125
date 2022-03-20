using UnityEngine;
public class WADPetProfile : FrameSkipper
{
    // Fields
    private UnityEngine.UI.Text petName;
    private UnityEngine.UI.Text description;
    private UnityEngine.GameObject thinkBubble;
    private UnityEngine.UI.Image petImage;
    private Spine.Unity.SkeletonGraphic petAnim;
    private UnityEngine.GameObject levelupAnim;
    private UnityEngine.GameObject foodIcon;
    private UnityEngine.UI.Text feedButtonText;
    private UnityEngine.UI.Button feedButton;
    private UnityEngine.Transform feedArrow;
    private UnityEngine.GameObject unlockNow;
    private UnityEngine.GameObject upgradeCostGroup;
    private UnityEngine.UI.Text upgradeCost;
    private UnityEngine.UI.Text upgradeProgressText;
    private UnityEngine.UI.Button upgradeButton;
    private UnityEngine.Transform upgradeArrow;
    private WADPets.WADPet thisPet;
    private DG.Tweening.Sequence feedArrowSequence;
    private DG.Tweening.Sequence upgradeArrowSequence;
    private DG.Tweening.Tweener foodIconTweener;
    
    // Methods
    public void Setup(WADPets.WADPet pet)
    {
        this.ResetUI();
        this.thisPet = pet;
        mem[1152921516773081320] = 0;
        this.UpdatePetBasicInfo(pet:  pet);
        this.UpdatePetStatus(pet:  pet);
    }
    private System.Collections.IEnumerator ShowLevelupAnim()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WADPetProfile.<ShowLevelupAnim>d__21();
    }
    private System.Collections.IEnumerator ShowUpgradeArrow()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WADPetProfile.<ShowUpgradeArrow>d__22();
    }
    private System.Collections.IEnumerator ShowFeedArrow()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WADPetProfile.<ShowFeedArrow>d__23();
    }
    private void UpdateTimer()
    {
        object val_18;
        System.TimeSpan val_2 = MonoSingleton<WADPetsManager>.Instance.GetTimeCountdownToNextFeed();
        double val_3 = val_2._ticks.TotalDays;
        val_3 = (val_3 == Infinity) ? (-val_3) : (val_3);
        if((int)val_3 != 0)
        {
                val_18 = val_2._ticks.Days.ToString(format:  "0");
            string val_10 = System.String.Format(format:  "{0}d {1}h {2}m", arg0:  val_18, arg1:  val_2._ticks.Hours.ToString(format:  "00"), arg2:  val_2._ticks.Minutes.ToString(format:  "00"));
        }
        else
        {
                val_18 = val_2._ticks.Hours.ToString(format:  "00");
            string val_15 = System.String.Format(format:  "{0}h {1}m", arg0:  val_18, arg1:  val_2._ticks.Minutes.ToString(format:  "00"));
        }
        
        if(val_2._ticks.TotalSeconds >= 0)
        {
                return;
        }
        
        mem[1152921516773599048] = 0;
        MonoSingleton<PetsScreenMain>.Instance.Refresh(highlightPet:  0);
    }
    private void ResetUI()
    {
        this.petImage.gameObject.SetActive(value:  false);
        this.petAnim.gameObject.SetActive(value:  false);
        this.upgradeProgressText.gameObject.SetActive(value:  false);
        this.upgradeCostGroup.SetActive(value:  false);
        this.unlockNow.SetActive(value:  false);
        this.thinkBubble.SetActive(value:  false);
        this.feedArrow.gameObject.SetActive(value:  false);
        this.upgradeArrow.gameObject.SetActive(value:  false);
        this.feedButton.interactable = false;
        this.StopAllCoroutines();
        int val_6 = DG.Tweening.DOTween.Kill(targetOrId:  this.foodIconTweener, complete:  false);
        int val_7 = DG.Tweening.DOTween.Kill(targetOrId:  this.upgradeArrowSequence, complete:  false);
        int val_8 = DG.Tweening.DOTween.Kill(targetOrId:  this.feedArrowSequence, complete:  false);
    }
    private void UpdatePetBasicInfo(WADPets.WADPet pet)
    {
        var val_5;
        UnityEngine.UI.Text val_6;
        var val_7;
        val_5 = pet.Info.Name;
        string val_1 = pet.Info.Name.ToString();
        mem2[0] = pet.Info.Name;
        val_6 = 1152921504884269056;
        val_7 = null;
        val_7 = null;
        if(App.game == 1)
        {
                val_6 = this.petName;
            val_5 = pet.Info.Name;
            mem2[0] = pet.Info.Name;
            string val_3 = System.String.Format(format:  "• {0} •", arg0:  pet.Info.Name.ToString());
        }
        
        string val_4 = WADPetsManager.GetAbilityDescription(pet:  pet);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void UpdatePetStatus(WADPets.WADPet pet)
    {
        UnityEngine.Events.UnityAction val_32;
        object val_33;
        .<>4__this = this;
        .pet = pet;
        this.feedButtonText.horizontalOverflow = 0;
        this.feedButtonText.resizeTextMaxSize = 35;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  0.8f, y:  0.8f, z:  1f);
        this.foodIcon.transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        if(WADPetsManager.IsAnyPetUnlocked() == false)
        {
            goto label_6;
        }
        
        if(WADPetsManager.IsAnyPetHungry() == false)
        {
            goto label_8;
        }
        
        this.foodIcon.SetActive(value:  true);
        string val_6 = Localization.Localize(key:  "feed_all_pets_upper_formatted", defaultValue:  "FEED ALL\nPETS", useSingularKey:  false);
        this.feedButton.m_OnClick.RemoveAllListeners();
        this.feedButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetProfile::OnClick_FeedAllPets()));
        this.feedButton.interactable = true;
        goto label_18;
        label_6:
        this.foodIcon.SetActive(value:  true);
        string val_8 = Localization.Localize(key:  "feed_all_pets_upper_formatted", defaultValue:  "FEED ALL\nPETS", useSingularKey:  false);
        goto label_18;
        label_8:
        this.foodIcon.SetActive(value:  false);
        this.feedButtonText.horizontalOverflow = 1;
        this.feedButtonText.resizeTextMaxSize = 40;
        mem[1152921516774585976] = new System.Action(object:  this, method:  System.Void WADPetProfile::UpdateTimer());
        label_18:
        WADPets.WADPetUpgradeRequirement val_10 = WADPetsManager.GetUpgradeRequirement(levelIndex:  (WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.LevelIndex);
        this.upgradeButton.interactable = (((WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.Cards) >= val_10.Cards) ? 1 : 0;
        this.upgradeButton.m_OnClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction val_12 = null;
        val_32 = val_12;
        val_12 = new UnityEngine.Events.UnityAction(object:  new WADPetProfile.<>c__DisplayClass27_0(), method:  System.Void WADPetProfile.<>c__DisplayClass27_0::<UpdatePetStatus>b__0());
        this.upgradeButton.m_OnClick.AddListener(call:  val_12);
        if(((WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.IsUnlocked) == false)
        {
            goto label_30;
        }
        
        val_33 = Localization.Localize(key:  "upgrade_upper", defaultValue:  "UPGRADE", useSingularKey:  false);
        if(((WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.IsActive()) == false)
        {
            goto label_31;
        }
        
        this.petAnim.gameObject.SetActive(value:  true);
        this.petAnim.skeletonDataAsset = (WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.Info.AnimIdleSkeletonDataAsset;
        this.petAnim.Initialize(overwrite:  true);
        this.petAnim.startingAnimation = "Idle";
        Spine.TrackEntry val_16 = this.petAnim.state.SetAnimation(trackIndex:  0, animationName:  this.petAnim.startingAnimation, loop:  true);
        this.petAnim.skeleton.SetSlotsToSetupPose();
        UnityEngine.Color val_17 = UnityEngine.Color.white;
        this.petAnim.color = new UnityEngine.Color() {r = val_17.r, g = val_17.g, b = val_17.b, a = val_17.a};
        this.petAnim.freeze = false;
        goto label_69;
        label_30:
        this.petAnim.gameObject.SetActive(value:  true);
        this.petAnim.skeletonDataAsset = (WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.Info.AnimIdleSkeletonDataAsset;
        this.petAnim.Initialize(overwrite:  true);
        this.petAnim.startingAnimation = "Idle";
        Spine.TrackEntry val_19 = this.petAnim.state.SetAnimation(trackIndex:  0, animationName:  this.petAnim.startingAnimation, loop:  false);
        this.petAnim.skeleton.SetSlotsToSetupPose();
        UnityEngine.Color val_20 = UnityEngine.Color.black;
        this.petAnim.color = new UnityEngine.Color() {r = val_20.r, g = val_20.g, b = val_20.b, a = val_20.a};
        this.petAnim.freeze = true;
        if(((WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.Cards) < val_10.Cards)
        {
            goto label_60;
        }
        
        this.unlockNow.SetActive(value:  true);
        UnityEngine.Coroutine val_22 = this.StartCoroutine(routine:  this.ShowUpgradeArrow());
        return;
        label_31:
        this.petImage.sprite = (WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.Info.SadFaceIcon;
        this.petImage.gameObject.SetActive(value:  true);
        this.thinkBubble.SetActive(value:  true);
        goto label_69;
        label_60:
        val_33 = Localization.Localize(key:  "locked_upper", defaultValue:  "LOCKED", useSingularKey:  false);
        label_69:
        val_32 = this.upgradeButton.gameObject;
        val_32.SetActive(value:  (((WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.LevelIndex) != (MonoSingleton<WADPetsManager>.Instance.GetMaxLevel())) ? 1 : 0);
        if(((WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.Cards) < val_10.Cards)
        {
            goto label_76;
        }
        
        string val_29 = val_10.Coins.ToString();
        if(this.upgradeCostGroup != null)
        {
            goto label_78;
        }
        
        label_76:
        val_32 = (WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.Cards;
        string val_30 = System.String.Format(format:  "{0}\n{1}/{2}", arg0:  val_33, arg1:  (WADPetProfile.<>c__DisplayClass27_0)[1152921516774622032].pet.Cards, arg2:  val_10.Cards);
        label_78:
        this.upgradeProgressText.gameObject.SetActive(value:  true);
    }
    private void OnClick_FeedAllPets()
    {
        if((MonoSingleton<WADPetsManager>.Instance.FeedAllPets()) != false)
        {
                WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.GetWindow<WADPetsFeedFoodPopup>();
            if(val_4.isActiveAndEnabled != false)
        {
                SLCWindow.CloseWindow(window:  val_4.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        
            MonoSingleton<PetsScreenMain>.Instance.Refresh(highlightPet:  this.thisPet);
            return;
        }
        
        GameBehavior val_8 = App.getBehavior;
        val_8.<metaGameBehavior>k__BackingField.Init(type:  0);
    }
    public WADPetProfile()
    {
    
    }

}
