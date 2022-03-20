using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIProfileExtraData : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text rankText;
        private UnityEngine.UI.Text pointsText;
        private UnityEngine.UI.Text inactiveText;
        private UnityEngine.UI.Text ordinalText;
        private UnityEngine.GameObject extraDataCategory;
        private UnityEngine.GameObject activePlayerBox;
        private UnityEngine.GameObject inactivePlayerBox;
        
        // Methods
        public void Setup(SLC.Social.Profile profile)
        {
            UnityEngine.UI.Text val_15;
            UnityEngine.UI.Text val_16;
            val_15 = this;
            val_16 = 1152921505022660608;
            SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if(profile.ServerId == val_2.ServerId)
            {
                    if(SLC.Social.Leagues.LeaguesManager.IsAvailableAndInGuild() == false)
            {
                goto label_16;
            }
            
            }
            
            this.activePlayerBox.SetActive(value:  profile.isMemberActive);
            this.inactivePlayerBox.SetActive(value:  (profile.isMemberActive == false) ? 1 : 0);
            if(profile.isMemberActive == false)
            {
                goto label_12;
            }
            
            SLC.Social.Leagues.Guild val_6 = SLC.Social.Leagues.LeaguesManager.DAO.GetGuild(guildId:  profile.GuildServerId);
            if(val_6 != null)
            {
                    int val_7 = val_6.GetRankInGuildById(id:  profile.ServerId);
                string val_8 = val_7.ToString();
                val_16 = this.pointsText;
                string val_9 = profile.leaguePoints.ToString();
                val_15 = this.ordinalText;
                string val_10 = Ordinal.AddOrdinal(num:  val_7);
                return;
            }
            
            label_16:
            this.extraDataCategory.SetActive(value:  false);
            return;
            label_12:
            val_15 = this.inactiveText;
            if(profile.GuildMaster != false)
            {
                    string val_13 = System.String.Format(format:  "{0} - {1}", arg0:  Localization.Localize(key:  "leader_upper", defaultValue:  "LEADER", useSingularKey:  false), arg1:  Localization.Localize(key:  "inactive_upper", defaultValue:  "INACTIVE", useSingularKey:  false));
                return;
            }
            
            string val_14 = Localization.Localize(key:  "inactive_upper", defaultValue:  "INACTIVE", useSingularKey:  false);
        }
        public LeaguesUIProfileExtraData()
        {
        
        }
    
    }

}
