using UnityEngine;
public class TRVHackBehavior : HackBehavior
{
    // Methods
    public override SROptions GetGameSpecificSROptions()
    {
        return SuperLuckySROptionsParent<SROptions_TRV>.Instance;
    }
    public override void AppendGameLevelInfo(ref System.Text.StringBuilder builder)
    {
        System.Text.StringBuilder val_27;
        System.Text.StringBuilder val_28;
        val_27 = 1152921517046617648;
        if((MonoSingleton<TRVMainController>.Instance) != 0)
        {
                TRVMainController val_3 = MonoSingleton<TRVMainController>.Instance;
            if(val_3.currentGame != null)
        {
                TRVMainController val_4 = MonoSingleton<TRVMainController>.Instance;
            System.Text.StringBuilder val_5 = builder.AppendLine(value:  "CURRENT QUIZ DATA");
            System.Text.StringBuilder val_7 = builder.AppendLine(value:  "Category : "("Category : ") + val_4.currentGame.quizCategory);
            System.Text.StringBuilder val_11 = builder.AppendLine(value:  "current question : "("current question : ") + val_4.currentGame.countedAnswers + 1(val_4.currentGame.countedAnswers + 1));
            System.Text.StringBuilder val_14 = builder.AppendLine(value:  "current difficulty array : "("current difficulty array : ") + MiniJSON.Json.Serialize(obj:  val_4.currentGame.<myArrayIndex>k__BackingField)(MiniJSON.Json.Serialize(obj:  val_4.currentGame.<myArrayIndex>k__BackingField)));
            val_28 = builder;
            System.Text.StringBuilder val_16 = val_28.AppendLine(value:  "current quiz length " + val_4.currentGame.quizLength);
            System.Text.StringBuilder val_17 = builder.AppendLine(value:  "_____");
            System.Text.StringBuilder val_18 = builder.AppendLine(value:  "CURRENT QUESTION DATA");
            TRVMainController val_19 = MonoSingleton<TRVMainController>.Instance;
            if(val_19.currentGame == null)
        {
                return;
        }
        
            TRVMainController val_20 = MonoSingleton<TRVMainController>.Instance;
            if(val_20.currentGame.currentQuestionData == null)
        {
                return;
        }
        
            TRVMainController val_21 = MonoSingleton<TRVMainController>.Instance;
            val_28 = val_21.currentGame.currentQuestionData;
            System.Text.StringBuilder val_23 = builder.AppendLine(value:  "question ID " + val_21.currentGame.currentQuestionData.<questionID>k__BackingField(val_21.currentGame.currentQuestionData.<questionID>k__BackingField));
            val_27 = builder;
            System.Text.StringBuilder val_25 = val_27.AppendLine(value:  "difficulty " + val_21.currentGame.currentQuestionData.<difficulty>k__BackingField(val_21.currentGame.currentQuestionData.<difficulty>k__BackingField));
            return;
        }
        
        }
        
        System.Text.StringBuilder val_26 = builder.AppendLine(value:  "NO DATA WHILE NOT IN GAMEPLAY");
    }
    public override void AppendCategoriesInfo(ref System.Text.StringBuilder builder)
    {
        string val_5;
        object val_6;
        var val_17;
        System.Text.StringBuilder val_18;
        string val_19;
        var val_20;
        System.Text.StringBuilder val_3 = builder.AppendLine(value:  System.String.Format(format:  "Current Level: {0}", arg0:  App.Player));
        val_17 = null;
        val_17 = null;
        List.Enumerator<T> val_4 = TRVDataParser.categoryNames.GetEnumerator();
        goto label_13;
        label_22:
        TRVDataParser val_7 = MonoSingleton<TRVDataParser>.Instance;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = 0;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_8 = val_7.getAvailableSubCategories;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = val_5;
        if((val_8.ContainsKey(key:  val_19)) == false)
        {
            goto label_13;
        }
        
        val_18 = builder;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = 0;
        System.Text.StringBuilder val_10 = val_18.AppendLine();
        val_18 = builder;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_11 = val_18.AppendLine(value:  val_5);
        val_20 = 0;
        goto label_16;
        label_21:
        val_6 = 1;
        val_19 = val_5;
        if(val_8.Item[val_19] == null)
        {
                throw new NullReferenceException();
        }
        
        if(0 >= 1152921504619999232)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_19 = System.String.Format(format:  "{0} - {1}", arg0:  val_6, arg1:  public System.Collections.DictionaryEntry Array.InternalEnumerator<System.Collections.DictionaryEntry>::get_Current());
        if(builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_14 = builder.AppendLine(value:  val_19);
        val_20 = 0 + 1;
        label_16:
        val_19 = val_5;
        if(val_8.Item[val_19] == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_20 < 44316368)
        {
            goto label_21;
        }
        
        label_13:
        if(val_6.MoveNext() == true)
        {
            goto label_22;
        }
        
        val_6.Dispose();
    }
    public TRVHackBehavior()
    {
    
    }

}
