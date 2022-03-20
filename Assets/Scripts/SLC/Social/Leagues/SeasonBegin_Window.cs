using UnityEngine;

namespace SLC.Social.Leagues
{
    public class SeasonBegin_Window : MonoBehaviour
    {
        // Fields
        private SLC.Social.Leagues.LeaguesUIGuildTierDisplay tierDisplay;
        private UnityEngine.GameObject promotionGroup;
        private UnityEngine.GameObject demotionGroup;
        private bool wasPromoted;
        private bool wasDemoted;
        
        // Methods
        private void OnEnable()
        {
            this.Show();
        }
        private void Show()
        {
            int val_11;
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            this.wasPromoted = val_1.SeasonPromotion;
            SLC.Social.Leagues.LeaguesDataController val_2 = SLC.Social.Leagues.LeaguesManager.DAO;
            this.wasDemoted = val_2.SeasonDemotion;
            SLC.Social.Leagues.LeaguesDataController val_3 = SLC.Social.Leagues.LeaguesManager.DAO;
            if((val_3.LastSeasonRank & 2147483648) == 0)
            {
                    if(SLC.Social.Leagues.LeaguesManager.DAO != null)
            {
                goto label_9;
            }
            
            }
            
            SLC.Social.Leagues.Guild val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            label_9:
            SLC.Social.Leagues.LeaguesDataController val_7 = SLC.Social.Leagues.LeaguesManager.DAO;
            if((val_7.LastSeasonTier & 2147483648) == 0)
            {
                    SLC.Social.Leagues.LeaguesDataController val_8 = SLC.Social.Leagues.LeaguesManager.DAO;
                val_11 = val_8.LastSeasonTier;
            }
            else
            {
                    SLC.Social.Leagues.Guild val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                val_11 = val_10.tier;
            }
            
            this.tierDisplay.UpdateTierUI(guildTier:  val_11);
            this.promotionGroup.SetActive(value:  false);
            this.demotionGroup.SetActive(value:  false);
            this.CancelInvoke();
            this.Invoke(methodName:  "NextPhase", time:  1.25f);
        }
        private void NextPhase()
        {
            if(this.wasPromoted != true)
            {
                    if(this.wasDemoted == false)
            {
                goto label_2;
            }
            
            }
            
            this.promotionGroup.SetActive(value:  (this.wasPromoted == true) ? 1 : 0);
            this.demotionGroup.SetActive(value:  this.wasDemoted);
            this.Invoke(methodName:  "ShowNewRank", time:  0.5f);
            return;
            label_2:
            this.ShowNewRank();
        }
        private void ShowNewRank()
        {
            SLC.Social.Leagues.Guild val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.tierDisplay.UpdateTierUI(guildTier:  val_2.tier);
            SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            SLC.Social.Leagues.Guild val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        }
        private void OnDisable()
        {
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_1.SeasonPromotion = false;
            SLC.Social.Leagues.LeaguesDataController val_2 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_2.SeasonDemotion = false;
        }
        public SeasonBegin_Window()
        {
        
        }
    
    }

}
