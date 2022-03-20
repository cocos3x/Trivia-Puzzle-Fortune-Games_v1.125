using UnityEngine;

namespace twelvegigs.Autopilot
{
    public class AutopilotTools
    {
        // Methods
        public static bool RaycastOnButton(twelvegigs.Autopilot.AutopilotButton button, UnityEngine.Camera camera)
        {
            var val_4;
            var val_5;
            UnityEngine.GameObject val_6;
            var val_7;
            System.Collections.Generic.List<UnityEngine.GameObject> val_1 = button.GetTargets();
            if(true < 1)
            {
                goto label_3;
            }
            
            val_4 = 4;
            label_8:
            if(0 < true)
            {
                    val_5 = true;
            }
            else
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_6 = X9 + 32;
            if(true <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_6 = 0;
            }
            
            UnityEngine.Vector3 val_2 = button.GetWorldCenterPos(target:  val_6);
            if((twelvegigs.Autopilot.AutopilotTools.RaycastOnPosition(target:  X9 + 32, worldPos:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, camera:  camera)) == true)
            {
                goto label_7;
            }
            
            val_4 = val_4 + 1;
            if((val_4 - 3) < true)
            {
                goto label_8;
            }
            
            label_3:
            val_7 = 0;
            return (bool)val_7;
            label_7:
            val_7 = 1;
            return (bool)val_7;
        }
        public static bool RaycastOnPosition(UnityEngine.GameObject target, UnityEngine.Vector3 worldPos, UnityEngine.Camera camera)
        {
            UnityEngine.EventSystems.PointerEventData val_11;
            float val_12 = worldPos.z;
            if(target == 0)
            {
                    return false;
            }
            
            UnityEngine.EventSystems.PointerEventData val_3 = null;
            val_11 = val_3;
            val_3 = new UnityEngine.EventSystems.PointerEventData(eventSystem:  UnityEngine.EventSystems.EventSystem.current);
            UnityEngine.Vector3 val_4 = camera.WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = worldPos.x, y = worldPos.y, z = val_12});
            val_12 = val_4.x;
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_12, y = val_4.y, z = val_4.z});
            .<position>k__BackingField = val_5;
            mem[1152921520007353836] = val_5.y;
            UnityEngine.EventSystems.EventSystem.current.RaycastAll(eventData:  val_3, raycastResults:  new System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>());
            if(((public System.Void System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>::.ctor()) == 0) || (1152921520007275072 < 1))
            {
                    return false;
            }
            
            var val_12 = 0;
            var val_11 = 0;
            do
            {
                if(1152921520007275072 <= val_11)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if(null != (X9 + 60 + 4))
            {
                    return false;
            }
            
                if(null <= val_11)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((System.Void UnlockableUIWordIQ::InfoButtonClicked()) == target)
            {
                    return false;
            }
            
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_11 = (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32.GetComponent<UnityEngine.UI.GraphicRaycaster>();
                if(val_11 != 0)
            {
                    return false;
            }
            
                val_11 = val_11 + 1;
                val_12 = val_12 + 72;
            }
            while(val_11 < null);
            
            return false;
        }
        public static UnityEngine.Camera GetCamera(UnityEngine.Transform go)
        {
            UnityEngine.Transform val_7 = go;
            goto label_0;
            label_11:
            UnityEngine.Canvas val_1 = val_7.GetComponentInParent<UnityEngine.Canvas>();
            if(val_1 == 0)
            {
                    return 0;
            }
            
            if(val_1.renderMode == 1)
            {
                    return val_1.worldCamera;
            }
            
            val_7 = val_1.transform.parent;
            label_0:
            if(val_7 != 0)
            {
                goto label_11;
            }
            
            return 0;
        }
        public static string GetRoute(UnityEngine.Transform transform)
        {
            if(transform != 0)
            {
                    return System.String.Format(format:  "{0}/{1}", arg0:  transform.parent, arg1:  transform.name);
            }
            
            return (string)System.String.alignConst;
        }
        public static byte[] TakeScreenshot()
        {
            UnityEngine.Texture2D val_3 = new UnityEngine.Texture2D(width:  UnityEngine.Screen.width, height:  UnityEngine.Screen.height, textureFormat:  3, mipChain:  false);
            UnityEngine.Rect val_6 = new UnityEngine.Rect(x:  0f, y:  0f, width:  (float)UnityEngine.Screen.width, height:  (float)UnityEngine.Screen.height);
            val_3.ReadPixels(source:  new UnityEngine.Rect() {m_XMin = val_6.m_XMin, m_YMin = val_6.m_YMin, m_Width = val_6.m_Width, m_Height = val_6.m_Height}, destX:  0, destY:  0);
            val_3.Apply();
            UnityEngine.Object.Destroy(obj:  val_3);
            return (System.Byte[])UnityEngine.ImageConversion.EncodeToPNG(tex:  val_3);
        }
        public static void LogFormat(string format, object[] args)
        {
            UnityEngine.Debug.LogFormat(format:  "[AUTOPILOT]:"("[AUTOPILOT]:") + format, args:  args);
        }
        public static void Log(string message)
        {
            UnityEngine.Debug.Log(message:  "[AUTOPILOT]: "("[AUTOPILOT]: ") + message);
        }
        public static void LogErrorFormat(string format, object[] args)
        {
            UnityEngine.Debug.LogErrorFormat(format:  "[AUTOPILOT]: "("[AUTOPILOT]: ") + format, args:  args);
        }
        public static void LogError(string message)
        {
            UnityEngine.Debug.LogError(message:  "[AUTOPILOT]: "("[AUTOPILOT]: ") + message);
        }
        public AutopilotTools()
        {
        
        }
    
    }

}
