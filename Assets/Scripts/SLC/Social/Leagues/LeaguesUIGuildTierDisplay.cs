using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIGuildTierDisplay : MonoBehaviour
    {
        // Fields
        public static System.Collections.Generic.List<string> TierTextHexColors;
        private UnityEngine.UI.Text tierNameText;
        private TMPro.TextMeshProUGUI tierNameTextMesh;
        private bool defaultToMyGuildOnEnable;
        private bool refreshOnMyGuildUpdate;
        public static System.Collections.Generic.Dictionary<int, int> GuildTierToSimpleType;
        private SLC.Social.Leagues.Guild guild;
        
        // Methods
        private void Start()
        {
            if(this.refreshOnMyGuildUpdate == false)
            {
                    return;
            }
            
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
        }
        public void OnMyGuildUpdate()
        {
            SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            this.Refresh(guildId:  val_2.GuildServerId);
        }
        private void OnEnable()
        {
            if(this.defaultToMyGuildOnEnable == false)
            {
                    return;
            }
            
            SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            this.Refresh(guildId:  val_2.GuildServerId);
        }
        public void Refresh(int guildId)
        {
            SLC.Social.Leagues.Guild val_2 = SLC.Social.Leagues.LeaguesManager.DAO.GetGuild(guildId:  guildId);
            this.guild = val_2;
            if(val_2 == null)
            {
                    return;
            }
            
            this.UpdateTierUI(guildTier:  val_2.tier);
        }
        public void UpdateRankUI(int guildRank, int tier, bool showRank = True)
        {
        
        }
        public void UpdateTierUI(int guildTier)
        {
            object val_9;
            TMPro.TextMeshProUGUI val_10;
            var val_11;
            var val_12;
            val_10 = guildTier;
            if(val_10 == 1)
            {
                goto label_1;
            }
            
            if(val_10 != 0)
            {
                goto label_2;
            }
            
            UnityEngine.Debug.LogError(message:  "Tier is 0");
            return;
            label_1:
            this.tierNameText.gameObject.SetActive(value:  false);
            this.tierNameTextMesh.gameObject.SetActive(value:  true);
            val_10 = this.tierNameTextMesh;
            string val_3 = SLC.Social.Leagues.GuildTierLoc.GetLocalizedTier(tier:  1);
            val_11 = public System.Void TMPro.TMP_Text::set_text(string value);
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
            label_2:
            this.tierNameTextMesh.gameObject.SetActive(value:  false);
            this.tierNameText.gameObject.SetActive(value:  true);
            val_12 = null;
            val_12 = null;
            int val_6 = SLC.Social.Leagues.LeaguesUIGuildTierDisplay.GuildTierToSimpleType.Item[val_10];
            if((SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors + 24) <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_9 = SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors + 16;
            val_9 = val_9 + (val_6 << 3);
            val_9 = mem[(SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors + 16 + (val_6) << 3) + 32];
            val_9 = (SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors + 16 + (val_6) << 3) + 32;
            string val_8 = System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  val_9, arg1:  SLC.Social.Leagues.GuildTierLoc.GetLocalizedTier(tier:  val_10));
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        public LeaguesUIGuildTierDisplay()
        {
        
        }
        private static LeaguesUIGuildTierDisplay()
        {
            System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
            val_1.Add(item:  "FFDA58");
            val_1.Add(item:  "BCEBF7");
            val_1.Add(item:  "B8B5D1");
            val_1.Add(item:  "F5DA45");
            val_1.Add(item:  "C4C1C1");
            val_1.Add(item:  "F67C3A");
            SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors = val_1;
            System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_2 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
            val_2.Add(key:  1, value:  0);
            val_2.Add(key:  2, value:  1);
            val_2.Add(key:  3, value:  2);
            val_2.Add(key:  4, value:  3);
            val_2.Add(key:  5, value:  3);
            val_2.Add(key:  6, value:  3);
            val_2.Add(key:  7, value:  4);
            val_2.Add(key:  8, value:  4);
            val_2.Add(key:  9, value:  4);
            val_2.Add(key:  10, value:  5);
            val_2.Add(key:  11, value:  5);
            val_2.Add(key:  12, value:  5);
            val_2.Add(key:  13, value:  5);
            val_2.Add(key:  14, value:  5);
            val_2.Add(key:  15, value:  5);
            SLC.Social.Leagues.LeaguesUIGuildTierDisplay.GuildTierToSimpleType = val_2;
        }
    
    }

}
