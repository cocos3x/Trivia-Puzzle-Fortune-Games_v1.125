using UnityEngine;
public class Math3D
{
    // Fields
    private static UnityEngine.Transform tempChild;
    private static UnityEngine.Transform tempParent;
    private static UnityEngine.Vector3[] positionRegister;
    private static float[] posTimeRegister;
    private static int positionSamplesTaken;
    private static UnityEngine.Quaternion[] rotationRegister;
    private static float[] rotTimeRegister;
    
    // Methods
    public static void Init()
    {
        var val_9 = null;
        Math3D.tempChild = new UnityEngine.GameObject(name:  "Math3d_TempChild").transform;
        Math3D.tempParent = new UnityEngine.GameObject(name:  "Math3d_TempParent").transform;
        Math3D.tempChild.gameObject.hideFlags = 61;
        UnityEngine.Object.DontDestroyOnLoad(target:  Math3D.tempChild.gameObject);
        Math3D.tempParent.gameObject.hideFlags = 61;
        UnityEngine.Object.DontDestroyOnLoad(target:  Math3D.tempParent.gameObject);
        Math3D.tempChild.parent = Math3D.tempParent;
    }
    public static UnityEngine.Vector3 AddVectorLength(UnityEngine.Vector3 vector, float size)
    {
        float val_2 = vector.y;
        float val_1 = UnityEngine.Vector3.Magnitude(vector:  new UnityEngine.Vector3() {x = vector.x, y = val_2, z = vector.z});
        val_2 = val_1 + size;
        size = val_2 / val_1;
        return UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = vector.x, y = vector.y, z = vector.z}, d:  size);
    }
    public static UnityEngine.Vector3 SetVectorLength(UnityEngine.Vector3 vector, float size)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.Normalize(value:  new UnityEngine.Vector3() {x = vector.x, y = vector.y, z = vector.z});
        return UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, d:  size);
    }
    public static UnityEngine.Quaternion SubtractRotation(UnityEngine.Quaternion B, UnityEngine.Quaternion A)
    {
        UnityEngine.Quaternion val_1 = UnityEngine.Quaternion.Inverse(rotation:  new UnityEngine.Quaternion() {x = A.x, y = A.y, z = A.z, w = A.w});
        return UnityEngine.Quaternion.op_Multiply(lhs:  new UnityEngine.Quaternion() {x = val_1.x, y = val_1.y, z = val_1.z, w = val_1.w}, rhs:  new UnityEngine.Quaternion() {x = B.x, y = B.y, z = B.z, w = B.w});
    }
    public static bool PlanePlaneIntersection(out UnityEngine.Vector3 linePoint, out UnityEngine.Vector3 lineVec, UnityEngine.Vector3 plane1Normal, UnityEngine.Vector3 plane1Position, UnityEngine.Vector3 plane2Normal, UnityEngine.Vector3 plane2Position)
    {
        float val_1;
        float val_7;
        float val_12;
        var val_13;
        val_12 = plane2Normal.x;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        linePoint.x = val_2.x;
        linePoint.y = val_2.y;
        linePoint.z = val_2.z;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        lineVec.x = val_3.x;
        lineVec.y = val_3.y;
        lineVec.z = val_3.z;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = plane1Normal.x, y = plane1Normal.y, z = plane1Normal.z}, rhs:  new UnityEngine.Vector3() {x = val_12, y = val_1, z = plane2Normal.y});
        lineVec.x = val_4.x;
        lineVec.y = val_4.y;
        lineVec.z = val_4.z;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = val_12, y = val_1, z = plane2Normal.y}, rhs:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
        float val_6 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = plane1Normal.x, y = plane1Normal.y, z = plane1Normal.z}, rhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
        if(System.Math.Abs(val_6) > 0.006f)
        {
                val_12 = val_7;
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = plane1Position.x, y = plane1Position.y, z = plane1Position.z}, b:  new UnityEngine.Vector3() {x = plane2Normal.z, y = val_12, z = plane2Position.x});
            float val_9 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = plane1Normal.x, y = plane1Normal.y, z = plane1Normal.z}, rhs:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
            val_9 = val_9 / val_6;
            UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Multiply(d:  val_9, a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
            UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = plane2Normal.z, y = val_12, z = plane2Position.x}, b:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
            val_13 = 1;
            linePoint.x = val_11.x;
            linePoint.y = val_11.y;
            linePoint.z = val_11.z;
            return (bool)val_13;
        }
        
        val_13 = 0;
        return (bool)val_13;
    }
    public static bool LinePlaneIntersection(out UnityEngine.Vector3 intersection, UnityEngine.Vector3 linePoint, UnityEngine.Vector3 lineVec, UnityEngine.Vector3 planeNormal, UnityEngine.Vector3 planePoint)
    {
        float val_1;
        float val_2;
        float val_9;
        float val_10;
        var val_11;
        val_9 = planeNormal.x;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        intersection.x = val_3.x;
        intersection.y = val_3.y;
        intersection.z = val_3.z;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = planeNormal.z, y = val_1, z = planePoint.x}, b:  new UnityEngine.Vector3() {x = linePoint.x, y = linePoint.y, z = linePoint.z});
        val_10 = lineVec.z;
        float val_6 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = lineVec.x, y = lineVec.y, z = val_10}, rhs:  new UnityEngine.Vector3() {x = val_9, y = val_2, z = planeNormal.y});
        if(val_6 != 0f)
        {
                val_9 = (UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, rhs:  new UnityEngine.Vector3() {x = val_9, y = val_2, z = planeNormal.y})) / val_6;
            UnityEngine.Vector3 val_7 = Math3D.SetVectorLength(vector:  new UnityEngine.Vector3() {x = lineVec.x, y = lineVec.y, z = val_10}, size:  val_9);
            val_9 = val_7.x;
            val_10 = val_7.z;
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = linePoint.x, y = linePoint.y, z = linePoint.z}, b:  new UnityEngine.Vector3() {x = val_9, y = val_7.y, z = val_10});
            val_11 = 1;
            intersection.x = val_8.x;
            intersection.y = val_8.y;
            intersection.z = val_8.z;
            return (bool)val_11;
        }
        
        val_11 = 0;
        return (bool)val_11;
    }
    public static bool LineLineIntersection(out UnityEngine.Vector3 intersection, UnityEngine.Vector3 linePoint1, UnityEngine.Vector3 lineVec1, UnityEngine.Vector3 linePoint2, UnityEngine.Vector3 lineVec2)
    {
        float val_1;
        float val_2;
        float val_12;
        float val_13;
        float val_14;
        var val_15;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        intersection.x = val_3.x;
        intersection.y = val_3.y;
        intersection.z = val_3.z;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = linePoint2.x, y = val_2, z = linePoint2.y}, b:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z});
        val_12 = val_4.x;
        val_13 = val_4.z;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = lineVec1.x, y = lineVec1.y, z = lineVec1.z}, rhs:  new UnityEngine.Vector3() {x = linePoint2.z, y = val_1, z = lineVec2.x});
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = val_12, y = val_4.y, z = val_13}, rhs:  new UnityEngine.Vector3() {x = linePoint2.z, y = val_1, z = lineVec2.x});
        val_14 = val_6.x;
        float val_7 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_12, y = val_4.y, z = val_13}, rhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
        val_15 = 0;
        if(val_7 >= (1E-05f))
        {
                return (bool)val_15;
        }
        
        val_12 = linePoint1.z;
        val_13 = linePoint1.x;
        if(val_7 <= (-1E-05f))
        {
                return (bool)val_15;
        }
        
        val_14 = (UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_14, y = val_6.y, z = val_6.z}, rhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z})) / val_5.x.sqrMagnitude;
        val_15 = 0;
        if(val_14 < 0f)
        {
                return (bool)val_15;
        }
        
        if(val_14 > 1f)
        {
                return (bool)val_15;
        }
        
        UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = lineVec1.x, y = lineVec1.y, z = lineVec1.z}, d:  val_14);
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_13, y = linePoint1.y, z = val_12}, b:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
        val_15 = 1;
        intersection.x = val_11.x;
        intersection.y = val_11.y;
        intersection.z = val_11.z;
        return (bool)val_15;
    }
    public static bool LineLineIntersection(out UnityEngine.Vector3 intersection, UnityEngine.Ray ray1, UnityEngine.Ray ray2)
    {
        UnityEngine.Vector3 val_1 = ray1.origin;
        UnityEngine.Vector3 val_2 = ray1.direction;
        UnityEngine.Vector3 val_3 = ray2.origin;
        UnityEngine.Vector3 val_4 = ray2.direction;
        return (bool)Math3D.LineLineIntersection(intersection: out  new UnityEngine.Vector3() {x = intersection.x, y = intersection.y, z = intersection.z}, linePoint1:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, lineVec1:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, linePoint2:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.z, z = val_4.x}, lineVec2:  new UnityEngine.Vector3() {x = val_4.z, y = val_2.x, z = val_1.y});
    }
    public static bool ClosestPointsOnTwoLines(out UnityEngine.Vector3 closestPointLine1, out UnityEngine.Vector3 closestPointLine2, UnityEngine.Vector3 linePoint1, UnityEngine.Vector3 lineVec1, UnityEngine.Vector3 linePoint2, UnityEngine.Vector3 lineVec2)
    {
        float val_1;
        float val_8;
        float val_18;
        float val_19;
        float val_20;
        float val_21;
        var val_22;
        val_18 = lineVec1.z;
        float val_19 = val_1;
        val_19 = lineVec2.x;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        closestPointLine1.x = val_2.x;
        closestPointLine1.y = val_2.y;
        closestPointLine1.z = val_2.z;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        closestPointLine2.x = val_3.x;
        closestPointLine2.y = val_3.y;
        closestPointLine2.z = val_3.z;
        val_20 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = lineVec1.x, y = lineVec1.y, z = val_18}, rhs:  new UnityEngine.Vector3() {x = lineVec1.x, y = lineVec1.y, z = val_18});
        float val_22 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = lineVec1.x, y = lineVec1.y, z = val_18}, rhs:  new UnityEngine.Vector3() {x = linePoint2.z, y = val_19, z = val_19});
        float val_18 = val_19;
        float val_6 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = linePoint2.z, y = val_19, z = val_18}, rhs:  new UnityEngine.Vector3() {x = linePoint2.z, y = val_19, z = val_19});
        val_18 = val_20 * val_6;
        val_19 = val_18 - (val_22 * val_22);
        if(val_19 != 0f)
        {
                val_21 = linePoint2.x;
            val_21 = val_21;
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z}, b:  new UnityEngine.Vector3() {x = val_21, y = val_8, z = linePoint2.y});
            val_19 = lineVec1.x;
            val_20 = val_9.y;
            val_18 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_19, y = lineVec1.y, z = val_18}, rhs:  new UnityEngine.Vector3() {x = val_9.x, y = val_20, z = val_9.z});
            float val_20 = val_19;
            float val_11 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = linePoint2.z, y = val_20, z = val_19}, rhs:  new UnityEngine.Vector3() {x = val_9.x, y = val_20, z = val_9.z});
            float val_21 = val_6;
            val_20 = val_22 * val_11;
            val_21 = val_21 * val_18;
            val_20 = val_20 - val_21;
            val_11 = val_20 * val_11;
            val_11 = val_11 - (val_22 * val_18);
            val_22 = val_11 / val_19;
            UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_19, y = lineVec1.y, z = val_18}, d:  val_20 / val_19);
            UnityEngine.Vector3 val_15 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z}, b:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
            closestPointLine1.x = val_15.x;
            closestPointLine1.y = val_15.y;
            closestPointLine1.z = val_15.z;
            UnityEngine.Vector3 val_16 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = linePoint2.z, y = val_19, z = val_19}, d:  val_22);
            UnityEngine.Vector3 val_17 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_21, y = val_8, z = linePoint2.y}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
            val_22 = 1;
            closestPointLine2.x = val_17.x;
            closestPointLine2.y = val_17.y;
            closestPointLine2.z = val_17.z;
            return (bool)val_22;
        }
        
        val_22 = 0;
        return (bool)val_22;
    }
    public static UnityEngine.Vector3 ProjectPointOnLine(UnityEngine.Vector3 linePoint, UnityEngine.Vector3 lineVec, UnityEngine.Vector3 point)
    {
        float val_1;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = point.x, y = val_1, z = point.y}, b:  new UnityEngine.Vector3() {x = linePoint.x, y = linePoint.y, z = linePoint.z});
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = lineVec.x, y = lineVec.y, z = lineVec.z}, d:  UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, rhs:  new UnityEngine.Vector3() {x = lineVec.x, y = lineVec.y, z = lineVec.z}));
        return UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = linePoint.x, y = linePoint.y, z = linePoint.z}, b:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
    }
    public static UnityEngine.Vector3 ProjectPointOnLineSegment(UnityEngine.Vector3 linePoint1, UnityEngine.Vector3 linePoint2, UnityEngine.Vector3 point)
    {
        var val_7;
        float val_11;
        float val_12;
        float val_13;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = linePoint2.x, y = linePoint2.y, z = linePoint2.z}, b:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z});
        UnityEngine.Vector3 val_3 = val_2.x.normalized;
        val_7 = null;
        UnityEngine.Vector3 val_4 = Math3D.ProjectPointOnLine(linePoint:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z}, lineVec:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, point:  new UnityEngine.Vector3() {x = point.x, y = point.y});
        val_11 = val_4.x;
        val_12 = val_4.y;
        val_13 = val_4.z;
        int val_5 = Math3D.PointOnWhichSideOfLineSegment(linePoint1:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z}, linePoint2:  new UnityEngine.Vector3() {x = linePoint2.x, y = linePoint2.y, z = linePoint2.z}, point:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.z});
        if(val_5 == 0)
        {
                return new UnityEngine.Vector3() {x = val_11, y = val_12, z = val_13};
        }
        
        if(val_5 == 1)
        {
            goto label_6;
        }
        
        if(val_5 != 2)
        {
            goto label_7;
        }
        
        val_11 = linePoint2.x;
        val_12 = linePoint2.y;
        val_13 = linePoint2.z;
        return new UnityEngine.Vector3() {x = val_11, y = val_12, z = val_13};
        label_6:
        val_11 = linePoint1.x;
        val_12 = linePoint1.y;
        val_13 = linePoint1.z;
        return new UnityEngine.Vector3() {x = val_11, y = val_12, z = val_13};
        label_7:
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        val_11 = val_6.x;
        val_12 = val_6.y;
        val_13 = val_6.z;
        return new UnityEngine.Vector3() {x = val_11, y = val_12, z = val_13};
    }
    public static UnityEngine.Vector3 ProjectPointOnPlane(UnityEngine.Vector3 planeNormal, UnityEngine.Vector3 planePoint, UnityEngine.Vector3 point)
    {
        float val_1;
        float val_4;
        float val_5;
        float val_6;
        float val_7;
        val_4 = val_1;
        val_5 = point.y;
        val_6 = point.x;
        val_7 = planePoint.z;
        val_5 = val_5;
        val_4 = val_4;
        val_6 = val_6;
        val_7 = val_7;
        val_5 = val_5;
        val_4 = val_4;
        val_6 = val_6;
        UnityEngine.Vector3 val_3 = Math3D.SetVectorLength(vector:  new UnityEngine.Vector3() {x = planeNormal.x, y = planeNormal.y, z = planeNormal.z}, size:  -(Math3D.SignedDistancePlanePoint(planeNormal:  new UnityEngine.Vector3() {x = planeNormal.x, y = planeNormal.y, z = planeNormal.z}, planePoint:  new UnityEngine.Vector3() {x = planePoint.x, y = planePoint.y, z = val_7}, point:  new UnityEngine.Vector3() {x = val_6, y = val_5, z = ???})));
        return UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_6, y = val_4, z = val_5}, b:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
    }
    public static UnityEngine.Vector3 ProjectVectorOnPlane(UnityEngine.Vector3 planeNormal, UnityEngine.Vector3 vector)
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Multiply(d:  UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = vector.x, y = vector.y, z = vector.z}, rhs:  new UnityEngine.Vector3() {x = planeNormal.x, y = planeNormal.y, z = planeNormal.z}), a:  new UnityEngine.Vector3() {x = planeNormal.x, y = planeNormal.y, z = planeNormal.z});
        return UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = vector.x, y = vector.y, z = vector.z}, b:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
    }
    public static float SignedDistancePlanePoint(UnityEngine.Vector3 planeNormal, UnityEngine.Vector3 planePoint, UnityEngine.Vector3 point)
    {
        float val_1;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = point.x, y = val_1, z = point.y}, b:  new UnityEngine.Vector3() {x = planePoint.x, y = planePoint.y, z = planePoint.z});
        return UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = planeNormal.x, y = planeNormal.y, z = planeNormal.z}, rhs:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
    }
    public static float SignedDotProduct(UnityEngine.Vector3 vectorA, UnityEngine.Vector3 vectorB, UnityEngine.Vector3 normal)
    {
        float val_1;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = normal.x, y = val_1, z = normal.y}, rhs:  new UnityEngine.Vector3() {x = vectorA.x, y = vectorA.y, z = vectorA.z});
        return UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, rhs:  new UnityEngine.Vector3() {x = vectorB.x, y = vectorB.y, z = vectorB.z});
    }
    public static float SignedVectorAngle(UnityEngine.Vector3 referenceVector, UnityEngine.Vector3 otherVector, UnityEngine.Vector3 normal)
    {
        float val_1;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = normal.x, y = val_1, z = normal.y}, rhs:  new UnityEngine.Vector3() {x = referenceVector.x, y = referenceVector.y, z = referenceVector.z});
        float val_5 = UnityEngine.Mathf.Sign(f:  UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, rhs:  new UnityEngine.Vector3() {x = otherVector.x, y = otherVector.y, z = otherVector.z}));
        val_5 = (UnityEngine.Vector3.Angle(from:  new UnityEngine.Vector3() {x = referenceVector.x, y = referenceVector.y, z = referenceVector.z}, to:  new UnityEngine.Vector3() {x = otherVector.x, y = otherVector.y, z = otherVector.z})) * val_5;
        return (float)val_5;
    }
    public static float AngleVectorPlane(UnityEngine.Vector3 vector, UnityEngine.Vector3 normal)
    {
        float val_2 = (float)(double)UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = vector.x, y = vector.y, z = vector.z}, rhs:  new UnityEngine.Vector3() {x = normal.x, y = normal.y, z = normal.z});
        val_2 = 1.570796f - val_2;
        return (float)val_2;
    }
    public static float DotProductAngle(UnityEngine.Vector3 vec1, UnityEngine.Vector3 vec2)
    {
        float val_1 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = vec1.x, y = vec1.y, z = vec1.z}, rhs:  new UnityEngine.Vector3() {x = vec2.x, y = vec2.y, z = vec2.z});
        return (float)(float)vec2.z;
    }
    public static void PlaneFrom3Points(out UnityEngine.Vector3 planeNormal, out UnityEngine.Vector3 planePoint, UnityEngine.Vector3 pointA, UnityEngine.Vector3 pointB, UnityEngine.Vector3 pointC)
    {
        float val_1;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        planeNormal.x = val_2.x;
        planeNormal.y = val_2.y;
        planeNormal.z = val_2.z;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        planePoint.x = val_3.x;
        planePoint.y = val_3.y;
        planePoint.z = val_3.z;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = pointB.x, y = pointB.y, z = pointB.z}, b:  new UnityEngine.Vector3() {x = pointA.x, y = pointA.y, z = pointA.z});
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = pointC.x, y = val_1, z = pointC.y}, b:  new UnityEngine.Vector3() {x = pointA.x, y = pointA.y, z = pointA.z});
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, rhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.Normalize(value:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        planeNormal.x = val_7.x;
        planeNormal.y = val_7.y;
        planeNormal.z = val_7.z;
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, d:  2f);
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = pointA.x, y = pointA.y, z = pointA.z}, b:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
        UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, d:  2f);
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = pointA.x, y = pointA.y, z = pointA.z}, b:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = pointC.x, y = val_1, z = pointC.y}, b:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = pointB.x, y = pointB.y, z = pointB.z}, b:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
        bool val_14 = Math3D.ClosestPointsOnTwoLines(closestPointLine1: out  new UnityEngine.Vector3() {x = planePoint.x, y = planePoint.y, z = planePoint.z}, closestPointLine2: out  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, linePoint1:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, lineVec1:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, linePoint2:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.z, z = val_13.x}, lineVec2:  new UnityEngine.Vector3() {x = val_13.z, y = val_12.y, z = pointB.x});
    }
    public static UnityEngine.Vector3 GetForwardVector(UnityEngine.Quaternion q)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.forward;
        return UnityEngine.Quaternion.op_Multiply(rotation:  new UnityEngine.Quaternion() {x = q.x, y = q.y, z = q.z, w = q.w}, point:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
    }
    public static UnityEngine.Vector3 GetUpVector(UnityEngine.Quaternion q)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.up;
        return UnityEngine.Quaternion.op_Multiply(rotation:  new UnityEngine.Quaternion() {x = q.x, y = q.y, z = q.z, w = q.w}, point:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
    }
    public static UnityEngine.Vector3 GetRightVector(UnityEngine.Quaternion q)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.right;
        return UnityEngine.Quaternion.op_Multiply(rotation:  new UnityEngine.Quaternion() {x = q.x, y = q.y, z = q.z, w = q.w}, point:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
    }
    public static UnityEngine.Quaternion QuaternionFromMatrix(UnityEngine.Matrix4x4 m)
    {
        UnityEngine.Vector4 val_1 = m.GetColumn(index:  2);
        UnityEngine.Vector3 val_2 = UnityEngine.Vector4.op_Implicit(v:  new UnityEngine.Vector4() {x = val_1.x, y = val_1.y, z = val_1.z, w = val_1.w});
        UnityEngine.Vector4 val_3 = m.GetColumn(index:  1);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector4.op_Implicit(v:  new UnityEngine.Vector4() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w});
        return UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, upwards:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
    }
    public static UnityEngine.Vector3 PositionFromMatrix(UnityEngine.Matrix4x4 m)
    {
        UnityEngine.Vector4 val_1 = m.GetColumn(index:  3);
        UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  val_1.x, y:  val_1.y, z:  val_1.z);
        return new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
    }
    public static void LookRotationExtended(ref UnityEngine.GameObject gameObjectInOut, UnityEngine.Vector3 alignWithVector, UnityEngine.Vector3 alignWithNormal, UnityEngine.Vector3 customForward, UnityEngine.Vector3 customUp)
    {
        float val_1;
        float val_2;
        UnityEngine.Quaternion val_3 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = alignWithVector.x, y = alignWithVector.y, z = alignWithVector.z}, upwards:  new UnityEngine.Vector3() {x = alignWithNormal.x, y = alignWithNormal.y, z = alignWithNormal.z});
        UnityEngine.Quaternion val_4 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = customForward.x, y = val_2, z = customForward.y}, upwards:  new UnityEngine.Vector3() {x = customForward.z, y = val_1, z = customUp.x});
        UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.Inverse(rotation:  new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w});
        UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.op_Multiply(lhs:  new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w}, rhs:  new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w});
        gameObjectInOut.transform.rotation = new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w};
    }
    public static void TransformWithParent(out UnityEngine.Quaternion childRotation, out UnityEngine.Vector3 childPosition, UnityEngine.Quaternion parentRotation, UnityEngine.Vector3 parentPosition, UnityEngine.Quaternion startParentRotation, UnityEngine.Vector3 startParentPosition, UnityEngine.Quaternion startChildRotation, UnityEngine.Vector3 startChildPosition)
    {
        float val_3;
        float val_4;
        float val_5;
        float val_7;
        float val_8;
        float val_9;
        var val_13;
        UnityEngine.Quaternion val_1 = UnityEngine.Quaternion.identity;
        childRotation.x = val_1.x;
        childRotation.y = val_1.y;
        childRotation.z = val_1.z;
        childRotation.w = val_1.w;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        childPosition.x = val_2.x;
        childPosition.y = val_2.y;
        childPosition.z = val_2.z;
        val_13 = null;
        val_13 = null;
        Math3D.tempParent.rotation = new UnityEngine.Quaternion() {x = startParentRotation.x, y = val_4, z = startParentRotation.y, w = val_3};
        Math3D.tempParent.position = new UnityEngine.Vector3() {x = startParentRotation.z, y = val_5, z = startParentRotation.w};
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.one;
        Math3D.tempParent.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        Math3D.tempChild.rotation = new UnityEngine.Quaternion() {x = startParentPosition.x, y = val_8, z = startParentPosition.y, w = val_7};
        Math3D.tempChild.position = new UnityEngine.Vector3() {x = startParentPosition.z, y = val_9, z = startChildRotation.x};
        UnityEngine.Vector3 val_10 = UnityEngine.Vector3.one;
        Math3D.tempChild.localScale = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
        Math3D.tempParent.rotation = new UnityEngine.Quaternion() {x = parentRotation.x, y = parentRotation.y, z = parentRotation.z, w = parentRotation.w};
        Math3D.tempParent.position = new UnityEngine.Vector3() {x = parentPosition.x, y = parentPosition.y, z = parentPosition.z};
        UnityEngine.Quaternion val_11 = Math3D.tempChild.rotation;
        childRotation.x = val_11.x;
        childRotation.y = val_11.y;
        childRotation.z = val_11.z;
        childRotation.w = val_11.w;
        UnityEngine.Vector3 val_12 = Math3D.tempChild.position;
        childPosition.x = val_12.x;
        childPosition.y = val_12.y;
        childPosition.z = val_12.z;
    }
    public static void PreciseAlign(ref UnityEngine.GameObject gameObjectInOut, UnityEngine.Vector3 alignWithVector, UnityEngine.Vector3 alignWithNormal, UnityEngine.Vector3 alignWithPosition, UnityEngine.Vector3 triangleForward, UnityEngine.Vector3 triangleNormal, UnityEngine.Vector3 trianglePosition)
    {
        float val_1;
        float val_4;
        float val_10;
        float val_11;
        float val_12;
        float val_13;
        float val_14;
        float val_15;
        val_10 = triangleForward.z;
        val_11 = triangleForward.y;
        val_12 = alignWithPosition.z;
        val_13 = alignWithNormal.x;
        val_14 = alignWithVector.y;
        val_12 = val_12;
        val_10 = val_10;
        val_11 = val_11;
        val_15 = val_14;
        val_13 = val_13;
        val_14 = val_15;
        val_12 = val_12;
        val_10 = val_10;
        val_11 = val_11;
        val_15 = val_14;
        Math3D.LookRotationExtended(gameObjectInOut: ref  UnityEngine.GameObject val_5 = gameObjectInOut, alignWithVector:  new UnityEngine.Vector3() {x = alignWithVector.x, y = val_15, z = alignWithVector.z}, alignWithNormal:  new UnityEngine.Vector3() {x = val_13, y = alignWithNormal.y, z = alignWithNormal.z}, customForward:  new UnityEngine.Vector3() {x = val_12, y = triangleForward.x, z = val_11}, customUp:  new UnityEngine.Vector3() {x = val_10, z = alignWithNormal.z});
        UnityEngine.Vector3 val_7 = val_5.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = triangleNormal.x, y = val_1, z = triangleNormal.y});
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = alignWithPosition.x, y = val_4, z = alignWithPosition.y}, b:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        val_5.transform.Translate(translation:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, relativeTo:  0);
    }
    public static void VectorsToTransform(ref UnityEngine.GameObject gameObjectInOut, UnityEngine.Vector3 positionVector, UnityEngine.Vector3 directionVector, UnityEngine.Vector3 normalVector)
    {
        float val_1;
        gameObjectInOut.transform.position = new UnityEngine.Vector3() {x = positionVector.x, y = positionVector.y, z = positionVector.z};
        UnityEngine.Quaternion val_4 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = directionVector.x, y = directionVector.y, z = directionVector.z}, upwards:  new UnityEngine.Vector3() {x = normalVector.x, y = val_1, z = normalVector.y});
        gameObjectInOut.transform.rotation = new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w};
    }
    public static int PointOnWhichSideOfLineSegment(UnityEngine.Vector3 linePoint1, UnityEngine.Vector3 linePoint2, UnityEngine.Vector3 point)
    {
        float val_1;
        float val_9;
        var val_10;
        val_9 = linePoint1.z;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = linePoint2.x, y = linePoint2.y, z = linePoint2.z}, b:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = val_9});
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = point.x, y = val_1, z = point.y}, b:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = val_9});
        if((UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, rhs:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z})) > 0f)
        {
                val_9 = val_3.x.magnitude;
            val_10 = ((val_9 > val_2.x.magnitude) ? 1 : 0) << 1;
            return (int)val_10;
        }
        
        val_10 = 1;
        return (int)val_10;
    }
    public static float MouseDistanceToLine(UnityEngine.Vector3 linePoint1, UnityEngine.Vector3 linePoint2)
    {
        UnityEngine.Camera val_1 = UnityEngine.Camera.main;
        UnityEngine.Vector3 val_2 = UnityEngine.Input.mousePosition;
        UnityEngine.Vector3 val_3 = val_1.WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z});
        UnityEngine.Vector3 val_4 = val_1.WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = linePoint2.x, y = linePoint2.y, z = linePoint2.z});
        UnityEngine.Vector3 val_5 = Math3D.ProjectPointOnLineSegment(linePoint1:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, linePoint2:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, point:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.z, z = 0f});
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  val_5.x, y:  val_5.y, z:  0f);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, b:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        return (float)val_7.x.magnitude;
    }
    public static float MouseDistanceToCircle(UnityEngine.Vector3 point, float radius)
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Input.mousePosition;
        UnityEngine.Vector3 val_3 = UnityEngine.Camera.main.WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = point.x, y = point.y, z = point.z});
        UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  val_3.x, y:  val_3.y, z:  0f);
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, b:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        float val_6 = val_5.x.magnitude;
        val_6 = val_6 - radius;
        return (float)val_6;
    }
    public static bool IsLineInRectangle(UnityEngine.Vector3 linePoint1, UnityEngine.Vector3 linePoint2, UnityEngine.Vector3 rectA, UnityEngine.Vector3 rectB, UnityEngine.Vector3 rectC, UnityEngine.Vector3 rectD)
    {
        var val_1;
        float val_2;
        var val_3;
        float val_4;
        var val_13;
        float val_14;
        float val_15;
        float val_16;
        var val_17;
        float val_18;
        float val_19;
        float val_20;
        float val_21;
        float val_22;
        var val_23;
        var val_24;
        var val_25;
        val_13 = 1152921504875589632;
        val_14 = rectC.y;
        val_16 = val_2;
        val_15 = rectB.z;
        val_17 = null;
        val_18 = rectB.y;
        val_20 = val_3;
        val_19 = rectB.x;
        val_21 = rectA.x;
        val_15 = val_15;
        val_19 = val_19;
        val_14 = val_14;
        val_20 = val_20;
        val_22 = val_15;
        if((Math3D.IsPointInRectangle(point:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z}, rectA:  new UnityEngine.Vector3() {x = val_21, y = val_4, z = rectA.y}, rectC:  new UnityEngine.Vector3() {x = val_18, y = val_15, z = rectA.z}, rectB:  new UnityEngine.Vector3() {x = val_19, y = rectC.x, z = val_14}, rectD:  new UnityEngine.Vector3())) == true)
        {
            goto label_3;
        }
        
        val_23 = null;
        if((Math3D.IsPointInRectangle(point:  new UnityEngine.Vector3() {x = linePoint2.x, y = linePoint2.y, z = linePoint2.z}, rectA:  new UnityEngine.Vector3() {x = val_21, y = val_4, z = rectA.y}, rectC:  new UnityEngine.Vector3() {x = val_18, y = val_22, z = rectA.z}, rectB:  new UnityEngine.Vector3() {x = val_19, y = rectC.x, z = val_14}, rectD:  new UnityEngine.Vector3() {z = val_16})) == false)
        {
            goto label_6;
        }
        
        label_3:
        val_24 = 1;
        return (bool)val_24;
        label_6:
        val_25 = null;
        val_22 = linePoint2.y;
        val_18 = linePoint1.z;
        val_21 = val_1;
        val_16 = linePoint2.x;
        val_13 = Math3D.AreLineSegmentsCrossing(pointA1:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = val_18}, pointA2:  new UnityEngine.Vector3() {x = val_16, y = val_22, z = linePoint2.z}, pointB1:  new UnityEngine.Vector3() {x = val_18, y = val_22, z = rectC.x}, pointB2:  new UnityEngine.Vector3() {x = val_14, y = rectC.x, z = val_14});
        bool val_12 = ((Math3D.AreLineSegmentsCrossing(pointA1:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z}, pointA2:  new UnityEngine.Vector3() {x = linePoint2.x, y = linePoint2.y, z = linePoint2.z}, pointB1:  new UnityEngine.Vector3() {x = val_21, y = rectA.y, z = rectA.z}, pointB2:  new UnityEngine.Vector3() {x = val_19, y = rectC.x, z = val_14})) | (Math3D.AreLineSegmentsCrossing(pointA1:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = linePoint1.z}, pointA2:  new UnityEngine.Vector3() {x = linePoint2.x, y = val_22, z = linePoint2.z}, pointB1:  new UnityEngine.Vector3() {x = rectA.z, y = val_19, z = val_18}, pointB2:  new UnityEngine.Vector3() {x = val_22, y = rectC.x, z = val_14}))) | val_13;
        val_12 = val_12 | (Math3D.AreLineSegmentsCrossing(pointA1:  new UnityEngine.Vector3() {x = linePoint1.x, y = linePoint1.y, z = val_18}, pointA2:  new UnityEngine.Vector3() {x = val_16, y = val_22, z = linePoint2.z}, pointB1:  new UnityEngine.Vector3() {x = rectC.x, y = val_14, z = val_21}, pointB2:  new UnityEngine.Vector3() {x = rectA.y, y = rectC.x, z = val_14}));
        val_24 = val_12;
        return (bool)val_24;
    }
    public static bool IsPointInRectangle(UnityEngine.Vector3 point, UnityEngine.Vector3 rectA, UnityEngine.Vector3 rectC, UnityEngine.Vector3 rectB, UnityEngine.Vector3 rectD)
    {
        float val_1;
        float val_2;
        float val_3;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = rectC.x, y = val_1, z = rectC.y}, b:  new UnityEngine.Vector3() {x = rectA.x, y = rectA.y, z = rectA.z});
        UnityEngine.Vector3 val_7 = Math3D.AddVectorLength(vector:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, size:  val_4.x.magnitude * (-0.5f));
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = rectA.x, y = rectA.y, z = rectA.z}, b:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = rectC.z, y = val_3, z = rectB.x}, b:  new UnityEngine.Vector3() {x = rectA.x, y = rectA.y, z = rectA.z});
        float val_10 = val_9.x.magnitude;
        val_10 = val_10 * 0.5f;
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = rectB.y, y = val_2, z = rectB.z}, b:  new UnityEngine.Vector3() {x = rectA.x, y = rectA.y, z = rectA.z});
        UnityEngine.Vector3 val_13 = val_9.x.normalized;
        UnityEngine.Vector3 val_14 = Math3D.ProjectPointOnLine(linePoint:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, lineVec:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, point:  new UnityEngine.Vector3() {x = point.x, y = point.z});
        UnityEngine.Vector3 val_15 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, b:  new UnityEngine.Vector3() {x = point.x, y = point.y, z = point.z});
        UnityEngine.Vector3 val_17 = val_11.x.normalized;
        UnityEngine.Vector3 val_18 = Math3D.ProjectPointOnLine(linePoint:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, lineVec:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z}, point:  new UnityEngine.Vector3() {x = point.x, y = point.z});
        UnityEngine.Vector3 val_19 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, b:  new UnityEngine.Vector3() {x = point.x, y = point.y, z = point.z});
        float val_24 = 0.5f;
        val_24 = val_11.x.magnitude * val_24;
        return (bool)((val_19.x.magnitude <= val_10) ? 1 : 0) & ((val_15.x.magnitude <= val_24) ? 1 : 0);
    }
    public static bool AreLineSegmentsCrossing(UnityEngine.Vector3 pointA1, UnityEngine.Vector3 pointA2, UnityEngine.Vector3 pointB1, UnityEngine.Vector3 pointB2)
    {
        float val_1;
        float val_2;
        float val_12;
        float val_13;
        var val_14;
        var val_15;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = pointA2.x, y = pointA2.y, z = pointA2.z}, b:  new UnityEngine.Vector3() {x = pointA1.x, y = pointA1.y, z = pointA1.z});
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = pointB1.z, y = val_2, z = pointB2.x}, b:  new UnityEngine.Vector3() {x = pointB1.x, y = val_1, z = pointB1.y});
        UnityEngine.Vector3 val_5 = val_3.x.normalized;
        val_12 = val_5.z;
        UnityEngine.Vector3 val_6 = val_4.x.normalized;
        val_13 = val_6.y;
        if((Math3D.ClosestPointsOnTwoLines(closestPointLine1: out  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, closestPointLine2: out  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, linePoint1:  new UnityEngine.Vector3() {x = pointA1.x, y = pointA1.y, z = pointA1.z}, lineVec1:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_12}, linePoint2:  new UnityEngine.Vector3() {x = pointB1.x, y = pointB1.y, z = val_6.x}, lineVec2:  new UnityEngine.Vector3() {x = val_6.z, y = val_2, z = pointA2.x})) != false)
        {
                val_14 = null;
            val_13 = 0f;
            val_12 = 0f;
            var val_11 = (((Math3D.PointOnWhichSideOfLineSegment(linePoint1:  new UnityEngine.Vector3() {x = pointA1.x, y = pointA1.y, z = pointA1.z}, linePoint2:  new UnityEngine.Vector3() {x = pointA2.x, y = pointA2.y, z = pointA2.z}, point:  new UnityEngine.Vector3() {x = 0f, y = val_12, z = val_6.x})) | (Math3D.PointOnWhichSideOfLineSegment(linePoint1:  new UnityEngine.Vector3() {x = pointB1.x, y = val_1, z = pointB1.y}, linePoint2:  new UnityEngine.Vector3() {x = pointB1.z, y = val_2, z = pointB2.x}, point:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = val_6.x}))) == 0) ? 1 : 0;
            return (bool)val_15;
        }
        
        val_15 = 0;
        return (bool)val_15;
    }
    public static bool LinearAcceleration(out UnityEngine.Vector3 vector, UnityEngine.Vector3 position, int samples)
    {
        float val_22;
        float val_23;
        float val_24;
        float val_25;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_33;
        UnityEngine.Vector3[] val_34;
        System.Single[] val_35;
        var val_37;
        var val_38;
        UnityEngine.Vector3 val_39;
        var val_40;
        UnityEngine.Vector3[] val_41;
        var val_42;
        val_22 = position.y;
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
        val_23 = val_1.x;
        val_24 = val_1.y;
        val_25 = val_1.z;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        vector.x = val_2.x;
        vector.y = val_2.y;
        vector.z = val_2.z;
        val_28 = null;
        val_28 = null;
        if(Math3D.positionRegister == null)
        {
                UnityEngine.Vector3[] val_4 = new UnityEngine.Vector3[0];
            val_29 = null;
            val_29 = null;
            Math3D.positionRegister = val_4;
            val_28 = null;
            Math3D.posTimeRegister = new float[0];
        }
        
        val_30 = 0;
        val_31 = 4294967296;
        val_32 = -4294967296;
        val_33 = 4294967296;
        goto label_8;
        label_18:
        UnityEngine.Vector3 val_22 = val_4[1];
        UnityEngine.Vector3 val_23 = val_4[2];
        mem[1152921515391571408] = val_22;
        mem[1152921515391571416] = val_23;
        val_33 = 8589934592;
        mem[1152921515391575504] = 0;
        val_28 = null;
        val_30 = 1;
        label_8:
        val_28 = null;
        val_34 = Math3D.positionRegister;
        if(val_30 < ((val_32 + ((mem[1152921515391571400]) << 32)) >> 32))
        {
            goto label_18;
        }
        
        val_34 = Math3D.positionRegister;
        var val_7 = (-4294967296) + ((mem[1152921515391571400]) << 32);
        val_7 = val_7 >> 32;
        val_7 = val_34 + (val_7 * 12);
        mem2[0] = position.x;
        mem2[0] = val_22;
        mem2[0] = position.z;
        val_35 = Math3D.posTimeRegister;
        var val_9 = (-4294967296) + ((mem[1152921515391575496]) << 32);
        val_9 = val_35 + (val_9 >> 30);
        mem2[0] = UnityEngine.Time.time;
        val_37 = null;
        int val_24 = Math3D.positionSamplesTaken;
        val_24 = val_24 + 1;
        Math3D.positionSamplesTaken = val_24;
        if(Math3D.positionSamplesTaken < ((samples > 3) ? samples : 3))
        {
            goto label_44;
        }
        
        val_38 = 0;
        val_31 = 8589934592;
        val_33 = 4294967296;
        goto label_26;
        label_50:
        val_32 = 1;
        val_39 = val_22;
        val_22 = val_23;
        UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_39, y = val_4[2], z = val_22}, b:  new UnityEngine.Vector3() {x = mem[1152921515391571400] + 32, y = mem[1152921515391571400] + 32 + 4, z = mem[1152921515391571400] + 40});
        val_25 = val_10.x;
        float val_11 = (mem[1152921515391575496] + 32) - 0f;
        if(val_11 == 0f)
        {
            goto label_44;
        }
        
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_25, y = val_10.y, z = val_10.z}, d:  val_11);
        val_40 = null;
        val_22 = val_12.x;
        val_40 = null;
        UnityEngine.Vector3[] val_26 = Math3D.positionRegister;
        val_35 = val_32 + 1;
        val_26 = val_26 + (0 * 12);
        val_24 = val_23;
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = mem[1152921515391571400], y = val_12.y, z = mem[1152921515391571408]}, b:  new UnityEngine.Vector3() {x = val_26, y = (0 * 12) + val_4 + 4, z = (0 * 12) + val_4 + 8});
        val_39 = val_13.x;
        float val_14 = mem[1152921515391575480] - (2.524355E-29f);
        if(val_14 == 0f)
        {
            goto label_44;
        }
        
        UnityEngine.Vector3 val_15 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_39, y = val_13.y, z = val_13.z}, d:  val_14);
        UnityEngine.Vector3 val_16 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z}, b:  new UnityEngine.Vector3() {x = val_22, y = val_12.y, z = val_12.z});
        UnityEngine.Vector3 val_17 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_24, y = val_24, z = val_25}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
        val_37 = null;
        val_23 = val_17.x;
        val_24 = val_17.y;
        val_25 = val_17.z;
        val_31 = 12884901888;
        val_33 = 8589934592;
        val_38 = val_35 - 1;
        label_26:
        val_37 = null;
        val_41 = Math3D.positionRegister;
        if(val_38 < (((-8589934592) + ((mem[1152921515391571400]) << 32)) >> 32))
        {
            goto label_50;
        }
        
        val_41 = Math3D.positionRegister;
        var val_27 = mem[1152921515391571400];
        val_27 = val_27 - 2;
        UnityEngine.Vector3 val_19 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_23, y = val_24, z = val_25}, d:  (float)val_27);
        val_35 = 1152921515391567312;
        float val_28 = 0f;
        var val_20 = (-4294967296) + ((mem[1152921515391575496]) << 32);
        val_20 = val_20 >> 30;
        val_28 = (1152921515391575504 + ((-4294967296 + (mem[1152921515391575496]) << 32) >> 30)) - val_28;
        UnityEngine.Vector3 val_21 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z}, d:  val_28);
        val_42 = 1;
        vector.x = val_21.x;
        vector.y = val_21.y;
        vector.z = val_21.z;
        return (bool)val_42;
        label_44:
        val_42 = 0;
        return (bool)val_42;
    }
    public static float LinearFunction2DBasic(float x, float Qx, float Qy)
    {
        Qx = Qy / Qx;
        x = Qx * x;
        return (float)x;
    }
    public static float LinearFunction2DFull(float x, float Px, float Py, float Qx, float Qy)
    {
        Qx = Qx - Px;
        Qy = Qy - Py;
        Qx = Qy / Qx;
        x = x - Px;
        x = x * Qx;
        x = x + Py;
        return (float)x;
    }
    public static float DistanceFromPoint2Ray(UnityEngine.Vector3 point, UnityEngine.Ray ray)
    {
        UnityEngine.Vector3 val_1 = ray.direction;
        UnityEngine.Vector3 val_2 = ray.origin;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = point.x, y = point.y, z = point.z}, b:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, rhs:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        return (float)val_4.x.magnitude;
    }
    public static float DistanceFromPoint2Ray(UnityEngine.Vector3 point, UnityEngine.Vector3 startingPoint, UnityEngine.Vector3 rayDirection)
    {
        float val_1;
        rayDirection.x.Normalize();
        UnityEngine.Ray val_2 = new UnityEngine.Ray(origin:  new UnityEngine.Vector3() {x = startingPoint.x, y = startingPoint.y, z = startingPoint.z}, direction:  new UnityEngine.Vector3() {x = rayDirection.x, y = val_1, z = rayDirection.y});
        return (float)Math3D.DistanceFromPoint2Ray(point:  new UnityEngine.Vector3() {x = point.x, y = point.y, z = point.z}, ray:  new UnityEngine.Ray() {m_Origin = new UnityEngine.Vector3() {x = val_2.m_Origin.x}, m_Direction = new UnityEngine.Vector3() {y = val_2.m_Direction.y}});
    }
    public Math3D()
    {
    
    }
    private static Math3D()
    {
    
    }

}
