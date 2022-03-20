using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIGuildDisplay : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text guildName;
        private SLC.Social.Leagues.LeaguesUIGuildTierDisplay guildTierDisplay;
        private UnityEngine.UI.Image guildAvatar;
        private UnityEngine.UI.Button guildButton;
        private bool defaultToMyGuildOnEnable;
        private bool refreshOnMyGuildUpdate;
        private int guildDisplaying;
        public System.Action OnGuildDisplayClicked;
        private SLC.Social.Leagues.Guild guild;
        
        // Methods
        private void Start()
        {
            UnityEngine.Events.UnityAction val_5;
            if(this.guildButton != 0)
            {
                    UnityEngine.Events.UnityAction val_2 = null;
                val_5 = val_2;
                val_2 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIGuildDisplay::OnThisButtonClicked());
                this.guildButton.m_OnClick.AddListener(call:  val_2);
            }
            
            if(this.refreshOnMyGuildUpdate == false)
            {
                    return;
            }
            
            val_5 = 2;
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
        }
        private void OnMyGuildUpdate()
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
            
            this.guildDisplaying = guildId;
            this.guildAvatar.sprite = SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.GetAvatarSpriteByID(id:  this.guild.AvatarId, portraitID:  0);
            if((UnityEngine.Object.op_Implicit(exists:  this.guildTierDisplay)) == false)
            {
                    return;
            }
            
            this.guildTierDisplay.Refresh(guildId:  guildId);
        }
        private void OnThisButtonClicked()
        {
            if(this.OnGuildDisplayClicked != null)
            {
                    this.OnGuildDisplayClicked.Invoke();
                return;
            }
            
            if((MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance) == 0)
            {
                    return;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance.ShowGuildInfoPopup(guildId:  this.guildDisplaying);
        }
        public void SetButtonInteractable(bool isInteractable)
        {
            if(this.guildButton != null)
            {
                    this.guildButton.interactable = isInteractable;
                return;
            }
            
            throw new NullReferenceException();
        }
        public LeaguesUIGuildDisplay()
        {
            this.guildDisplaying = 0;
        }
    
    }

}
