using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIGuildGridItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image bgImage;
        private UnityEngine.UI.Image bgTileImage;
        private UnityEngine.UI.Image GuildImage;
        private UnityEngine.UI.Text GuildNameText;
        private UnityEngine.UI.Text GuildMemberCountText;
        private UnityEngine.UI.Text LeaguePointsAmount;
        private UnityEngine.GameObject league_points_section;
        private UnityEngine.GameObject member_count_section;
        private UnityEngine.UI.Text GuildTierText;
        private TMPro.TextMeshProUGUI GuildTierTextMesh;
        private UnityEngine.UI.Text Rank;
        private UnityEngine.GameObject RankGameObject;
        private UnityEngine.GameObject YourClubObject;
        private UnityEngine.Sprite notYou;
        private UnityEngine.Sprite you;
        private UnityEngine.Sprite notYouBG;
        private UnityEngine.Sprite youBG;
        private UnityEngine.Color normalColor;
        private UnityEngine.Color promotionColor;
        private UnityEngine.Color demotionColor;
        private UnityEngine.GameObject up_arrow_promotion;
        private UnityEngine.GameObject down_arrow_demotion;
        private UnityEngine.UI.Text seasonRewardPointsText;
        private int guildDisplaying;
        private SLC.Social.Leagues.Guild guild;
        private bool clickable;
        
        // Methods
        public void SetClickable(bool clickable)
        {
            this.clickable = clickable;
        }
        public void UpdateUIFromGuild(int guildId, bool rankingView = False, bool showMemberCount = False, int finalSeasonRank = -1)
        {
            if(guildId != 1)
            {
                    this.guildDisplaying = guildId;
                SLC.Social.Leagues.Guild val_2 = SLC.Social.Leagues.LeaguesManager.DAO.GetGuild(guildId:  guildId);
                this.guild = val_2;
                showMemberCount = showMemberCount;
                this.UpdateUIFromGuild(guild:  val_2, rankingView:  rankingView, showMemberCount:  showMemberCount, finalSeasonRank:  finalSeasonRank);
                return;
            }
            
            this.gameObject.SetActive(value:  false);
        }
        public void UpdateUIFromGuild(SLC.Social.Leagues.Guild guild, bool rankingView = False, bool showMemberCount = False, int finalSeasonRank = -1)
        {
            UnityEngine.UI.Text val_48;
            UnityEngine.UI.Text val_49;
            int val_50;
            int val_51;
            var val_52;
            var val_53;
            TMPro.TextMeshProUGUI val_54;
            var val_55;
            var val_56;
            var val_57;
            UnityEngine.Sprite val_58;
            val_48 = finalSeasonRank;
            val_49 = showMemberCount;
            UnityEngine.GameObject val_1 = this.gameObject;
            if(guild == null)
            {
                goto label_2;
            }
            
            val_1.SetActive(value:  true);
            this.guildDisplaying = guild.ServerId;
            if(this.GuildImage != 0)
            {
                    this.GuildImage.sprite = SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.GetAvatarSpriteByID(id:  guild.AvatarId, portraitID:  0);
            }
            
            UnityEngine.GameObject val_5 = this.GuildMemberCountText.gameObject;
            if(val_49 == false)
            {
                goto label_13;
            }
            
            val_5.SetActive(value:  true);
            val_49 = this.GuildMemberCountText;
            string val_6 = System.String.Format(format:  "{0}", arg0:  guild.MemberCount);
            goto label_15;
            label_2:
            val_1.SetActive(value:  false);
            return;
            label_13:
            val_5.SetActive(value:  false);
            label_15:
            this.RankGameObject.SetActive(value:  false);
            if(rankingView == false)
            {
                goto label_18;
            }
            
            this.GuildTierText.gameObject.SetActive(value:  false);
            this.GuildTierTextMesh.gameObject.SetActive(value:  false);
            this.league_points_section.SetActive(value:  true);
            decimal val_9 = guild.LeaguePointsFinal;
            GameEcon val_10 = App.getGameEcon;
            string val_11 = val_9.flags.ToString(format:  val_10.numberFormatInt);
            if((val_48 & 2147483648) != 0)
            {
                goto label_28;
            }
            
            SLC.Social.Leagues.LeaguesDataController val_12 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_50 = val_12.LastSeasonTier;
            goto label_32;
            label_18:
            this.league_points_section.SetActive(value:  false);
            if(guild.tier == 1)
            {
                goto label_34;
            }
            
            if(guild.tier != 0)
            {
                goto label_35;
            }
            
            UnityEngine.Debug.LogError(message:  "Tier is 0");
            goto label_68;
            label_28:
            val_50 = guild.tier;
            label_32:
            this.member_count_section.SetActive(value:  false);
            if((val_48 & 2147483648) != 0)
            {
                goto label_40;
            }
            
            val_48 = this.seasonRewardPointsText;
            if(val_48 == 0)
            {
                    return;
            }
            
            SLC.Social.Leagues.SeasonReward val_14 = SLC.Social.Leagues.LeaguesEconomy.GetSeasonRewardForTier(tier:  val_50);
            decimal val_15 = val_14.GetCategory4Reward;
            val_51 = guild;
            if(guild.rank <= 2)
            {
                goto label_47;
            }
            
            if(guild.rank <= 5)
            {
                goto label_48;
            }
            
            if(guild.rank > 11)
            {
                goto label_49;
            }
            
            val_52 = val_14;
            val_53 = 0;
            decimal val_16 = val_52.GetCategory3Reward;
            goto label_69;
            label_40:
            val_51 = guild.rank;
            goto label_51;
            label_34:
            this.GuildTierText.gameObject.SetActive(value:  false);
            this.GuildTierTextMesh.gameObject.SetActive(value:  true);
            val_54 = this.GuildTierTextMesh;
            string val_19 = SLC.Social.Leagues.GuildTierLoc.GetLocalizedTier(tier:  guild.tier);
            goto label_68;
            label_35:
            this.GuildTierTextMesh.gameObject.SetActive(value:  false);
            this.GuildTierText.gameObject.SetActive(value:  true);
            val_54 = this.GuildTierText;
            val_55 = null;
            val_55 = null;
            val_49 = SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors;
            int val_22 = SLC.Social.Leagues.LeaguesUIGuildTierDisplay.GuildTierToSimpleType.Item[guild.tier];
            if((SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors + 24) <= val_22)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_48 = SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors + 16;
            val_48 = val_48 + (val_22 << 3);
            string val_24 = System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  (SLC.Social.Leagues.LeaguesUIGuildTierDisplay.TierTextHexColors + 16 + (val_22) << 3) + 32, arg1:  SLC.Social.Leagues.GuildTierLoc.GetLocalizedTier(tier:  guild.tier));
            goto label_68;
            label_47:
            val_52 = val_14;
            val_53 = 0;
            decimal val_25 = val_52.GetCategory1Reward;
            goto label_69;
            label_48:
            val_52 = val_14;
            val_53 = 0;
            decimal val_26 = val_52.GetCategory2Reward;
            label_69:
            label_49:
            GameEcon val_27 = App.getGameEcon;
            string val_28 = val_26.flags.ToString(format:  val_27.numberFormatInt);
            label_51:
            if((val_50 == 1) || ((guild + 48) > 2))
            {
                goto label_75;
            }
            
            val_49 = UnityEngine.ColorUtility.ToHtmlStringRGB(color:  new UnityEngine.Color() {r = this.promotionColor});
            string val_31 = System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  val_49, arg1:  guild + 48.ToString());
            if((UnityEngine.Object.op_Implicit(exists:  this.up_arrow_promotion)) == false)
            {
                goto label_97;
            }
            
            val_56 = 1;
            goto label_81;
            label_75:
            val_49 = this.Rank;
            if((val_50 == 15) || ((guild + 48) < 12))
            {
                goto label_83;
            }
            
            string val_35 = System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  UnityEngine.ColorUtility.ToHtmlStringRGB(color:  new UnityEngine.Color() {r = this.demotionColor}), arg1:  guild + 48.ToString());
            if((UnityEngine.Object.op_Implicit(exists:  this.up_arrow_promotion)) != false)
            {
                    this.up_arrow_promotion.SetActive(value:  false);
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.down_arrow_demotion)) == false)
            {
                goto label_101;
            }
            
            val_57 = 1;
            goto label_93;
            label_83:
            string val_40 = System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  UnityEngine.ColorUtility.ToHtmlStringRGB(color:  new UnityEngine.Color() {r = this.normalColor}), arg1:  guild + 48.ToString());
            if((UnityEngine.Object.op_Implicit(exists:  this.up_arrow_promotion)) == false)
            {
                goto label_97;
            }
            
            val_56 = 0;
            label_81:
            this.up_arrow_promotion.SetActive(value:  false);
            label_97:
            if((UnityEngine.Object.op_Implicit(exists:  this.down_arrow_demotion)) == false)
            {
                goto label_101;
            }
            
            val_57 = 0;
            label_93:
            this.down_arrow_demotion.SetActive(value:  false);
            label_101:
            this.RankGameObject.SetActive(value:  true);
            label_68:
            val_48 = this.YourClubObject;
            if(val_48 == 0)
            {
                    return;
            }
            
            val_48 = 1152921505022660608;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_115;
            }
            
            SLC.Social.Leagues.Guild val_47 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            if(val_47.ServerId != guild.ServerId)
            {
                goto label_115;
            }
            
            this.YourClubObject.SetActive(value:  true);
            this.clickable = true;
            this.bgImage.sprite = this.you;
            val_58 = this.youBG;
            goto label_119;
            label_115:
            this.YourClubObject.SetActive(value:  false);
            this.bgImage.sprite = this.notYou;
            val_58 = this.notYouBG;
            label_119:
            this.bgTileImage.sprite = val_58;
        }
        public void OnClickGuildItem()
        {
            if(this.clickable == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance.ShowGuildInfoPopup(guildId:  this.guildDisplaying);
        }
        public void OnClick_JoinButton()
        {
            SLC.Social.Leagues.LeaguesManager.DAO.RespondToClubInvite(clubID:  this.guildDisplaying, accepted:  true);
        }
        public void OnClick_IgnoreButton()
        {
            SLC.Social.Leagues.LeaguesManager.DAO.RespondToClubInvite(clubID:  this.guildDisplaying, accepted:  false);
            SLC.Social.Leagues.LeaguesManager.DAO.RemoveGuildInviteById(guildId:  this.guildDisplaying);
            this.gameObject.SetActive(value:  false);
        }
        public LeaguesUIGuildGridItem()
        {
            UnityEngine.Color32 val_1 = new UnityEngine.Color32(r:  255, g:  255, b:  255, a:  255);
            UnityEngine.Color val_2 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_1.r, g = val_1.r, b = val_1.r, a = val_1.r});
            this.normalColor = val_2;
            mem[1152921519698787796] = val_2.g;
            mem[1152921519698787800] = val_2.b;
            mem[1152921519698787804] = val_2.a;
            UnityEngine.Color32 val_3 = new UnityEngine.Color32(r:  0, g:  255, b:  1, a:  255);
            UnityEngine.Color val_4 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_3.r, g = val_3.r, b = val_3.r, a = val_3.r});
            this.promotionColor = val_4;
            mem[1152921519698787812] = val_4.g;
            mem[1152921519698787816] = val_4.b;
            mem[1152921519698787820] = val_4.a;
            UnityEngine.Color32 val_5 = new UnityEngine.Color32(r:  253, g:  0, b:  0, a:  255);
            UnityEngine.Color val_6 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_5.r, g = val_5.r, b = val_5.r, a = val_5.r});
            this.demotionColor = val_6;
            mem[1152921519698787828] = val_6.g;
            mem[1152921519698787832] = val_6.b;
            mem[1152921519698787836] = val_6.a;
            this.guildDisplaying = 0;
            this.clickable = true;
        }
    
    }

}
