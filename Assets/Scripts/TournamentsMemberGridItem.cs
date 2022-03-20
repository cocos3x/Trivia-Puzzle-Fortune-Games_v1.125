using UnityEngine;
public class TournamentsMemberGridItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button mainButton;
    private UnityEngine.GameObject special_rank_1st;
    private UnityEngine.GameObject special_rank_2nd;
    private UnityEngine.GameObject special_rank_3rd;
    private UnityEngine.UI.Text text_rank;
    private AvatarSlotUGUI memberAvatar;
    private UnityEngine.UI.Text text_memberName;
    private UnityEngine.UI.Text text_winnings;
    private UnityEngine.GameObject reward_group;
    private UnityEngine.GameObject reward_gift;
    private UnityEngine.GameObject reward_gem;
    private UnityEngine.GameObject reward_coin;
    private UnityEngine.GameObject promotion;
    private UnityEngine.GameObject demotion;
    private UnityEngine.GameObject background_me;
    private UnityEngine.GameObject background_others;
    private SLC.Social.Profile profile;
    private System.Action<int> onClickAction;
    private TournamentsMembersListView _ListViewParent;
    
    // Properties
    private TournamentsMembersListView ListViewParent { get; }
    
    // Methods
    private TournamentsMembersListView get_ListViewParent()
    {
        TournamentsMembersListView val_4;
        if(this._ListViewParent == 0)
        {
                this._ListViewParent = this.transform.GetComponentInParent<TournamentsMembersListView>();
            return val_4;
        }
        
        val_4 = this._ListViewParent;
        return val_4;
    }
    private void Awake()
    {
        this.mainButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TournamentsMemberGridItem::OnClick()));
    }
    public void UpdateUIFromMember(SLC.Social.Profile memberProfile, int tierIndex, int rankIndex, int rankedWinnings, System.Action<int> clickAction, bool isMe = False)
    {
        var val_41;
        System.Action<System.Int32> val_42;
        int val_43;
        var val_44;
        UnityEngine.UI.Text val_45;
        bool val_46;
        var val_47;
        System.Int32[] val_49;
        var val_50;
        int val_51;
        val_42 = clickAction;
        val_43 = tierIndex;
        val_44 = this;
        if(memberProfile == null)
        {
            goto label_2;
        }
        
        this.gameObject.SetActive(value:  true);
        this.profile = memberProfile;
        val_41 = 1152921504765632512;
        int val_2 = rankIndex + 1;
        if(this.special_rank_1st != 0)
        {
                this.special_rank_1st.SetActive(value:  (rankIndex == 0) ? 1 : 0);
            this.text_rank.gameObject.SetActive(value:  (val_2 > 3) ? 1 : 0);
        }
        
        if(this.special_rank_2nd != 0)
        {
                this.special_rank_2nd.SetActive(value:  (val_2 == 2) ? 1 : 0);
            this.text_rank.gameObject.SetActive(value:  (val_2 > 3) ? 1 : 0);
        }
        
        if(this.special_rank_3rd == 0)
        {
            goto label_17;
        }
        
        this.special_rank_3rd.SetActive(value:  (val_2 == 3) ? 1 : 0);
        val_45 = val_44;
        this.text_rank.gameObject.SetActive(value:  (val_2 > 3) ? 1 : 0);
        goto label_21;
        label_2:
        val_46 = 0;
        goto label_64;
        label_17:
        val_45 = this.text_rank;
        label_21:
        string val_15 = val_2.ToString();
        string val_16 = rankedWinnings.ToString();
        this.onClickAction = val_42;
        this.background_me.SetActive(value:  isMe);
        this.background_others.SetActive(value:  (~isMe) & 1);
        val_42 = 1152921504900829184;
        val_47 = null;
        val_47 = null;
        val_49 = TournamentsEconomy.rewardIndexByRank;
        if(TournamentsEconomy.rewardIndexByRank.Length <= rankIndex)
        {
            goto label_33;
        }
        
        val_49 = TournamentsEconomy.rewardIndexByRank;
        System.Int32[][] val_40 = TournamentsEconomy.giftRewardsByTier;
        val_40 = val_40 + (((long)(int)(tierIndex)) << 3);
        val_49 = val_49 + (val_2 << 2);
        var val_19 = ((TournamentsEconomy.giftRewardsByTier + ((long)(int)(tierIndex)) << 3) + 32) + (((TournamentsEconomy.rewardIndexByRank + ((rankIndex + 1)) << 2) + 32) << 2);
        this.reward_gift.SetActive(value:  ((((TournamentsEconomy.giftRewardsByTier + ((long)(int)(tierIndex)) << 3) + 32 + ((TournamentsEconomy.rewardIndexByRank + ((rankIndex + 1)) << 2) + 32) << 2) + 32) > 0) ? 1 : 0);
        this.reward_gem.SetActive(value:  ((TournamentsEconomy.gemOrPetFoodRewardsByTier[(long)val_43][((TournamentsEconomy.rewardIndexByRank + ((rankIndex + 1)) << 2) + 32) << 2]) > 0) ? 1 : 0);
        System.Int32[][] val_43 = TournamentsEconomy.coinRewardsByTier;
        val_43 = val_43 + (((long)(int)(tierIndex)) << 3);
        var val_44 = (TournamentsEconomy.coinRewardsByTier + ((long)(int)(tierIndex)) << 3) + 32;
        val_44 = val_44 + (((TournamentsEconomy.rewardIndexByRank + ((rankIndex + 1)) << 2) + 32) << 2);
        this.reward_coin.SetActive(value:  ((((TournamentsEconomy.coinRewardsByTier + ((long)(int)(tierIndex)) << 3) + 32 + ((TournamentsEconomy.rewardIndexByRank + ((rankIndex + 1)) << 2) + 32) << 2) + 32) > 0) ? 1 : 0);
        if((TournamentsEconomy.TierIndexCanPromote(tierIndex:  val_43)) == false)
        {
            goto label_53;
        }
        
        val_50 = TournamentsEconomy.RankIndexIsPromotion(rankIndex:  rankIndex);
        if(this.promotion != null)
        {
            goto label_56;
        }
        
        label_33:
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "{0} TournamentsMemberGridItem attempting to set up, but will exceed econ index range. Somehow too many members in this Tournament!", arg0:  Ordinal.GetOrdinalFormat(num:  rankIndex)));
        val_44 = this.gameObject;
        val_46 = CompanyDevices.Instance.CompanyDevice();
        goto label_64;
        label_53:
        val_50 = 0;
        label_56:
        this.promotion.SetActive(value:  false);
        if((TournamentsEconomy.TierIndexCanDemote(tierIndex:  val_43)) == false)
        {
            goto label_68;
        }
        
        val_51 = rankIndex;
        bool val_32 = TournamentsEconomy.RankIndexIsDemotion(rankIndex:  val_51);
        if(this.demotion != null)
        {
            goto label_71;
        }
        
        label_68:
        val_51 = 0;
        label_71:
        this.demotion.SetActive(value:  val_51 & 1);
        if((this.reward_gift.activeSelf != true) && (this.reward_gem.activeSelf != true))
        {
                if(this.reward_coin.activeSelf != true)
        {
                if(this.promotion.activeSelf == false)
        {
            goto label_81;
        }
        
        }
        
        }
        
        label_87:
        val_43 = this.reward_group;
        if(val_43 == 0)
        {
                return;
        }
        
        val_46 = 1 & 1;
        label_64:
        this.reward_group.SetActive(value:  val_46);
        return;
        label_81:
        bool val_39 = this.demotion.activeSelf;
        goto label_87;
    }
    private void OnClick()
    {
        if(this.onClickAction == null)
        {
                return;
        }
        
        this.onClickAction.Invoke(obj:  this.profile.ServerId);
    }
    private void ScrollCellIndex(int index)
    {
        this.ListViewParent.SetupGridItem(memberGridItem:  this, itemIndex:  index);
    }
    public TournamentsMemberGridItem()
    {
    
    }

}
