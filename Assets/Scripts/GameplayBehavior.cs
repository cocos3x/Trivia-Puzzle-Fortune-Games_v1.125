using UnityEngine;
public class GameplayBehavior
{
    // Methods
    public virtual bool SupportsHintTutorials()
    {
        return false;
    }
    public virtual void OnClick_UseHint()
    {
        null = null;
        UnityEngine.Debug.LogError(message:  "No behavior set for onclick Use hint in " + App.game);
    }
    public virtual void OnClick_UseMegaHint()
    {
        null = null;
        UnityEngine.Debug.LogError(message:  "No behavior set for onclick Use mega hint in " + App.game);
    }
    public virtual void OnClick_UsePickerHint()
    {
        null = null;
        UnityEngine.Debug.LogError(message:  "No behavior set for onclick Use picker hint in " + App.game);
    }
    public virtual string GetDifficultyForTracking()
    {
        return (string)System.String.alignConst;
    }
    public virtual string GetProgressForTracking()
    {
        return (string)System.String.alignConst;
    }
    public virtual string GetProgressTypeForTracking()
    {
        return (string)System.String.alignConst;
    }
    public virtual bool DemoPopupEnabled()
    {
        return false;
    }
    public virtual bool SupportsHintPopup()
    {
        return true;
    }
    public virtual bool SupportsPickerHint()
    {
        return false;
    }
    public virtual bool SupportsMegaHint()
    {
        return false;
    }
    public virtual bool SupportsCheckHint()
    {
        return false;
    }
    public virtual bool IsPickerHintActivated()
    {
        return false;
    }
    public virtual bool SupportAdvancedPlayerPopup()
    {
        return true;
    }
    public virtual bool SupportSkipTutorial()
    {
        return true;
    }
    public virtual bool SupportExtraWords()
    {
        return true;
    }
    public virtual bool WaitForGenerationBeforeGamePopups()
    {
        return false;
    }
    public virtual int GetWordPanRadius(int numTile = 0)
    {
        return 250;
    }
    public virtual float GetPanElipseAdjustment()
    {
        return 1f;
    }
    public virtual float SetWordTileScale(int numTile)
    {
        int val_1 = numTile - 1;
        return (float)(val_1 == 7) ? 0.7f : ((val_1 == 6) ? 0.75f : 1f);
    }
    public virtual float GetLetterTileContainerScale()
    {
        return 811f;
    }
    public virtual float LineWordCellGap()
    {
        return 0.08f;
    }
    public virtual string StoreBonusAmountText(decimal rawPercent)
    {
        decimal val_2 = new System.Decimal(value:  100);
        decimal val_3 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = rawPercent.flags, hi = rawPercent.hi, lo = rawPercent.lo, mid = rawPercent.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        decimal val_4 = System.Math.Round(d:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        return (string)System.String.Format(format:  Localization.Localize(key:  "#_pct_extra_upper", defaultValue:  "{0}% EXTRA", useSingularKey:  false), arg0:  val_4.flags.ToString());
    }
    public virtual decimal CalculateStoreBonusPercent(PurchaseModel pack, int decimalPlaces)
    {
        decimal val_1 = pack.Credits;
        decimal val_2 = System.Decimal.op_Explicit(value:  pack.sale_price);
        decimal val_3 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        decimal val_5 = App.getGameEcon.base099CreditPackSize;
        decimal val_6 = new System.Decimal(lo:  99, mid:  0, hi:  0, isNegative:  false, scale:  2);
        decimal val_7 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo});
        decimal val_8 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        decimal val_9 = System.Decimal.Round(d:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, decimals:  decimalPlaces);
        decimal val_10 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, d2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
        return new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid};
    }
    public virtual string InfinityText()
    {
        return System.String.Format(format:  Localization.Localize(key:  "level_#", defaultValue:  "Level {0}", useSingularKey:  false), arg0:  "<b><size=15>∞</size></b>");
    }
    public virtual string GetExtraReqWordsInfo()
    {
        return "Not Applicable to This Game.";
    }
    public virtual bool ShowCoinCollectOnServerCoinAwardPopup()
    {
        return true;
    }
    public virtual bool ShowAdsControlPopupAutomatically()
    {
        return true;
    }
    public virtual string GetCurrentLevelPlayerPrefKey()
    {
        return "PP_currPL";
    }
    public virtual string GetExtraRequiredWordsPrefKey_NormalGameplay()
    {
        return "xtra_req_words";
    }
    public virtual bool UseNewLevelGen()
    {
        return false;
    }
    public GameplayBehavior()
    {
    
    }

}
