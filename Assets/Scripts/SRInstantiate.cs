using UnityEngine;
public static class SRInstantiate
{
    // Methods
    public static T Instantiate<T>(T prefab)
    {
        goto __RuntimeMethodHiddenParam + 48;
    }
    public static UnityEngine.GameObject Instantiate(UnityEngine.GameObject prefab)
    {
        return UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  prefab);
    }
    public static T Instantiate<T>(T prefab, UnityEngine.Vector3 position, UnityEngine.Quaternion rotation)
    {
        goto __RuntimeMethodHiddenParam + 48;
    }

}
