using UnityEngine;
public class RandomSet
{
    // Fields
    private static System.Random random;
    public bool replacement;
    private System.Collections.Generic.Dictionary<int, float> items;
    private float totalItemWeight;
    private System.Collections.Generic.Dictionary<int, float> used;
    private float totalUsedWeight;
    
    // Methods
    public void clear()
    {
        this.items.Clear();
        this.used.Clear();
        this.totalUsedWeight = 0f;
        this.totalItemWeight = 0f;
    }
    public int count()
    {
        return this.items.Count;
    }
    public void reset()
    {
        int val_3;
        var val_4;
        int val_7;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = this.used.Keys.GetEnumerator();
        label_6:
        val_7 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.Int32, System.Single>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(this.used == null)
        {
                throw new NullReferenceException();
        }
        
        val_7 = val_3;
        if(this.items == null)
        {
                throw new NullReferenceException();
        }
        
        this.items.Add(key:  val_3, value:  this.used.Item[val_7]);
        goto label_6;
        label_3:
        val_4.Dispose();
        float val_7 = this.totalItemWeight;
        val_7 = val_7 + this.totalUsedWeight;
        this.totalItemWeight = val_7;
        this.used.Clear();
        this.totalUsedWeight = 0f;
    }
    public void add(int item, float weight = 1)
    {
        this.items.Add(key:  item, value:  weight);
        float val_1 = this.totalItemWeight;
        val_1 = val_1 + weight;
        this.totalItemWeight = val_1;
    }
    public void addIntRange(int lowest, int highest)
    {
        if(lowest > highest)
        {
                return;
        }
        
        int val_1 = lowest;
        do
        {
            this.add(item:  val_1, weight:  1f);
            val_1 = val_1 + 1;
        }
        while(val_1 <= highest);
    
    }
    public int roll(bool unweighted = False)
    {
        int val_5;
        var val_6;
        var val_10;
        var val_11;
        int val_12;
        float val_13;
        val_10 = unweighted;
        if(this.items.Count < 1)
        {
            goto label_2;
        }
        
        val_11 = null;
        val_11 = null;
        if(val_10 == false)
        {
            goto label_6;
        }
        
        int val_2 = this.items.Count;
        goto label_8;
        label_2:
        val_12 = 0;
        return (int)val_12;
        label_6:
        label_8:
        val_13 = (float)RandomSet.random;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_4 = this.items.Keys.GetEnumerator();
        label_15:
        if(val_6.MoveNext() == false)
        {
            goto label_12;
        }
        
        val_12 = val_5;
        if(val_10 != true)
        {
                if(this.items == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_13 = val_13 - this.items.Item[val_12];
        if(val_13 >= 0)
        {
            goto label_15;
        }
        
        goto label_16;
        label_12:
        val_12 = 0;
        label_16:
        val_6.Dispose();
        if(this.replacement == true)
        {
                return (int)val_12;
        }
        
        this.use(item:  0);
        return (int)val_12;
    }
    public int remainingCount()
    {
        return this.items.Count;
    }
    public static int singleInRange(int lowest, int highest)
    {
        null = null;
        System.Random val_3 = RandomSet.random;
        var val_2 = 1;
        val_2 = val_2 - lowest;
        val_2 = val_2 + highest;
        val_2 = val_3 - ((val_3 / val_2) * val_2);
        val_3 = val_2 + lowest;
        return (int)val_3;
    }
    public static int singleInRange(System.Collections.Generic.List<object> range)
    {
        if(true == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        return RandomSet.singleInRange(lowest:  System.Convert.ToInt32(value:  null), highest:  System.Convert.ToInt32(value:  (System.Convert.__il2cppRuntimeField_cctor_finished + ((System.Convert.__il2cppRuntimeField_cctor_finished - 1)) << 3) + 32));
    }
    public void use(int item)
    {
        if((this.items.ContainsKey(key:  item)) == false)
        {
                return;
        }
        
        float val_2 = this.items.Item[item];
        this.used.Add(key:  item, value:  val_2);
        bool val_3 = this.items.Remove(key:  item);
        float val_4 = this.totalUsedWeight;
        float val_5 = this.totalItemWeight;
        val_4 = val_2 + val_4;
        val_5 = val_5 - val_2;
        this.totalUsedWeight = val_4;
        this.totalItemWeight = val_5;
    }
    public void replace(int item)
    {
        if((this.used.ContainsKey(key:  item)) == false)
        {
                return;
        }
        
        float val_2 = this.used.Item[item];
        this.items.Add(key:  item, value:  val_2);
        bool val_3 = this.used.Remove(key:  item);
        float val_4 = this.totalUsedWeight;
        float val_5 = this.totalItemWeight;
        val_4 = val_4 - val_2;
        val_5 = val_2 + val_5;
        this.totalUsedWeight = val_4;
        this.totalItemWeight = val_5;
    }
    public float getWeight(int item)
    {
        if((this.items.ContainsKey(key:  item)) == false)
        {
                return 0f;
        }
        
        return this.items.Item[item];
    }
    public System.Collections.Generic.List<int> stream(int count)
    {
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        this.reset();
        do
        {
            if(this.items.Count < 1)
        {
                return val_1;
        }
        
            if(1152921510062986752 >= count)
        {
                return val_1;
        }
        
            val_1.Add(item:  this.roll(unweighted:  false));
        }
        while(this.items != null);
        
        throw new NullReferenceException();
    }
    public void printBuckets()
    {
        var val_3;
        var val_4;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = this.items.Keys.GetEnumerator();
        label_4:
        if(val_4.MoveNext() == false)
        {
            goto label_3;
        }
        
        string val_7 = "avail( " + val_3.ToString() + ", ";
        goto label_4;
        label_3:
        val_4.Dispose();
        UnityEngine.Debug.Log(message:  "avail( " + ")");
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_10 = this.used.Keys.GetEnumerator();
        label_10:
        if(val_4.MoveNext() == false)
        {
            goto label_9;
        }
        
        string val_13 = "used( " + val_3.ToString() + ", ";
        goto label_10;
        label_9:
        val_4.Dispose();
        UnityEngine.Debug.Log(message:  "used( " + ")");
    }
    public RandomSet()
    {
        this.items = new System.Collections.Generic.Dictionary<System.Int32, System.Single>();
        this.used = new System.Collections.Generic.Dictionary<System.Int32, System.Single>();
    }
    private static RandomSet()
    {
        RandomSet.random = new System.Random();
    }

}
