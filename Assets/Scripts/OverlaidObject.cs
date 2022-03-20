using UnityEngine;
public struct OverlaidObject
{
    // Fields
    public UnityEngine.Transform transform;
    public UnityEngine.Transform parent;
    public int siblingIndex;
    
    // Methods
    public OverlaidObject(UnityEngine.Transform _transform, UnityEngine.Transform _parent, int _siblingIndex)
    {
        this = _transform;
        this.parent = _parent;
        this.siblingIndex = _siblingIndex;
    }
    public void Restore()
    {
        this.Restore(_siblingIndex:  this.siblingIndex);
    }
    public void Restore(int _siblingIndex)
    {
        UnityEngine.Transform val_5;
        if(1152921504975376384 != 0)
        {
                val_5 = this.parent;
            if(val_5 != 0)
        {
                1152921504975376384.SetParent(p:  this.parent);
            1152921504975376384.SetSiblingIndex(index:  _siblingIndex);
            return;
        }
        
        }
        
        if(1152921504975376384 == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  1152921504975376384.gameObject);
    }

}
