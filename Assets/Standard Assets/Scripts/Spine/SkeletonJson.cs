using UnityEngine;

namespace Spine
{
    public class SkeletonJson
    {
        // Fields
        private float <Scale>k__BackingField;
        private Spine.AttachmentLoader attachmentLoader;
        private System.Collections.Generic.List<Spine.SkeletonJson.LinkedMesh> linkedMeshes;
        
        // Properties
        public float Scale { get; set; }
        
        // Methods
        public float get_Scale()
        {
            return (float)this.<Scale>k__BackingField;
        }
        public void set_Scale(float value)
        {
            this.<Scale>k__BackingField = value;
        }
        public SkeletonJson(Spine.Atlas[] atlasArray)
        {
            Spine.AtlasAttachmentLoader val_1 = new Spine.AtlasAttachmentLoader(atlasArray:  atlasArray);
        }
        public SkeletonJson(Spine.AttachmentLoader attachmentLoader)
        {
            this.linkedMeshes = new System.Collections.Generic.List<LinkedMesh>();
            if(attachmentLoader == null)
            {
                    throw new System.ArgumentNullException(paramName:  "attachmentLoader", message:  "attachmentLoader cannot be null.");
            }
            
            this.attachmentLoader = attachmentLoader;
            this.<Scale>k__BackingField = 1f;
        }
        public Spine.SkeletonData ReadSkeletonData(string path)
        {
            System.IO.StreamReader val_2 = new System.IO.StreamReader(stream:  new System.IO.FileStream(path:  path, mode:  3, access:  1, share:  1));
            val_3.name = System.IO.Path.GetFileNameWithoutExtension(path:  path);
            if(val_2 != null)
            {
                    var val_6 = 0;
                val_6 = val_6 + 1;
                val_2.Dispose();
            }
            
            if(0 != 0)
            {
                    throw 0;
            }
            
            return (Spine.SkeletonData)this.ReadSkeletonData(reader:  val_2);
        }
        public Spine.SkeletonData ReadSkeletonData(System.IO.TextReader reader)
        {
            var val_13;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_14;
            float val_202;
            object val_203;
            var val_204;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_205;
            var val_206;
            Spine.ExposedList<Spine.BoneData> val_207;
            float val_208;
            string val_209;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_210;
            string val_211;
            string val_212;
            string val_213;
            var val_214;
            object val_215;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_216;
            string val_217;
            string val_218;
            Spine.BlendMode val_219;
            string val_220;
            object val_221;
            var val_222;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_223;
            Spine.MeshAttachment val_224;
            string val_225;
            string val_226;
            string val_228;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_229;
            string val_230;
            string val_231;
            string val_233;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_234;
            System.Type val_235;
            string val_236;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_238;
            string val_245;
            string val_246;
            string val_247;
            string val_248;
            var val_249;
            var val_250;
            val_202 = 0;
            if(reader == null)
            {
                goto label_1;
            }
            
            Spine.SkeletonData val_1 = new Spine.SkeletonData();
            object val_2 = Spine.Json.Deserialize(text:  reader);
            if(val_2 == null)
            {
                goto label_4;
            }
            
            val_203 = val_2;
            if((val_203.ContainsKey(key:  "skeleton")) != false)
            {
                    object val_4 = val_203.Item["skeleton"];
                if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_204 = null;
                val_205 = val_4;
                object val_5 = val_205.Item["hash"];
                if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_206 = 1152921504622235648;
                if(val_5 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
                .hash = val_5;
                object val_6 = val_205.Item["spine"];
                if(val_6 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
                .version = val_6;
                .width = Spine.SkeletonJson.GetFloat(map:  val_205, name:  "width", defaultValue:  0f);
                .height = Spine.SkeletonJson.GetFloat(map:  val_205, name:  "height", defaultValue:  0f);
                val_202 = 0f;
                .fps = Spine.SkeletonJson.GetFloat(map:  val_205, name:  "fps", defaultValue:  val_202);
                .imagesPath = Spine.SkeletonJson.GetString(map:  val_205, name:  "images", defaultValue:  0);
            }
            
            object val_11 = val_203.Item["bones"];
            if(val_11 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_12 = val_11.GetEnumerator();
            val_207 = val_14;
            val_208 = 1f;
            label_40:
            val_209 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_13.MoveNext() == false)
            {
                goto label_17;
            }
            
            val_210 = val_207;
            if(val_210 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_209 = "parent";
            if((val_210.ContainsKey(key:  val_209)) == false)
            {
                goto label_21;
            }
            
            object val_17 = val_210.Item["parent"];
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_211 = val_17;
            if(val_17 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            val_209 = val_211;
            Spine.BoneData val_18 = val_1.FindBone(boneName:  val_209);
            val_203 = val_18;
            if(val_18 != null)
            {
                goto label_25;
            }
            
            goto label_26;
            label_21:
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_203 = 0;
            label_25:
            val_207 = (Spine.SkeletonData)[1152921510625361216].bones;
            if(val_207 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_212 = val_210.Item["name"];
            if(val_212 != null)
            {
                    val_209 = null;
                if(null != val_209)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            new Spine.BoneData() = new Spine.BoneData(index:  W25, name:  val_212, parent:  val_203);
            val_207 = "length";
            val_209 = "length";
            float val_21 = Spine.SkeletonJson.GetFloat(map:  val_210, name:  val_209, defaultValue:  0f);
            if(new Spine.BoneData() == null)
            {
                    throw new NullReferenceException();
            }
            
            val_21 = (this.<Scale>k__BackingField) * val_21;
            .length = val_21;
            float val_22 = Spine.SkeletonJson.GetFloat(map:  val_210, name:  "x", defaultValue:  0f);
            val_22 = (this.<Scale>k__BackingField) * val_22;
            .x = val_22;
            float val_23 = Spine.SkeletonJson.GetFloat(map:  val_210, name:  "y", defaultValue:  0f);
            val_23 = (this.<Scale>k__BackingField) * val_23;
            .y = val_23;
            .rotation = Spine.SkeletonJson.GetFloat(map:  val_210, name:  "rotation", defaultValue:  0f);
            .scaleX = Spine.SkeletonJson.GetFloat(map:  val_210, name:  "scaleX", defaultValue:  val_208);
            .scaleY = Spine.SkeletonJson.GetFloat(map:  val_210, name:  "scaleY", defaultValue:  val_208);
            .shearX = Spine.SkeletonJson.GetFloat(map:  val_210, name:  "shearX", defaultValue:  0f);
            val_207 = "shearY";
            .shearY = Spine.SkeletonJson.GetFloat(map:  val_210, name:  "shearY", defaultValue:  0f);
            val_203 = 0;
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_213 = Spine.SkeletonJson.GetString(map:  val_210, name:  "transform", defaultValue:  0.ToString());
            val_203 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_209 = val_213;
            if((System.Enum.Parse(enumType:  val_203, value:  val_209, ignoreCase:  true)) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_209 = null;
            .transformMode = null;
            if((Spine.SkeletonData)[1152921510625361216].bones == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.SkeletonData)[1152921510625361216].bones.Add(item:  new Spine.BoneData());
            goto label_40;
            label_17:
            val_13.Dispose();
            var val_33 = (671 == 671) ? -1 : 0;
            val_205 = "slots";
            val_215 = val_203;
            if((val_215.ContainsKey(key:  "slots")) == false)
            {
                goto label_78;
            }
            
            object val_35 = val_215.Item["slots"];
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_36 = val_35.GetEnumerator();
            label_76:
            if(val_13.MoveNext() == false)
            {
                goto label_45;
            }
            
            val_216 = val_14;
            if(val_216 == 0)
            {
                    throw new NullReferenceException();
            }
            
            object val_38 = val_216.Item["name"];
            val_203 = val_38;
            if(val_38 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            object val_39 = val_216.Item["bone"];
            val_217 = val_39;
            if(val_39 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.BoneData val_40 = val_1.FindBone(boneName:  val_217);
            if(val_40 == null)
            {
                goto label_54;
            }
            
            if((Spine.SkeletonData)[1152921510625361216].slots == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.SlotData val_41 = new Spine.SlotData(index:  W26, name:  val_203, boneData:  val_40);
            if((val_216.ContainsKey(key:  "color")) != false)
            {
                    object val_43 = val_216.Item["color"];
                val_203 = val_43;
                if(val_43 != null)
            {
                    if(null != null)
            {
                goto label_58;
            }
            
            }
            
                if(val_41 == null)
            {
                    throw new NullReferenceException();
            }
            
                .r = Spine.SkeletonJson.ToColor(hexString:  val_203, colorIndex:  0, expectedLength:  8);
                .g = Spine.SkeletonJson.ToColor(hexString:  val_203, colorIndex:  1, expectedLength:  8);
                .b = Spine.SkeletonJson.ToColor(hexString:  val_203, colorIndex:  2, expectedLength:  8);
                .a = Spine.SkeletonJson.ToColor(hexString:  val_203, colorIndex:  3, expectedLength:  8);
            }
            
            if((val_216.ContainsKey(key:  "dark")) != false)
            {
                    object val_49 = val_216.Item["dark"];
                val_203 = val_49;
                if(val_49 != null)
            {
                    if(null != null)
            {
                goto label_62;
            }
            
            }
            
                if(val_41 == null)
            {
                    throw new NullReferenceException();
            }
            
                .r2 = Spine.SkeletonJson.ToColor(hexString:  val_203, colorIndex:  0, expectedLength:  6);
                .g2 = Spine.SkeletonJson.ToColor(hexString:  val_203, colorIndex:  1, expectedLength:  6);
                .b2 = Spine.SkeletonJson.ToColor(hexString:  val_203, colorIndex:  2, expectedLength:  6);
                .hasSecondColor = true;
            }
            
            if(val_41 == null)
            {
                    throw new NullReferenceException();
            }
            
            .attachmentName = Spine.SkeletonJson.GetString(map:  val_216, name:  "attachment", defaultValue:  0);
            if((val_216.ContainsKey(key:  "blend")) != false)
            {
                    val_203 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
                val_218 = val_216.Item["blend"];
                if(val_218 != null)
            {
                    if(null != null)
            {
                goto label_71;
            }
            
            }
            
                if((System.Enum.Parse(enumType:  val_203, value:  val_218, ignoreCase:  true)) == null)
            {
                    throw new NullReferenceException();
            }
            
            }
            else
            {
                    val_219 = 0;
            }
            
            .blendMode = val_219;
            if((Spine.SkeletonData)[1152921510625361216].slots == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.SkeletonData)[1152921510625361216].slots.Add(item:  val_41);
            goto label_76;
            label_45:
            val_33 = (long)val_33 + 1;
            mem2[0] = 1137;
            val_13.Dispose();
            if(val_33 != 1)
            {
                    var val_58 = ((1723498368 + (((long)(int)(671 == 0x29F ? -1 : 0) + 1)) << 2) == 1137) ? 1 : 0;
                val_58 = ((val_33 >= 0) ? 1 : 0) & val_58;
                val_214 = val_33 - val_58;
            }
            else
            {
                    val_214 = 0;
            }
            
            label_78:
            val_220 = "ik";
            val_221 = val_203;
            if((val_221.ContainsKey(key:  "ik")) == false)
            {
                goto label_79;
            }
            
            object val_61 = val_221.Item["ik"];
            if(val_61 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_62 = val_61.GetEnumerator();
            val_222 = 1152921510607413024;
            val_212 = 1152921510607438624;
            val_208 = 1f;
            label_108:
            if(val_13.MoveNext() == false)
            {
                goto label_83;
            }
            
            val_223 = val_14;
            if(val_223 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_220 = val_223.Item["name"];
            val_203 = new Spine.IkConstraintData();
            if(val_220 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            val_203 = new Spine.IkConstraintData(name:  val_220);
            if(val_203 == null)
            {
                    throw new NullReferenceException();
            }
            
            .order = Spine.SkeletonJson.GetInt(map:  val_223, name:  "order", defaultValue:  0);
            object val_67 = val_223.Item["bones"];
            if(val_67 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_68 = val_67.GetEnumerator();
            label_99:
            if(val_13.MoveNext() == false)
            {
                goto label_93;
            }
            
            val_213 = val_14;
            if(val_213 != 0)
            {
                    val_224 = mem[val_14];
                val_224 = val_213;
                if(val_224 != null)
            {
                goto label_330;
            }
            
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.BoneData val_70 = val_1.FindBone(boneName:  val_213);
            if(val_70 == null)
            {
                goto label_97;
            }
            
            if((Spine.IkConstraintData)[1152921510625496384].bones == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.IkConstraintData)[1152921510625496384].bones.Add(item:  val_70);
            goto label_99;
            label_93:
            val_214 = val_214 + 1;
            val_225 = 0;
            mem2[0] = 1350;
            val_13.Dispose();
            if(val_225 != 0)
            {
                    throw val_225 = "Target bone not found: "("Target bone not found: ") + val_245;
            }
            
            if(val_214 != 1)
            {
                    var val_71 = ((1723498368 + ((val_214 + 1)) << 2) == 1350) ? 1 : 0;
                val_71 = ((val_214 >= 0) ? 1 : 0) & val_71;
                val_214 = val_214 - val_71;
            }
            
            object val_73 = val_223.Item["target"];
            val_226 = val_73;
            if(val_73 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.BoneData val_74 = val_1.FindBone(boneName:  val_226);
            .target = val_74;
            if(val_74 == null)
            {
                goto label_106;
            }
            
            .bendDirection = (((Spine.SkeletonJson.GetBoolean(map:  val_223, name:  "bendPositive", defaultValue:  true)) & true) != 0) ? (-1) : 1;
            .mix = Spine.SkeletonJson.GetFloat(map:  val_223, name:  "mix", defaultValue:  val_208);
            if((Spine.SkeletonData)[1152921510625361216].ikConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.SkeletonData)[1152921510625361216].ikConstraints.Add(item:  new Spine.IkConstraintData());
            goto label_108;
            label_97:
            System.Exception val_79 = null;
            val_213 = val_79;
            val_79 = new System.Exception(message:  "IK constraint bone not found: "("IK constraint bone not found: ") + val_213);
            val_224 = 1152921510624977456;
            throw val_213;
            label_79:
            val_228 = "transform";
            goto label_124;
            label_83:
            val_214 = val_214 + 1;
            mem2[0] = 1502;
            val_13.Dispose();
            val_228 = "transform";
            if(val_214 != 1)
            {
                    var val_80 = ((1723498368 + ((val_214 + 1)) << 2) == 1502) ? 1 : 0;
                val_80 = ((val_214 >= 0) ? 1 : 0) & val_80;
                val_214 = val_214 - val_80;
            }
            else
            {
                    val_214 = 0;
            }
            
            label_124:
            val_221 = val_228;
            val_216 = val_203;
            if((val_216.ContainsKey(key:  val_228)) == false)
            {
                goto label_169;
            }
            
            object val_83 = val_216.Item["transform"];
            if(val_83 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_84 = val_83.GetEnumerator();
            val_212 = "shearMix";
            val_222 = 1152921510607464224;
            val_208 = 1f;
            label_154:
            if(val_13.MoveNext() == false)
            {
                goto label_129;
            }
            
            val_229 = val_14;
            if(val_229 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_216 = val_229.Item["name"];
            val_203 = new Spine.TransformConstraintData();
            if(val_216 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            val_203 = new Spine.TransformConstraintData(name:  val_216);
            if(val_203 == null)
            {
                    throw new NullReferenceException();
            }
            
            .order = Spine.SkeletonJson.GetInt(map:  val_229, name:  "order", defaultValue:  0);
            object val_89 = val_229.Item["bones"];
            if(val_89 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_90 = val_89.GetEnumerator();
            label_145:
            if(val_13.MoveNext() == false)
            {
                goto label_139;
            }
            
            val_213 = val_14;
            if(val_213 != 0)
            {
                    val_224 = mem[val_14];
                val_224 = val_213;
                if(val_224 != null)
            {
                goto label_330;
            }
            
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.BoneData val_92 = val_1.FindBone(boneName:  val_213);
            if(val_92 == null)
            {
                goto label_143;
            }
            
            if((Spine.TransformConstraintData)[1152921510625541440].bones == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.TransformConstraintData)[1152921510625541440].bones.Add(item:  val_92);
            goto label_145;
            label_139:
            val_214 = val_214 + 1;
            val_230 = 0;
            mem2[0] = 1715;
            val_13.Dispose();
            if(val_230 != 0)
            {
                    throw val_230 = "Slot bone not found: "("Slot bone not found: ") + val_195;
            }
            
            if(val_214 != 1)
            {
                    var val_93 = ((1723498368 + ((val_214 + 1)) << 2) == 1715) ? 1 : 0;
                val_93 = ((val_214 >= 0) ? 1 : 0) & val_93;
                val_214 = val_214 - val_93;
            }
            
            object val_95 = val_229.Item["target"];
            val_231 = val_95;
            if(val_95 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.BoneData val_96 = val_1.FindBone(boneName:  val_231);
            .target = val_96;
            if(val_96 == null)
            {
                goto label_152;
            }
            
            .local = Spine.SkeletonJson.GetBoolean(map:  val_229, name:  "local", defaultValue:  false);
            .relative = Spine.SkeletonJson.GetBoolean(map:  val_229, name:  "relative", defaultValue:  false);
            .offsetRotation = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "rotation", defaultValue:  0f);
            float val_102 = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "x", defaultValue:  0f);
            val_102 = (this.<Scale>k__BackingField) * val_102;
            .offsetX = val_102;
            float val_103 = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "y", defaultValue:  0f);
            val_103 = (this.<Scale>k__BackingField) * val_103;
            .offsetY = val_103;
            .offsetScaleX = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "scaleX", defaultValue:  0f);
            .offsetScaleY = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "scaleY", defaultValue:  0f);
            .offsetShearY = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "shearY", defaultValue:  0f);
            .rotateMix = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "rotateMix", defaultValue:  val_208);
            .translateMix = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "translateMix", defaultValue:  val_208);
            .scaleMix = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "scaleMix", defaultValue:  val_208);
            .shearMix = Spine.SkeletonJson.GetFloat(map:  val_229, name:  "shearMix", defaultValue:  val_208);
            if((Spine.SkeletonData)[1152921510625361216].transformConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.SkeletonData)[1152921510625361216].transformConstraints.Add(item:  new Spine.TransformConstraintData());
            goto label_154;
            label_143:
            System.Exception val_112 = null;
            val_213 = val_112;
            val_112 = new System.Exception(message:  "Transform constraint bone not found: "("Transform constraint bone not found: ") + val_213);
            val_224 = 1152921510624977456;
            throw val_213;
            label_129:
            val_214 = val_214 + 1;
            mem2[0] = 2101;
            val_13.Dispose();
            if(val_214 != 1)
            {
                    var val_113 = ((1723498368 + ((val_214 + 1)) << 2) == 2101) ? 1 : 0;
                val_113 = ((val_214 >= 0) ? 1 : 0) & val_113;
                val_214 = val_214 - val_113;
            }
            else
            {
                    val_214 = 0;
            }
            
            label_169:
            val_233 = "path";
            val_221 = val_203;
            if((val_221.ContainsKey(key:  "path")) == false)
            {
                goto label_226;
            }
            
            object val_116 = val_221.Item["path"];
            if(val_116 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_117 = val_116.GetEnumerator();
            val_212 = 1152921510607534880;
            val_208 = 1f;
            label_211:
            if(val_13.MoveNext() == false)
            {
                goto label_174;
            }
            
            val_234 = val_14;
            if(val_234 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_233 = val_234.Item["name"];
            val_203 = new Spine.PathConstraintData();
            if(val_233 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            val_203 = new Spine.PathConstraintData(name:  val_233);
            if(val_203 == null)
            {
                    throw new NullReferenceException();
            }
            
            .order = Spine.SkeletonJson.GetInt(map:  val_234, name:  "order", defaultValue:  0);
            object val_122 = val_234.Item["bones"];
            if(val_122 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_123 = val_122.GetEnumerator();
            label_190:
            if(val_13.MoveNext() == false)
            {
                goto label_184;
            }
            
            val_213 = val_14;
            if(val_213 != 0)
            {
                    val_224 = mem[val_14];
                val_224 = val_213;
                if(val_224 != null)
            {
                goto label_330;
            }
            
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.BoneData val_125 = val_1.FindBone(boneName:  val_213);
            if(val_125 == null)
            {
                goto label_188;
            }
            
            if((Spine.PathConstraintData)[1152921510625586496].bones == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.PathConstraintData)[1152921510625586496].bones.Add(item:  val_125);
            goto label_190;
            label_184:
            val_214 = val_214 + 1;
            val_235 = 0;
            mem2[0] = 2314;
            val_13.Dispose();
            if(val_235 != 0)
            {
                    throw val_235 = "Target bone not found: "("Target bone not found: ") + val_230;
            }
            
            if(val_214 != 1)
            {
                    var val_126 = ((1723498368 + ((val_214 + 1)) << 2) == 2314) ? 1 : 0;
                val_126 = ((val_214 >= 0) ? 1 : 0) & val_126;
                val_214 = val_214 - val_126;
            }
            
            object val_128 = val_234.Item["target"];
            val_236 = val_128;
            if(val_128 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.SlotData val_129 = val_1.FindSlot(slotName:  val_236);
            .target = val_129;
            if(val_129 == null)
            {
                goto label_197;
            }
            
            val_205 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            if((System.Enum.Parse(enumType:  val_205, value:  Spine.SkeletonJson.GetString(map:  val_234, name:  "positionMode", defaultValue:  "percent"), ignoreCase:  true)) == null)
            {
                    throw new NullReferenceException();
            }
            
            .positionMode = null;
            val_236 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_211 = "length";
            if((System.Enum.Parse(enumType:  val_236, value:  Spine.SkeletonJson.GetString(map:  val_234, name:  "spacingMode", defaultValue:  "length"), ignoreCase:  true)) == null)
            {
                    throw new NullReferenceException();
            }
            
            .spacingMode = null;
            val_235 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            if((System.Enum.Parse(enumType:  val_235, value:  Spine.SkeletonJson.GetString(map:  val_234, name:  "rotateMode", defaultValue:  "tangent"), ignoreCase:  true)) == null)
            {
                    throw new NullReferenceException();
            }
            
            .rotateMode = null;
            .offsetRotation = Spine.SkeletonJson.GetFloat(map:  val_234, name:  "rotation", defaultValue:  0f);
            float val_140 = Spine.SkeletonJson.GetFloat(map:  val_234, name:  "position", defaultValue:  0f);
            .position = val_140;
            if((Spine.PathConstraintData)[1152921510625586496].positionMode == 0)
            {
                    val_140 = (this.<Scale>k__BackingField) * val_140;
                .position = val_140;
            }
            
            float val_141 = Spine.SkeletonJson.GetFloat(map:  val_234, name:  "spacing", defaultValue:  0f);
            .spacing = val_141;
            if((Spine.PathConstraintData)[1152921510625586496].spacingMode < 2)
            {
                    val_141 = (this.<Scale>k__BackingField) * val_141;
                .spacing = val_141;
            }
            
            .rotateMix = Spine.SkeletonJson.GetFloat(map:  val_234, name:  "rotateMix", defaultValue:  val_208);
            .translateMix = Spine.SkeletonJson.GetFloat(map:  val_234, name:  "translateMix", defaultValue:  val_208);
            if((Spine.SkeletonData)[1152921510625361216].pathConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.SkeletonData)[1152921510625361216].pathConstraints.Add(item:  new Spine.PathConstraintData());
            goto label_211;
            label_188:
            val_213 = "Path bone not found: "("Path bone not found: ") + val_213;
            val_224 = 1152921510624977456;
            throw new System.Exception(message:  val_213);
            label_174:
            val_214 = val_214 + 1;
            mem2[0] = 2729;
            val_13.Dispose();
            if(val_214 != 1)
            {
                    var val_146 = ((1723498368 + ((val_214 + 1)) << 2) == 2729) ? 1 : 0;
                val_146 = ((val_214 >= 0) ? 1 : 0) & val_146;
                val_214 = val_214 - val_146;
            }
            else
            {
                    val_214 = 0;
            }
            
            label_226:
            val_205 = val_203;
            if((val_205.ContainsKey(key:  "skins")) == false)
            {
                goto label_316;
            }
            
            object val_149 = val_205.Item["skins"];
            if(val_149 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_212 = 1152921510193070112;
            Dictionary.Enumerator<TKey, TValue> val_150 = val_149.GetEnumerator();
            val_229 = 1152921510193071136;
            label_301:
            if(val_13.MoveNext() == false)
            {
                goto label_231;
            }
            
            val_238 = val_14;
            Spine.Skin val_153 = null;
            val_203 = val_153;
            val_153 = new Spine.Skin(name:  val_14);
            if(val_238 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_154 = val_238.GetEnumerator();
            label_250:
            if(val_13.MoveNext() == false)
            {
                goto label_235;
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_14 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_224 = mem[val_14];
            val_224 = val_14;
            val_224 = (val_14 + 200 + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8;
            if(val_224 != null)
            {
                goto label_330;
            }
            
            val_213 = val_1.FindSlotIndex(slotName:  val_14);
            Dictionary.Enumerator<TKey, TValue> val_157 = val_14.GetEnumerator();
            label_246:
            if(val_13.MoveNext() == false)
            {
                goto label_240;
            }
            
            if(val_14 != 0)
            {
                    val_224 = null;
            }
            
            Spine.Attachment val_159 = this.ReadAttachment(map:  val_14, skin:  val_153, slotIndex:  val_213, name:  val_14, skeletonData:  val_1);
            if(val_159 == null)
            {
                goto label_246;
            }
            
            if(val_203 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_153.AddAttachment(slotIndex:  val_213, name:  val_14, attachment:  val_159);
            goto label_246;
            label_240:
            var val_160 = val_214 + 1;
            val_213 = 0;
            mem2[0] = 3007;
            val_224 = 1152921510193072160;
            val_13.Dispose();
            if(val_213 != 0)
            {
                    throw val_213;
            }
            
            if((val_160 == 1) || ((1723498368 + ((val_214 + 1)) << 2) != 3007))
            {
                goto label_250;
            }
            
            var val_206 = 0;
            val_206 = val_206 ^ (val_160 >> 31);
            var val_161 = val_160 + val_206;
            goto label_250;
            label_235:
            val_214 = val_214 + 1;
            val_245 = 0;
            mem2[0] = 3035;
            val_13.Dispose();
            if(val_245 != 0)
            {
                    throw val_245 = "Parent bone not found: "("Parent bone not found: ") + val_213.Item["parent"];
            }
            
            if(val_214 == 1)
            {
                goto label_294;
            }
            
            var val_165 = ((1723498368 + ((val_214 + 1)) << 2) == 3035) ? 1 : 0;
            val_165 = ((val_214 >= 0) ? 1 : 0) & val_165;
            val_214 = val_214 - val_165;
            if(val_1 != null)
            {
                goto label_295;
            }
            
            throw new NullReferenceException();
            label_294:
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_295:
            if((Spine.SkeletonData)[1152921510625361216].skins == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.SkeletonData)[1152921510625361216].skins.Add(item:  val_153);
            if(val_203 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  (Spine.Skin)[1152921510625672512].name, b:  "default")) == false)
            {
                goto label_301;
            }
            
            .defaultSkin = val_203;
            goto label_301;
            label_231:
            val_214 = val_214 + 1;
            mem2[0] = 3103;
            val_13.Dispose();
            if(val_214 != 1)
            {
                    var val_168 = ((1723498368 + ((val_214 + 1)) << 2) == 3103) ? 1 : 0;
                val_168 = ((val_214 >= 0) ? 1 : 0) & val_168;
                val_214 = val_214 - val_168;
            }
            else
            {
                    val_214 = 0;
            }
            
            label_316:
            val_221 = this.linkedMeshes;
            if(val_221 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_222 = 1152921504863449088;
            var val_211 = 0;
            val_212 = 0;
            label_332:
            if(val_211 >= val_203)
            {
                goto label_318;
            }
            
            if(3103 <= val_211)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_170 = 3103 + 0;
            val_206 = mem[(3103 + 0) + 32];
            val_206 = (3103 + 0) + 32;
            if(val_206 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(((3103 + 0) + 32 + 24) != 0)
            {
                    if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_213 = val_1.FindSkin(skinName:  (3103 + 0) + 32 + 24);
            }
            else
            {
                    if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_213 = (Spine.SkeletonData)[1152921510625361216].defaultSkin;
            }
            
            var val_172 = (val_213 == 0) ? (val_212) : (val_213);
            if(val_213 == null)
            {
                goto label_325;
            }
            
            if(val_172 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Spine.Attachment val_173 = val_172.GetAttachment(slotIndex:  (3103 + 0) + 32 + 32, name:  (3103 + 0) + 32 + 16);
            if(val_173 == null)
            {
                goto label_327;
            }
            
            val_224 = val_173;
            if(((3103 + 0) + 32 + 40) == 0)
            {
                    throw new NullReferenceException();
            }
            
            (3103 + 0) + 32 + 40.ParentMesh = val_224;
            if(((3103 + 0) + 32 + 40) == 0)
            {
                    throw new NullReferenceException();
            }
            
            (3103 + 0) + 32 + 40.UpdateUVs();
            val_221 = this.linkedMeshes;
            val_211 = val_211 + 1;
            if(val_221 != null)
            {
                goto label_332;
            }
            
            throw new NullReferenceException();
            label_318:
            val_221.Clear();
            val_205 = val_203;
            if((val_205.ContainsKey(key:  "events")) == false)
            {
                goto label_346;
            }
            
            object val_175 = val_205.Item["events"];
            if(val_175 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_176 = val_175.GetEnumerator();
            val_222 = 1152921510607578912;
            label_344:
            if(val_13.MoveNext() == false)
            {
                goto label_337;
            }
            
            val_203 = val_14;
            val_238 = val_14;
            Spine.EventData val_178 = new Spine.EventData(name:  val_203);
            if(val_178 == null)
            {
                    throw new NullReferenceException();
            }
            
            .<Int>k__BackingField = Spine.SkeletonJson.GetInt(map:  val_238, name:  "int", defaultValue:  0);
            .<Float>k__BackingField = Spine.SkeletonJson.GetFloat(map:  val_238, name:  "float", defaultValue:  0f);
            .<String>k__BackingField = Spine.SkeletonJson.GetString(map:  val_238, name:  "string", defaultValue:  System.String.alignConst);
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((Spine.SkeletonData)[1152921510625361216].events == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.SkeletonData)[1152921510625361216].events.Add(item:  val_178);
            goto label_344;
            label_337:
            val_214 = val_214 + 1;
            mem2[0] = 3484;
            val_13.Dispose();
            if(val_214 != 1)
            {
                    var val_182 = ((1723498368 + ((val_214 + 1)) << 2) == 3484) ? 1 : 0;
                val_182 = ((val_214 >= 0) ? 1 : 0) & val_182;
                val_214 = val_214 - val_182;
            }
            else
            {
                    val_214 = 0;
            }
            
            label_346:
            val_205 = val_203;
            if((val_205.ContainsKey(key:  "animations")) == false)
            {
                goto label_539;
            }
            
            object val_185 = val_205.Item["animations"];
            if(val_185 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_186 = val_185.GetEnumerator();
            val_213 = 1152921510193071136;
            label_355:
            if(val_13.MoveNext() == false)
            {
                goto label_351;
            }
            
            val_209 = val_14;
            if(val_209 != 0)
            {
                    val_207 = null;
            }
            
            this.ReadAnimation(map:  val_209, name:  val_14, skeletonData:  val_1);
            goto label_355;
            label_351:
            var val_188 = val_214 + 1;
            mem2[0] = 3611;
            val_13.Dispose();
            label_539:
            (Spine.SkeletonData)[1152921510625361216].bones.TrimExcess();
            (Spine.SkeletonData)[1152921510625361216].slots.TrimExcess();
            (Spine.SkeletonData)[1152921510625361216].skins.TrimExcess();
            (Spine.SkeletonData)[1152921510625361216].events.TrimExcess();
            (Spine.SkeletonData)[1152921510625361216].animations.TrimExcess();
            (Spine.SkeletonData)[1152921510625361216].ikConstraints.TrimExcess();
            return val_1;
            label_330:
            label_325:
            val_246 = mem[val_14 + 24];
            val_246 = val_14 + 24;
            val_247 = "Slot not found: ";
            goto label_363;
            label_327:
            val_246 = mem[(3103 + 0) + 32 + 16];
            val_246 = (3103 + 0) + 32 + 16;
            val_247 = "Parent mesh not found: ";
            label_363:
            val_207 = 1152921510624977456;
            val_209 = public Spine.SkeletonData Spine.SkeletonJson::ReadSkeletonData(System.IO.TextReader reader);
            throw new System.Exception(message:  val_247 + val_246);
            label_26:
            throw new System.Exception(message:  val_245);
            label_106:
            System.Exception val_195 = null;
            val_248 = val_195;
            val_195 = new System.Exception(message:  val_225);
            throw val_248;
            label_54:
            throw new System.Exception(message:  val_230);
            label_152:
            throw new System.Exception(message:  val_235);
            label_197:
            val_205 = "Target slot not found: "("Target slot not found: ") + val_235;
            System.Exception val_201 = null;
            val_249 = val_201;
            val_201 = new System.Exception(message:  val_205);
            val_211 = 1152921510624977456;
            throw val_249;
            label_71:
            label_62:
            label_58:
            label_4:
            System.Exception val_202 = null;
            val_250 = val_202;
            val_202 = new System.Exception(message:  "Invalid JSON.");
            goto label_364;
            label_1:
            System.ArgumentNullException val_203 = null;
            val_250 = val_203;
            val_203 = new System.ArgumentNullException(paramName:  "reader", message:  "reader cannot be null.");
            label_364:
            val_204 = public Spine.SkeletonData Spine.SkeletonJson::ReadSkeletonData(System.IO.TextReader reader);
            throw val_250;
        }
        private Spine.Attachment ReadAttachment(System.Collections.Generic.Dictionary<string, object> map, Spine.Skin skin, int slotIndex, string name, Spine.SkeletonData skeletonData)
        {
            int val_69;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_70;
            string val_71;
            string val_72;
            Spine.MeshAttachment val_74;
            var val_76;
            var val_78;
            var val_79;
            string val_81;
            val_69 = slotIndex;
            val_70 = map;
            val_71 = Spine.SkeletonJson.GetString(map:  val_70, name:  "name", defaultValue:  name);
            string val_2 = Spine.SkeletonJson.GetString(map:  val_70, name:  "type", defaultValue:  "region");
            string val_4 = ((System.String.op_Equality(a:  val_2, b:  "skinnedmesh")) != true) ? "weightedmesh" : (val_2);
            string val_6 = ((System.String.op_Equality(a:  val_4, b:  "weightedmesh")) != true) ? "mesh" : (val_4);
            object val_10 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  ((System.String.op_Equality(a:  val_6, b:  "weightedlinkedmesh")) != true) ? "linkedmesh" : (val_6), ignoreCase:  true);
            if(null > 6)
            {
                goto label_7;
            }
            
            var val_71 = 30113372;
            val_72 = Spine.SkeletonJson.GetString(map:  val_70, name:  "path", defaultValue:  val_71);
            val_71 = mem[4611686018537160284] + val_71;
            goto (mem[4611686018537160284] + 30113372);
            label_7:
            val_74 = 0;
            return (Spine.Attachment)val_74;
            label_22:
            if(((slotIndex + 176 + 8) + -8) == null)
            {
                goto label_21;
            }
            
             =  + 1;
             =  + 16;
            if( < (slotIndex + 294))
            {
                goto label_22;
            }
            
            goto label_23;
            label_32:
            if(((slotIndex + 176 + 8) + -8) == null)
            {
                goto label_31;
            }
            
             =  + 1;
             =  + 16;
            if( < (slotIndex + 294))
            {
                goto label_32;
            }
            
            goto label_33;
            label_37:
            if(((slotIndex + 176 + 8) + -8) == null)
            {
                goto label_36;
            }
            
             =  + 1;
             =  + 16;
            if( < (slotIndex + 294))
            {
                goto label_37;
            }
            
            goto label_38;
            label_21:
            var val_81 = ;
            val_81 = val_81 + 2;
             =  + val_81;
            val_76 =  + 304;
            label_23:
            Spine.BoundingBoxAttachment val_49 = val_69.NewBoundingBoxAttachment(skin:  val_74, name:  val_71);
            val_74 = val_49;
            if(val_49 != null)
            {
                goto label_57;
            }
            
            return (Spine.Attachment)val_74;
            label_31:
            var val_83 = ;
            val_83 = val_83 + 5;
             =  + val_83;
            val_78 =  + 304;
            label_33:
            Spine.ClippingAttachment val_55 = val_69.NewClippingAttachment(skin:  val_74, name:  val_71);
            val_74 = val_55;
            if(val_55 == null)
            {
                    return (Spine.Attachment)val_74;
            }
            
            val_71 = "end";
            Spine.SlotData val_57 = skeletonData.FindSlot(slotName:  Spine.SkeletonJson.GetString(map:  val_70, name:  "end", defaultValue:  0));
            if(val_57 == null)
            {
                goto label_63;
            }
            
            val_55.endSlot = val_57;
            label_57:
            this.attachmentLoader.ReadVertices(map:  val_70, attachment:  val_74, verticesLength:  (Spine.SkeletonJson.GetInt(map:  val_70, name:  "vertexCount", defaultValue:  0)) << 1);
            return (Spine.Attachment)val_74;
            label_36:
            var val_85 = ;
            val_85 = val_85 + 3;
             =  + val_85;
            val_79 =  + 304;
            label_38:
            Spine.PathAttachment val_60 = val_69.NewPathAttachment(skin:  val_74, name:  val_71);
            val_74 = val_60;
            if(val_60 == null)
            {
                    return (Spine.Attachment)val_74;
            }
            
            val_60.closed = Spine.SkeletonJson.GetBoolean(map:  val_70, name:  "closed", defaultValue:  false);
            val_60.constantSpeed = Spine.SkeletonJson.GetBoolean(map:  val_70, name:  "constantSpeed", defaultValue:  true);
            this.attachmentLoader.ReadVertices(map:  val_70, attachment:  val_74, verticesLength:  (Spine.SkeletonJson.GetInt(map:  val_70, name:  "vertexCount", defaultValue:  0)) << 1);
            val_60.lengths = Spine.SkeletonJson.GetFloatArray(map:  val_70, name:  "lengths", scale:  this.<Scale>k__BackingField);
            return (Spine.Attachment)val_74;
            label_63:
            val_81 = "Clipping end slot not found: "("Clipping end slot not found: ") + Spine.SkeletonJson.GetString(map:  ???, name:  ???, defaultValue:  0)(Spine.SkeletonJson.GetString(map:  ???, name:  ???, defaultValue:  0));
            throw new System.Exception(message:  val_81);
        }
        private void ReadVertices(System.Collections.Generic.Dictionary<string, object> map, Spine.VertexAttachment attachment, int verticesLength)
        {
            var val_8;
            int val_9;
            Spine.VertexAttachment val_10;
            T[] val_11;
            var val_12;
            val_9 = verticesLength;
            val_10 = attachment;
            attachment.worldVerticesLength = val_9;
            val_11 = Spine.SkeletonJson.GetFloatArray(map:  map, name:  "vertices", scale:  1f);
            if(val_1.Length != val_9)
            {
                goto label_3;
            }
            
            if(((this.<Scale>k__BackingField) == 1f) || (val_9 < 1))
            {
                goto label_8;
            }
            
            do
            {
                float val_10 = val_11[0];
                var val_3 = 8 + 1;
                val_10 = (this.<Scale>k__BackingField) * val_10;
                val_11[0] = val_10;
            }
            while((8 - 7) < (long)val_9);
            
            goto label_8;
            label_3:
            Spine.ExposedList<System.Single> val_6 = new Spine.ExposedList<System.Single>(capacity:  val_9 + (val_9 << 3));
            Spine.ExposedList<System.Int32> val_7 = null;
            val_9 = val_7;
            val_7 = new Spine.ExposedList<System.Int32>(capacity:  val_9 + (val_9 << 1));
            if(val_1.Length < 1)
            {
                goto label_20;
            }
            
            val_8 = 1;
            label_21:
            float val_11 = val_11[0];
            val_11 = (val_11 == Infinityf) ? (-(double)val_11) : ((double)val_11);
            int val_12 = (int)val_11;
            val_7.Add(item:  val_12);
            val_12 = val_8 + (val_12 << 2);
            if(val_8 < val_12)
            {
                    do
            {
                float val_13 = val_11[4];
                val_13 = (val_13 == Infinityf) ? (-(double)val_13) : ((double)val_13);
                val_7.Add(item:  (int)val_13);
                val_8 = val_8 + 1;
                float val_15 = this.<Scale>k__BackingField;
                val_15 = val_15 * (val_11[val_8 << 2]);
                val_6.Add(item:  val_15);
                val_8 = val_8 + 1;
                float val_16 = val_11[12];
                val_16 = val_16 * (this.<Scale>k__BackingField);
                val_6.Add(item:  val_16);
                val_8 = val_8 + 1;
                val_6.Add(item:  val_11[16]);
                val_8 = val_8 + 1;
            }
            while(val_8 < val_12);
            
                val_12 = 5;
            }
            else
            {
                    val_12 = val_8;
            }
            
            if(val_12 >= val_1.Length)
            {
                goto label_20;
            }
            
            val_8 = val_12 + 1;
            if(val_12 < val_1.Length)
            {
                goto label_21;
            }
            
            throw new IndexOutOfRangeException();
            label_20:
            val_10 = val_10;
            mem2[0] = val_7.ToArray();
            val_11 = val_6.ToArray();
            label_8:
            mem2[0] = val_11;
        }
        private void ReadAnimation(System.Collections.Generic.Dictionary<string, object> map, string name, Spine.SkeletonData skeletonData)
        {
            float val_5;
            string val_6;
            float val_283;
            Spine.ExposedList<T> val_284;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_285;
            var val_286;
            string val_287;
            var val_288;
            System.Single[] val_289;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_290;
            var val_291;
            var val_292;
            var val_293;
            System.Single[] val_297;
            System.String[] val_298;
            int val_299;
            var val_300;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_301;
            var val_302;
            var val_303;
            string val_304;
            Spine.CurveTimeline val_305;
            Spine.ExposedList<T> val_307;
            int val_308;
            int val_309;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_310;
            var val_311;
            float val_312;
            float val_313;
            var val_314;
            float val_316;
            var val_317;
            System.Single[] val_319;
            Spine.CurveTimeline val_320;
            var val_324;
            string val_325;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_328;
            var val_329;
            int val_330;
            var val_331;
            var val_333;
            Spine.ExposedList<T> val_334;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_335;
            string val_336;
            val_283 = this.<Scale>k__BackingField;
            Spine.ExposedList<Spine.Timeline> val_1 = null;
            val_284 = val_1;
            val_1 = new Spine.ExposedList<Spine.Timeline>();
            val_285 = map;
            val_286 = "slots";
            if((val_285.ContainsKey(key:  "slots")) == false)
            {
                goto label_2;
            }
            
            val_287 = 1152921504685600768;
            Dictionary.Enumerator<TKey, TValue> val_4 = val_285.Item["slots"].GetEnumerator();
            label_133:
            if(val_5.MoveNext() == false)
            {
                goto label_6;
            }
            
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_288 = val_6;
            int val_9 = skeletonData.FindSlotIndex(slotName:  val_6);
            if(val_288 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_10 = val_288.GetEnumerator();
            label_78:
            if(val_5.MoveNext() == false)
            {
                goto label_11;
            }
            
            val_289 = val_6;
            if((System.String.op_Equality(a:  val_6, b:  "attachment")) == false)
            {
                goto label_15;
            }
            
            if(val_289 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_285 = mem[val_6 + 24];
            val_285 = val_6 + 24;
            Spine.AttachmentTimeline val_13 = new Spine.AttachmentTimeline(frameCount:  val_285);
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            .slotIndex = val_9;
            List.Enumerator<T> val_14 = val_289.GetEnumerator();
            val_289 = 0;
            label_26:
            if(val_5.MoveNext() == false)
            {
                goto label_18;
            }
            
            val_290 = val_6;
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_290.Item["time"] == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_17 = val_290.Item["name"];
            if(val_17 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            var val_18 = val_289 + 1;
            val_13.SetFrame(frameIndex:  0, time:  3.230314E-38f, attachmentName:  val_17);
            goto label_26;
            label_15:
            if((System.String.op_Equality(a:  val_6, b:  "color")) == false)
            {
                goto label_27;
            }
            
            if(val_289 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_285 = mem[val_6 + 24];
            val_285 = val_6 + 24;
            Spine.ColorTimeline val_20 = new Spine.ColorTimeline(frameCount:  val_285);
            if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
            .slotIndex = val_9;
            List.Enumerator<T> val_21 = val_289.GetEnumerator();
            val_289 = 0;
            goto label_30;
            label_38:
            val_20.SetFrame(frameIndex:  0, time:  V9.16B, r:  Spine.SkeletonJson.ToColor(hexString:  X27, colorIndex:  0, expectedLength:  8), g:  Spine.SkeletonJson.ToColor(hexString:  X27, colorIndex:  1, expectedLength:  8), b:  Spine.SkeletonJson.ToColor(hexString:  X27, colorIndex:  2, expectedLength:  8), a:  Spine.SkeletonJson.ToColor(hexString:  X27, colorIndex:  3, expectedLength:  8));
            Spine.SkeletonJson.ReadCurve(valueMap:  X26, timeline:  val_20, frameIndex:  0);
            val_289 = 1;
            label_30:
            if(val_5.MoveNext() == false)
            {
                goto label_31;
            }
            
            val_290 = val_6;
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_290.Item["time"] == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_290.Item["color"] == null) || (null == null))
            {
                goto label_38;
            }
            
            throw new NullReferenceException();
            label_18:
            val_289 = 0;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            val_291 = 1;
            if(val_291 != 1)
            {
                    var val_29 = (291 == 291) ? 1 : 0;
                val_29 = ((val_291 >= 0) ? 1 : 0) & val_29;
                val_291 = val_291 - val_29;
            }
            
            if(val_284 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_13);
            val_289 = (Spine.AttachmentTimeline)[1152921510627798464].frames;
            if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_32 = val_13.FrameCount - 1;
            if(val_32 >= (Spine.AttachmentTimeline)[1152921510627798464].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_33 = System.Math.Max(val1:  0f, val2:  val_289[val_32]);
            goto label_78;
            label_27:
            if((System.String.op_Equality(a:  val_6, b:  "twoColor")) == false)
            {
                goto label_48;
            }
            
            if(val_289 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_285 = mem[val_6 + 24];
            val_285 = val_6 + 24;
            Spine.TwoColorTimeline val_35 = new Spine.TwoColorTimeline(frameCount:  val_285);
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            .slotIndex = val_9;
            List.Enumerator<T> val_36 = val_289.GetEnumerator();
            val_290 = 0;
            goto label_51;
            label_61:
            val_287 = 1152921504685600768;
            val_35.SetFrame(frameIndex:  0, time:  V9.16B, r:  Spine.SkeletonJson.ToColor(hexString:  val_287, colorIndex:  0, expectedLength:  8), g:  Spine.SkeletonJson.ToColor(hexString:  val_287, colorIndex:  1, expectedLength:  8), b:  Spine.SkeletonJson.ToColor(hexString:  val_287, colorIndex:  2, expectedLength:  8), a:  Spine.SkeletonJson.ToColor(hexString:  val_287, colorIndex:  3, expectedLength:  8), r2:  Spine.SkeletonJson.ToColor(hexString:  val_289, colorIndex:  0, expectedLength:  6), g2:  Spine.SkeletonJson.ToColor(hexString:  val_289, colorIndex:  1, expectedLength:  6), b2:  Spine.SkeletonJson.ToColor(hexString:  val_289, colorIndex:  2, expectedLength:  6));
            Spine.SkeletonJson.ReadCurve(valueMap:  X27, timeline:  val_35, frameIndex:  0);
            val_290 = 1;
            label_51:
            if(val_5.MoveNext() == false)
            {
                goto label_52;
            }
            
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_6.Item["time"] == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_6.Item["light"] != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            object val_47 = val_6.Item["dark"];
            val_289 = val_47;
            if((val_47 == null) || (null == null))
            {
                goto label_61;
            }
            
            throw new NullReferenceException();
            label_31:
            var val_285 = val_291;
            val_285 = val_285 + 1;
            val_289 = 0;
            mem2[0] = 517;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            val_292 = val_285;
            if(val_292 != 1)
            {
                    var val_48 = ((1725919104 + (((val_291 - (val_291 >= 0x0 ? 1 : 0 & 291 == 0x123 ? 1 : 0)) + 1)) << 2) == 517) ? 1 : 0;
                val_48 = ((val_292 >= 0) ? 1 : 0) & val_48;
                val_292 = val_292 - val_48;
            }
            
            if(val_284 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_20);
            val_289 = (Spine.ColorTimeline)[1152921510627810752].frames;
            int val_50 = val_20.FrameCount;
            if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_51 = val_50 + (val_50 << 2);
            val_51 = val_51 - 5;
            if(val_51 >= (Spine.ColorTimeline)[1152921510627810752].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_52 = System.Math.Max(val1:  0f, val2:  val_289[val_51]);
            goto label_78;
            label_52:
            var val_287 = val_292;
            val_287 = val_287 + 1;
            val_289 = 0;
            mem2[0] = 796;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            val_293 = val_287;
            if(val_293 != 1)
            {
                    var val_53 = ((1725919104 + (((((val_291 - (val_291 >= 0x0 ? 1 : 0 & 291 == 0x123 ? 1 : 0)) + 1) - (val_292 >= 0x0 ? 1 : 0 & 1725919104 + (((val_291 - (val_291 >= 0x0 ? 1 : 0 & 291 == 0x123 ? 1 : 0)) + 1)) << 2 == 0x205 ? 1 : 0))) << 2) == 796) ? 1 : 0;
                val_53 = ((val_293 >= 0) ? 1 : 0) & val_53;
                val_293 = val_293 - val_53;
            }
            
            if(val_284 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_35);
            val_289 = (Spine.TwoColorTimeline)[1152921510627859904].frames;
            if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_56 = val_35.FrameCount << 3;
            val_56 = val_56 - 8;
            if(val_56 >= (Spine.TwoColorTimeline)[1152921510627859904].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_57 = System.Math.Max(val1:  0f, val2:  val_289[val_56]);
            goto label_78;
            label_11:
            val_297 = 0;
            var val_58 = val_293 + 1;
            mem2[0] = 911;
            val_5.Dispose();
            if(val_297 != 0)
            {
                    throw val_297 = "Path constraint not found: "("Path constraint not found: ") + val_285;
            }
            
            if((val_58 == 1) || ((1725919104 + (((((((val_291 - (val_291 >= 0x0 ? 1 : 0 & 291 == 0x123 ? 1 : 0)) + 1) - (val_292 >= 0x0 ? 1 : 0 & 1725919104 + (((val_291 - (val_291 >= 0x0 ? 1 : 0 & 291 == 0x123 ? 1 : 0)) + 1)) << 2 == 0x205 ? 1 : 0) << 2) != 911))
            {
                goto label_133;
            }
            
            var val_289 = 0;
            val_289 = val_289 ^ (val_58 >> 31);
            val_289 = val_58 + val_289;
            goto label_133;
            label_48:
            string[] val_59 = new string[5];
            val_298 = val_59;
            if(val_59 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_299 = val_59.Length;
            if(val_299 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_298[0] = "Invalid timeline type for a slot: ";
            if(val_6 != 0)
            {
                    if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_299 = val_59.Length;
            }
            
            if(val_299 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_298[1] = val_6;
            if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_299 = val_59.Length;
            if(val_299 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_298[2] = " (";
            if(val_6 != 0)
            {
                    if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_299 = val_59.Length;
            }
            
            if(val_299 <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_298[3] = val_6;
            if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_299 = val_59.Length;
            if(val_299 <= 4)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_298[4] = ")";
            throw new System.Exception(message:  +val_59);
            label_2:
            val_300 = 0;
            val_301 = val_285;
            goto label_237;
            label_6:
            var val_290 = val_293;
            val_290 = val_290 + 1;
            mem2[0] = 939;
            val_5.Dispose();
            val_301 = map;
            if(val_290 != 1)
            {
                    var val_62 = ((1725919104 + (((((((val_291 - (val_291 >= 0x0 ? 1 : 0 & 291 == 0x123 ? 1 : 0)) + 1) - (val_292 >= 0x0 ? 1 : 0 & 1725919104 + (((val_291 - (val_291 >= 0x0 ? 1 : 0 & 291 == 0x123 ? 1 : 0)) + 1)) << 2 == 0x205 ? 1 : 0) << 2) == 939) ? 1 : 0;
                val_62 = ((val_290 >= 0) ? 1 : 0) & val_62;
                val_300 = val_290 - val_62;
            }
            else
            {
                    val_300 = 0;
            }
            
            label_237:
            val_286 = "bones";
            if((val_301.ContainsKey(key:  "bones")) == false)
            {
                goto label_238;
            }
            
            val_285 = 1152921510214912464;
            val_302 = 1152921504685600768;
            val_303 = 1152921510222861648;
            Dictionary.Enumerator<TKey, TValue> val_66 = val_301.Item["bones"].GetEnumerator();
            label_332:
            val_284 = val_284;
            if(val_5.MoveNext() == false)
            {
                goto label_242;
            }
            
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_288 = val_6;
            int val_68 = skeletonData.FindBoneIndex(boneName:  val_6);
            if(val_68 == 1)
            {
                goto label_244;
            }
            
            if(val_288 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_69 = val_288.GetEnumerator();
            string val_293 = val_6;
            label_303:
            if(val_5.MoveNext() == false)
            {
                goto label_248;
            }
            
            val_304 = val_293;
            val_290 = val_293;
            if((System.String.op_Equality(a:  val_304, b:  "rotate")) == false)
            {
                goto label_252;
            }
            
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_289 = mem[val_6 + 24];
            val_289 = val_6 + 24;
            Spine.RotateTimeline val_72 = new Spine.RotateTimeline(frameCount:  val_289);
            if(val_72 == null)
            {
                    throw new NullReferenceException();
            }
            
            .boneIndex = val_68;
            List.Enumerator<T> val_73 = val_290.GetEnumerator();
            val_289 = 0;
            if(val_5.MoveNext() == false)
            {
                goto label_256;
            }
            
            val_290 = val_6;
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_290.Item["time"] == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_290.Item["angle"] == null)
            {
                    throw new NullReferenceException();
            }
            
            throw new NullReferenceException();
            label_252:
            if((System.String.op_Equality(a:  val_304, b:  "translate")) != true)
            {
                    if((System.String.op_Equality(a:  val_304, b:  "scale")) != true)
            {
                    if((System.String.op_Equality(a:  val_304, b:  "shear")) == false)
            {
                goto label_267;
            }
            
            }
            
            }
            
            if((System.String.op_Equality(a:  val_304, b:  "scale")) == false)
            {
                goto label_268;
            }
            
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Spine.ScaleTimeline val_81 = null;
            val_305 = val_81;
            val_81 = new Spine.ScaleTimeline(frameCount:  val_6 + 24);
            goto label_277;
            label_256:
            val_289 = 0;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            var val_291 = 1;
            if(val_291 == 1)
            {
                goto label_272;
            }
            
            var val_82 = (1242 == 1242) ? 1 : 0;
            val_82 = ((val_291 >= 0) ? 1 : 0) & val_82;
            val_291 = val_291 - val_82;
            if(val_284 != 0)
            {
                goto label_273;
            }
            
            throw new NullReferenceException();
            label_268:
            if((System.String.op_Equality(a:  val_304, b:  "shear")) == false)
            {
                goto label_275;
            }
            
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Spine.ShearTimeline val_85 = null;
            val_305 = val_85;
            val_85 = new Spine.ShearTimeline(frameCount:  val_6 + 24);
            goto label_277;
            label_272:
            if(val_284 == 0)
            {
                    throw new NullReferenceException();
            }
            
            label_273:
            val_1.Add(item:  val_72);
            val_289 = (Spine.RotateTimeline)[1152921510627966448].frames;
            if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_87 = val_72.FrameCount << 1;
            val_87 = val_87 - 2;
            if(val_87 >= (Spine.RotateTimeline)[1152921510627966448].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_88 = System.Math.Max(val1:  0f, val2:  val_289[val_87]);
            goto label_303;
            label_275:
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_289 = mem[val_6 + 24];
            val_289 = val_6 + 24;
            Spine.TranslateTimeline val_89 = null;
            val_305 = val_89;
            val_89 = new Spine.TranslateTimeline(frameCount:  val_289);
            label_277:
            if(val_305 == null)
            {
                    throw new NullReferenceException();
            }
            
            .boneIndex = val_68;
            List.Enumerator<T> val_90 = val_290.GetEnumerator();
            val_289 = 0;
            if(val_5.MoveNext() != false)
            {
                    val_290 = val_6;
                if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
                object val_95 = val_290.Item["time"];
                if(val_95 == null)
            {
                    throw new NullReferenceException();
            }
            
                throw new NullReferenceException();
            }
            
            val_289 = 0;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            var val_294 = 1;
            if(val_294 == 1)
            {
                goto label_295;
            }
            
            var val_96 = (1560 == 1560) ? 1 : 0;
            val_96 = ((val_294 >= 0) ? 1 : 0) & val_96;
            val_294 = val_294 - val_96;
            if(val_284 != 0)
            {
                goto label_296;
            }
            
            throw new NullReferenceException();
            label_295:
            if(val_284 == 0)
            {
                    throw new NullReferenceException();
            }
            
            label_296:
            val_1.Add(item:  val_89);
            val_289 = (Spine.TranslateTimeline)[1152921510628023792].frames;
            int val_98 = val_89.FrameCount;
            if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_99 = val_98 + (val_98 << 1);
            val_99 = val_99 - 3;
            if(val_99 >= (Spine.TranslateTimeline)[1152921510628023792].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_100 = System.Math.Max(val1:  0f, val2:  val_289[val_99]);
            goto label_303;
            label_248:
            val_297 = 0;
            val_307 = 1;
            val_5.Dispose();
            if(val_297 != 0)
            {
                    throw val_297;
            }
            
            if((val_307 == 1) || (1675 != 1675))
            {
                goto label_332;
            }
            
            var val_296 = 0;
            val_296 = val_296 ^ 0;
            val_296 = val_307 + val_296;
            goto label_332;
            label_267:
            string[] val_101 = new string[5];
            if(val_101 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_308 = val_101.Length;
            if(val_308 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_101[0] = "Invalid timeline type for a bone: ";
            if(val_304 != 0)
            {
                    if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_309 = val_101.Length;
            }
            
            if(val_309 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_101[1] = val_304;
            if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_309 = val_101.Length;
            if(val_309 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_101[2] = " (";
            if(val_6 != 0)
            {
                    if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_309 = val_101.Length;
            }
            
            if(val_309 <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_101[3] = val_6;
            if(X0 != true)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_309 = val_101.Length;
            if(val_309 <= 4)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_101[4] = ")";
            throw new System.Exception(message:  +val_101);
            label_238:
            val_310 = val_301;
            val_303 = 1152921510222861648;
            goto label_425;
            label_242:
            val_300 = val_296 + 1;
            mem2[0] = 1703;
            val_5.Dispose();
            val_310 = map;
            if(val_300 != 1)
            {
                    var val_104 = ((1725919104 + (((val_307 + (0 ^ 0)) + 1)) << 2) == 1703) ? 1 : 0;
                val_104 = ((val_300 >= 0) ? 1 : 0) & val_104;
                val_300 = val_300 - val_104;
            }
            
            label_425:
            val_286 = "ik";
            if((val_310.ContainsKey(key:  "ik")) == false)
            {
                goto label_426;
            }
            
            Dictionary.Enumerator<TKey, TValue> val_108 = val_310.Item["ik"].GetEnumerator();
            val_290 = 1152921504622129152;
            val_311 = "mix";
            val_307 = "bendPositive";
            val_312 = 1f;
            label_452:
            val_313 = 0f;
            if(val_5.MoveNext() == false)
            {
                goto label_430;
            }
            
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_288 = val_6;
            if(val_288 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Spine.IkConstraintTimeline val_111 = new Spine.IkConstraintTimeline(frameCount:  val_6 + 24);
            if((skeletonData + 72) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_285 = 1152921510214912464;
            if(val_111 == null)
            {
                    throw new NullReferenceException();
            }
            
            .ikConstraintIndex = skeletonData + 72.IndexOf(item:  skeletonData.FindIkConstraint(constraintName:  val_6));
            List.Enumerator<T> val_113 = val_288.GetEnumerator();
            val_289 = 0;
            if(val_5.MoveNext() != false)
            {
                    if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
                object val_118 = val_6.Item["time"];
                if(val_118 == null)
            {
                    throw new NullReferenceException();
            }
            
                throw new NullReferenceException();
            }
            
            var val_297 = val_300;
            val_297 = val_297 + 1;
            val_297 = 0;
            mem2[0] = 1950;
            val_5.Dispose();
            if(val_297 != 0)
            {
                    throw val_297;
            }
            
            val_314 = val_297;
            if(val_314 != 1)
            {
                    var val_119 = ((1725919104 + (((((val_307 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((val_307 + (0 ^ 0)) + 1)) << 2 == 0x6A7 ? 1 : 0)) + 1)) << 2) == 1950) ? 1 : 0;
                val_119 = ((val_314 >= 0) ? 1 : 0) & val_119;
                val_314 = val_314 - val_119;
            }
            
            if(val_284 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_111);
            val_297 = (Spine.IkConstraintTimeline)[1152921510628089376].frames;
            int val_121 = val_111.FrameCount;
            if(val_297 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_122 = val_121 + (val_121 << 1);
            val_122 = val_122 - 3;
            if(val_122 >= (Spine.IkConstraintTimeline)[1152921510628089376].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_123 = System.Math.Max(val1:  val_313, val2:  val_297[val_122]);
            goto label_452;
            label_426:
            val_313 = 0f;
            goto label_466;
            label_430:
            val_300 = val_300 + 1;
            mem2[0] = 2012;
            val_5.Dispose();
            val_284 = val_284;
            val_303 = 1152921510222861648;
            val_310 = map;
            if(val_300 != 1)
            {
                    var val_124 = ((1725919104 + (((((val_307 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((val_307 + (0 ^ 0)) + 1)) << 2 == 0x6A7 ? 1 : 0)) + 1)) << 2) == 2012) ? 1 : 0;
                val_124 = ((val_300 >= 0) ? 1 : 0) & val_124;
                val_300 = val_300 - val_124;
            }
            
            label_466:
            val_286 = "transform";
            if((val_310.ContainsKey(key:  "transform")) == false)
            {
                goto label_467;
            }
            
            Dictionary.Enumerator<TKey, TValue> val_128 = val_310.Item["transform"].GetEnumerator();
            val_290 = 1152921504622129152;
            val_311 = "rotateMix";
            val_307 = "translateMix";
            val_312 = 1f;
            label_493:
            val_316 = val_313;
            if(val_5.MoveNext() == false)
            {
                goto label_471;
            }
            
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_288 = val_6;
            if(val_288 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Spine.TransformConstraintTimeline val_131 = new Spine.TransformConstraintTimeline(frameCount:  val_6 + 24);
            if((skeletonData + 80) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_285 = 1152921510214912464;
            if(val_131 == null)
            {
                    throw new NullReferenceException();
            }
            
            .transformConstraintIndex = skeletonData + 80.IndexOf(item:  skeletonData.FindTransformConstraint(constraintName:  val_6));
            List.Enumerator<T> val_133 = val_288.GetEnumerator();
            val_289 = 0;
            if(val_5.MoveNext() != false)
            {
                    if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
                object val_139 = val_6.Item["time"];
                if(val_139 == null)
            {
                    throw new NullReferenceException();
            }
            
                throw new NullReferenceException();
            }
            
            var val_299 = val_300;
            val_299 = val_299 + 1;
            val_297 = 0;
            mem2[0] = 2303;
            val_5.Dispose();
            if(val_297 != 0)
            {
                    throw val_297;
            }
            
            val_317 = val_299;
            if(val_317 != 1)
            {
                    var val_140 = ((1725919104 + (((((((val_307 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((val_307 + (0 ^ 0)) + 1)) << 2 == 0x6A7 ? 1 : 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((((val_307 + (0 ^ 0)) + 1) - ) << 2) == 2303) ? 1 : 0;
                val_140 = ((val_317 >= 0) ? 1 : 0) & val_140;
                val_317 = val_317 - val_140;
            }
            
            if(val_284 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_131);
            val_297 = (Spine.TransformConstraintTimeline)[1152921510628142624].frames;
            int val_142 = val_131.FrameCount;
            if(val_297 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_143 = val_142 + (val_142 << 2);
            val_143 = val_143 - 5;
            if(val_143 >= (Spine.TransformConstraintTimeline)[1152921510628142624].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_144 = System.Math.Max(val1:  val_316, val2:  val_297[val_143]);
            goto label_493;
            label_467:
            val_316 = val_313;
            goto label_509;
            label_471:
            val_300 = val_300 + 1;
            mem2[0] = 2365;
            val_5.Dispose();
            val_284 = val_284;
            val_303 = 1152921510222861648;
            val_310 = map;
            if(val_300 != 1)
            {
                    var val_145 = ((1725919104 + (((((((val_307 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((val_307 + (0 ^ 0)) + 1)) << 2 == 0x6A7 ? 1 : 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((((val_307 + (0 ^ 0)) + 1) - ) << 2) == 2365) ? 1 : 0;
                val_145 = ((val_300 >= 0) ? 1 : 0) & val_145;
                val_300 = val_300 - val_145;
            }
            
            label_509:
            val_319 = "paths";
            if((val_310.ContainsKey(key:  "paths")) == false)
            {
                goto label_656;
            }
            
            Dictionary.Enumerator<TKey, TValue> val_149 = val_310.Item["paths"].GetEnumerator();
            val_307 = 1152921504622129152;
            label_600:
            if(val_5.MoveNext() == false)
            {
                goto label_514;
            }
            
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_285 = val_6;
            val_288 = val_6;
            int val_151 = skeletonData.FindPathConstraintIndex(pathConstraintName:  val_285);
            if(val_151 == 1)
            {
                goto label_516;
            }
            
            if((skeletonData + 88) == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_301 = skeletonData + 88 + 16;
            if(val_301 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_151 >= (skeletonData + 88 + 16 + 24))
            {
                    throw new IndexOutOfRangeException();
            }
            
            if(val_288 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_301 = val_301 + (val_151 << 3);
            val_285 = mem[(skeletonData + 88 + 16 + (val_151) << 3) + 32];
            val_285 = (skeletonData + 88 + 16 + (val_151) << 3) + 32;
            Dictionary.Enumerator<TKey, TValue> val_152 = val_288.GetEnumerator();
            val_289 = 1152921504687730688;
            label_572:
            label_529:
            if(val_5.MoveNext() == false)
            {
                goto label_523;
            }
            
            val_290 = val_6;
            if(((System.String.op_Equality(a:  val_6, b:  "position")) == true) || ((System.String.op_Equality(a:  val_6, b:  "spacing")) == true))
            {
                goto label_528;
            }
            
            if((System.String.op_Equality(a:  val_6, b:  "mix")) == false)
            {
                goto label_529;
            }
            
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_289 = mem[val_6 + 24];
            val_289 = val_6 + 24;
            Spine.PathConstraintMixTimeline val_157 = new Spine.PathConstraintMixTimeline(frameCount:  val_289);
            if(val_157 == null)
            {
                    throw new NullReferenceException();
            }
            
            .pathConstraintIndex = val_151;
            List.Enumerator<T> val_158 = val_290.GetEnumerator();
            val_289 = 0;
            if(val_5.MoveNext() == false)
            {
                goto label_533;
            }
            
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            float val_161 = Spine.SkeletonJson.GetFloat(map:  val_6, name:  "rotateMix", defaultValue:  1f);
            float val_162 = Spine.SkeletonJson.GetFloat(map:  val_6, name:  "translateMix", defaultValue:  1f);
            if(val_6.Item["time"] == null)
            {
                    throw new NullReferenceException();
            }
            
            throw new NullReferenceException();
            label_528:
            if((System.String.op_Equality(a:  val_6, b:  "spacing")) != false)
            {
                    if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_289 = mem[val_6 + 24];
                val_289 = val_6 + 24;
                Spine.PathConstraintSpacingTimeline val_164 = null;
                val_320 = val_164;
                val_164 = new Spine.PathConstraintSpacingTimeline(frameCount:  val_289);
                if(val_285 == 0)
            {
                    throw new NullReferenceException();
            }
            
                var val_165 = (((skeletonData + 88 + 16 + (val_151) << 3) + 32 + 52) < 2) ? 1 : 0;
            }
            else
            {
                    if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_289 = mem[val_6 + 24];
                val_289 = val_6 + 24;
                Spine.PathConstraintPositionTimeline val_166 = null;
                val_320 = val_166;
                val_166 = new Spine.PathConstraintPositionTimeline(frameCount:  val_289);
                if(val_285 == 0)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            float val_168 = (((((skeletonData + 88 + 16 + (val_151) << 3) + 32 + 48) == 0) ? 1 : 0) != 0) ? (val_283) : 1f;
            if(val_320 == null)
            {
                    throw new NullReferenceException();
            }
            
            .pathConstraintIndex = val_151;
            List.Enumerator<T> val_169 = val_290.GetEnumerator();
            val_289 = 0;
            if(val_5.MoveNext() != false)
            {
                    val_290 = val_6;
                if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
                float val_173 = Spine.SkeletonJson.GetFloat(map:  val_290, name:  val_6, defaultValue:  0f);
                if(val_290.Item["time"] == null)
            {
                    throw new NullReferenceException();
            }
            
                throw new NullReferenceException();
            }
            
            var val_302 = val_300;
            val_302 = val_302 + 1;
            val_289 = 0;
            mem2[0] = 2770;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            var val_303 = val_302;
            if(val_303 == 1)
            {
                goto label_556;
            }
            
            var val_174 = ((1725919104 + (((((((((val_307 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((val_307 + (0 ^ 0)) + 1)) << 2 == 0x6A7 ? 1 : 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((((val_307 + (0 ^ 0)) + 1) ) << 2) == 2770) ? 1 : 0;
            val_174 = ((val_303 >= 0) ? 1 : 0) & val_174;
            val_303 = val_303 - val_174;
            goto label_557;
            label_533:
            var val_304 = val_303;
            val_304 = val_304 + 1;
            val_289 = 0;
            mem2[0] = 2979;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            var val_305 = val_304;
            if(val_305 == 1)
            {
                goto label_559;
            }
            
            var val_176 = ((1725919104 + (((((((((((val_307 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((val_307 + (0 ^ 0)) + 1)) << 2 == 0x6A7 ? 1 : 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((((val_307 + (0 ^ 0)) + 1) << 2) == 2979) ? 1 : 0;
            val_176 = ((val_305 >= 0) ? 1 : 0) & val_176;
            val_305 = val_305 - val_176;
            goto label_560;
            label_556:
            label_557:
            if(val_284 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_166);
            val_289 = (Spine.PathConstraintPositionTimeline)[1152921510628204064].frames;
            if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_179 = val_166.FrameCount << 1;
            val_179 = val_179 - 2;
            if(val_179 >= (Spine.PathConstraintPositionTimeline)[1152921510628204064].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_180 = System.Math.Max(val1:  val_316, val2:  val_289[val_179]);
            goto label_572;
            label_559:
            label_560:
            if(val_284 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_157);
            val_289 = (Spine.PathConstraintMixTimeline)[1152921510628191776].frames;
            int val_181 = val_157.FrameCount;
            if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_182 = val_181 + (val_181 << 1);
            val_182 = val_182 - 3;
            if(val_182 >= (Spine.PathConstraintMixTimeline)[1152921510628191776].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_183 = System.Math.Max(val1:  val_316, val2:  val_289[val_182]);
            goto label_572;
            label_523:
            val_297 = 0;
            val_5.Dispose();
            if(val_297 != 0)
            {
                    throw val_297;
            }
            
            if((1 == 1) || (3041 != 3041))
            {
                goto label_600;
            }
            
            var val_308 = 0;
            val_308 = val_308 ^ 0;
            val_308 = 1 + val_308;
            goto label_600;
            label_514:
            val_300 = val_308 + 1;
            mem2[0] = 3069;
            val_5.Dispose();
            val_284 = val_284;
            val_310 = map;
            if(val_300 != 1)
            {
                    var val_184 = ((1725919104 + (((1 + (0 ^ 0)) + 1)) << 2) == 3069) ? 1 : 0;
                val_184 = ((val_300 >= 0) ? 1 : 0) & val_184;
                val_300 = val_300 - val_184;
            }
            
            label_656:
            val_319 = "deform";
            if((val_310.ContainsKey(key:  "deform")) == false)
            {
                goto label_811;
            }
            
            object val_187 = val_310.Item["deform"];
            if(val_187 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_324 = null;
            Dictionary.Enumerator<TKey, TValue> val_188 = val_187.GetEnumerator();
            label_796:
            if(val_5.MoveNext() == false)
            {
                goto label_661;
            }
            
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_304 = val_6;
            Spine.Skin val_190 = skeletonData.FindSkin(skinName:  val_6);
            if(val_304 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_191 = val_304.GetEnumerator();
            label_755:
            if(val_5.MoveNext() == false)
            {
                goto label_666;
            }
            
            val_285 = val_6;
            val_289 = val_6;
            int val_193 = skeletonData.FindSlotIndex(slotName:  val_285);
            val_290 = val_193;
            if(val_193 == 1)
            {
                goto label_667;
            }
            
            if(val_289 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_194 = val_289.GetEnumerator();
            label_720:
            if(val_5.MoveNext() == false)
            {
                goto label_671;
            }
            
            if(val_190 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_289 = val_6;
            Spine.Attachment val_196 = val_190.GetAttachment(slotIndex:  val_290, name:  val_6);
            if(val_196 == null)
            {
                goto label_679;
            }
            
            if(val_190 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Collections.Generic.Dictionary<AttachmentKeyTuple, Spine.Attachment> val_309 = val_190.attachments;
            val_309 = val_309 * 1431655766;
            val_309 = val_309 >> 32;
            val_309 = val_309 + (val_309 >> 63);
            val_290 = val_309 << 1;
            if(val_289 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_285 = mem[val_6 + 24];
            val_285 = val_6 + 24;
            Spine.DeformTimeline val_198 = new Spine.DeformTimeline(frameCount:  val_285);
            if(val_198 == null)
            {
                    throw new NullReferenceException();
            }
            
            .attachment = val_196;
            .slotIndex = val_290;
            val_285 = "vertices";
            List.Enumerator<T> val_199 = val_289.GetEnumerator();
            var val_200 = (((val_6 + 200 + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) != 0) ? 1 : 0;
            val_200 = val_200 | (( < 1) ? 1 : 0);
            val_307 = (long);
            Spine.Skin val_202 = val_190 + 32;
            if(val_5.MoveNext() != false)
            {
                    if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
                if((val_6.ContainsKey(key:  "vertices")) != false)
            {
                    float[] val_205 = new float[0];
                val_289 = val_205;
                int val_206 = Spine.SkeletonJson.GetInt(map:  val_6, name:  "offset", defaultValue:  0);
                System.Single[] val_207 = Spine.SkeletonJson.GetFloatArray(map:  val_6, name:  "vertices", scale:  1f);
                val_285 = val_207;
                if(val_207 == null)
            {
                    throw new NullReferenceException();
            }
            
                System.Array.Copy(sourceArray:  val_285, sourceIndex:  0, destinationArray:  val_205, destinationIndex:  val_206, length:  val_207.Length);
                if(val_283 != 1f)
            {
                    int val_208 = val_206 + val_207.Length;
                if(val_206 < val_208)
            {
                    if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_311 = (long)val_206;
                do
            {
                if(val_311 >= val_205.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
                float val_310 = val_289[((long)(int)(val_206)) << 2];
                val_311 = val_311 + 1;
                val_310 = val_283 * val_310;
                val_289[((long)(int)(val_206)) << 2] = val_310;
            }
            while(val_311 < (long)val_208);
            
            }
            
            }
            
                val_285 = "vertices";
                if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_312 = 0;
                do
            {
                if(val_312 >= val_205.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
                if(val_190 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_312 >= val_190.attachments)
            {
                    throw new IndexOutOfRangeException();
            }
            
                mem2[0] = null + null;
                val_312 = val_312 + 1;
            }
            while(val_312 < val_307);
            
            }
            else
            {
                    val_289 = val_190;
                val_289 = new float[0];
            }
            
                if(val_6.Item["time"] == null)
            {
                    throw new NullReferenceException();
            }
            
                throw new NullReferenceException();
            }
            
            var val_313 = val_300;
            val_313 = val_313 + 1;
            val_289 = 0;
            mem2[0] = 3664;
            val_307 = val_284;
            val_290 = val_290;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            if(val_313 != 1)
            {
                    var val_212 = ((1725919104 + (((((1 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((1 + (0 ^ 0)) + 1)) << 2 == 0xBFD ? 1 : 0)) + 1)) << 2) == 3664) ? 1 : 0;
                val_212 = ((val_313 >= 0) ? 1 : 0) & val_212;
                val_313 = val_313 - val_212;
            }
            
            if(val_307 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_198);
            val_289 = (Spine.DeformTimeline)[1152921510628306464].frames;
            if(val_289 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_215 = val_198.FrameCount - 1;
            if(val_215 >= (Spine.DeformTimeline)[1152921510628306464].frames.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            float val_216 = System.Math.Max(val1:  val_316, val2:  val_289[val_215]);
            goto label_720;
            label_671:
            val_285 = val_300 + 1;
            val_289 = 0;
            mem2[0] = 3724;
            val_5.Dispose();
            if(val_289 != 0)
            {
                    throw val_289;
            }
            
            if((val_285 == 1) || ((1725919104 + (((((1 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((1 + (0 ^ 0)) + 1)) << 2 == 0xBFD ? 1 : 0)) + 1)) << 2) != 3724))
            {
                goto label_755;
            }
            
            var val_315 = 0;
            val_315 = val_315 ^ (val_285 >> 31);
            var val_217 = val_285 + val_315;
            goto label_755;
            label_679:
            val_289 = "Deform attachment not found: "("Deform attachment not found: ") + val_6;
            System.Exception val_219 = null;
            val_285 = val_219;
            val_219 = new System.Exception(message:  val_289);
            throw val_285;
            label_666:
            var val_220 = val_300 + 1;
            val_319 = 0;
            mem2[0] = 3752;
            val_325 = 1152921510193072160;
            val_5.Dispose();
            if(val_319 != 0)
            {
                    throw val_319 = "Event not found: "("Event not found: ") + val_336.Item["name"];
            }
            
            if((val_220 == 1) || ((1725919104 + (((((1 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((1 + (0 ^ 0)) + 1)) << 2 == 0xBFD ? 1 : 0)) + 1)) << 2) != 3752))
            {
                goto label_796;
            }
            
            var val_316 = 0;
            val_316 = val_316 ^ (val_220 >> 31);
            var val_221 = val_220 + val_316;
            goto label_796;
            label_667:
            val_289 = "Slot not found: "("Slot not found: ") + val_285;
            System.Exception val_223 = null;
            val_285 = val_223;
            val_223 = new System.Exception(message:  val_289);
            throw val_285;
            label_661:
            val_300 = val_300 + 1;
            mem2[0] = 3780;
            val_5.Dispose();
            val_328 = map;
            if(val_300 != 1)
            {
                    var val_224 = ((1725919104 + (((((1 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((1 + (0 ^ 0)) + 1)) << 2 == 0xBFD ? 1 : 0)) + 1)) << 2) == 3780) ? 1 : 0;
                val_224 = ((val_300 >= 0) ? 1 : 0) & val_224;
                val_300 = val_300 - val_224;
            }
            
            label_811:
            val_319 = "drawOrder";
            if((val_328.ContainsKey(key:  "drawOrder")) != true)
            {
                    if((val_328.ContainsKey(key:  "draworder")) == false)
            {
                goto label_813;
            }
            
            }
            
            object val_230 = val_328.Item[((val_328.ContainsKey(key:  "drawOrder")) != true) ? (val_319) : "draworder"];
            if(val_230 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_304 = val_230;
            Spine.DrawOrderTimeline val_231 = new Spine.DrawOrderTimeline(frameCount:  val_328);
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((skeletonData + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_232 = val_304.GetEnumerator();
            val_307 = 1152921510211410768;
            val_285 = 1152921504685600768;
            val_311 = 1152921504622129152;
            val_283 = Infinityf;
            label_879:
            if(val_5.MoveNext() == false)
            {
                goto label_819;
            }
            
            val_290 = val_6;
            if(val_290 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_290.ContainsKey(key:  "offsets")) == false)
            {
                goto label_890;
            }
            
            int[] val_236 = new int[0];
            var val_317 = (long)(skeletonData + 32 + 24) - 1;
            if((((long)(skeletonData + 32 + 24) - 1) & 2147483648) == 0)
            {
                    do
            {
                if(val_236 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_317 >= val_236.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_317 = val_317 - 1;
                val_236[((long)(int)((skeletonData + 32 + 24 - 1))) << 2] = 0;
            }
            while((val_317 & 2147483648) == 0);
            
            }
            
            val_325 = "offsets";
            object val_237 = val_290.Item["offsets"];
            val_304 = val_237;
            if(val_237 == null)
            {
                    throw new NullReferenceException();
            }
            
            int[] val_239 = new int[0];
            List.Enumerator<T> val_240 = val_304.GetEnumerator();
            val_329 = 0;
            val_330 = 0;
            goto label_831;
            label_846:
            val_236[-1686256256] = val_330;
            val_330 = val_304;
            label_831:
            if(val_5.MoveNext() == false)
            {
                goto label_832;
            }
            
            val_289 = val_6;
            if(val_289 == 0)
            {
                    throw new NullReferenceException();
            }
            
            object val_242 = val_289.Item["slot"];
            if(val_242 != null)
            {
                    if(null != null)
            {
                    throw new IndexOutOfRangeException();
            }
            
            }
            
            int val_243 = skeletonData.FindSlotIndex(slotName:  val_242);
            if(val_243 == 1)
            {
                goto label_838;
            }
            
            if(val_330 != val_243)
            {
                    do
            {
                if(val_239 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_329 >= val_239.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
                var val_244 = val_329 + 1;
                val_239[0] = val_330;
            }
            while(val_243 != (val_330 + 1));
            
                val_331 = val_243;
            }
            
            if(val_289.Item["offset"] == null)
            {
                    throw new NullReferenceException();
            }
            
            val_289 = val_331 + 1;
            if(val_236 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_318 = (int)(null == val_283) ? (-(double)null) : ((double)null);
            val_318 = val_331 + val_318;
            if(val_318 < val_236.Length)
            {
                goto label_846;
            }
            
            throw new IndexOutOfRangeException();
            label_832:
            var val_319 = val_300;
            val_319 = val_319 + 1;
            val_304 = 0;
            mem2[0] = 4185;
            val_325 = 1152921510348445696;
            val_5.Dispose();
            if(val_304 != 0)
            {
                    throw val_319;
            }
            
            var val_320 = val_319;
            if((val_320 == 1) || ((1725919104 + (((((((1 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((1 + (0 ^ 0)) + 1)) << 2 == 0xBFD ? 1 : 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((((1 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? ) << 2) != 4185))
            {
                goto label_882;
            }
            
            val_320 = val_320 + (0 ^ (val_320 >> 31));
            goto label_852;
            label_838:
            System.Exception val_251 = null;
            val_289 = val_251;
            val_251 = new System.Exception(message:  "Slot not found: "("Slot not found: ") + val_289.Item["slot"]);
            throw val_289;
            label_890:
            if(val_231 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_290.Item["time"] == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_253 = 0 + 1;
            val_231.SetFrame(frameIndex:  0, time:  3.230314E-38f, drawOrder:  0);
            goto label_879;
            label_882:
            if(val_239 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_329 >= val_239.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_329 = val_329 + 1;
            val_239[0] = val_330;
            val_333 = val_330 + 1;
            label_852:
            if(val_333 < (skeletonData + 32 + 24))
            {
                goto label_882;
            }
            
            var val_324 = (long)(skeletonData + 32 + 24) - 1;
            if((((long)(skeletonData + 32 + 24) - 1) & 2147483648) != 0)
            {
                goto label_890;
            }
            
            do
            {
                if(val_236 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_324 >= val_236.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
                if((val_236[((long)(int)((skeletonData + 32 + 24 - 1))) << 2]) == 1)
            {
                    if(val_239 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_329 = val_329 - 1;
                if(val_329 >= val_239.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
                val_236[((long)(int)((skeletonData + 32 + 24 - 1))) << 2] = val_239[val_329 << 2];
            }
            
                val_324 = val_324 - 1;
            }
            while((val_324 & 2147483648) == 0);
            
            goto label_890;
            label_819:
            val_300 = val_300 + 1;
            mem2[0] = 4294;
            val_5.Dispose();
            val_334 = val_284;
            val_303 = 1152921510222861648;
            if(val_300 != 1)
            {
                    var val_255 = ((1725919104 + (((((((1 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((1 + (0 ^ 0)) + 1)) << 2 == 0xBFD ? 1 : 0)) + 1) - (val_300 >= 0x0 ? 1 : 0 & 1725919104 + (((((1 + (0 ^ 0)) + 1) - (val_300 >= 0x0 ? ) << 2) == 4294) ? 1 : 0;
                val_255 = ((val_300 >= 0) ? 1 : 0) & val_255;
                val_300 = val_300 - val_255;
            }
            
            if(val_334 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_231);
            if(val_231 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_319 = (Spine.DrawOrderTimeline)[1152921510628421152].frames;
            if(val_319 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_316 = System.Math.Max(val1:  val_316, val2:  val_319[val_231.FrameCount - 1]);
            label_813:
            val_319 = "events";
            if((map.ContainsKey(key:  "events")) == false)
            {
                goto label_898;
            }
            
            val_307 = 1152921510214912464;
            object val_261 = map.Item["events"];
            if(val_261 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_319 = val_261;
            Spine.EventTimeline val_262 = new Spine.EventTimeline(frameCount:  map);
            List.Enumerator<T> val_263 = val_319.GetEnumerator();
            val_285 = "string";
            label_914:
            if(val_5.MoveNext() == false)
            {
                goto label_902;
            }
            
            val_335 = val_6;
            if(val_335 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_325 = val_335.Item["name"];
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_325 != null)
            {
                    if(null != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            Spine.EventData val_266 = skeletonData.FindEvent(eventDataName:  val_325);
            if(val_266 == null)
            {
                goto label_909;
            }
            
            val_325 = 1152921504863928320;
            val_290 = val_335.Item["time"];
            if(val_290 == null)
            {
                    throw new NullReferenceException();
            }
            
            new Spine.Event() = new Spine.Event(time:  3.230314E-38f, data:  val_266);
            if(new Spine.Event() == null)
            {
                    throw new NullReferenceException();
            }
            
            .intValue = Spine.SkeletonJson.GetInt(map:  val_335, name:  "int", defaultValue:  val_266.<Int>k__BackingField);
            .floatValue = Spine.SkeletonJson.GetFloat(map:  val_335, name:  "float", defaultValue:  val_266.<Float>k__BackingField);
            .stringValue = Spine.SkeletonJson.GetString(map:  val_335, name:  "string", defaultValue:  val_266.<String>k__BackingField);
            if(val_262 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_272 = 0 + 1;
            val_262.SetFrame(frameIndex:  0, e:  new Spine.Event());
            goto label_914;
            label_898:
            if(val_334 != 0)
            {
                goto label_915;
            }
            
            throw new NullReferenceException();
            label_902:
            var val_326 = val_300;
            val_326 = val_326 + 1;
            mem2[0] = 4605;
            val_5.Dispose();
            if(val_284 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_262);
            if(val_262 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_319 = (Spine.EventTimeline)[1152921510628503072].frames;
            if(val_319 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_915:
            val_1.TrimExcess();
            if(skeletonData == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_319 = mem[skeletonData + 64];
            val_319 = skeletonData + 64;
            if(val_319 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_319.Add(item:  new Spine.Animation(name:  name, timelines:  val_1, duration:  System.Math.Max(val1:  val_316, val2:  val_319[val_262.FrameCount - 1])));
            return;
            label_516:
            throw new System.Exception(message:  val_297);
            label_244:
            val_336 = "Bone not found: "("Bone not found: ") + 0;
            throw new System.Exception(message:  val_336);
            label_909:
            val_325 = 1152921510627078320;
            throw new System.Exception(message:  val_319);
        }
        private static void ReadCurve(System.Collections.Generic.Dictionary<string, object> valueMap, Spine.CurveTimeline timeline, int frameIndex)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = valueMap;
            if((val_5.ContainsKey(key:  "curve")) == false)
            {
                    return;
            }
            
            object val_2 = val_5.Item["curve"];
            val_5 = val_2;
            if((val_2 & 1) != 0)
            {
                    timeline.SetStepped(frameIndex:  frameIndex);
                return;
            }
            
            var val_3 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_5) : 0;
        }
        private static float[] GetFloatArray(System.Collections.Generic.Dictionary<string, object> map, string name, float scale)
        {
            var val_3;
            var val_5;
            var val_6;
            var val_7;
            object val_1 = map.Item[name];
            float[] val_2 = new float[80883712];
            if(scale != 1f)
            {
                goto label_5;
            }
            
            if(41934848 < 1)
            {
                    return (System.Single[])val_2;
            }
            
            val_3 = 0;
            val_5 = 41934848;
            goto label_7;
            label_13:
            val_3 = 1;
            label_7:
            if(val_5 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            mem2[0] = 6830404;
            if((val_3 + 1) < 41934848)
            {
                goto label_13;
            }
            
            return (System.Single[])val_2;
            label_5:
            if(41934848 < 1)
            {
                    return (System.Single[])val_2;
            }
            
            val_6 = 0;
            val_7 = 41934848;
            goto label_16;
            label_22:
            val_6 = 1;
            label_16:
            if(val_7 <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            float val_5 = 9.571435E-39f;
            val_5 = val_5 * scale;
            mem2[0] = val_5;
            if((val_6 + 1) < 41934848)
            {
                goto label_22;
            }
            
            return (System.Single[])val_2;
        }
        private static int[] GetIntArray(System.Collections.Generic.Dictionary<string, object> map, string name)
        {
            var val_4;
            var val_5;
            object val_1 = map.Item[name];
            int[] val_2 = new int[80883712];
            if(41934848 < 1)
            {
                    return (System.Int32[])val_2;
            }
            
            val_4 = 0;
            val_5 = 41934848;
            goto label_6;
            label_12:
            val_4 = 1;
            label_6:
            if(val_5 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            mem2[0] = (int)((9.571435E-39f) == Infinityf) ? (-((double)9.571435E-39f)) : ((double)9.571435E-39f);
            if((val_4 + 1) < 41934848)
            {
                goto label_12;
            }
            
            return (System.Int32[])val_2;
        }
        private static float GetFloat(System.Collections.Generic.Dictionary<string, object> map, string name, float defaultValue)
        {
            float val_3 = defaultValue;
            if((map.ContainsKey(key:  name)) == false)
            {
                    return 3.230314E-38f;
            }
            
            object val_2 = map.Item[name];
            return 3.230314E-38f;
        }
        private static int GetInt(System.Collections.Generic.Dictionary<string, object> map, string name, int defaultValue)
        {
            if((map.ContainsKey(key:  name)) == false)
            {
                    return defaultValue;
            }
            
            object val_2 = map.Item[name];
            defaultValue = (int)(null == Infinityf) ? (-(double)null) : ((double)null);
            return defaultValue;
        }
        private static bool GetBoolean(System.Collections.Generic.Dictionary<string, object> map, string name, bool defaultValue)
        {
            bool val_5 = defaultValue;
            if((map.ContainsKey(key:  name)) == false)
            {
                    return (bool)((null != 0) ? 1 : 0) & 1;
            }
            
            object val_2 = map.Item[name];
            return (bool)((null != 0) ? 1 : 0) & 1;
        }
        private static string GetString(System.Collections.Generic.Dictionary<string, object> map, string name, string defaultValue)
        {
            if((map.ContainsKey(key:  name)) == false)
            {
                    return (string)defaultValue;
            }
            
            object val_2 = map.Item[name];
            defaultValue = val_2;
            if(val_2 == null)
            {
                    return (string)defaultValue;
            }
            
            if(null == null)
            {
                    return (string)defaultValue;
            }
        
        }
        private static float ToColor(string hexString, int colorIndex, int expectedLength = 8)
        {
            if(hexString.m_stringLength != expectedLength)
            {
                    throw new System.ArgumentException(message:  +new object[4], paramName:  "hexString");
            }
            
            colorIndex = colorIndex << 1;
            float val_6 = 255f;
            val_6 = ((float)System.Convert.ToInt32(value:  hexString.Substring(startIndex:  colorIndex, length:  2), fromBase:  16)) / val_6;
            return (float)val_6;
        }
    
    }

}
