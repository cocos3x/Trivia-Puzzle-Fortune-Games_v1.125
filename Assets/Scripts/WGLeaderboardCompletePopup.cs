using UnityEngine;
public class WGLeaderboardCompletePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject winner_section;
    private UnityEngine.UI.HorizontalLayoutGroup rank_group;
    private UnityEngine.UI.Text winner_rank;
    private UnityEngine.UI.Text winner_rank_suffix;
    private UnityEngine.UI.Text winner_reward;
    private UnityEngine.UI.Button collect_button;
    private GridCoinCollectAnimationInstantiator coinAnim;
    private GemsCollectAnimationInstantiator gemAnim;
    private UnityEngine.GameObject loser_section;
    private UnityEngine.UI.Text loser_rank;
    private UnityEngine.UI.Button continue_button;
    private int playerReward;
    private int playerRank;
    
    // Methods
    private void Awake()
    {
        this.rank_group.enabled = false;
        this.winner_section.SetActive(value:  false);
        this.loser_section.SetActive(value:  false);
    }
    private void OnEnable()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        this.playerRank = LeaderboardEventHandler.instance.playerInfo;
        val_3 = null;
        val_3 = null;
        int val_1 = LeaderboardEventHandler.instance.GetCurrentReward();
        this.playerReward = val_1;
        if(val_1 != 0)
        {
                this.SetupWinnerSection();
            return;
        }
        
        this.SetupLoserSection();
    }
    private void SetupWinnerSection()
    {
        var val_11;
        System.Delegate val_12;
        string val_1 = this.playerRank.ToString();
        string val_2 = Ordinal.AddOrdinal(num:  this.playerRank);
        string val_3 = this.playerReward.ToString();
        val_11 = null;
        val_11 = null;
        if(LeaderboardEventHandler.instance.EventRewardsGems() != false)
        {
                new UnityEngine.Events.UnityAction() = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardCompletePopup::PlayGemAnim());
            this.collect_button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction());
            System.Action val_6 = null;
            val_12 = val_6;
            val_6 = new System.Action(object:  this, method:  System.Void WGLeaderboardCompletePopup::OnCoinAnimFinished());
            System.Delegate val_7 = System.Delegate.Combine(a:  this.collect_button.m_OnClick, b:  val_6);
            if(val_7 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
            mem2[0] = val_7;
        }
        else
        {
                new UnityEngine.Events.UnityAction() = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardCompletePopup::PlayCoinAnim());
            this.collect_button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction());
            System.Action val_9 = null;
            val_12 = val_9;
            val_9 = new System.Action(object:  this, method:  System.Void WGLeaderboardCompletePopup::OnCoinAnimFinished());
            System.Delegate val_10 = System.Delegate.Combine(a:  this.coinAnim.OnCompleteCallback, b:  val_9);
            if(val_10 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
            this.coinAnim.OnCompleteCallback = val_10;
        }
        
        this.winner_section.SetActive(value:  true);
        this.rank_group.enabled = true;
        return;
        label_20:
    }
    private void SetupLoserSection()
    {
        string val_1 = this.playerRank + "+"("+");
        this.continue_button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardCompletePopup::ClosePopup()));
        this.loser_section.SetActive(value:  true);
    }
    private void PlayGemAnim()
    {
        var val_10;
        this.collect_button.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardCompletePopup::PlayCoinAnim()));
        App.Player.AddGems(amount:  this.playerReward, source:  "Leaderboard Reward", subsource:  0);
        App.Player.TrackNonCoinReward(source:  "Leaderboard Reward", subSource:  0, rewardType:  "Gems", rewardAmount:  this.playerReward.ToString(), additionalParams:  0);
        MonoSingleton<WordGameEventsController>.Instance.StopAllCoroutines();
        val_10 = null;
        val_10 = null;
        LeaderboardEventHandler.instance.UpdateProgressionToServer(progress:  0, rewarded:  true);
        Player val_6 = App.Player;
        Player val_7 = App.Player;
        decimal val_8 = System.Decimal.op_Implicit(value:  val_7._gems);
        this.gemAnim.Play(fromValue:  val_6._gems - this.playerReward, toValue:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void PlayCoinAnim()
    {
        var val_9;
        this.collect_button.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardCompletePopup::PlayCoinAnim()));
        decimal val_3 = System.Decimal.op_Implicit(value:  this.playerReward);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, source:  "Leaderboard Reward", subSource:  0, externalParams:  0, doTrack:  true);
        MonoSingleton<WordGameEventsController>.Instance.StopAllCoroutines();
        val_9 = null;
        val_9 = null;
        LeaderboardEventHandler.instance.UpdateProgressionToServer(progress:  0, rewarded:  true);
        Player val_5 = App.Player;
        decimal val_6 = System.Decimal.op_Implicit(value:  this.playerReward);
        decimal val_7 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
        Player val_8 = App.Player;
        this.coinAnim.Play(fromValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, toValue:  new System.Decimal() {flags = val_8._credits, hi = val_8._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void OnCoinAnimFinished()
    {
        this.ClosePopup();
    }
    private void ClosePopup()
    {
        var val_3;
        var val_4;
        val_3 = null;
        val_3 = null;
        rewarded = true;
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        val_4 = null;
        val_4 = null;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDisable()
    {
        null = null;
        LeaderboardEventHandler.instance.OnMyEventPopupClosed();
    }
    public WGLeaderboardCompletePopup()
    {
    
    }

}
