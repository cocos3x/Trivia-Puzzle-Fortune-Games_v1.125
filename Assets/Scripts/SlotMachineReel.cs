using UnityEngine;
public class SlotMachineReel : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<UnityEngine.GameObject> reelObjects;
    private float objectHeight;
    private float spinSpeed;
    private float topEndHeight;
    private float bottomEndHeight;
    private float fullReelDuration;
    
    // Methods
    private void OnEnable()
    {
        if(this.objectHeight <= 0f)
        {
                if(true == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector2 val_2 = 0.transform.sizeDelta;
            this.objectHeight = val_2.y;
        }
        
        float val_3 = (float)val_2.x;
        val_3 = val_2.y * val_3;
        val_3 = val_3 / this.spinSpeed;
        this.topEndHeight = val_2.y;
        this.fullReelDuration = val_3;
    }
    public void SpinToIndex(int targetIndex, int extraRounds = 1, System.Action callBack)
    {
        var val_4;
        bool val_4 = true;
        val_4 = 0;
        do
        {
            if(val_4 >= val_4)
        {
                return;
        }
        
            val_4 = val_4 & 4294967295;
            if(val_4 >= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_4 = val_4 + 0;
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.TweenObjectToHeight(reelObject:  ((true & 4294967295) + 0) + 32, targetHeight:  this.GetTargetHeight(objectIndex:  0, reelTargetIndex:  targetIndex), extraRounds:  extraRounds, callBack:  callBack));
            val_4 = val_4 + 1;
        }
        while(this.reelObjects != null);
        
        throw new NullReferenceException();
    }
    private System.Collections.IEnumerator TweenObjectToHeight(UnityEngine.GameObject reelObject, float targetHeight, int extraRounds, System.Action callBack)
    {
        .<>1__state = 0;
        .reelObject = reelObject;
        .targetHeight = targetHeight;
        .extraRounds = extraRounds;
        .<>4__this = this;
        .callBack = callBack;
        return (System.Collections.IEnumerator)new SlotMachineReel.<TweenObjectToHeight>d__8();
    }
    private float GetTravelDuration(UnityEngine.GameObject reelObject, float targetHeight)
    {
        UnityEngine.Vector3 val_2 = reelObject.transform.localPosition;
        float val_3 = this.spinSpeed;
        val_2.y = val_2.y - targetHeight;
        val_3 = val_2.y / val_3;
        return (float)val_3;
    }
    private float GetTargetHeight(int objectIndex, int reelTargetIndex)
    {
        var val_5;
        int val_1 = reelTargetIndex - objectIndex;
        if(val_1 > (((W9 < 0) ? (W9 + 1) : (W9)) >> 1))
        {
                val_5 = val_1 - W9;
        }
        else
        {
                var val_5 = 1;
            val_5 = val_5 - W9;
            val_5 = ((val_1 < ((((-W9) < 0) ? (val_5) : (-W9)) >> 1)) ? (W9) : 0) + val_1;
        }
        
        float val_6 = this.objectHeight;
        val_6 = val_6 * (float)val_5;
        return (float)val_6;
    }
    public SlotMachineReel()
    {
        this.spinSpeed = 3000f;
    }

}
