using UnityEngine;

namespace Spine
{
    public class SkeletonBounds
    {
        // Fields
        private Spine.ExposedList<Spine.Polygon> polygonPool;
        private float minX;
        private float minY;
        private float maxX;
        private float maxY;
        private Spine.ExposedList<Spine.BoundingBoxAttachment> <BoundingBoxes>k__BackingField;
        private Spine.ExposedList<Spine.Polygon> <Polygons>k__BackingField;
        
        // Properties
        public Spine.ExposedList<Spine.BoundingBoxAttachment> BoundingBoxes { get; set; }
        public Spine.ExposedList<Spine.Polygon> Polygons { get; set; }
        public float MinX { get; set; }
        public float MinY { get; set; }
        public float MaxX { get; set; }
        public float MaxY { get; set; }
        public float Width { get; }
        public float Height { get; }
        
        // Methods
        public Spine.ExposedList<Spine.BoundingBoxAttachment> get_BoundingBoxes()
        {
            return (Spine.ExposedList<Spine.BoundingBoxAttachment>)this.<BoundingBoxes>k__BackingField;
        }
        private void set_BoundingBoxes(Spine.ExposedList<Spine.BoundingBoxAttachment> value)
        {
            this.<BoundingBoxes>k__BackingField = value;
        }
        public Spine.ExposedList<Spine.Polygon> get_Polygons()
        {
            return (Spine.ExposedList<Spine.Polygon>)this.<Polygons>k__BackingField;
        }
        private void set_Polygons(Spine.ExposedList<Spine.Polygon> value)
        {
            this.<Polygons>k__BackingField = value;
        }
        public float get_MinX()
        {
            return (float)this.minX;
        }
        public void set_MinX(float value)
        {
            this.minX = value;
        }
        public float get_MinY()
        {
            return (float)this.minY;
        }
        public void set_MinY(float value)
        {
            this.minY = value;
        }
        public float get_MaxX()
        {
            return (float)this.maxX;
        }
        public void set_MaxX(float value)
        {
            this.maxX = value;
        }
        public float get_MaxY()
        {
            return (float)this.maxY;
        }
        public void set_MaxY(float value)
        {
            this.maxY = value;
        }
        public float get_Width()
        {
            float val_1 = this.maxX;
            val_1 = val_1 - this.minX;
            return (float)val_1;
        }
        public float get_Height()
        {
            float val_1 = this.maxY;
            val_1 = val_1 - this.minY;
            return (float)val_1;
        }
        public SkeletonBounds()
        {
            this.polygonPool = new Spine.ExposedList<Spine.Polygon>();
            this.<BoundingBoxes>k__BackingField = new Spine.ExposedList<Spine.BoundingBoxAttachment>();
            this.<Polygons>k__BackingField = new Spine.ExposedList<Spine.Polygon>();
        }
        public void Update(Spine.Skeleton skeleton, bool updateAabb)
        {
            Spine.Slot val_3;
            Spine.Polygon val_4;
            System.Single[] val_5;
            this.<BoundingBoxes>k__BackingField.Clear(clearArray:  true);
            if(41934848 >= 1)
            {
                    do
            {
                this.polygonPool.Add(item:  public System.Int64 UnityEngine.AndroidJavaObject::CallStatic<System.Int64>(string methodName, object[] args));
                val_3 = 0 + 1;
            }
            while(val_3 < 41934848);
            
            }
            
            this.<Polygons>k__BackingField.Clear(clearArray:  true);
            if(W27 >= 1)
            {
                    var val_3 = 0;
                do
            {
                val_3 = "INACTIVE";
                this.<BoundingBoxes>k__BackingField.Add(item:  "INACTIVE".__il2cppRuntimeField_40);
                val_4 = mem[399299496];
                this.polygonPool.RemoveAt(index:  44366607);
                this.<Polygons>k__BackingField.Add(item:  null);
                val_5 = (Spine.Polygon)[1152921510614753520].<Vertices>k__BackingField;
                .<Count>k__BackingField = "INACTIVE".__il2cppRuntimeField_40 + 48;
                float[] val_2 = new float[0];
                val_5 = val_2;
                .<Vertices>k__BackingField = val_2;
                "INACTIVE".__il2cppRuntimeField_40.ComputeWorldVertices(slot:  val_3, worldVertices:  val_2);
                val_3 = val_3 + 1;
            }
            while(val_3 < W27);
            
            }
            
            if(updateAabb != false)
            {
                    this.AabbCompute();
                return;
            }
            
            this.minX = ;
            this.minY = ;
            this.maxX = 2.147484E+09f;
            this.maxY = 2.147484E+09f;
        }
        private void AabbCompute()
        {
            float val_7;
            float val_8;
            float val_9;
            float val_10;
            if(W21 >= 1)
            {
                    val_7 = -2.147484E+09f;
                val_8 = 2.147484E+09f;
                var val_9 = 0;
                val_9 = val_8;
                val_10 = val_7;
                do
            {
                if((mem[-74351394354111740]) >= 1)
            {
                    do
            {
                var val_1 = 0 + 1;
                var val_2 = (mem[-74351394354111748]) + 0;
                var val_3 = (mem[-74351394354111748]) + (val_1 << 2);
                val_8 = System.Math.Min(val1:  val_8, val2:  (mem[-74351394354111748] + 0) + 32);
                val_9 = System.Math.Min(val1:  val_8, val2:  (mem[-74351394354111748] + ((0 + 1)) << 2) + 32);
                val_7 = System.Math.Max(val1:  val_7, val2:  (mem[-74351394354111748] + 0) + 32);
                val_10 = System.Math.Max(val1:  val_7, val2:  (mem[-74351394354111748] + ((0 + 1)) << 2) + 32);
            }
            while((val_1 + 1) < (mem[-74351394354111740]));
            
            }
            
                val_9 = val_9 + 1;
            }
            while(val_9 < W21);
            
            }
            else
            {
                    val_9 = 2.147484E+09f;
                val_10 = -2.147484E+09f;
                val_8 = val_9;
                val_7 = val_10;
            }
            
            this.minX = val_9;
            this.minY = val_9;
            this.maxX = val_10;
            this.maxY = val_10;
        }
        public bool AabbContainsPoint(float x, float y)
        {
            if(this.minX > x)
            {
                    return false;
            }
            
            if(this.maxX < x)
            {
                    return false;
            }
            
            if(this.minY <= y)
            {
                    return (bool)(this.maxY >= y) ? 1 : 0;
            }
            
            return false;
        }
        public bool AabbIntersectsSegment(float x1, float y1, float x2, float y2)
        {
            if(this.minX >= x1)
            {
                    if(this.minX >= x2)
            {
                    return false;
            }
            
            }
            
            if(this.minY >= y1)
            {
                    if(this.minY >= y2)
            {
                    return false;
            }
            
            }
            
            if(this.maxX <= x1)
            {
                    if(this.maxX <= x2)
            {
                    return false;
            }
            
            }
            
            if((this.maxY <= y1) && (this.maxY <= y2))
            {
                    return false;
            }
            
            y2 = y2 - y1;
            x2 = x2 - x1;
            x2 = y2 / x2;
            float val_1 = this.minX - x1;
            val_1 = x2 * val_1;
            val_1 = val_1 + y1;
            if(val_1 > this.minY)
            {
                    if(val_1 < 0)
            {
                    return true;
            }
            
            }
            
            float val_2 = this.maxX - x1;
            val_2 = x2 * val_2;
            val_2 = val_2 + y1;
            if(val_2 > this.minY)
            {
                    if(val_2 < 0)
            {
                    return true;
            }
            
            }
            
            float val_3 = this.minY - y1;
            val_3 = val_3 / x2;
            val_3 = val_3 + x1;
            if((val_3 > this.minX) && (val_3 < 0))
            {
                    return true;
            }
            
            y1 = this.maxY - y1;
            y1 = y1 / x2;
            x1 = y1 + x1;
            return (bool)((x1 < 0) ? 1 : 0) & ((x1 > this.minX) ? 1 : 0);
        }
        public bool AabbIntersectsSkeleton(Spine.SkeletonBounds bounds)
        {
            if(bounds != null)
            {
                    if(this.minX >= 0)
            {
                    return false;
            }
            
                if(this.maxX <= bounds.minX)
            {
                    return false;
            }
            
                if(this.minY >= 0)
            {
                    return false;
            }
            
                return (bool)(this.maxY > bounds.minY) ? 1 : 0;
            }
            
            throw new NullReferenceException();
        }
        public bool ContainsPoint(Spine.Polygon polygon, float x, float y)
        {
            var val_5;
            if((polygon.<Count>k__BackingField) >= 1)
            {
                    val_5 = 0;
                int val_1 = (polygon.<Count>k__BackingField) - 2;
                do
            {
                float val_7 = polygon.<Vertices>k__BackingField[1];
                float val_8 = polygon.<Vertices>k__BackingField[val_1 + 1];
                if(val_7 < 0)
            {
                    if(val_8 >= y)
            {
                goto label_6;
            }
            
            }
            
                if((val_7 >= y) && (val_8 < 0))
            {
                    label_6:
                float val_9 = polygon.<Vertices>k__BackingField[0];
                val_7 = val_8 - val_7;
                val_7 = (y - val_7) / val_7;
                val_7 = val_7 * ((polygon.<Vertices>k__BackingField[val_1]) - val_9);
                val_7 = val_9 + val_7;
                if(val_7 < 0)
            {
                    val_5 = val_5 ^ 1;
            }
            
            }
            
            }
            while((0 + 2) < (polygon.<Count>k__BackingField));
            
                return (bool)val_5 & 1;
            }
            
            val_5 = 0;
            return (bool)val_5 & 1;
        }
        public Spine.BoundingBoxAttachment ContainsPoint(float x, float y)
        {
            var val_3;
            if(W22 >= 1)
            {
                    var val_3 = 0;
                do
            {
                var val_1 = X8 + 0;
                if((this.ContainsPoint(polygon:  (X8 + 0) + 32, x:  x, y:  y)) == true)
            {
                    return (Spine.BoundingBoxAttachment)Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg;
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < X22);
            
            }
            
            val_3 = 0;
            return (Spine.BoundingBoxAttachment)Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg;
        }
        public Spine.BoundingBoxAttachment IntersectsSegment(float x1, float y1, float x2, float y2)
        {
            var val_3;
            if(W22 >= 1)
            {
                    var val_3 = 0;
                do
            {
                var val_1 = X8 + 0;
                if((this.IntersectsSegment(polygon:  (X8 + 0) + 32, x1:  x1, y1:  y1, x2:  x2, y2:  y2)) == true)
            {
                    return (Spine.BoundingBoxAttachment)Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg;
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < X22);
            
            }
            
            val_3 = 0;
            return (Spine.BoundingBoxAttachment)Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg;
        }
        public bool IntersectsSegment(Spine.Polygon polygon, float x1, float y1, float x2, float y2)
        {
            var val_14;
            int val_1 = (polygon.<Count>k__BackingField) - 2;
            int val_2 = (polygon.<Count>k__BackingField) - 1;
            if((polygon.<Count>k__BackingField) >= 1)
            {
                    float val_3 = x1 * y2;
                float val_5 = x1 - x2;
                float val_6 = y1 - y2;
                val_3 = val_3 - (y1 * x2);
                do
            {
                var val_7 = 0 + 1;
                float val_16 = polygon.<Vertices>k__BackingField[val_7];
                float val_17 = polygon.<Vertices>k__BackingField[0];
                float val_8 = 0.0005730391f * val_16;
                float val_10 = 0.0005730391f - val_17;
                float val_11 = 0.0005730391f - val_16;
                val_8 = val_8 - (0.0005730391f * val_17);
                float val_12 = val_5 * val_11;
                val_10 = val_3 * val_10;
                val_12 = val_12 - (val_6 * val_10);
                val_10 = val_10 - (val_5 * val_8);
                val_10 = val_10 / val_12;
                if(val_10 >= 0.0005730391f)
            {
                    if(val_10 <= val_17)
            {
                goto label_8;
            }
            
            }
            
                if((val_10 >= val_17) && (val_10 <= 0.0005730391f))
            {
                    label_8:
                if(val_10 >= x1)
            {
                    if(val_10 <= x2)
            {
                goto label_12;
            }
            
            }
            
                if((val_10 >= x2) && (val_10 <= x1))
            {
                    label_12:
                val_11 = val_3 * val_11;
                val_8 = val_6 * val_8;
                val_8 = val_11 - val_8;
                val_8 = val_8 / val_12;
                if(val_8 >= 0.0005730391f)
            {
                    if(val_8 <= val_16)
            {
                goto label_16;
            }
            
            }
            
                if((val_8 >= val_16) && (val_8 <= 0.0005730391f))
            {
                    label_16:
                if(val_8 >= y1)
            {
                    if(val_8 <= y2)
            {
                goto label_22;
            }
            
            }
            
                if(val_8 >= y2)
            {
                    if(val_8 <= y1)
            {
                goto label_22;
            }
            
            }
            
            }
            
            }
            
            }
            
            }
            while((val_7 + 1) < (polygon.<Count>k__BackingField));
            
            }
            
            val_14 = 0;
            return (bool)val_14;
            label_22:
            val_14 = 1;
            return (bool)val_14;
        }
        public Spine.Polygon GetPolygon(Spine.BoundingBoxAttachment attachment)
        {
            var val_2;
            int val_1 = this.<BoundingBoxes>k__BackingField.IndexOf(item:  attachment);
            if(val_1 != 1)
            {
                    Spine.ExposedList<Spine.Polygon> val_2 = this.<Polygons>k__BackingField;
                val_2 = val_2 + (val_1 << 3);
                return (Spine.Polygon)val_2;
            }
            
            val_2 = 0;
            return (Spine.Polygon)val_2;
        }
    
    }

}
