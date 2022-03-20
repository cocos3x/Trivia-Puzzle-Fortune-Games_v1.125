using UnityEngine;
public class WGAdsControlPopupV2 : WGAdsControlPopup
{
    // Fields
    private UnityEngine.UI.Text coinRewardText;
    private UnityEngine.UI.Text gemsRewardText;
    private UnityEngine.UI.Text displayValueText;
    private UnityEngine.UI.Text startedPackPrice;
    
    // Methods
    private void OnEnable()
    {
        if(41967616 != 0)
        {
                mem2[0] = new System.Action<System.Boolean>(object:  this, method:  System.Void WGAdsControlPopup::OnClick_NoAds(bool result));
        }
        
        this.FetchNoAdsPackage();
        this.UpdateUI();
        this.SetSubscriptionEntryPoint();
        this.SetPopupSeen();
    }
    private void UpdateUI()
    {
        decimal val_1 = 35174.Credits;
        string val_2 = val_1.flags.ToString();
        bool val_3 = UnityEngine.Object.op_Implicit(exists:  this.gemsRewardText);
        if(val_3 != false)
        {
                decimal val_4 = val_3.Gems;
            string val_5 = val_4.flags.ToString();
        }
        
        Il2CppInteropData* val_11 = UnityEngine.UI.Text.__il2cppRuntimeField_interopData;
        GameBehavior val_7 = App.getBehavior;
        val_11 = val_11 * ((float)UnityEngine.Mathf.CeilToInt(f:  val_11));
        float val_12 = -0.01f;
        val_12 = ((float)UnityEngine.Mathf.CeilToInt(f:  val_11)) + val_12;
        string val_9 = val_12.ToString(format:  "$0.00");
        string val_10 = this.displayValueText.LocalPrice;
    }
    protected override void OnPurchaseNoAdsPackSuccess()
    {
        var val_19;
        int val_20;
        var val_21;
        decimal val_1 = 35173.Gems;
        val_19 = null;
        val_19 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                Player val_3 = App.Player;
            decimal val_4 = System.Decimal.op_Implicit(value:  val_3._gems);
            decimal val_5 = val_4.flags.Gems;
            decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
            Player val_8 = App.Player;
            decimal val_9 = System.Decimal.op_Implicit(value:  val_8._gems);
            val_20 = val_9.lo;
            val_1.flags.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}), toValue:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_20, mid = val_9.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        }
        
        decimal val_10 = val_1.flags.Credits;
        val_21 = null;
        val_21 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_13 = App.Player.Credits;
            decimal val_14 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_12._credits, hi = val_12._credits, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid});
            Player val_15 = App.Player;
            val_10.flags.Play(fromValue:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid}, toValue:  new System.Decimal() {flags = val_15._credits, hi = val_15._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        }
        
        WGStoreController val_16 = MonoSingletonSelfGenerating<WGStoreController>.Instance;
        System.Delegate val_18 = System.Delegate.Remove(source:  val_16.OnStorePurchaseFailed, value:  new System.Action<System.String, System.String>(object:  this, method:  System.Void WGAdsControlPopup::OnPurchaseNoAdsPackFailed(string title, string message)));
        if(val_18 != null)
        {
                if(null != null)
        {
            goto label_29;
        }
        
        }
        
        val_16.OnStorePurchaseFailed = val_18;
        return;
        label_29:
    }
    public WGAdsControlPopupV2()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
