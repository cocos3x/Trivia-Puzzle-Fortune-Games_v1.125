using UnityEngine;
public class UIDragObjectSimple : MonoBehaviour, IDragHandler, IEventSystemHandler
{
    // Fields
    private UnityEngine.RectTransform m_transform;
    
    // Methods
    public void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        UnityEngine.Vector3 val_1 = this.m_transform.position;
        UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  eventData.<delta>k__BackingField, y:  val_1.y);
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, b:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        this.m_transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public UIDragObjectSimple()
    {
    
    }

}
