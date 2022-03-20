using UnityEngine;
public class TheLibraryCollectionScreen : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button_back;
    private UnityEngine.UI.Button button_info;
    private UnityEngine.UI.Text text_total_score;
    private UnityEngine.UI.Text text_title;
    private ExtraProgress extra_progress_bar;
    private UnityEngine.UI.Text text_progress;
    private UnityEngine.UI.Text text_progress_complete_amount;
    private UnityEngine.GameObject obj_complete_display;
    private UnityEngine.UI.ScrollRect scrollRect;
    private UnityEngine.Transform xfm_content_group;
    private LibraryBookDisplay_Collection prefab_book_display;
    private UnityEngine.Transform xfm_shelf_group;
    private UnityEngine.GameObject prefab_shelf;
    private System.Collections.Generic.List<LibraryBookDisplay_Collection> libraryBookInstances;
    private System.Collections.Generic.List<UnityEngine.GameObject> shelfInstances;
    
    // Methods
    private void Awake()
    {
        this.button_back.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryCollectionScreen::OnBackClicked()));
        this.button_info.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryCollectionScreen::OnInfoClicked()));
    }
    public void Setup(string collectionName)
    {
        var val_51;
        var val_52;
        var val_53;
        System.Func<BookInfo, System.String> val_55;
        var val_56;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_58;
        var val_59;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_61;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32> val_63;
        var val_64;
        System.Func<BookInfo, System.String> val_66;
        System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo> val_68;
        var val_69;
        System.Func<BookInfo, System.Int32> val_71;
        var val_72;
        System.Func<BookInfo, System.String> val_74;
        System.Collections.Generic.Dictionary<BookRarity, BookEconInfo> val_75;
        var val_76;
        var val_77;
        var val_78;
        var val_79;
        System.Collections.Generic.List<UnityEngine.GameObject> val_81;
        System.Collections.Generic.List<LibraryBookDisplay_Collection> val_82;
        var val_84;
        this.xfm_content_group.gameObject.SetActive(value:  false);
        GameBehavior val_3 = App.getBehavior;
        string val_5 = System.String.Format(format:  val_3.<metaGameBehavior>k__BackingField, arg0:  collectionName.ToUpper());
        val_51 = null;
        val_51 = null;
        string val_6 = ToString();
        val_52 = 1152921515875437808;
        System.Collections.Generic.List<BookInfo> val_8 = TheLibraryLogic.PlayerBooksByCollection.Item[collectionName];
        val_53 = null;
        val_53 = null;
        val_55 = TheLibraryCollectionScreen.<>c.<>9__16_0;
        if(val_55 == null)
        {
                System.Func<BookInfo, System.String> val_9 = null;
            val_55 = val_9;
            val_9 = new System.Func<BookInfo, System.String>(object:  TheLibraryCollectionScreen.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryCollectionScreen.<>c::<Setup>b__16_0(BookInfo bookInfo));
            TheLibraryCollectionScreen.<>c.<>9__16_0 = val_55;
        }
        
        val_56 = null;
        val_56 = null;
        val_58 = TheLibraryCollectionScreen.<>c.<>9__16_1;
        if(val_58 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_11 = null;
            val_58 = val_11;
            val_11 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(object:  TheLibraryCollectionScreen.<>c.__il2cppRuntimeField_static_fields, method:  System.Linq.IGrouping<System.String, BookInfo> TheLibraryCollectionScreen.<>c::<Setup>b__16_1(System.Linq.IGrouping<string, BookInfo> newGroup));
            TheLibraryCollectionScreen.<>c.<>9__16_1 = val_58;
        }
        
        val_59 = null;
        val_59 = null;
        val_61 = TheLibraryCollectionScreen.<>c.<>9__16_2;
        if(val_61 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_13 = null;
            val_61 = val_13;
            val_13 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String>(object:  TheLibraryCollectionScreen.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryCollectionScreen.<>c::<Setup>b__16_2(System.Linq.IGrouping<string, BookInfo> queryEntry));
            val_59 = null;
            TheLibraryCollectionScreen.<>c.<>9__16_2 = val_61;
        }
        
        val_59 = null;
        val_63 = TheLibraryCollectionScreen.<>c.<>9__16_3;
        if(val_63 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32> val_14 = null;
            val_63 = val_14;
            val_14 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32>(object:  TheLibraryCollectionScreen.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TheLibraryCollectionScreen.<>c::<Setup>b__16_3(System.Linq.IGrouping<string, BookInfo> queryEntry));
            TheLibraryCollectionScreen.<>c.<>9__16_3 = val_63;
        }
        
        System.Collections.Generic.Dictionary<TKey, TElement> val_15 = System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<System.String, BookInfo>, System.String, System.Int32>(source:  System.Linq.Enumerable.Select<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String>(source:  val_8, keySelector:  val_9), selector:  val_11), keySelector:  val_13, elementSelector:  val_14);
        val_64 = null;
        val_64 = null;
        val_66 = TheLibraryCollectionScreen.<>c.<>9__16_4;
        if(val_66 == null)
        {
                System.Func<BookInfo, System.String> val_16 = null;
            val_66 = val_16;
            val_16 = new System.Func<BookInfo, System.String>(object:  TheLibraryCollectionScreen.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryCollectionScreen.<>c::<Setup>b__16_4(BookInfo b));
            val_64 = null;
            TheLibraryCollectionScreen.<>c.<>9__16_4 = val_66;
        }
        
        val_64 = null;
        val_68 = TheLibraryCollectionScreen.<>c.<>9__16_5;
        if(val_68 == null)
        {
                System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo> val_17 = null;
            val_68 = val_17;
            val_17 = new System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo>(object:  TheLibraryCollectionScreen.<>c.__il2cppRuntimeField_static_fields, method:  BookInfo TheLibraryCollectionScreen.<>c::<Setup>b__16_5(string key, System.Collections.Generic.IEnumerable<BookInfo> group));
            TheLibraryCollectionScreen.<>c.<>9__16_5 = val_68;
        }
        
        val_69 = null;
        val_69 = null;
        val_71 = TheLibraryCollectionScreen.<>c.<>9__16_6;
        if(val_71 == null)
        {
                System.Func<BookInfo, System.Int32> val_19 = null;
            val_71 = val_19;
            val_19 = new System.Func<BookInfo, System.Int32>(object:  TheLibraryCollectionScreen.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TheLibraryCollectionScreen.<>c::<Setup>b__16_6(BookInfo b));
            TheLibraryCollectionScreen.<>c.<>9__16_6 = val_71;
        }
        
        val_72 = null;
        val_72 = null;
        val_74 = TheLibraryCollectionScreen.<>c.<>9__16_7;
        if(val_74 == null)
        {
                System.Func<BookInfo, System.String> val_21 = null;
            val_74 = val_21;
            val_21 = new System.Func<BookInfo, System.String>(object:  TheLibraryCollectionScreen.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryCollectionScreen.<>c::<Setup>b__16_7(BookInfo b));
            TheLibraryCollectionScreen.<>c.<>9__16_7 = val_74;
        }
        
        System.Collections.Generic.List<TSource> val_23 = System.Linq.Enumerable.ToList<BookInfo>(source:  System.Linq.Enumerable.ThenBy<BookInfo, System.String>(source:  System.Linq.Enumerable.OrderBy<BookInfo, System.Int32>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String, BookInfo>(source:  val_8, keySelector:  val_16, resultSelector:  val_17), keySelector:  val_19), keySelector:  val_21));
        .timesCompleted = 0;
        val_75 = BookList.BooksByCollection.Item[collectionName];
        if(val_15.Count < 1152921515875477744)
        {
                val_76 = 0;
        }
        
        .timesCompleted = System.Linq.Enumerable.Min(source:  val_15.Values);
        int val_31 = System.Linq.Enumerable.Count<System.Int32>(source:  val_15.Values, predicate:  new System.Func<System.Int32, System.Boolean>(object:  new TheLibraryCollectionScreen.<>c__DisplayClass16_0(), method:  System.Boolean TheLibraryCollectionScreen.<>c__DisplayClass16_0::<Setup>b__8(int c)));
        var val_34 = ((val_31 == 0) ? 1 : 0) & ((((TheLibraryCollectionScreen.<>c__DisplayClass16_0)[1152921515895868784].timesCompleted) > 0) ? 1 : 0);
        if(val_34 == 1)
        {
            
        }
        
        string val_37 = System.String.Format(format:  "{0}/{1}", arg0:  val_31.ToString(), arg1:  val_25 + 24.ToString());
        this.obj_complete_display.SetActive(value:  (((TheLibraryCollectionScreen.<>c__DisplayClass16_0)[1152921515895868784].timesCompleted) > 0) ? 1 : 0);
        this.extra_progress_bar.target = (float)val_25 + 24;
        this.extra_progress_bar.current = (float)(val_34 != 0) ? (val_25 + 24) : -1595928276;
        val_77 = null;
        val_77 = null;
        int val_52 = TheLibraryLogic.CategoryCompleteLibraryBonus;
        int val_40 = val_52 * ((TheLibraryCollectionScreen.<>c__DisplayClass16_0)[1152921515895868784].timesCompleted);
        if(val_52 >= 1)
        {
                var val_53 = 0;
            do
        {
            if(val_52 <= val_53)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_52 = val_52 + 0;
            val_78 = null;
            val_78 = null;
            val_52 = 0;
            val_75 = TheLibraryLogic.BookEcon;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            BookEconInfo val_42 = val_75.Item[TheLibraryLogic.PurchasableBookRefreshTimeHours + 40];
            val_53 = val_53 + 1;
            val_40 = val_40 + (val_42.LibraryValue * (val_15.Item[(TheLibraryLogic.CategoryCompleteLibraryBonus + 0) + 32 + 24]));
        }
        while(val_53 < val_42.LibraryValue);
        
        }
        
        string val_43 = val_40.ToString();
        if(val_40 < this.text_total_score)
        {
                val_52 = 1152921515895746224;
            do
        {
            this.libraryBookInstances.Add(item:  UnityEngine.Object.Instantiate<LibraryBookDisplay_Collection>(original:  this.prefab_book_display, parent:  this.xfm_content_group));
            val_79 = val_40 + 1;
        }
        while(val_79 < this.xfm_content_group);
        
        }
        
        float val_54 = (float)this.xfm_content_group;
        val_54 = val_54 / 3f;
        int val_45 = UnityEngine.Mathf.CeilToInt(f:  val_54);
        val_81 = this.shelfInstances;
        if(1152921504765632512 < val_45)
        {
                val_52 = 1152921513413301296;
            do
        {
            this.shelfInstances.Add(item:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.prefab_shelf, parent:  this.xfm_shelf_group));
        }
        while(44197129 < val_45);
        
            val_81 = this.shelfInstances;
        }
        
        var val_55 = 0;
        label_99:
        if(val_55 >= this.shelfInstances)
        {
            goto label_96;
        }
        
        if(this.shelfInstances <= val_55)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.SetActive(value:  (val_55 < val_45) ? 1 : 0);
        val_55 = val_55 + 1;
        if(this.shelfInstances != null)
        {
            goto label_99;
        }
        
        label_96:
        val_82 = this.libraryBookInstances;
        var val_56 = 4;
        label_113:
        var val_48 = val_56 - 4;
        if(val_48 >= this.shelfInstances)
        {
            goto label_102;
        }
        
        if(this.shelfInstances <= val_48)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        0.gameObject.SetActive(value:  (val_48 < this.shelfInstances) ? 1 : 0);
        if(val_48 < this.shelfInstances)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(this.shelfInstances <= val_48)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_84 = typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0 + 32;
            if(this.shelfInstances <= val_48)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_84 = mem[typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0 + 32 + 32];
            val_84 = typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0 + 32 + 32;
        }
        
            typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0 + 32.Setup(info:  typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0 + 32, bookCount:  val_15.Item[typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0 + 32 + 32 + 24]);
        }
        
        val_82 = this.libraryBookInstances;
        val_56 = val_56 + 1;
        if(val_82 != null)
        {
            goto label_113;
        }
        
        throw new NullReferenceException();
        label_102:
        this.Invoke(methodName:  "ShowScroll", time:  0.1f);
    }
    private void ShowScroll()
    {
        this.xfm_content_group.gameObject.SetActive(value:  true);
        MonoExtensions.ScrollToTop(scrollRect:  this.scrollRect);
    }
    private void OnBackClicked()
    {
        MonoSingleton<TheLibraryUI>.Instance.BackButtonPressed();
    }
    private void OnInfoClicked()
    {
        LibraryWindowManager val_2 = MonoSingleton<LibraryWindowManager>.Instance.ShowUGUIMonolith<TheLibraryInfoPopup>(showNext:  false);
    }
    public TheLibraryCollectionScreen()
    {
        this.libraryBookInstances = new System.Collections.Generic.List<LibraryBookDisplay_Collection>();
        this.shelfInstances = new System.Collections.Generic.List<UnityEngine.GameObject>();
    }

}
