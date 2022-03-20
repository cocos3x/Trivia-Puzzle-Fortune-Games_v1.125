using UnityEngine;
public class UGUIDynamicPlacementManager : MonoSingleton<UGUIDynamicPlacementManager>
{
    // Fields
    private PrefabsFromFolder prefabsFromFolder;
    private System.Collections.Generic.Dictionary<DynamicPlacementLocation, DynamicPlacementPoint> placementPoints;
    
    // Methods
    public T PlaceGameObject<T>(DynamicPlacementLocation loc = 0)
    {
        PrefabsFromFolder val_10 = this.prefabsFromFolder;
        if(val_10 != 0)
        {
            goto label_4;
        }
        
        UnityEngine.Debug.LogError(message:  "Prefab " + System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48 + 16})(System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48 + 16})) + " not found!"(" not found!"));
        goto label_10;
        label_4:
        if(loc == 0)
        {
            goto label_11;
        }
        
        if((this.placementPoints.ContainsKey(key:  loc)) == false)
        {
            goto label_13;
        }
        
        this.placementPoints.Item[loc].PlaceObject(obj:  val_10.gameObject);
        return (DynamicToolTip)val_10;
        label_11:
        val_10.transform.SetParent(p:  0);
        return (DynamicToolTip)val_10;
        label_13:
        UnityEngine.Debug.LogError(message:  "No placement point found/set at "("No placement point found/set at ") + null.ToString() + " Destroying prefab");
        UnityEngine.Object.Destroy(obj:  val_10 = this.prefabsFromFolder);
        label_10:
        val_10 = 0;
        return (DynamicToolTip)val_10;
    }
    public void TryToAddPlacementPoint(DynamicPlacementPoint dPP, DynamicPlacementLocation dPL)
    {
        if((this.placementPoints.ContainsKey(key:  dPL)) != false)
        {
                UnityEngine.Debug.LogError(message:  "Duplicate placement points with position of " + dPL.ToString());
            return;
        }
        
        this.placementPoints.Add(key:  dPL, value:  dPP);
    }
    public void RemovePlacementPoint(DynamicPlacementPoint dPP, DynamicPlacementLocation dPL)
    {
        if((this.placementPoints.ContainsKey(key:  dPL)) != false)
        {
                bool val_2 = this.placementPoints.Remove(key:  dPL);
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Trying to remove a duplicate " + dPL.ToString() + " placement point");
    }
    public UGUIDynamicPlacementManager()
    {
        this.placementPoints = new System.Collections.Generic.Dictionary<DynamicPlacementLocation, DynamicPlacementPoint>();
    }

}
