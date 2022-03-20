using UnityEngine;
private sealed class BlockShapeSpawner.<UpdateSpawnShapesPosition>d__26 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public BlockPuzzleMagic.BlockShapeSpawner <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public BlockShapeSpawner.<UpdateSpawnShapesPosition>d__26(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        BlockPuzzleMagic.ShapeInfo val_10;
        int val_11;
        val_10 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_33;
        }
        
        this.<>1__state = 0;
        val_11 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.2f);
        this.<>1__state = val_11;
        return (bool)val_11;
        label_1:
        this.<>1__state = 0;
        var val_18 = 4;
        label_30:
        if((val_18 - 4) >= ((this.<>4__this.spawnedShapes.Length) << ))
        {
            goto label_6;
        }
        
        if(((this.<>4__this.spawnedShapes[0]) != 0) && ((this.<>4__this.ShapeContainers[0]) != 0))
        {
                BlockPuzzleMagic.ShapeInfo val_15 = this.<>4__this.spawnedShapes[0];
            UnityEngine.Vector3 val_5 = this.<>4__this.ShapeContainers[0].position;
            this.<>4__this.spawnedShapes[0].neutralWorldPosition = val_5;
            mem2[0] = val_5.y;
            mem2[0] = val_5.z;
            if((this.<>4__this.spawnedShapes[0].isDragged) != true)
        {
                BlockPuzzleMagic.ShapeInfo val_17 = this.<>4__this.spawnedShapes[0];
            this.<>4__this.spawnedShapes[0].transform.position = new UnityEngine.Vector3() {x = this.<>4__this.spawnedShapes[0].neutralWorldPosition, y = val_5.y, z = val_5.z};
        }
        
        }
        
        val_18 = val_18 + 1;
        if((this.<>4__this.spawnedShapes) != null)
        {
            goto label_30;
        }
        
        label_6:
        var val_22 = 4;
        label_57:
        if((val_22 - 4) >= ((this.<>4__this.spawnedPowerupShapes.Length) << ))
        {
            goto label_33;
        }
        
        val_10 = this.<>4__this.spawnedPowerupShapes[0];
        if(val_10 != 0)
        {
                val_10 = this.<>4__this.ShapeContainers[0];
            if(val_10 != 0)
        {
                val_10 = this.<>4__this.spawnedPowerupShapes[0];
            UnityEngine.Vector3 val_10 = this.<>4__this.ShapeContainers[0].position;
            this.<>4__this.spawnedPowerupShapes[0].neutralWorldPosition = val_10;
            mem2[0] = val_10.y;
            mem2[0] = val_10.z;
            if((this.<>4__this.spawnedPowerupShapes[0].isDragged) != true)
        {
                BlockPuzzleMagic.ShapeInfo val_21 = this.<>4__this.spawnedPowerupShapes[0];
            this.<>4__this.spawnedPowerupShapes[0].transform.position = new UnityEngine.Vector3() {x = this.<>4__this.spawnedPowerupShapes[0].neutralWorldPosition, y = val_10.y, z = val_10.z};
        }
        
        }
        
        }
        
        val_22 = val_22 + 1;
        if((this.<>4__this.spawnedPowerupShapes) != null)
        {
            goto label_57;
        }
        
        throw new NullReferenceException();
        label_33:
        val_11 = 0;
        return (bool)val_11;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
