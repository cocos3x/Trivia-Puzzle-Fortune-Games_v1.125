using UnityEngine;

namespace UnityEngine.UI.Extensions
{
    public class RadialLayout : LayoutGroup
    {
        // Fields
        public float fDistance;
        public float MinAngle;
        public float MaxAngle;
        public float StartAngle;
        
        // Methods
        protected override void OnEnable()
        {
            this.OnEnable();
            this.CalculateRadial();
        }
        public override void SetLayoutHorizontal()
        {
        
        }
        public override void SetLayoutVertical()
        {
        
        }
        public override void CalculateLayoutInputVertical()
        {
            this.CalculateRadial();
        }
        public override void CalculateLayoutInputHorizontal()
        {
            this.CalculateRadial();
        }
        private void CalculateRadial()
        {
            var val_17;
            Clear();
            if(this.transform.childCount == 0)
            {
                    return;
            }
            
            float val_17 = this.StartAngle;
            val_17 = 0;
            do
            {
                if(val_17 >= this.transform.childCount)
            {
                    return;
            }
            
                UnityEngine.Transform val_10 = this.transform.GetChild(index:  0);
                if(val_10 != null)
            {
                    if(null != null)
            {
                goto label_8;
            }
            
            }
            
                if(val_10 != 0)
            {
                    Add(driver:  this, rectTransform:  val_10, drivenProperties:  6);
                float val_12 = val_17 * 0.01745329f;
                UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  val_12, y:  val_12, z:  0f);
                UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, d:  this.fDistance);
                val_10.localPosition = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
                UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
                val_10.pivot = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
                val_10.anchorMax = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
                val_10.anchorMin = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
                val_17 = ((this.MaxAngle - this.MinAngle) / (float)this.transform.childCount) + val_17;
            }
            
                val_17 = val_17 + 1;
            }
            while(val_10.transform != null);
            
            throw new NullReferenceException();
            label_8:
        }
        public RadialLayout()
        {
        
        }
    
    }

}
