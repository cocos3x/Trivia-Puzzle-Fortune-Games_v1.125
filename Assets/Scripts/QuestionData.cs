using UnityEngine;
public class QuestionData
{
    // Fields
    private string <questionID>k__BackingField;
    private string <category>k__BackingField;
    private int <difficulty>k__BackingField;
    private string <question>k__BackingField;
    private string <answer>k__BackingField;
    private System.Collections.Generic.List<string> <incorrectAnswers>k__BackingField;
    private string <factoid>k__BackingField;
    public UnityEngine.Sprite imageSp;
    
    // Properties
    public string questionID { get; set; }
    public string category { get; set; }
    public int difficulty { get; set; }
    public string question { get; set; }
    public string answer { get; set; }
    public System.Collections.Generic.List<string> incorrectAnswers { get; set; }
    public string factoid { get; set; }
    
    // Methods
    public string get_questionID()
    {
        return (string)this.<questionID>k__BackingField;
    }
    private void set_questionID(string value)
    {
        this.<questionID>k__BackingField = value;
    }
    public string get_category()
    {
        return (string)this.<category>k__BackingField;
    }
    public void set_category(string value)
    {
        this.<category>k__BackingField = value;
    }
    public int get_difficulty()
    {
        return (int)this.<difficulty>k__BackingField;
    }
    private void set_difficulty(int value)
    {
        this.<difficulty>k__BackingField = value;
    }
    public string get_question()
    {
        return (string)this.<question>k__BackingField;
    }
    private void set_question(string value)
    {
        this.<question>k__BackingField = value;
    }
    public string get_answer()
    {
        return (string)this.<answer>k__BackingField;
    }
    private void set_answer(string value)
    {
        this.<answer>k__BackingField = value;
    }
    public System.Collections.Generic.List<string> get_incorrectAnswers()
    {
        return (System.Collections.Generic.List<System.String>)this.<incorrectAnswers>k__BackingField;
    }
    private void set_incorrectAnswers(System.Collections.Generic.List<string> value)
    {
        this.<incorrectAnswers>k__BackingField = value;
    }
    public string get_factoid()
    {
        return (string)this.<factoid>k__BackingField;
    }
    private void set_factoid(string value)
    {
        this.<factoid>k__BackingField = value;
    }
    public QuestionData(string unparsedQuestionData)
    {
        var val_14;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        char[] val_2 = new char[1];
        val_2[0] = '	';
        val_1.AddRange(collection:  unparsedQuestionData.Split(separator:  val_2));
        if((public System.Void System.Collections.Generic.List<System.String>::AddRange(System.Collections.Generic.IEnumerable<T> collection)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.<questionID>k__BackingField = static System.Void System.Collections.Generic.ArraySortHelper<System.Byte>::Sort(T[] keys, int index, int length, System.Comparison<T> comparer);
        bool val_4 = val_1.Remove(item:  static System.Void System.Collections.Generic.ArraySortHelper<System.Byte>::Sort(T[] keys, int index, int length, System.Comparison<T> comparer));
        if((public System.Void System.Collections.Generic.List<System.String>::AddRange(System.Collections.Generic.IEnumerable<T> collection)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.<category>k__BackingField = static System.Void System.Collections.Generic.ArraySortHelper<System.Byte>::Sort(T[] keys, int index, int length, System.Comparison<T> comparer);
        bool val_5 = val_1.Remove(item:  static System.Void System.Collections.Generic.ArraySortHelper<System.Byte>::Sort(T[] keys, int index, int length, System.Comparison<T> comparer));
        if((public System.Void System.Collections.Generic.List<System.String>::AddRange(System.Collections.Generic.IEnumerable<T> collection)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        bool val_7 = System.Int32.TryParse(s:  static System.Void System.Collections.Generic.ArraySortHelper<System.Byte>::Sort(T[] keys, int index, int length, System.Comparison<T> comparer), result: out  0);
        val_1.RemoveAt(index:  0);
        this.<difficulty>k__BackingField = UnityEngine.Mathf.Min(a:  0, b:  3);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        this.<question>k__BackingField = UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 32;
        bool val_9 = val_1.Remove(item:  UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 32);
        System.Collections.Generic.List<System.String> val_10 = new System.Collections.Generic.List<System.String>();
        this.<incorrectAnswers>k__BackingField = val_10;
        val_14 = 0;
        goto label_11;
        label_14:
        bool val_11 = val_1.Remove(item:  val_10);
        this.<incorrectAnswers>k__BackingField.Add(item:  val_10);
        val_14 = 1;
        label_11:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if(val_14 < 3)
        {
            goto label_14;
        }
        
        this.<answer>k__BackingField = UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 32;
        bool val_12 = val_1.Remove(item:  UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 32);
        this.<factoid>k__BackingField = UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 32;
        bool val_13 = val_1.Remove(item:  UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 32);
    }
    public override string ToString()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_3 = val_1.AppendLine(value:  System.String.Format(format:  "question : {0}", arg0:  this.<question>k__BackingField));
        System.Text.StringBuilder val_5 = val_1.AppendLine(value:  System.String.Format(format:  "answer : {0}", arg0:  this.<answer>k__BackingField));
        System.Text.StringBuilder val_6 = val_1.AppendLine(value:  "incorrect answers");
        System.Text.StringBuilder val_8 = val_1.AppendLine(value:  PrettyPrint.printJSON(obj:  this.<incorrectAnswers>k__BackingField, types:  false, singleLineOutput:  false));
        goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
    }

}
