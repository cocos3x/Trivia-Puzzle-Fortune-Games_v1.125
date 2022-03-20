using UnityEngine;
public class GiftRewardUI_PetCard : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text cardName;
    private UnityEngine.UI.Image petCardIcon;
    private UnityEngine.GameObject levelGroup;
    private UnityEngine.UI.Text level;
    private UnityEngine.UI.Image progressBar;
    private UnityEngine.UI.Image upgradeFill;
    private UnityEngine.Sprite upgradeSp;
    private UnityEngine.Sprite inProgressSp;
    private UnityEngine.UI.Text upgradeProgress;
    private UnityEngine.GameObject upgradeArrow;
    
    // Methods
    public void Setup(WADPets.WADPet pet, decimal progressStartBalance, WADPets.WADPetUpgradeRequirement upgradeRequirement)
    {
        this.ResetUI();
        this.levelGroup.SetActive(value:  pet.IsUnlocked);
        string val_1 = pet.LevelIndex.ToString();
        this.petCardIcon.sprite = pet.Info.CardIcon;
        string val_4 = System.String.Format(format:  "{0} {1}", arg0:  pet.GetPrettyName(), arg1:  Localization.Localize(key:  "card_cap_first", defaultValue:  "Card", useSingularKey:  false));
        if((MonoSingleton<WADPetsManager>.Instance.IsPetMaxLevel(pet:  pet)) != true)
        {
                float val_11 = (float)upgradeRequirement.Cards;
            val_11 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = progressStartBalance.flags, hi = progressStartBalance.hi, lo = progressStartBalance.lo, mid = progressStartBalance.mid})) / val_11;
        }
        
        this.progressBar.fillAmount = UnityEngine.Mathf.Min(a:  val_11, b:  1f);
        var val_10 = ((this.progressBar.m_FillAmount.Equals(obj:  1f)) != true) ? 72 : 80;
        this.upgradeFill.sprite = null;
    }
    public void OnPetCardRewardAction(WADPets.WADPet pet, float endProgressValue, WADPets.WADPetUpgradeRequirement upgradeRequirement)
    {
        WADPets.WADPet val_14 = pet;
        GiftRewardUI_PetCard.<>c__DisplayClass11_0 val_1 = new GiftRewardUI_PetCard.<>c__DisplayClass11_0();
        .<>4__this = this;
        .endProgressValue = endProgressValue;
        if((MonoSingleton<WADPetsManager>.Instance.IsPetMaxLevel(pet:  val_14 = pet)) != false)
        {
                if(this.upgradeProgress != null)
        {
            goto label_6;
        }
        
        }
        
        val_14 = pet.Cards;
        string val_4 = System.String.Format(format:  "{0}/{1}", arg0:  pet.Cards, arg1:  upgradeRequirement.Cards);
        label_6:
        var val_6 = ((this.progressBar.m_FillAmount.Equals(obj:  1f)) != true) ? 72 : 80;
        this.upgradeFill.sprite = null;
        .progress = this.progressBar.m_FillAmount;
        DG.Tweening.Tweener val_13 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void GiftRewardUI_PetCard.<>c__DisplayClass11_0::<OnPetCardRewardAction>b__0(float x)), startValue:  this.progressBar.m_FillAmount, endValue:  (GiftRewardUI_PetCard.<>c__DisplayClass11_0)[1152921517575511616].endProgressValue, duration:  0.5f), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void GiftRewardUI_PetCard.<>c__DisplayClass11_0::<OnPetCardRewardAction>b__1())), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void GiftRewardUI_PetCard.<>c__DisplayClass11_0::<OnPetCardRewardAction>b__2()));
    }
    private void ResetUI()
    {
        this.upgradeArrow.SetActive(value:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public GiftRewardUI_PetCard()
    {
    
    }

}
