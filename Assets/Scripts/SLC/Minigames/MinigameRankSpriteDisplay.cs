using UnityEngine;

namespace SLC.Minigames
{
    public class MinigameRankSpriteDisplay : MonoBehaviour
    {
        // Fields
        private const string frameWorkBundleName = "minigames_framework";
        private UnityEngine.UI.Image rankImage;
        private SLC.Minigames.MinigameRankSpriteDisplay.RankDisplayType typeOfDisplay;
        
        // Methods
        public void Setup(SLC.Minigames.MinigameLevelRank rank)
        {
            this.DisplaySprite(rank:  rank);
        }
        public void OverrideRankWithFlag()
        {
            this.rankImage.sprite = MonoSingletonSelfGenerating<ResourceLoader>.Instance.GetSpriteFromBundle(bundleName:  "minigames_framework", spriteName:  "Icon_Progress_Bar_Flag");
        }
        private void DisplaySprite(SLC.Minigames.MinigameLevelRank rank)
        {
            this.rankImage.enabled = (rank.rankLevel > 0) ? 1 : 0;
            mem2[0] = this.typeOfDisplay;
            this.rankImage.sprite = MonoSingletonSelfGenerating<ResourceLoader>.Instance.GetSpriteFromBundle(bundleName:  "minigames_framework", spriteName:  System.String.Format(format:  "Icon_{0}_{1}", arg0:  this.typeOfDisplay.ToString(), arg1:  rank.rankName));
        }
        public MinigameRankSpriteDisplay()
        {
        
        }
    
    }

}
