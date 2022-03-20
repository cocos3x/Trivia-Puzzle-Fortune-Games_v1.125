using UnityEngine;
public class MinigamesConfig : ScriptableObject
{
    // Fields
    public System.Collections.Generic.List<MiniGame> minigames;
    
    // Properties
    public string[] MiniGamesScenes { get; }
    public string[] MiniGamesIds { get; }
    
    // Methods
    public string[] get_MiniGamesScenes()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_2 = this.minigames.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(5 == 0)
        {
            goto label_6;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  64);
        goto label_6;
        label_2:
        0.Dispose();
        return (System.String[])val_1.ToArray();
    }
    public string[] get_MiniGamesIds()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_2 = this.minigames.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(5 == 0)
        {
            goto label_6;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  11993091);
        goto label_6;
        label_2:
        0.Dispose();
        return (System.String[])val_1.ToArray();
    }
    public MiniGame GetMiniGameById(string id)
    {
        string val_4;
        var val_5;
        val_4 = id;
        List.Enumerator<T> val_1 = this.minigames.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_5 = 0;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  11993091, b:  val_4)) == false)
        {
            goto label_4;
        }
        
        goto label_5;
        label_2:
        val_5 = 0;
        label_5:
        0.Dispose();
        return (MiniGame)val_5;
    }
    public MiniGame GetMiniGameByIndex(int index)
    {
        var val_3;
        var val_4;
        val_3 = index;
        List.Enumerator<T> val_1 = this.minigames.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_4 = 0;
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(1 != val_3)
        {
            goto label_4;
        }
        
        goto label_5;
        label_2:
        val_4 = 0;
        label_5:
        0.Dispose();
        return (MiniGame)val_4;
    }
    public MinigamesConfig()
    {
    
    }

}
