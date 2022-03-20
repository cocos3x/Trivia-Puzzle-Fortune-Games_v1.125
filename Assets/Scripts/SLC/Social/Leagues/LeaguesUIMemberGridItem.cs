using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIMemberGridItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button mainButton;
        private UnityEngine.UI.Text rankText;
        private UnityEngine.UI.Outline rankTextOutline;
        private AvatarSlotUGUI memberAvatarSlot;
        private UnityEngine.UI.Text memberNameText;
        private UnityEngine.GameObject memberPointsContributionGroup;
        private UnityEngine.UI.Text memberContributionText;
        private UnityEngine.UI.Text memberPointsText;
        private UnityEngine.GameObject leaderImage;
        private UnityEngine.GameObject coLeaderImage;
        private UnityEngine.GameObject inactiveImage;
        private UnityEngine.UI.Button acceptInviteButton;
        private UnityEngine.UI.Button rejectInviteButton;
        private UnityEngine.UI.Text acceptInviteButtonText;
        private UnityEngine.GameObject yourProfileObject;
        private UnityEngine.UI.Image goldenTicketImage;
        private UnityEngine.Sprite hasGT;
        private UnityEngine.Sprite noGT;
        private SLC.Social.Profile member;
        private SLC.Social.Leagues.GuildJoinRequest request;
        private System.Action<int> onClickAction;
        
        // Methods
        private void Awake()
        {
            this.mainButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIMemberGridItem::OnClick()));
        }
        private void Start()
        {
            this.acceptInviteButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIMemberGridItem::AcceptRequest_button()));
            this.rejectInviteButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIMemberGridItem::RejectRequest_button()));
        }
        public void UpdateUIFromMember(SLC.Social.Profile member, int rank, bool showLeadersOptions, SLC.Social.Leagues.GuildJoinRequest request, bool showMVP = True, bool specialMVPMode = False, System.Action<int> clickOutAction)
        {
            UnityEngine.UI.Text val_41;
            UnityEngine.UI.Text val_42;
            var val_47;
            UnityEngine.Sprite val_48;
            bool val_49;
            var val_50;
            string val_51;
            string val_52;
            val_41 = this;
            UnityEngine.GameObject val_1 = this.gameObject;
            if(member == null)
            {
                goto label_2;
            }
            
            val_1.SetActive(value:  true);
            val_42 = this.rankText;
            this.member = member;
            this.onClickAction = clickOutAction;
            if(rank < 1)
            {
                goto label_3;
            }
            
            string val_2 = +rank;
            if(val_42 != null)
            {
                goto label_4;
            }
            
            label_2:
            val_1.SetActive(value:  false);
            return;
            label_3:
            label_4:
            this.rankTextOutline.enabled = (rank < 1) ? 1 : 0;
            if(rank < 1)
            {
                goto label_8;
            }
            
            UnityEngine.Color val_4 = UnityEngine.Color.black;
            if(this.rankTextOutline != null)
            {
                goto label_9;
            }
            
            label_8:
            UnityEngine.Color val_5 = UnityEngine.Color.white;
            label_9:
            this.rankTextOutline.effectColor = new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a};
            if(specialMVPMode != true)
            {
                    decimal val_6 = member.GetLeagueCoins;
                val_42 = val_6.lo;
                decimal val_7 = new System.Decimal(value:  232);
                string val_8 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_42, mid = val_6.mid}, maxSigFigs:  3, round:  true, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_7.flags, hi = val_7.flags, lo = val_7.lo, mid = val_7.lo}, useRichText:  false, withSpaces:  false);
            }
            
            decimal val_9 = new System.Decimal(value:  232);
            string val_10 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = member.leaguePoints, hi = member.leaguePoints, lo = val_42, mid = val_6.mid}, maxSigFigs:  3, round:  true, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_9.flags, hi = val_9.flags, lo = val_9.lo, mid = val_9.lo}, useRichText:  false, withSpaces:  false);
            if((member.isMemberActive == true) || (showLeadersOptions == false))
            {
                goto label_22;
            }
            
            this.inactiveImage.SetActive(value:  true);
            val_47 = 0;
            goto label_25;
            label_22:
            if((member.GuildMaster == false) || (showLeadersOptions == false))
            {
                goto label_27;
            }
            
            this.inactiveImage.SetActive(value:  false);
            val_47 = 1;
            label_25:
            this.leaderImage.SetActive(value:  true);
            label_115:
            label_46:
            this.coLeaderImage.SetActive(value:  false);
            label_114:
            SLC.Social.Leagues.LeaguesDataController val_11 = SLC.Social.Leagues.LeaguesManager.DAO;
            this.yourProfileObject.SetActive(value:  (member.ServerId == val_11.MyId) ? 1 : 0);
            if(this.goldenTicketImage == 0)
            {
                goto label_37;
            }
            
            if(member.hasSubscriptionActive == false)
            {
                goto label_38;
            }
            
            val_48 = this.hasGT;
            goto label_40;
            label_27:
            if((member.Officer == false) || (showLeadersOptions == false))
            {
                goto label_42;
            }
            
            this.inactiveImage.SetActive(value:  false);
            this.leaderImage.SetActive(value:  false);
            goto label_46;
            label_38:
            val_48 = this.noGT;
            label_40:
            this.goldenTicketImage.sprite = val_48;
            GameBehavior val_15 = App.getBehavior;
            this.goldenTicketImage.gameObject.SetActive(value:  (val_15.<metaGameBehavior>k__BackingField) & 1);
            label_37:
            SLC.Social.Profile val_18 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if(val_18.GuildMaster == true)
            {
                goto label_58;
            }
            
            SLC.Social.Profile val_20 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            val_49 = val_20.Officer;
            if(val_49 == false)
            {
                goto label_69;
            }
            
            label_58:
            SLC.Social.Profile val_22 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
            if(member.ServerId == val_22.ServerId)
            {
                    val_49 = 0;
            }
            else
            {
                    val_49 = member.GuildMaster ^ 1;
            }
            
            label_69:
            if((val_49 & showLeadersOptions) != 0)
            {
                goto label_70;
            }
            
            this.request = request;
            if((rank > 0) || (request == null))
            {
                goto label_72;
            }
            
            this.acceptInviteButton.gameObject.SetActive(value:  true);
            this.rejectInviteButton.gameObject.SetActive(value:  true);
            UnityEngine.GameObject val_26 = this.memberPointsContributionGroup.gameObject;
            val_50 = 0;
            goto label_80;
            label_70:
            this.acceptInviteButton.gameObject.SetActive(value:  false);
            this.rejectInviteButton.gameObject.SetActive(value:  false);
            this.memberPointsContributionGroup.gameObject.SetActive(value:  true);
            return;
            label_72:
            this.acceptInviteButton.gameObject.SetActive(value:  false);
            this.rejectInviteButton.gameObject.SetActive(value:  false);
            val_50 = 1;
            label_80:
            this.memberPointsContributionGroup.gameObject.SetActive(value:  true);
            SLC.Social.Leagues.Guild val_34 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            SLC.Social.Leagues.Guild val_36 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            if(val_34.MemberCount == val_36.maximumMembers)
            {
                    this.acceptInviteButton.interactable = false;
                val_41 = this.acceptInviteButtonText;
                val_51 = "full_upper";
                val_52 = "FULL";
            }
            else
            {
                    this.acceptInviteButton.interactable = true;
                val_41 = this.acceptInviteButtonText;
                val_51 = "accept_upper";
                val_52 = "ACCEPT";
            }
            
            string val_37 = Localization.Localize(key:  val_51, defaultValue:  val_52, useSingularKey:  false);
            return;
            label_42:
            if((UnityEngine.Object.op_Implicit(exists:  this.leaderImage)) != false)
            {
                    this.leaderImage.SetActive(value:  false);
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.coLeaderImage)) != false)
            {
                    this.coLeaderImage.SetActive(value:  false);
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.inactiveImage)) == false)
            {
                goto label_114;
            }
            
            if(this.inactiveImage != null)
            {
                goto label_115;
            }
            
            throw new NullReferenceException();
        }
        private void AcceptRequest_button()
        {
            if(this.request != null)
            {
                    this.request.AcceptRequest();
                return;
            }
            
            throw new NullReferenceException();
        }
        private void RejectRequest_button()
        {
            if(this.request != null)
            {
                    this.request.RejectRequest();
                return;
            }
            
            throw new NullReferenceException();
        }
        private void ToggleCoLeader_button()
        {
            if(this.member.Officer != false)
            {
                    SLC.Social.Leagues.LeaguesManager.DAO.DemoteMember(toDemote:  this.member, responseCallback:  0);
                return;
            }
            
            SLC.Social.Leagues.LeaguesManager.DAO.PromoteMember(toPromote:  this.member, responseCallback:  0);
        }
        private void RemovePlayer_button()
        {
        
        }
        private void OnClick()
        {
            if(this.onClickAction != null)
            {
                    this.onClickAction.Invoke(obj:  this.member.ServerId);
                return;
            }
            
            SLC.Social.Leagues.LeaguesUIManager.ShowPlayerProfile(serverId:  this.member.ServerId, gridItem:  this.gameObject);
        }
        private void OnClick_ProMembership()
        {
            if(this.onClickAction == null)
            {
                    return;
            }
            
            this.onClickAction.Invoke(obj:  0);
        }
        public LeaguesUIMemberGridItem()
        {
        
        }
    
    }

}
