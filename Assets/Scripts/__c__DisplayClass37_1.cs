using UnityEngine;
private sealed class BBLFTUXDemoWindow.<>c__DisplayClass37_1
{
    // Fields
    public UnityEngine.Vector3 arrowStartPos;
    public UnityEngine.Vector3 arrowEndPos;
    public UnityEngine.Vector3 pointerStartPos;
    public UnityEngine.Vector3 pointerEndPos;
    public BBLFTUXDemoWindow <>4__this;
    
    // Methods
    public BBLFTUXDemoWindow.<>c__DisplayClass37_1()
    {
    
    }
    internal void <DisplayFTUXStep>b__2()
    {
        this.<>4__this.ShowArrowHead(from:  new UnityEngine.Vector3() {x = this.arrowStartPos}, to:  new UnityEngine.Vector3() {x = this.arrowEndPos});
        this.<>4__this.MovePointerAlong(startPos:  new UnityEngine.Vector3() {x = this.pointerStartPos}, endPos:  new UnityEngine.Vector3() {x = this.pointerEndPos}, moveAlongDuration:  1f, moveAlongLoopType:  0, moveAlongEaseType:  1);
    }

}
