using UnityEngine;
public class FPHPiggyBankPopup : PiggyBankPopup
{
    // Methods
    public override void SetupPreview()
    {
        string val_2 = System.String.Format(format:  Localization.Localize(key:  "piggy_bank_popup_info", defaultValue:  "Collect {0} Stars and buy the Piggy Bank to open it!", useSingularKey:  false), arg0:  PiggyBankHandler.iapHigh + 132);
        bool val_4 = this.gameObject.activeInHierarchy;
        if(val_4 != false)
        {
                val_4.Play();
            return;
        }
        
        mem[1152921516553019200] = 1;
    }
    protected override void AnimateParticleAttraction()
    {
        if((147633.GetComponent<ParticlePositionToPoint>()) == 0)
        {
                return;
        }
        
        this = 147633.GetComponent<ParticlePositionToPoint>();
        val_3.attractionPoint = transform;
    }
    protected override void DoOnPurchaseAnimation()
    {
        System.Action val_1 = new System.Action(object:  this, method:  System.Void PiggyBankPopup::OnCollectAnimationComplete());
        mem2[0] = val_1;
        Player val_2 = App.Player;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_2._gems);
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = -938483840, hi = 268435458});
        Player val_6 = App.Player;
        decimal val_7 = System.Decimal.op_Implicit(value:  val_6._gems);
        val_1.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}), toValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, textTickTime:  -1f, delayBeforeComplete:  1.5f, destinationObject:  0, originObject:  0);
    }
    public FPHPiggyBankPopup()
    {
    
    }

}
