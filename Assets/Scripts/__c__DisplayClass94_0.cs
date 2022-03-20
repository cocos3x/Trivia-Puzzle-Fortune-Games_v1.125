using UnityEngine;
private sealed class ShapeInfo.<>c__DisplayClass94_0
{
    // Fields
    public BlockPuzzleMagic.ShapeInfo <>4__this;
    public System.Action onComplete;
    
    // Methods
    public ShapeInfo.<>c__DisplayClass94_0()
    {
    
    }
    internal void <SnapBackAndReset>b__0()
    {
        this.<>4__this.ToggleSortingOrder(bringToFront:  false);
        this.<>4__this.gameObject.transform.position = new UnityEngine.Vector3() {x = this.<>4__this.neutralWorldPosition};
        if(this.onComplete == null)
        {
                return;
        }
        
        this.onComplete.Invoke();
    }

}
