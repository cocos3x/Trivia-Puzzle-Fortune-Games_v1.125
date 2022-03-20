using UnityEngine;
public class TournamentsMembersListView : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.LoopVerticalScrollRect loopScrollRect;
    private UnityEngine.GameObject parentWindow;
    private TournamentInfo tournamentInfo;
    private SLC.Social.Profile myProfile;
    private bool initialized;
    private static UnityEngine.UI.LoopScrollPrefabSource _prefabSource;
    private UnityEngine.GameObject _tournamentMemberGridItemPrefab;
    private TournamentsPopup parentTournamentsPopup;
    
    // Properties
    private UnityEngine.GameObject tournamentMemberGridItemPrefab { get; }
    private TournamentsPopup ParentTournamentsPopup { get; }
    
    // Methods
    private UnityEngine.GameObject get_tournamentMemberGridItemPrefab()
    {
        UnityEngine.GameObject val_4;
        if(this._tournamentMemberGridItemPrefab == 0)
        {
                this._tournamentMemberGridItemPrefab = PrefabLoader.LoadPrefab<TournamentsMemberGridItem>(featureName:  "Tournaments").gameObject;
            return val_4;
        }
        
        val_4 = this._tournamentMemberGridItemPrefab;
        return val_4;
    }
    private TournamentsPopup get_ParentTournamentsPopup()
    {
        TournamentsPopup val_3;
        if(this.parentTournamentsPopup != 0)
        {
                val_3 = this.parentTournamentsPopup;
            return val_2;
        }
        
        TournamentsPopup val_2 = this.parentWindow.GetComponent<TournamentsPopup>();
        this.parentTournamentsPopup = val_2;
        return val_2;
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
    public void Refresh(UnityEngine.GameObject parentWindowObject, TournamentInfo tournamentInfo, bool refillCells = False)
    {
        this.DoInit();
        this.parentWindow = parentWindowObject;
        this.tournamentInfo = tournamentInfo;
        mem2[0] = tournamentInfo.tournamentPlayers;
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.RefreshMyCells(refill:  refillCells));
    }
    public System.Collections.IEnumerator RefreshMyCells(bool refill)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .refill = refill;
        return (System.Collections.IEnumerator)new TournamentsMembersListView.<RefreshMyCells>d__15();
    }
    public void SetupGridItem(TournamentsMemberGridItem memberGridItem, int itemIndex)
    {
        System.Action<System.Int32> val_4;
        TournamentInfo val_4 = this.tournamentInfo;
        if(val_4 <= itemIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + (itemIndex << 3);
        SLC.Social.Profile val_1 = (this.tournamentInfo + (itemIndex) << 3).tournamentPlayers.ToProfile();
        if(W25 != 0)
        {
                System.Action<System.Int32> val_2 = null;
            val_4 = val_2;
            val_2 = new System.Action<System.Int32>(object:  this, method:  System.Void TournamentsMembersListView::OnMemberClickedCallback(int memberId));
            this.myProfile = val_1;
        }
        else
        {
                val_4 = 0;
        }
        
        memberGridItem.UpdateUIFromMember(memberProfile:  val_1, tierIndex:  this.tournamentInfo.tierIndex, rankIndex:  itemIndex, rankedWinnings:  (this.tournamentInfo + (itemIndex) << 3).tournamentPlayers, clickAction:  val_4, isMe:  (W25 != 0) ? 1 : 0);
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
        if(TournamentsMembersListView._prefabSource == null)
        {
                val_5 = null;
            val_5 = null;
            TournamentsMembersListView._prefabSource = new UnityEngine.UI.LoopScrollPrefabSource();
            mem[1152921515921349184] = this.tournamentMemberGridItemPrefab;
            val_4 = null;
            mem[1152921515921349192] = 3;
        }
        
        val_3 = this.loopScrollRect;
        mem2[0] = TournamentsMembersListView._prefabSource;
    }
    private bool IsMe(int serverId)
    {
        SLC.Social.Profile val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        return (bool)(val_2.ServerId == serverId) ? 1 : 0;
    }
    private void OnMemberClickedCallback(int memberId)
    {
        if(this.parentWindow != 0)
        {
                if(this.ParentTournamentsPopup != 0)
        {
                TournamentsPopup val_4 = this.ParentTournamentsPopup;
            if(val_4.allowProfileAccess == false)
        {
                return;
        }
        
        }
        
        }
        
        SLC.Social.Leagues.LeaguesUIManager.ShowPlayerProfile(serverId:  this.myProfile.ServerId, gridItem:  0);
    }
    public TournamentsMembersListView()
    {
    
    }
    private static TournamentsMembersListView()
    {
    
    }

}
