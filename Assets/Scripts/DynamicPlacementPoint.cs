using UnityEngine;
public class DynamicPlacementPoint : MonoBehaviour
{
    // Fields
    private DynamicPlacementLocation myLocation;
    
    // Methods
    private void Start()
    {
        if((MonoSingleton<UGUIDynamicPlacementManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<UGUIDynamicPlacementManager>.Instance.TryToAddPlacementPoint(dPP:  this, dPL:  this.myLocation);
    }
    public void PlaceObject(UnityEngine.GameObject obj)
    {
        obj.transform.SetParent(p:  this.transform);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
        obj.transform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.one;
        obj.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        UnityEngine.Quaternion val_8 = UnityEngine.Quaternion.identity;
        obj.transform.localRotation = new UnityEngine.Quaternion() {x = val_8.x, y = val_8.y, z = val_8.z, w = val_8.w};
        obj.gameObject.SetActive(value:  true);
    }
    private void OnDestroy()
    {
        if((MonoSingleton<UGUIDynamicPlacementManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<UGUIDynamicPlacementManager>.Instance.RemovePlacementPoint(dPP:  this, dPL:  this.myLocation);
    }
    public DynamicPlacementPoint()
    {
    
    }

}
