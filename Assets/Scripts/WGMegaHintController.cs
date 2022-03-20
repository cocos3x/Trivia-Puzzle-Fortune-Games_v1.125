using UnityEngine;
public class WGMegaHintController : MonoSingleton<WGMegaHintController>
{
    // Fields
    private bool canHint;
    private UnityEngine.Sprite raySprite;
    private int numMegaHints;
    private float TimePerAnim;
    private float timePerSecondary;
    private float timeProgress;
    
    // Methods
    public void OnMegaHintPressed(bool freeHint = False)
    {
        System.Collections.Generic.List<LineWord> val_27;
        var val_28;
        var val_29;
        var val_30;
        if(this.canHint == false)
        {
                return;
        }
        
        decimal val_1 = CurrencyController.GetBalance();
        GameEcon val_2 = App.getGameEcon;
        if(((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2._HintMEGACost, hi = val_2._HintMEGACost, lo = X24, mid = X24})) != true) && (freeHint != true))
        {
                val_28 = null;
            val_28 = null;
            PurchaseProxy.currentPurchasePoint = 9;
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  0);
            return;
        }
        
        if(freeHint != true)
        {
                GameEcon val_6 = App.getGameEcon;
            bool val_7 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_6._HintMEGACost, hi = val_6._HintMEGACost, lo = val_1.lo, mid = val_1.mid}, source:  "Mega Hint", externalParams:  0, animated:  false);
        }
        
        Prefs.AddToNumHint(world:  Prefs.currentWorld, subWorld:  Prefs.currentChapter, level:  Prefs.currentLevel);
        System.Collections.Generic.List<LineWord> val_11 = null;
        val_27 = val_11;
        val_11 = new System.Collections.Generic.List<LineWord>();
        val_29 = 0;
        WordRegion val_14 = WordRegion.instance;
        Prefs.AddToNumHint(world:  Prefs.currentWorld, subWorld:  Prefs.currentChapter, level:  Prefs.currentLevel);
        Prefs.HasUsedHintMega = true;
        MainController.instance.HintsUsedMega = val_18.megarHintsUsed + 1;
        if(freeHint != false)
        {
                MainController.instance.FreeHintsUsed = true;
        }
        else
        {
                NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnHintUsed");
            val_30 = null;
            val_30 = null;
            App.trackerManager.track(eventName:  "Mega Hint");
            Player val_22 = App.Player;
            int val_29 = val_22.properties.HintsUsedOnCurrentChapter;
            val_29 = val_29 + 1;
            val_22.properties.HintsUsedOnCurrentChapter = val_29;
        }
        
        this.canHint = false;
        WordRegion val_23 = WordRegion.instance;
        val_23.canHint = false;
        UnityEngine.Coroutine val_26 = this.StartCoroutine(routine:  this.CoolMegaHint(availableLines:  val_11, tutorial:  freeHint));
    }
    private System.Collections.IEnumerator CoolMegaHint(System.Collections.Generic.List<LineWord> availableLines, bool tutorial = False)
    {
        .<>1__state = 0;
        .availableLines = availableLines;
        .<>4__this = this;
        .tutorial = tutorial;
        return (System.Collections.IEnumerator)new WGMegaHintController.<CoolMegaHint>d__7();
    }
    private System.Collections.IEnumerator CellAnimation(Cell chosenCell)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .chosenCell = chosenCell;
        return (System.Collections.IEnumerator)new WGMegaHintController.<CellAnimation>d__8();
    }
    public WGMegaHintController()
    {
        this.canHint = true;
        this.numMegaHints = 5;
        this.TimePerAnim = ;
    }

}
