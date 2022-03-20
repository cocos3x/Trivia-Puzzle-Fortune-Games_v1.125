using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_MyClubTabsNotifs : MonoBehaviour
    {
        // Fields
        public const string LeaguesChatLastMessagePref = "leagues_last_message_seen";
        private UnityEngine.GameObject chatsNotifObject;
        private UnityEngine.UI.Text chatsNotifCountText;
        private UnityEngine.UI.Toggle chatToggle;
        
        // Methods
        private void Awake()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  4.ToString());
        }
        private void OnMyGuildChatUpdate()
        {
            var val_13;
            System.Predicate<System.String> val_15;
            UnityEngine.GameObject val_16;
            SLC.Social.Leagues.Conversation val_17;
            var val_18;
            SLC.Social.Leagues.Guild val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_13 = null;
            val_13 = null;
            val_15 = LeaguesUI_MyClubTabsNotifs.<>c.<>9__5_0;
            if(val_15 == null)
            {
                    System.Predicate<System.String> val_3 = null;
                val_15 = val_3;
                val_3 = new System.Predicate<System.String>(object:  LeaguesUI_MyClubTabsNotifs.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LeaguesUI_MyClubTabsNotifs.<>c::<OnMyGuildChatUpdate>b__5_0(string x));
                LeaguesUI_MyClubTabsNotifs.<>c.<>9__5_0 = val_15;
            }
            
            int val_4 = val_2.chat.FindIndex(match:  val_3);
            if(val_4 == 1)
            {
                goto label_11;
            }
            
            SLC.Social.Leagues.Guild val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            SLC.Social.Leagues.Conversation val_13 = val_6.chat;
            val_13 = val_13 - 1;
            if(val_4 != val_13)
            {
                goto label_17;
            }
            
            val_16 = this.chatsNotifObject;
            goto label_30;
            label_11:
            SLC.Social.Leagues.Guild val_8 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            goto label_24;
            label_17:
            SLC.Social.Leagues.Guild val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            val_17 = val_10.chat + (~val_4);
            label_24:
            val_16 = this.chatsNotifObject;
            if(val_17 < 1)
            {
                goto label_30;
            }
            
            var val_11 = (this.chatToggle.m_IsOn == false) ? 1 : 0;
            if(val_16 != null)
            {
                goto label_32;
            }
            
            label_30:
            val_18 = 0;
            label_32:
            val_16.SetActive(value:  false);
            string val_12 = val_17.ToString();
        }
        public LeaguesUI_MyClubTabsNotifs()
        {
        
        }
    
    }

}
