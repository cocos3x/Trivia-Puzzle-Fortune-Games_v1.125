using UnityEngine;
private sealed class PowerupEarthquakeButton.<>c__DisplayClass6_0
{
    // Fields
    public System.Collections.Generic.List<BlockPuzzleMagic.GridCell> gridCells;
    public System.Collections.Generic.List<System.Collections.Generic.List<int>> order;
    public float animationDelay;
    public UnityEngine.UI.Image quakeIcon;
    
    // Methods
    public PowerupEarthquakeButton.<>c__DisplayClass6_0()
    {
    
    }
    internal void <PlayEarthquakeAnimation>b__0()
    {
        System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>> val_4;
        var val_6;
        System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>> val_7;
        System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>> val_8;
        val_4 = this.order;
        var val_10 = 0;
        label_32:
        if(val_10 >= 32493568)
        {
                return;
        }
        
        val_6 = 8;
        goto label_3;
        label_31:
        if(32493568 <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(mem[85899346120] <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = mem[85899346112];
        if(val_5 <= (mem[85899346112] + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + ((mem[85899346112] + 32) << 3);
        if(((mem[85899346112] + (mem[85899346112] + 32) << 3) + 32.isFilled) != false)
        {
                if(val_5 <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_5 = val_5 + 0;
            if((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 24) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_6 = ((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16;
            if(val_6 <= (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_6 = val_6 + ((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3);
            var val_7 = (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3) + 32;
            if(((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3) + 32 + 40.hasStone) != false)
        {
                if(val_7 <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_7 = val_7 + 0;
            if((((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3) + 32 + 0) + 32 + 24) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_8 = ((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3) + 32 + 0) + 32 + 16;
            if(val_8 <= (((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3) + 32 + 0) + 32 + 16 + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = val_8 + ((((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3) + 32 + 0) + 32 + 16 + 32) << 3);
            float val_9 = this.animationDelay;
            val_9 = (0f * 0.035f) + val_9;
            (((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3) + 32 + 0) + 32 + 16 + (((((mem[85899346112] + (mem + 32.ClearCellEarthquake(animationDelay:  val_9);
        }
        
        }
        
        val_7 = this.order;
        val_6 = 9;
        label_3:
        if(val_8 <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + 0;
        if((val_6 - 8) < (((((((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + (((mem[85899346112] + (mem[85899346112] + 32) << 3) + 0) + 32 + 16 + 32) << 3) + 32 + 0) + 32 + 16 + (((((mem[85899346112] + (me + 32 + 24))
        {
            goto label_31;
        }
        
        val_8 = this.order;
        val_10 = val_10 + 1;
        if(val_8 != null)
        {
            goto label_32;
        }
        
        throw new NullReferenceException();
    }
    internal void <PlayEarthquakeAnimation>b__1()
    {
        UnityEngine.Object.Destroy(obj:  this.quakeIcon.gameObject);
    }

}
