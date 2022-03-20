using UnityEngine;

namespace SLC.Minigames
{
    public class MinigameRankProgressBar : MonoBehaviour
    {
        // Fields
        private bool showTooltip;
        private bool showRankIcon;
        private bool showFlagInsteadOfIcon;
        private UnityEngine.UI.Image sliderImage;
        private UnityEngine.UI.Text tooltipContainer;
        private SLC.Minigames.MinigameRankSpriteDisplay rankSprite;
        private UnityEngine.RectTransform sliderRect;
        private UnityEngine.GameObject[] sliderTicks;
        private UnityEngine.UI.Image[] checkpointFlags;
        
        // Methods
        private void OnEnable()
        {
            UnityEngine.RectTransform val_16;
            var val_17;
            SLC.Minigames.MinigameLevelRank val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentRank;
            SLC.Minigames.MinigameLevelRank val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetNextRank;
            this.rankSprite.gameObject.SetActive(value:  this.showRankIcon);
            if(this.showRankIcon != false)
            {
                    this.SetupRankIcon(nextRank:  val_4);
            }
            
            if(this.tooltipContainer != 0)
            {
                    this.tooltipContainer.transform.parent.gameObject.SetActive(value:  this.showTooltip);
                if(this.showTooltip != false)
            {
                    this.SetupTooltip(currentRank:  val_2, nextRank:  val_4);
            }
            
            }
            
            UnityEngine.Color val_10 = val_2.Color;
            this.sliderImage.color = new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a};
            val_16 = this.sliderRect;
            if((val_16 != 0) && (this.sliderTicks.Length != 0))
            {
                    this.SetupCheckpointTicks(rankData:  val_2);
            }
            
            if(this.checkpointFlags.Length == 0)
            {
                    return;
            }
            
            if(this.checkpointFlags.Length < 1)
            {
                    return;
            }
            
            do
            {
                SLC.Minigames.MinigameManager val_12 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                if(0 == (val_12.currentPlayerData.GetCheckpointsCompletedInRank() - 1))
            {
                    val_17 = 1;
            }
            else
            {
                    val_17 = 0;
            }
            
                this.checkpointFlags[0].gameObject.SetActive(value:  false);
                val_16 = 0 + 1;
            }
            while(val_16 < this.checkpointFlags.Length);
        
        }
        private void SetupCheckpointTicks(SLC.Minigames.MinigameLevelRank rankData)
        {
            var val_7;
            UnityEngine.GameObject[] val_8;
            int val_1 = rankData.NumCheckpoints;
            UnityEngine.Rect val_2 = this.sliderRect.rect;
            float val_3 = val_2.m_XMin.width;
            val_8 = this.sliderTicks;
            val_3 = (val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
            var val_10 = 0;
            do
            {
                if(val_10 >= this.sliderTicks.Length)
            {
                    return;
            }
            
                if(this.sliderTicks.Length <= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_8 = this.sliderTicks;
            }
            
                float val_9 = (float)val_8[val_10][0];
                val_9 = val_9 / 100f;
                val_7 = val_8[val_10].GetComponent<UnityEngine.RectTransform>();
                UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  val_9 * (float)(int)val_3, y:  0f);
                val_7.anchoredPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
                val_10 = val_10 + 1;
            }
            while(this.sliderTicks != null);
            
            throw new NullReferenceException();
        }
        private void SetupRankIcon(SLC.Minigames.MinigameLevelRank nextRank)
        {
            if(this.rankSprite != null)
            {
                    if(this.showFlagInsteadOfIcon != false)
            {
                    this.rankSprite.OverrideRankWithFlag();
                return;
            }
            
                this.rankSprite.DisplaySprite(rank:  nextRank);
                return;
            }
            
            throw new NullReferenceException();
        }
        private void SetupTooltip(SLC.Minigames.MinigameLevelRank currentRank, SLC.Minigames.MinigameLevelRank nextRank)
        {
            decimal val_1 = new System.Decimal(value:  232);
            string val_3 = System.String.Format(format:  "Only {0}% of players reach {1}", arg0:  MetricSystem.Abbreviate(number:  new System.Decimal() {flags = currentRank.percentPlayersComplete, hi = currentRank.percentPlayersComplete, lo = currentRank, mid = currentRank}, maxSigFigs:  3, round:  true, useColor:  true, maxValueWithoutAbbr:  new System.Decimal() {flags = val_1.flags, hi = val_1.flags, lo = val_1.lo, mid = val_1.lo}, useRichText:  false, withSpaces:  false), arg1:  nextRank.rankName);
        }
        public MinigameRankProgressBar()
        {
        
        }
    
    }

}
