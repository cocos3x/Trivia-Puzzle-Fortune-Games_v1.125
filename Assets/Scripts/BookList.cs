using UnityEngine;
public class BookList
{
    // Fields
    public static System.Collections.Generic.List<System.Collections.Generic.List<string>> BookOptionsSkus;
    private static bool hasLoaded;
    private static System.Collections.Generic.Dictionary<string, BookInfo> bookInfos;
    private static System.Collections.Generic.Dictionary<BookRarity, System.Collections.Generic.List<BookInfo>> booksByRarity;
    private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<BookInfo>> booksByCollection;
    private static BookInfo tempBook;
    
    // Properties
    public static System.Collections.Generic.Dictionary<string, BookInfo> BookInfos { get; }
    public static System.Collections.Generic.List<BookInfo> BookInfosList { get; }
    public static System.Collections.Generic.Dictionary<BookRarity, System.Collections.Generic.List<BookInfo>> BooksByRarity { get; }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<BookInfo>> BooksByCollection { get; }
    
    // Methods
    public static System.Collections.Generic.Dictionary<string, BookInfo> get_BookInfos()
    {
        var val_1 = null;
        if(BookList.hasLoaded == false)
        {
            goto label_3;
        }
        
        val_1 = null;
        if(BookList.bookInfos != null)
        {
            goto label_6;
        }
        
        label_3:
        BookList.Load();
        val_1 = null;
        label_6:
        val_1 = null;
        return (System.Collections.Generic.Dictionary<System.String, BookInfo>)BookList.bookInfos;
    }
    public static System.Collections.Generic.List<BookInfo> get_BookInfosList()
    {
        return System.Linq.Enumerable.ToList<BookInfo>(source:  BookList.BookInfos.Values);
    }
    public static System.Collections.Generic.Dictionary<BookRarity, System.Collections.Generic.List<BookInfo>> get_BooksByRarity()
    {
        System.Collections.Generic.Dictionary<TKey, TElement> val_9;
        var val_10;
        var val_11;
        System.Func<BookInfo, BookRarity> val_13;
        var val_14;
        System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, System.Linq.IGrouping<BookRarity, BookInfo>> val_16;
        var val_17;
        System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, BookRarity> val_19;
        System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, System.Collections.Generic.List<BookInfo>> val_21;
        val_10 = null;
        val_10 = null;
        if(BookList.booksByRarity == null)
        {
                val_11 = null;
            val_11 = null;
            val_13 = BookList.<>c.<>9__9_0;
            if(val_13 == null)
        {
                System.Func<BookInfo, BookRarity> val_2 = null;
            val_13 = val_2;
            val_2 = new System.Func<BookInfo, BookRarity>(object:  BookList.<>c.__il2cppRuntimeField_static_fields, method:  BookRarity BookList.<>c::<get_BooksByRarity>b__9_0(BookInfo bookInfo));
            BookList.<>c.<>9__9_0 = val_13;
        }
        
            val_14 = null;
            val_14 = null;
            val_16 = BookList.<>c.<>9__9_1;
            if(val_16 == null)
        {
                System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, System.Linq.IGrouping<BookRarity, BookInfo>> val_4 = null;
            val_16 = val_4;
            val_4 = new System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, System.Linq.IGrouping<BookRarity, BookInfo>>(object:  BookList.<>c.__il2cppRuntimeField_static_fields, method:  System.Linq.IGrouping<BookRarity, BookInfo> BookList.<>c::<get_BooksByRarity>b__9_1(System.Linq.IGrouping<BookRarity, BookInfo> newGroup));
            BookList.<>c.<>9__9_1 = val_16;
        }
        
            val_17 = null;
            val_17 = null;
            val_19 = BookList.<>c.<>9__9_2;
            if(val_19 == null)
        {
                System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, BookRarity> val_6 = null;
            val_19 = val_6;
            val_6 = new System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, BookRarity>(object:  BookList.<>c.__il2cppRuntimeField_static_fields, method:  BookRarity BookList.<>c::<get_BooksByRarity>b__9_2(System.Linq.IGrouping<BookRarity, BookInfo> queryEntry));
            val_17 = null;
            BookList.<>c.<>9__9_2 = val_19;
        }
        
            val_17 = null;
            val_21 = BookList.<>c.<>9__9_3;
            if(val_21 == null)
        {
                System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, System.Collections.Generic.List<BookInfo>> val_7 = null;
            val_21 = val_7;
            val_7 = new System.Func<System.Linq.IGrouping<BookRarity, BookInfo>, System.Collections.Generic.List<BookInfo>>(object:  BookList.<>c.__il2cppRuntimeField_static_fields, method:  System.Collections.Generic.List<BookInfo> BookList.<>c::<get_BooksByRarity>b__9_3(System.Linq.IGrouping<BookRarity, BookInfo> queryEntry));
            BookList.<>c.<>9__9_3 = val_21;
        }
        
            val_10 = null;
            val_9 = System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<BookRarity, BookInfo>, BookRarity, System.Collections.Generic.List<BookInfo>>(source:  System.Linq.Enumerable.Select<System.Linq.IGrouping<BookRarity, BookInfo>, System.Linq.IGrouping<BookRarity, BookInfo>>(source:  System.Linq.Enumerable.GroupBy<BookInfo, BookRarity>(source:  BookList.BookInfosList, keySelector:  val_2), selector:  val_4), keySelector:  val_6, elementSelector:  val_7);
            val_10 = null;
            BookList.booksByRarity = val_9;
        }
        
        val_10 = null;
        return (System.Collections.Generic.Dictionary<BookRarity, System.Collections.Generic.List<BookInfo>>)BookList.booksByRarity;
    }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<BookInfo>> get_BooksByCollection()
    {
        var val_3 = null;
        if(BookList.booksByCollection == null)
        {
                val_3 = null;
            BookList.booksByCollection = BookList.GroupBookInfosByCollection(booksToGroup:  BookList.BookInfosList);
        }
        
        val_3 = null;
        return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<BookInfo>>)BookList.booksByCollection;
    }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<BookInfo>> GroupBookInfosByCollection(System.Collections.Generic.List<BookInfo> booksToGroup)
    {
        var val_7;
        System.Func<BookInfo, System.String> val_9;
        var val_10;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_12;
        var val_13;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_15;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Collections.Generic.List<BookInfo>> val_17;
        val_7 = null;
        val_7 = null;
        val_9 = BookList.<>c.<>9__13_0;
        if(val_9 == null)
        {
                System.Func<BookInfo, System.String> val_1 = null;
            val_9 = val_1;
            val_1 = new System.Func<BookInfo, System.String>(object:  BookList.<>c.__il2cppRuntimeField_static_fields, method:  System.String BookList.<>c::<GroupBookInfosByCollection>b__13_0(BookInfo bookInfo));
            BookList.<>c.<>9__13_0 = val_9;
        }
        
        val_10 = null;
        val_10 = null;
        val_12 = BookList.<>c.<>9__13_1;
        if(val_12 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_3 = null;
            val_12 = val_3;
            val_3 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(object:  BookList.<>c.__il2cppRuntimeField_static_fields, method:  System.Linq.IGrouping<System.String, BookInfo> BookList.<>c::<GroupBookInfosByCollection>b__13_1(System.Linq.IGrouping<string, BookInfo> newGroup));
            BookList.<>c.<>9__13_1 = val_12;
        }
        
        val_13 = null;
        val_13 = null;
        val_15 = BookList.<>c.<>9__13_2;
        if(val_15 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_5 = null;
            val_15 = val_5;
            val_5 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String>(object:  BookList.<>c.__il2cppRuntimeField_static_fields, method:  System.String BookList.<>c::<GroupBookInfosByCollection>b__13_2(System.Linq.IGrouping<string, BookInfo> queryEntry));
            val_13 = null;
            BookList.<>c.<>9__13_2 = val_15;
        }
        
        val_13 = null;
        val_17 = BookList.<>c.<>9__13_3;
        if(val_17 != null)
        {
                return System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<System.String, BookInfo>, System.String, System.Collections.Generic.List<BookInfo>>(source:  System.Linq.Enumerable.Select<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String>(source:  booksToGroup, keySelector:  val_1), selector:  val_3), keySelector:  val_5, elementSelector:  System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Collections.Generic.List<BookInfo>> val_6 = null);
        }
        
        val_17 = val_6;
        val_6 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Collections.Generic.List<BookInfo>>(object:  BookList.<>c.__il2cppRuntimeField_static_fields, method:  System.Collections.Generic.List<BookInfo> BookList.<>c::<GroupBookInfosByCollection>b__13_3(System.Linq.IGrouping<string, BookInfo> queryEntry));
        BookList.<>c.<>9__13_3 = val_17;
        return System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<System.String, BookInfo>, System.String, System.Collections.Generic.List<BookInfo>>(source:  System.Linq.Enumerable.Select<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String>(source:  booksToGroup, keySelector:  val_1), selector:  val_3), keySelector:  val_5, elementSelector:  val_6);
    }
    private static void Load()
    {
        var val_12;
        var val_13;
        System.Collections.Generic.Dictionary<System.String, BookInfo> val_1 = new System.Collections.Generic.Dictionary<System.String, BookInfo>();
        val_12 = null;
        val_12 = null;
        BookList.bookInfos = val_1;
        char[] val_5 = new char[1];
        val_5[0] = '
        ';
        if(val_6.Length < 2)
        {
                return;
        }
        
        var val_19 = 1;
        do
        {
            char[] val_7 = new char[1];
            val_7[0] = '	';
            System.String[] val_8 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "LibraryBooks/Library Economy - Book List").text.Replace(oldValue:  "\r", newValue:  "").Split(separator:  val_5)[val_19].Split(separator:  val_7);
            object val_10 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_8[3]);
            BookInfo val_11 = new BookInfo();
            .SKU = val_8[0];
            .Title = val_8[1];
            .Author = val_8[2];
            .Rarity = null;
            .Collection = val_8[4];
            val_13 = null;
            val_13 = null;
            BookList.tempBook = val_11;
            val_1.Add(key:  val_8[0], value:  val_11);
            val_19 = val_19 + 1;
        }
        while(val_19 < val_6.Length);
    
    }
    public BookList()
    {
    
    }
    private static BookList()
    {
        System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<System.String>>();
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        val_2.Add(item:  "6BC460A2C24A2E1FE7B56092B7208446");
        val_1.Add(item:  val_2);
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>();
        val_3.Add(item:  "7E46BE65620D0C1CB6C91C992308070B");
        val_3.Add(item:  "47755AE67981C7ADFD8FF224A5D83C47");
        val_3.Add(item:  "6F7E745DAD0787EF7DDA0997A578A52B");
        val_1.Add(item:  val_3);
        System.Collections.Generic.List<System.String> val_4 = new System.Collections.Generic.List<System.String>();
        val_4.Add(item:  "C55215698B92BB80396AA30221BDFD31");
        val_4.Add(item:  "1FE43F3F347A67378DCE8B83E77C09A8");
        val_4.Add(item:  "71A3F905D1E16D988F95153ACBEFE65A");
        val_1.Add(item:  val_4);
        System.Collections.Generic.List<System.String> val_5 = new System.Collections.Generic.List<System.String>();
        val_5.Add(item:  "A0306D3E7FF0AD822EE5030957BA2FA5");
        val_5.Add(item:  "DC76AF05354D1033B73A9BB7E767E9D4");
        val_5.Add(item:  "19B3D0337AAF6B912BA05D9F2A420415");
        val_1.Add(item:  val_5);
        System.Collections.Generic.List<System.String> val_6 = new System.Collections.Generic.List<System.String>();
        val_6.Add(item:  "9242E7B21E6BFD8D115D7D8D949462AC");
        val_6.Add(item:  "E6B7C23C609AAB4755F660FEC0F8229D");
        val_6.Add(item:  "B2D1D2348DCC240995A64CCB668997CD");
        val_1.Add(item:  val_6);
        System.Collections.Generic.List<System.String> val_7 = new System.Collections.Generic.List<System.String>();
        val_7.Add(item:  "57AD2DFD5C2D84407B0E003798898161");
        val_7.Add(item:  "BD73D7DFC1BE32A7977E21A741EE6C03");
        val_7.Add(item:  "7B41E30047BF7A94261F3BDE66CA78A1");
        val_1.Add(item:  val_7);
        BookList.BookOptionsSkus = val_1;
        BookList.hasLoaded = false;
    }

}
