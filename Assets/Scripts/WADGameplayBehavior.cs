using UnityEngine;
public class WADGameplayBehavior : GameplayBehavior
{
    // Methods
    public override bool SupportsHintTutorials()
    {
        return true;
    }
    public override void OnClick_UseHint()
    {
        WordRegion val_2 = WordRegion.instance;
        bool val_3 = WGHintButtonDemoPopup.IsShowing;
        if((this & 1) == 0)
        {
                return;
        }
        
        WordRegion.instance.OnHintDemoDisable();
    }
    public override void OnClick_UseMegaHint()
    {
        MonoSingleton<WGMegaHintController>.Instance.OnMegaHintPressed(freeHint:  true);
        WordRegion.instance.OnHintDemoDisable();
        MonoSingleton<ScreenOverlay>.Instance.ToggleDarkener(state:  true, animated:  false, duration:  0.4f);
        Player val_4 = App.Player;
        val_4.properties.Save(writePrefs:  true);
    }
    public override void OnClick_UsePickerHint()
    {
        MonoSingleton<HintPickerController>.Instance.OnHintPickButtonClicked(free:  WGHintPickerDemoPopup.IsShowing);
        if((this & 1) == 0)
        {
                return;
        }
        
        WordRegion.instance.OnHintDemoDisable();
    }
    public override bool DemoPopupEnabled()
    {
        return true;
    }
    public override bool SupportsPickerHint()
    {
        return true;
    }
    public override bool SupportsMegaHint()
    {
        return false;
    }
    public override bool IsPickerHintActivated()
    {
        if((MonoSingleton<HintPickerController>.Instance) == 0)
        {
                return false;
        }
        
        HintPickerController val_3 = MonoSingleton<HintPickerController>.Instance;
        return val_3.HintPickerGroup.activeInHierarchy;
    }
    public override string StoreBonusAmountText(decimal rawPercent)
    {
        decimal val_2 = new System.Decimal(value:  100);
        decimal val_3 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = rawPercent.flags, hi = rawPercent.hi, lo = rawPercent.lo, mid = rawPercent.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        decimal val_4 = System.Math.Round(d:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        return (string)System.String.Format(format:  Localization.Localize(key:  "#_pct_free_upper", defaultValue:  "{0}% FREE", useSingularKey:  false), arg0:  val_4.flags.ToString());
    }
    public override string GetExtraReqWordsInfo()
    {
        return WordRegion.Debug_GetExtraRequiredWordsInfo();
    }
    public override string GetCurrentLevelPlayerPrefKey()
    {
        return "PP_currPL";
    }
    public override string GetExtraRequiredWordsPrefKey_NormalGameplay()
    {
        return "xtra_req_words";
    }
    public override bool UseNewLevelGen()
    {
        return (bool)(WordApp.LevelGenVersionToUse == 2) ? 1 : 0;
    }
    public WADGameplayBehavior()
    {
    
    }

}
