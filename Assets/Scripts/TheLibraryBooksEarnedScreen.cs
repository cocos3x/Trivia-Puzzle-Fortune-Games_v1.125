using UnityEngine;
public class TheLibraryBooksEarnedScreen : MonoBehaviour
{
    // Fields
    public int startingBookIndex;
    private UnityEngine.UI.Button button_close;
    private UnityEngine.UI.Button button_library;
    private UnityEngine.UI.LoopVerticalScrollRect loopScrollRect;
    private int booksBeyondEarned;
    private int curr_total;
    private System.Action OnCloseCallback;
    
    // Methods
    private void Awake()
    {
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryBooksEarnedScreen::OnBackClicked()));
        this.button_library.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryBooksEarnedScreen::OnLibraryClicked()));
    }
    private void OnEnable()
    {
        TheLibraryUI.HideMainUICanvas();
        int val_1 = ChapterBookLogic.GetCurrentBook(playerLevel:  0);
        System.Collections.Generic.List<System.String> val_2 = TheLibraryLogic.SkusGrantedForCompletedBooks;
        int val_3 = W24 + 1;
        int val_12 = ~W24;
        val_12 = val_1 + val_12;
        this.startingBookIndex = val_12;
        val_3 = val_3 + this.booksBeyondEarned;
        this.curr_total = val_3;
        SLCDebug.Log(logMessage:  "GRANTED SKUS: "("GRANTED SKUS: ") + PrettyPrint.printJSON(obj:  TheLibraryLogic.SkusGrantedForCompletedBooks, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  TheLibraryLogic.SkusGrantedForCompletedBooks, types:  false, singleLineOutput:  false)), colorHash:  "#FFFFFF", isError:  false);
        object[] val_8 = new object[5];
        val_8[0] = val_1;
        val_8[1] = ???;
        val_8[2] = (val_3 == val_1) ? 1 : 0;
        val_8[3] = this.startingBookIndex;
        val_8[4] = this.curr_total;
        SLCDebug.Log(logMessage:  System.String.Format(format:  "TheLibraryBooksEarnedScreen.OnEnable() currentBook = {0}, grantedBooksHistoryCount = {1}, haveCompleteHistory = {2}, startingBookIndex = {3}, curr_total = {4}", args:  val_8), colorHash:  "#FFFFFF", isError:  false);
        mem2[0] = this.curr_total;
        UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  this.WaitAndCenterGrid());
    }
    private void OnDisable()
    {
        TheLibraryUI.ShowMainUICanvas();
    }
    public void DisplayBooksEarned(System.Action onCloseCallback)
    {
        if(onCloseCallback == null)
        {
                return;
        }
        
        this.OnCloseCallback = onCloseCallback;
    }
    public void OnGridItemBookClicked(int bookIndex, int chapter)
    {
        if((bookIndex + 1) > (ChapterBookLogic.GetCurrentBook(playerLevel:  0)))
        {
                return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        GameBehavior val_4 = App.getBehavior;
        mem2[0] = new System.Action(object:  this, method:  System.Void TheLibraryBooksEarnedScreen::<OnGridItemBookClicked>b__11_0());
        mem2[0] = bookIndex;
        mem2[0] = chapter;
    }
    private System.Collections.IEnumerator WaitAndCenterGrid()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TheLibraryBooksEarnedScreen.<WaitAndCenterGrid>d__12();
    }
    private void CenterGrid()
    {
        if(this.loopScrollRect != null)
        {
                this.loopScrollRect.RefillCells(offset:  this.curr_total + (~this.booksBeyondEarned));
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnBackClicked()
    {
        if(this.OnCloseCallback != null)
        {
                this.OnCloseCallback.Invoke();
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnLibraryClicked()
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 59;
        if((MonoSingleton<TheLibraryUI>.Instance) == 0)
        {
                TheLibraryUI.ShowTheLibrary(onCloseAction:  new System.Action(object:  this, method:  System.Void TheLibraryBooksEarnedScreen::<OnLibraryClicked>b__15_0()));
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TheLibraryBooksEarnedScreen()
    {
        this.booksBeyondEarned = 6;
    }
    private void <OnGridItemBookClicked>b__11_0()
    {
        GameBehavior val_1 = App.getBehavior;
        if(this.OnCloseCallback == null)
        {
                return;
        }
        
        mem2[0] = this.OnCloseCallback;
    }
    private void <OnLibraryClicked>b__15_0()
    {
        GameBehavior val_1 = App.getBehavior;
        if(this.OnCloseCallback == null)
        {
                return;
        }
        
        mem2[0] = this.OnCloseCallback;
    }

}
