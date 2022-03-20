using UnityEngine;

namespace WordHound
{
    public class WGStarsBalance : MonoBehaviour
    {
        // Fields
        private bool listenForUpdate;
        private TweenCoinsText balanceText;
        
        // Methods
        private void OnEnable()
        {
            this.OnStarsChanged();
            if(this.listenForUpdate == false)
            {
                    return;
            }
            
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnStarsChanged");
        }
        public void Init(int initialStars)
        {
            decimal val_1 = System.Decimal.op_Implicit(value:  initialStars);
            this.balanceText.Set(instantValue:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
        }
        public void OnStarsChanged()
        {
            Player val_1 = App.Player;
            decimal val_2 = System.Decimal.op_Implicit(value:  val_1._stars);
            this.balanceText.CountUp(endValue:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, seconds:  1f);
        }
        public WGStarsBalance()
        {
        
        }
    
    }

}
