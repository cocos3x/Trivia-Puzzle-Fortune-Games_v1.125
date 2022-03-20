using UnityEngine;
public class LibraryBookDisplay_Collection : LibraryBookDisplay
{
    // Fields
    private UnityEngine.GameObject obj_book_count;
    private UnityEngine.UI.Text text_book_count;
    private UnityEngine.UI.Text text_book_score_amount;
    
    // Methods
    public void Setup(BookInfo info, int bookCount)
    {
        var val_5;
        this.Setup(info:  info);
        this.obj_book_count.SetActive(value:  (bookCount > 1) ? 1 : 0);
        string val_2 = bookCount.ToString();
        val_5 = null;
        val_5 = null;
        BookEconInfo val_3 = TheLibraryLogic.BookEcon.Item[info.Rarity];
        int val_5 = val_3.LibraryValue;
        val_5 = bookCount * val_5;
        string val_4 = val_5.ToString();
    }
    public LibraryBookDisplay_Collection()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
