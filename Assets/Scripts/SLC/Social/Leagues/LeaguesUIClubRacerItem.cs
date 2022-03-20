using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIClubRacerItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image guildImage;
        private UnityEngine.GameObject youGroup;
        private UnityEngine.UI.Text rankDisplay;
        
        // Methods
        public void SetupUI(int avatarId, bool yours, int rank, int displayTier)
        {
            this.guildImage.sprite = SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.GetAvatarSpriteByID(id:  avatarId, portraitID:  0);
            this.youGroup.SetActive(value:  yours);
            UnityEngine.Transform val_4 = this.transform;
            if(yours != false)
            {
                    val_4.SetAsLastSibling();
            }
            else
            {
                    val_4.SetAsFirstSibling();
            }
            
            string val_5 = rank.ToString();
        }
        public LeaguesUIClubRacerItem()
        {
        
        }
    
    }

}
