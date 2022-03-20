using UnityEngine;
private sealed class ShapeInfo.<>c__DisplayClass82_0
{
    // Fields
    public UnityEngine.EventSystems.PointerEventData eData;
    public BlockPuzzleMagic.ShapeInfo <>4__this;
    
    // Methods
    public ShapeInfo.<>c__DisplayClass82_0()
    {
    
    }
    internal void <OnPointerDown>b__0()
    {
        if((this.<>4__this) != null)
        {
                this.<>4__this.InitiateDragMode(eventData:  this.eData);
            return;
        }
        
        throw new NullReferenceException();
    }

}
