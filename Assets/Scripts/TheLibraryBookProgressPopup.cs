using UnityEngine;
public class TheLibraryBookProgressPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button_close;
    private UnityEngine.UI.LoopScrollRect loopScrollRect;
    private TheLibraryBooksEarnedGridItem book_progress_display;
    private int currentBookIndex;
    private int currentChapterNumber;
    private int curr_total;
    private System.Action OnClosedCallback;
    
    // Methods
    private void Awake()
    {
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryBookProgressPopup::OnCloseClicked()));
    }
    private void Start()
    {
        this.DisplayBookProgress(bookIndex:  this.currentBookIndex, chapterNumber:  this.currentChapterNumber, onClosedCallback:  this.OnClosedCallback);
    }
    public void InitBookProgress(int bookIndex, int chapterNumber, System.Action onClosedCallback)
    {
        this.OnClosedCallback = onClosedCallback;
        this.currentBookIndex = bookIndex;
        this.currentChapterNumber = chapterNumber;
    }
    public void DisplayBookProgress(int bookIndex, int chapterNumber, System.Action onClosedCallback)
    {
        this.OnClosedCallback = onClosedCallback;
        this.currentBookIndex = bookIndex;
        this.currentChapterNumber = chapterNumber;
        int val_2 = ChapterBookLogic.GetLevelsPerChapter(book:  bookIndex + 1, chapter:  chapterNumber);
        this.curr_total = val_2;
        this.loopScrollRect.totalCount = val_2;
        this.loopScrollRect.RefillCells(offset:  0);
        this.book_progress_display.OnClickedGridItem = new System.Action<System.Int32, System.Int32>(object:  this, method:  System.Void TheLibraryBookProgressPopup::OnChapterClicked(int bookIndex, int chapter));
        this.book_progress_display.SetupGridItem(bookIndex:  bookIndex);
        this.book_progress_display.progress_display.ToggleChapterSelected(chapter:  chapterNumber);
    }
    public void SetupGridItem(WGChapterSelectLevelItem gridItem, int i)
    {
        int val_9;
        int val_10;
        string val_11;
        var val_12;
        var val_13;
        string val_14;
        System.Action<System.Int32> val_15;
        val_9 = i;
        if(this.curr_total > val_9)
        {
                val_9 = ChapterBookLogic.GetCumulativeLevelFromBookAndChapter(book:  this.currentBookIndex + 1, chapter:  this.currentChapterNumber, levelInChapterIndex:  val_9);
            val_10 = 0;
            val_11 = 0;
            if(val_9 <= (MonoSingletonSelfGenerating<WADChapterManager>.Instance.MaxPredefinedLevels))
        {
                val_10 = val_9;
            val_11 = MonoSingletonSelfGenerating<WADChapterManager>.Instance.GetGameLevelForPlayerLevelFromChapter(playerLevel:  val_10, checkLevelSkip:  true);
        }
        
            if(val_11 != null)
        {
                val_11 = val_6.word;
        }
        
            val_12 = val_9;
            val_13 = App.Player;
            val_14 = val_11;
            val_15 = new System.Action<System.Int32>(object:  this, method:  System.Void TheLibraryBookProgressPopup::OnPlayLevelClicked(int level));
        }
        else
        {
                val_12 = 0;
            val_13 = 0;
            val_14 = "";
            val_15 = 0;
        }
        
        gridItem.Setup(levelName:  0, currentLevel:  0, levelWord:  val_14, playLevelCallback:  val_15);
    }
    private void OnPlayLevelClicked(int level)
    {
        var val_10;
        TheLibraryUI.ForceTheLibraryClose();
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true)
        {
                if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_12;
        }
        
        }
        
        }
        
        MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        val_10 = null;
        val_10 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 60;
        GameBehavior val_6 = App.getBehavior;
        label_12:
        if((MonoSingleton<WGWindowManager>.Instance.ShowingWindow<LevelCompletePopup>()) != false)
        {
                return;
        }
        
        MonoSingleton<WGWindowManager>.Instance.CloseCurrentWindow();
    }
    private void OnChapterClicked(int bookIndex, int chapter)
    {
        this.DisplayBookProgress(bookIndex:  bookIndex, chapterNumber:  chapter, onClosedCallback:  this.OnClosedCallback);
    }
    private void OnCloseClicked()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(this.OnClosedCallback == null)
        {
                return;
        }
        
        this.OnClosedCallback.Invoke();
    }
    public TheLibraryBookProgressPopup()
    {
        this.currentBookIndex = -1;
        this.currentChapterNumber = -1;
    }

}
