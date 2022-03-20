using UnityEngine;
public class TheLibraryLogic
{
    // Fields
    private const string prefs_player_books = "player_library_books";
    private const string prefs_books_buyable_refreshed_time = "lib_buy_time";
    private const string prefs_books_buyable = "lib_buy_books";
    private const string prefs_books_purchased = "lib_pur_books";
    private const string prefs_saved_econ_version = "lib_econ_ver";
    private const string prefs_skus_from_chapters = "lib_skus_per_ch";
    private const string prefs_current_unlock_target_sku = "lib_tgt_sku";
    private const string prefs_book_packs_purchased = "lib_lft_bpks";
    private const string prefs_books_from_packs_purchased = "lib_bfp";
    public const string On_Book_Granted_Notification = "OnBookGranted";
    private const int EconVersion = 1;
    public static int LibraryAccessed;
    private static System.Collections.Generic.Dictionary<BookRarity, int> debug_rolledRarities;
    private static System.Collections.Generic.Dictionary<string, int> debug_rolledBooks;
    private static BookRarity[] PurchasableRarityDispersion;
    public static int PurchasableBookRefreshTimeHours;
    public static int CategoryCompleteLibraryBonus;
    public static System.Collections.Generic.Dictionary<BookRarity, BookEconInfo> BookEcon;
    public static int BookPackGemCost;
    public static int BookPackBookCount;
    private static int _MyEconVersion;
    private static System.Collections.Generic.List<BookInfo> playerBooks;
    private static System.Collections.Generic.List<string> _SkusGrantedForCompletedBooks;
    private static string _CurrentBookUnlockTarget;
    private static BookInfo _LastGrantedBook;
    private static System.DateTime _LastPurchasableRefreshDate;
    private static int TL_Version;
    private static int _LifetimeBookPacksPurchased;
    private static int _LifetimeBooksPurchasedInPacks;
    private static System.Collections.Generic.List<BookInfo> _PurchasableBooks;
    private static System.Collections.Generic.List<BookInfo> _PurchasedBooksInPeriod;
    private static int lastBookCount;
    private static int completedCollectionCount;
    private static RandomSet randomSet;
    private static System.Collections.Generic.List<BookInfo> booksOfRarity;
    private static BookInfo rolledBook;
    private const string prefs_server_queue = "lib_svr_q";
    private static bool IsPosting;
    private static System.Collections.Generic.Queue<TheLibraryServerQueuedItem> _QueuedItems;
    
    // Properties
    private static int MyEconVersion { get; set; }
    public static System.Collections.Generic.List<BookInfo> PlayerBooks { get; }
    public static System.Collections.Generic.List<string> SkusGrantedForCompletedBooks { get; }
    public static string CurrentBookUnlockTarget { get; set; }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<BookInfo>> PlayerBooksByCollection { get; }
    public static int LibraryScore { get; }
    public static BookInfo LastGrantedBook { get; }
    public static System.DateTime LastPurchasableRefreshDate { get; set; }
    public static int LifetimeBooksEarned { get; }
    public static int LifetimeBooksPurchased { get; }
    public static int LifetimeBookPacksPurchased { get; set; }
    public static int LifetimeBooksPurchasedInPacks { get; set; }
    public static System.Collections.Generic.List<BookInfo> PurchasableBooks { get; }
    public static System.Collections.Generic.List<BookInfo> PurchasedBooksInPeriod { get; set; }
    private static System.Collections.Generic.Queue<TheLibraryServerQueuedItem> QueuedItems { get; }
    
    // Methods
    private static int get_MyEconVersion()
    {
        int val_2;
        var val_3 = null;
        if(TheLibraryLogic._MyEconVersion == 1)
        {
                val_3 = null;
            val_2 = UnityEngine.PlayerPrefs.GetInt(key:  "lib_econ_ver", defaultValue:  0);
            val_3 = null;
            TheLibraryLogic._MyEconVersion = val_2;
        }
        
        val_3 = null;
        return (int)TheLibraryLogic._MyEconVersion;
    }
    private static void set_MyEconVersion(int value)
    {
        null = null;
        TheLibraryLogic._MyEconVersion = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "lib_econ_ver", value:  TheLibraryLogic._MyEconVersion);
    }
    public static System.Collections.Generic.List<BookInfo> get_PlayerBooks()
    {
        string val_3;
        var val_4 = null;
        if(TheLibraryLogic.playerBooks == null)
        {
                val_3 = UnityEngine.PlayerPrefs.GetString(key:  "player_library_books", defaultValue:  "{}");
            TheLibraryLogic.playerBooks = TheLibraryLogic.DeserializeBooksFromSkuCount(skuJson:  val_3);
            TheLibraryLogic.RequestPlayerBooksFromServer();
            val_4 = null;
        }
        
        val_4 = null;
        return (System.Collections.Generic.List<BookInfo>)TheLibraryLogic.playerBooks;
    }
    public static System.Collections.Generic.List<string> get_SkusGrantedForCompletedBooks()
    {
        System.Collections.Generic.List<System.String> val_3;
        var val_4 = null;
        if(TheLibraryLogic._SkusGrantedForCompletedBooks == null)
        {
                val_4 = null;
            val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "lib_skus_per_ch", defaultValue:  "[]"));
            val_4 = null;
            TheLibraryLogic._SkusGrantedForCompletedBooks = val_3;
        }
        
        val_4 = null;
        return (System.Collections.Generic.List<System.String>)TheLibraryLogic._SkusGrantedForCompletedBooks;
    }
    public static string get_CurrentBookUnlockTarget()
    {
        string val_6;
        var val_7;
        var val_8;
        var val_9;
        val_7 = null;
        val_7 = null;
        if((System.String.IsNullOrEmpty(value:  TheLibraryLogic._CurrentBookUnlockTarget)) != false)
        {
                val_8 = null;
            val_6 = UnityEngine.PlayerPrefs.GetString(key:  "lib_tgt_sku", defaultValue:  1152921513259884000);
            val_8 = null;
            TheLibraryLogic._CurrentBookUnlockTarget = val_6;
        }
        else
        {
                val_8 = null;
        }
        
        val_8 = null;
        if((System.String.IsNullOrEmpty(value:  TheLibraryLogic._CurrentBookUnlockTarget)) != false)
        {
                val_6 = TheLibraryLogic.GetBookChoices(currentBookIndex:  0);
            int val_5 = UnityEngine.Random.Range(min:  0, max:  0);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            TheLibraryLogic._CurrentBookUnlockTarget = (TheLibraryLogic.__il2cppRuntimeField_cctor_finished + (val_5) << 3) + 32 + 16;
            UnityEngine.PlayerPrefs.SetString(key:  "lib_tgt_sku", value:  TheLibraryLogic._CurrentBookUnlockTarget);
        }
        
        val_9 = null;
        val_9 = null;
        return TheLibraryLogic._CurrentBookUnlockTarget;
    }
    public static void set_CurrentBookUnlockTarget(string value)
    {
        null = null;
        TheLibraryLogic._CurrentBookUnlockTarget = value;
        UnityEngine.PlayerPrefs.SetString(key:  "lib_tgt_sku", value:  TheLibraryLogic._CurrentBookUnlockTarget);
    }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<BookInfo>> get_PlayerBooksByCollection()
    {
        return BookList.GroupBookInfosByCollection(booksToGroup:  TheLibraryLogic.PlayerBooks);
    }
    public static int get_LibraryScore()
    {
        System.Collections.Generic.Dictionary<BookRarity, BookEconInfo> val_5;
        var val_6;
        var val_7;
        var val_8;
        val_6 = 0;
        val_7 = 0;
        goto label_1;
        label_12:
        val_5 = TheLibraryLogic.BookEcon;
        System.Collections.Generic.List<BookInfo> val_1 = TheLibraryLogic.PlayerBooks;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        BookEconInfo val_2 = val_5.Item[TheLibraryLogic.PurchasableBookRefreshTimeHours + 40];
        val_6 = 1;
        val_7 = val_2.LibraryValue + val_7;
        label_1:
        System.Collections.Generic.List<BookInfo> val_3 = TheLibraryLogic.PlayerBooks;
        val_8 = null;
        if(val_6 < W9)
        {
            goto label_12;
        }
        
        int val_4 = TheLibraryLogic.CountCompletedCollections();
        val_4 = val_7 + (TheLibraryLogic.CategoryCompleteLibraryBonus * val_4);
        return (int)val_4;
    }
    public static BookInfo get_LastGrantedBook()
    {
        null = null;
        return (BookInfo)TheLibraryLogic._LastGrantedBook;
    }
    public static System.DateTime get_LastPurchasableRefreshDate()
    {
        var val_9;
        var val_10;
        System.DateTime val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        val_9 = null;
        val_9 = null;
        val_10 = null;
        val_11 = TheLibraryLogic._LastPurchasableRefreshDate;
        val_10 = null;
        if(((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_11}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) != false) && ((UnityEngine.PlayerPrefs.HasKey(key:  "lib_buy_time")) != false))
        {
                val_12 = null;
            val_12 = null;
            if((UnityEngine.PlayerPrefs.GetInt(key:  "tl_version", defaultValue:  1)) < TheLibraryLogic.TL_Version)
        {
                System.DateTime val_4 = System.DateTime.UtcNow;
            val_13 = null;
            val_11 = val_4.dateData;
            val_13 = null;
            TheLibraryLogic._LastPurchasableRefreshDate = val_11;
            UnityEngine.PlayerPrefs.SetInt(key:  "tl_version", value:  TheLibraryLogic.TL_Version);
            bool val_5 = PrefsSerializationManager.SavePlayerPrefs();
        }
        else
        {
                System.DateTime val_7 = System.DateTime.UtcNow;
            System.DateTime val_8 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "lib_buy_time"), defaultValue:  new System.DateTime() {dateData = val_7.dateData});
            val_14 = null;
            val_11 = val_8.dateData;
            val_14 = null;
            TheLibraryLogic._LastPurchasableRefreshDate = val_11;
        }
        
        }
        
        val_15 = null;
        val_15 = null;
        return (System.DateTime)TheLibraryLogic._LastPurchasableRefreshDate;
    }
    public static void set_LastPurchasableRefreshDate(System.DateTime value)
    {
        null = null;
        TheLibraryLogic._LastPurchasableRefreshDate = value.dateData;
        UnityEngine.PlayerPrefs.SetString(key:  "lib_buy_time", value:  TheLibraryLogic._LastPurchasableRefreshDate.ToString());
    }
    public static int get_LifetimeBooksEarned()
    {
        int val_2 = ChapterBookLogic.GetCurrentBook(playerLevel:  App.Player);
        val_2 = val_2 - 1;
        return (int)val_2;
    }
    public static int get_LifetimeBooksPurchased()
    {
        System.Collections.Generic.List<BookInfo> val_1 = TheLibraryLogic.PlayerBooks;
        int val_3 = TheLibraryLogic.LifetimeBooksPurchasedInPacks;
        val_3 = (W20 - TheLibraryLogic.LifetimeBooksEarned) - val_3;
        return (int)val_3;
    }
    public static int get_LifetimeBookPacksPurchased()
    {
        int val_2;
        var val_3 = null;
        if((TheLibraryLogic._LifetimeBookPacksPurchased & 2147483648) != 0)
        {
                val_3 = null;
            val_2 = UnityEngine.PlayerPrefs.GetInt(key:  "lib_lft_bpks", defaultValue:  0);
            val_3 = null;
            TheLibraryLogic._LifetimeBookPacksPurchased = val_2;
        }
        
        val_3 = null;
        return (int)TheLibraryLogic._LifetimeBookPacksPurchased;
    }
    public static void set_LifetimeBookPacksPurchased(int value)
    {
        null = null;
        TheLibraryLogic._LifetimeBookPacksPurchased = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "lib_lft_bpks", value:  TheLibraryLogic._LifetimeBookPacksPurchased);
    }
    public static int get_LifetimeBooksPurchasedInPacks()
    {
        int val_2;
        var val_3 = null;
        if((TheLibraryLogic._LifetimeBooksPurchasedInPacks & 2147483648) != 0)
        {
                val_3 = null;
            val_2 = UnityEngine.PlayerPrefs.GetInt(key:  "lib_bfp", defaultValue:  0);
            val_3 = null;
            TheLibraryLogic._LifetimeBooksPurchasedInPacks = val_2;
        }
        
        val_3 = null;
        return (int)TheLibraryLogic._LifetimeBooksPurchasedInPacks;
    }
    public static void set_LifetimeBooksPurchasedInPacks(int value)
    {
        null = null;
        TheLibraryLogic._LifetimeBooksPurchasedInPacks = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "lib_bfp", value:  TheLibraryLogic._LifetimeBooksPurchasedInPacks);
    }
    public static System.Collections.Generic.List<BookInfo> get_PurchasableBooks()
    {
        var val_32;
        System.Collections.Generic.List<BookInfo> val_33;
        ulong val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        System.Predicate<BookInfo> val_41;
        var val_42;
        var val_43;
        var val_46;
        var val_47;
        var val_48;
        System.Collections.Generic.List<BookInfo> val_50;
        val_32 = null;
        val_32 = null;
        if(TheLibraryLogic._PurchasableBooks == null)
        {
                val_32 = null;
            TheLibraryLogic._PurchasableBooks = TheLibraryLogic.DeserializeBooksFromSkuCount(skuJson:  UnityEngine.PlayerPrefs.GetString(key:  "lib_buy_books", defaultValue:  "{}"));
        }
        
        val_32 = null;
        val_33 = TheLibraryLogic._PurchasableBooks;
        if(val_33 == null)
        {
            goto label_12;
        }
        
        val_33 = TheLibraryLogic._PurchasableBooks;
        if((mem[val_2 + 24]) < 1)
        {
            goto label_12;
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        val_34 = val_3.dateData;
        System.DateTime val_4 = TheLibraryLogic.LastPurchasableRefreshDate;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_34}, d2:  new System.DateTime() {dateData = val_4.dateData});
        val_35 = null;
        int val_32 = TheLibraryLogic.PurchasableBookRefreshTimeHours;
        val_32 = val_32 * 3600;
        if(val_5._ticks.TotalSeconds <= (double)val_32)
        {
            goto label_19;
        }
        
        label_12:
        System.Collections.Generic.List<BookInfo> val_7 = null;
        val_34 = val_7;
        val_7 = new System.Collections.Generic.List<BookInfo>();
        val_36 = null;
        val_36 = null;
        TheLibraryLogic._PurchasableBooks = val_34;
        val_37 = 0;
        goto label_22;
        label_86:
        System.Collections.Generic.List<BookInfo> val_8 = TheLibraryLogic.PlayerBooks;
        val_38 = null;
        val_38 = null;
        val_39 = null;
        val_39 = null;
        val_41 = TheLibraryLogic.<>c.<>9__60_0;
        if(val_41 == null)
        {
                System.Predicate<BookInfo> val_11 = null;
            val_41 = val_11;
            val_11 = new System.Predicate<BookInfo>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TheLibraryLogic.<>c::<get_PurchasableBooks>b__60_0(BookInfo b));
            TheLibraryLogic.<>c.<>9__60_0 = val_41;
        }
        
        val_42 = BookList.BooksByRarity.Item[TheLibraryLogic.PurchasableRarityDispersion + 32].FindAll(match:  val_11);
        if(val_41 < 1)
        {
            goto label_41;
        }
        
        val_43 = 0;
        int val_13 = UnityEngine.Random.Range(min:  0, max:  -1617826560);
        goto label_42;
        label_41:
        val_34 = 0;
        if(val_34 != 0)
        {
            goto label_62;
        }
        
        label_79:
        val_46 = null;
        val_46 = null;
        val_42 = BookList.BooksByRarity.Item[TheLibraryLogic.PurchasableRarityDispersion + 32];
        System.Collections.Generic.List<BookInfo> val_23 = BookList.BooksByRarity.Item[TheLibraryLogic.PurchasableRarityDispersion + 32];
        val_43 = 0;
        int val_24 = UnityEngine.Random.Range(min:  0, max:  TheLibraryLogic.PurchasableRarityDispersion + 32);
        label_42:
        if(TheLibraryLogic.PurchasableRarityDispersion <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<BookInfo> val_25 = val_42 + 16;
        System.Collections.Generic.List<BookInfo> val_26 = 1152921504687730688 + (val_24 << 3);
        val_34 = mem[(1152921504687730688 + (val_24) << 3) + 32];
        if(val_34 == 0)
        {
            goto label_79;
        }
        
        label_62:
        val_47 = null;
        val_47 = null;
        if((TheLibraryLogic.ListContainsBook(bookInfos:  val_7, bookToCheck:  val_34)) == true)
        {
            goto label_79;
        }
        
        val_48 = null;
        val_48 = null;
        val_7.Add(item:  val_34);
        val_36 = null;
        val_37 = 1;
        label_22:
        val_36 = null;
        if(val_37 < TheLibraryLogic.PurchasableRarityDispersion.Length)
        {
            goto label_86;
        }
        
        val_36 = null;
        val_50 = TheLibraryLogic._PurchasedBooksInPeriod;
        if(val_50 != null)
        {
                val_50 = TheLibraryLogic._PurchasedBooksInPeriod;
            val_50.Clear();
            System.Collections.Generic.List<BookInfo> val_28 = null;
            val_34 = val_28;
            val_28 = new System.Collections.Generic.List<BookInfo>();
            TheLibraryLogic.PurchasedBooksInPeriod = val_28;
            val_36 = null;
        }
        
        val_36 = null;
        UnityEngine.PlayerPrefs.SetString(key:  "lib_buy_books", value:  TheLibraryLogic.SerializeBooksToSkuCount(booksToSerialize:  val_7));
        System.DateTime val_30 = DateTimeCheat.UtcNow;
        TheLibraryLogic.LastPurchasableRefreshDate = new System.DateTime() {dateData = val_30.dateData};
        bool val_31 = PrefsSerializationManager.SavePlayerPrefs();
        val_35 = null;
        label_19:
        val_35 = null;
        return TheLibraryLogic._PurchasableBooks;
    }
    public static System.Collections.Generic.List<BookInfo> get_PurchasedBooksInPeriod()
    {
        string val_3;
        var val_4 = null;
        if(TheLibraryLogic._PurchasedBooksInPeriod == null)
        {
                val_3 = UnityEngine.PlayerPrefs.GetString(key:  "lib_pur_books", defaultValue:  "{}");
            val_4 = null;
            TheLibraryLogic._PurchasedBooksInPeriod = TheLibraryLogic.DeserializeBooksFromSkuCount(skuJson:  val_3);
        }
        
        val_4 = null;
        return (System.Collections.Generic.List<BookInfo>)TheLibraryLogic._PurchasedBooksInPeriod;
    }
    public static void set_PurchasedBooksInPeriod(System.Collections.Generic.List<BookInfo> value)
    {
        null = null;
        TheLibraryLogic._PurchasedBooksInPeriod = value;
        UnityEngine.PlayerPrefs.SetString(key:  "lib_pur_books", value:  TheLibraryLogic.SerializeBooksToSkuCount(booksToSerialize:  TheLibraryLogic._PurchasedBooksInPeriod));
    }
    public static void GrantTargetBook()
    {
        TheLibraryLogic._LastGrantedBook = BookList.BookInfos.Item[TheLibraryLogic.CurrentBookUnlockTarget];
        TheLibraryLogic.SkusGrantedForCompletedBooks.Add(item:  val_3.SKU);
        UnityEngine.PlayerPrefs.SetString(key:  "lib_skus_per_ch", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  TheLibraryLogic.SkusGrantedForCompletedBooks));
        TheLibraryLogic.CurrentBookUnlockTarget = "";
        TheLibraryLogic.AddBookToPlayer(bookInfo:  TheLibraryLogic._LastGrantedBook, purchased:  false);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_8.Add(key:  "Book Collected", value:  System.String.Format(format:  "{0} - {1}", arg0:  val_3.Title, arg1:  val_3.Author));
        App.Player.TrackNonCoinReward(source:  "Chapter Complete", subSource:  "Free Book", rewardType:  0, rewardAmount:  0, additionalParams:  val_8);
    }
    public static BookInfo GrantRandomBook()
    {
        TheLibraryLogic._LastGrantedBook = TheLibraryLogic.GetRandomBook();
        TheLibraryLogic.SkusGrantedForCompletedBooks.Add(item:  val_1.SKU);
        UnityEngine.PlayerPrefs.SetString(key:  "lib_skus_per_ch", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  TheLibraryLogic.SkusGrantedForCompletedBooks));
        TheLibraryLogic.AddBookToPlayer(bookInfo:  TheLibraryLogic._LastGrantedBook, purchased:  false);
        return TheLibraryLogic._LastGrantedBook;
    }
    public static bool BuyBook(BookInfo bookToBuy)
    {
        var val_14;
        var val_15;
        val_14 = null;
        val_14 = null;
        BookEconInfo val_1 = TheLibraryLogic.BookEcon.Item[bookToBuy.Rarity];
        Player val_2 = App.Player;
        if(val_2._stars < val_1.GoldenAppleCost)
        {
                val_15 = 0;
            return (bool)val_15;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "Book Purchased", value:  System.String.Format(format:  "{0} - {1}", arg0:  bookToBuy.Title, arg1:  bookToBuy.Author));
        mem2[0] = bookToBuy.Rarity;
        MonoSingleton<GoldenApplesManager>.Instance.DebitBalance(debitAmount:  val_1.GoldenAppleCost, source:  System.String.Format(format:  "Book {0}", arg0:  bookToBuy.Rarity.ToString()), additionalParams:  val_3);
        TheLibraryLogic.AddBookToPlayer(bookInfo:  bookToBuy, purchased:  true);
        TheLibraryLogic.AddPurchasedBookForPeriod(bookInfo:  bookToBuy);
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  20);
        System.DateTime val_8 = TheLibraryLogic.LastPurchasableRefreshDate;
        System.DateTime val_9 = val_8.dateData.AddHours(value:  (double)TheLibraryLogic.PurchasableBookRefreshTimeHours);
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  20, when:  new System.DateTime() {dateData = val_9.dateData}, optMessage:  "New books are available!", extraData:  0);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        if(SLC.Social.Leagues.LeaguesManager.DAO != 0)
        {
                val_15 = 1;
            SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  true);
            return (bool)val_15;
        }
        
        val_15 = 1;
        return (bool)val_15;
    }
    public static System.Collections.Generic.List<BookInfo> BuyBookPack(int packSize)
    {
        var val_8;
        var val_9;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        val_21 = null;
        val_21 = null;
        System.Collections.Generic.List<BookInfo> val_1 = new System.Collections.Generic.List<BookInfo>();
        val_22 = 1152921504884269056;
        Player val_2 = App.Player;
        if(val_2._gems < TheLibraryLogic.BookPackGemCost)
        {
                return val_1;
        }
        
        App.Player.AddGems(amount:  -TheLibraryLogic.BookPackGemCost, source:  System.String.Format(format:  "{0} Book Pack", arg0:  packSize), subsource:  0);
        RandomSet val_5 = null;
        val_22 = val_5;
        val_5 = new RandomSet();
        val_23 = null;
        val_23 = null;
        Dictionary.ValueCollection.Enumerator<TKey, TValue> val_7 = TheLibraryLogic.BookEcon.Values.GetEnumerator();
        label_17:
        if(val_9.MoveNext() == false)
        {
            goto label_14;
        }
        
        if(val_8 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_5.add(item:  val_8 + 16, weight:  (float)val_8 + 28);
        goto label_17;
        label_14:
        val_9.Dispose();
        .replacement = true;
        val_5.printBuckets();
        if(packSize >= 1)
        {
                var val_20 = 0;
            do
        {
            int val_12 = val_5.roll(unweighted:  false);
            if(((val_12 == 0) ? (0 + 1) : 0) == 3)
        {
                val_5.use(item:  0);
        }
        
            if(((packSize - 2) == val_20) && ((((val_12 & 4294967294) == 2) ? (0 + 1) : 0) == 0))
        {
                val_5.use(item:  0);
            val_5.use(item:  1);
        }
        
            val_5.printBuckets();
            BookInfo val_16 = TheLibraryLogic.GetRandomBookByRarity(rarity:  val_12);
            TheLibraryLogic.AddBookToPlayer(bookInfo:  val_16, purchased:  true);
            TheLibraryLogic.AddPurchasedBookForPeriod(bookInfo:  val_16);
            val_1.Add(item:  val_16);
            val_20 = val_20 + 1;
        }
        while(val_20 < packSize);
        
        }
        
        val_24 = null;
        int val_17 = TheLibraryLogic.LifetimeBookPacksPurchased;
        val_17 = val_17 + 1;
        TheLibraryLogic.LifetimeBookPacksPurchased = val_17;
        int val_18 = TheLibraryLogic.LifetimeBooksPurchasedInPacks;
        TheLibraryLogic.LifetimeBooksPurchasedInPacks = (TheLibraryLogic.__il2cppRuntimeField_cctor_finished + val_18)>>0&0xFFFFFFFF;
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
        return val_1;
    }
    public static void Hack_GrantBook(BookInfo bookToGive)
    {
        TheLibraryLogic.AddBookToPlayer(bookInfo:  bookToGive, purchased:  true);
    }
    public static void Hack_BackFillBooksEarned()
    {
        System.Collections.Generic.List<System.String> val_2 = TheLibraryLogic.SkusGrantedForCompletedBooks;
        int val_3 = (ChapterBookLogic.GetCurrentBook(playerLevel:  0)) - 1;
        if(val_3 >= 1)
        {
                var val_10 = 0;
            do
        {
            if(val_10 >= W24)
        {
                System.Collections.Generic.List<BookInfo> val_4 = TheLibraryLogic.GetBookChoices(currentBookIndex:  0);
            int val_5 = UnityEngine.Random.Range(min:  0, max:  0);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            TheLibraryLogic.SkusGrantedForCompletedBooks.Add(item:  (TheLibraryLogic.__il2cppRuntimeField_cctor_finished + (val_5) << 3) + 32 + 16);
            TheLibraryLogic.playerBooks.Add(item:  (TheLibraryLogic.__il2cppRuntimeField_cctor_finished + (val_5) << 3) + 32);
        }
        
            val_10 = val_10 + 1;
        }
        while(val_10 < val_3);
        
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "lib_skus_per_ch", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  TheLibraryLogic.SkusGrantedForCompletedBooks));
        bool val_9 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static string LogDebug()
    {
        null = null;
        TheLibraryLogic.randomSet.printBuckets();
        return System.String.Format(format:  "Rarity Rolls:\n{0}\nBook Rolls:\n{1}", arg0:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  TheLibraryLogic.debug_rolledRarities, formatting:  1), arg1:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  TheLibraryLogic.debug_rolledBooks, formatting:  1));
    }
    public static int CountTimesCollectionCompleted(System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<BookInfo>> playerCollection)
    {
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_12;
        var val_13;
        System.Func<BookInfo, System.String> val_15;
        var val_16;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_18;
        var val_19;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32> val_22;
        System.Collections.Generic.List<BookInfo> val_2 = BookList.BooksByCollection.Item[playerCollection.Value];
        if((X1 + 24) < W9)
        {
                return 0;
        }
        
        val_13 = null;
        val_13 = null;
        val_15 = TheLibraryLogic.<>c.<>9__72_0;
        if(val_15 == null)
        {
                System.Func<BookInfo, System.String> val_3 = null;
            val_15 = val_3;
            val_3 = new System.Func<BookInfo, System.String>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryLogic.<>c::<CountTimesCollectionCompleted>b__72_0(BookInfo bookInfo));
            TheLibraryLogic.<>c.<>9__72_0 = val_15;
        }
        
        val_16 = null;
        val_16 = null;
        val_18 = TheLibraryLogic.<>c.<>9__72_1;
        if(val_18 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_5 = null;
            val_18 = val_5;
            val_5 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.Linq.IGrouping<System.String, BookInfo> TheLibraryLogic.<>c::<CountTimesCollectionCompleted>b__72_1(System.Linq.IGrouping<string, BookInfo> newGroup));
            TheLibraryLogic.<>c.<>9__72_1 = val_18;
        }
        
        val_19 = null;
        val_19 = null;
        val_12 = TheLibraryLogic.<>c.<>9__72_2;
        if(val_12 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_7 = null;
            val_12 = val_7;
            val_7 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryLogic.<>c::<CountTimesCollectionCompleted>b__72_2(System.Linq.IGrouping<string, BookInfo> queryEntry));
            val_19 = null;
            TheLibraryLogic.<>c.<>9__72_2 = val_12;
        }
        
        val_19 = null;
        val_22 = TheLibraryLogic.<>c.<>9__72_3;
        if(val_22 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32> val_8 = null;
            val_22 = val_8;
            val_8 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TheLibraryLogic.<>c::<CountTimesCollectionCompleted>b__72_3(System.Linq.IGrouping<string, BookInfo> queryEntry));
            TheLibraryLogic.<>c.<>9__72_3 = val_22;
        }
        
        System.Collections.Generic.Dictionary<TKey, TElement> val_9 = System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<System.String, BookInfo>, System.String, System.Int32>(source:  System.Linq.Enumerable.Select<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String>(source:  X1, keySelector:  val_3), selector:  val_5), keySelector:  val_7, elementSelector:  val_8);
        if(val_9.Count >= 1152921515875477744)
        {
                return System.Linq.Enumerable.Min(source:  val_9.Values);
        }
        
        return 0;
    }
    public static bool ListContainsBook(System.Collections.Generic.List<BookInfo> bookInfos, BookInfo bookToCheck)
    {
        .bookToCheck = bookToCheck;
        return System.Linq.Enumerable.Any<BookInfo>(source:  bookInfos, predicate:  new System.Func<BookInfo, System.Boolean>(object:  new TheLibraryLogic.<>c__DisplayClass73_0(), method:  System.Boolean TheLibraryLogic.<>c__DisplayClass73_0::<ListContainsBook>b__0(BookInfo b)));
    }
    public static void AddPurchasedBookForPeriod(BookInfo bookInfo)
    {
        TheLibraryLogic.PurchasedBooksInPeriod.Add(item:  bookInfo);
        UnityEngine.PlayerPrefs.SetString(key:  "lib_pur_books", value:  TheLibraryLogic.SerializeBooksToSkuCount(booksToSerialize:  TheLibraryLogic._PurchasedBooksInPeriod));
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static bool BookAlreadyPurchased(BookInfo bookInfo)
    {
        return TheLibraryLogic.ListContainsBook(bookInfos:  TheLibraryLogic.PurchasedBooksInPeriod, bookToCheck:  bookInfo);
    }
    public static void TrackSessionEnd(ref System.Collections.Generic.Dictionary<string, object> eventProperties)
    {
        var val_1;
        if(((0 & 2) != 0) && (0 == 0))
        {
                val_1 = null;
        }
        
        eventProperties.Add(key:  "Library Accessed", value:  TheLibraryLogic.prefs_server_queue);
        TheLibraryLogic.prefs_server_queue = 0;
    }
    public static int CountCompletedCollections()
    {
        var val_9;
        int val_10;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        val_9 = null;
        val_9 = null;
        val_10 = TheLibraryLogic.lastBookCount;
        System.Collections.Generic.List<BookInfo> val_1 = TheLibraryLogic.PlayerBooks;
        val_11 = null;
        if(val_10 == W9)
        {
                val_12 = null;
            val_13 = 1152921504898859192;
            return (int)TheLibraryLogic.completedCollectionCount;
        }
        
        val_14 = null;
        TheLibraryLogic.completedCollectionCount = 0;
        val_10 = TheLibraryLogic.PlayerBooks;
        Dictionary.Enumerator<TKey, TValue> val_4 = BookList.GroupBookInfosByCollection(booksToGroup:  val_10).GetEnumerator();
        goto label_13;
        label_16:
        val_15 = null;
        val_10 = 0;
        val_15 = null;
        int val_6 = (TheLibraryLogic.CountTimesCollectionCompleted(playerCollection:  new System.Collections.Generic.KeyValuePair<System.String, System.Collections.Generic.List<BookInfo>>() {Value = val_10})) + TheLibraryLogic.completedCollectionCount;
        TheLibraryLogic.completedCollectionCount = val_6;
        label_13:
        if(0.MoveNext() == true)
        {
            goto label_16;
        }
        
        0.Dispose();
        System.Collections.Generic.List<BookInfo> val_8 = TheLibraryLogic.PlayerBooks;
        val_13 = null;
        TheLibraryLogic.lastBookCount = val_6;
        return (int)TheLibraryLogic.completedCollectionCount;
    }
    public static string GetProgressForCollection(string collectionName, bool showCompletedState = True)
    {
        System.Func<TSource, System.Boolean> val_36;
        var val_37;
        System.Func<BookInfo, System.String> val_39;
        var val_40;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_42;
        var val_43;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_45;
        System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32> val_47;
        var val_48;
        System.Func<BookInfo, System.String> val_50;
        System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo> val_52;
        var val_53;
        System.Func<BookInfo, System.Int32> val_55;
        var val_56;
        System.Func<BookInfo, System.String> val_58;
        var val_59;
        object val_60;
        string val_62;
        val_36 = 1152921515875437808;
        System.Collections.Generic.List<BookInfo> val_3 = BookList.BooksByCollection.Item[collectionName];
        if((TheLibraryLogic.PlayerBooksByCollection.Count < 1) || ((TheLibraryLogic.PlayerBooksByCollection.ContainsKey(key:  collectionName)) == false))
        {
            goto label_11;
        }
        
        System.Collections.Generic.List<BookInfo> val_9 = TheLibraryLogic.PlayerBooksByCollection.Item[collectionName];
        val_37 = null;
        val_37 = null;
        val_39 = TheLibraryLogic.<>c.<>9__80_0;
        if(val_39 == null)
        {
                System.Func<BookInfo, System.String> val_10 = null;
            val_39 = val_10;
            val_10 = new System.Func<BookInfo, System.String>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryLogic.<>c::<GetProgressForCollection>b__80_0(BookInfo bookInfo));
            TheLibraryLogic.<>c.<>9__80_0 = val_39;
        }
        
        val_40 = null;
        val_40 = null;
        val_42 = TheLibraryLogic.<>c.<>9__80_1;
        if(val_42 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>> val_12 = null;
            val_42 = val_12;
            val_12 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.Linq.IGrouping<System.String, BookInfo> TheLibraryLogic.<>c::<GetProgressForCollection>b__80_1(System.Linq.IGrouping<string, BookInfo> newGroup));
            TheLibraryLogic.<>c.<>9__80_1 = val_42;
        }
        
        val_43 = null;
        val_43 = null;
        val_45 = TheLibraryLogic.<>c.<>9__80_2;
        if(val_45 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String> val_14 = null;
            val_45 = val_14;
            val_14 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.String>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryLogic.<>c::<GetProgressForCollection>b__80_2(System.Linq.IGrouping<string, BookInfo> queryEntry));
            val_43 = null;
            TheLibraryLogic.<>c.<>9__80_2 = val_45;
        }
        
        val_43 = null;
        val_47 = TheLibraryLogic.<>c.<>9__80_3;
        if(val_47 == null)
        {
                System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32> val_15 = null;
            val_47 = val_15;
            val_15 = new System.Func<System.Linq.IGrouping<System.String, BookInfo>, System.Int32>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TheLibraryLogic.<>c::<GetProgressForCollection>b__80_3(System.Linq.IGrouping<string, BookInfo> queryEntry));
            TheLibraryLogic.<>c.<>9__80_3 = val_47;
        }
        
        System.Collections.Generic.Dictionary<TKey, TElement> val_16 = System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<System.String, BookInfo>, System.String, System.Int32>(source:  System.Linq.Enumerable.Select<System.Linq.IGrouping<System.String, BookInfo>, System.Linq.IGrouping<System.String, BookInfo>>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String>(source:  val_9, keySelector:  val_10), selector:  val_12), keySelector:  val_14, elementSelector:  val_15);
        val_48 = null;
        val_48 = null;
        val_50 = TheLibraryLogic.<>c.<>9__80_4;
        if(val_50 == null)
        {
                System.Func<BookInfo, System.String> val_17 = null;
            val_50 = val_17;
            val_17 = new System.Func<BookInfo, System.String>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryLogic.<>c::<GetProgressForCollection>b__80_4(BookInfo b));
            val_48 = null;
            TheLibraryLogic.<>c.<>9__80_4 = val_50;
        }
        
        val_48 = null;
        val_52 = TheLibraryLogic.<>c.<>9__80_5;
        if(val_52 == null)
        {
                System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo> val_18 = null;
            val_52 = val_18;
            val_18 = new System.Func<System.String, System.Collections.Generic.IEnumerable<BookInfo>, BookInfo>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  BookInfo TheLibraryLogic.<>c::<GetProgressForCollection>b__80_5(string key, System.Collections.Generic.IEnumerable<BookInfo> group));
            TheLibraryLogic.<>c.<>9__80_5 = val_52;
        }
        
        val_53 = null;
        val_53 = null;
        val_55 = TheLibraryLogic.<>c.<>9__80_6;
        if(val_55 == null)
        {
                System.Func<BookInfo, System.Int32> val_20 = null;
            val_55 = val_20;
            val_20 = new System.Func<BookInfo, System.Int32>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TheLibraryLogic.<>c::<GetProgressForCollection>b__80_6(BookInfo b));
            TheLibraryLogic.<>c.<>9__80_6 = val_55;
        }
        
        val_56 = null;
        val_56 = null;
        val_58 = TheLibraryLogic.<>c.<>9__80_7;
        if(val_58 == null)
        {
                System.Func<BookInfo, System.String> val_22 = null;
            val_58 = val_22;
            val_22 = new System.Func<BookInfo, System.String>(object:  TheLibraryLogic.<>c.__il2cppRuntimeField_static_fields, method:  System.String TheLibraryLogic.<>c::<GetProgressForCollection>b__80_7(BookInfo b));
            TheLibraryLogic.<>c.<>9__80_7 = val_58;
        }
        
        System.Collections.Generic.List<TSource> val_24 = System.Linq.Enumerable.ToList<BookInfo>(source:  System.Linq.Enumerable.ThenBy<BookInfo, System.String>(source:  System.Linq.Enumerable.OrderBy<BookInfo, System.Int32>(source:  System.Linq.Enumerable.GroupBy<BookInfo, System.String, BookInfo>(source:  val_9, keySelector:  val_17, resultSelector:  val_18), keySelector:  val_20), keySelector:  val_22));
        .timesCompleted = 0;
        if(val_16.Count >= 1152921515875477744)
        {
            goto label_58;
        }
        
        val_59 = 0;
        goto label_59;
        label_11:
        val_60 = 0.ToString();
        string val_27 = 1152921515876346304.ToString();
        val_62 = "{0}/{1}";
        return (string)System.String.Format(format:  val_62 = "{0}/{1}", arg0:  val_60 = val_32.ToString(), arg1:  "{0}/{1}".ToString());
        label_58:
        label_59:
        .timesCompleted = System.Linq.Enumerable.Min(source:  val_16.Values);
        System.Func<System.Int32, System.Boolean> val_31 = null;
        val_36 = val_31;
        val_31 = new System.Func<System.Int32, System.Boolean>(object:  new TheLibraryLogic.<>c__DisplayClass80_0(), method:  System.Boolean TheLibraryLogic.<>c__DisplayClass80_0::<GetProgressForCollection>b__8(int c));
        int val_32 = System.Linq.Enumerable.Count<System.Int32>(source:  val_16.Values, predicate:  val_31);
        if((showCompletedState == false) || (((TheLibraryLogic.<>c__DisplayClass80_0)[1152921515876531328].timesCompleted) <= 0))
        {
            goto label_63;
        }
        
        val_62 = "{0}/{1}";
        if(val_32 != 0)
        {
            goto label_64;
        }
        
        goto label_65;
        label_63:
        label_64:
        label_65:
        return (string)System.String.Format(format:  val_62, arg0:  val_60, arg1:  "{0}/{1}".ToString());
    }
    public static string GetCurrentBookUnlockTarget()
    {
        string val_3;
        var val_4;
        var val_5;
        val_4 = null;
        val_4 = null;
        if((System.String.IsNullOrEmpty(value:  TheLibraryLogic._CurrentBookUnlockTarget)) != false)
        {
                val_5 = null;
            val_3 = UnityEngine.PlayerPrefs.GetString(key:  "lib_tgt_sku", defaultValue:  "");
            val_5 = null;
            TheLibraryLogic._CurrentBookUnlockTarget = val_3;
        }
        else
        {
                val_5 = null;
        }
        
        val_5 = null;
        return (string)TheLibraryLogic._CurrentBookUnlockTarget;
    }
    public static System.Collections.Generic.List<BookInfo> GetBookChoices(int currentBookIndex = -1)
    {
        var val_7;
        var val_8;
        var val_9;
        System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_10;
        val_7 = currentBookIndex;
        if((val_7 & 2147483648) != 0)
        {
                val_7 = (ChapterBookLogic.GetCurrentBook(playerLevel:  0)) - 1;
        }
        
        System.Collections.Generic.List<BookInfo> val_2 = new System.Collections.Generic.List<BookInfo>();
        val_8 = 1152921504898273280;
        val_9 = null;
        val_9 = null;
        val_10 = BookList.BookOptionsSkus;
        if(val_7 < (BookList.BookOptionsSkus + 24))
        {
                val_10 = BookList.BookOptionsSkus;
            if((BookList.BookOptionsSkus + 24) <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_6 = BookList.BookOptionsSkus + 16;
            val_6 = val_6 + (val_7 << 3);
            if(((BookList.BookOptionsSkus + 16 + ((val_1 - 1)) << 3) + 32 + 24) < 1)
        {
                return val_2;
        }
        
            var val_8 = 0;
            do
        {
            if(val_8 >= ((BookList.BookOptionsSkus + 16 + ((val_1 - 1)) << 3) + 32 + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_7 = (BookList.BookOptionsSkus + 16 + ((val_1 - 1)) << 3) + 32 + 16;
            val_7 = val_7 + 0;
            val_2.Add(item:  BookList.BookInfos.Item[((BookList.BookOptionsSkus + 16 + ((val_1 - 1)) << 3) + 32 + 16 + 0) + 32]);
            val_8 = val_8 + 1;
        }
        while(val_8 < ((BookList.BookOptionsSkus + 16 + ((val_1 - 1)) << 3) + 32 + 24));
        
            return val_2;
        }
        
        val_8 = 1152921504898859008;
        var val_9 = 0;
        do
        {
            val_2.Add(item:  TheLibraryLogic.GetRandomBook());
            val_9 = val_9 + 1;
        }
        while(val_9 < 2);
        
        return val_2;
    }
    public static void InitializePlayerData()
    {
        string val_8;
        var val_9;
        var val_10;
        val_9 = null;
        val_9 = null;
        if(TheLibraryLogic.playerBooks == null)
        {
                val_8 = UnityEngine.PlayerPrefs.GetString(key:  "player_library_books", defaultValue:  "{}");
            TheLibraryLogic.playerBooks = TheLibraryLogic.DeserializeBooksFromSkuCount(skuJson:  val_8);
            TheLibraryLogic.RequestPlayerBooksFromServer();
            val_9 = null;
        }
        
        val_9 = null;
        if((System.String.IsNullOrEmpty(value:  TheLibraryLogic._CurrentBookUnlockTarget)) != false)
        {
                val_10 = null;
            val_8 = UnityEngine.PlayerPrefs.GetString(key:  "lib_tgt_sku", defaultValue:  "");
            val_10 = null;
            TheLibraryLogic._CurrentBookUnlockTarget = val_8;
        }
        else
        {
                val_10 = null;
        }
        
        val_10 = null;
        if((System.String.IsNullOrEmpty(value:  TheLibraryLogic._CurrentBookUnlockTarget)) == false)
        {
                return;
        }
        
        System.Collections.Generic.List<BookInfo> val_6 = TheLibraryLogic.GetBookChoices(currentBookIndex:  0);
        int val_7 = UnityEngine.Random.Range(min:  0, max:  0);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        TheLibraryLogic._CurrentBookUnlockTarget = (TheLibraryLogic.__il2cppRuntimeField_cctor_finished + (val_7) << 3) + 32 + 16;
        UnityEngine.PlayerPrefs.SetString(key:  "lib_tgt_sku", value:  TheLibraryLogic._CurrentBookUnlockTarget);
    }
    public static BookInfo GetRandomBook()
    {
        var val_4;
        var val_5;
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        RandomSet val_15;
        var val_16;
        val_11 = null;
        val_11 = null;
        if(TheLibraryLogic.randomSet != null)
        {
            goto label_3;
        }
        
        RandomSet val_1 = new RandomSet();
        val_12 = null;
        val_12 = null;
        TheLibraryLogic.randomSet = val_1;
        Dictionary.ValueCollection.Enumerator<TKey, TValue> val_3 = TheLibraryLogic.BookEcon.Values.GetEnumerator();
        val_10 = 1152921515874872928;
        label_13:
        if(val_5.MoveNext() == false)
        {
            goto label_8;
        }
        
        val_13 = null;
        val_14 = null;
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_15 = TheLibraryLogic.randomSet;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.add(item:  val_4 + 16, weight:  (float)val_4 + 28);
        goto label_13;
        label_8:
        val_5.Dispose();
        val_16 = null;
        val_16 = null;
        mem[1152921515877188240] = 1;
        val_1.printBuckets();
        val_11 = null;
        label_3:
        val_11 = null;
        return (BookInfo)TheLibraryLogic.GetRandomBookByRarity(rarity:  val_1.roll(unweighted:  false));
    }
    private static BookInfo GetRandomBookByRarity(BookRarity rarity)
    {
        var val_4 = null;
        TheLibraryLogic.booksOfRarity = BookList.BooksByRarity.Item[rarity];
        int val_3 = UnityEngine.Random.Range(min:  0, max:  mem[val_2 + 24]);
        if((mem[val_2 + 24]) <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_4 = mem[val_2 + 16];
        val_4 = val_4 + (val_3 << 3);
        TheLibraryLogic.rolledBook = (mem[val_2 + 16] + (val_3) << 3) + 32;
        TheLibraryLogic.DebugRoll(rolledRarityToTrack:  rarity, rolledBookToTrack:  TheLibraryLogic.rolledBook);
        return TheLibraryLogic.rolledBook;
    }
    private static void AddBookToPlayer(BookInfo bookInfo, bool purchased)
    {
        TheLibraryLogic.PlayerBooks.Add(item:  bookInfo);
        UnityEngine.PlayerPrefs.SetString(key:  "player_library_books", value:  TheLibraryLogic.SerializeBooksToSkuCount(booksToSerialize:  TheLibraryLogic.PlayerBooks));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnBookGranted");
        TheLibraryLogic.PostAddedBookToServer(sku:  bookInfo.SKU, purchased:  purchased);
    }
    private static void DebugRoll(BookRarity rolledRarityToTrack, BookInfo rolledBookToTrack)
    {
        var val_9;
        var val_10;
        var val_11;
        var val_13;
        var val_15;
        val_9 = null;
        val_9 = null;
        TheLibraryLogic.debug_rolledRarities.set_Item(key:  rolledRarityToTrack, value:  TheLibraryLogic.debug_rolledRarities.Item[rolledRarityToTrack] + 1);
        val_10 = TheLibraryLogic.debug_rolledBooks;
        val_11 = null;
        if((val_10.ContainsKey(key:  rolledBookToTrack.Author + " - "(" - ") + rolledBookToTrack.Title)) != false)
        {
                val_13 = null;
            string val_5 = rolledBookToTrack.Author + " - "(" - ") + rolledBookToTrack.Title;
            TheLibraryLogic.debug_rolledBooks.set_Item(key:  val_5, value:  TheLibraryLogic.debug_rolledBooks.Item[val_5] + 1);
            return;
        }
        
        val_15 = null;
        TheLibraryLogic.debug_rolledBooks.Add(key:  rolledBookToTrack.Author + " - "(" - ") + rolledBookToTrack.Title, value:  1);
    }
    private static string SerializeBooksToSkuCount(System.Collections.Generic.List<BookInfo> booksToSerialize)
    {
        object val_8;
        var val_9;
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
        if(1152921513420107024 < 1)
        {
                return Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1, formatting:  0);
        }
        
        var val_8 = 0;
        if(1152921513420107024 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>()) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((System.String.IsNullOrEmpty(value:  public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>().__il2cppRuntimeField_10)) != false)
        {
                val_8 = System.String.Format(format:  "TheLibraryLogic.SerializeBooksToSkuCount: SKU null for book:`{0}`. This book will be lost, like... tears... in rain.", arg0:  public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>().__il2cppRuntimeField_20);
            UnityEngine.Debug.LogError(message:  val_8);
        }
        else
        {
                if(1152921515877766992 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = mem[public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>().__il2cppRuntimeField_20 + 16];
            val_8 = public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>().__il2cppRuntimeField_20 + 16;
            if((val_1.ContainsKey(key:  public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>().__il2cppRuntimeField_20 + 16)) != false)
        {
                if(W9 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_9 = mem[(public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>().__il2cppRuntimeField_20 + 0) + 32];
            val_9 = (public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>().__il2cppRuntimeField_20 + 0) + 32;
        }
        
            val_1.set_Item(key:  val_8, value:  (val_1.Item[(public UnityEngine.Transform UnityEngine.Component::GetComponent<UnityEngine.Transform>().__il2cppRuntimeField_20 + 0) + 32 + 16]) + 1);
        }
        else
        {
                val_1.Add(key:  val_8, value:  1);
        }
        
        }
        
        val_8 = val_8 + 1;
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1, formatting:  0);
    }
    private static System.Collections.Generic.List<BookInfo> DeserializeBooksFromSkuCount(string skuJson)
    {
        System.Collections.Generic.List<BookInfo> val_1 = new System.Collections.Generic.List<BookInfo>();
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_2 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.String, System.Int32>>(value:  skuJson);
        if(val_4.Length < 1)
        {
                return val_1;
        }
        
        var val_12 = 0;
        label_23:
        if((BookList.BookInfos.ContainsKey(key:  null)) == false)
        {
            goto label_10;
        }
        
        var val_11 = 0;
        label_18:
        val_11 = val_11 + 1;
        if(val_11 >= val_2.Item[null])
        {
            goto label_12;
        }
        
        val_1.Add(item:  BookList.BookInfos.Item[null]);
        if(val_12 < val_4.Length)
        {
            goto label_18;
        }
        
        label_10:
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "TheLibraryLogic.DeserializeBooksFromSkuCount: No known SKU matches SKU:`{0}`. This book will be lost, like... tears... in rain.", arg0:  null));
        label_12:
        val_12 = val_12 + 1;
        if(val_12 < val_4.Length)
        {
            goto label_23;
        }
        
        return val_1;
    }
    private static string SerializeBooksToSkuList(System.Collections.Generic.List<BookInfo> booksToSerialize)
    {
        object val_4;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        if(1152921509851217984 < 1)
        {
                return Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1, formatting:  0);
        }
        
        var val_4 = 0;
        do
        {
            if(1152921509851217984 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_4 = System.String.IsNullOrEmpty(value:  "big_quiz_reward".__il2cppRuntimeField_10);
            if("big_quiz_reward" <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_4 != false)
        {
                val_4 = System.String.Format(format:  "TheLibraryLogic.SerializeBooksToSkuList: SKU null for book:`{0}`. This book will be lost, like... tears... in rain.", arg0:  "big_quiz_reward".__il2cppRuntimeField_20);
            UnityEngine.Debug.LogError(message:  val_4);
        }
        else
        {
                val_1.Add(item:  "big_quiz_reward".__il2cppRuntimeField_20 + 16);
        }
        
            val_4 = val_4 + 1;
        }
        while(val_4 < 1152921515506388016);
        
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1, formatting:  0);
    }
    private static System.Collections.Generic.List<BookInfo> DeserializeBooksFromSkuList(string skuJson)
    {
        object val_8;
        System.Collections.Generic.List<BookInfo> val_1 = new System.Collections.Generic.List<BookInfo>();
        System.Collections.Generic.List<System.String> val_2 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  skuJson);
        if(1152921515619543488 < 1)
        {
                return val_1;
        }
        
        var val_10 = 4;
        do
        {
            var val_3 = val_10 - 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((BookList.BookInfos.ContainsKey(key:  BookList.__il2cppRuntimeField_cctor_finished + 32)) != false)
        {
                val_8 = BookList.BookInfos;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_1.Add(item:  val_8.Item[BookList.__il2cppRuntimeField_cctor_finished + 32]);
        }
        else
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_8 = System.String.Format(format:  "TheLibraryLogic.DeserializeBooksFromSkuList: No known SKU matches SKU:`{0}`. This book will be lost, like... tears... in rain.", arg0:  BookList.__il2cppRuntimeField_cctor_finished + 32);
            UnityEngine.Debug.LogError(message:  val_8);
        }
        
            val_10 = val_10 + 1;
        }
        while((val_10 - 3) < null);
        
        return val_1;
    }
    private static System.Collections.Generic.Queue<TheLibraryServerQueuedItem> get_QueuedItems()
    {
        System.Collections.Generic.Queue<TheLibraryServerQueuedItem> val_3;
        var val_4 = null;
        if(TheLibraryLogic._QueuedItems == null)
        {
                val_4 = null;
            val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Queue<TheLibraryServerQueuedItem>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "lib_svr_q", defaultValue:  "[]"));
            val_4 = null;
            TheLibraryLogic._QueuedItems = val_3;
        }
        
        val_4 = null;
        return (System.Collections.Generic.Queue<TheLibraryServerQueuedItem>)TheLibraryLogic._QueuedItems;
    }
    private static void EnqueuePost(TheLibraryServerQueuedItem item)
    {
        TheLibraryLogic.QueuedItems.Enqueue(item:  item);
        UnityEngine.PlayerPrefs.SetString(key:  "lib_svr_q", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  TheLibraryLogic.QueuedItems));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private static TheLibraryServerQueuedItem DequeuePost()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "lib_svr_q", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  TheLibraryLogic.QueuedItems));
        bool val_5 = PrefsSerializationManager.SavePlayerPrefs();
        return (TheLibraryServerQueuedItem)TheLibraryLogic.QueuedItems.Dequeue();
    }
    private static void PostAddedBookToServer(string sku, bool purchased)
    {
        TheLibraryLogic.EnqueuePost(item:  new TheLibraryServerQueuedItem(sku:  sku, purchased:  purchased));
        if(TheLibraryLogic.IsPosting != false)
        {
                return;
        }
        
        TheLibraryLogic.DoPostNextQueuedItem();
    }
    private static void PostAddedBookToServer(string[] skus, bool purchased)
    {
        .Skus = skus;
        .Purchased = purchased;
        TheLibraryLogic.EnqueuePost(item:  new TheLibraryServerQueuedItem());
        if(TheLibraryLogic.IsPosting != false)
        {
                return;
        }
        
        TheLibraryLogic.DoPostNextQueuedItem();
    }
    private static void DoPostToServer(string sku, bool purchased)
    {
        var val_6;
        var val_7;
        val_6 = null;
        val_6 = null;
        TheLibraryLogic.IsPosting = true;
        Player val_1 = App.Player;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "source", value:  (purchased != true) ? "purchased" : "completed");
        val_3.Add(key:  "sku", value:  sku);
        val_7 = null;
        val_7 = null;
        App.networkManager.DoPost(path:  System.String.Format(format:  "/api/word/libraries/{0}/skus", arg0:  val_1.id), postBody:  val_3, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  0, method:  static System.Void TheLibraryLogic::BookAddedServerResponse(string url, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private static void DoPostToServer(string[] skus, bool purchased)
    {
        var val_6;
        var val_7;
        val_6 = null;
        val_6 = null;
        TheLibraryLogic.IsPosting = true;
        Player val_1 = App.Player;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "source", value:  (purchased != true) ? "purchased" : "completed");
        val_3.Add(key:  "skus", value:  skus);
        val_7 = null;
        val_7 = null;
        App.networkManager.DoPost(path:  System.String.Format(format:  "/api/word/libraries/{0}/skus", arg0:  val_1.id), postBody:  val_3, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  0, method:  static System.Void TheLibraryLogic::BookAddedServerResponse(string url, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private static void BookAddedServerResponse(string url, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        if((response != null) && ((response.ContainsKey(key:  "success")) != false))
        {
                object val_2 = response.Item["success"];
            val_7 = 1152921504615792640;
            if(null != null)
        {
                object val_3 = response.Item["success"];
            if(null != null)
        {
                TheLibraryServerQueuedItem val_4 = TheLibraryLogic.DequeuePost();
        }
        
        }
        
        }
        
        System.Collections.Generic.Queue<TheLibraryServerQueuedItem> val_5 = TheLibraryLogic.QueuedItems;
        val_8 = null;
        val_8 = null;
        if(App.networkManager.Reachable() != false)
        {
                val_9 = null;
            val_9 = null;
            if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null)
        {
                TheLibraryLogic.DoPostNextQueuedItem();
            return;
        }
        
        }
        
        val_10 = null;
        val_10 = null;
        TheLibraryLogic.IsPosting = false;
    }
    private static void DoPostNextQueuedItem()
    {
        TheLibraryServerQueuedItem val_2 = TheLibraryLogic.QueuedItems.Peek();
        if(val_2.Skus.Length == 1)
        {
                TheLibraryLogic.DoPostToServer(sku:  val_2.Skus[0], purchased:  (val_2.Purchased == true) ? 1 : 0);
            return;
        }
        
        TheLibraryLogic.DoPostToServer(skus:  val_2.Skus, purchased:  (val_2.Purchased == true) ? 1 : 0);
    }
    private static void RequestPlayerBooksFromServer()
    {
        null = null;
        Player val_1 = App.Player;
        App.networkManager.DoGet(path:  System.String.Format(format:  "/api/word/libraries/{0}", arg0:  val_1.id), onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  0, method:  static System.Void TheLibraryLogic::PlayerBooksRequestServerResponse(string url, System.Collections.Generic.Dictionary<string, object> response)), destroy:  false, immediate:  false, getParams:  0, timeout:  20);
    }
    private static void PlayerBooksRequestServerResponse(string url, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_27;
        var val_28;
        var val_29;
        string val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_34;
        val_27 = response;
        if(val_27 == null)
        {
                return;
        }
        
        if((val_27.ContainsKey(key:  "success")) == false)
        {
                return;
        }
        
        object val_2 = val_27.Item["success"];
        if(0 != 3)
        {
                return;
        }
        
        if((val_27.ContainsKey(key:  "library")) == false)
        {
                return;
        }
        
        if(val_27.Item["library"] == null)
        {
                return;
        }
        
        object val_5 = val_27.Item["library"];
        val_27 = 0;
        System.Collections.Generic.List<BookInfo> val_6 = new System.Collections.Generic.List<BookInfo>();
        if((ContainsKey(key:  "completed")) != false)
        {
                string val_9 = Newtonsoft.Json.JsonConvert.SerializeObject(value:  Item["completed"]);
            val_28 = 1152921504898859008;
            val_29 = null;
            val_29 = null;
            TheLibraryLogic._SkusGrantedForCompletedBooks = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  val_9);
            val_6.AddRange(collection:  TheLibraryLogic.DeserializeBooksFromSkuList(skuJson:  val_9));
        }
        
        val_30 = "purchased";
        if((ContainsKey(key:  "purchased")) != false)
        {
                val_30 = Newtonsoft.Json.JsonConvert.SerializeObject(value:  Item["purchased"]);
            val_6.AddRange(collection:  TheLibraryLogic.DeserializeBooksFromSkuCount(skuJson:  val_30));
        }
        
        val_31 = null;
        val_31 = null;
        val_31 = null;
        val_32 = 1152921504898863168;
        TheLibraryLogic.playerBooks = val_6;
        val_31 = null;
        if((mem[1152921515880299960] == 0) && (TheLibraryLogic.MyEconVersion != 1))
        {
                System.Collections.Generic.List<System.String> val_17 = new System.Collections.Generic.List<System.String>();
            val_30 = App.Player;
            val_33 = null;
            val_28 = (ChapterBookLogic.GetCurrentBook(playerLevel:  val_30)) - 1;
            val_34 = (uint)(((uint)((TheLibraryLogic.__il2cppRuntimeField_12F>>1) & 0x1)) >> 1) & 1;
            if(val_28 >= 1)
        {
                var val_26 = 0;
            do
        {
            val_30 = TheLibraryLogic.GetRandomBook();
            val_6.Add(item:  val_30);
            val_17.Add(item:  val_20.SKU);
            val_33 = null;
            val_26 = val_26 + 1;
            val_34 = (uint)(((uint)((TheLibraryLogic.__il2cppRuntimeField_12F>>1) & 0x1)) >> 1) & 1;
        }
        while(val_26 < val_28);
        
        }
        
            TheLibraryLogic.MyEconVersion = 1;
            if(val_33 >= 1)
        {
                TheLibraryLogic.PostAddedBookToServer(skus:  val_17.ToArray(), purchased:  false);
        }
        
        }
        
        if((ContainsKey(key:  "current")) == false)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  Item["current"])) != false)
        {
                return;
        }
        
        TheLibraryLogic.CurrentBookUnlockTarget = Item["current"];
    }
    public static void PostCurrentUnlockTarget(string sku)
    {
        var val_5;
        Player val_1 = App.Player;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "sku", value:  sku);
        val_5 = null;
        val_5 = null;
        App.networkManager.DoPost(path:  System.String.Format(format:  "/api/word/libraries/{0}/current", arg0:  val_1.id), postBody:  val_3, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  0, method:  static System.Void TheLibraryLogic::PlayerBooksRequestServerResponse(string url, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    public TheLibraryLogic()
    {
    
    }
    private static TheLibraryLogic()
    {
        var val_9;
        var val_10;
        TheLibraryLogic.prefs_server_queue = 0;
        System.Collections.Generic.Dictionary<BookRarity, System.Int32> val_1 = new System.Collections.Generic.Dictionary<BookRarity, System.Int32>();
        val_1.Add(key:  0, value:  0);
        val_1.Add(key:  1, value:  0);
        val_1.Add(key:  2, value:  0);
        val_1.Add(key:  3, value:  0);
        TheLibraryLogic.debug_rolledRarities = val_1;
        TheLibraryLogic.debug_rolledBooks = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
        TheLibraryLogic.PurchasableRarityDispersion = new BookRarity[8];
        TheLibraryLogic.PurchasableBookRefreshTimeHours = 24;
        TheLibraryLogic.CategoryCompleteLibraryBonus = 500;
        System.Collections.Generic.Dictionary<BookRarity, BookEconInfo> val_4 = new System.Collections.Generic.Dictionary<BookRarity, BookEconInfo>();
        val_4.Add(key:  0, value:  new BookEconInfo(rarity:  0, libraryValue:  25, goldenAppleCost:  100, freeBookChance:  56));
        val_4.Add(key:  1, value:  new BookEconInfo(rarity:  1, libraryValue:  50, goldenAppleCost:  94, freeBookChance:  27));
        val_4.Add(key:  2, value:  new BookEconInfo(rarity:  2, libraryValue:  100, goldenAppleCost:  220, freeBookChance:  12));
        val_4.Add(key:  3, value:  new BookEconInfo(rarity:  3, libraryValue:  250, goldenAppleCost:  124, freeBookChance:  5));
        val_9 = null;
        TheLibraryLogic.BookEcon = val_4;
        TheLibraryLogic.BookPackGemCost = 5;
        TheLibraryLogic.BookPackBookCount = 5;
        TheLibraryLogic._MyEconVersion = 0;
        TheLibraryLogic._LastGrantedBook = 0;
        val_10 = null;
        val_10 = null;
        val_9 = 1152921504898859192;
        TheLibraryLogic._LastPurchasableRefreshDate = System.DateTime.MinValue;
        TheLibraryLogic.TL_Version = 2;
        TheLibraryLogic._LifetimeBookPacksPurchased = 0;
        TheLibraryLogic._LifetimeBooksPurchasedInPacks = 0;
        TheLibraryLogic.lastBookCount = 0;
        TheLibraryLogic.completedCollectionCount = 0;
        TheLibraryLogic.IsPosting = false;
    }

}
