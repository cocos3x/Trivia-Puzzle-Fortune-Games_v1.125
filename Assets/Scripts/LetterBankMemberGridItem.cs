using UnityEngine;
public class LetterBankMemberGridItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button mainButton;
    private UnityEngine.UI.Text text_rank;
    private AvatarSlotUGUI memberAvatar;
    private UnityEngine.UI.Text text_memberName;
    private UnityEngine.UI.Text text_winnings;
    private UnityEngine.GameObject background_me;
    private UnityEngine.GameObject background_others;
    private UnityEngine.UI.Image image_goldenTicket;
    private UnityEngine.Sprite hasGT;
    private UnityEngine.Sprite noGT;
    private UnityEngine.UI.Text text_leadership;
    private SLC.Social.Profile profile;
    private System.Action<int> onClickAction;
    private LetterBankMembersListView _ListViewParent;
    
    // Properties
    private LetterBankMembersListView ListViewParent { get; }
    
    // Methods
    private LetterBankMembersListView get_ListViewParent()
    {
        LetterBankMembersListView val_4;
        if(this._ListViewParent == 0)
        {
                this._ListViewParent = this.transform.GetComponentInParent<LetterBankMembersListView>();
            return val_4;
        }
        
        val_4 = this._ListViewParent;
        return val_4;
    }
    private void Awake()
    {
        this.mainButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LetterBankMemberGridItem::OnClick()));
    }
    public void UpdateUIFromMember(SLC.Social.Profile memberProfile, int rankIndex, int rankedWinnings, System.Action<int> clickAction, bool isMe = False)
    {
        bool val_11;
        UnityEngine.UI.Text val_12;
        UnityEngine.Sprite val_13;
        var val_14;
        val_11 = isMe;
        val_12 = rankIndex;
        UnityEngine.GameObject val_1 = this.gameObject;
        if(memberProfile == null)
        {
            goto label_2;
        }
        
        val_1.SetActive(value:  true);
        this.profile = memberProfile;
        string val_3 = val_12 + 1.ToString();
        val_12 = this.text_winnings;
        string val_4 = rankedWinnings.ToString();
        this.onClickAction = clickAction;
        this.background_me.SetActive(value:  val_11);
        this.background_others.SetActive(value:  (~val_11) & 1);
        val_11 = this.image_goldenTicket;
        if(val_11 == 0)
        {
            goto label_12;
        }
        
        if(memberProfile.hasSubscriptionActive == false)
        {
            goto label_13;
        }
        
        val_13 = this.hasGT;
        goto label_15;
        label_2:
        val_1.SetActive(value:  false);
        return;
        label_13:
        val_13 = this.noGT;
        label_15:
        this.image_goldenTicket.sprite = val_13;
        label_12:
        UnityEngine.GameObject val_8 = this.text_leadership.gameObject;
        if(memberProfile.GuildMaster == false)
        {
            goto label_19;
        }
        
        val_14 = 1;
        if(val_8 != null)
        {
            goto label_20;
        }
        
        label_19:
        label_20:
        val_8.SetActive(value:  (memberProfile.Officer == true) ? 1 : 0);
        var val_10 = (memberProfile.GuildMaster == false) ? "CO-LEADER" : "LEADER";
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
    public LetterBankMemberGridItem()
    {
    
    }

}
