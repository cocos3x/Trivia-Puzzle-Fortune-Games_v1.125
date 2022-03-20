using UnityEngine;

namespace WordForest
{
    public class WFONewsListItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image iconNewsSender;
        private UnityEngine.UI.Image iconNewsType;
        private UnityEngine.UI.Text labelBody;
        private UnityEngine.UI.Text labelTimestamp;
        private UnityEngine.Sprite spriteRefNewsAttack;
        private UnityEngine.Sprite spriteRefNewsRaid;
        private UnityEngine.Sprite spriteRefNewsShield;
        private WordForest.NewsArticle newsData;
        
        // Methods
        public void Initialize(WordForest.NewsArticle data)
        {
            UnityEngine.Sprite val_14;
            string val_16;
            this.newsData = data;
            System.DateTime val_1 = System.DateTime.UtcNow;
            System.DateTime val_2 = data.time.ToUniversalTime();
            System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
            WordForest.RaidAttackManager val_4 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            this.iconNewsSender.sprite = val_4.avatarConfig.GetAvatarSpriteByID(id:  data.sender.avatarId, portraitID:  0);
            if((data.message.Contains(value:  "tried")) == false)
            {
                goto label_12;
            }
            
            val_14 = this.spriteRefNewsShield;
            goto label_18;
            label_12:
            if((data.message.Contains(value:  "stole")) == false)
            {
                goto label_16;
            }
            
            val_14 = this.spriteRefNewsRaid;
            goto label_18;
            label_16:
            if((data.message.Contains(value:  "attacked")) == false)
            {
                goto label_20;
            }
            
            val_14 = this.spriteRefNewsAttack;
            label_18:
            this.iconNewsType.sprite = val_14;
            label_20:
            if(val_3._ticks.TotalHours < 0)
            {
                    return;
            }
            
            if(val_3._ticks.TotalHours < 0)
            {
                    double val_11 = val_3._ticks.TotalHours;
                val_11 = (val_11 == Infinity) ? (-val_11) : (val_11);
                val_16 = "{0}h ago";
            }
            else
            {
                    double val_12 = val_3._ticks.TotalDays;
                val_12 = (val_12 == Infinity) ? (-val_12) : (val_12);
                val_16 = "{0}d ago";
            }
            
            string val_13 = System.String.Format(format:  val_16, arg0:  (int)val_12);
        }
        public WFONewsListItem()
        {
        
        }
    
    }

}
