using UnityEngine;
public static class ObjectExtensions
{
    // Methods
    public static T SafeDestroy<T>(T obj)
    {
        if(UnityEngine.Application.isEditor != false)
        {
                UnityEngine.Object.DestroyImmediate(obj:  obj);
            return 0;
        }
        
        UnityEngine.Object.Destroy(obj:  obj);
        return 0;
    }
    public static T SafeDestroyGameObject<T>(T component)
    {
        if(component == 0)
        {
                return 0;
        }
        
        UnityEngine.GameObject val_3 = ObjectExtensions.SafeDestroy<UnityEngine.GameObject>(obj:  component.gameObject);
        return 0;
    }

}
