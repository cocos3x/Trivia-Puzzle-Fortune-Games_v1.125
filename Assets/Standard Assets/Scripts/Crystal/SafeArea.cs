using UnityEngine;

namespace Crystal
{
    public class SafeArea : MonoBehaviour
    {
        // Fields
        public static Crystal.SafeArea.SimDevice Sim;
        private UnityEngine.Rect[] NSA_iPhoneX;
        private UnityEngine.Rect[] NSA_iPhoneXsMax;
        private UnityEngine.RectTransform Panel;
        private UnityEngine.Rect LastSafeArea;
        private bool ConformX;
        private bool ConformY;
        
        // Methods
        private void Awake()
        {
            UnityEngine.RectTransform val_1 = this.GetComponent<UnityEngine.RectTransform>();
            this.Panel = val_1;
            if(val_1 == 0)
            {
                    UnityEngine.Debug.LogError(message:  "Cannot apply safe area - no RectTransform found on "("Cannot apply safe area - no RectTransform found on ") + this.name);
                UnityEngine.Object.Destroy(obj:  this.gameObject);
            }
            
            this.Refresh();
        }
        private void Update()
        {
            this.Refresh();
        }
        private void Refresh()
        {
            UnityEngine.Rect val_1 = this.GetSafeArea();
            if((UnityEngine.Rect.op_Inequality(lhs:  new UnityEngine.Rect() {m_XMin = val_1.m_XMin, m_YMin = val_1.m_YMin, m_Width = val_1.m_Width, m_Height = val_1.m_Height}, rhs:  new UnityEngine.Rect() {m_XMin = this.LastSafeArea})) == false)
            {
                    return;
            }
            
            this.ApplySafeArea(r:  new UnityEngine.Rect() {m_XMin = val_1.m_XMin, m_YMin = val_1.m_YMin, m_Width = val_1.m_Width, m_Height = val_1.m_Height});
        }
        private UnityEngine.Rect GetSafeArea()
        {
            var val_23;
            float val_25;
            float val_26;
            float val_27;
            float val_28;
            var val_29;
            var val_30;
            var val_31;
            SimDevice val_32;
            UnityEngine.Rect[] val_33;
            val_23 = this;
            UnityEngine.Rect val_1 = UnityEngine.Screen.safeArea;
            val_25 = val_1.m_XMin;
            val_26 = val_1.m_YMin;
            val_27 = val_1.m_Width;
            val_28 = val_1.m_Height;
            if(UnityEngine.Application.isEditor == false)
            {
                    return new UnityEngine.Rect() {m_XMin = val_25, m_YMin = val_26, m_Width = val_27, m_Height = val_28};
            }
            
            val_29 = 1152921504869572608;
            val_30 = null;
            val_30 = null;
            if(Crystal.SafeArea.Sim == 0)
            {
                    return new UnityEngine.Rect() {m_XMin = val_25, m_YMin = val_26, m_Width = val_27, m_Height = val_28};
            }
            
            UnityEngine.Rect val_5 = new UnityEngine.Rect(x:  0f, y:  0f, width:  (float)UnityEngine.Screen.width, height:  (float)UnityEngine.Screen.height);
            val_31 = null;
            val_31 = null;
            val_32 = Crystal.SafeArea.Sim;
            if(val_32 == 2)
            {
                goto label_7;
            }
            
            if(val_32 != 1)
            {
                goto label_8;
            }
            
            val_33 = this.NSA_iPhoneX;
            label_13:
            val_32 = this.NSA_iPhoneX.Length;
            if(UnityEngine.Screen.height <= UnityEngine.Screen.width)
            {
                goto label_10;
            }
            
            goto label_12;
            label_7:
            int val_8 = UnityEngine.Screen.height;
            int val_9 = UnityEngine.Screen.width;
            val_33 = this.NSA_iPhoneXsMax;
            if(val_33 != null)
            {
                goto label_13;
            }
            
            throw new NullReferenceException();
            label_10:
            label_12:
            label_8:
            val_23 = UnityEngine.Screen.width;
            val_29 = UnityEngine.Screen.width;
            UnityEngine.Rect val_22 = new UnityEngine.Rect(x:  null.x * (float)val_23, y:  null.y * (float)UnityEngine.Screen.height, width:  null.width * (float)val_29, height:  null.height * (float)UnityEngine.Screen.height);
            val_25 = val_22.m_XMin;
            val_26 = val_22.m_YMin;
            val_27 = val_22.m_Width;
            val_28 = val_22.m_Height;
            return new UnityEngine.Rect() {m_XMin = val_25, m_YMin = val_26, m_Width = val_27, m_Height = val_28};
        }
        private void ApplySafeArea(UnityEngine.Rect r)
        {
            float val_13;
            this.LastSafeArea = r;
            mem[1152921513319708068] = r.m_YMin;
            mem[1152921513319708072] = r.m_Width;
            mem[1152921513319708076] = r.m_Height;
            if(this.ConformX != true)
            {
                    r.m_XMin.x = 0f;
                val_13 = (float)UnityEngine.Screen.width;
                r.m_XMin.width = val_13;
            }
            
            if(this.ConformY != true)
            {
                    r.m_XMin.y = 0f;
                val_13 = (float)UnityEngine.Screen.height;
                r.m_XMin.height = val_13;
            }
            
            UnityEngine.Vector2 val_3 = r.m_XMin.position;
            UnityEngine.Vector2 val_4 = r.m_XMin.position;
            UnityEngine.Vector2 val_5 = r.m_XMin.size;
            UnityEngine.Vector2 val_6 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y}, b:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y});
            this.Panel.anchorMin = new UnityEngine.Vector2() {x = val_3.x / (float)UnityEngine.Screen.width, y = val_3.y / (float)UnityEngine.Screen.height};
            float val_13 = (float)UnityEngine.Screen.width;
            float val_14 = (float)UnityEngine.Screen.height;
            val_13 = val_6.x / val_13;
            val_14 = val_6.y / val_14;
            this.Panel.anchorMax = new UnityEngine.Vector2() {x = val_13, y = val_14};
        }
        public SafeArea()
        {
            UnityEngine.Rect[] val_1 = new UnityEngine.Rect[2];
            UnityEngine.Rect val_2 = new UnityEngine.Rect(x:  0f, y:  0.04187192f, width:  1f, height:  0.9039409f);
            val_1[0] = val_2.m_XMin;
            UnityEngine.Rect val_3 = new UnityEngine.Rect(x:  0.05418719f, y:  0.056f, width:  0.8916256f, height:  0.944f);
            val_1[1] = val_3.m_XMin;
            this.NSA_iPhoneX = val_1;
            UnityEngine.Rect[] val_4 = new UnityEngine.Rect[2];
            UnityEngine.Rect val_5 = new UnityEngine.Rect(x:  0f, y:  0.03794643f, width:  1f, height:  0.9129464f);
            val_4[0] = val_5.m_XMin;
            UnityEngine.Rect val_6 = new UnityEngine.Rect(x:  0.04910714f, y:  0.05072464f, width:  0.9017857f, height:  0.9492754f);
            UnityEngine.Rect val_7;
            val_4[1] = val_6.m_XMin;
            this.NSA_iPhoneXsMax = val_4;
            val_7 = new UnityEngine.Rect(x:  0f, y:  0f, width:  0f, height:  0f);
            this.LastSafeArea = val_7.m_XMin;
            this.ConformX = true;
            this.ConformY = true;
        }
        private static SafeArea()
        {
        
        }
    
    }

}
