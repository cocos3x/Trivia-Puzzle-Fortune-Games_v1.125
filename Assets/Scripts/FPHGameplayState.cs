using UnityEngine;
public class FPHGameplayState
{
    // Fields
    private FPHLevelObject <levelData>k__BackingField;
    private int <levelIndex>k__BackingField;
    private int <removesUsed>k__BackingField;
    public System.Collections.Generic.List<char> lettersPowerupRemoved;
    public bool solveModeUsedToAnswer;
    public int starsEarned;
    private int <hintsUsed>k__BackingField;
    private int <tokensRemaining>k__BackingField;
    public int eventReward;
    public int retryAttempts;
    private System.Collections.Generic.List<object> tokenTransactionsMade;
    private System.Collections.Generic.List<object> gemTransactionsMade;
    public System.Collections.Generic.List<char> lettersPurchased;
    public char currentTutorialLetter;
    public int trackingLevel;
    public System.Collections.Generic.Dictionary<string, object> associatedEvents;
    public int consonantsPurchased;
    public int vowelsPurchased;
    public System.Collections.Generic.List<FPHLetterSlotState> phraseSlotState;
    public System.Collections.Generic.List<char> phraseSlotDisplayValue;
    public string phraseSlotCorrectValue;
    private string _phraseSlotCorrectValueNormalizedNotSerialized;
    public FPHChestType chestType;
    public int rewardMultiplier;
    public bool hasCollectedChest;
    
    // Properties
    public FPHLevelObject levelData { get; set; }
    public int levelIndex { get; set; }
    public int removesUsed { get; set; }
    public int hintsUsed { get; set; }
    public int tokensRemaining { get; set; }
    public string phraseSlotCorrectValueNormalized { get; }
    
    // Methods
    public FPHLevelObject get_levelData()
    {
        return (FPHLevelObject)this.<levelData>k__BackingField;
    }
    public void set_levelData(FPHLevelObject value)
    {
        this.<levelData>k__BackingField = value;
    }
    public int get_levelIndex()
    {
        return (int)this.<levelIndex>k__BackingField;
    }
    public void set_levelIndex(int value)
    {
        this.<levelIndex>k__BackingField = value;
    }
    public int get_removesUsed()
    {
        return (int)this.<removesUsed>k__BackingField;
    }
    public void set_removesUsed(int value)
    {
        this.<removesUsed>k__BackingField = value;
    }
    public int get_hintsUsed()
    {
        return (int)this.<hintsUsed>k__BackingField;
    }
    public void set_hintsUsed(int value)
    {
        this.<hintsUsed>k__BackingField = value;
    }
    public int get_tokensRemaining()
    {
        return (int)this.<tokensRemaining>k__BackingField;
    }
    public void set_tokensRemaining(int value)
    {
        this.<tokensRemaining>k__BackingField = value;
    }
    public string get_phraseSlotCorrectValueNormalized()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this._phraseSlotCorrectValueNormalizedNotSerialized);
        if(val_1 == false)
        {
                return (string)this._phraseSlotCorrectValueNormalizedNotSerialized;
        }
        
        string val_2 = val_1.RemoveDiacritics(s:  this.phraseSlotCorrectValue);
        this._phraseSlotCorrectValueNormalizedNotSerialized = val_2;
        this._phraseSlotCorrectValueNormalizedNotSerialized = val_2.ReplaceSpecialCharacters(s:  val_2);
        object[] val_4 = new object[1];
        val_4[0] = this._phraseSlotCorrectValueNormalizedNotSerialized;
        UnityEngine.Debug.LogErrorFormat(format:  "normalized: {0}", args:  val_4);
        return (string)this._phraseSlotCorrectValueNormalizedNotSerialized;
    }
    private string RemoveDiacritics(string s)
    {
        System.Text.NormalizationForm val_6 = 2;
        if(val_2.m_stringLength >= 0)
        {
                var val_6 = 0;
            do
        {
            char val_3 = s.Normalize(normalizationForm:  val_6 = 2).Chars[0];
            val_6 = 0;
            if((System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch:  val_3)) != 5)
        {
                val_6 = val_3;
            System.Text.StringBuilder val_5 = new System.Text.StringBuilder().Append(value:  val_6);
        }
        
            int val_7 = val_2.m_stringLength;
            val_6 = val_6 + 1;
            val_7 = val_7 - 1;
        }
        while(val_6 <= val_7);
        
        }
    
    }
    private string ReplaceSpecialCharacters(string s)
    {
        return s.Replace(oldValue:  "ß", newValue:  "S");
    }
    public string GetCurrentDisplayString()
    {
        var val_3 = 0;
        label_5:
        if(val_3 >= 1152921504630968320)
        {
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        
        if(val_3 >= 44292424)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Text.StringBuilder val_2 = new System.Text.StringBuilder().Append(value:  '핰');
        val_3 = val_3 + 1;
        if(this.phraseSlotDisplayValue != null)
        {
            goto label_5;
        }
        
        goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
    }
    public bool IsCurrentDisplayCorrectAnswer()
    {
        return System.String.op_Equality(a:  this.GetCurrentDisplayString(), b:  this.phraseSlotCorrectValue);
    }
    public int GetTotalCoinReward()
    {
        return (int)this.rewardMultiplier * (this.<tokensRemaining>k__BackingField);
    }
    public int GetTotalStarReward()
    {
        return (int)this.eventReward + (this.rewardMultiplier * this.starsEarned);
    }
    public static bool Deserialize(string dataString, ref FPHGameplayState stateToLoad)
    {
        char val_15;
        var val_16;
        string val_80;
        char val_81;
        string val_82;
        var val_83;
        var val_84;
        var val_85;
        var val_86;
        val_80 = 0;
        object val_1 = MiniJSON.Json.Deserialize(json:  dataString);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_82 = val_1;
        object val_3 = MiniJSON.Json.Deserialize(json:  val_82);
        if(val_3 != null)
        {
                val_82 = val_3;
        }
        
        UnityEngine.Debug.LogError(message:  "null loaded data");
        do
        {
            return false;
        }
        while((val_82.ContainsKey(key:  "rmvUs")) == false);
        
        val_80 = "rmvUs";
        object val_9 = val_82.Item[val_80];
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_9, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                <removesUsed>k__BackingField = 0;
        }
        
        if((val_82.ContainsKey(key:  "lettPwpRmvd")) == false)
        {
                return false;
        }
        
        object val_12 = val_82.Item["lettPwpRmvd"];
        if((val_12 == null) || (stateToLoad == null))
        {
            goto label_21;
        }
        
        lettersPowerupRemoved = new System.Collections.Generic.List<System.Char>();
        List.Enumerator<T> val_14 = val_12.GetEnumerator();
        label_27:
        val_80 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_16.MoveNext() == false)
        {
            goto label_22;
        }
        
        val_81 = val_15;
        if(val_81 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_80 = null;
        if(stateToLoad == null)
        {
                throw new NullReferenceException();
        }
        
        if(stateToLoad.lettersPowerupRemoved == null)
        {
                throw new NullReferenceException();
        }
        
        stateToLoad.lettersPowerupRemoved.Add(item:  val_81);
        goto label_27;
        label_22:
        val_16.Dispose();
        label_21:
        if((val_82.ContainsKey(key:  "stEarn")) == false)
        {
                return false;
        }
        
        val_80 = "stEarn";
        object val_19 = val_82.Item[val_80];
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_19, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                starsEarned = 0;
        }
        
        if((val_82.ContainsKey(key:  "hntUsd")) == false)
        {
                return false;
        }
        
        val_80 = "hntUsd";
        object val_22 = val_82.Item[val_80];
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_22, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                <hintsUsed>k__BackingField = 0;
        }
        
        if((val_82.ContainsKey(key:  "tknRem")) == false)
        {
                return false;
        }
        
        val_80 = "tknRem";
        object val_25 = val_82.Item[val_80];
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_25, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                <tokensRemaining>k__BackingField = 0;
        }
        
        if((val_82.ContainsKey(key:  "evntRwd")) == false)
        {
                return false;
        }
        
        val_80 = "evntRwd";
        object val_28 = val_82.Item[val_80];
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_28, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                eventReward = 0;
        }
        
        if((val_82.ContainsKey(key:  "rtyAtt")) == false)
        {
                return false;
        }
        
        val_80 = "rtyAtt";
        object val_31 = val_82.Item[val_80];
        if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_31, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                retryAttempts = 0;
        }
        
        if((val_82.ContainsKey(key:  "tknTrns")) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                val_80 = "tknTrns";
            object val_34 = val_82.Item[val_80];
            val_83 = 0;
            tokenTransactionsMade = ;
            if(stateToLoad == null)
        {
                throw new NullReferenceException();
        }
        
            if(stateToLoad.tokenTransactionsMade == null)
        {
                tokenTransactionsMade = new System.Collections.Generic.List<System.Object>();
        }
        
        }
        
        if((val_82.ContainsKey(key:  "gmTrns")) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                val_80 = "gmTrns";
            object val_38 = val_82.Item[val_80];
            val_84 = 0;
            gemTransactionsMade = ;
            if(stateToLoad == null)
        {
                throw new NullReferenceException();
        }
        
            if(stateToLoad.gemTransactionsMade == null)
        {
                gemTransactionsMade = new System.Collections.Generic.List<System.Object>();
        }
        
        }
        
        if((val_82.ContainsKey(key:  "lttPrch")) == false)
        {
                return false;
        }
        
        if(stateToLoad == null)
        {
            goto label_69;
        }
        
        object val_42 = val_82.Item["lttPrch"];
        val_85 = 0;
        System.Collections.Generic.List<System.Char> val_44 = null;
        val_80 = public System.Void System.Collections.Generic.List<System.Char>::.ctor();
        val_44 = new System.Collections.Generic.List<System.Char>();
        if(stateToLoad == null)
        {
                throw new NullReferenceException();
        }
        
        lettersPurchased = val_44;
        List.Enumerator<T> val_45 = GetEnumerator();
        label_76:
        val_80 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_16.MoveNext() == false)
        {
            goto label_70;
        }
        
        if(stateToLoad == null)
        {
                throw new NullReferenceException();
        }
        
        val_81 = val_15;
        if(val_81 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_81 = val_81;
        val_80 = System.Char.Parse(s:  val_81);
        if(stateToLoad.lettersPurchased == null)
        {
                throw new NullReferenceException();
        }
        
        stateToLoad.lettersPurchased.Add(item:  val_80);
        goto label_76;
        label_70:
        val_16.Dispose();
        label_69:
        char val_50 = 32;
        if((val_82.ContainsKey(key:  "tutChar")) == false)
        {
                return false;
        }
        
        val_80 = "tutChar";
        object val_49 = val_82.Item[val_80];
        if(val_49 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Char.TryParse(s:  val_49, result: out  val_50)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                currentTutorialLetter = val_50;
        }
        
        if((val_82.ContainsKey(key:  "lvl")) == false)
        {
                return false;
        }
        
        val_80 = "lvl";
        object val_53 = val_82.Item[val_80];
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_53, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                trackingLevel = 0;
        }
        
        if((val_82.ContainsKey(key:  "cnsPurch")) == false)
        {
                return false;
        }
        
        val_80 = "cnsPurch";
        object val_56 = val_82.Item[val_80];
        if(val_56 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_56, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                consonantsPurchased = 0;
        }
        
        if((val_82.ContainsKey(key:  "vwlPurch")) == false)
        {
                return false;
        }
        
        val_80 = "vwlPurch";
        object val_59 = val_82.Item[val_80];
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_59, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                vowelsPurchased = 0;
        }
        
        if((val_82.ContainsKey(key:  "vwlPurch")) == false)
        {
                return false;
        }
        
        val_80 = "vwlPurch";
        object val_62 = val_82.Item[val_80];
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_62, result: out  null)) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                vowelsPurchased = 0;
        }
        
        if((val_82.ContainsKey(key:  "phrsSS")) == false)
        {
                return false;
        }
        
        if(stateToLoad != null)
        {
                object val_65 = val_82.Item["phrsSS"];
            System.Collections.Generic.List<System.Object> val_66 = new System.Collections.Generic.List<System.Object>();
        }
        
        label_131:
        if((val_82.ContainsKey(key:  "phrsSDV")) == false)
        {
                return false;
        }
        
        if(stateToLoad == null)
        {
            goto label_111;
        }
        
        object val_68 = val_82.Item["phrsSDV"];
        val_86 = 0;
        System.Collections.Generic.List<System.Char> val_70 = null;
        val_80 = public System.Void System.Collections.Generic.List<System.Char>::.ctor();
        val_70 = new System.Collections.Generic.List<System.Char>();
        if(stateToLoad == null)
        {
                throw new NullReferenceException();
        }
        
        phraseSlotDisplayValue = val_70;
        List.Enumerator<T> val_71 = GetEnumerator();
        label_118:
        val_80 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_16.MoveNext() == false)
        {
            goto label_112;
        }
        
        if(stateToLoad == null)
        {
                throw new NullReferenceException();
        }
        
        val_81 = val_15;
        if(val_81 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_81 = val_81;
        val_80 = System.Char.Parse(s:  val_81);
        if(stateToLoad.phraseSlotDisplayValue == null)
        {
                throw new NullReferenceException();
        }
        
        stateToLoad.phraseSlotDisplayValue.Add(item:  val_80);
        goto label_118;
        label_112:
        val_16.Dispose();
        if((0 == 1) || (1349 != 1349))
        {
                return false;
        }
        
        label_111:
        if((val_82.ContainsKey(key:  "phrSCV")) == false)
        {
                return false;
        }
        
        if(stateToLoad == null)
        {
                return false;
        }
        
        val_80 = "phrSCV";
        object val_75 = val_82.Item[val_80];
        if(val_75 == null)
        {
                throw new NullReferenceException();
        }
        
        phraseSlotCorrectValue = val_75;
        return false;
        label_129:
        val_80 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_16.MoveNext() == false)
        {
            goto label_125;
        }
        
        val_81 = val_15;
        if(val_81 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_80 = null;
        Add(item:  val_81);
        goto label_129;
        label_125:
        val_80 = public System.Void List.Enumerator<System.Object>::Dispose();
        val_16.Dispose();
        if(stateToLoad == null)
        {
                throw new NullReferenceException();
        }
        
        phraseSlotState = ;
        goto label_131;
    }
    public string Serialize()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "lvlI", value:  this.<levelIndex>k__BackingField);
        val_1.Add(key:  "rmvUs", value:  this.<removesUsed>k__BackingField);
        val_1.Add(key:  "lettPwpRmvd", value:  this.lettersPowerupRemoved);
        val_1.Add(key:  "stEarn", value:  this.starsEarned);
        val_1.Add(key:  "hntUsd", value:  this.<hintsUsed>k__BackingField);
        val_1.Add(key:  "tknRem", value:  this.<tokensRemaining>k__BackingField);
        val_1.Add(key:  "evntRwd", value:  this.eventReward);
        val_1.Add(key:  "rtyAtt", value:  this.retryAttempts);
        val_1.Add(key:  "tknTrns", value:  this.tokenTransactionsMade);
        val_1.Add(key:  "gmTrns", value:  this.gemTransactionsMade);
        val_1.Add(key:  "lttPrch", value:  this.lettersPurchased);
        val_1.Add(key:  "tutChar", value:  this.currentTutorialLetter);
        val_1.Add(key:  "lvl", value:  this.trackingLevel);
        val_1.Add(key:  "cnsPurch", value:  this.consonantsPurchased);
        val_1.Add(key:  "vwlPurch", value:  this.vowelsPurchased);
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        List.Enumerator<T> val_3 = this.phraseSlotState.GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(item:  0);
        goto label_5;
        label_3:
        0.Dispose();
        val_1.Add(key:  "phrsSS", value:  val_2);
        val_1.Add(key:  "phrsSDV", value:  this.phraseSlotDisplayValue);
        val_1.Add(key:  "phrSCV", value:  this.phraseSlotCorrectValue);
        return (string)MiniJSON.Json.Serialize(obj:  val_1);
    }
    public FPHGameplayState()
    {
        this.lettersPowerupRemoved = new System.Collections.Generic.List<System.Char>();
        this.tokenTransactionsMade = new System.Collections.Generic.List<System.Object>();
        this.gemTransactionsMade = new System.Collections.Generic.List<System.Object>();
        this.lettersPurchased = new System.Collections.Generic.List<System.Char>();
        this.currentTutorialLetter = 32;
        this.associatedEvents = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.phraseSlotState = new System.Collections.Generic.List<FPHLetterSlotState>();
        this.phraseSlotDisplayValue = new System.Collections.Generic.List<System.Char>();
        this.chestType = 2.12199579244747E-314;
    }

}
