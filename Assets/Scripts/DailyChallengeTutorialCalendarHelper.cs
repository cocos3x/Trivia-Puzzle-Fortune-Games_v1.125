using UnityEngine;
public class DailyChallengeTutorialCalendarHelper : MonoSingleton<DailyChallengeTutorialCalendarHelper>
{
    // Fields
    private UnityEngine.GameObject zooTilesFocus;
    private UnityEngine.GameObject previousChallengeFocus;
    private DynamicToolTip TT;
    
    // Methods
    private void OnEnable()
    {
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) == 0)
        {
                return;
        }
        
        DailyChallengeTutorialManager val_3 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
        if(val_3._TutorialActive == false)
        {
                return;
        }
        
        this.ShowZooTilesStep();
    }
    private void ShowZooTilesStep()
    {
        UnityEngine.Color val_2 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.45f);
        System.Nullable<UnityEngine.Color> val_3 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.5f, fadeOutDuration:  0.15f);
        GameMaskOverlay val_4 = MonoSingleton<GameMaskOverlay>.Instance;
        System.Collections.Generic.List<UnityEngine.Transform> val_5 = new System.Collections.Generic.List<UnityEngine.Transform>();
        DynamicToolTip val_7 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        this.TT = val_7;
        this.TT.ShowToolTip(objToToolTip:  this.zooTilesFocus, text:  Localization.Localize(key:  "dc_ftux_calendar1", defaultValue:  "Play twice a day to collect coin rewards and ZOO TILES!", useSingularKey:  false), topToolTip:  true, displayDuration:  -1f, width:  800f, height:  300f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  true, gotItCallback:  new System.Action(object:  this, method:  System.Void DailyChallengeTutorialCalendarHelper::OnZooTilesGotItClicked()), showPick:  false, maxFontSize:  0);
        val_5.Add(item:  this.zooTilesFocus.transform);
        val_5.Add(item:  val_7.gameObject.transform);
        val_4.BlockRaycasts = true;
        val_4.Interactable = true;
        val_4.ShowOverlay(contentToOverlay:  val_5.ToArray());
    }
    private void OnZooTilesGotItClicked()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.TT)) != false)
        {
                this.TT.Dismiss();
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        this.ShowPreviousChallengeStep();
    }
    private void ShowPreviousChallengeStep()
    {
        UnityEngine.Color val_2 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.45f);
        System.Nullable<UnityEngine.Color> val_3 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.5f, fadeOutDuration:  0.15f);
        GameMaskOverlay val_4 = MonoSingleton<GameMaskOverlay>.Instance;
        System.Collections.Generic.List<UnityEngine.Transform> val_5 = new System.Collections.Generic.List<UnityEngine.Transform>();
        DynamicToolTip val_7 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        this.TT = val_7;
        this.TT.ShowToolTip(objToToolTip:  this.previousChallengeFocus, text:  Localization.Localize(key:  "dc_ftux_calendar2", defaultValue:  "You can play previous challenges to earn all your STARS!", useSingularKey:  false), topToolTip:  false, displayDuration:  -1f, width:  800f, height:  300f, tooltipOffsetX:  0f, tooltipOffsetY:  -40f, viewportSettings:  0, showGotItButton:  true, gotItCallback:  new System.Action(object:  this, method:  System.Void DailyChallengeTutorialCalendarHelper::OnPreviousChallengeGotItClicked()), showPick:  false, maxFontSize:  0);
        val_5.Add(item:  this.previousChallengeFocus.transform);
        val_5.Add(item:  val_7.gameObject.transform);
        val_4.BlockRaycasts = true;
        val_4.Interactable = true;
        val_4.ShowOverlay(contentToOverlay:  val_5.ToArray());
        val_4.AllowButtonClicks(parentObject:  this.previousChallengeFocus, allowInteraction:  false);
    }
    private void OnPreviousChallengeGotItClicked()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.TT)) != false)
        {
                this.TT.Dismiss();
        }
        
        this.TT.AllowButtonClicks(parentObject:  this.previousChallengeFocus, allowInteraction:  true);
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        MonoSingleton<DailyChallengeTutorialManager>.Instance.HandlePreviousChallengesPrompted();
    }
    private void AllowButtonClicks(UnityEngine.GameObject parentObject, bool allowInteraction)
    {
        if(val_1.Length < 1)
        {
                return;
        }
        
        var val_4 = 0;
        do
        {
            parentObject.GetComponentsInChildren<UnityEngine.UI.Button>(includeInactive:  false)[val_4].interactable = allowInteraction;
            val_4 = val_4 + 1;
        }
        while(val_4 < val_1.Length);
    
    }
    public DailyChallengeTutorialCalendarHelper()
    {
    
    }

}
