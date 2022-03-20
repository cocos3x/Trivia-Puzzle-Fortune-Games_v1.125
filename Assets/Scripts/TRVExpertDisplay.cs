using UnityEngine;
public class TRVExpertDisplay : MonoBehaviour
{
    // Fields
    private readonly UnityEngine.Color barBlue;
    private readonly UnityEngine.Color barPink;
    private UnityEngine.UI.Image backgroundImage;
    private UnityEngine.UI.Image expertImage;
    private UnityEngine.UI.Image lockImage;
    private UnityEngine.UI.Image fillBarMask;
    private UnityEngine.UI.Text expertName;
    private UnityEngine.UI.Text expertLevel;
    private UnityEngine.UI.Text expertCards;
    private System.Collections.Generic.List<TRVExpertProficiencyDisplay> proficiencyDisplays;
    private UnityEngine.UI.Image upgradeImage;
    private UnityEngine.Sprite commonBG;
    private UnityEngine.Sprite uncommonBG;
    private UnityEngine.Sprite rareBG;
    private UnityEngine.Sprite epicBG;
    private UnityEngine.GameObject levelUpBar;
    
    // Methods
    public void Init(TRVExpert me, TRVExpertProgressData progress, bool upgraded = False, bool showName = True)
    {
        var val_39;
        UnityEngine.UI.Image val_40;
        System.Collections.Generic.List<TRVExpertProficiencyDisplay> val_46;
        var val_47;
        TRVCategoryProficiencies val_48;
        if((UnityEngine.Object.op_Implicit(exists:  this.expertName)) != false)
        {
                this.expertName.gameObject.SetActive(value:  showName);
            string val_4 = me.GetLocalizedName;
        }
        
        this.expertImage.sprite = me.mySprite;
        if((UnityEngine.Object.op_Implicit(exists:  this.lockImage)) == false)
        {
            goto label_13;
        }
        
        UnityEngine.GameObject val_6 = this.lockImage.gameObject;
        if(progress == null)
        {
            goto label_15;
        }
        
        val_39 = (progress.<unlocked>k__BackingField) ^ 1;
        if(val_6 != null)
        {
            goto label_16;
        }
        
        label_15:
        val_39 = 1;
        label_16:
        val_6.SetActive(value:  (val_39 != 0) ? 1 : 0);
        label_13:
        if((progress != null) && ((progress.<unlocked>k__BackingField) != false))
        {
                val_40 = this.backgroundImage;
        }
        else
        {
                val_40 = this;
            UnityEngine.Color32 val_8 = new UnityEngine.Color32(r:  100, g:  100, b:  100, a:  255);
            UnityEngine.Color val_9 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_8.r, g = val_8.r, b = val_8.r, a = val_8.r});
            this.backgroundImage.color = new UnityEngine.Color() {r = val_9.r, g = val_9.g, b = val_9.b, a = val_9.a};
            UnityEngine.Color32 val_10 = new UnityEngine.Color32(r:  100, g:  100, b:  100, a:  255);
            UnityEngine.Color val_11 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_10.r, g = val_10.r, b = val_10.r, a = val_10.r});
            this.expertImage.color = new UnityEngine.Color() {r = val_11.r, g = val_11.g, b = val_11.b, a = val_11.a};
            this.levelUpBar.SetActive(value:  false);
            if((UnityEngine.Object.op_Implicit(exists:  this.lockImage)) != false)
        {
                UnityEngine.Color32 val_13 = new UnityEngine.Color32(r:  100, g:  100, b:  100, a:  255);
            UnityEngine.Color val_14 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_13.r, g = val_13.r, b = val_13.r, a = val_13.r});
            this.lockImage.color = new UnityEngine.Color() {r = val_14.r, g = val_14.g, b = val_14.b, a = val_14.a};
        }
        
        }
        
        UnityEngine.Vector3 val_16 = UnityEngine.Vector3.one;
        null.transform.localScale = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
        TRVExpertRarites val_40 = me.rarity;
        val_40 = val_40 - 1;
        if(val_40 > 3)
        {
            goto label_39;
        }
        
        var val_41 = 32556192 + ((me.rarity - 1)) << 2;
        val_41 = val_41 + 32556192;
        goto (32556192 + ((me.rarity - 1)) << 2 + 32556192);
        label_39:
        if((UnityEngine.Object.op_Implicit(exists:  this.upgradeImage)) != false)
        {
                this.upgradeImage.gameObject.SetActive(value:  false);
        }
        
        TRVExpertsController val_22 = MonoSingleton<TRVExpertsController>.Instance;
        ExpertLevelReq val_23 = val_22.myEcon.getReqFromExpert(exp:  me, prog:  progress);
        if(progress == null)
        {
            goto label_55;
        }
        
        this.fillBarMask.gameObject.SetActive(value:  true);
        if((UnityEngine.Object.op_Implicit(exists:  this.expertCards)) == false)
        {
            goto label_59;
        }
        
        if(val_23 == null)
        {
            goto label_60;
        }
        
        string val_26 = System.String.Format(format:  "{0}/{1}", arg0:  progress.<cardsOwned>k__BackingField, arg1:  val_23.cardsNeeded);
        if(this.expertCards != null)
        {
            goto label_61;
        }
        
        label_55:
        this.fillBarMask.fillAmount = 0f;
        if((UnityEngine.Object.op_Implicit(exists:  this.expertCards)) != false)
        {
                string val_28 = System.String.Format(format:  "{0}/{1}", arg0:  0, arg1:  1);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.expertLevel)) != false)
        {
                string val_30 = me.totalDefault.ToString();
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.expertCards)) == false)
        {
            goto label_96;
        }
        
        string val_32 = System.String.Format(format:  "{0}/{1}", arg0:  0, arg1:  val_23.cardsNeeded);
        goto label_96;
        label_60:
        label_61:
        label_59:
        if((UnityEngine.Object.op_Implicit(exists:  this.expertLevel)) != false)
        {
                string val_35 = progress.level.ToString();
        }
        
        int val_43 = progress.<cardsOwned>k__BackingField;
        if(val_43 == 0)
        {
            goto label_82;
        }
        
        if((val_23 == null) || (val_43 >= val_23.cardsNeeded))
        {
            goto label_84;
        }
        
        float val_42 = (float)val_43;
        val_42 = val_42 / (float)val_23.cardsNeeded;
        this.fillBarMask.fillAmount = val_42;
        this.fillBarMask.color = new UnityEngine.Color() {r = this.barBlue, g = (float)val_23.cardsNeeded, b = val_19.z, a = 1.25f};
        goto label_96;
        label_84:
        this.fillBarMask.fillAmount = 1f;
        this.fillBarMask.color = new UnityEngine.Color() {r = this.barPink, g = val_19.y, b = val_19.z, a = 1.25f};
        if((val_23 == null) || ((UnityEngine.Object.op_Implicit(exists:  this.upgradeImage)) == false))
        {
            goto label_96;
        }
        
        this.upgradeImage.gameObject.SetActive(value:  true);
        goto label_96;
        label_82:
        this.fillBarMask.fillAmount = 0f;
        label_96:
        val_46 = this.proficiencyDisplays;
        var val_44 = 4;
        label_118:
        var val_38 = val_44 - 4;
        if(val_38 >= val_43)
        {
                return;
        }
        
        val_43 = val_43 & 4294967295;
        if(progress == null)
        {
            goto label_100;
        }
        
        if(val_38 >= val_43)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_47 = mem[(progress.<cardsOwned>k__BackingField & 4294967295) + 32];
        val_47 = (progress.<cardsOwned>k__BackingField & 4294967295) + 32;
        if(val_38 >= 1152921504765632512)
        {
            goto label_111;
        }
        
        if(val_38 >= val_43)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_48 = mem[(progress.<cardsOwned>k__BackingField & 4294967295) + 32];
        val_48 = (progress.<cardsOwned>k__BackingField & 4294967295) + 32;
        if(upgraded == false)
        {
            goto label_107;
        }
        
        val_47.UpdateProf(data:  val_48);
        goto label_115;
        label_100:
        if(val_38 >= val_43)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_47 = mem[(progress.<cardsOwned>k__BackingField & 4294967295) + 32];
        val_47 = (progress.<cardsOwned>k__BackingField & 4294967295) + 32;
        if(val_38 >= 1152921504765632512)
        {
            goto label_111;
        }
        
        if(val_38 >= val_43)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_48 = mem[(progress.<cardsOwned>k__BackingField & 4294967295) + 32];
        val_48 = (progress.<cardsOwned>k__BackingField & 4294967295) + 32;
        label_107:
        val_47.DisplayProf(data:  val_48);
        goto label_115;
        label_111:
        val_47.gameObject.SetActive(value:  false);
        label_115:
        val_46 = this.proficiencyDisplays;
        val_44 = val_44 + 1;
        if(val_46 != null)
        {
            goto label_118;
        }
        
        throw new NullReferenceException();
    }
    public void AnimateCardProgress(TRVExpert me, TRVExpertProgressData progress)
    {
        TRVExpert val_17;
        int val_18;
        int val_19;
        val_17 = me;
        if(progress == null)
        {
                return;
        }
        
        this.fillBarMask.gameObject.SetActive(value:  true);
        TRVExpertsController val_2 = MonoSingleton<TRVExpertsController>.Instance;
        val_17 = val_2.myEcon.getReqFromExpert(exp:  val_17, prog:  progress);
        if((UnityEngine.Object.op_Implicit(exists:  this.expertCards)) == false)
        {
            goto label_10;
        }
        
        if(val_17 == null)
        {
            goto label_11;
        }
        
        string val_5 = System.String.Format(format:  "{0}/{1}", arg0:  progress.<cardsOwned>k__BackingField, arg1:  val_3.cardsNeeded);
        if(this.expertCards != null)
        {
            goto label_12;
        }
        
        label_11:
        label_12:
        label_10:
        if((UnityEngine.Object.op_Implicit(exists:  this.expertLevel)) != false)
        {
                string val_8 = progress.level.ToString();
        }
        
        if(val_17 == null)
        {
                return;
        }
        
        val_18 = progress.<cardsOwned>k__BackingField;
        val_19 = val_3.cardsNeeded;
        if(val_18 == val_19)
        {
                PluginExtension.SetColorAlpha(graphic:  this.upgradeImage, a:  0f);
            val_18 = progress.<cardsOwned>k__BackingField;
            val_19 = val_3.cardsNeeded;
        }
        
        if(val_18 > val_19)
        {
                return;
        }
        
        val_18 = val_18 - 1;
        float val_17 = (float)val_18;
        val_17 = val_17 / (float)val_19;
        this.fillBarMask.fillAmount = val_17;
        this.fillBarMask.color = new UnityEngine.Color() {r = this.barBlue, g = (float)val_19};
        float val_18 = (float)progress.<cardsOwned>k__BackingField;
        val_18 = val_18 / (float)val_3.cardsNeeded;
        DG.Tweening.Tweener val_9 = DG.Tweening.ShortcutExtensions46.DOFillAmount(target:  this.fillBarMask, endValue:  val_18, duration:  0.5f);
        if((progress.<cardsOwned>k__BackingField) != val_3.cardsNeeded)
        {
                return;
        }
        
        DG.Tweening.Sequence val_10 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  val_10);
        DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_10, interval:  0.4f);
        DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_10, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.upgradeImage, endValue:  1f, duration:  0.2f));
        DG.Tweening.TweenCallback val_15 = null;
        val_17 = val_15;
        val_15 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void TRVExpertDisplay::<AnimateCardProgress>b__17_0());
        mem2[0] = val_17;
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenExtensions.Play<DG.Tweening.Sequence>(t:  val_10);
    }
    public TRVExpertDisplay()
    {
        UnityEngine.Color val_1 = new UnityEngine.Color(r:  0.2745098f, g:  0.627451f, b:  1f);
        this.barBlue = val_1.r;
        UnityEngine.Color val_2 = new UnityEngine.Color(r:  0.972549f, g:  0.3372549f, b:  1f);
        this.barPink = val_2.r;
    }
    private void <AnimateCardProgress>b__17_0()
    {
        UnityEngine.ParticleSystem val_3 = MonoSingleton<WGSFXController>.Instance.PlaySFX(reqType:  3, parent:  this.upgradeImage.rectTransform, playImmediate:  true);
    }

}
