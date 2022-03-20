using UnityEngine;
[Serializable]
public class GameLevel
{
    // Fields
    public System.Collections.Generic.List<string> levelProgress;
    public int playerLevel;
    public bool isChallengingLevel;
    public int goldenApplesExtraDifficulty;
    public int goldenApplesStreaks;
    public int goldenApplesStreaksSubBonus;
    public int goldenApplesExtraWords;
    public int goldenApplesExtraWordsSubBonus;
    public int highestWordStreak;
    public bool completed;
    public string word;
    public string answers;
    public string extraWords;
    private string lvlName;
    public int levelIndex;
    public string language;
    public int actualWordCount;
    public string coords;
    public string gridSize;
    public string availExtraReq;
    public int extraWordsNeeded;
    public string extraRequiredWords;
    public System.Collections.Generic.List<string> commonW;
    public System.Collections.Generic.List<string> uncommonW;
    public System.Collections.Generic.List<string> rareW;
    public System.Collections.Generic.List<string> rwdBase;
    public System.Collections.Generic.List<string> rwdExp1;
    public System.Collections.Generic.List<string> rwdExp2;
    public System.Collections.Generic.List<string> rwdExp3;
    public System.Collections.Generic.List<string> rwdExp4;
    public string challengeWord;
    public float avgCompletionTime;
    
    // Properties
    public string levelName { get; set; }
    
    // Methods
    public System.Collections.Generic.List<string> GetLevelProgress()
    {
        return System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Skip<System.String>(source:  this.levelProgress, count:  1));
    }
    public string get_levelName()
    {
        return (string)this.lvlName;
    }
    public void set_levelName(string value)
    {
        this.lvlName = value;
        if((System.String.IsNullOrEmpty(value:  value)) != false)
        {
                return;
        }
        
        bool val_3 = System.Int32.TryParse(s:  value, result: out  this.levelIndex);
    }
    private System.Collections.Generic.List<string> GetShuffledWords(string inputStr)
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        if(inputStr.m_stringLength >= 1)
        {
                var val_9 = 0;
            do
        {
            if((System.String.op_Equality(a:  inputStr.Chars[0].ToString(), b:  "|")) != false)
        {
                val_1.Add(item:  "");
        }
        else
        {
                int val_8 = inputStr.m_stringLength;
            val_8 = val_8 - 1;
            if(val_9 == val_8)
        {
                val_1.Add(item:  "" + inputStr.Chars[0].ToString());
        }
        
        }
        
            val_9 = val_9 + 1;
        }
        while(val_9 < inputStr.m_stringLength);
        
        }
        
        PluginExtension.Shuffle<System.String>(list:  val_1, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        return val_1;
    }
    public override string ToString()
    {
        int val_4;
        int val_5;
        object[] val_1 = new object[14];
        val_4 = val_1.Length;
        val_1[0] = this.word;
        if(this.answers != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[1] = this.answers;
        if(this.extraWords != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[2] = this.extraWords;
        if(this.lvlName != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[3] = this.lvlName;
        if(this.coords != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[4] = this.coords;
        if(this.gridSize != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[5] = this.gridSize;
        if(this.language != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[6] = this.language;
        val_1[7] = this.avgCompletionTime;
        val_1[8] = MiniJSON.Json.Serialize(obj:  this.levelProgress);
        val_1[9] = this.actualWordCount;
        val_1[10] = this.isChallengingLevel;
        int val_4 = this.goldenApplesExtraWords;
        val_4 = val_4 + this.goldenApplesExtraDifficulty;
        val_4 = val_4 + this.goldenApplesStreaks;
        val_5 = val_1.Length;
        val_1[11] = val_4;
        if(this.availExtraReq != null)
        {
                val_5 = val_1.Length;
        }
        
        val_1[12] = this.availExtraReq;
        val_1[13] = this.extraWordsNeeded;
        return (string)System.String.Format(format:  "GameLevel: word: {0},\nanswers: {1},\nextraWords: {2},\nlevelName: {3},\ncoords: {4},\ngrid: {5},\nlanguage: {6},\navg comp time: {7},\nlevel_progress: {8}, \nwords_count: {9}, \nis_challenging_level: {10}, \ngolden_apples: {11}\naer: {12}, \nextraNeeded:{13}", args:  val_1);
    }
    public void SetupActualWords(int maxAnswersWordCount)
    {
        char[] val_1 = new char[1];
        val_1[0] = 124;
        this.answers = this.answers.TrimEnd(trimChars:  val_1);
        char[] val_3 = new char[1];
        val_3[0] = 124;
        this.extraWords = this.extraWords.TrimEnd(trimChars:  val_3);
    }
    public void MoveExtraWordsToAllWords()
    {
        string val_1 = this.answers + "|"("|");
        this.answers = val_1;
        this.answers = val_1 + this.extraWords;
        this.extraWords = "";
    }
    public void WordRemovalWithUncommonWords(int maxCount = 24, int removePercent = 20, bool removePlurals = True, System.Collections.Generic.List<string> rareWords, System.Collections.Generic.List<string> uncommonWords)
    {
        string val_20;
        var val_21;
        string val_59;
        string val_60;
        var val_62;
        var val_63;
        string val_64;
        int val_65;
        val_59 = this.word;
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_57 = 0;
        val_60 = "";
        label_5:
        if(val_57 >= this.word.m_stringLength)
        {
            goto label_2;
        }
        
        if((val_59.Chars[0] & 65535) != ('|'))
        {
                val_59 = this.word;
            if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
            val_60 = val_60 + val_59.Chars[0].ToString();
        }
        
        val_59 = this.word;
        val_57 = val_57 + 1;
        if(val_59 != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_2:
        char[] val_6 = new char[1];
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6[0] = 124;
        if(this.answers == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_8 = new System.Collections.Generic.List<System.String>(collection:  this.answers.Split(separator:  val_6));
        System.Collections.Generic.List<System.String> val_9 = new System.Collections.Generic.List<System.String>();
        if(this.extraWords != null)
        {
                char[] val_10 = new char[1];
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
            val_10[0] = 124;
            val_59 = val_9;
            if(val_59 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_9.AddRange(collection:  this.extraWords.Split(separator:  val_10));
        }
        
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_12 = 1152921505060011504 * removePercent;
        val_12 = val_12 >> 37;
        int val_16 = UnityEngine.Mathf.Max(a:  val_12 + (val_12 >> 63), b:  1152921505060011504 - maxCount);
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_17 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        RandomSet val_18 = new RandomSet();
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        .replacement = true;
        val_18.add(item:  2, weight:  64f);
        val_18.add(item:  3, weight:  32f);
        val_18.add(item:  4, weight:  16f);
        val_18.add(item:  5, weight:  8f);
        val_18.add(item:  6, weight:  4f);
        val_18.add(item:  7, weight:  2f);
        List.Enumerator<T> val_19 = val_8.GetEnumerator();
        label_23:
        if(val_21.MoveNext() == false)
        {
            goto label_18;
        }
        
        if(val_20 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_17.ContainsKey(key:  val_20 + 16)) == false)
        {
            goto label_21;
        }
        
        val_17.set_Item(key:  val_20 + 16, value:  (val_17.Item[val_20 + 16]) + 1);
        goto label_23;
        label_21:
        val_17.Add(key:  val_20 + 16, value:  1);
        goto label_23;
        label_18:
        val_21.Dispose();
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_17.ContainsKey(key:  3)) == false)
        {
            goto label_26;
        }
        
        int val_58 = val_16;
        if(val_58 <= val_17.Item[3])
        {
            goto label_26;
        }
        
        if(val_58 < 0)
        {
            goto label_27;
        }
        
        val_62 = val_58 - 2;
        goto label_28;
        label_39:
        val_62 = val_62 - 1;
        label_28:
        int val_28 = val_62 + 1;
        if(val_58 <= val_28)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_58 = val_58 + (val_28 << 3);
        val_63 = mem[(val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32];
        val_63 = (val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32;
        if(val_63 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_59 = (val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32 + 16;
        if(val_59 == 3)
        {
                if(val_59 <= val_28)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_59 = val_59 + (((long)(int)((((val_16 - 2) - 1) + 1))) << 3);
            val_64 = mem[((val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32 + 16 + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + 32];
            val_64 = ((val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32 + 16 + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + 32;
        }
        
            if((System.String.op_Inequality(a:  val_64, b:  val_60)) != false)
        {
                if(val_59 <= val_28)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_59 = uncommonWords;
            if(val_59 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_59 = val_59 + (((long)(int)((((val_16 - 2) - 1) + 1))) << 3);
            var val_60 = 1152921513293150832;
            if((val_59.Contains(item:  (((val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32 + 16 + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + 32)) != true)
        {
                if(val_60 <= val_28)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_59 = val_9;
            if(val_59 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_60 = val_60 + (((long)(int)((((val_16 - 2) - 1) + 1))) << 3);
            val_9.Add(item:  (1152921513293150832 + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + 32);
            val_8.RemoveAt(index:  val_28);
            int val_61 = val_16;
            val_61 = val_61 - 1;
        }
        
        }
        
        }
        
        if((val_62 & 2147483648) == 0)
        {
            goto label_39;
        }
        
        label_27:
        bool val_31 = val_17.Remove(key:  3);
        label_26:
        var val_62 = 2;
        do
        {
            if((val_17.ContainsKey(key:  2)) != true)
        {
                val_18.use(item:  2);
        }
        
            val_62 = val_62 + 1;
        }
        while(val_62 != 8);
        
        if(val_61 < 1)
        {
            goto label_62;
        }
        
        var val_65 = 0;
        label_63:
        val_65 = val_18.roll(unweighted:  false);
        if(val_17.Item[val_65] != 1)
        {
            goto label_44;
        }
        
        var val_63 = 0;
        label_45:
        val_65 = val_18.roll(unweighted:  false);
        if(val_63 > 98)
        {
            goto label_44;
        }
        
        val_63 = val_63 + 1;
        if(val_17.Item[val_65] == 1)
        {
            goto label_45;
        }
        
        label_44:
        RandomSet val_37 = new RandomSet();
        if(1152921504858656768 >= 1)
        {
                var val_64 = 0;
            if(1152921504858656768 <= val_64)
        {
                val_59 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(null == 0)
        {
                throw new NullReferenceException();
        }
        
            if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
            val_59 = val_37;
            val_37.add(item:  0, weight:  1f);
            val_64 = val_64 + 1;
        }
        
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_65 = val_65 + 1;
        int val_38 = val_37.roll(unweighted:  false);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((System.String.op_Equality(a:  (ProfilerMemoryBlock.<CleanUp>d__8.__il2cppRuntimeField_name + (val_38) << 3) + 32, b:  val_60)) == true)
        {
            goto label_54;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_59 = uncommonWords;
        if(val_59 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_66 = 1152921513293150832;
        if((val_59.Contains(item:  ((ProfilerMemoryBlock.<CleanUp>d__8.__il2cppRuntimeField_name + (val_38) << 3) + ((long)(int)(val_38)) << 3) + 32)) == false)
        {
            goto label_57;
        }
        
        label_54:
        if(val_65 <= 99)
        {
            goto label_63;
        }
        
        goto label_62;
        label_57:
        if(val_66 <= val_38)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_59 = val_9;
        if(val_59 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_66 = val_66 + (((long)(int)(val_38)) << 3);
        val_9.Add(item:  (1152921513293150832 + ((long)(int)(val_38)) << 3) + 32);
        val_8.RemoveAt(index:  val_38);
        val_17.set_Item(key:  val_65, value:  val_17.Item[val_65] - 1);
        if(val_65 > 99)
        {
            goto label_62;
        }
        
        int val_67 = val_61;
        val_67 = val_67 - 1;
        if(val_67 >= 2)
        {
            goto label_63;
        }
        
        label_62:
        System.Text.StringBuilder val_44 = new System.Text.StringBuilder();
        List.Enumerator<T> val_45 = val_8.GetEnumerator();
        val_60 = rareWords;
        label_69:
        if(val_21.MoveNext() == false)
        {
            goto label_64;
        }
        
        if(val_60 != 0)
        {
                if((val_60.Contains(item:  val_20)) == true)
        {
            goto label_69;
        }
        
        }
        
        if(val_44.Length >= 1)
        {
                System.Text.StringBuilder val_49 = val_44.Append(value:  "|");
        }
        
        System.Text.StringBuilder val_50 = val_44.Append(value:  val_20);
        goto label_69;
        label_64:
        val_21.Dispose();
        if(val_44 == null)
        {
                throw new NullReferenceException();
        }
        
        this.answers = val_44;
        System.Text.StringBuilder val_51 = new System.Text.StringBuilder();
        val_59 = val_9;
        if(val_59 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_52 = val_9.GetEnumerator();
        label_75:
        if(val_21.MoveNext() == false)
        {
            goto label_72;
        }
        
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_51.Length >= 1)
        {
                System.Text.StringBuilder val_55 = val_51.Append(value:  "|");
        }
        
        System.Text.StringBuilder val_56 = val_51.Append(value:  val_20);
        goto label_75;
        label_72:
        val_21.Dispose();
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        this.extraWords = val_51;
        this.WordRemoval(maxCount:  maxCount, removePercent:  removePercent, removePlurals:  false, rareWords:  val_60);
    }
    public void WordRemoval(int maxCount = 24, int removePercent = 20, bool removePlurals = True, System.Collections.Generic.List<string> rareWords)
    {
        string val_20;
        var val_21;
        string val_57;
        int val_58;
        var val_60;
        var val_61;
        string val_62;
        var val_63;
        val_57 = this.word;
        if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_54 = 0;
        label_5:
        if(val_54 >= this.word.m_stringLength)
        {
            goto label_2;
        }
        
        if((val_57.Chars[0] & 65535) != ('|'))
        {
                val_57 = this.word;
            if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
            string val_5 = "" + val_57.Chars[0].ToString();
        }
        
        val_57 = this.word;
        val_54 = val_54 + 1;
        if(val_57 != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_2:
        char[] val_6 = new char[1];
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6[0] = 124;
        if(this.answers == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_8 = new System.Collections.Generic.List<System.String>(collection:  this.answers.Split(separator:  val_6));
        System.Collections.Generic.List<System.String> val_9 = new System.Collections.Generic.List<System.String>();
        if(this.extraWords != null)
        {
                char[] val_10 = new char[1];
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
            val_10[0] = 124;
            val_57 = val_9;
            if(val_57 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_9.AddRange(collection:  this.extraWords.Split(separator:  val_10));
        }
        
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_12 = 1152921505060011504 * removePercent;
        val_12 = val_12 >> 37;
        int val_16 = UnityEngine.Mathf.Max(a:  val_12 + (val_12 >> 63), b:  1152921505060011504 - maxCount);
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_17 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        RandomSet val_18 = new RandomSet();
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        .replacement = true;
        val_18.add(item:  2, weight:  64f);
        val_18.add(item:  3, weight:  32f);
        val_18.add(item:  4, weight:  16f);
        val_18.add(item:  5, weight:  8f);
        val_18.add(item:  6, weight:  4f);
        val_18.add(item:  7, weight:  2f);
        List.Enumerator<T> val_19 = val_8.GetEnumerator();
        val_58 = 1152921515438575024;
        label_23:
        if(val_21.MoveNext() == false)
        {
            goto label_18;
        }
        
        if(val_20 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_17.ContainsKey(key:  val_20 + 16)) == false)
        {
            goto label_21;
        }
        
        val_17.set_Item(key:  val_20 + 16, value:  (val_17.Item[val_20 + 16]) + 1);
        goto label_23;
        label_21:
        val_17.Add(key:  val_20 + 16, value:  1);
        goto label_23;
        label_18:
        val_21.Dispose();
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_17.ContainsKey(key:  3)) == false)
        {
            goto label_26;
        }
        
        int val_55 = val_16;
        if(val_55 <= val_17.Item[3])
        {
            goto label_26;
        }
        
        if(val_55 < 0)
        {
            goto label_27;
        }
        
        val_60 = val_55 - 2;
        goto label_28;
        label_36:
        val_60 = val_60 - 1;
        label_28:
        val_58 = val_60 + 1;
        if(val_55 <= val_58)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_55 = val_55 + (val_58 << 3);
        val_61 = mem[(val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32];
        val_61 = (val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32;
        if(val_61 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_56 = (val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32 + 16;
        if(val_56 == 3)
        {
                if(val_56 <= val_58)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_56 = val_56 + (((long)(int)((((val_16 - 2) - 1) + 1))) << 3);
            val_62 = mem[((val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32 + 16 + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + 32];
            val_62 = ((val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32 + 16 + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + 32;
        }
        
            if((System.String.op_Inequality(a:  val_62, b:  "")) != false)
        {
                if(val_56 <= val_58)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_57 = val_9;
            if(val_57 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_56 = val_56 + (((long)(int)((((val_16 - 2) - 1) + 1))) << 3);
            val_9.Add(item:  (((val_16 + ((((val_16 - 2) - 1) + 1)) << 3) + 32 + 16 + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + ((long)(int)((((val_16 - 2) - 1) + 1))) << 3) + 32);
            val_8.RemoveAt(index:  val_58);
            int val_57 = val_16;
            val_57 = val_57 - 1;
        }
        
        }
        
        if((val_60 & 2147483648) == 0)
        {
            goto label_36;
        }
        
        label_27:
        bool val_29 = val_17.Remove(key:  3);
        label_26:
        var val_58 = 2;
        do
        {
            if((val_17.ContainsKey(key:  2)) != true)
        {
                val_18.use(item:  2);
        }
        
            val_58 = val_58 + 1;
        }
        while(val_58 != 8);
        
        val_63 = 0;
        goto label_52;
        label_55:
        if(val_57 <= 0)
        {
            goto label_40;
        }
        
        val_58 = val_18.roll(unweighted:  false);
        if(val_17.Item[val_58] != 1)
        {
            goto label_42;
        }
        
        var val_59 = 0;
        label_43:
        val_58 = val_18.roll(unweighted:  false);
        if(val_59 > 98)
        {
            goto label_42;
        }
        
        val_59 = val_59 + 1;
        if(val_17.Item[val_58] == 1)
        {
            goto label_43;
        }
        
        label_42:
        RandomSet val_35 = new RandomSet();
        if(1152921504858656768 >= 1)
        {
                var val_60 = 0;
            if(1152921504858656768 <= val_60)
        {
                val_57 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(null == 0)
        {
                throw new NullReferenceException();
        }
        
            if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
            val_57 = val_35;
            val_35.add(item:  0, weight:  1f);
            val_60 = val_60 + 1;
        }
        
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_63 = 1;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((System.String.op_Equality(a:  (ProfilerMemoryBlock.<CleanUp>d__8.__il2cppRuntimeField_name + (val_36) << 3) + 32, b:  "")) != true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_57 = val_9;
            if(val_57 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_9.Add(item:  ((ProfilerMemoryBlock.<CleanUp>d__8.__il2cppRuntimeField_name + (val_36) << 3) + ((long)(int)(val_36)) << 3) + 32);
            val_8.RemoveAt(index:  val_35.roll(unweighted:  false));
            int val_61 = val_57;
            val_61 = val_61 - 1;
            val_17.set_Item(key:  val_58, value:  val_17.Item[val_58] - 1);
        }
        
        label_52:
        if(val_63 <= 99)
        {
            goto label_55;
        }
        
        label_40:
        System.Text.StringBuilder val_41 = new System.Text.StringBuilder();
        List.Enumerator<T> val_42 = val_8.GetEnumerator();
        label_61:
        if(val_21.MoveNext() == false)
        {
            goto label_56;
        }
        
        if(rareWords != 0)
        {
                if((rareWords.Contains(item:  val_20)) == true)
        {
            goto label_61;
        }
        
        }
        
        if(val_41.Length >= 1)
        {
                System.Text.StringBuilder val_46 = val_41.Append(value:  "|");
        }
        
        System.Text.StringBuilder val_47 = val_41.Append(value:  val_20);
        goto label_61;
        label_56:
        val_21.Dispose();
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        this.answers = val_41;
        System.Text.StringBuilder val_48 = new System.Text.StringBuilder();
        val_57 = val_9;
        if(val_57 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_49 = val_9.GetEnumerator();
        label_67:
        if(val_21.MoveNext() == false)
        {
            goto label_64;
        }
        
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_48.Length >= 1)
        {
                System.Text.StringBuilder val_52 = val_48.Append(value:  "|");
        }
        
        System.Text.StringBuilder val_53 = val_48.Append(value:  val_20);
        goto label_67;
        label_64:
        val_21.Dispose();
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        this.extraWords = val_48;
    }
    public string ToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "word", value:  this.word);
        val_1.Add(key:  "answers", value:  this.answers);
        val_1.Add(key:  "extraWords", value:  this.extraWords);
        val_1.Add(key:  "levelName", value:  this.lvlName);
        val_1.Add(key:  "playerLevel", value:  this.playerLevel);
        val_1.Add(key:  "coords", value:  this.coords);
        val_1.Add(key:  "gridSize", value:  this.gridSize);
        val_1.Add(key:  "completed", value:  this.completed);
        val_1.Add(key:  "availExtraReq", value:  this.availExtraReq);
        val_1.Add(key:  "avgCompletionTime", value:  this.avgCompletionTime);
        val_1.Add(key:  "levelProgress", value:  this.levelProgress);
        val_1.Add(key:  "wordsCount", value:  this.actualWordCount);
        val_1.Add(key:  "isChallengingLevel", value:  this.isChallengingLevel);
        val_1.Add(key:  "goldenApplesExDifficulty", value:  this.goldenApplesExtraDifficulty);
        val_1.Add(key:  "goldenApplesStreaks", value:  this.goldenApplesStreaks);
        val_1.Add(key:  "goldenApplesStreaksSub", value:  this.goldenApplesStreaksSubBonus);
        val_1.Add(key:  "goldenApplesExWords", value:  this.goldenApplesExtraWords);
        val_1.Add(key:  "goldenApplesExWordsSub", value:  this.goldenApplesExtraWordsSubBonus);
        val_1.Add(key:  "highestWordStreak", value:  this.highestWordStreak);
        GameBehavior val_2 = App.getBehavior;
        string val_3 = val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        this.language = val_3;
        val_1.Add(key:  "language", value:  val_3);
        return (string)MiniJSON.Json.Serialize(obj:  val_1);
    }
    public void FromJSON(string jsonString)
    {
        string val_37;
        var val_38;
        string val_66;
        object val_1 = MiniJSON.Json.Deserialize(json:  jsonString);
        if((val_1.ContainsKey(key:  "word")) != false)
        {
                this.word = val_1.Item["word"];
        }
        
        if((val_1.ContainsKey(key:  "answers")) != false)
        {
                this.answers = val_1.Item["answers"];
        }
        
        if((val_1.ContainsKey(key:  "extraWords")) != false)
        {
                if(val_1.Item["extraWords"] != null)
        {
                this.extraWords = val_1.Item["extraWords"];
        }
        
        }
        
        if((val_1.ContainsKey(key:  "levelName")) != false)
        {
                this.levelName = val_1.Item["levelName"];
        }
        
        if((val_1.ContainsKey(key:  "playerLevel")) != false)
        {
                this.playerLevel = System.Int32.Parse(s:  val_1.Item["playerLevel"], style:  511);
        }
        
        if((val_1.ContainsKey(key:  "coords")) != false)
        {
                if(val_1.Item["coords"] != null)
        {
                this.coords = val_1.Item["coords"];
        }
        
        }
        
        if((val_1.ContainsKey(key:  "gridSize")) != false)
        {
                if(val_1.Item["gridSize"] != null)
        {
                this.gridSize = val_1.Item["gridSize"];
        }
        
        }
        
        if((val_1.ContainsKey(key:  "completed")) != false)
        {
                this.completed = System.Boolean.Parse(value:  val_1.Item["completed"]);
        }
        
        if((val_1.ContainsKey(key:  "availExtraReq")) != false)
        {
                if(val_1.Item["availExtraReq"] != null)
        {
                this.availExtraReq = val_1.Item["availExtraReq"];
        }
        
        }
        
        if((val_1.ContainsKey(key:  "avgCompletionTime")) != false)
        {
                this.avgCompletionTime = System.Single.Parse(s:  val_1.Item["avgCompletionTime"], style:  511);
        }
        
        if((val_1.ContainsKey(key:  "language")) != false)
        {
                this.language = val_1.Item["language"];
        }
        
        if((val_1.ContainsKey(key:  "levelProgress")) == false)
        {
            goto label_42;
        }
        
        object val_33 = val_1.Item["levelProgress"];
        this.levelProgress = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_36 = GetEnumerator();
        label_41:
        val_66 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_38.MoveNext() == false)
        {
            goto label_38;
        }
        
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_66 = val_37;
        if(this.levelProgress == null)
        {
                throw new NullReferenceException();
        }
        
        this.levelProgress.Add(item:  val_66);
        goto label_41;
        label_38:
        val_38.Dispose();
        if((val_1.ContainsKey(key:  "wordsCount")) != false)
        {
                this.actualWordCount = System.Int32.Parse(s:  val_1.Item["wordsCount"]);
        }
        
        label_42:
        if((val_1.ContainsKey(key:  "isChallengingLevel")) != false)
        {
                this.isChallengingLevel = System.Boolean.Parse(value:  val_1.Item["isChallengingLevel"]);
        }
        
        if((val_1.ContainsKey(key:  "goldenApplesExDifficulty")) != false)
        {
                this.goldenApplesExtraDifficulty = System.Int32.Parse(s:  val_1.Item["goldenApplesExDifficulty"]);
        }
        
        if((val_1.ContainsKey(key:  "goldenApplesStreaks")) != false)
        {
                this.goldenApplesStreaks = System.Int32.Parse(s:  val_1.Item["goldenApplesStreaks"]);
        }
        
        if((val_1.ContainsKey(key:  "goldenApplesStreaksSub")) != false)
        {
                this.goldenApplesStreaksSubBonus = System.Int32.Parse(s:  val_1.Item["goldenApplesStreaksSub"]);
        }
        
        if((val_1.ContainsKey(key:  "goldenApplesExWords")) != false)
        {
                this.goldenApplesExtraWords = System.Int32.Parse(s:  val_1.Item["goldenApplesExWords"]);
        }
        
        if((val_1.ContainsKey(key:  "goldenApplesExWordsSub")) != false)
        {
                this.goldenApplesExtraWordsSubBonus = System.Int32.Parse(s:  val_1.Item["goldenApplesExWordsSub"]);
        }
        
        if((val_1.ContainsKey(key:  "highestWordStreak")) == false)
        {
                return;
        }
        
        this.highestWordStreak = System.Int32.Parse(s:  val_1.Item["highestWordStreak"]);
    }
    public string Serialize()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_2 = val_1.Append(value:  this.word);
        System.Text.StringBuilder val_3 = val_1.Append(value:  "#");
        System.Text.StringBuilder val_4 = val_1.Append(value:  this.answers);
        System.Text.StringBuilder val_5 = val_1.Append(value:  "#");
        System.Text.StringBuilder val_6 = val_1.Append(value:  this.extraWords);
        System.Text.StringBuilder val_7 = val_1.Append(value:  "#");
        System.Text.StringBuilder val_8 = val_1.Append(value:  this.lvlName);
        System.Text.StringBuilder val_9 = val_1.Append(value:  "#");
        System.Text.StringBuilder val_10 = val_1.Append(value:  this.coords);
        System.Text.StringBuilder val_11 = val_1.Append(value:  "#");
        System.Text.StringBuilder val_12 = val_1.Append(value:  this.gridSize);
        System.Text.StringBuilder val_13 = val_1.Append(value:  "#");
        System.Text.StringBuilder val_14 = val_1.Append(value:  this.availExtraReq);
        System.Text.StringBuilder val_15 = val_1.Append(value:  "#");
        GameBehavior val_16 = App.getBehavior;
        string val_17 = val_16.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        this.language = val_17;
        System.Text.StringBuilder val_18 = val_1.Append(value:  val_17);
        System.Text.StringBuilder val_19 = val_1.Append(value:  "#");
        System.Text.StringBuilder val_20 = val_1.Append(value:  this.avgCompletionTime);
        goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
    }
    public static GameLevel Deserialize(string data)
    {
        var val_7;
        int val_8;
        var val_9;
        if(data == null)
        {
            goto label_1;
        }
        
        val_7 = 0;
        if((System.String.op_Equality(a:  data, b:  "")) == true)
        {
                return (GameLevel)val_7;
        }
        
        GameLevel val_2 = null;
        val_7 = val_2;
        val_2 = new GameLevel();
        char[] val_3 = new char[1];
        val_3[0] = '#';
        System.String[] val_4 = data.Split(separator:  val_3);
        .word = val_4[0];
        .answers = val_4[1];
        .extraWords = val_4[2];
        val_2.levelName = val_4[3];
        .coords = val_4[4];
        .gridSize = val_4[5];
        val_8 = val_4.Length;
        if(val_8 < 7)
        {
            goto label_13;
        }
        
        .availExtraReq = val_4[6];
        val_8 = val_4.Length;
        val_9 = 7;
        goto label_14;
        label_1:
        val_7 = 0;
        return (GameLevel)val_7;
        label_13:
        val_9 = 6;
        label_14:
        if(val_9 < val_8)
        {
                val_9 = val_9 + 1;
            .language = val_4[val_9];
            val_8 = val_4.Length;
        }
        
        if(val_9 >= val_8)
        {
                return (GameLevel)val_7;
        }
        
        bool val_6 = System.Single.TryParse(s:  val_4[val_9], result: out  (GameLevel)[1152921515440453712].avgCompletionTime);
        return (GameLevel)val_7;
    }
    public GameLevel()
    {
        this.levelProgress = new System.Collections.Generic.List<System.String>();
        this.extraRequiredWords = "";
        this.challengeWord = "";
    }

}
