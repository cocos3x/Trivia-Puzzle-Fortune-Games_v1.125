using UnityEngine;
public class TheLibraryBooksEarnedGridItem : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject obj_book_mystery;
    private LibraryBookDisplay book_display;
    private TheLibraryBookProgressDisplay progress_display;
    private UnityEngine.UI.Button button_view_chapter_progress;
    private int displayedBookIndex;
    private TheLibraryBooksEarnedScreen _BooksEarnedScreenParent;
    private System.Action<int, int> OnClickedGridItem;
    
    // Properties
    private TheLibraryBooksEarnedScreen BooksEarnedScreenParent { get; }
    
    // Methods
    private TheLibraryBooksEarnedScreen get_BooksEarnedScreenParent()
    {
        TheLibraryBooksEarnedScreen val_4;
        if(this._BooksEarnedScreenParent == 0)
        {
                this._BooksEarnedScreenParent = this.transform.GetComponentInParent<TheLibraryBooksEarnedScreen>();
            return val_4;
        }
        
        val_4 = this._BooksEarnedScreenParent;
        return val_4;
    }
    private void Awake()
    {
        this.button_view_chapter_progress.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryBooksEarnedGridItem::OnClickViewProgress()));
    }
    public void SetupGridItem(int bookIndex, System.Action<int, int> onClickedGridItem)
    {
        this.OnClickedGridItem = onClickedGridItem;
        this.SetupGridItem(bookIndex:  bookIndex);
    }
    public void SetupGridItem(int bookIndex)
    {
        BookInfo val_23;
        System.Action<System.Int32, System.Int32> val_24;
        this.gameObject.SetActive(value:  (bookIndex >> 31) ^ 1);
        if((bookIndex & 2147483648) != 0)
        {
                return;
        }
        
        this.displayedBookIndex = bookIndex;
        var val_22 = null;
        System.Collections.Generic.List<System.String> val_5 = TheLibraryLogic.SkusGrantedForCompletedBooks;
        int val_6 = bookIndex + 1;
        val_22 = val_22 - (ChapterBookLogic.GetCurrentBook(playerLevel:  0));
        val_24 = val_22 + val_6;
        if(<0)
        {
            goto label_12;
        }
        
        System.Collections.Generic.List<System.String> val_7 = TheLibraryLogic.SkusGrantedForCompletedBooks;
        var val_23 = null;
        System.Collections.Generic.List<System.String> val_9 = TheLibraryLogic.SkusGrantedForCompletedBooks;
        if(val_23 <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_23 = val_23 + (val_24 << 3);
        val_23 = BookList.BookInfos.Item[(null + (((null - val_4) + (bookIndex + 1))) << 3) + 32];
        System.Action<System.Int32, System.Int32> val_11 = null;
        val_24 = val_11;
        val_11 = new System.Action<System.Int32, System.Int32>(object:  this, method:  System.Void TheLibraryBooksEarnedGridItem::ExecuteProgressDisplayClick(int bookIndex, int chapter));
        this.progress_display.displayedBookIndex = bookIndex;
        this.progress_display.OnChapterItemClicked = val_24;
        this.progress_display.SetupElementsForCompletedBook(bookIndex:  bookIndex);
        goto label_21;
        label_12:
        if((ChapterBookLogic.GetCurrentBook(playerLevel:  0)) != val_6)
        {
            goto label_24;
        }
        
        string val_13 = TheLibraryLogic.GetCurrentBookUnlockTarget();
        val_23 = 0;
        if((System.String.IsNullOrEmpty(value:  val_13)) != true)
        {
                val_23 = BookList.BookInfos.Item[val_13];
        }
        
        System.Action<System.Int32, System.Int32> val_17 = null;
        val_24 = val_17;
        val_17 = new System.Action<System.Int32, System.Int32>(object:  this, method:  System.Void TheLibraryBooksEarnedGridItem::ExecuteProgressDisplayClick(int bookIndex, int chapter));
        this.progress_display.displayedBookIndex = bookIndex;
        this.progress_display.OnChapterItemClicked = val_24;
        this.progress_display.SetupElementsForCurrentBook();
        label_21:
        this.button_view_chapter_progress.interactable = true;
        goto label_33;
        label_24:
        this.progress_display.displayedBookIndex = bookIndex;
        this.progress_display.OnChapterItemClicked = new System.Action<System.Int32, System.Int32>(object:  this, method:  System.Void TheLibraryBooksEarnedGridItem::ExecuteProgressDisplayClick(int bookIndex, int chapter));
        this.progress_display.SetupElementsForFutureBook(bookIndex:  bookIndex);
        this.button_view_chapter_progress.interactable = false;
        val_23 = 0;
        label_33:
        this.obj_book_mystery.SetActive(value:  (val_23 == 0) ? 1 : 0);
        this.book_display.gameObject.SetActive(value:  (val_23 != 0) ? 1 : 0);
        if(val_23 == 0)
        {
                return;
        }
        
        this.book_display.Setup(info:  val_23);
    }
    public void ToggleChapterSelected(int chapter)
    {
        if(this.progress_display != null)
        {
                this.progress_display.ToggleChapterSelected(chapter:  chapter);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void ScrollCellIndex(int index)
    {
        TheLibraryBooksEarnedScreen val_1 = this.BooksEarnedScreenParent;
        index = val_1.startingBookIndex + index;
        this.SetupGridItem(bookIndex:  index);
    }
    private void OnClickViewProgress()
    {
        this.ExecuteProgressDisplayClick(bookIndex:  this.displayedBookIndex, chapter:  1);
    }
    private void ExecuteProgressDisplayClick(int bookIndex, int chapter)
    {
        if(this.OnClickedGridItem != null)
        {
                this.OnClickedGridItem.Invoke(arg1:  bookIndex, arg2:  chapter);
            return;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.BooksEarnedScreenParent)) == false)
        {
                return;
        }
        
        this.BooksEarnedScreenParent.OnGridItemBookClicked(bookIndex:  bookIndex, chapter:  chapter);
    }
    public TheLibraryBooksEarnedGridItem()
    {
        this.displayedBookIndex = 0;
    }

}
