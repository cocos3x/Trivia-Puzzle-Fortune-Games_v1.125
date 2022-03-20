using UnityEngine;
public class WGOnTheTrailDayTracking : MonoBehaviour
{
    // Methods
    public void Setup(int today, System.Collections.Generic.List<bool> daysRewarded, System.Collections.Generic.List<int> rewards)
    {
        int val_5;
        int val_6;
        int val_7;
        OnTheTrailEvent.OnTheTrailDayItemStatus val_8;
        T[] val_2 = this.transform.GetComponentsInChildren<WGOnTheTrailDayItem>();
        if(W25 < 1)
        {
                return;
        }
        
        int val_3 = today - 1;
        label_22:
        if(0 >= (long)val_3)
        {
            goto label_4;
        }
        
        if(0 >= val_2[val_3])
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        T val_4 = val_2[0];
        val_6 = 0;
        val_5 = 0 + 1;
        val_7 = val_5;
        val_8 = val_2[0][0] ^ 1;
        goto label_9;
        label_4:
        if(0 != val_3)
        {
            goto label_12;
        }
        
        if(val_2[val_3] <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_2[val_3][val_3] == 0)
        {
            goto label_12;
        }
        
        1152921506204592464.Setup(status:  0, day:  today, reward:  0);
        val_5 = 0 + 1;
        goto label_16;
        label_12:
        int val_8 = val_2.Length;
        if(0 >= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = 2;
        val_8 = val_8 + 0;
        val_6 = mem[(val_2.Length + 0) + 32];
        val_6 = (val_2.Length + 0) + 32;
        val_5 = 0 + 1;
        val_7 = val_5;
        label_9:
        val_2[0].Setup(status:  val_8, day:  val_7, reward:  val_6);
        label_16:
        if(val_5 < X25)
        {
            goto label_22;
        }
    
    }
    public WGOnTheTrailDayTracking()
    {
    
    }

}
