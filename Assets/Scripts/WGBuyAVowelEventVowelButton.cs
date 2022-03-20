using UnityEngine;
public class WGBuyAVowelEventVowelButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button;
    private UnityEngine.UI.Text costText;
    private UnityEngine.GameObject coinIcon;
    private UnityEngine.GameObject disableCover;
    
    // Methods
    public void Setup(string letter, decimal cost, System.Action<string> callback)
    {
        var val_15;
        var val_16;
        var val_18;
        .callback = callback;
        .letter = letter;
        val_15 = null;
        val_15 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = cost.flags, hi = cost.hi, lo = cost.lo, mid = cost.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                GameEcon val_3 = App.getGameEcon;
            string val_4 = cost.flags.ToString(format:  val_3.numberFormatInt);
        }
        else
        {
                val_16 = 0;
            string val_5 = Localization.Localize(key:  "free_upper", defaultValue:  "FREE", useSingularKey:  false);
        }
        
        val_18 = null;
        val_18 = null;
        int val_15 = cost.lo;
        val_15 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = cost.flags, hi = cost.hi, lo = val_15, mid = cost.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.coinIcon.SetActive(value:  val_15);
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new WGBuyAVowelEventVowelButton.<>c__DisplayClass4_0(), method:  System.Void WGBuyAVowelEventVowelButton.<>c__DisplayClass4_0::<Setup>b__0()));
        int val_16 = cost.lo;
        val_16 = System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = cost.flags, hi = cost.hi, lo = val_16, mid = cost.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.button.interactable = val_16;
        int val_17 = cost.lo;
        val_17 = System.Decimal.op_Equality(d1:  new System.Decimal() {flags = cost.flags, hi = cost.hi, lo = val_17, mid = cost.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.disableCover.SetActive(value:  val_17);
        int val_18 = cost.lo;
        val_18 = System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = cost.flags, hi = cost.hi, lo = val_18, mid = cost.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.costText.gameObject.transform.parent.gameObject.SetActive(value:  val_18);
    }
    public WGBuyAVowelEventVowelButton()
    {
    
    }

}
