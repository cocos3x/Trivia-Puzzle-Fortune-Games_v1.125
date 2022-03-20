using UnityEngine;

namespace WordForest
{
    public class WFOGameAcornStatView : GoldenApplesStatView
    {
        // Methods
        private void OnAcornLevelBalanceUpdated(Notification notif)
        {
            var val_5;
            if(((notif != null) && (notif.data != null)) && ((notif.data & 1) != 0))
            {
                    val_5 = (System.Boolean.Parse(value:  notif.data.ToString())) ^ 1;
            }
            else
            {
                    val_5 = 0;
            }
            
            this.UpdateBalance(instantly:  val_5 & 1);
        }
        protected override string GetBalanceUpdateNotificationName()
        {
            return "OnAcornLevelBalanceUpdated";
        }
        protected override decimal GetCountUpBalance()
        {
            int val_5;
            var val_6;
            int val_7;
            var val_8;
            val_5 = this;
            val_6 = null;
            val_6 = null;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = 41971712, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    return new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid};
            }
            
            val_5 = WordForest.WFOPlayer.Instance.starsLevelBalance;
            val_7 = val_5;
            val_8 = 0;
            decimal val_4 = System.Decimal.op_Implicit(value:  val_7);
            return new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid};
        }
        protected override void OnTouchAreaClicked()
        {
            WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WordForest.WFOAcornInfoPopup>(showNext:  false);
        }
        public WFOGameAcornStatView()
        {
        
        }
    
    }

}
