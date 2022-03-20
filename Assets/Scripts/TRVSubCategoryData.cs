using UnityEngine;
public class TRVSubCategoryData
{
    // Fields
    public string subCategory;
    public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<QuestionData>> questionData;
    
    // Methods
    public TRVSubCategoryData(UnityEngine.TextAsset unparsedData, string subCategoryName)
    {
        var val_9;
        string val_10;
        string val_11;
        int val_12;
        var val_13;
        var val_14;
        System.String[] val_15;
        val_10 = val_2;
        this.subCategory = "";
        this.questionData = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<QuestionData>>();
        val_2 = new System.Object();
        val_11 = unparsedData.text;
        System.String[] val_4 = System.Text.RegularExpressions.Regex.Split(input:  val_11, pattern:  "\n|\r|\r\n");
        if(val_4 == null)
        {
                return;
        }
        
        val_12 = val_4.Length;
        val_11 = val_4;
        if(val_12 == 0)
        {
                return;
        }
        
        if(val_12 >= 1)
        {
                val_13 = 1152921517247365568;
            val_9 = 1152921516944745696;
            val_14 = 1152921517247366592;
            var val_10 = 0;
            do
        {
            if((this.questionData.ContainsKey(key:  (QuestionData)[1152921517247503488].<difficulty>k__BackingField)) != true)
        {
                val_10 = this.questionData;
            val_10.Add(key:  (QuestionData)[1152921517247503488].<difficulty>k__BackingField, value:  new System.Collections.Generic.List<QuestionData>());
            val_13 = val_13;
            val_9 = val_9;
            val_11 = val_11;
            val_15 = val_11[32];
            val_14 = 1152921517247366592;
        }
        
            this.questionData.Item[(QuestionData)[1152921517247503488].<difficulty>k__BackingField].Add(item:  new QuestionData(unparsedQuestionData:  1152921505059157200));
            val_12 = val_4.Length;
            val_10 = val_10 + 1;
        }
        while(val_10 < val_12);
        
        }
        
        this.subCategory = val_10;
    }
    public TRVSubCategoryData(string textBlock, string subCategoryName)
    {
        var val_8;
        string val_9;
        string val_10;
        int val_11;
        var val_12;
        var val_13;
        System.String[] val_14;
        val_9 = val_2;
        val_10 = textBlock;
        this.subCategory = "";
        this.questionData = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<QuestionData>>();
        val_2 = new System.Object();
        System.String[] val_3 = System.Text.RegularExpressions.Regex.Split(input:  val_10, pattern:  "\n|\r|\r\n");
        if(val_3 == null)
        {
                return;
        }
        
        val_11 = val_3.Length;
        val_10 = val_3;
        if(val_11 == 0)
        {
                return;
        }
        
        if(val_11 >= 1)
        {
                val_12 = 1152921517247365568;
            val_8 = 1152921516944745696;
            val_13 = 1152921517247366592;
            var val_9 = 0;
            do
        {
            if((this.questionData.ContainsKey(key:  (QuestionData)[1152921517247762944].<difficulty>k__BackingField)) != true)
        {
                val_9 = this.questionData;
            val_9.Add(key:  (QuestionData)[1152921517247762944].<difficulty>k__BackingField, value:  new System.Collections.Generic.List<QuestionData>());
            val_12 = val_12;
            val_8 = val_8;
            val_10 = val_10;
            val_14 = val_10[32];
            val_13 = 1152921517247366592;
        }
        
            this.questionData.Item[(QuestionData)[1152921517247762944].<difficulty>k__BackingField].Add(item:  new QuestionData(unparsedQuestionData:  1152921505059157200));
            val_11 = val_3.Length;
            val_9 = val_9 + 1;
        }
        while(val_9 < val_11);
        
        }
        
        this.subCategory = val_9;
    }

}
