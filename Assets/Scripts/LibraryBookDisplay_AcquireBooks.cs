using UnityEngine;
public class LibraryBookDisplay_AcquireBooks : LibraryBookDisplay
{
    // Fields
    private UnityEngine.GameObject object_new_tag;
    private UnityEngine.GameObject object_purchaseable_group;
    private UnityEngine.UI.Button button_purchase;
    private UnityEngine.UI.Text text_apples_cost;
    private UnityEngine.UI.Button button_purchased_display;
    private UnityEngine.UI.Text text_collection_progress;
    private BookInfo myBookInfo;
    private System.Action<BookInfo, LibraryBookDisplay_AcquireBooks> bookClickedAction;
    private System.Action<BookInfo, LibraryBookDisplay_AcquireBooks> bookAlreadyPurchasedClickedAction;
    
    // Methods
    private void Awake()
    {
        this.button_purchase.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LibraryBookDisplay_AcquireBooks::OnPurchaseClicked()));
        this.button_purchased_display.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LibraryBookDisplay_AcquireBooks::OnAlreadyPurchasedClicked()));
    }
    public void Setup(BookInfo info, bool isNew, bool isPurchased, System.Action<BookInfo, LibraryBookDisplay_AcquireBooks> onBookClicked, System.Action<BookInfo, LibraryBookDisplay_AcquireBooks> onBookAlreadyPurchasedClicked)
    {
        System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo> val_40;
        UnityEngine.UI.Text val_41;
        var val_42;
        var val_43;
        var val_44;
        object val_45;
        var val_46;
        System.Collections.Generic.IEnumerable<TSource> val_47;
        var val_48;
        System.Func<BookInfo, System.String> val_50;
        var val_51;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_53;
        var val_54;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_56;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32> val_58;
        var val_59;
        var val_60;
        System.Func<BookInfo, System.String> val_62;
        var val_64;
        var val_65;
        System.Func<BookInfo, System.Int32> val_67;
        var val_68;
        System.Func<BookInfo, System.String> val_70;
        var val_71;
        System.Collections.Generic.IEnumerable<TSource> val_72;
        this.Setup(info:  info);
        this.myBookInfo = info;
        this.object_new_tag.SetActive(value:  isNew);
        this.object_purchaseable_group.SetActive(value:  (~isPurchased) & 1);
        this.button_purchased_display.gameObject.SetActive(value:  isPurchased);
        val_41 = this.text_apples_cost;
        val_42 = null;
        val_42 = null;
        BookEconInfo val_5 = TheLibraryLogic.BookEcon.Item[this.myBookInfo.Rarity];
        string val_6 = val_5.GoldenAppleCost.ToString();
        this.bookClickedAction = onBookClicked;
        this.bookAlreadyPurchasedClickedAction = onBookAlreadyPurchasedClicked;
        val_43 = 1152921504898273280;
        val_44 = 1152921515875437808;
        System.Collections.Generic.List<BookInfo> val_8 = BookList.BooksByCollection.Item[info.Collection];
        if((TheLibraryLogic.PlayerBooksByCollection.ContainsKey(key:  info.Collection)) != false)
        {
                LibraryBookDisplay_AcquireBooks.<>c__DisplayClass10_0 val_11 = null;
            val_45 = val_11;
            val_11 = new LibraryBookDisplay_AcquireBooks.<>c__DisplayClass10_0();
            val_46 = 1152921504899338240;
            val_47 = TheLibraryLogic.PlayerBooksByCollection.Item[info.Collection];
            val_48 = null;
            val_48 = null;
            val_50 = LibraryBookDisplay_AcquireBooks.<>c.<>9__10_0;
            if(val_50 == null)
        {
                System.Func<BookInfo, System.String> val_14 = null;
            val_50 = val_14;
            val_14 = new System.Func<BookInfo, System.String>(object:  LibraryBookDisplay_AcquireBooks.<>c.__il2cppRuntimeField_static_fields, method:  System.String LibraryBookDisplay_AcquireBooks.<>c::<Setup>b__10_0(BookInfo bookInfo));
            LibraryBookDisplay_AcquireBooks.<>c.<>9__10_0 = val_50;
        }
        
            val_51 = null;
            val_51 = null;
            val_53 = LibraryBookDisplay_AcquireBooks.<>c.<>9__10_1;
            if(val_53 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_16 = null;
            val_53 = val_16;
            val_16 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(object:  LibraryBookDisplay_AcquireBooks.<>c.__il2cppRuntimeField_static_fields, method:  System.Linq.IGrouping<System.String, BookInfo> LibraryBookDisplay_AcquireBooks.<>c::<Setup>b__10_1(System.Linq.IGrouping<string, BookInfo> newGroup));
            LibraryBookDisplay_AcquireBooks.<>c.<>9__10_1 = val_53;
        }
        
            val_54 = null;
            val_54 = null;
            val_56 = LibraryBookDisplay_AcquireBooks.<>c.<>9__10_2;
            if(val_56 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_18 = null;
            val_56 = val_18;
            val_18 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String>(object:  LibraryBookDisplay_AcquireBooks.<>c.__il2cppRuntimeField_static_fields, method:  System.String LibraryBookDisplay_AcquireBooks.<>c::<Setup>b__10_2(System.Linq.IGrouping<string, BookInfo> queryEntry));
            val_54 = null;
            LibraryBookDisplay_AcquireBooks.<>c.<>9__10_2 = val_56;
        }
        
            val_54 = null;
            val_58 = LibraryBookDisplay_AcquireBooks.<>c.<>9__10_3;
            if(val_58 == null)
        {
                val_59 = val_43;
            System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32> val_19 = null;
            val_58 = val_19;
            val_19 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32>(object:  LibraryBookDisplay_AcquireBooks.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LibraryBookDisplay_AcquireBooks.<>c::<Setup>b__10_3(System.Linq.IGrouping<string, BookInfo> queryEntry));
            val_43 = ;
            LibraryBookDisplay_AcquireBooks.<>c.<>9__10_3 = val_58;
            val_44 = 1152921515875437808;
        }
        
            System.Collections.Generic.Dictionary<TKey, TElement> val_20 = System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<System.String, BookInfo>, System.String, System.Int32>(source:  System.Linq.Enumerable.Select<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String>(source:  val_47, keySelector:  val_14), selector:  val_16), keySelector:  val_18, elementSelector:  val_19);
            val_60 = null;
            val_60 = null;
            val_62 = LibraryBookDisplay_AcquireBooks.<>c.<>9__10_4;
            if(val_62 == null)
        {
                System.Func<BookInfo, System.String> val_21 = null;
            val_62 = val_21;
            val_21 = new System.Func<BookInfo, System.String>(object:  LibraryBookDisplay_AcquireBooks.<>c.__il2cppRuntimeField_static_fields, method:  System.String LibraryBookDisplay_AcquireBooks.<>c::<Setup>b__10_4(BookInfo b));
            val_60 = null;
            LibraryBookDisplay_AcquireBooks.<>c.<>9__10_4 = val_62;
        }
        
            val_60 = null;
            val_40 = LibraryBookDisplay_AcquireBooks.<>c.<>9__10_5;
            if(val_40 == null)
        {
                val_64 = val_43;
            System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo> val_22 = null;
            val_40 = val_22;
            val_22 = new System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo>(object:  LibraryBookDisplay_AcquireBooks.<>c.__il2cppRuntimeField_static_fields, method:  BookInfo LibraryBookDisplay_AcquireBooks.<>c::<Setup>b__10_5(string key, System.Collections.Generic.IEnumerable<BookInfo> group));
            val_43 = ;
            val_44 = val_44;
            val_47 = val_47;
            val_45 = val_45;
            val_46 = 1152921504899338240;
            LibraryBookDisplay_AcquireBooks.<>c.<>9__10_5 = val_40;
        }
        
            val_65 = null;
            val_67 = LibraryBookDisplay_AcquireBooks.<>c.<>9__10_6;
            if(val_67 == null)
        {
                System.Func<BookInfo, System.Int32> val_24 = null;
            val_67 = val_24;
            val_24 = new System.Func<BookInfo, System.Int32>(object:  LibraryBookDisplay_AcquireBooks.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LibraryBookDisplay_AcquireBooks.<>c::<Setup>b__10_6(BookInfo b));
            LibraryBookDisplay_AcquireBooks.<>c.<>9__10_6 = val_67;
        }
        
            val_68 = null;
            val_68 = null;
            val_70 = LibraryBookDisplay_AcquireBooks.<>c.<>9__10_7;
            if(val_70 == null)
        {
                System.Func<BookInfo, System.String> val_26 = null;
            val_70 = val_26;
            val_26 = new System.Func<BookInfo, System.String>(object:  LibraryBookDisplay_AcquireBooks.<>c.__il2cppRuntimeField_static_fields, method:  System.String LibraryBookDisplay_AcquireBooks.<>c::<Setup>b__10_7(BookInfo b));
            LibraryBookDisplay_AcquireBooks.<>c.<>9__10_7 = val_70;
        }
        
            System.Collections.Generic.List<TSource> val_28 = System.Linq.Enumerable.ToList<BookInfo>(source:  System.Linq.Enumerable.ThenBy<BookInfo, System.String>(source:  System.Linq.Enumerable.OrderBy<BookInfo, System.Int32>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String, BookInfo>(source:  val_47, keySelector:  val_21, resultSelector:  val_22), keySelector:  val_24), keySelector:  val_26));
            System.Collections.Generic.List<BookInfo> val_30 = BookList.BooksByCollection.Item[info.Collection];
            .timesCompleted = 0;
            if(val_20.Count < 1152921515875477744)
        {
                val_71 = 0;
        }
        
            .timesCompleted = System.Linq.Enumerable.Min(source:  val_20.Values);
            val_41 = val_20.Values;
            val_72 = val_41;
        }
        
        string val_39 = System.String.Format(format:  "{0} {1}/{2}", arg0:  info.Collection, arg1:  System.Linq.Enumerable.Count<System.Int32>(source:  val_72, predicate:  new System.Func<System.Int32, System.Boolean>(object:  val_11, method:  System.Boolean LibraryBookDisplay_AcquireBooks.<>c__DisplayClass10_0::<Setup>b__8(int c))).ToString(), arg2:  BookList.__il2cppRuntimeField_cctor_finished.ToString());
    }
    private void OnPurchaseClicked()
    {
        if(this.bookClickedAction == null)
        {
                return;
        }
        
        this.bookClickedAction.Invoke(arg1:  this.myBookInfo, arg2:  this);
    }
    private void OnAlreadyPurchasedClicked()
    {
        if(this.bookAlreadyPurchasedClickedAction == null)
        {
                return;
        }
        
        this.bookAlreadyPurchasedClickedAction.Invoke(arg1:  this.myBookInfo, arg2:  this);
    }
    public LibraryBookDisplay_AcquireBooks()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
