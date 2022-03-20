using UnityEngine;
[Serializable]
public class WGEventButton_Game : MonoBehaviour
{
    // Fields
    public const string ON_WGEVENT_GAME_BUTTON_UPDATE = "OnGameEventButtonUpdate";
    private readonly UnityEngine.Vector2 icon_size;
    public UGUINetworkedButton event_button;
    public UnityEngine.UI.Image button_prefix;
    public UnityEngine.UI.Text event_text_above;
    public UnityEngine.GameObject event_text_bg;
    public UnityEngine.UI.Text event_text;
    public UnityEngine.UI.Image button_suffix;
    public UnityEngine.UI.Image event_icon;
    public UnityEngine.GameObject opposingButton;
    public UnityEngine.GameObject rewardTooltip;
    public UnityEngine.GameObject messageTooltip;
    public UnityEngine.UI.Text messageTooltipText;
    public UnityEngine.Transform event_middle_root;
    private UnityEngine.Coroutine removeMessageTooltipCoroutine;
    private UnityEngine.Coroutine timerCoroutine;
    public UnityEngine.Sprite lcMenuSprite;
    public UnityEngine.Sprite lcGameSprite;
    public UnityEngine.Sprite ecMenuSprite;
    public UnityEngine.Sprite ecGameSprite;
    public UnityEngine.Sprite wwGameSprite;
    public UnityEngine.Sprite pcMenuSprite;
    public UnityEngine.Sprite pcGameSprite;
    public UnityEngine.Sprite ccCvCGameSprite;
    public UnityEngine.Sprite apGameSprite;
    public UnityEngine.Sprite pbGameSprite;
    public UnityEngine.Sprite pb2GameSprite;
    public UnityEngine.Sprite lbdGameSprite;
    public UnityEngine.GameObject lbdRankupFlyout;
    private UnityEngine.Coroutine removeFlyoutCoroutine;
    public UnityEngine.Sprite lwGameSprite;
    public UnityEngine.Sprite wordHuntGameSprite;
    public UnityEngine.Sprite vipPartyGameSprite;
    public UnityEngine.Sprite ggGameSprite;
    public UnityEngine.Sprite superStreakGameSprite;
    public UnityEngine.Sprite superStreakInactiveSprite;
    public UnityEngine.Sprite hotStreakGameSprite;
    public UnityEngine.Sprite hotStreakInactiveSprite;
    public UnityEngine.Sprite lightningLevelsGameSprite;
    public UnityEngine.Sprite hintManiaGameSprite;
    public UnityEngine.Sprite onTheTrailGameSprite;
    public UnityEngine.Sprite keyToRichesSprite;
    public UnityEngine.Sprite superBundleSprite;
    public UnityEngine.Sprite bingoSprite;
    public UnityEngine.Sprite piggyBankRaidGameSprite;
    public UnityEngine.Sprite seasonPassSprite;
    public UnityEngine.Sprite snakesAndLaddersGameSprite;
    public UnityEngine.Sprite spinKingMenuSprite;
    public UnityEngine.Sprite islandParadiseSprite;
    public UnityEngine.Sprite letterBankGameSprite;
    public UnityEngine.Sprite forestFrenzySprite;
    public UnityEngine.Sprite prgressiveIAPSprite;
    public UnityEngine.ParticleSystem progressEffect;
    private WGEventHandler currentEventHandler;
    private bool mustShowRankupFlyout;
    
    // Methods
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventControllerUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventHandlerProgress");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "ShowRankupFlyout");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "ShowWordHuntTooltip");
        NotificationCenter val_6 = NotificationCenter.DefaultCenter;
        val_6.AddObserver(observer:  this, name:  "DoneQueuingAvailablePopups");
        val_6.RemoveAllListeners();
        System.Delegate val_8 = System.Delegate.Combine(a:  this.event_button.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGEventButton_Game::OnClick(bool result)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        this.event_button.OnConnectionClick = val_8;
        return;
        label_13:
    }
    private void OnEnable()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateDisplayDelayed());
    }
    private void OnClick(bool result)
    {
        if(this.currentEventHandler != null)
        {
                if((this.currentEventHandler & 1) == 0)
        {
                if((this.currentEventHandler & 1) == 0)
        {
            goto label_4;
        }
        
        }
        
            bool val_1 = result;
            if(this.rewardTooltip != 0)
        {
                this.rewardTooltip.SetActive(value:  false);
        }
        
            if(this.messageTooltip == 0)
        {
                return;
        }
        
            this.messageTooltip.SetActive(value:  false);
            return;
        }
        
        label_4:
        GameBehavior val_4 = App.getBehavior;
        this = ???;
        goto mem[(1152921504946249728 + (public WGEventsListPopup MetaGameBehavior::ShowUGUIMonolith<WGEventsListPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    private void OnGameEventControllerUpdate()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateDisplayDelayed());
    }
    private void OnGameEventHandlerProgress()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateDisplayDelayed());
    }
    private void OnLocalize()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateDisplayDelayed());
    }
    private void UpdateDisplay()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateDisplayDelayed());
    }
    private System.Collections.IEnumerator UpdateDisplayDelayed()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGEventButton_Game.<UpdateDisplayDelayed>d__62();
    }
    private void showLeaderboardFlyout()
    {
        var val_3;
        this.lbdRankupFlyout.SetActive(value:  true);
        val_3 = null;
        val_3 = null;
        typeof(LeaderboardEventPlayerInfo_Self).__il2cppRuntimeField_38 = 0;
        this.removeFlyoutCoroutine = this.StartCoroutine(routine:  this.RemoveFlyoutOnClick(flyout:  this.lbdRankupFlyout));
    }
    private void ShowWordHuntTooltip()
    {
        if((System.String.op_Equality(a:  (this.currentEventHandler.myEvent == 0) ? "" : this.currentEventHandler.myEvent.type, b:  "WordHunt")) == false)
        {
                return;
        }
        
        this.ShowToolTip(message:  "You found a Word Hunt word!");
    }
    private void DoneQueuingAvailablePopups()
    {
        if(this.mustShowRankupFlyout == false)
        {
                return;
        }
        
        if((System.String.op_Equality(a:  (this.currentEventHandler.myEvent == 0) ? "" : this.currentEventHandler.myEvent.type, b:  "Leaderboard")) == false)
        {
                return;
        }
        
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.GetWindow<WGGameSceneFlyoutProxy>();
        mem2[0] = new System.Action(object:  this, method:  System.Void WGEventButton_Game::showLeaderboardFlyout());
        WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGGameSceneFlyoutProxy>(showNext:  false);
    }
    private void ShowRankupFlyout()
    {
        this.mustShowRankupFlyout = true;
    }
    private void ShowToolTip(string message)
    {
        if(this.messageTooltip == 0)
        {
                return;
        }
        
        this.messageTooltip.SetActive(value:  true);
        this.removeMessageTooltipCoroutine = this.StartCoroutine(routine:  this.RemoveFlyoutOnClick(flyout:  this.messageTooltip));
    }
    private System.Collections.IEnumerator RemoveFlyoutOnClick(UnityEngine.GameObject flyout)
    {
        .<>1__state = 0;
        .flyout = flyout;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGEventButton_Game.<RemoveFlyoutOnClick>d__68();
    }
    private System.Collections.IEnumerator UpdateButtonTextTimer(int seconds)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .seconds = seconds;
        return (System.Collections.IEnumerator)new WGEventButton_Game.<UpdateButtonTextTimer>d__69();
    }
    public WGEventButton_Game()
    {
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  100f, y:  100f);
        this.icon_size = val_1.x;
    }

}
