using UnityEngine;
public class LibraryBookDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text text_book_title;
    private UnityEngine.UI.Text text_book_author;
    private UnityEngine.UI.Text text_book_collection;
    private UnityEngine.GameObject[] obj_stars_rarity;
    private UnityEngine.UI.Image image_book;
    private UnityEngine.Sprite[] sprites_book_rarity;
    private Gradient[] bookGradients;
    private BookInfo bookInfo;
    
    // Properties
    public BookInfo GetBookInfo { get; }
    public UnityEngine.GameObject[] GetStarObjects { get; }
    
    // Methods
    public BookInfo get_GetBookInfo()
    {
        return (BookInfo)this.bookInfo;
    }
    public UnityEngine.GameObject[] get_GetStarObjects()
    {
        return (UnityEngine.GameObject[])this.obj_stars_rarity;
    }
    public void Setup(BookInfo info)
    {
        var val_5;
        this.bookInfo = info;
        bool val_1 = UnityEngine.Object.op_Inequality(x:  this.text_book_collection, y:  0);
        if((this.image_book != 0) && (this.sprites_book_rarity.Length != 0))
        {
                this.image_book.sprite = this.sprites_book_rarity[info.Rarity];
        }
        
        var val_7 = 0;
        label_19:
        if(val_7 >= this.obj_stars_rarity.Length)
        {
            goto label_16;
        }
        
        this.obj_stars_rarity[val_7].SetActive(value:  (val_7 <= info.Rarity) ? 1 : 0);
        val_7 = val_7 + 1;
        if(this.obj_stars_rarity != null)
        {
            goto label_19;
        }
        
        label_16:
        val_5 = 0;
        do
        {
            if(val_5 >= this.bookGradients.Length)
        {
                return;
        }
        
            this.bookGradients[val_5].enabled = (val_5 == info.Rarity) ? 1 : 0;
            val_5 = val_5 + 1;
        }
        while(this.bookGradients != null);
        
        throw new NullReferenceException();
    }
    public LibraryBookDisplay()
    {
    
    }

}
