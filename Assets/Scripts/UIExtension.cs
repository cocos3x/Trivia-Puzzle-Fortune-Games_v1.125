using UnityEngine;
public static class UIExtension
{
    // Methods
    public static UnityEngine.Vector3[] GetCorners(UnityEngine.RectTransform rectTransform)
    {
        UnityEngine.Vector3[] val_1 = new UnityEngine.Vector3[4];
        rectTransform.GetWorldCorners(fourCornersArray:  val_1);
        return val_1;
    }
    public static float MaxY(UnityEngine.RectTransform rectTransform)
    {
        return (float)UIExtension.GetCorners(rectTransform:  rectTransform)[2];
    }
    public static float MinY(UnityEngine.RectTransform rectTransform)
    {
        return (float)UIExtension.GetCorners(rectTransform:  rectTransform)[0];
    }
    public static float MaxX(UnityEngine.RectTransform rectTransform)
    {
        return (float)UIExtension.GetCorners(rectTransform:  rectTransform)[3];
    }
    public static float MinX(UnityEngine.RectTransform rectTransform)
    {
        return (float)UIExtension.GetCorners(rectTransform:  rectTransform)[0];
    }

}
