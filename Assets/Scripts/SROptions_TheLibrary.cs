using UnityEngine;
public class SROptions_TheLibrary : SuperLuckySROptionsParent<SROptions_TheLibrary>, INotifyPropertyChanged
{
    // Fields
    private int collectionIndex;
    private int bookIndex;
    
    // Properties
    private System.Collections.Generic.List<string> BookListKeys { get; }
    private System.Collections.Generic.List<BookInfo> CurrentBooks { get; }
    public string CurrentCollection { get; }
    public string CurrentBook { get; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public void RefreshBooksStore()
    {
        System.DateTime val_1 = TheLibraryLogic.LastPurchasableRefreshDate;
        System.DateTime val_2 = val_1.dateData.AddHours(value:  (double)-TheLibraryLogic.PurchasableBookRefreshTimeHours);
        TheLibraryLogic.LastPurchasableRefreshDate = new System.DateTime() {dateData = val_2.dateData};
    }
    private System.Collections.Generic.List<string> get_BookListKeys()
    {
        return System.Linq.Enumerable.ToList<System.String>(source:  BookList.BooksByCollection.Keys);
    }
    private System.Collections.Generic.List<BookInfo> get_CurrentBooks()
    {
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<BookInfo>> val_1 = BookList.BooksByCollection;
        System.Collections.Generic.List<System.String> val_2 = val_1.BookListKeys;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        return val_1.Item[(BookList.__il2cppRuntimeField_cctor_finished + (this.collectionIndex) << 3) + 32];
    }
    public string get_CurrentCollection()
    {
        bool val_2 = true;
        System.Collections.Generic.List<System.String> val_1 = this.BookListKeys;
        if(val_2 <= this.collectionIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.collectionIndex) << 3);
        return (string)(true + (this.collectionIndex) << 3) + 32;
    }
    public void CycleCollectionForward()
    {
        int val_1 = this.collectionIndex + 1;
        this.collectionIndex = val_1;
        System.Collections.Generic.List<System.String> val_2 = this.BookListKeys;
        float val_3 = UnityEngine.Mathf.Repeat(t:  (float)val_1, length:  (float)W21);
        val_3 = (val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
        this.collectionIndex = (int)val_3;
        this.bookIndex = 0;
        SROptions_TheLibrary.NotifyPropertyChanged(propertyName:  "Collection");
    }
    public void CycleCollectionBackward()
    {
        int val_1 = this.collectionIndex - 1;
        this.collectionIndex = val_1;
        System.Collections.Generic.List<System.String> val_2 = this.BookListKeys;
        float val_3 = UnityEngine.Mathf.Repeat(t:  (float)val_1, length:  (float)W21);
        val_3 = (val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
        this.collectionIndex = (int)val_3;
        this.bookIndex = 0;
        SROptions_TheLibrary.NotifyPropertyChanged(propertyName:  "Collection");
    }
    public string get_CurrentBook()
    {
        bool val_2 = true;
        System.Collections.Generic.List<BookInfo> val_1 = this.CurrentBooks;
        if(val_2 <= this.bookIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.bookIndex) << 3);
        return (string)(true + (this.bookIndex) << 3) + 32 + 24;
    }
    public void CycleBookForward()
    {
        int val_1 = this.bookIndex + 1;
        this.bookIndex = val_1;
        System.Collections.Generic.List<BookInfo> val_2 = this.CurrentBooks;
        float val_3 = UnityEngine.Mathf.Repeat(t:  (float)val_1, length:  (float)W21);
        val_3 = (val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
        this.bookIndex = (int)val_3;
        SROptions_TheLibrary.NotifyPropertyChanged(propertyName:  "Book");
    }
    public void CycleBookBackward()
    {
        int val_1 = this.bookIndex - 1;
        this.bookIndex = val_1;
        System.Collections.Generic.List<BookInfo> val_2 = this.CurrentBooks;
        float val_3 = UnityEngine.Mathf.Repeat(t:  (float)val_1, length:  (float)W21);
        val_3 = (val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
        this.bookIndex = (int)val_3;
        SROptions_TheLibrary.NotifyPropertyChanged(propertyName:  "Book");
    }
    public void GrantBook()
    {
        bool val_2 = true;
        System.Collections.Generic.List<BookInfo> val_1 = this.CurrentBooks;
        if(val_2 <= this.bookIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.bookIndex) << 3);
        TheLibraryLogic.Hack_GrantBook(bookToGive:  (true + (this.bookIndex) << 3) + 32);
    }
    public void BackFillBooks()
    {
        TheLibraryLogic.Hack_BackFillBooksEarned();
    }
    public SROptions_TheLibrary()
    {
    
    }

}
