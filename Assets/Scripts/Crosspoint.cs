using UnityEngine;
private class Crossword.Crosspoint
{
    // Fields
    public int x;
    public int y;
    public char l;
    public int dir;
    private static System.Collections.Generic.List<CrosswordCreator.Crossword.Crossword.Crosspoint> All;
    
    // Properties
    public static int Count { get; }
    
    // Methods
    public Crossword.Crosspoint(int x, int y, char l, int dir)
    {
        this.x = x;
        this.y = y;
        this.l = l;
        this.dir = dir;
    }
    public static void Add(int x, int y, char l, int dir)
    {
        null = null;
        .x = x;
        .y = y;
        .l = l;
        .dir = dir;
        Crossword.Crosspoint.All.Add(item:  new Crossword.Crosspoint());
    }
    public static CrosswordCreator.Crossword.Crossword.Crosspoint Get(int index)
    {
        null = null;
        if((Crossword.Crosspoint.All + 24) <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_1 = Crossword.Crosspoint.All + 16;
        val_1 = val_1 + (index << 3);
        return (Crosspoint)(Crossword.Crosspoint.All + 16 + (index) << 3) + 32;
    }
    public static CrosswordCreator.Crossword.Crossword.Crosspoint GetAt(int x, int y)
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = y;
        val_4 = null;
        val_4 = null;
        List.Enumerator<T> val_1 = Crossword.Crosspoint.All.GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_5 = 0;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((11993091 != x) || (1 != val_3))
        {
            goto label_7;
        }
        
        goto label_8;
        label_4:
        val_5 = 0;
        label_8:
        0.Dispose();
        return (Crosspoint)val_5;
    }
    public static void Remove(int x, int y)
    {
        var val_3;
        Crosspoint val_1 = Crossword.Crosspoint.GetAt(x:  x, y:  y);
        if(val_1 == null)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        bool val_2 = Crossword.Crosspoint.All.Remove(item:  val_1);
    }
    public static void Clear()
    {
        null = null;
        Crossword.Crosspoint.All.Clear();
    }
    public static int get_Count()
    {
        null = null;
        return (int)Crossword.Crosspoint.All + 24;
    }
    private static Crossword.Crosspoint()
    {
        Crossword.Crosspoint.All = new System.Collections.Generic.List<Crosspoint>();
    }

}
