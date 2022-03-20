using UnityEngine;
public class LimitedQueue<T> : Queue<T>
{
    // Fields
    private int <Limit>k__BackingField;
    
    // Properties
    public int Limit { get; set; }
    
    // Methods
    public int get_Limit()
    {
        return (int)this;
    }
    public void set_Limit(int value)
    {
        mem[1152921515501913328] = value;
    }
    public LimitedQueue<T>(int limit)
    {
        goto __RuntimeMethodHiddenParam + 24 + 192 + 16;
    }
    public void Enqueue(T item)
    {
        goto label_1;
        label_2:
        label_1:
        if(this >= this)
        {
            goto label_2;
        }
        
        goto __RuntimeMethodHiddenParam + 24 + 192 + 48;
    }

}
