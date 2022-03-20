using UnityEngine;
public class SlotMachineEconomy
{
    // Fields
    private System.Collections.Generic.List<float> coinChance;
    private System.Collections.Generic.List<int> coinValue;
    private System.Collections.Generic.List<float> starChance;
    private System.Collections.Generic.List<int> starValue;
    
    // Methods
    public int GetCoinReward()
    {
        System.Collections.Generic.List<System.Single> val_3;
        var val_4;
        float val_5 = UnityEngine.Random.Range(min:  0f, max:  50f);
        var val_4 = 8;
        label_7:
        var val_2 = val_4 - 8;
        if(val_2 >= 32493568)
        {
            goto label_2;
        }
        
        if(val_2 >= 32493568)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_5 <= (2.466285E-43f))
        {
            goto label_4;
        }
        
        val_3 = this.coinChance;
        if(val_2 >= 32493568)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3 = this.coinChance;
        }
        
        val_4 = val_4 + 1;
        val_5 = val_5 - (2.466285E-43f);
        if(val_3 != null)
        {
            goto label_7;
        }
        
        label_2:
        val_4 = 0;
        return (int)val_4;
        label_4:
        if(32493568 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = 176;
        if(val_2 > 8)
        {
                return (int)val_4;
        }
        
        val_4 = (UnityEngine.Random.Range(min:  0, max:  10)) + val_4;
        return (int)val_4;
    }
    public int GetStarReward()
    {
        System.Collections.Generic.List<System.Single> val_3;
        var val_4;
        float val_5 = UnityEngine.Random.Range(min:  0f, max:  50f);
        var val_4 = 8;
        label_7:
        var val_2 = val_4 - 8;
        if(val_2 >= 32493568)
        {
            goto label_2;
        }
        
        if(val_2 >= 32493568)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_5 <= (2.466285E-43f))
        {
            goto label_4;
        }
        
        val_3 = this.starChance;
        if(val_2 >= 32493568)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3 = this.starChance;
        }
        
        val_4 = val_4 + 1;
        val_5 = val_5 - (2.466285E-43f);
        if(val_3 != null)
        {
            goto label_7;
        }
        
        label_2:
        val_4 = 0;
        return (int)val_4;
        label_4:
        if(32493568 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = 176;
        if(val_2 > 8)
        {
                return (int)val_4;
        }
        
        val_4 = (UnityEngine.Random.Range(min:  0, max:  10)) + val_4;
        return (int)val_4;
    }
    public void CheckEconomy()
    {
        System.Collections.Generic.List<System.Single> val_4;
        float val_5;
        System.Collections.Generic.List<System.Single> val_6;
        bool val_4 = true;
        var val_5 = 0;
        float val_6 = 0f;
        label_4:
        if(val_5 >= val_4)
        {
            goto label_2;
        }
        
        val_4 = val_4 & 4294967295;
        val_4 = this.coinChance;
        if(val_5 >= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_4 = this.coinChance;
        }
        
        var val_1 = X9 + 0;
        val_5 = val_5 + 1;
        val_6 = val_6 + ((X9 + 0) + 32);
        if(val_4 != null)
        {
            goto label_4;
        }
        
        label_2:
        UnityEngine.Debug.LogError(message:  "total coin chance: "("total coin chance: ") + val_6);
        var val_7 = 0;
        val_5 = 0f;
        label_11:
        if(val_7 >= null)
        {
            goto label_9;
        }
        
        val_6 = this.starChance;
        if(val_7 >= 151543808)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_6 = this.starChance;
        }
        
        val_7 = val_7 + 1;
        val_5 = val_5 + ((UnityEngine.Debug.__il2cppRuntimeField_cctor_finished + 0) + 32);
        if(val_6 != null)
        {
            goto label_11;
        }
        
        throw new NullReferenceException();
        label_9:
        UnityEngine.Debug.LogError(message:  "total star chance: "("total star chance: ") + val_5);
    }
    public SlotMachineEconomy()
    {
        System.Collections.Generic.List<System.Single> val_1 = new System.Collections.Generic.List<System.Single>();
        val_1.Add(item:  0.5f);
        val_1.Add(item:  1.25f);
        val_1.Add(item:  3.75f);
        val_1.Add(item:  6.25f);
        val_1.Add(item:  10.625f);
        val_1.Add(item:  12.5f);
        val_1.Add(item:  7.5f);
        val_1.Add(item:  5f);
        val_1.Add(item:  2.5f);
        val_1.Add(item:  0.05f);
        val_1.Add(item:  0.025f);
        val_1.Add(item:  0.0125f);
        val_1.Add(item:  0.0075f);
        val_1.Add(item:  0.007f);
        val_1.Add(item:  0.0065f);
        val_1.Add(item:  0.006f);
        val_1.Add(item:  0.0055f);
        val_1.Add(item:  0.005f);
        this.coinChance = val_1;
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        val_2.Add(item:  10);
        val_2.Add(item:  20);
        val_2.Add(item:  30);
        val_2.Add(item:  40);
        val_2.Add(item:  50);
        val_2.Add(item:  60);
        val_2.Add(item:  70);
        val_2.Add(item:  80);
        val_2.Add(item:  90);
        val_2.Add(item:  100);
        val_2.Add(item:  200);
        val_2.Add(item:  44);
        val_2.Add(item:  144);
        val_2.Add(item:  244);
        val_2.Add(item:  88);
        val_2.Add(item:  188);
        val_2.Add(item:  32);
        val_2.Add(item:  132);
        this.coinValue = val_2;
        System.Collections.Generic.List<System.Single> val_3 = new System.Collections.Generic.List<System.Single>();
        val_3.Add(item:  0.25f);
        val_3.Add(item:  0.5f);
        val_3.Add(item:  1.75f);
        val_3.Add(item:  3.75f);
        val_3.Add(item:  7.5f);
        val_3.Add(item:  8.5f);
        val_3.Add(item:  9.5f);
        val_3.Add(item:  8.5f);
        val_3.Add(item:  7.5f);
        val_3.Add(item:  0.45f);
        val_3.Add(item:  0.4f);
        val_3.Add(item:  0.35f);
        val_3.Add(item:  0.3f);
        val_3.Add(item:  0.25f);
        val_3.Add(item:  0.2f);
        val_3.Add(item:  0.15f);
        val_3.Add(item:  0.1f);
        val_3.Add(item:  0.05f);
        this.starChance = val_3;
        System.Collections.Generic.List<System.Int32> val_4 = new System.Collections.Generic.List<System.Int32>();
        val_4.Add(item:  10);
        val_4.Add(item:  20);
        val_4.Add(item:  30);
        val_4.Add(item:  40);
        val_4.Add(item:  50);
        val_4.Add(item:  60);
        val_4.Add(item:  70);
        val_4.Add(item:  80);
        val_4.Add(item:  90);
        val_4.Add(item:  100);
        val_4.Add(item:  200);
        val_4.Add(item:  44);
        val_4.Add(item:  144);
        val_4.Add(item:  244);
        val_4.Add(item:  88);
        val_4.Add(item:  188);
        val_4.Add(item:  32);
        val_4.Add(item:  132);
        this.starValue = val_4;
    }

}
