using UnityEngine;
public class DailyChallengeZooTileAreaUI : MonoBehaviour
{
    // Fields
    private const int PREV = -1;
    private const int NEXT = 1;
    private UnityEngine.UI.Text month;
    private UnityEngine.UI.Text currentMonthStars;
    private WGDailyChallengeZooTile monthTile;
    private UnityEngine.UI.Text lifetimeStars;
    private WGDailyChallengeZooTile lifetimeTile;
    private UnityEngine.GameObject tilesGallery;
    private UnityEngine.Transform zooTilesParent;
    private UnityEngine.GameObject arrowsGroup;
    private UnityEngine.UI.Button leftArrowBtn;
    private UnityEngine.UI.Button rightArrowBtn;
    private WGDailyChallengeFunFact funFact;
    private int currentStartNavigationIndex;
    
    // Methods
    private void Awake()
    {
        this.tilesGallery.SetActive(value:  false);
        this.funFact.gameObject.SetActive(value:  false);
        this.leftArrowBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DailyChallengeZooTileAreaUI::<Awake>b__14_0()));
        this.rightArrowBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DailyChallengeZooTileAreaUI::<Awake>b__14_1()));
    }
    private void OnEnable()
    {
        System.DateTime val_2 = DateTimeCheat.Now;
        string val_5 = new System.Globalization.DateTimeFormatInfo().GetMonthName(month:  val_2.dateData.Month).ToLower();
        string val_7 = Localization.Localize(key:  val_5, defaultValue:  val_5, useSingularKey:  false).ToUpper();
        WGDailyChallengeManager val_8 = MonoSingleton<WGDailyChallengeManager>.Instance;
        decimal val_9 = System.Decimal.op_Implicit(value:  val_8.monthHistory.stars);
        decimal val_10 = new System.Decimal(value:  232);
        string val_11 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, maxSigFigs:  3, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_10.flags, hi = val_10.flags, lo = val_10.lo, mid = val_10.lo}, useRichText:  false, withSpaces:  false);
        Player val_12 = App.Player;
        decimal val_13 = System.Decimal.op_Implicit(value:  val_12.dcStars);
        decimal val_14 = new System.Decimal(value:  232);
        string val_15 = MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid}, maxSigFigs:  3, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_14.flags, hi = val_14.flags, lo = val_14.lo, mid = val_14.lo}, useRichText:  false, withSpaces:  false);
        UnityEngine.Coroutine val_17 = this.StartCoroutine(routine:  this.WaitSetup());
    }
    public void HideFunFactPopup()
    {
        if(this.funFact != null)
        {
                this.funFact.HideFunFact();
            return;
        }
        
        throw new NullReferenceException();
    }
    private System.Collections.IEnumerator WaitSetup()
    {
        .<>4__this = this;
        return (System.Collections.IEnumerator)new DailyChallengeZooTileAreaUI.<WaitSetup>d__17(<>1__state:  0);
    }
    private void SetupZooTiles()
    {
        var val_10;
        var val_11;
        WGDailyChallengeZooTile val_12;
        WGDailyChallengeManager val_2 = MonoSingleton<WGDailyChallengeManager>.Instance;
        .manager = val_2;
        if(val_2 == 0)
        {
                return;
        }
        
        (DailyChallengeZooTileAreaUI.<>c__DisplayClass18_0)[1152921516180539856].manager.monthHistory.tile = (DailyChallengeZooTileAreaUI.<>c__DisplayClass18_0)[1152921516180539856].manager.GetMonthTileName();
        val_10 = 0;
        if((System.String.IsNullOrEmpty(value:  (DailyChallengeZooTileAreaUI.<>c__DisplayClass18_0)[1152921516180539856].manager.monthHistory.tile)) != true)
        {
                val_11 = null;
            val_11 = null;
        }
        
        this.monthTile.tile = ZooTilePool.MonthlyZooTiles.Find(match:  new System.Predicate<ZooTile>(object:  new DailyChallengeZooTileAreaUI.<>c__DisplayClass18_0(), method:  System.Boolean DailyChallengeZooTileAreaUI.<>c__DisplayClass18_0::<SetupZooTiles>b__0(ZooTile x)));
        this.lifetimeTile.tile = (DailyChallengeZooTileAreaUI.<>c__DisplayClass18_0)[1152921516180539856].manager.GetNextLifetimeTile();
        val_12 = this.monthTile;
        if(this.monthTile.tile != null)
        {
                this.monthTile.tile.requiredStars = (DailyChallengeZooTileAreaUI.<>c__DisplayClass18_0)[1152921516180539856].manager.<Econ>k__BackingField.RequiredMonthlyStars;
            val_12 = this.monthTile;
        }
        
        val_12.Setup(lockCompValue:  (DailyChallengeZooTileAreaUI.<>c__DisplayClass18_0)[1152921516180539856].manager.monthHistory.stars, isMonthTileInCollection:  false);
        Player val_9 = App.Player;
        this.lifetimeTile.Setup(lockCompValue:  val_9.dcStars, isMonthTileInCollection:  false);
        this.UpdateZooTiles(cmd:  0);
    }
    private void UpdateZooTiles(int cmd = 0)
    {
        var val_17;
        System.Collections.Generic.List<ZooTile> val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.ZooTileCollection;
        if((public static WGDailyChallengeManager MonoSingleton<WGDailyChallengeManager>::get_Instance()) == 0)
        {
                return;
        }
        
        if()
        {
                int val_4 = UnityEngine.Mathf.Clamp(value:  this.currentStartNavigationIndex + cmd, min:  0, max:  44196828);
            UnityEngine.UI.Button val_17 = this.leftArrowBtn;
            this.currentStartNavigationIndex = val_4;
            val_17.interactable = (val_4 != 0) ? 1 : 0;
            val_17 = val_17 - 4;
            this.rightArrowBtn.interactable = (this.currentStartNavigationIndex != val_17) ? 1 : 0;
        }
        else
        {
                this.arrowsGroup.SetActive(value:  false);
        }
        
        var val_19 = 0;
        label_30:
        if(val_19 >= this.zooTilesParent.childCount)
        {
            goto label_14;
        }
        
        UnityEngine.Transform val_9 = this.zooTilesParent.GetChild(index:  0);
        if(val_19 < W23)
        {
                .tile = val_9.GetComponent<WGDailyChallengeZooTile>();
            int val_18 = this.currentStartNavigationIndex;
            int val_11 = val_19 + val_18;
            if(W9 <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_18 = val_18 + (val_11 << 3);
            val_10.tile = (this.currentStartNavigationIndex + ((0 + this.currentStartNavigationIndex)) << 3) + 32;
            val_17 = null;
            val_17 = null;
            Player val_14 = App.Player;
            (DailyChallengeZooTileAreaUI.<>c__DisplayClass19_0)[1152921516180842320].tile.Setup(lockCompValue:  val_14.dcStars, isMonthTileInCollection:  ((ZooTilePool.MonthlyZooTiles.Find(match:  new System.Predicate<ZooTile>(object:  new DailyChallengeZooTileAreaUI.<>c__DisplayClass19_0(), method:  System.Boolean DailyChallengeZooTileAreaUI.<>c__DisplayClass19_0::<UpdateZooTiles>b__0(ZooTile x)))) != 0) ? 1 : 0);
        }
        else
        {
                val_9.gameObject.SetActive(value:  false);
        }
        
        val_19 = val_19 + 1;
        if(this.zooTilesParent != null)
        {
            goto label_30;
        }
        
        label_14:
        this.tilesGallery.SetActive(value:  true);
    }
    public DailyChallengeZooTileAreaUI()
    {
    
    }
    private void <Awake>b__14_0()
    {
        this.UpdateZooTiles(cmd:  0);
    }
    private void <Awake>b__14_1()
    {
        this.UpdateZooTiles(cmd:  1);
    }

}
