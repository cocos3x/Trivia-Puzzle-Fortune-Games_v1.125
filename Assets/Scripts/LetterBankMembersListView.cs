using UnityEngine;
public class LetterBankMembersListView : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.LoopVerticalScrollRect loopScrollRect;
    private UnityEngine.GameObject parentWindow;
    private System.Collections.Generic.List<LetterBankEventPlayer> eventPlayers;
    private SLC.Social.Profile myProfile;
    private bool initialized;
    private static UnityEngine.UI.LoopScrollPrefabSource _prefabSource;
    private UnityEngine.GameObject _letterBankMemberGridItemPrefab;
    
    // Properties
    private UnityEngine.GameObject letterBankMemberGridItemPrefab { get; }
    
    // Methods
    private UnityEngine.GameObject get_letterBankMemberGridItemPrefab()
    {
        UnityEngine.GameObject val_4;
        if(this._letterBankMemberGridItemPrefab == 0)
        {
                this._letterBankMemberGridItemPrefab = PrefabLoader.LoadPrefab<LetterBankMemberGridItem>(featureName:  "LetterBankEvent").gameObject;
            return val_4;
        }
        
        val_4 = this._letterBankMemberGridItemPrefab;
        return val_4;
    }
    private void OnEnable()
    {
        this.DoInit();
    }
    private void OnDisable()
    {
        if(this.loopScrollRect != null)
        {
                this.loopScrollRect.ClearCells();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void Refresh(UnityEngine.GameObject parentWindowObject, System.Collections.Generic.List<LetterBankEventPlayer> eventPlayers, bool refillCells = False)
    {
        UnityEngine.UI.LoopVerticalScrollRect val_4;
        var val_5;
        this.DoInit();
        this.parentWindow = parentWindowObject;
        if(eventPlayers != null)
        {
                val_4 = this.loopScrollRect;
            this.eventPlayers = eventPlayers;
        }
        else
        {
                val_4 = this.loopScrollRect;
            val_5 = 0;
        }
        
        mem2[0] = val_5;
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.RefreshMyCells(refill:  refillCells));
    }
    public System.Collections.IEnumerator RefreshMyCells(bool refill)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .refill = refill;
        return (System.Collections.IEnumerator)new LetterBankMembersListView.<RefreshMyCells>d__12();
    }
    public void SetupGridItem(LetterBankMemberGridItem memberGridItem, int itemIndex)
    {
        SLC.Social.Profile val_6;
        bool val_6 = true;
        if(val_6 <= itemIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (itemIndex << 3);
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.GetGuildMember(memberId:  (true + (itemIndex) << 3) + 32 + 16);
        val_6 = val_2;
        if(val_2 == null)
        {
                val_6 = (true + (itemIndex) << 3) + 32.ToProfile();
        }
        
        if(((true + (itemIndex) << 3) + 32 + 49) == 0)
        {
            goto label_8;
        }
        
        this.myProfile = val_6;
        label_10:
        memberGridItem.UpdateUIFromMember(memberProfile:  val_6, rankIndex:  itemIndex, rankedWinnings:  (true + (itemIndex) << 3) + 32 + 32, clickAction:  new System.Action<System.Int32>(object:  this, method:  System.Void LetterBankMembersListView::OnMemberClickedCallback(int memberId)), isMe:  (((true + (itemIndex) << 3) + 32 + 49) != 0) ? 1 : 0);
        return;
        label_8:
        if(memberGridItem != null)
        {
            goto label_10;
        }
        
        throw new NullReferenceException();
    }
    private void DoInit()
    {
        UnityEngine.UI.LoopVerticalScrollRect val_3;
        var val_4;
        var val_5;
        val_3 = this;
        if(this.initialized == true)
        {
                return;
        }
        
        val_4 = null;
        val_4 = null;
        if(LetterBankMembersListView._prefabSource == null)
        {
                val_5 = null;
            val_5 = null;
            LetterBankMembersListView._prefabSource = new UnityEngine.UI.LoopScrollPrefabSource();
            mem[1152921516325238848] = this.letterBankMemberGridItemPrefab;
            val_4 = null;
            mem[1152921516325238856] = 3;
        }
        
        val_3 = this.loopScrollRect;
        mem2[0] = LetterBankMembersListView._prefabSource;
    }
    private bool IsMe(int serverId)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        return (bool)(val_2.ServerId == serverId) ? 1 : 0;
    }
    private void OnMemberClickedCallback(int memberId)
    {
        SLC.Social.Leagues.LeaguesUIManager.ShowPlayerProfile(serverId:  this.myProfile.ServerId, gridItem:  0);
    }
    public LetterBankMembersListView()
    {
    
    }
    private static LetterBankMembersListView()
    {
    
    }

}
