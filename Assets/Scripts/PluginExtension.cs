using UnityEngine;
public static class PluginExtension
{
    // Methods
    public static void SetX(UnityEngine.Transform transform, float x)
    {
        UnityEngine.Vector3 val_1 = transform.position;
        UnityEngine.Vector3 val_2 = transform.position;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  x, y:  val_1.y, z:  val_2.z);
        transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void SetY(UnityEngine.Transform transform, float y)
    {
        UnityEngine.Vector3 val_1 = transform.position;
        UnityEngine.Vector3 val_2 = transform.position;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_1.x, y:  y, z:  val_2.z);
        transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void SetZ(UnityEngine.Transform transform, float z)
    {
        UnityEngine.Vector3 val_1 = transform.position;
        UnityEngine.Vector3 val_2 = transform.position;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_1.x, y:  val_2.y, z:  z);
        transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void SetPosition2D(UnityEngine.Transform transform, UnityEngine.Vector3 target)
    {
        UnityEngine.Vector3 val_1 = transform.position;
        UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  target.x, y:  target.y, z:  val_1.z);
        transform.position = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
    }
    public static void SetLocalX(UnityEngine.Transform transform, float x)
    {
        UnityEngine.Vector3 val_1 = transform.localPosition;
        UnityEngine.Vector3 val_2 = transform.localPosition;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  x, y:  val_1.y, z:  val_2.z);
        transform.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void SetLocalY(UnityEngine.Transform transform, float y)
    {
        UnityEngine.Vector3 val_1 = transform.localPosition;
        UnityEngine.Vector3 val_2 = transform.localPosition;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_1.x, y:  y, z:  val_2.z);
        transform.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void SetLocalZ(UnityEngine.Transform transform, float z)
    {
        UnityEngine.Vector3 val_1 = transform.localPosition;
        UnityEngine.Vector3 val_2 = transform.localPosition;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_1.x, y:  val_2.y, z:  z);
        transform.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void MoveLocalX(UnityEngine.Transform transform, float deltaX)
    {
        UnityEngine.Vector3 val_1 = transform.localPosition;
        UnityEngine.Vector3 val_2 = transform.localPosition;
        UnityEngine.Vector3 val_3 = transform.localPosition;
        UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  val_1.x + deltaX, y:  val_2.y, z:  val_3.z);
        transform.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
    }
    public static void MoveLocalY(UnityEngine.Transform transform, float deltaY)
    {
        UnityEngine.Vector3 val_1 = transform.localPosition;
        UnityEngine.Vector3 val_2 = transform.localPosition;
        UnityEngine.Vector3 val_3 = transform.localPosition;
        UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  val_1.x, y:  val_2.y + deltaY, z:  val_3.z);
        transform.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
    }
    public static void MoveLocalZ(UnityEngine.Transform transform, float deltaZ)
    {
        UnityEngine.Vector3 val_1 = transform.localPosition;
        UnityEngine.Vector3 val_2 = transform.localPosition;
        UnityEngine.Vector3 val_3 = transform.localPosition;
        val_3.z = val_3.z + deltaZ;
        UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  val_1.x, y:  val_2.y, z:  val_3.z);
        transform.localPosition = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
    }
    public static void MoveLocalXYZ(UnityEngine.Transform transform, float deltaX, float deltaY, float deltaZ)
    {
        UnityEngine.Vector3 val_1 = transform.localPosition;
        UnityEngine.Vector3 val_2 = transform.localPosition;
        UnityEngine.Vector3 val_3 = transform.localPosition;
        val_3.z = val_3.z + deltaZ;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  val_1.x + deltaX, y:  val_2.y + deltaY, z:  val_3.z);
        transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
    }
    public static void SetLocalScaleX(UnityEngine.Transform transform, float x)
    {
        UnityEngine.Vector3 val_1 = transform.localScale;
        UnityEngine.Vector3 val_2 = transform.localScale;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  x, y:  val_1.y, z:  val_2.z);
        transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void SetLocalScaleY(UnityEngine.Transform transform, float y)
    {
        UnityEngine.Vector3 val_1 = transform.localScale;
        UnityEngine.Vector3 val_2 = transform.localScale;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_1.x, y:  y, z:  val_2.z);
        transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void SetLocalScaleZ(UnityEngine.Transform transform, float z)
    {
        UnityEngine.Vector3 val_1 = transform.localScale;
        UnityEngine.Vector3 val_2 = transform.localScale;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_1.x, y:  val_2.y, z:  z);
        transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public static void Times(int count, System.Action action)
    {
        if(count < 1)
        {
                return;
        }
        
        int val_1 = count;
        do
        {
            action.Invoke();
            val_1 = val_1 - 1;
        }
        while(count != 1);
    
    }
    public static void SetColorAlpha(UnityEngine.UI.MaskableGraphic graphic, float a)
    {
        UnityEngine.Color val_1 = graphic.color;
        graphic.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = a};
    }
    public static void LookAt2D(UnityEngine.Transform transform, UnityEngine.Vector3 target, float angle = 0)
    {
        float val_6 = angle;
        UnityEngine.Vector3 val_1 = transform.position;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = target.x, y = target.y, z = target.z}, b:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
        float val_5 = val_2.y;
        val_5 = val_5 * 57.29578f;
        val_6 = val_5 + val_6;
        UnityEngine.Quaternion val_4 = UnityEngine.Quaternion.Euler(x:  0f, y:  0f, z:  val_6 + (-90f));
        transform.rotation = new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w};
    }
    public static void LookAt2D(UnityEngine.Transform transform, UnityEngine.Transform target, float angle = 0)
    {
        UnityEngine.Vector3 val_1 = target.position;
        PluginExtension.LookAt2D(transform:  transform, target:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, angle:  angle);
    }
    public static float Delta(float number, float delta)
    {
        float val_1 = UnityEngine.Random.Range(min:  -delta, max:  delta);
        val_1 = val_1 + number;
        return (float)val_1;
    }
    public static float DeltaPercent(float number, float percent)
    {
        number = -(number * percent);
        float val_2 = UnityEngine.Random.Range(min:  number, max:  number * percent);
        val_2 = val_2 + number;
        return (float)val_2;
    }
    public static void Shuffle<T>(System.Collections.Generic.IList<T> list, System.Nullable<int> seed)
    {
        int val_10;
        var val_11;
        var val_12;
        var val_14;
        var val_16;
        if((seed.HasValue & true) != 0)
        {
            goto label_1;
        }
        
        System.Random val_2 = null;
        val_10 = seed.HasValue.Value;
        val_11 = 0;
        val_12 = val_2;
        val_2 = new System.Random(Seed:  val_10);
        if(list != null)
        {
            goto label_2;
        }
        
        label_1:
        System.Random val_3 = null;
        val_10 = 0;
        val_12 = val_3;
        val_3 = new System.Random();
        label_2:
        var val_10 = 0;
        val_10 = val_10 + 1;
        val_10 = __RuntimeMethodHiddenParam + 48;
        val_11 = 0;
        if(list < 2)
        {
                return;
        }
        
        do
        {
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_14 = 0;
            val_16 = mem[(VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0) + 8];
            val_16 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0) + 8;
            System.Collections.Generic.IList<T> val_6 = list - 1;
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_16 = 0;
            var val_13 = 0;
            val_13 = val_13 + 1;
            var val_14 = 0;
            val_14 = val_14 + 1;
        }
        while(list > 2);
    
    }

}
