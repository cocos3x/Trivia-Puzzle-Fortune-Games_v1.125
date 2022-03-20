using UnityEngine;
public class DailyChallengeDefinition : EncodableModel
{
    // Fields
    public int MinRequiredLength;
    public int CoinReward;
    public System.Collections.Generic.List<object> GoldenRewards;
    public System.Collections.Generic.List<object> StarThresholds;
    public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<int>> LettersWordCount;
    public int LettersLength;
    public int MaxRequiredWordsAmount;
    public int MinRequiredWordsAmount;
    
    // Properties
    public decimal GetReward { get; }
    
    // Methods
    public DailyChallengeDefinition(System.Collections.Generic.Dictionary<string, object> sourceData)
    {
        this.Decode(jasonObject:  sourceData, sourceModel:  0);
        this.DecodeLettersWordsCount(sourceData:  sourceData);
    }
    public decimal get_GetReward()
    {
        return System.Convert.ToDecimal(value:  this.CoinReward);
    }
    private void DecodeLettersWordsCount(System.Collections.Generic.Dictionary<string, object> sourceData)
    {
        string val_5;
        var val_7;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>> val_18;
        var val_20;
        if((sourceData.ContainsKey(key:  "letters_word_count")) == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>> val_2 = null;
        val_18 = val_2;
        val_2 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>();
        this.LettersWordCount = val_18;
        Dictionary.Enumerator<TKey, TValue> val_4 = sourceData.Item["letters_word_count"].GetEnumerator();
        var val_18 = 0;
        label_19:
        if(val_7.MoveNext() == false)
        {
            goto label_6;
        }
        
        val_20 = val_5;
        System.Collections.Generic.List<System.Int32> val_10 = new System.Collections.Generic.List<System.Int32>();
        if(val_20 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_12 = GetEnumerator();
        label_15:
        if(val_7.MoveNext() == false)
        {
            goto label_12;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Add(item:  System.Int32.Parse(s:  val_5, style:  511));
        goto label_15;
        label_12:
        val_20 = 0;
        val_18 = val_18 + 1;
        mem2[0] = 161;
        val_7.Dispose();
        if(val_20 != 0)
        {
                throw val_20;
        }
        
        if(val_18 != 1)
        {
                var val_15 = ((1152921517470410656 + ((0 + 1)) << 2) == 161) ? 1 : 0;
            val_15 = ((val_18 >= 0) ? 1 : 0) & val_15;
            val_18 = val_18 - val_15;
        }
        
        if(this.LettersWordCount == null)
        {
                throw new NullReferenceException();
        }
        
        this.LettersWordCount.Add(key:  System.Int32.Parse(s:  val_5, style:  511), value:  val_10);
        goto label_19;
        label_6:
        var val_17 = val_18 + 1;
        mem2[0] = 202;
        val_7.Dispose();
    }

}
