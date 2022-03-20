using UnityEngine;
public class FPHLevelObject
{
    // Fields
    private string <id>k__BackingField;
    private int <levelIndex>k__BackingField;
    private string <phrase>k__BackingField;
    private string <clue>k__BackingField;
    
    // Properties
    public string id { get; set; }
    public int levelIndex { get; set; }
    public string phrase { get; set; }
    public string clue { get; set; }
    
    // Methods
    public string get_id()
    {
        return (string)this.<id>k__BackingField;
    }
    private void set_id(string value)
    {
        this.<id>k__BackingField = value;
    }
    public int get_levelIndex()
    {
        return (int)this.<levelIndex>k__BackingField;
    }
    private void set_levelIndex(int value)
    {
        this.<levelIndex>k__BackingField = value;
    }
    public string get_phrase()
    {
        return (string)this.<phrase>k__BackingField;
    }
    private void set_phrase(string value)
    {
        this.<phrase>k__BackingField = value;
    }
    public string get_clue()
    {
        return (string)this.<clue>k__BackingField;
    }
    private void set_clue(string value)
    {
        this.<clue>k__BackingField = value;
    }
    public FPHLevelObject(string unparsedString)
    {
        char[] val_1 = new char[1];
        val_1[0] = '	';
        System.String[] val_2 = unparsedString.Split(separator:  val_1);
        this.<id>k__BackingField = val_2[0];
        if((System.Int32.TryParse(s:  val_2[1], result: out  0)) != false)
        {
                this.<levelIndex>k__BackingField = 0;
        }
        
        this.<clue>k__BackingField = val_2[2].ToUpperInvariant();
        this.<phrase>k__BackingField = val_2[3].ToUpperInvariant();
    }

}
