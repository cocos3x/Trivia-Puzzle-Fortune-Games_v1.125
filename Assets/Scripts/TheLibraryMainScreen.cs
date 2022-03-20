using UnityEngine;
public class TheLibraryMainScreen : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button_back;
    private UnityEngine.UI.Button button_info;
    private UnityEngine.UI.Button button_new_books;
    private UnityEngine.UI.Button button_free_books;
    private UnityEngine.GameObject object_new_books_count;
    private UnityEngine.UI.Text text_new_books_count;
    private UnityEngine.UI.Text text_total_score;
    private UnityEngine.UI.ScrollRect scrollRect;
    private UnityEngine.Transform xfm_content_group;
    private LibraryCollectionDisplay prefab_collection_display;
    private System.Collections.Generic.List<LibraryCollectionDisplay> collectionDisplayInstances;
    
    // Methods
    private void Awake()
    {
        this.button_back.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryMainScreen::OnBackClicked()));
        this.button_info.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryMainScreen::OnInfoClicked()));
        this.button_new_books.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryMainScreen::OnNewBooksClicked()));
        this.button_free_books.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryMainScreen::OnFreeBooksClicked()));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnBookGranted");
    }
    private void OnEnable()
    {
        this.xfm_content_group.gameObject.SetActive(value:  false);
        this.Refresh();
        this.Invoke(methodName:  "ShowScroll", time:  0.1f);
    }
    public void Refresh()
    {
        TheLibraryMainScreen val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        TheLibraryMainScreen val_39;
        int val_41;
        System.Collections.Generic.List<LibraryCollectionDisplay> val_42;
        var val_43;
        val_30 = this;
        val_31 = 1152921515876351424;
        val_32 = 0;
        System.Collections.Generic.List<BookInfo> val_9 = TheLibraryLogic.PurchasableBooks;
        string val_10 = 1.ToString();
        this.object_new_books_count.SetActive(value:  (1 > 0) ? 1 : 0);
        val_33 = null;
        string val_13 = TheLibraryLogic.LibraryScore.ToString(format:  "#,##0");
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<BookInfo>> val_14 = TheLibraryLogic.PlayerBooksByCollection;
        System.Linq.Enumerable.ToList<System.String>(source:  val_14.Keys).Sort();
        if(1152921515899197520 < 1)
        {
            goto label_29;
        }
        
        var val_31 = 0;
        label_60:
        if(1 < val_14.Count)
        {
                this.collectionDisplayInstances.Add(item:  UnityEngine.Object.Instantiate<LibraryCollectionDisplay>(original:  this.prefab_collection_display, parent:  this.xfm_content_group));
        }
        
        if(this.collectionDisplayInstances <= val_31)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_35 = public System.Collections.Generic.List<T> System.Collections.Generic.List<System.String>::GetRange(int index, int count);
        if(this.collectionDisplayInstances <= val_31)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.KeyValuePair<System.String, System.Collections.Generic.List<BookInfo>> val_20 = new System.Collections.Generic.KeyValuePair<System.String, System.Collections.Generic.List<BookInfo>>(key:  public System.Collections.Generic.List<T> System.Collections.Generic.List<System.String>::GetRange(int index, int count), value:  val_14.Item[System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg]);
        val_36 = 0;
        val_37 = 0;
        goto label_39;
        label_50:
        if(44214440 <= val_31)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<BookInfo> val_22 = val_14.Item[TheLibraryLogic.PurchasableBookRefreshTimeHours];
        if(1152921504898863104 <= val_36)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        BookEconInfo val_23 = TheLibraryLogic.BookEcon.Item[TheLibraryLogic.PurchasableBookRefreshTimeHours + 40];
        int val_30 = val_23.LibraryValue;
        val_36 = 1;
        val_37 = val_30 + val_37;
        label_39:
        if(val_30 <= val_31)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_30 = val_30 + 0;
        System.Collections.Generic.List<BookInfo> val_24 = val_14.Item[(val_23.LibraryValue + 0) + 32];
        val_38 = null;
        if(val_36 < 1152921504898859008)
        {
            goto label_50;
        }
        
        val_39 = val_30;
        if(1152921504898859008 <= val_31)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_31 = null;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_41 = null;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_41 = TheLibraryLogic.PurchasableBookRefreshTimeHours;
        System.Collections.Generic.List<BookInfo> val_25 = val_14.Item[val_41];
        int val_32 = TheLibraryLogic.CountTimesCollectionCompleted(playerCollection:  new System.Collections.Generic.KeyValuePair<System.String, System.Collections.Generic.List<BookInfo>>() {Value = val_20.Value});
        Setup(name:  null, score:  val_37 + (TheLibraryLogic.CategoryCompleteLibraryBonus * val_32), numBooks:  -1592522672);
        val_30 = val_30;
        val_31 = val_31 + 1;
        if(val_31 < val_32)
        {
            goto label_60;
        }
        
        label_29:
        val_42 = this.collectionDisplayInstances;
        val_43 = 0;
        do
        {
            if(val_43 >= val_32)
        {
                return;
        }
        
            if(val_32 <= val_43)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_32 = val_32 + 0;
            (val_21 + 0) + 32.gameObject.SetActive(value:  (val_43 < val_14.Count) ? 1 : 0);
            val_42 = this.collectionDisplayInstances;
            val_43 = val_43 + 1;
        }
        while(val_42 != null);
        
        throw new NullReferenceException();
    }
    private void OnBookGranted()
    {
        this.Refresh();
    }
    private void ShowScroll()
    {
        this.xfm_content_group.gameObject.SetActive(value:  true);
    }
    private void OnBackClicked()
    {
        MonoSingleton<TheLibraryUI>.Instance.BackButtonPressed();
    }
    private void OnInfoClicked()
    {
        LibraryWindowManager val_2 = MonoSingleton<LibraryWindowManager>.Instance.ShowUGUIMonolith<TheLibraryInfoPopup>(showNext:  false);
    }
    private void OnNewBooksClicked()
    {
        LibraryWindowManager val_2 = MonoSingleton<LibraryWindowManager>.Instance.ShowUGUIMonolith<TheLibraryAcquireBooksPopup>(showNext:  false);
    }
    private void OnFreeBooksClicked()
    {
        LibraryWindowManager val_2 = MonoSingleton<LibraryWindowManager>.Instance.ShowUGUIMonolith<TheLibraryBooksEarnedScreen>(showNext:  false);
    }
    public TheLibraryMainScreen()
    {
        this.collectionDisplayInstances = new System.Collections.Generic.List<LibraryCollectionDisplay>();
    }

}
