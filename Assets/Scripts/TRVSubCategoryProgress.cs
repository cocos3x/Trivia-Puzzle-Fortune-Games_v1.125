using UnityEngine;
public class TRVSubCategoryProgress
{
    // Fields
    public System.Collections.Generic.Dictionary<int, int> seenQuestions;
    public int incorrectQuestions;
    public int quizzesComplete;
    public int crownsCollected;
    public int rank;
    public int rankProgress;
    public bool isFinished;
    
    // Properties
    public int totalQuestionsSeen { get; }
    
    // Methods
    public int get_totalQuestionsSeen()
    {
        var val_2;
        System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>, System.Int32> val_4;
        val_2 = null;
        val_2 = null;
        val_4 = TRVSubCategoryProgress.<>c.<>9__8_0;
        if(val_4 != null)
        {
                return System.Linq.Enumerable.Sum<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>>(source:  this.seenQuestions, selector:  System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>, System.Int32> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>, System.Int32>(object:  TRVSubCategoryProgress.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVSubCategoryProgress.<>c::<get_totalQuestionsSeen>b__8_0(System.Collections.Generic.KeyValuePair<int, int> x));
        TRVSubCategoryProgress.<>c.<>9__8_0 = val_4;
        return System.Linq.Enumerable.Sum<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>>(source:  this.seenQuestions, selector:  val_1);
    }
    public int SeenQuestionsPerDifficulty(int diff)
    {
        if((this.seenQuestions.ContainsKey(key:  diff)) == true)
        {
                return this.seenQuestions.Item[diff];
        }
        
        this.seenQuestions.Add(key:  diff, value:  0);
        return this.seenQuestions.Item[diff];
    }
    public void ResetCat()
    {
        this.incorrectQuestions = 0;
        this.quizzesComplete = 0;
        this.crownsCollected = 0;
        this.rank = 0;
        this.seenQuestions = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        mem[1152921517327914517] = 0;
    }
    public string encode()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "incorrect", value:  this.incorrectQuestions);
        val_1.Add(key:  "progress", value:  this.seenQuestions);
        val_1.Add(key:  "completedQuiz", value:  this.quizzesComplete);
        val_1.Add(key:  "crowns", value:  this.crownsCollected);
        val_1.Add(key:  "rank", value:  this.rank);
        val_1.Add(key:  "rankProgress", value:  this.rankProgress);
        val_1.Add(key:  "finished", value:  this.isFinished);
        return (string)MiniJSON.Json.Serialize(obj:  val_1);
    }
    public bool decode(string data)
    {
        string val_10;
        var val_11;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_36;
        var val_37;
        var val_38;
        string val_39;
        var val_40;
        object val_1 = MiniJSON.Json.Deserialize(json:  data);
        val_36 = 1152921504685600768;
        val_37 = 1152921510222861648;
        if((val_1.ContainsKey(key:  "progress")) == false)
        {
            goto label_32;
        }
        
        object val_3 = val_1.Item["progress"];
        val_38 = 0;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_5 = null;
        val_36 = val_5;
        val_5 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        if(Keys.Count < 1)
        {
            goto label_41;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_9 = Keys.GetEnumerator();
        label_16:
        if(val_11.MoveNext() == false)
        {
            goto label_12;
        }
        
        val_39 = val_10;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        if(Item[val_39] == null)
        {
                throw new NullReferenceException();
        }
        
        val_39 = null;
        val_5.Add(key:  System.Int32.Parse(s:  val_10), value:  19914752);
        goto label_16;
        label_12:
        val_11.Dispose();
        val_37 = 1152921510222861648;
        label_41:
        if(val_36 == null)
        {
            goto label_17;
        }
        
        this.seenQuestions = val_36;
        val_36 = "incorrect";
        if(((val_1.ContainsKey(key:  "incorrect")) == false) || ((System.Int32.TryParse(s:  val_1.Item["incorrect"], result: out  this.incorrectQuestions)) == false))
        {
            goto label_32;
        }
        
        val_36 = "completedQuiz";
        if(((val_1.ContainsKey(key:  "completedQuiz")) == false) || ((System.Int32.TryParse(s:  val_1.Item["completedQuiz"], result: out  this.quizzesComplete)) == false))
        {
            goto label_32;
        }
        
        val_36 = "finished";
        if((val_1.ContainsKey(key:  "finished")) == false)
        {
            goto label_32;
        }
        
        val_36 = val_1.Item["finished"];
        if((System.Boolean.TryParse(value:  val_36, result: out  this.isFinished)) == false)
        {
            goto label_32;
        }
        
        val_36 = "rank";
        if(((val_1.ContainsKey(key:  "rank")) == false) || ((System.Int32.TryParse(s:  val_1.Item["rank"], result: out  this.rank)) == false))
        {
            goto label_32;
        }
        
        val_36 = "rankProgress";
        if((val_1.ContainsKey(key:  "rankProgress")) == false)
        {
            goto label_32;
        }
        
        bool val_34 = System.Int32.TryParse(s:  val_1.Item["rankProgress"], result: out  this.rankProgress);
        goto label_34;
        label_17:
        UnityEngine.Debug.LogError(message:  "Error decoding progress");
        label_32:
        val_40 = 0;
        label_34:
        val_40 = val_40 & 1;
        return (bool)val_40;
    }
    public TRVSubCategoryProgress()
    {
        this.seenQuestions = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
    }

}
