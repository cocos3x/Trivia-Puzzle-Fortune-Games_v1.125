using UnityEngine;
public class TheLibraryBookProgressDisplay : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<TheLibraryBookProgressElement> chapterDisplay;
    private UnityEngine.UI.Image image_chapter_background;
    private UnityEngine.Color color_chapter_background_darkened;
    private int displayedBookIndex;
    private System.Action<int, int> OnChapterItemClicked;
    
    // Methods
    public void Setup(int bookIndex, TheLibrary.ProgressState state, System.Action<int, int> onChapterItemClicked)
    {
        this.displayedBookIndex = bookIndex;
        this.OnChapterItemClicked = onChapterItemClicked;
        if(state == 0)
        {
            goto label_0;
        }
        
        if(state == 2)
        {
            goto label_1;
        }
        
        if(state != 1)
        {
                return;
        }
        
        this.SetupElementsForCurrentBook();
        return;
        label_0:
        this.SetupElementsForCompletedBook(bookIndex:  bookIndex);
        return;
        label_1:
        this.SetupElementsForFutureBook(bookIndex:  bookIndex);
    }
    public void ToggleChapterSelected(int chapter)
    {
        var val_3;
        int val_1 = chapter - 1;
        val_3 = 0;
        do
        {
            if(val_3 >= val_1)
        {
                return;
        }
        
            if(val_1 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1 = val_1 + 0;
            ((chapter - 1) + 0) + 32.ToggleChapterSelected(isOn:  (val_1 == val_3) ? 1 : 0, dimOthers:  true);
            val_3 = val_3 + 1;
        }
        while(this.chapterDisplay != null);
        
        throw new NullReferenceException();
    }
    private void SetupElementsForCurrentBook()
    {
        var val_17;
        System.Collections.Generic.List<TheLibraryBookProgressElement> val_18;
        Player val_1 = App.Player;
        int val_20 = ChapterBookLogic.GetChaptersPerBook(playerLevel:  val_1);
        val_17 = ChapterBookLogic.GetCurrentChapter(playerLevel:  val_1);
        if(val_20 >= 1)
        {
                Player val_6 = val_1 - (ChapterBookLogic.GetFirstLevelOfChapter(playerLevel:  val_1));
            int val_7 = val_17 - 1;
            float val_17 = (float)ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_1);
            int val_18 = 0;
            do
        {
            val_17 = (val_7 == val_18) ? ((float)val_6 / val_17) : 0f;
            if(val_6 <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            Player.__il2cppRuntimeField_byval_arg.gameObject.SetActive(value:  true);
            var val_11 = (val_7 != val_18) ? (1 + 1) : 1;
            if(val_11 <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_11 = val_11 + 0;
            val_17 = mem[(val_7 != 0 ? (1 + 1) : 1 + 0) + 32];
            val_17 = (val_7 != 0 ? (1 + 1) : 1 + 0) + 32;
            var val_19 = 1152921504614248448;
            val_18 = val_18 + 1;
            val_17.Setup(chapter:  val_18, completeProgress:  (val_7 <= val_18) ? (val_17) : 1f, lastChapterInBook:  -1588810928, state:  (val_7 <= val_18) ? (val_11) : 0, interactable:  true, chapterClickAction:  new System.Action<System.Int32>(object:  this, method:  System.Void TheLibraryBookProgressDisplay::OnElementClicked(int elementChapter)));
        }
        while(val_18 < val_20);
        
        }
        
        val_18 = this.chapterDisplay;
        if(val_19 > val_20)
        {
                do
        {
            if(val_19 <= val_20)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_19 = val_19 + (val_20 << 3);
            (1152921504614248448 + (val_2) << 3) + 32.gameObject.SetActive(value:  false);
            val_18 = this.chapterDisplay;
            val_20 = val_20 + 1;
        }
        while(val_20 < val_19);
        
        }
        
        if(this.image_chapter_background == 0)
        {
                return;
        }
        
        UnityEngine.Color val_16 = UnityEngine.Color.white;
        this.image_chapter_background.color = new UnityEngine.Color() {r = val_16.r, g = val_16.g, b = val_16.b, a = val_16.a};
    }
    private void SetupElementsForFutureBook(int bookIndex)
    {
        int val_10 = ChapterBookLogic.GetChaptersFromBook(bookNum:  bookIndex + 1);
        var val_9 = 4;
        label_11:
        if((val_9 - 4) >= val_10)
        {
            goto label_4;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 32.gameObject.SetActive(value:  true);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 32.Setup(chapter:  val_9 - 3, completeProgress:  0f, lastChapterInBook:  -1588810928, state:  2, interactable:  false, chapterClickAction:  new System.Action<System.Int32>(object:  this, method:  System.Void TheLibraryBookProgressDisplay::OnElementClicked(int elementChapter)));
        val_9 = val_9 + 1;
        if(this.chapterDisplay != null)
        {
            goto label_11;
        }
        
        label_4:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        (ChapterBookLogic.__il2cppRuntimeField_cctor_finished + (val_2) << 3) + 32.gameObject.SetActive(value:  false);
        this.chapterDisplay = this.chapterDisplay;
        val_10 = val_10 + 1;
        if(this.image_chapter_background == 0)
        {
                return;
        }
        
        this.image_chapter_background.color = new UnityEngine.Color() {r = this.color_chapter_background_darkened};
    }
    private void SetupElementsForCompletedBook(int bookIndex)
    {
        int val_11 = ChapterBookLogic.GetChaptersFromBook(bookNum:  bookIndex + 1);
        var val_10 = 4;
        label_11:
        if((val_10 - 4) >= val_11)
        {
            goto label_4;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 32.gameObject.SetActive(value:  true);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 32.Setup(chapter:  val_10 - 3, completeProgress:  1f, lastChapterInBook:  -1588810928, state:  0, interactable:  true, chapterClickAction:  new System.Action<System.Int32>(object:  this, method:  System.Void TheLibraryBookProgressDisplay::OnElementClicked(int elementChapter)));
        val_10 = val_10 + 1;
        if(this.chapterDisplay != null)
        {
            goto label_11;
        }
        
        label_4:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        (ChapterBookLogic.__il2cppRuntimeField_cctor_finished + (val_2) << 3) + 32.gameObject.SetActive(value:  false);
        this.chapterDisplay = this.chapterDisplay;
        val_11 = val_11 + 1;
        if(this.image_chapter_background == 0)
        {
                return;
        }
        
        UnityEngine.Color val_9 = UnityEngine.Color.white;
        this.image_chapter_background.color = new UnityEngine.Color() {r = val_9.r, g = val_9.g, b = val_9.b, a = val_9.a};
    }
    private void OnElementClicked(int elementChapter)
    {
        if(this.OnChapterItemClicked == null)
        {
                return;
        }
        
        this.OnChapterItemClicked.Invoke(arg1:  this.displayedBookIndex, arg2:  elementChapter);
    }
    public TheLibraryBookProgressDisplay()
    {
        this.displayedBookIndex = 0;
    }

}
