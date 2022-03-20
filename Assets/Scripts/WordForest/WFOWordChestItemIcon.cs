using UnityEngine;

namespace WordForest
{
    public class WFOWordChestItemIcon : MonoBehaviour
    {
        // Fields
        private UnityEngine.CanvasGroup canvasGroup;
        private UnityEngine.UI.Image iconImage;
        private UnityEngine.UI.Text iconLabel;
        private WordForest.WFORewardData itemData;
        private UnityEngine.Sprite refIconAcorn;
        private UnityEngine.Sprite refIconCoin;
        private UnityEngine.Sprite refIconAcornMultiplier;
        private UnityEngine.Sprite refIconShield;
        private UnityEngine.Sprite refIconRaid;
        private UnityEngine.Sprite refIconAttack;
        private UnityEngine.Sprite refIconIslandParadise;
        private System.Collections.Generic.Queue<WordForest.WFORewardData> multiplierAnimQueue;
        private decimal multiplierSuffix;
        
        // Properties
        public WordForest.WFORewardData ItemData { get; }
        public WordForest.WFORewardType ItemType { get; }
        public decimal ItemAmount { get; }
        
        // Methods
        public WordForest.WFORewardData get_ItemData()
        {
            WordForest.WFORewardData val_0;
            mem[1152921519429515004] = ???;
            val_0.id = this.itemData;
            return val_0;
        }
        public WordForest.WFORewardType get_ItemType()
        {
            return (WordForest.WFORewardType)this;
        }
        public decimal get_ItemAmount()
        {
            return new System.Decimal() {flags = X8, hi = X8};
        }
        public void Initialize(WordForest.WFORewardData rewardData)
        {
            mem[1152921519429839416] = rewardData.amount.lo;
            mem[1152921519429839408] = rewardData.amount.flags;
            this.itemData = rewardData.id;
            this.UpdateLabel();
            if(rewardData.amount.lo != 1)
            {
                    return;
            }
            
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnAcornMultiplierTrailParticleCompleted");
        }
        public void FadeOff(float duration)
        {
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  1.3f, y:  1.3f, z:  1f);
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.canvasGroup.transform, endValue:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, duration:  duration));
            DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  0f, duration:  duration));
        }
        public void AddMultiplierToAnimationQueue(WordForest.WFORewardData rewardToAppend)
        {
            this.multiplierAnimQueue.Enqueue(item:  new WordForest.WFORewardData() {id = rewardToAppend.id, amount = new System.Decimal() {hi = 268435459}, transformToId = ???});
        }
        private void OnAcornMultiplierTrailParticleCompleted()
        {
            var val_2;
            int val_3;
            int val_4;
            if(true < 1)
            {
                    return;
            }
            
            WordForest.WFORewardData val_1 = this.multiplierAnimQueue.Dequeue();
            if(val_2 != 3)
            {
                    return;
            }
            
            if(val_2 != 1)
            {
                    return;
            }
            
            decimal val_5 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.multiplierSuffix, hi = this.multiplierSuffix, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_3, hi = val_3, lo = val_4, mid = val_4});
            this.multiplierSuffix = val_5;
            mem[1152921519430292104] = val_5.lo;
            mem[1152921519430292108] = val_5.mid;
            this.UpdateLabel();
        }
        private void UpdateLabel()
        {
            decimal val_7;
            var val_8;
            UnityEngine.UI.Text val_9;
            bool val_6 = true;
            val_6 = val_6 - 1;
            if(val_6 > 6)
            {
                goto label_1;
            }
            
            object val_7 = 32555408 + ((true - 1)) << 2;
            val_7 = val_7 + 32555408;
            goto (32555408 + ((true - 1)) << 2 + 32555408);
            label_1:
            val_7 = this.multiplierSuffix;
            val_8 = null;
            val_8 = null;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_7, hi = val_7, lo = this.iconLabel, mid = this.iconLabel}, d2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0})) == false)
            {
                goto label_18;
            }
            
            val_9 = this.iconLabel;
            val_7 = System.Decimal.__il2cppRuntimeField_static_fields;
            string val_3 = System.String.Format(format:  "+{0} x{1}", arg0:  System.Decimal.__il2cppRuntimeField_static_fields, arg1:  this.multiplierSuffix);
            if(val_9 != null)
            {
                goto label_19;
            }
            
            label_18:
            val_9 = this.iconLabel;
            goto label_23;
            label_19:
            label_23:
            if(1152921504814993404 > 2)
            {
                    return;
            }
            
            this.iconLabel.gameObject.SetActive(value:  false);
        }
        public WFOWordChestItemIcon()
        {
            this.multiplierAnimQueue = new System.Collections.Generic.Queue<WordForest.WFORewardData>();
        }
    
    }

}
