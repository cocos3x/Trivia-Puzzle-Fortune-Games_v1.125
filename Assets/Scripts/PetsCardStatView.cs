using UnityEngine;
public class PetsCardStatView : CurrencyStatView
{
    // Fields
    public const string PETS_CARD_STAT_UPDATE = "PetsCardStatViewUpdate";
    private UnityEngine.UI.Text cardName;
    private UnityEngine.UI.Image petCardIcon;
    private UnityEngine.UI.Image progressBar;
    private UnityEngine.UI.Image upgradeFill;
    private UnityEngine.Sprite upgradeSp;
    private UnityEngine.Sprite inProgressSp;
    private UnityEngine.UI.Text upgradeProgress;
    private UnityEngine.GameObject upgradeArrow;
    private UnityEngine.GameObject levelGroup;
    private UnityEngine.UI.Text level;
    
    // Methods
    private void OnDiceRollsBalanceUpdated(Notification notif)
    {
        var val_4;
        if(notif.data != null)
        {
                val_4 = (System.Boolean.Parse(value:  notif.data.ToString())) ^ 1;
        }
        else
        {
                val_4 = 1;
        }
        
        var val_3 = val_4 & 1;
        goto typeof(PetsCardStatView).__il2cppRuntimeField_180;
    }
    protected override decimal GetCountUpBalance()
    {
        int val_4;
        var val_5;
        decimal val_6;
        var val_7;
        var val_8;
        val_4 = this;
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
            goto label_2;
        }
        
        val_5 = null;
        val_5 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = 41971712, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_5;
        }
        
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
        label_2:
        val_4 = 1152921504617017344;
        val_8 = null;
        val_8 = null;
        val_6 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
        label_5:
        val_4 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance();
        val_6 = val_4;
        val_7 = 0;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_6);
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
    }
    protected override string GetBalanceUpdateNotificationName()
    {
        return "PetsCardStatViewUpdate";
    }
    protected override void OnTouchAreaClicked()
    {
    
    }
    public void Setup(WADPets.WADPet pet, decimal progressStartBalance, WADPets.WADPetUpgradeRequirement upgradeRequirement)
    {
        if((MonoSingleton<WADPetsManager>.Instance.IsPetMaxLevel(pet:  pet)) != false)
        {
                if(this.upgradeProgress != null)
        {
            goto label_5;
        }
        
        }
        
        string val_3 = System.String.Format(format:  "{0}/{1}", arg0:  pet.Cards, arg1:  upgradeRequirement.Cards);
        label_5:
        WADPets.WADPetUpgradeRequirement val_4 = WADPetsManager.GetUpgradeRequirement(levelIndex:  pet.LevelIndex);
        float val_17 = (float)pet + 24 + 8;
        val_17 = val_17 / (float)val_4.Cards;
        this.upgradeArrow.SetActive(value:  ((UnityEngine.Mathf.Min(a:  val_17, b:  1f)) > 0.999f) ? 1 : 0);
        this.levelGroup.SetActive(value:  pet.IsUnlocked);
        string val_7 = pet + 24.ToString();
        this.petCardIcon.sprite = pet.Info.CardIcon;
        string val_10 = System.String.Format(format:  "{0} {1}", arg0:  pet.GetPrettyName(), arg1:  Localization.Localize(key:  "card_cap_first", defaultValue:  "Card", useSingularKey:  false));
        if((MonoSingleton<WADPetsManager>.Instance.IsPetMaxLevel(pet:  pet)) != true)
        {
                float val_18 = (float)upgradeRequirement.Cards;
            val_18 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = progressStartBalance.flags, hi = progressStartBalance.hi, lo = progressStartBalance.lo, mid = progressStartBalance.mid})) / val_18;
        }
        
        this.progressBar.fillAmount = UnityEngine.Mathf.Min(a:  val_18, b:  1f);
        var val_16 = ((this.progressBar.m_FillAmount.Equals(obj:  1f)) != true) ? 136 : 144;
        this.upgradeFill.sprite = null;
    }
    public void OnPetCardRewardAction(WADPets.WADPet pet, float endProgressValue, WADPets.WADPetUpgradeRequirement upgradeRequirement)
    {
        WADPets.WADPet val_14 = pet;
        PetsCardStatView.<>c__DisplayClass16_0 val_1 = new PetsCardStatView.<>c__DisplayClass16_0();
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
        var val_6 = ((this.progressBar.m_FillAmount.Equals(obj:  1f)) != true) ? 136 : 144;
        this.upgradeFill.sprite = null;
        .progress = this.progressBar.m_FillAmount;
        DG.Tweening.Tweener val_13 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void PetsCardStatView.<>c__DisplayClass16_0::<OnPetCardRewardAction>b__0(float x)), startValue:  this.progressBar.m_FillAmount, endValue:  (PetsCardStatView.<>c__DisplayClass16_0)[1152921516731766048].endProgressValue, duration:  0.5f), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void PetsCardStatView.<>c__DisplayClass16_0::<OnPetCardRewardAction>b__1())), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void PetsCardStatView.<>c__DisplayClass16_0::<OnPetCardRewardAction>b__2()));
    }
    public PetsCardStatView()
    {
    
    }

}
