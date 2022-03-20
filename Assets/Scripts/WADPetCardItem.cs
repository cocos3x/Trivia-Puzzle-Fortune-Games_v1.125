using UnityEngine;
public class WADPetCardItem : MyButton
{
    // Fields
    private UnityEngine.UI.Image bg;
    private UnityEngine.Sprite unselectedSp;
    private UnityEngine.Sprite selectedSp;
    private UnityEngine.GameObject thinkBubble;
    private UnityEngine.UI.Image petImage;
    private Spine.Unity.SkeletonGraphic petAnim;
    private UnityEngine.GameObject levelGroup;
    private UnityEngine.UI.Text level;
    private UnityEngine.UI.Image progressBar;
    private UnityEngine.UI.Image progressFill;
    private UnityEngine.Sprite progressFillSp;
    private UnityEngine.Sprite upgradeFillSp;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.GameObject upgradeArrow;
    private WADPets.WADPet thisPet;
    private bool isHighlighted;
    
    // Methods
    public void Setup(WADPets.WADPet pet, bool highlight = False)
    {
        this.ResetUI();
        bool val_1 = highlight;
        this.thisPet = pet;
        this.isHighlighted = val_1;
        this.UpdateProgress(pet:  pet);
        this.UpdateBackground(highlight:  val_1);
        this.UpdatePet(pet:  pet);
    }
    public void UpdateCard(WADPets.WADPet highlightedPet)
    {
        this.ResetUI();
        this.isHighlighted = (this.thisPet == highlightedPet) ? 1 : 0;
        this.UpdateProgress(pet:  this.thisPet);
        this.UpdateBackground(highlight:  this.isHighlighted);
        this.UpdatePet(pet:  this.thisPet);
    }
    public override void OnButtonClick()
    {
        this.OnButtonClick();
        if(this.isHighlighted != false)
        {
                return;
        }
        
        MonoSingleton<PetsScreenMain>.Instance.Refresh(highlightPet:  this.thisPet);
        this.bg.sprite = this.selectedSp;
    }
    private void ResetUI()
    {
        this.bg.sprite = this.unselectedSp;
        this.thinkBubble.SetActive(value:  false);
        this.levelGroup.SetActive(value:  false);
        this.petImage.gameObject.SetActive(value:  false);
        this.petAnim.gameObject.SetActive(value:  false);
    }
    private void UpdateProgress(WADPets.WADPet pet)
    {
        var val_15;
        string val_1 = pet.LevelIndex.ToString();
        this.level.gameObject.SetActive(value:  (pet.LevelIndex > 0) ? 1 : 0);
        WADPets.WADPetUpgradeRequirement val_4 = WADPetsManager.GetUpgradeRequirement(levelIndex:  pet.LevelIndex);
        if(pet.LevelIndex != (MonoSingleton<WADPetsManager>.Instance.GetMaxLevel()))
        {
                float val_15 = (float)pet.Cards;
            val_15 = val_15 / (float)val_4.Cards;
        }
        
        this.progressBar.fillAmount = UnityEngine.Mathf.Min(a:  val_15, b:  1f);
        val_15 = mem[pet.LevelIndex];
        val_15 = pet.LevelIndex;
        if(val_15 == (MonoSingleton<WADPetsManager>.Instance.GetMaxLevel()))
        {
                if(this.progressText != null)
        {
            goto label_17;
        }
        
        }
        
        val_15 = 1152921504619999232;
        string val_10 = System.String.Format(format:  "{0}/{1}", arg0:  pet.Cards, arg1:  val_4.Cards);
        label_17:
        this.upgradeArrow.SetActive(value:  this.progressBar.m_FillAmount.Equals(obj:  1f));
        var val_14 = ((this.progressBar.m_FillAmount.Equals(obj:  1f)) != true) ? 128 : 120;
        this.progressFill.sprite = null;
    }
    private void UpdateBackground(bool highlight)
    {
        if(this.bg != null)
        {
                var val_1 = (highlight != true) ? 56 : 48;
            this.bg.sprite = null;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void UpdatePet(WADPets.WADPet pet)
    {
        var val_14;
        var val_15;
        val_14 = pet;
        val_15 = this;
        if(pet.IsUnlocked == false)
        {
            goto label_2;
        }
        
        if(val_14.IsActive() == false)
        {
            goto label_3;
        }
        
        this.petAnim.gameObject.SetActive(value:  true);
        this.petAnim.skeletonDataAsset = pet.Info.AnimIdleSkeletonDataAsset;
        this.petAnim.Initialize(overwrite:  true);
        this.petAnim.startingAnimation = "Idle";
        Spine.TrackEntry val_3 = this.petAnim.state.SetAnimation(trackIndex:  0, animationName:  this.petAnim.startingAnimation, loop:  true);
        this.petAnim.skeleton.SetSlotsToSetupPose();
        UnityEngine.Color val_4 = UnityEngine.Color.white;
        this.petAnim.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
        this.petAnim.freeze = false;
        goto label_16;
        label_2:
        this.petAnim.gameObject.SetActive(value:  true);
        this.petAnim.skeletonDataAsset = pet.Info.AnimIdleSkeletonDataAsset;
        this.petAnim.Initialize(overwrite:  true);
        this.petAnim.startingAnimation = "Idle";
        Spine.TrackEntry val_6 = this.petAnim.state.SetAnimation(trackIndex:  0, animationName:  this.petAnim.startingAnimation, loop:  false);
        this.petAnim.skeleton.SetSlotsToSetupPose();
        UnityEngine.Color val_7 = UnityEngine.Color.black;
        this.petAnim.color = new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a};
        this.petAnim.freeze = true;
        val_14 = ???;
        val_15 = ???;
        goto typeof(Spine.Unity.SkeletonGraphic).__il2cppRuntimeField_600;
        label_3:
        val_15 + 72.sprite = val_14 + 16 + 48;
        val_15 + 72.gameObject.SetActive(value:  true);
        val_15 + 64.SetActive(value:  true);
        label_16:
        val_15 + 88.SetActive(value:  true);
    }
    public WADPetCardItem()
    {
    
    }

}
