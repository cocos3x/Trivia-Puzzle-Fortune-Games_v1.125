using UnityEngine;
public class ChapterBookLogic : MonoSingleton<ChapterBookLogic>
{
    // Fields
    private static System.Collections.Generic.List<System.Collections.Generic.List<int>> EarlyLevelChapterBooks;
    private const int early_list_index_level = 0;
    private const int early_list_index_chapter = 1;
    private const int early_list_index_book = 2;
    public static int _ChaptersPerBook;
    public static int _LevelsPerChapter;
    
    // Methods
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
        WADChapterManager val_1 = MonoSingletonSelfGenerating<WADChapterManager>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnLevelCompleted, b:  new System.Action(object:  this, method:  System.Void ChapterBookLogic::HandleLevelCompleted()));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnLevelCompleted = val_3;
        return;
        label_5:
    }
    public static bool ShowBookComplete(int playerLevel = -1)
    {
        int val_4 = playerLevel;
        if(val_4 > 0)
        {
                return (bool)((ChapterBookLogic.GetFirstLevelOfBook(playerLevel:  val_4 = App.Player)) == val_4) ? 1 : 0;
        }
        
        return (bool)((ChapterBookLogic.GetFirstLevelOfBook(playerLevel:  val_4)) == val_4) ? 1 : 0;
    }
    public static bool ShowBookIntro(int playerLevel = -1)
    {
        int val_5 = playerLevel;
        if(val_5 > 0)
        {
                return (bool)((ChapterBookLogic.GetFirstLevelOfBook(playerLevel:  val_5 = App.Player)) == (val_5 - 1)) ? 1 : 0;
        }
        
        return (bool)((ChapterBookLogic.GetFirstLevelOfBook(playerLevel:  val_5)) == (val_5 - 1)) ? 1 : 0;
    }
    public static bool ShowChapterComplete(int playerLevel = -1)
    {
        int val_4 = playerLevel;
        if(val_4 > 0)
        {
                return (bool)((ChapterBookLogic.GetFirstLevelOfChapter(playerLevel:  val_4 = App.Player)) == val_4) ? 1 : 0;
        }
        
        return (bool)((ChapterBookLogic.GetFirstLevelOfChapter(playerLevel:  val_4)) == val_4) ? 1 : 0;
    }
    public static int GetCurrentBook(int playerLevel = -1)
    {
        int val_9;
        var val_10;
        var val_11;
        int val_13;
        int val_14;
        var val_15;
        var val_16;
        int val_17;
        val_9 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetCurrentBook(playerLevel:  val_9);
        }
        
        if(val_9 <= 0)
        {
                val_9 = App.Player;
        }
        
        val_10 = 1152921504898539520;
        val_11 = null;
        val_11 = null;
        val_13 = ChapterBookLogic.early_list_index_book;
        if(val_9 < (ChapterBookLogic.early_list_index_book + 24))
        {
                val_14 = ChapterBookLogic.early_list_index_book;
            if((ChapterBookLogic.early_list_index_book + 24) <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_7 = ChapterBookLogic.early_list_index_book + 16;
            val_7 = val_7 + (val_9 << 3);
            val_15 = mem[(ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32];
            val_15 = (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32;
            if(((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_16 = mem[(ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40];
            val_16 = (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40;
            return (int)val_16;
        }
        
        val_17 = ChapterBookLogic.early_list_index_book;
        Player val_4 = val_9 + 1;
        val_4 = val_4 - (ChapterBookLogic.early_list_index_book + 24);
        float val_8 = (float)val_4;
        val_8 = val_8 / ((float)(ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_9)) * ChapterBookLogic._ChaptersPerBook);
        val_15 = UnityEngine.Mathf.FloorToInt(f:  val_8);
        val_10 = (ChapterBookLogic.early_list_index_book + 24) - 1;
        if((ChapterBookLogic.early_list_index_book + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_9 = ChapterBookLogic.early_list_index_book + 16;
        val_9 = val_9 + (val_10 << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 24 - 1)) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_10 = (ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 24 - 1)) << 3) + 32 + 16 + 40;
        val_10 = val_15 + val_10;
        val_16 = val_10 + 1;
        return (int)val_16;
    }
    public static int GetFirstLevelOfBook(int playerLevel = -1)
    {
        int val_9;
        var val_10;
        var val_11;
        int val_13;
        int val_14;
        var val_15;
        var val_16;
        var val_17;
        int val_18;
        val_9 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetFirstLevelOfBook(playerLevel:  val_9);
        }
        
        if(val_9 <= 0)
        {
                val_9 = App.Player;
        }
        
        val_10 = 1152921504898539520;
        val_11 = null;
        val_11 = null;
        val_13 = ChapterBookLogic.early_list_index_book;
        if(val_9 >= (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_15;
        }
        
        val_14 = ChapterBookLogic.early_list_index_book;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_9 = ChapterBookLogic.early_list_index_book + 16;
        val_9 = val_9 + (val_9 << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_15 = 0;
        goto label_22;
        label_33:
        if((ChapterBookLogic.early_list_index_book + 24) <= val_15)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_10 = ChapterBookLogic.early_list_index_book + 16;
        val_10 = val_10 + 0;
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40) == ((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40))
        {
                return (int)val_17;
        }
        
        val_15 = 1;
        label_22:
        val_16 = null;
        val_16 = null;
        if(val_15 < (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_33;
        }
        
        val_17 = 0;
        return (int)val_17;
        label_15:
        val_18 = ChapterBookLogic.early_list_index_book;
        float val_11 = (float)val_9 - (ChapterBookLogic.early_list_index_book + 24);
        val_11 = val_11 / ((float)(ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_9)) * ChapterBookLogic._ChaptersPerBook);
        val_10 = mem[ChapterBookLogic.early_list_index_book + 24];
        val_10 = ChapterBookLogic.early_list_index_book + 24;
        val_17 = val_10 + ((ChapterBookLogic._ChaptersPerBook * (UnityEngine.Mathf.FloorToInt(f:  val_11))) * (ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_9)));
        return (int)val_17;
    }
    public static int GetFirstLevelOfSecondBook()
    {
        var val_2;
        var val_3;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetFirstLevelOfSecondBook();
        }
        
        val_2 = 0;
        goto label_8;
        label_19:
        if((ChapterBookLogic.early_list_index_book + 24) <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_2 = ChapterBookLogic.early_list_index_book + 16;
        val_2 = val_2 + 0;
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40) == 2)
        {
                return 1;
        }
        
        val_2 = 1;
        label_8:
        val_3 = null;
        val_3 = null;
        if(val_2 < (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_19;
        }
        
        return 1;
    }
    public static int GetCurrentChapter(int playerLevel = -1)
    {
        int val_7;
        var val_8;
        int val_9;
        var val_10;
        val_7 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetCurrentChapter(playerLevel:  val_7);
        }
        
        if(val_7 <= 0)
        {
                val_7 = App.Player;
        }
        
        val_8 = null;
        val_8 = null;
        val_9 = ChapterBookLogic.early_list_index_book;
        if(val_7 < (ChapterBookLogic.early_list_index_book + 24))
        {
                val_9 = ChapterBookLogic.early_list_index_book;
            if((ChapterBookLogic.early_list_index_book + 24) <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_7 = ChapterBookLogic.early_list_index_book + 16;
            val_7 = val_7 + (val_7 << 3);
            val_7 = mem[(ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32];
            val_7 = (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32;
            if(((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_10 = mem[(ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 36];
            val_10 = (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 36;
            return (int)val_10;
        }
        
        float val_8 = (float)val_7 - (ChapterBookLogic.GetFirstLevelOfBook(playerLevel:  val_7));
        val_8 = val_8 / ((float)ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_7));
        val_10 = (UnityEngine.Mathf.FloorToInt(f:  val_8)) + 1;
        return (int)val_10;
    }
    public static int GetCurrentCumulativeChapter(int playerLevel = -1)
    {
        int val_9;
        var val_10;
        var val_11;
        val_9 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetCurrentCumulativeChapter(playerLevel:  val_9);
        }
        
        if(val_9 <= 0)
        {
                val_9 = App.Player;
        }
        
        val_10 = null;
        int val_4 = (ChapterBookLogic.GetCurrentBook(playerLevel:  val_9)) - 1;
        var val_5 = ((ChapterBookLogic.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
        if(val_4 >= 1)
        {
                var val_9 = 1;
            do
        {
            val_10 = null;
            val_9 = val_9 + 1;
            val_11 = (ChapterBookLogic.GetChaptersFromBook(bookNum:  1)) + 0;
            var val_7 = ((ChapterBookLogic.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
        }
        while(val_9 <= val_4);
        
        }
        else
        {
                val_11 = 0;
        }
        
        int val_8 = ChapterBookLogic.GetCurrentChapter(playerLevel:  val_9);
        val_8 = val_8 + val_11;
        return (int)val_8;
    }
    public static int GetFirstLevelOfChapter(int playerLevel = -1)
    {
        int val_7;
        var val_8;
        int val_9;
        var val_10;
        var val_11;
        var val_12;
        int val_13;
        var val_14;
        var val_15;
        val_7 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetFirstLevelOfChapter(playerLevel:  val_7);
        }
        
        if(val_7 <= 0)
        {
                val_7 = App.Player;
        }
        
        val_8 = null;
        val_8 = null;
        val_9 = ChapterBookLogic.early_list_index_book;
        if(val_7 >= (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_15;
        }
        
        val_9 = ChapterBookLogic.early_list_index_book;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_6 = ChapterBookLogic.early_list_index_book + 16;
        val_6 = val_6 + (val_7 << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = mem[(ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40];
        val_10 = (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_7 = ChapterBookLogic.early_list_index_book + 16;
        val_7 = val_7 + (((long)(int)(val_2)) << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_2)) << 3) + 32 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_11 = 0;
        goto label_26;
        label_44:
        if((ChapterBookLogic.early_list_index_book + 24) <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_8 = ChapterBookLogic.early_list_index_book + 16;
        val_8 = val_8 + 0;
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40) == val_10)
        {
                val_12 = null;
            val_12 = null;
            if((ChapterBookLogic.early_list_index_book + 24) <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_9 = ChapterBookLogic.early_list_index_book + 16;
            val_9 = val_9 + 0;
            val_13 = mem[(ChapterBookLogic.early_list_index_book + 16 + 0) + 32];
            val_13 = (ChapterBookLogic.early_list_index_book + 16 + 0) + 32;
            if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 36) == ((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_2)) << 3) + 32 + 16 + 36))
        {
                return (int)val_15;
        }
        
        }
        
        val_11 = 1;
        label_26:
        val_14 = null;
        val_14 = null;
        val_13 = ChapterBookLogic.early_list_index_book;
        if(val_11 < (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_44;
        }
        
        val_15 = 0;
        return (int)val_15;
        label_15:
        val_10 = (ChapterBookLogic.GetCurrentChapter(playerLevel:  val_7)) - 1;
        val_15 = (ChapterBookLogic.GetFirstLevelOfBook(playerLevel:  val_7)) + ((ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_7)) * val_10);
        return (int)val_15;
    }
    public static int GetLastLevelOfChapter(int playerLevel = -1)
    {
        int val_6 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetLastLevelOfChapter(playerLevel:  val_6 = playerLevel);
        }
        
        if(val_6 <= 0)
        {
                val_6 = App.Player;
        }
        
        int val_4 = ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_6);
        val_4 = ((ChapterBookLogic.GetFirstLevelOfChapter(playerLevel:  val_6)) + val_4) - 1;
        return (int)val_4;
    }
    public static int GetLevelWithinChapter(int playerLevel = -1)
    {
        int val_5 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetLevelWithinChapter(playerLevel:  val_5 = playerLevel);
        }
        
        if(val_5 <= 0)
        {
                val_5 = App.Player;
        }
        
        int val_3 = ChapterBookLogic.GetFirstLevelOfChapter(playerLevel:  val_5);
        val_3 = (val_5 + 1) - val_3;
        return (int)val_3;
    }
    public static int GetChaptersPerBook(int playerLevel = -1)
    {
        var val_4;
        int val_5;
        var val_6;
        int val_8;
        int val_9;
        var val_10;
        var val_11;
        var val_12;
        int val_13;
        int val_14;
        var val_15;
        var val_16;
        val_4 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_5 = 4;
            return val_5;
        }
        
        if(val_4 <= 0)
        {
                val_4 = App.Player;
        }
        
        val_6 = null;
        val_6 = null;
        val_8 = ChapterBookLogic.early_list_index_book;
        if(val_4 >= (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_14;
        }
        
        val_9 = ChapterBookLogic.early_list_index_book;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_4 = ChapterBookLogic.early_list_index_book + 16;
        val_4 = val_4 + (val_4 << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = 0;
        val_11 = 0;
        label_37:
        val_12 = null;
        val_12 = null;
        val_13 = ChapterBookLogic.early_list_index_book;
        if(val_10 >= (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_24;
        }
        
        val_14 = ChapterBookLogic.early_list_index_book;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = ChapterBookLogic.early_list_index_book + 16;
        val_5 = val_5 + 0;
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_15 = null;
        var val_3 = (((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40) == ((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40)) ? (val_10) : (val_11);
        val_15 = null;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_6 = ChapterBookLogic.early_list_index_book + 16;
        val_6 = val_6 + 0;
        val_16 = mem[(ChapterBookLogic.early_list_index_book + 16 + 0) + 32];
        val_16 = (ChapterBookLogic.early_list_index_book + 16 + 0) + 32;
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + 1;
        if(((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40) <= ((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40))
        {
            goto label_37;
        }
        
        val_12 = null;
        label_24:
        val_12 = null;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_7 = ChapterBookLogic.early_list_index_book + 16;
        val_7 = val_7 + (val_3 << 3);
        val_4 = mem[(ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40 == (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40 ? val_10 + 32];
        val_4 = (ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40 == (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40 ? val_10 + 32;
        if(((ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40 == (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40 ? val_10 + 32 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = mem[(ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40 == (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40 ? val_10 + 32 + 16 + 36];
        val_5 = (ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 16 + 0) + 32 + 16 + 40 == (ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40 ? val_10 + 32 + 16 + 36;
        return val_5;
        label_14:
        val_5 = ChapterBookLogic._ChaptersPerBook;
        return val_5;
    }
    public static int GetChaptersFromBook(int bookNum)
    {
        object val_7;
        int val_8;
        var val_9;
        System.Predicate<T> val_10;
        var val_11;
        var val_12;
        var val_13;
        ChapterBookLogic.<>c__DisplayClass19_0 val_1 = null;
        val_7 = val_1;
        val_1 = new ChapterBookLogic.<>c__DisplayClass19_0();
        .bookNum = bookNum;
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_8 = 4;
            return val_8;
        }
        
        val_9 = null;
        val_9 = null;
        System.Predicate<System.Collections.Generic.List<System.Int32>> val_3 = null;
        val_10 = val_3;
        val_3 = new System.Predicate<System.Collections.Generic.List<System.Int32>>(object:  val_1, method:  System.Boolean ChapterBookLogic.<>c__DisplayClass19_0::<GetChaptersFromBook>b__0(System.Collections.Generic.List<int> v));
        val_11 = null;
        if((ChapterBookLogic.early_list_index_book.Exists(match:  val_3)) != false)
        {
                val_12 = null;
            System.Predicate<System.Collections.Generic.List<System.Int32>> val_5 = null;
            val_10 = val_5;
            val_5 = new System.Predicate<System.Collections.Generic.List<System.Int32>>(object:  val_1, method:  System.Boolean ChapterBookLogic.<>c__DisplayClass19_0::<GetChaptersFromBook>b__1(System.Collections.Generic.List<int> v));
            int val_6 = ChapterBookLogic.early_list_index_book.FindLastIndex(match:  val_5);
            if((ChapterBookLogic.early_list_index_book + 24) <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_7 = ChapterBookLogic.early_list_index_book + 16;
            val_7 = val_7 + (val_6 << 3);
            val_7 = mem[(ChapterBookLogic.early_list_index_book + 16 + (val_6) << 3) + 32];
            val_7 = (ChapterBookLogic.early_list_index_book + 16 + (val_6) << 3) + 32;
            if(((ChapterBookLogic.early_list_index_book + 16 + (val_6) << 3) + 32 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = mem[(ChapterBookLogic.early_list_index_book + 16 + (val_6) << 3) + 32 + 16 + 36];
            val_8 = (ChapterBookLogic.early_list_index_book + 16 + (val_6) << 3) + 32 + 16 + 36;
            return val_8;
        }
        
        val_13 = null;
        val_8 = ChapterBookLogic._ChaptersPerBook;
        return val_8;
    }
    public static int GetLevelsPerChapter(int playerLevel = -1)
    {
        int val_4;
        var val_5;
        int val_7;
        var val_8;
        int val_9;
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        val_4 = playerLevel;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetLevelsPerChapter(playerLevel:  val_4);
        }
        
        if(val_4 <= 0)
        {
                val_4 = App.Player;
        }
        
        val_5 = null;
        val_5 = null;
        val_7 = ChapterBookLogic.early_list_index_book;
        if(val_4 >= (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_15;
        }
        
        val_7 = ChapterBookLogic.early_list_index_book;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_4 = ChapterBookLogic.early_list_index_book + 16;
        val_4 = val_4 + (val_4 << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((ChapterBookLogic.early_list_index_book + 24) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = ChapterBookLogic.early_list_index_book + 16;
        val_5 = val_5 + (((long)(int)(val_2)) << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_2)) << 3) + 32 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = ChapterBookLogic.GetFirstLevelOfBook(playerLevel:  val_4);
        val_9 = 0;
        goto label_26;
        label_59:
        if((ChapterBookLogic.early_list_index_book + 24) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_6 = ChapterBookLogic.early_list_index_book + 16;
        val_6 = val_6 + (val_8 << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + (val_3) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((ChapterBookLogic.early_list_index_book + 16 + (val_3) << 3) + 32 + 16 + 40) != ((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40))
        {
            goto label_40;
        }
        
        val_10 = null;
        val_10 = null;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_7 = ChapterBookLogic.early_list_index_book + 16;
        val_7 = val_7 + (((long)(int)(val_3)) << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_3)) << 3) + 32 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_3)) << 3) + 32 + 16 + 36) != ((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_2)) << 3) + 32 + 16 + 36))
        {
            goto label_40;
        }
        
        val_9 = 1;
        goto label_41;
        label_40:
        val_11 = null;
        val_11 = null;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_8 = ChapterBookLogic.early_list_index_book + 16;
        val_8 = val_8 + (((long)(int)(val_3)) << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_3)) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_3)) << 3) + 32 + 16 + 40) > ((ChapterBookLogic.early_list_index_book + 16 + (val_2) << 3) + 32 + 16 + 40))
        {
                return val_9;
        }
        
        val_12 = null;
        val_12 = null;
        if((ChapterBookLogic.early_list_index_book + 24) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_9 = ChapterBookLogic.early_list_index_book + 16;
        val_9 = val_9 + (((long)(int)(val_3)) << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_3)) << 3) + 32 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_3)) << 3) + 32 + 16 + 36) > ((ChapterBookLogic.early_list_index_book + 16 + ((long)(int)(val_2)) << 3) + 32 + 16 + 36))
        {
                return val_9;
        }
        
        label_41:
        val_8 = val_8 + 1;
        label_26:
        val_13 = null;
        val_13 = null;
        if(val_8 < (ChapterBookLogic.early_list_index_book + 24))
        {
            goto label_59;
        }
        
        return val_9;
        label_15:
        val_9 = ChapterBookLogic._LevelsPerChapter;
        return val_9;
    }
    public static int GetLevelsPerChapter(int book, int chapter)
    {
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        .book = book;
        .chapter = chapter;
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return WordLevelGen.GetLevelsForChapter(chapter:  (((ChapterBookLogic.<>c__DisplayClass21_0)[1152921515867678192].chapter) + (((ChapterBookLogic.<>c__DisplayClass21_0)[1152921515867678192].book) << 2)) - 4);
        }
        
        val_7 = null;
        val_7 = null;
        if((ChapterBookLogic.early_list_index_book + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_7 = ChapterBookLogic.early_list_index_book + 16;
        val_7 = val_7 + (((ChapterBookLogic.early_list_index_book + 24) - 1) << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 24 - 1)) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = null;
        if(((ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 24 - 1)) << 3) + 32 + 16 + 40) < ((ChapterBookLogic.<>c__DisplayClass21_0)[1152921515867678192].book))
        {
                val_9 = null;
            return (int)ChapterBookLogic._LevelsPerChapter;
        }
        
        val_10 = null;
        return System.Linq.Enumerable.Count<System.Collections.Generic.List<System.Int32>>(source:  ChapterBookLogic.early_list_index_book, predicate:  new System.Func<System.Collections.Generic.List<System.Int32>, System.Boolean>(object:  new ChapterBookLogic.<>c__DisplayClass21_0(), method:  System.Boolean ChapterBookLogic.<>c__DisplayClass21_0::<GetLevelsPerChapter>b__0(System.Collections.Generic.List<int> p)));
    }
    public static int GetCumulativeLevelFromBookAndChapter(int book, int chapter, int levelInChapterIndex)
    {
        int val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        int val_20;
        var val_21;
        var val_22;
        .book = book;
        .chapter = chapter;
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_14 = (ChapterBookLogic.<>c__DisplayClass22_0)[1152921515867825008].book;
            int val_3 = ((ChapterBookLogic.<>c__DisplayClass22_0)[1152921515867825008].chapter) + (val_14 << 2);
            val_3 = levelInChapterIndex + (WordLevelGen.GetLevelsThroughChapter(chapter:  val_3 - 5));
            val_15 = val_3 + 1;
            return (int)val_15;
        }
        
        val_16 = null;
        val_16 = null;
        if((ChapterBookLogic.early_list_index_book + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_13 = ChapterBookLogic.early_list_index_book + 16;
        val_13 = val_13 + (((ChapterBookLogic.early_list_index_book + 24) - 1) << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 24 - 1)) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_17 = null;
        if(((ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 24 - 1)) << 3) + 32 + 16 + 40) >= ((ChapterBookLogic.<>c__DisplayClass22_0)[1152921515867825008].book))
        {
            goto label_16;
        }
        
        val_18 = null;
        val_19 = mem[ChapterBookLogic.early_list_index_book + 24];
        val_19 = ChapterBookLogic.early_list_index_book + 24;
        if(val_19 == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_14 = ChapterBookLogic.early_list_index_book + 16;
        val_14 = val_14 + ((val_19 - 1) << 3);
        if(((ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 24 - 1)) << 3) + 32 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = (ChapterBookLogic.<>c__DisplayClass22_0)[1152921515867825008].book;
        val_14 = ((ChapterBookLogic.early_list_index_book + 16 + ((ChapterBookLogic.early_list_index_book + 24 - 1)) << 3) + 32 + 16 + 40) + 1;
        goto label_23;
        label_30:
        val_21 = 0;
        goto label_24;
        label_29:
        val_19 = (ChapterBookLogic.GetLevelsPerChapter(book:  val_14, chapter:  0)) + val_19;
        val_21 = 1;
        label_24:
        if(val_21 < (ChapterBookLogic.GetChaptersFromBook(bookNum:  val_14)))
        {
            goto label_29;
        }
        
        val_20 = (ChapterBookLogic.<>c__DisplayClass22_0)[1152921515867825008].book;
        val_14 = val_14 + 1;
        label_23:
        if(val_14 < val_20)
        {
            goto label_30;
        }
        
        int val_15 = (ChapterBookLogic.<>c__DisplayClass22_0)[1152921515867825008].chapter;
        val_15 = val_15 - 1;
        if(val_15 < 1)
        {
            goto label_31;
        }
        
        goto label_32;
        label_35:
        val_20 = (ChapterBookLogic.<>c__DisplayClass22_0)[1152921515867825008].book;
        label_32:
        int val_16 = (ChapterBookLogic.<>c__DisplayClass22_0)[1152921515867825008].chapter;
        val_14 = 0 + 1;
        val_19 = (ChapterBookLogic.GetLevelsPerChapter(book:  val_20, chapter:  0)) + val_19;
        val_16 = val_16 - 1;
        if(val_14 < val_16)
        {
            goto label_35;
        }
        
        label_31:
        val_15 = val_19 + levelInChapterIndex;
        return (int)val_15;
        label_16:
        val_22 = null;
        val_14 = ChapterBookLogic.early_list_index_book;
        val_15 = (val_14.FindIndex(match:  new System.Predicate<System.Collections.Generic.List<System.Int32>>(object:  new ChapterBookLogic.<>c__DisplayClass22_0(), method:  System.Boolean ChapterBookLogic.<>c__DisplayClass22_0::<GetCumulativeLevelFromBookAndChapter>b__0(System.Collections.Generic.List<int> p)))) + levelInChapterIndex;
        return (int)val_15;
    }
    private void HandleLevelCompleted()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((ChapterBookLogic.ShowBookComplete(playerLevel:  App.Player)) == false)
        {
                return;
        }
        
        TheLibraryLogic.GrantTargetBook();
    }
    public ChapterBookLogic()
    {
    
    }
    private static ChapterBookLogic()
    {
        System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>>();
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(item:  0);
        val_2.Add(item:  0);
        val_2.Add(item:  0);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_2);
        System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.Add(item:  1);
        val_3.Add(item:  1);
        val_3.Add(item:  1);
        val_1.Add(item:  val_3);
        System.Collections.Generic.List<System.Int32> val_4 = new System.Collections.Generic.List<System.Int32>();
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_4.Add(item:  2);
        val_4.Add(item:  1);
        val_4.Add(item:  1);
        val_1.Add(item:  val_4);
        System.Collections.Generic.List<System.Int32> val_5 = new System.Collections.Generic.List<System.Int32>();
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_5.Add(item:  3);
        val_5.Add(item:  1);
        val_5.Add(item:  1);
        val_1.Add(item:  val_5);
        System.Collections.Generic.List<System.Int32> val_6 = new System.Collections.Generic.List<System.Int32>();
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6.Add(item:  4);
        val_6.Add(item:  1);
        val_6.Add(item:  1);
        val_1.Add(item:  val_6);
        System.Collections.Generic.List<System.Int32> val_7 = new System.Collections.Generic.List<System.Int32>();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_7.Add(item:  5);
        val_7.Add(item:  1);
        val_7.Add(item:  1);
        val_1.Add(item:  val_7);
        System.Collections.Generic.List<System.Int32> val_8 = new System.Collections.Generic.List<System.Int32>();
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.Add(item:  6);
        val_8.Add(item:  2);
        val_8.Add(item:  1);
        val_1.Add(item:  val_8);
        System.Collections.Generic.List<System.Int32> val_9 = new System.Collections.Generic.List<System.Int32>();
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9.Add(item:  7);
        val_9.Add(item:  2);
        val_9.Add(item:  1);
        val_1.Add(item:  val_9);
        System.Collections.Generic.List<System.Int32> val_10 = new System.Collections.Generic.List<System.Int32>();
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Add(item:  8);
        val_10.Add(item:  2);
        val_10.Add(item:  1);
        val_1.Add(item:  val_10);
        System.Collections.Generic.List<System.Int32> val_11 = new System.Collections.Generic.List<System.Int32>();
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.Add(item:  9);
        val_11.Add(item:  2);
        val_11.Add(item:  1);
        val_1.Add(item:  val_11);
        System.Collections.Generic.List<System.Int32> val_12 = new System.Collections.Generic.List<System.Int32>();
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.Add(item:  10);
        val_12.Add(item:  2);
        val_12.Add(item:  1);
        val_1.Add(item:  val_12);
        System.Collections.Generic.List<System.Int32> val_13 = new System.Collections.Generic.List<System.Int32>();
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13.Add(item:  11);
        val_13.Add(item:  3);
        val_13.Add(item:  1);
        val_1.Add(item:  val_13);
        System.Collections.Generic.List<System.Int32> val_14 = new System.Collections.Generic.List<System.Int32>();
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.Add(item:  12);
        val_14.Add(item:  3);
        val_14.Add(item:  1);
        val_1.Add(item:  val_14);
        System.Collections.Generic.List<System.Int32> val_15 = new System.Collections.Generic.List<System.Int32>();
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15.Add(item:  13);
        val_15.Add(item:  3);
        val_15.Add(item:  1);
        val_1.Add(item:  val_15);
        System.Collections.Generic.List<System.Int32> val_16 = new System.Collections.Generic.List<System.Int32>();
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        val_16.Add(item:  14);
        val_16.Add(item:  3);
        val_16.Add(item:  1);
        val_1.Add(item:  val_16);
        System.Collections.Generic.List<System.Int32> val_17 = new System.Collections.Generic.List<System.Int32>();
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17.Add(item:  15);
        val_17.Add(item:  3);
        val_17.Add(item:  1);
        val_1.Add(item:  val_17);
        System.Collections.Generic.List<System.Int32> val_18 = new System.Collections.Generic.List<System.Int32>();
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18.Add(item:  16);
        val_18.Add(item:  1);
        val_18.Add(item:  2);
        val_1.Add(item:  val_18);
        System.Collections.Generic.List<System.Int32> val_19 = new System.Collections.Generic.List<System.Int32>();
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(item:  17);
        val_19.Add(item:  1);
        val_19.Add(item:  2);
        val_1.Add(item:  val_19);
        System.Collections.Generic.List<System.Int32> val_20 = new System.Collections.Generic.List<System.Int32>();
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20.Add(item:  18);
        val_20.Add(item:  1);
        val_20.Add(item:  2);
        val_1.Add(item:  val_20);
        System.Collections.Generic.List<System.Int32> val_21 = new System.Collections.Generic.List<System.Int32>();
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21.Add(item:  19);
        val_21.Add(item:  1);
        val_21.Add(item:  2);
        val_1.Add(item:  val_21);
        System.Collections.Generic.List<System.Int32> val_22 = new System.Collections.Generic.List<System.Int32>();
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22.Add(item:  20);
        val_22.Add(item:  1);
        val_22.Add(item:  2);
        val_1.Add(item:  val_22);
        System.Collections.Generic.List<System.Int32> val_23 = new System.Collections.Generic.List<System.Int32>();
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_23.Add(item:  21);
        val_23.Add(item:  2);
        val_23.Add(item:  2);
        val_1.Add(item:  val_23);
        System.Collections.Generic.List<System.Int32> val_24 = new System.Collections.Generic.List<System.Int32>();
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24.Add(item:  22);
        val_24.Add(item:  2);
        val_24.Add(item:  2);
        val_1.Add(item:  val_24);
        System.Collections.Generic.List<System.Int32> val_25 = new System.Collections.Generic.List<System.Int32>();
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        val_25.Add(item:  23);
        val_25.Add(item:  2);
        val_25.Add(item:  2);
        val_1.Add(item:  val_25);
        System.Collections.Generic.List<System.Int32> val_26 = new System.Collections.Generic.List<System.Int32>();
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.Add(item:  24);
        val_26.Add(item:  2);
        val_26.Add(item:  2);
        val_1.Add(item:  val_26);
        System.Collections.Generic.List<System.Int32> val_27 = new System.Collections.Generic.List<System.Int32>();
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_27.Add(item:  25);
        val_27.Add(item:  2);
        val_27.Add(item:  2);
        val_1.Add(item:  val_27);
        System.Collections.Generic.List<System.Int32> val_28 = new System.Collections.Generic.List<System.Int32>();
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28.Add(item:  26);
        val_28.Add(item:  3);
        val_28.Add(item:  2);
        val_1.Add(item:  val_28);
        System.Collections.Generic.List<System.Int32> val_29 = new System.Collections.Generic.List<System.Int32>();
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_29.Add(item:  27);
        val_29.Add(item:  3);
        val_29.Add(item:  2);
        val_1.Add(item:  val_29);
        System.Collections.Generic.List<System.Int32> val_30 = new System.Collections.Generic.List<System.Int32>();
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        val_30.Add(item:  28);
        val_30.Add(item:  3);
        val_30.Add(item:  2);
        val_1.Add(item:  val_30);
        System.Collections.Generic.List<System.Int32> val_31 = new System.Collections.Generic.List<System.Int32>();
        if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
        val_31.Add(item:  29);
        val_31.Add(item:  3);
        val_31.Add(item:  2);
        val_1.Add(item:  val_31);
        System.Collections.Generic.List<System.Int32> val_32 = new System.Collections.Generic.List<System.Int32>();
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        val_32.Add(item:  30);
        val_32.Add(item:  3);
        val_32.Add(item:  2);
        val_1.Add(item:  val_32);
        System.Collections.Generic.List<System.Int32> val_33 = new System.Collections.Generic.List<System.Int32>();
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        val_33.Add(item:  31);
        val_33.Add(item:  3);
        val_33.Add(item:  2);
        val_1.Add(item:  val_33);
        System.Collections.Generic.List<System.Int32> val_34 = new System.Collections.Generic.List<System.Int32>();
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34.Add(item:  32);
        val_34.Add(item:  3);
        val_34.Add(item:  2);
        val_1.Add(item:  val_34);
        System.Collections.Generic.List<System.Int32> val_35 = new System.Collections.Generic.List<System.Int32>();
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35.Add(item:  33);
        val_35.Add(item:  3);
        val_35.Add(item:  2);
        val_1.Add(item:  val_35);
        System.Collections.Generic.List<System.Int32> val_36 = new System.Collections.Generic.List<System.Int32>();
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36.Add(item:  34);
        val_36.Add(item:  3);
        val_36.Add(item:  2);
        val_1.Add(item:  val_36);
        System.Collections.Generic.List<System.Int32> val_37 = new System.Collections.Generic.List<System.Int32>();
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37.Add(item:  35);
        val_37.Add(item:  3);
        val_37.Add(item:  2);
        val_1.Add(item:  val_37);
        System.Collections.Generic.List<System.Int32> val_38 = new System.Collections.Generic.List<System.Int32>();
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        val_38.Add(item:  36);
        val_38.Add(item:  1);
        val_38.Add(item:  3);
        val_1.Add(item:  val_38);
        System.Collections.Generic.List<System.Int32> val_39 = new System.Collections.Generic.List<System.Int32>();
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        val_39.Add(item:  37);
        val_39.Add(item:  1);
        val_39.Add(item:  3);
        val_1.Add(item:  val_39);
        System.Collections.Generic.List<System.Int32> val_40 = new System.Collections.Generic.List<System.Int32>();
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        val_40.Add(item:  38);
        val_40.Add(item:  1);
        val_40.Add(item:  3);
        val_1.Add(item:  val_40);
        System.Collections.Generic.List<System.Int32> val_41 = new System.Collections.Generic.List<System.Int32>();
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41.Add(item:  39);
        val_41.Add(item:  1);
        val_41.Add(item:  3);
        val_1.Add(item:  val_41);
        System.Collections.Generic.List<System.Int32> val_42 = new System.Collections.Generic.List<System.Int32>();
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_42.Add(item:  40);
        val_42.Add(item:  1);
        val_42.Add(item:  3);
        val_1.Add(item:  val_42);
        System.Collections.Generic.List<System.Int32> val_43 = new System.Collections.Generic.List<System.Int32>();
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43.Add(item:  41);
        val_43.Add(item:  2);
        val_43.Add(item:  3);
        val_1.Add(item:  val_43);
        System.Collections.Generic.List<System.Int32> val_44 = new System.Collections.Generic.List<System.Int32>();
        if(val_44 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44.Add(item:  42);
        val_44.Add(item:  2);
        val_44.Add(item:  3);
        val_1.Add(item:  val_44);
        System.Collections.Generic.List<System.Int32> val_45 = new System.Collections.Generic.List<System.Int32>();
        if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
        val_45.Add(item:  43);
        val_45.Add(item:  2);
        val_45.Add(item:  3);
        val_1.Add(item:  val_45);
        System.Collections.Generic.List<System.Int32> val_46 = new System.Collections.Generic.List<System.Int32>();
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        val_46.Add(item:  44);
        val_46.Add(item:  2);
        val_46.Add(item:  3);
        val_1.Add(item:  val_46);
        System.Collections.Generic.List<System.Int32> val_47 = new System.Collections.Generic.List<System.Int32>();
        if(val_47 == null)
        {
                throw new NullReferenceException();
        }
        
        val_47.Add(item:  45);
        val_47.Add(item:  2);
        val_47.Add(item:  3);
        val_1.Add(item:  val_47);
        System.Collections.Generic.List<System.Int32> val_48 = new System.Collections.Generic.List<System.Int32>();
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        val_48.Add(item:  46);
        val_48.Add(item:  3);
        val_48.Add(item:  3);
        val_1.Add(item:  val_48);
        System.Collections.Generic.List<System.Int32> val_49 = new System.Collections.Generic.List<System.Int32>();
        if(val_49 == null)
        {
                throw new NullReferenceException();
        }
        
        val_49.Add(item:  47);
        val_49.Add(item:  3);
        val_49.Add(item:  3);
        val_1.Add(item:  val_49);
        System.Collections.Generic.List<System.Int32> val_50 = new System.Collections.Generic.List<System.Int32>();
        if(val_50 == null)
        {
                throw new NullReferenceException();
        }
        
        val_50.Add(item:  48);
        val_50.Add(item:  3);
        val_50.Add(item:  3);
        val_1.Add(item:  val_50);
        System.Collections.Generic.List<System.Int32> val_51 = new System.Collections.Generic.List<System.Int32>();
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_51.Add(item:  49);
        val_51.Add(item:  3);
        val_51.Add(item:  3);
        val_1.Add(item:  val_51);
        System.Collections.Generic.List<System.Int32> val_52 = new System.Collections.Generic.List<System.Int32>();
        if(val_52 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52.Add(item:  50);
        val_52.Add(item:  3);
        val_52.Add(item:  3);
        val_1.Add(item:  val_52);
        System.Collections.Generic.List<System.Int32> val_53 = new System.Collections.Generic.List<System.Int32>();
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        val_53.Add(item:  51);
        val_53.Add(item:  3);
        val_53.Add(item:  3);
        val_1.Add(item:  val_53);
        System.Collections.Generic.List<System.Int32> val_54 = new System.Collections.Generic.List<System.Int32>();
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        val_54.Add(item:  52);
        val_54.Add(item:  3);
        val_54.Add(item:  3);
        val_1.Add(item:  val_54);
        System.Collections.Generic.List<System.Int32> val_55 = new System.Collections.Generic.List<System.Int32>();
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_55.Add(item:  53);
        val_55.Add(item:  3);
        val_55.Add(item:  3);
        val_1.Add(item:  val_55);
        System.Collections.Generic.List<System.Int32> val_56 = new System.Collections.Generic.List<System.Int32>();
        if(val_56 == null)
        {
                throw new NullReferenceException();
        }
        
        val_56.Add(item:  54);
        val_56.Add(item:  3);
        val_56.Add(item:  3);
        val_1.Add(item:  val_56);
        System.Collections.Generic.List<System.Int32> val_57 = new System.Collections.Generic.List<System.Int32>();
        if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57.Add(item:  55);
        val_57.Add(item:  3);
        val_57.Add(item:  3);
        val_1.Add(item:  val_57);
        System.Collections.Generic.List<System.Int32> val_58 = new System.Collections.Generic.List<System.Int32>();
        if(val_58 == null)
        {
                throw new NullReferenceException();
        }
        
        val_58.Add(item:  56);
        val_58.Add(item:  4);
        val_58.Add(item:  3);
        val_1.Add(item:  val_58);
        System.Collections.Generic.List<System.Int32> val_59 = new System.Collections.Generic.List<System.Int32>();
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        val_59.Add(item:  57);
        val_59.Add(item:  4);
        val_59.Add(item:  3);
        val_1.Add(item:  val_59);
        System.Collections.Generic.List<System.Int32> val_60 = new System.Collections.Generic.List<System.Int32>();
        if(val_60 == null)
        {
                throw new NullReferenceException();
        }
        
        val_60.Add(item:  58);
        val_60.Add(item:  4);
        val_60.Add(item:  3);
        val_1.Add(item:  val_60);
        System.Collections.Generic.List<System.Int32> val_61 = new System.Collections.Generic.List<System.Int32>();
        if(val_61 == null)
        {
                throw new NullReferenceException();
        }
        
        val_61.Add(item:  59);
        val_61.Add(item:  4);
        val_61.Add(item:  3);
        val_1.Add(item:  val_61);
        System.Collections.Generic.List<System.Int32> val_62 = new System.Collections.Generic.List<System.Int32>();
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        val_62.Add(item:  60);
        val_62.Add(item:  4);
        val_62.Add(item:  3);
        val_1.Add(item:  val_62);
        System.Collections.Generic.List<System.Int32> val_63 = new System.Collections.Generic.List<System.Int32>();
        if(val_63 == null)
        {
                throw new NullReferenceException();
        }
        
        val_63.Add(item:  61);
        val_63.Add(item:  4);
        val_63.Add(item:  3);
        val_1.Add(item:  val_63);
        System.Collections.Generic.List<System.Int32> val_64 = new System.Collections.Generic.List<System.Int32>();
        if(val_64 == null)
        {
                throw new NullReferenceException();
        }
        
        val_64.Add(item:  62);
        val_64.Add(item:  4);
        val_64.Add(item:  3);
        val_1.Add(item:  val_64);
        System.Collections.Generic.List<System.Int32> val_65 = new System.Collections.Generic.List<System.Int32>();
        if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
        val_65.Add(item:  63);
        val_65.Add(item:  4);
        val_65.Add(item:  3);
        val_1.Add(item:  val_65);
        System.Collections.Generic.List<System.Int32> val_66 = new System.Collections.Generic.List<System.Int32>();
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_66.Add(item:  64);
        val_66.Add(item:  4);
        val_66.Add(item:  3);
        val_1.Add(item:  val_66);
        System.Collections.Generic.List<System.Int32> val_67 = new System.Collections.Generic.List<System.Int32>();
        if(val_67 == null)
        {
                throw new NullReferenceException();
        }
        
        val_67.Add(item:  65);
        val_67.Add(item:  4);
        val_67.Add(item:  3);
        val_1.Add(item:  val_67);
        System.Collections.Generic.List<System.Int32> val_68 = new System.Collections.Generic.List<System.Int32>();
        if(val_68 == null)
        {
                throw new NullReferenceException();
        }
        
        val_68.Add(item:  66);
        val_68.Add(item:  1);
        val_68.Add(item:  4);
        val_1.Add(item:  val_68);
        System.Collections.Generic.List<System.Int32> val_69 = new System.Collections.Generic.List<System.Int32>();
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        val_69.Add(item:  67);
        val_69.Add(item:  1);
        val_69.Add(item:  4);
        val_1.Add(item:  val_69);
        System.Collections.Generic.List<System.Int32> val_70 = new System.Collections.Generic.List<System.Int32>();
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        val_70.Add(item:  68);
        val_70.Add(item:  1);
        val_70.Add(item:  4);
        val_1.Add(item:  val_70);
        System.Collections.Generic.List<System.Int32> val_71 = new System.Collections.Generic.List<System.Int32>();
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        val_71.Add(item:  69);
        val_71.Add(item:  1);
        val_71.Add(item:  4);
        val_1.Add(item:  val_71);
        System.Collections.Generic.List<System.Int32> val_72 = new System.Collections.Generic.List<System.Int32>();
        if(val_72 == null)
        {
                throw new NullReferenceException();
        }
        
        val_72.Add(item:  70);
        val_72.Add(item:  1);
        val_72.Add(item:  4);
        val_1.Add(item:  val_72);
        System.Collections.Generic.List<System.Int32> val_73 = new System.Collections.Generic.List<System.Int32>();
        if(val_73 == null)
        {
                throw new NullReferenceException();
        }
        
        val_73.Add(item:  71);
        val_73.Add(item:  2);
        val_73.Add(item:  4);
        val_1.Add(item:  val_73);
        System.Collections.Generic.List<System.Int32> val_74 = new System.Collections.Generic.List<System.Int32>();
        if(val_74 == null)
        {
                throw new NullReferenceException();
        }
        
        val_74.Add(item:  72);
        val_74.Add(item:  2);
        val_74.Add(item:  4);
        val_1.Add(item:  val_74);
        System.Collections.Generic.List<System.Int32> val_75 = new System.Collections.Generic.List<System.Int32>();
        if(val_75 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75.Add(item:  73);
        val_75.Add(item:  2);
        val_75.Add(item:  4);
        val_1.Add(item:  val_75);
        System.Collections.Generic.List<System.Int32> val_76 = new System.Collections.Generic.List<System.Int32>();
        if(val_76 == null)
        {
                throw new NullReferenceException();
        }
        
        val_76.Add(item:  74);
        val_76.Add(item:  2);
        val_76.Add(item:  4);
        val_1.Add(item:  val_76);
        System.Collections.Generic.List<System.Int32> val_77 = new System.Collections.Generic.List<System.Int32>();
        if(val_77 == null)
        {
                throw new NullReferenceException();
        }
        
        val_77.Add(item:  75);
        val_77.Add(item:  2);
        val_77.Add(item:  4);
        val_1.Add(item:  val_77);
        System.Collections.Generic.List<System.Int32> val_78 = new System.Collections.Generic.List<System.Int32>();
        if(val_78 == null)
        {
                throw new NullReferenceException();
        }
        
        val_78.Add(item:  76);
        val_78.Add(item:  3);
        val_78.Add(item:  4);
        val_1.Add(item:  val_78);
        System.Collections.Generic.List<System.Int32> val_79 = new System.Collections.Generic.List<System.Int32>();
        if(val_79 == null)
        {
                throw new NullReferenceException();
        }
        
        val_79.Add(item:  77);
        val_79.Add(item:  3);
        val_79.Add(item:  4);
        val_1.Add(item:  val_79);
        System.Collections.Generic.List<System.Int32> val_80 = new System.Collections.Generic.List<System.Int32>();
        if(val_80 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80.Add(item:  78);
        val_80.Add(item:  3);
        val_80.Add(item:  4);
        val_1.Add(item:  val_80);
        System.Collections.Generic.List<System.Int32> val_81 = new System.Collections.Generic.List<System.Int32>();
        if(val_81 == null)
        {
                throw new NullReferenceException();
        }
        
        val_81.Add(item:  79);
        val_81.Add(item:  3);
        val_81.Add(item:  4);
        val_1.Add(item:  val_81);
        System.Collections.Generic.List<System.Int32> val_82 = new System.Collections.Generic.List<System.Int32>();
        if(val_82 == null)
        {
                throw new NullReferenceException();
        }
        
        val_82.Add(item:  80);
        val_82.Add(item:  3);
        val_82.Add(item:  4);
        val_1.Add(item:  val_82);
        System.Collections.Generic.List<System.Int32> val_83 = new System.Collections.Generic.List<System.Int32>();
        if(val_83 == null)
        {
                throw new NullReferenceException();
        }
        
        val_83.Add(item:  81);
        val_83.Add(item:  3);
        val_83.Add(item:  4);
        val_1.Add(item:  val_83);
        System.Collections.Generic.List<System.Int32> val_84 = new System.Collections.Generic.List<System.Int32>();
        if(val_84 == null)
        {
                throw new NullReferenceException();
        }
        
        val_84.Add(item:  82);
        val_84.Add(item:  3);
        val_84.Add(item:  4);
        val_1.Add(item:  val_84);
        System.Collections.Generic.List<System.Int32> val_85 = new System.Collections.Generic.List<System.Int32>();
        if(val_85 == null)
        {
                throw new NullReferenceException();
        }
        
        val_85.Add(item:  83);
        val_85.Add(item:  3);
        val_85.Add(item:  4);
        val_1.Add(item:  val_85);
        System.Collections.Generic.List<System.Int32> val_86 = new System.Collections.Generic.List<System.Int32>();
        if(val_86 == null)
        {
                throw new NullReferenceException();
        }
        
        val_86.Add(item:  84);
        val_86.Add(item:  3);
        val_86.Add(item:  4);
        val_1.Add(item:  val_86);
        System.Collections.Generic.List<System.Int32> val_87 = new System.Collections.Generic.List<System.Int32>();
        if(val_87 == null)
        {
                throw new NullReferenceException();
        }
        
        val_87.Add(item:  85);
        val_87.Add(item:  3);
        val_87.Add(item:  4);
        val_1.Add(item:  val_87);
        System.Collections.Generic.List<System.Int32> val_88 = new System.Collections.Generic.List<System.Int32>();
        if(val_88 == null)
        {
                throw new NullReferenceException();
        }
        
        val_88.Add(item:  86);
        val_88.Add(item:  4);
        val_88.Add(item:  4);
        val_1.Add(item:  val_88);
        System.Collections.Generic.List<System.Int32> val_89 = new System.Collections.Generic.List<System.Int32>();
        if(val_89 == null)
        {
                throw new NullReferenceException();
        }
        
        val_89.Add(item:  87);
        val_89.Add(item:  4);
        val_89.Add(item:  4);
        val_1.Add(item:  val_89);
        System.Collections.Generic.List<System.Int32> val_90 = new System.Collections.Generic.List<System.Int32>();
        if(val_90 == null)
        {
                throw new NullReferenceException();
        }
        
        val_90.Add(item:  88);
        val_90.Add(item:  4);
        val_90.Add(item:  4);
        val_1.Add(item:  val_90);
        System.Collections.Generic.List<System.Int32> val_91 = new System.Collections.Generic.List<System.Int32>();
        if(val_91 == null)
        {
                throw new NullReferenceException();
        }
        
        val_91.Add(item:  89);
        val_91.Add(item:  4);
        val_91.Add(item:  4);
        val_1.Add(item:  val_91);
        System.Collections.Generic.List<System.Int32> val_92 = new System.Collections.Generic.List<System.Int32>();
        if(val_92 == null)
        {
                throw new NullReferenceException();
        }
        
        val_92.Add(item:  90);
        val_92.Add(item:  4);
        val_92.Add(item:  4);
        val_1.Add(item:  val_92);
        System.Collections.Generic.List<System.Int32> val_93 = new System.Collections.Generic.List<System.Int32>();
        if(val_93 == null)
        {
                throw new NullReferenceException();
        }
        
        val_93.Add(item:  91);
        val_93.Add(item:  4);
        val_93.Add(item:  4);
        val_1.Add(item:  val_93);
        System.Collections.Generic.List<System.Int32> val_94 = new System.Collections.Generic.List<System.Int32>();
        if(val_94 == null)
        {
                throw new NullReferenceException();
        }
        
        val_94.Add(item:  92);
        val_94.Add(item:  4);
        val_94.Add(item:  4);
        val_1.Add(item:  val_94);
        System.Collections.Generic.List<System.Int32> val_95 = new System.Collections.Generic.List<System.Int32>();
        if(val_95 == null)
        {
                throw new NullReferenceException();
        }
        
        val_95.Add(item:  93);
        val_95.Add(item:  4);
        val_95.Add(item:  4);
        val_1.Add(item:  val_95);
        System.Collections.Generic.List<System.Int32> val_96 = new System.Collections.Generic.List<System.Int32>();
        if(val_96 == null)
        {
                throw new NullReferenceException();
        }
        
        val_96.Add(item:  94);
        val_96.Add(item:  4);
        val_96.Add(item:  4);
        val_1.Add(item:  val_96);
        System.Collections.Generic.List<System.Int32> val_97 = new System.Collections.Generic.List<System.Int32>();
        if(val_97 == null)
        {
                throw new NullReferenceException();
        }
        
        val_97.Add(item:  95);
        val_97.Add(item:  4);
        val_97.Add(item:  4);
        val_1.Add(item:  val_97);
        System.Collections.Generic.List<System.Int32> val_98 = new System.Collections.Generic.List<System.Int32>();
        if(val_98 == null)
        {
                throw new NullReferenceException();
        }
        
        val_98.Add(item:  96);
        val_98.Add(item:  5);
        val_98.Add(item:  4);
        val_1.Add(item:  val_98);
        System.Collections.Generic.List<System.Int32> val_99 = new System.Collections.Generic.List<System.Int32>();
        if(val_99 == null)
        {
                throw new NullReferenceException();
        }
        
        val_99.Add(item:  97);
        val_99.Add(item:  5);
        val_99.Add(item:  4);
        val_1.Add(item:  val_99);
        System.Collections.Generic.List<System.Int32> val_100 = new System.Collections.Generic.List<System.Int32>();
        if(val_100 == null)
        {
                throw new NullReferenceException();
        }
        
        val_100.Add(item:  98);
        val_100.Add(item:  5);
        val_100.Add(item:  4);
        val_1.Add(item:  val_100);
        System.Collections.Generic.List<System.Int32> val_101 = new System.Collections.Generic.List<System.Int32>();
        if(val_101 == null)
        {
                throw new NullReferenceException();
        }
        
        val_101.Add(item:  99);
        val_101.Add(item:  5);
        val_101.Add(item:  4);
        val_1.Add(item:  val_101);
        System.Collections.Generic.List<System.Int32> val_102 = new System.Collections.Generic.List<System.Int32>();
        if(val_102 == null)
        {
                throw new NullReferenceException();
        }
        
        val_102.Add(item:  100);
        val_102.Add(item:  5);
        val_102.Add(item:  4);
        val_1.Add(item:  val_102);
        System.Collections.Generic.List<System.Int32> val_103 = new System.Collections.Generic.List<System.Int32>();
        if(val_103 == null)
        {
                throw new NullReferenceException();
        }
        
        val_103.Add(item:  101);
        val_103.Add(item:  5);
        val_103.Add(item:  4);
        val_1.Add(item:  val_103);
        System.Collections.Generic.List<System.Int32> val_104 = new System.Collections.Generic.List<System.Int32>();
        if(val_104 == null)
        {
                throw new NullReferenceException();
        }
        
        val_104.Add(item:  102);
        val_104.Add(item:  5);
        val_104.Add(item:  4);
        val_1.Add(item:  val_104);
        System.Collections.Generic.List<System.Int32> val_105 = new System.Collections.Generic.List<System.Int32>();
        if(val_105 == null)
        {
                throw new NullReferenceException();
        }
        
        val_105.Add(item:  103);
        val_105.Add(item:  5);
        val_105.Add(item:  4);
        val_1.Add(item:  val_105);
        System.Collections.Generic.List<System.Int32> val_106 = new System.Collections.Generic.List<System.Int32>();
        if(val_106 == null)
        {
                throw new NullReferenceException();
        }
        
        val_106.Add(item:  104);
        val_106.Add(item:  5);
        val_106.Add(item:  4);
        val_1.Add(item:  val_106);
        System.Collections.Generic.List<System.Int32> val_107 = new System.Collections.Generic.List<System.Int32>();
        if(val_107 == null)
        {
                throw new NullReferenceException();
        }
        
        val_107.Add(item:  105);
        val_107.Add(item:  5);
        val_107.Add(item:  4);
        val_1.Add(item:  val_107);
        System.Collections.Generic.List<System.Int32> val_108 = new System.Collections.Generic.List<System.Int32>();
        if(val_108 == null)
        {
                throw new NullReferenceException();
        }
        
        val_108.Add(item:  106);
        val_108.Add(item:  1);
        val_108.Add(item:  5);
        val_1.Add(item:  val_108);
        System.Collections.Generic.List<System.Int32> val_109 = new System.Collections.Generic.List<System.Int32>();
        if(val_109 == null)
        {
                throw new NullReferenceException();
        }
        
        val_109.Add(item:  107);
        val_109.Add(item:  1);
        val_109.Add(item:  5);
        val_1.Add(item:  val_109);
        System.Collections.Generic.List<System.Int32> val_110 = new System.Collections.Generic.List<System.Int32>();
        if(val_110 == null)
        {
                throw new NullReferenceException();
        }
        
        val_110.Add(item:  108);
        val_110.Add(item:  1);
        val_110.Add(item:  5);
        val_1.Add(item:  val_110);
        System.Collections.Generic.List<System.Int32> val_111 = new System.Collections.Generic.List<System.Int32>();
        if(val_111 == null)
        {
                throw new NullReferenceException();
        }
        
        val_111.Add(item:  109);
        val_111.Add(item:  1);
        val_111.Add(item:  5);
        val_1.Add(item:  val_111);
        System.Collections.Generic.List<System.Int32> val_112 = new System.Collections.Generic.List<System.Int32>();
        if(val_112 == null)
        {
                throw new NullReferenceException();
        }
        
        val_112.Add(item:  110);
        val_112.Add(item:  1);
        val_112.Add(item:  5);
        val_1.Add(item:  val_112);
        System.Collections.Generic.List<System.Int32> val_113 = new System.Collections.Generic.List<System.Int32>();
        if(val_113 == null)
        {
                throw new NullReferenceException();
        }
        
        val_113.Add(item:  111);
        val_113.Add(item:  1);
        val_113.Add(item:  5);
        val_1.Add(item:  val_113);
        System.Collections.Generic.List<System.Int32> val_114 = new System.Collections.Generic.List<System.Int32>();
        if(val_114 == null)
        {
                throw new NullReferenceException();
        }
        
        val_114.Add(item:  112);
        val_114.Add(item:  1);
        val_114.Add(item:  5);
        val_1.Add(item:  val_114);
        System.Collections.Generic.List<System.Int32> val_115 = new System.Collections.Generic.List<System.Int32>();
        if(val_115 == null)
        {
                throw new NullReferenceException();
        }
        
        val_115.Add(item:  113);
        val_115.Add(item:  1);
        val_115.Add(item:  5);
        val_1.Add(item:  val_115);
        System.Collections.Generic.List<System.Int32> val_116 = new System.Collections.Generic.List<System.Int32>();
        if(val_116 == null)
        {
                throw new NullReferenceException();
        }
        
        val_116.Add(item:  114);
        val_116.Add(item:  1);
        val_116.Add(item:  5);
        val_1.Add(item:  val_116);
        System.Collections.Generic.List<System.Int32> val_117 = new System.Collections.Generic.List<System.Int32>();
        if(val_117 == null)
        {
                throw new NullReferenceException();
        }
        
        val_117.Add(item:  115);
        val_117.Add(item:  1);
        val_117.Add(item:  5);
        val_1.Add(item:  val_117);
        System.Collections.Generic.List<System.Int32> val_118 = new System.Collections.Generic.List<System.Int32>();
        if(val_118 == null)
        {
                throw new NullReferenceException();
        }
        
        val_118.Add(item:  116);
        val_118.Add(item:  2);
        val_118.Add(item:  5);
        val_1.Add(item:  val_118);
        System.Collections.Generic.List<System.Int32> val_119 = new System.Collections.Generic.List<System.Int32>();
        if(val_119 == null)
        {
                throw new NullReferenceException();
        }
        
        val_119.Add(item:  117);
        val_119.Add(item:  2);
        val_119.Add(item:  5);
        val_1.Add(item:  val_119);
        System.Collections.Generic.List<System.Int32> val_120 = new System.Collections.Generic.List<System.Int32>();
        if(val_120 == null)
        {
                throw new NullReferenceException();
        }
        
        val_120.Add(item:  118);
        val_120.Add(item:  2);
        val_120.Add(item:  5);
        val_1.Add(item:  val_120);
        System.Collections.Generic.List<System.Int32> val_121 = new System.Collections.Generic.List<System.Int32>();
        if(val_121 == null)
        {
                throw new NullReferenceException();
        }
        
        val_121.Add(item:  119);
        val_121.Add(item:  2);
        val_121.Add(item:  5);
        val_1.Add(item:  val_121);
        System.Collections.Generic.List<System.Int32> val_122 = new System.Collections.Generic.List<System.Int32>();
        if(val_122 == null)
        {
                throw new NullReferenceException();
        }
        
        val_122.Add(item:  120);
        val_122.Add(item:  2);
        val_122.Add(item:  5);
        val_1.Add(item:  val_122);
        System.Collections.Generic.List<System.Int32> val_123 = new System.Collections.Generic.List<System.Int32>();
        if(val_123 == null)
        {
                throw new NullReferenceException();
        }
        
        val_123.Add(item:  121);
        val_123.Add(item:  2);
        val_123.Add(item:  5);
        val_1.Add(item:  val_123);
        System.Collections.Generic.List<System.Int32> val_124 = new System.Collections.Generic.List<System.Int32>();
        if(val_124 == null)
        {
                throw new NullReferenceException();
        }
        
        val_124.Add(item:  122);
        val_124.Add(item:  2);
        val_124.Add(item:  5);
        val_1.Add(item:  val_124);
        System.Collections.Generic.List<System.Int32> val_125 = new System.Collections.Generic.List<System.Int32>();
        if(val_125 == null)
        {
                throw new NullReferenceException();
        }
        
        val_125.Add(item:  123);
        val_125.Add(item:  2);
        val_125.Add(item:  5);
        val_1.Add(item:  val_125);
        System.Collections.Generic.List<System.Int32> val_126 = new System.Collections.Generic.List<System.Int32>();
        if(val_126 == null)
        {
                throw new NullReferenceException();
        }
        
        val_126.Add(item:  124);
        val_126.Add(item:  2);
        val_126.Add(item:  5);
        val_1.Add(item:  val_126);
        System.Collections.Generic.List<System.Int32> val_127 = new System.Collections.Generic.List<System.Int32>();
        if(val_127 == null)
        {
                throw new NullReferenceException();
        }
        
        val_127.Add(item:  125);
        val_127.Add(item:  2);
        val_127.Add(item:  5);
        val_1.Add(item:  val_127);
        System.Collections.Generic.List<System.Int32> val_128 = new System.Collections.Generic.List<System.Int32>();
        if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
        val_128.Add(item:  126);
        val_128.Add(item:  3);
        val_128.Add(item:  5);
        val_1.Add(item:  val_128);
        System.Collections.Generic.List<System.Int32> val_129 = new System.Collections.Generic.List<System.Int32>();
        if(val_129 == null)
        {
                throw new NullReferenceException();
        }
        
        val_129.Add(item:  127);
        val_129.Add(item:  3);
        val_129.Add(item:  5);
        val_1.Add(item:  val_129);
        System.Collections.Generic.List<System.Int32> val_130 = new System.Collections.Generic.List<System.Int32>();
        if(val_130 == null)
        {
                throw new NullReferenceException();
        }
        
        val_130.Add(item:  128);
        val_130.Add(item:  3);
        val_130.Add(item:  5);
        val_1.Add(item:  val_130);
        System.Collections.Generic.List<System.Int32> val_131 = new System.Collections.Generic.List<System.Int32>();
        if(val_131 == null)
        {
                throw new NullReferenceException();
        }
        
        val_131.Add(item:  129);
        val_131.Add(item:  3);
        val_131.Add(item:  5);
        val_1.Add(item:  val_131);
        System.Collections.Generic.List<System.Int32> val_132 = new System.Collections.Generic.List<System.Int32>();
        if(val_132 == null)
        {
                throw new NullReferenceException();
        }
        
        val_132.Add(item:  130);
        val_132.Add(item:  3);
        val_132.Add(item:  5);
        val_1.Add(item:  val_132);
        System.Collections.Generic.List<System.Int32> val_133 = new System.Collections.Generic.List<System.Int32>();
        if(val_133 == null)
        {
                throw new NullReferenceException();
        }
        
        val_133.Add(item:  131);
        val_133.Add(item:  3);
        val_133.Add(item:  5);
        val_1.Add(item:  val_133);
        System.Collections.Generic.List<System.Int32> val_134 = new System.Collections.Generic.List<System.Int32>();
        if(val_134 == null)
        {
                throw new NullReferenceException();
        }
        
        val_134.Add(item:  132);
        val_134.Add(item:  3);
        val_134.Add(item:  5);
        val_1.Add(item:  val_134);
        System.Collections.Generic.List<System.Int32> val_135 = new System.Collections.Generic.List<System.Int32>();
        if(val_135 == null)
        {
                throw new NullReferenceException();
        }
        
        val_135.Add(item:  133);
        val_135.Add(item:  3);
        val_135.Add(item:  5);
        val_1.Add(item:  val_135);
        System.Collections.Generic.List<System.Int32> val_136 = new System.Collections.Generic.List<System.Int32>();
        if(val_136 == null)
        {
                throw new NullReferenceException();
        }
        
        val_136.Add(item:  134);
        val_136.Add(item:  3);
        val_136.Add(item:  5);
        val_1.Add(item:  val_136);
        System.Collections.Generic.List<System.Int32> val_137 = new System.Collections.Generic.List<System.Int32>();
        if(val_137 == null)
        {
                throw new NullReferenceException();
        }
        
        val_137.Add(item:  135);
        val_137.Add(item:  3);
        val_137.Add(item:  5);
        val_1.Add(item:  val_137);
        System.Collections.Generic.List<System.Int32> val_138 = new System.Collections.Generic.List<System.Int32>();
        if(val_138 == null)
        {
                throw new NullReferenceException();
        }
        
        val_138.Add(item:  136);
        val_138.Add(item:  4);
        val_138.Add(item:  5);
        val_1.Add(item:  val_138);
        System.Collections.Generic.List<System.Int32> val_139 = new System.Collections.Generic.List<System.Int32>();
        if(val_139 == null)
        {
                throw new NullReferenceException();
        }
        
        val_139.Add(item:  137);
        val_139.Add(item:  4);
        val_139.Add(item:  5);
        val_1.Add(item:  val_139);
        System.Collections.Generic.List<System.Int32> val_140 = new System.Collections.Generic.List<System.Int32>();
        if(val_140 == null)
        {
                throw new NullReferenceException();
        }
        
        val_140.Add(item:  138);
        val_140.Add(item:  4);
        val_140.Add(item:  5);
        val_1.Add(item:  val_140);
        System.Collections.Generic.List<System.Int32> val_141 = new System.Collections.Generic.List<System.Int32>();
        if(val_141 == null)
        {
                throw new NullReferenceException();
        }
        
        val_141.Add(item:  139);
        val_141.Add(item:  4);
        val_141.Add(item:  5);
        val_1.Add(item:  val_141);
        System.Collections.Generic.List<System.Int32> val_142 = new System.Collections.Generic.List<System.Int32>();
        if(val_142 == null)
        {
                throw new NullReferenceException();
        }
        
        val_142.Add(item:  140);
        val_142.Add(item:  4);
        val_142.Add(item:  5);
        val_1.Add(item:  val_142);
        System.Collections.Generic.List<System.Int32> val_143 = new System.Collections.Generic.List<System.Int32>();
        if(val_143 == null)
        {
                throw new NullReferenceException();
        }
        
        val_143.Add(item:  141);
        val_143.Add(item:  4);
        val_143.Add(item:  5);
        val_1.Add(item:  val_143);
        System.Collections.Generic.List<System.Int32> val_144 = new System.Collections.Generic.List<System.Int32>();
        if(val_144 == null)
        {
                throw new NullReferenceException();
        }
        
        val_144.Add(item:  142);
        val_144.Add(item:  4);
        val_144.Add(item:  5);
        val_1.Add(item:  val_144);
        System.Collections.Generic.List<System.Int32> val_145 = new System.Collections.Generic.List<System.Int32>();
        if(val_145 == null)
        {
                throw new NullReferenceException();
        }
        
        val_145.Add(item:  143);
        val_145.Add(item:  4);
        val_145.Add(item:  5);
        val_1.Add(item:  val_145);
        System.Collections.Generic.List<System.Int32> val_146 = new System.Collections.Generic.List<System.Int32>();
        if(val_146 == null)
        {
                throw new NullReferenceException();
        }
        
        val_146.Add(item:  144);
        val_146.Add(item:  4);
        val_146.Add(item:  5);
        val_1.Add(item:  val_146);
        System.Collections.Generic.List<System.Int32> val_147 = new System.Collections.Generic.List<System.Int32>();
        if(val_147 == null)
        {
                throw new NullReferenceException();
        }
        
        val_147.Add(item:  145);
        val_147.Add(item:  4);
        val_147.Add(item:  5);
        val_1.Add(item:  val_147);
        System.Collections.Generic.List<System.Int32> val_148 = new System.Collections.Generic.List<System.Int32>();
        if(val_148 == null)
        {
                throw new NullReferenceException();
        }
        
        val_148.Add(item:  146);
        val_148.Add(item:  5);
        val_148.Add(item:  5);
        val_1.Add(item:  val_148);
        System.Collections.Generic.List<System.Int32> val_149 = new System.Collections.Generic.List<System.Int32>();
        if(val_149 == null)
        {
                throw new NullReferenceException();
        }
        
        val_149.Add(item:  147);
        val_149.Add(item:  5);
        val_149.Add(item:  5);
        val_1.Add(item:  val_149);
        System.Collections.Generic.List<System.Int32> val_150 = new System.Collections.Generic.List<System.Int32>();
        if(val_150 == null)
        {
                throw new NullReferenceException();
        }
        
        val_150.Add(item:  148);
        val_150.Add(item:  5);
        val_150.Add(item:  5);
        val_1.Add(item:  val_150);
        System.Collections.Generic.List<System.Int32> val_151 = new System.Collections.Generic.List<System.Int32>();
        val_151.Add(item:  149);
        val_151.Add(item:  5);
        val_151.Add(item:  5);
        val_1.Add(item:  val_151);
        System.Collections.Generic.List<System.Int32> val_152 = new System.Collections.Generic.List<System.Int32>();
        val_152.Add(item:  150);
        val_152.Add(item:  5);
        val_152.Add(item:  5);
        val_1.Add(item:  val_152);
        System.Collections.Generic.List<System.Int32> val_153 = new System.Collections.Generic.List<System.Int32>();
        val_153.Add(item:  151);
        val_153.Add(item:  5);
        val_153.Add(item:  5);
        val_1.Add(item:  val_153);
        System.Collections.Generic.List<System.Int32> val_154 = new System.Collections.Generic.List<System.Int32>();
        val_154.Add(item:  152);
        val_154.Add(item:  5);
        val_154.Add(item:  5);
        val_1.Add(item:  val_154);
        System.Collections.Generic.List<System.Int32> val_155 = new System.Collections.Generic.List<System.Int32>();
        val_155.Add(item:  153);
        val_155.Add(item:  5);
        val_155.Add(item:  5);
        val_1.Add(item:  val_155);
        System.Collections.Generic.List<System.Int32> val_156 = new System.Collections.Generic.List<System.Int32>();
        val_156.Add(item:  154);
        val_156.Add(item:  5);
        val_156.Add(item:  5);
        val_1.Add(item:  val_156);
        System.Collections.Generic.List<System.Int32> val_157 = new System.Collections.Generic.List<System.Int32>();
        val_157.Add(item:  155);
        val_157.Add(item:  5);
        val_157.Add(item:  5);
        val_1.Add(item:  val_157);
        ChapterBookLogic.early_list_index_book = val_1;
        ChapterBookLogic._ChaptersPerBook = 5;
        ChapterBookLogic._LevelsPerChapter = 10;
    }

}
