using UnityEngine;

namespace TMPro.Examples
{
    public class CurveText : MonoBehaviour
    {
        // Fields
        private TMPro.TMP_Text m_TextComponent;
        public UnityEngine.AnimationCurve VertexCurve;
        public float CurveScale;
        
        // Properties
        private TMPro.TMP_Text TextComponent { get; }
        
        // Methods
        private TMPro.TMP_Text get_TextComponent()
        {
            TMPro.TMP_Text val_4;
            if(this.m_TextComponent == 0)
            {
                    this.m_TextComponent = this.gameObject.GetComponent<TMPro.TMP_Text>();
                return val_4;
            }
            
            val_4 = this.m_TextComponent;
            return val_4;
        }
        private void Update()
        {
            if((UnityEngine.Object.op_Implicit(exists:  this.TextComponent)) == false)
            {
                    return;
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.TextComponent)) == false)
            {
                    return;
            }
            
            this.DoWarpText();
        }
        private void DoWarpText()
        {
            var val_6;
            var val_11;
            TMPro.Examples.CurveText val_56;
            TMPro.Examples.CurveText val_57;
            float val_58;
            float val_59;
            var val_60;
            var val_61;
            val_56 = this;
            val_56 = this;
            mem[1152921519589526096].preWrapMode = 1;
            mem[1152921519589526096].postWrapMode = 1;
            TMPro.TMP_Text val_1 = this.TextComponent;
            TMPro.TMP_Text val_2 = this.TextComponent;
            val_57 = this;
            if(val_2.m_textInfo.characterCount == 0)
            {
                    return;
            }
            
            UnityEngine.Bounds val_4 = this.TextComponent.bounds;
            UnityEngine.Vector3 val_7 = val_6.min;
            val_58 = val_7.x;
            UnityEngine.Bounds val_9 = this.TextComponent.bounds;
            UnityEngine.Vector3 val_12 = val_11.max;
            if(val_2.m_textInfo.characterCount >= 1)
            {
                    val_59 = val_12.x - val_58;
                val_60 = 0;
                val_61 = 404;
                do
            {
                if(val_2.m_textInfo.characterInfo[1] != 0)
            {
                    TMPro.TMP_CharacterInfo[] val_13 = val_2.m_textInfo.characterInfo[404] - 316;
                val_2.m_textInfo.characterInfo[404] = val_2.m_textInfo.characterInfo[404] - 296;
                TMPro.TMP_CharacterInfo[] val_14 = mem[168685388848] + (1152921506715414336 * 12);
                var val_59 = (long)val_2.m_textInfo.characterInfo[404];
                val_2.m_textInfo.characterInfo[404] = mem[168685388848] + (val_59 * 12);
                float val_58 = 1.142636E+37f;
                val_58 = val_58 + (((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 32);
                val_58 = val_58 * 0.5f;
                UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  val_58, y:  2.894138E+37f);
                UnityEngine.Vector3 val_16 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_15.x, y = val_15.y});
                TMPro.TMP_CharacterInfo[] val_17 = mem[168685388848] + (1152921506715414336 * 12);
                UnityEngine.Vector3 val_18 = UnityEngine.Vector3.op_UnaryNegation(a:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
                UnityEngine.Vector3 val_19 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = 1.142636E+37f, y = (1152921506715414336 * 12) + mem[168685388848] + 40 + -4, z = mem[(1152921506715414336 * 12) + mem[168685388848] + 40]}, b:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z});
                this = val_19.x;
                mem2[0] = val_19.y;
                mem2[0] = val_19.z;
                UnityEngine.Vector3 val_21 = UnityEngine.Vector3.op_UnaryNegation(a:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
                UnityEngine.Vector3 val_22 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32, y = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32 + 4, z = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32 + 8}, b:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z});
                mem2[0] = val_22.x;
                mem2[0] = val_22.y;
                mem2[0] = val_22.z;
                val_59 = mem[168685388848] + (val_59 * 12);
                UnityEngine.Vector3 val_23 = UnityEngine.Vector3.op_UnaryNegation(a:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
                UnityEngine.Vector3 val_24 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 32, y = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 40 + -4, z = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 40}, b:  new UnityEngine.Vector3() {x = val_23.x, y = val_23.y, z = val_23.z});
                mem2[0] = val_24.x;
                mem2[0] = val_24.y;
                mem2[0] = val_24.z;
                var val_25 = mem[168685388848] + (2108567363 * 12);
                UnityEngine.Vector3 val_26 = UnityEngine.Vector3.op_UnaryNegation(a:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
                UnityEngine.Vector3 val_27 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = (2108567363 * 12) + mem[168685388848] + 32, y = (2108567363 * 12) + mem[168685388848] + 32 + 4, z = (2108567363 * 12) + mem[168685388848] + 32 + 8}, b:  new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z});
                mem2[0] = val_27.x;
                mem2[0] = val_27.y;
                mem2[0] = val_27.z;
                float val_29 = (val_16.x - val_58) / val_59;
                val_29 = val_29 + 0.0001f;
                float val_31 = (mem[1152921519589526096].Evaluate(time:  val_29)) * mem[1152921519589526104];
                val_6 = 0;
                UnityEngine.Vector3 val_34 = new UnityEngine.Vector3(x:  1f, y:  0f, z:  0f);
                float val_35 = val_59 * val_29;
                val_35 = val_58 + val_35;
                val_11 = 0;
                UnityEngine.Vector3 val_36 = new UnityEngine.Vector3(x:  val_35, y:  (mem[1152921519589526096].Evaluate(time:  val_29)) * mem[1152921519589526104]);
                UnityEngine.Vector3 val_37 = new UnityEngine.Vector3(x:  val_16.x, y:  val_31);
                UnityEngine.Vector3 val_38 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_36.x, y = val_36.y, z = val_36.z}, b:  new UnityEngine.Vector3() {x = val_37.x, y = val_37.y, z = val_37.z});
                UnityEngine.Vector3 val_39 = val_38.x.normalized;
                float val_60 = UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = val_34.x, y = val_34.y, z = val_34.z}, rhs:  new UnityEngine.Vector3() {x = val_39.x, y = val_39.y, z = val_39.z});
                val_60 = val_60 * 57.29578f;
                UnityEngine.Vector3 val_41 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = val_34.x, y = val_34.y, z = val_34.z}, rhs:  new UnityEngine.Vector3() {x = val_38.x, y = val_38.y, z = val_38.z});
                float val_61 = 360f;
                val_61 = val_61 - val_60;
                val_60 = (val_41.z > 0f) ? (val_60) : (val_61);
                val_11 = 0;
                UnityEngine.Vector3 val_42 = new UnityEngine.Vector3(x:  0f, y:  val_31, z:  0f);
                UnityEngine.Quaternion val_43 = UnityEngine.Quaternion.Euler(x:  0f, y:  0f, z:  val_60);
                UnityEngine.Vector3 val_44 = UnityEngine.Vector3.one;
                val_59 = val_44.z;
                UnityEngine.Matrix4x4 val_45 = UnityEngine.Matrix4x4.TRS(pos:  new UnityEngine.Vector3() {x = val_42.x, y = val_42.y, z = val_42.z}, q:  new UnityEngine.Quaternion() {x = val_43.x, y = val_43.y, z = val_43.z, w = val_43.w}, s:  new UnityEngine.Vector3() {x = val_44.x, y = val_59, z = 57.29578f});
                UnityEngine.Vector3 val_48 = val_34.x.MultiplyPoint3x4(point:  new UnityEngine.Vector3() {x = this, y = (1152921506715414336 * 12) + mem[168685388848] + 40 + -4, z = (1152921506715414336 * 12) + mem[168685388848] + 40});
                val_58 = val_58;
                this = val_48.x;
                mem2[0] = val_48.y;
                mem2[0] = val_48.z;
                UnityEngine.Vector3 val_49 = val_34.x.MultiplyPoint3x4(point:  new UnityEngine.Vector3() {x = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32, y = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32 + 4, z = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32 + 8});
                mem2[0] = val_49.x;
                mem2[0] = val_49.y;
                mem2[0] = val_49.z;
                UnityEngine.Vector3 val_50 = val_34.x.MultiplyPoint3x4(point:  new UnityEngine.Vector3() {x = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 32, y = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 40 + -4, z = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 40});
                mem2[0] = val_50.x;
                mem2[0] = val_50.y;
                mem2[0] = val_50.z;
                UnityEngine.Vector3 val_51 = val_34.x.MultiplyPoint3x4(point:  new UnityEngine.Vector3() {x = (2108567363 * 12) + mem[168685388848] + 32, y = (2108567363 * 12) + mem[168685388848] + 32 + 4, z = (2108567363 * 12) + mem[168685388848] + 32 + 8});
                mem2[0] = val_51.x;
                mem2[0] = val_51.y;
                mem2[0] = val_51.z;
                UnityEngine.Vector3 val_52 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = this, y = (1152921506715414336 * 12) + mem[168685388848] + 40 + -4, z = (1152921506715414336 * 12) + mem[168685388848] + 40}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
                this = val_52.x;
                mem2[0] = val_52.y;
                mem2[0] = val_52.z;
                UnityEngine.Vector3 val_53 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32, y = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32 + 4, z = ((long)(int)(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished) * 12) + mem[168685388848] + 32 + 8}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
                mem2[0] = val_53.x;
                mem2[0] = val_53.y;
                mem2[0] = val_53.z;
                UnityEngine.Vector3 val_54 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 32, y = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 40 + -4, z = ((long)(int)((val_2.m_textInfo.characterInfo[0x194] - 296)) * 12) + mem[168685388848] + 40}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
                mem2[0] = val_54.x;
                mem2[0] = val_54.y;
                mem2[0] = val_54.z;
                val_57 = (2108567363 * 12) + mem[168685388848] + 32 + 8;
                UnityEngine.Vector3 val_55 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = (2108567363 * 12) + mem[168685388848] + 32, y = (2108567363 * 12) + mem[168685388848] + 32 + 4, z = val_57}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
                mem2[0] = val_55.x;
                mem2[0] = val_55.y;
                mem2[0] = val_55.z;
                val_61 = 404;
                val_60 = val_60;
            }
            
                val_60 = val_60 + 1;
                val_61 = val_61 + 376;
            }
            while(val_60 < val_2.m_textInfo.characterCount);
            
            }
            
            TMPro.TMP_Text val_56 = this.TextComponent;
        }
        public CurveText()
        {
            UnityEngine.Keyframe[] val_1 = new UnityEngine.Keyframe[3];
            UnityEngine.Keyframe val_2 = new UnityEngine.Keyframe(time:  0f, value:  0f);
            val_1[0] = val_2.m_OutTangent;
            val_1[0] = val_2.m_Time;
            UnityEngine.Keyframe val_3 = new UnityEngine.Keyframe(time:  0.5f, value:  1f);
            val_1[1] = val_3.m_OutTangent;
            val_1[1] = val_3.m_Time;
            UnityEngine.Keyframe val_4 = new UnityEngine.Keyframe(time:  1f, value:  0f);
            val_1[2] = val_4.m_OutTangent;
            val_1[2] = val_4.m_Time;
            this.VertexCurve = new UnityEngine.AnimationCurve(keys:  val_1);
            this.CurveScale = 10f;
        }
    
    }

}
