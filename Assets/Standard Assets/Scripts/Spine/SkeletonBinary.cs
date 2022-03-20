using UnityEngine;

namespace Spine
{
    public class SkeletonBinary
    {
        // Fields
        public const int BONE_ROTATE = 0;
        public const int BONE_TRANSLATE = 1;
        public const int BONE_SCALE = 2;
        public const int BONE_SHEAR = 3;
        public const int SLOT_ATTACHMENT = 0;
        public const int SLOT_COLOR = 1;
        public const int SLOT_TWO_COLOR = 2;
        public const int PATH_POSITION = 0;
        public const int PATH_SPACING = 1;
        public const int PATH_MIX = 2;
        public const int CURVE_LINEAR = 0;
        public const int CURVE_STEPPED = 1;
        public const int CURVE_BEZIER = 2;
        private float <Scale>k__BackingField;
        private Spine.AttachmentLoader attachmentLoader;
        private byte[] buffer;
        private System.Collections.Generic.List<Spine.SkeletonJson.LinkedMesh> linkedMeshes;
        public static readonly Spine.TransformMode[] TransformModeValues;
        
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
        public SkeletonBinary(Spine.Atlas[] atlasArray)
        {
            Spine.AtlasAttachmentLoader val_1 = new Spine.AtlasAttachmentLoader(atlasArray:  atlasArray);
        }
        public SkeletonBinary(Spine.AttachmentLoader attachmentLoader)
        {
            this.buffer = new byte[32];
            this.linkedMeshes = new System.Collections.Generic.List<LinkedMesh>();
            if(attachmentLoader == null)
            {
                    throw new System.ArgumentNullException(paramName:  "attachmentLoader");
            }
            
            this.attachmentLoader = attachmentLoader;
            this.<Scale>k__BackingField = 1f;
        }
        public Spine.SkeletonData ReadSkeletonData(string path)
        {
            System.IO.FileStream val_1 = new System.IO.FileStream(path:  path, mode:  3, access:  1, share:  1);
            val_2.name = System.IO.Path.GetFileNameWithoutExtension(path:  path);
            if(val_1 != null)
            {
                    var val_5 = 0;
                val_5 = val_5 + 1;
                val_1.Dispose();
            }
            
            if(0 != 0)
            {
                    throw 0;
            }
            
            return (Spine.SkeletonData)this.ReadSkeletonData(input:  val_1);
        }
        public static string GetVersionString(System.IO.Stream input)
        {
            if(input == null)
            {
                    throw new System.ArgumentNullException(paramName:  "input");
            }
            
            int val_1 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_1 >= 2)
            {
                    System.IO.Stream val_3 = input + ((val_1 - 1) << );
            }
            
            int val_4 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_4 < 2)
            {
                    throw new System.ArgumentException(message:  "Stream does not contain a valid binary Skeleton Data.", paramName:  "input");
            }
            
            Spine.SkeletonBinary.ReadFully(input:  input, buffer:  new byte[0], offset:  0, length:  val_4 - 1);
            return (string)System.Text.Encoding.UTF8;
        }
        public Spine.SkeletonData ReadSkeletonData(System.IO.Stream input)
        {
            float val_114;
            var val_115;
            System.Collections.Generic.List<LinkedMesh> val_116;
            var val_117;
            var val_118;
            Spine.Skin val_119;
            string val_120;
            string val_121;
            if(input == null)
            {
                    throw new System.ArgumentNullException(paramName:  "input");
            }
            
            Spine.SkeletonData val_1 = new Spine.SkeletonData();
            .hash = this.ReadString(input:  input);
            if(val_2.m_stringLength == 0)
            {
                    .hash = 0;
            }
            
            .version = this.ReadString(input:  input);
            if(val_3.m_stringLength == 0)
            {
                    .version = 0;
            }
            
            .width = this.ReadFloat(input:  input);
            .height = this.ReadFloat(input:  input);
            if(input != null)
            {
                    .fps = this.ReadFloat(input:  input);
                .imagesPath = this.ReadString(input:  input);
                if(val_7.m_stringLength == 0)
            {
                    .imagesPath = 0;
            }
            
            }
            
            int val_8 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_8 >= 1)
            {
                    do
            {
                if(0 != 0)
            {
                    var val_11 = X25 + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
            }
            
                Spine.BoneData val_12 = new Spine.BoneData(index:  0, name:  this.ReadString(input:  input), parent:  0);
                .rotation = this.ReadFloat(input:  input);
                float val_14 = this.ReadFloat(input:  input);
                val_14 = (this.<Scale>k__BackingField) * val_14;
                .x = val_14;
                float val_15 = this.ReadFloat(input:  input);
                val_15 = (this.<Scale>k__BackingField) * val_15;
                .y = val_15;
                .scaleX = this.ReadFloat(input:  input);
                .scaleY = this.ReadFloat(input:  input);
                .shearX = this.ReadFloat(input:  input);
                .shearY = this.ReadFloat(input:  input);
                val_114 = (this.<Scale>k__BackingField) * (this.ReadFloat(input:  input));
                .length = val_114;
                Spine.TransformMode[] val_22 = Spine.SkeletonBinary.TransformModeValues + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 2);
                .transformMode = (Spine.SkeletonBinary.TransformModeValues + (val_21) << 2) + 32;
                if(input != 0)
            {
                    int val_23 = Spine.SkeletonBinary.ReadInt(input:  input);
            }
            
                (Spine.SkeletonData)[1152921510607709792].bones.Add(item:  val_12);
            }
            while(1 < val_8);
            
            }
            
            int val_24 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_24 >= 1)
            {
                    do
            {
                Spine.BoneData val_27 = val_12 + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
                int val_29 = Spine.SkeletonBinary.ReadInt(input:  input);
                float val_114 = (float)val_29 >> 24;
                float val_115 = (float)val_29 & 255;
                val_114 = val_114 / 255f;
                val_115 = val_115 / 255f;
                val_114 = 34359738368 / V11.2S;
                .r = val_114;
                .g = val_114;
                .a = val_115;
                int val_32 = Spine.SkeletonBinary.ReadInt(input:  input);
                if(val_32 != 1)
            {
                    val_114 = val_114 & 1095216660735;
                float val_116 = (float)val_32 & 255;
                val_116 = val_116 / 255f;
                val_114 = (double)val_114 / V11.2S;
                .hasSecondColor = true;
                .r2 = val_114;
                .b2 = val_116;
            }
            
                .attachmentName = this.ReadString(input:  input);
                .blendMode = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                (Spine.SkeletonData)[1152921510607709792].slots.Add(item:  new Spine.SlotData(index:  0, name:  this.ReadString(input:  input), boneData:  (val_12 + (val_26) << 3).parent));
            }
            while(1 < val_24);
            
            }
            
            int val_36 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_36 >= 1)
            {
                    var val_117 = 0;
                do
            {
                .order = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                int val_40 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                if(val_40 >= 1)
            {
                    do
            {
                var val_42 = true + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
                (Spine.IkConstraintData)[1152921510607775328].bones.Add(item:  (true + (val_41) << 3) + 32);
            }
            while(1 < val_40);
            
            }
            
                var val_44 = 1 + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
                .target = (1 + (val_43) << 3) + 32;
                .mix = this.ReadFloat(input:  input);
                .bendDirection = (int)(Spine.SkeletonBinary.ReadSByte(input:  input)) & 255;
                (Spine.SkeletonData)[1152921510607709792].ikConstraints.Add(item:  new Spine.IkConstraintData(name:  this.ReadString(input:  input)));
                val_117 = val_117 + 1;
            }
            while(val_117 < val_36);
            
            }
            
            int val_47 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_47 >= 1)
            {
                    var val_119 = 0;
                do
            {
                .order = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                int val_51 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                if(val_51 >= 1)
            {
                    var val_118 = 0;
                do
            {
                var val_53 = true + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
                (Spine.TransformConstraintData)[1152921510607799904].bones.Add(item:  (true + (val_52) << 3) + 32);
                val_118 = val_118 + 1;
            }
            while(val_118 < val_51);
            
            }
            
                var val_55 = val_118 + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
                .target = ((0 + 1) + (val_54) << 3) + 32;
                .local = (input != 0) ? 1 : 0;
                .relative = (input != 0) ? 1 : 0;
                .offsetRotation = this.ReadFloat(input:  input);
                float val_59 = this.ReadFloat(input:  input);
                val_59 = (this.<Scale>k__BackingField) * val_59;
                .offsetX = val_59;
                val_114 = (this.<Scale>k__BackingField) * (this.ReadFloat(input:  input));
                .offsetY = val_114;
                .offsetScaleX = this.ReadFloat(input:  input);
                .offsetScaleY = this.ReadFloat(input:  input);
                .offsetShearY = this.ReadFloat(input:  input);
                .rotateMix = this.ReadFloat(input:  input);
                .translateMix = this.ReadFloat(input:  input);
                .scaleMix = this.ReadFloat(input:  input);
                .shearMix = this.ReadFloat(input:  input);
                (Spine.SkeletonData)[1152921510607709792].transformConstraints.Add(item:  new Spine.TransformConstraintData(name:  this.ReadString(input:  input)));
                val_119 = val_119 + 1;
            }
            while(val_119 < val_47);
            
            }
            
            int val_68 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_68 >= 1)
            {
                    var val_121 = 0;
                do
            {
                .order = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                int val_72 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                if(val_72 >= 1)
            {
                    var val_120 = 0;
                do
            {
                var val_74 = true + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
                (Spine.PathConstraintData)[1152921510607824480].bones.Add(item:  (true + (val_73) << 3) + 32);
                val_120 = val_120 + 1;
            }
            while(val_120 < val_72);
            
            }
            
                var val_76 = val_120 + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
                .target = ((0 + 1) + (val_75) << 3) + 32;
                object val_80 = System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle())).GetValue(index:  Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true));
                .positionMode = null;
                object val_84 = System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle())).GetValue(index:  Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true));
                .spacingMode = null;
                object val_88 = System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle())).GetValue(index:  Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true));
                .rotateMode = null;
                .offsetRotation = this.ReadFloat(input:  input);
                float val_90 = this.ReadFloat(input:  input);
                .position = val_90;
                if((Spine.PathConstraintData)[1152921510607824480].positionMode == 0)
            {
                    val_114 = (this.<Scale>k__BackingField) * val_90;
                .position = val_114;
            }
            
                float val_91 = this.ReadFloat(input:  input);
                .spacing = val_91;
                if((Spine.PathConstraintData)[1152921510607824480].spacingMode <= 1)
            {
                    val_114 = (this.<Scale>k__BackingField) * val_91;
                .spacing = val_114;
            }
            
                .rotateMix = this.ReadFloat(input:  input);
                .translateMix = this.ReadFloat(input:  input);
                (Spine.SkeletonData)[1152921510607709792].pathConstraints.Add(item:  new Spine.PathConstraintData(name:  this.ReadString(input:  input)));
                val_121 = val_121 + 1;
            }
            while(val_121 < val_68);
            
            }
            
            Spine.Skin val_95 = this.ReadSkin(input:  input, skeletonData:  val_1, skinName:  "default", nonessential:  (input != 0) ? 1 : 0);
            if(val_95 != null)
            {
                    .defaultSkin = val_95;
                (Spine.SkeletonData)[1152921510607709792].skins.Add(item:  val_95);
            }
            
            int val_96 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_96 >= 1)
            {
                    var val_122 = 0;
                do
            {
                System.IO.Stream val_123 = input;
                bool val_97 = (val_123 != 0) ? 1 : 0;
                (Spine.SkeletonData)[1152921510607709792].skins.Add(item:  this.ReadSkin(input:  input, skeletonData:  val_1, skinName:  this.ReadString(input:  input), nonessential:  val_97));
                val_122 = val_122 + 1;
            }
            while(val_122 < val_96);
            
            }
            
            val_116 = this.linkedMeshes;
            var val_124 = 0;
            val_118 = 0;
            label_144:
            if(val_124 >= val_97)
            {
                goto label_132;
            }
            
            if(val_123 <= val_124)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_123 = val_123 + 0;
            val_115 = mem[(input + 0) + 32];
            val_115 = (input + 0) + 32;
            if(((input + 0) + 32 + 24) != 0)
            {
                    val_119 = val_1.FindSkin(skinName:  (input + 0) + 32 + 24);
            }
            else
            {
                    val_119 = (Spine.SkeletonData)[1152921510607709792].defaultSkin;
            }
            
            if(val_119 == null)
            {
                goto label_137;
            }
            
            Spine.Attachment val_102 = (val_119 == 0) ? (val_118) : (val_119).GetAttachment(slotIndex:  (input + 0) + 32 + 32, name:  (input + 0) + 32 + 16);
            if(val_102 == null)
            {
                goto label_139;
            }
            
            (input + 0) + 32 + 40.ParentMesh = val_102;
            (input + 0) + 32 + 40.UpdateUVs();
            val_124 = val_124 + 1;
            if(this.linkedMeshes != null)
            {
                goto label_144;
            }
            
            label_132:
            val_116.Clear();
            int val_103 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_103 >= 1)
            {
                    val_118 = 1152921510607578912;
                do
            {
                Spine.EventData val_105 = null;
                val_116 = val_105;
                val_105 = new Spine.EventData(name:  this.ReadString(input:  input));
                .<Int>k__BackingField = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  false);
                .<Float>k__BackingField = this.ReadFloat(input:  input);
                .<String>k__BackingField = this.ReadString(input:  input);
                (Spine.SkeletonData)[1152921510607709792].events.Add(item:  val_105);
                val_117 = 0 + 1;
            }
            while(val_117 < val_103);
            
            }
            
            int val_109 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_109 >= 1)
            {
                    var val_125 = val_109;
                do
            {
                this.ReadAnimation(name:  this.ReadString(input:  input), input:  input, skeletonData:  val_1);
                val_125 = val_125 - 1;
            }
            while(val_109 != 1);
            
            }
            
            (Spine.SkeletonData)[1152921510607709792].bones.TrimExcess();
            (Spine.SkeletonData)[1152921510607709792].slots.TrimExcess();
            (Spine.SkeletonData)[1152921510607709792].skins.TrimExcess();
            (Spine.SkeletonData)[1152921510607709792].events.TrimExcess();
            (Spine.SkeletonData)[1152921510607709792].animations.TrimExcess();
            (Spine.SkeletonData)[1152921510607709792].ikConstraints.TrimExcess();
            (Spine.SkeletonData)[1152921510607709792].pathConstraints.TrimExcess();
            return val_1;
            label_137:
            val_120 = mem[??? + 24];
            val_120 = ??? + 24;
            val_121 = "Skin not found: ";
            throw new System.Exception(message:  val_121 + val_120);
            label_139:
            val_120 = mem[(input + 0) + 32 + 16];
            val_120 = (input + 0) + 32 + 16;
            val_121 = "Parent mesh not found: ";
            throw new System.Exception(message:  val_121 + val_120);
        }
        private Spine.Skin ReadSkin(System.IO.Stream input, Spine.SkeletonData skeletonData, string skinName, bool nonessential)
        {
            string val_8;
            int val_9;
            Spine.Skin val_10;
            val_8 = skinName;
            int val_1 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_1 != 0)
            {
                    val_9 = val_1;
                Spine.Skin val_2 = null;
                val_10 = val_2;
                val_2 = new Spine.Skin(name:  val_8);
                if(val_9 < 1)
            {
                    return (Spine.Skin)val_10;
            }
            
                var val_9 = 0;
                do
            {
                val_8 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                int val_5 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                if(val_5 >= 1)
            {
                    var val_8 = 0;
                do
            {
                string val_6 = this.ReadString(input:  input);
                Spine.Attachment val_7 = this.ReadAttachment(input:  input, skeletonData:  skeletonData, skin:  val_2, slotIndex:  val_8, attachmentName:  val_6, nonessential:  nonessential);
                if(val_7 != null)
            {
                    val_2.AddAttachment(slotIndex:  val_8, name:  val_6, attachment:  val_7);
            }
            
                val_8 = val_8 + 1;
            }
            while(val_8 < val_5);
            
            }
            
                val_9 = val_9;
                val_9 = val_9 + 1;
            }
            while(val_9 < val_9);
            
                return (Spine.Skin)val_10;
            }
            
            val_10 = 0;
            return (Spine.Skin)val_10;
        }
        private Spine.Attachment ReadAttachment(System.IO.Stream input, Spine.SkeletonData skeletonData, Spine.Skin skin, int slotIndex, string attachmentName, bool nonessential)
        {
            string val_78;
            var val_79;
            System.IO.Stream val_80;
            Spine.AttachmentLoader val_81;
            var val_86;
            Spine.MeshAttachment val_87;
            var val_93;
            System.Int32[] val_94;
            val_78 = skin;
            val_79 = skeletonData;
            val_80 = input;
            val_81 = this;
            string val_1 = this.ReadString(input:  val_80);
            string val_2 = (val_1 == null) ? attachmentName : (val_1);
            if(val_80 > 6)
            {
                goto label_2;
            }
            
            var val_83 = 30113256 + (input) << 2;
            val_83 = val_83 + 30113256;
            goto (30113256 + (input) << 2 + 30113256);
            label_26:
            if(((val_3 == null ? val_1 == null ? attachmentName : val_1 : val_3 + 24 + 176 + 8) + -8) == null)
            {
                goto label_25;
            }
            
             =  + 1;
             =  + 16;
            if( < (val_3 == null ? val_1 == null ? attachmentName : val_1 : val_3 + 24 + 294))
            {
                goto label_26;
            }
            
            goto label_27;
            label_2:
            val_87 = 0;
            return (Spine.Attachment)val_87;
            label_68:
            if(((val_3 == null ? val_1 == null ? attachmentName : val_1 : val_3 + 24 + 176 + 8) + -8) == null)
            {
                goto label_67;
            }
            
             =  + 1;
             =  + 16;
            if( < (val_3 == null ? val_1 == null ? attachmentName : val_1 : val_3 + 24 + 294))
            {
                goto label_68;
            }
            
            goto label_69;
            label_67:
            var val_98 = ;
            val_98 = val_98 + 1;
             =  + val_98;
            val_93 =  + 304;
            label_69:
            Spine.MeshAttachment val_73 = NewMeshAttachment(skin:  val_78, name:  val_2, path:  null);
            val_87 = val_73;
            if(val_73 == null)
            {
                    return (Spine.Attachment)val_87;
            }
            
            float val_100 = (float) >> 24;
            float val_101 = 255f;
            val_100 = val_100 / val_101;
            val_101 = ((float) & 255) / val_101;
            val_73.r = val_100;
            val_100 = val_100 & (3.573311E-43f);
            double val_102 = (double)val_100;
            val_102 = val_102 / (3.573311E-43f);
            val_73.<Path>k__BackingField = ;
            val_73.g = val_102;
            val_73.a = val_101;
            mem2[0] = val_19.bones;
            mem2[0] = ;
            mem2[0] = val_19.vertices;
            val_73.regionUVs = ;
            val_73.triangles = ;
            val_87.UpdateUVs();
            val_73.hulllength =  << 1;
            if(( & 1) == 0)
            {
                    return (Spine.Attachment)val_87;
            }
            
            val_73.<Width>k__BackingField = (this.<Scale>k__BackingField) * ;
            val_73.<Height>k__BackingField = (this.<Scale>k__BackingField) * ;
            val_73.<Edges>k__BackingField = 0;
            return (Spine.Attachment)val_87;
            label_25:
            var val_103 = ;
            val_103 = val_103 + 3;
             =  + val_103;
            val_86 =  + 304;
            label_27:
            Spine.PathAttachment val_79 = NewPathAttachment(skin:  null, name:  val_2);
            val_87 = val_79;
            if(val_79 == null)
            {
                    return (Spine.Attachment)val_87;
            }
            
            val_79.constantSpeed = (0 != 0) ? 1 : 0;
            val_79.closed = ( != null) ? 1 : 0;
            mem2[0] =  << 1;
            mem2[0] = val_25.vertices;
            val_94 = val_25.bones;
            val_79.lengths = ;
            mem2[0] = val_94;
            return (Spine.Attachment)val_87;
        }
        private Spine.SkeletonBinary.Vertices ReadVertices(System.IO.Stream input, int vertexCount)
        {
            SkeletonBinary.Vertices val_16;
            int val_17;
            SkeletonBinary.Vertices val_1 = null;
            val_16 = val_1;
            val_1 = new SkeletonBinary.Vertices();
            if(input != null)
            {
                    Spine.ExposedList<System.Single> val_5 = null;
                val_17 = (vertexCount + (vertexCount << 1)) << 1;
                val_5 = new Spine.ExposedList<System.Single>(capacity:  (vertexCount + (vertexCount << 3)) << 1);
                Spine.ExposedList<System.Int32> val_6 = new Spine.ExposedList<System.Int32>(capacity:  val_17);
                if(vertexCount >= 1)
            {
                    var val_16 = 0;
                do
            {
                val_17 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                val_6.Add(item:  val_17);
                if(val_17 >= 1)
            {
                    var val_15 = 0;
                do
            {
                val_6.Add(item:  Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true));
                float val_9 = this.ReadFloat(input:  input);
                val_9 = (this.<Scale>k__BackingField) * val_9;
                val_5.Add(item:  val_9);
                float val_10 = this.ReadFloat(input:  input);
                val_10 = (this.<Scale>k__BackingField) * val_10;
                val_5.Add(item:  val_10);
                val_5.Add(item:  this.ReadFloat(input:  input));
                val_15 = val_15 + 1;
            }
            while(val_15 < val_17);
            
            }
            
                val_16 = val_16 + 1;
            }
            while(val_16 < vertexCount);
            
            }
            
                val_16 = val_16;
                mem[1152921510609504216] = val_5.ToArray();
                mem[1152921510609504208] = val_6.ToArray();
                return (Vertices)val_16;
            }
            
            vertexCount = vertexCount << 1;
            .vertices = this.ReadFloatArray(input:  input, n:  vertexCount, scale:  this.<Scale>k__BackingField);
            return (Vertices)val_16;
        }
        private float[] ReadFloatArray(System.IO.Stream input, int n, float scale)
        {
            var val_4;
            float[] val_1 = new float[0];
            if(scale == 1f)
            {
                    if(n < 1)
            {
                    return (System.Single[])val_1;
            }
            
                do
            {
                mem2[0] = this.ReadFloat(input:  input);
                val_4 = 0 + 1;
            }
            while(val_4 < (long)n);
            
                return (System.Single[])val_1;
            }
            
            if(n < 1)
            {
                    return (System.Single[])val_1;
            }
            
            do
            {
                float val_3 = this.ReadFloat(input:  input);
                val_3 = val_3 * scale;
                mem2[0] = val_3;
                val_4 = 0 + 1;
            }
            while(val_4 < (long)n);
            
            return (System.Single[])val_1;
        }
        private int[] ReadShortArray(System.IO.Stream input)
        {
            int val_4 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            int[] val_2 = new int[0];
            if(val_4 < 1)
            {
                    return (System.Int32[])val_2;
            }
            
            var val_4 = 0;
            do
            {
                val_4 = input;
                mem2[0] = input | (val_4 << 8);
                val_4 = val_4 + 1;
            }
            while(val_4 < (long)val_4);
            
            return (System.Int32[])val_2;
        }
        private void ReadAnimation(string name, System.IO.Stream input, Spine.SkeletonData skeletonData)
        {
            var val_158;
            float val_159;
            int val_160;
            float val_161;
            float val_162;
            float val_163;
            var val_166;
            System.IO.Stream val_169;
            var val_170;
            System.Single[] val_173;
            int val_174;
            var val_175;
            Spine.CurveTimeline val_176;
            var val_179;
            var val_180;
            var val_182;
            System.Single[] val_183;
            int val_185;
            var val_186;
            int val_187;
            var val_188;
            string val_189;
            Spine.ExposedList<T> val_190;
            Spine.SkeletonData val_191;
            val_158 = this;
            Spine.ExposedList<Spine.Timeline> val_1 = new Spine.ExposedList<Spine.Timeline>();
            int val_2 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            var val_3 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            if(val_2 < 1)
            {
                goto label_3;
            }
            
            val_159 = 0f;
            label_41:
            val_160 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            int val_5 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_5 < 1)
            {
                goto label_6;
            }
            
            label_40:
            int val_6 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(input == 2)
            {
                goto label_10;
            }
            
            if(input == 1)
            {
                goto label_11;
            }
            
            if(input != 0)
            {
                goto label_12;
            }
            
            Spine.AttachmentTimeline val_7 = new Spine.AttachmentTimeline(frameCount:  val_6);
            .slotIndex = val_160;
            if(input >= 1)
            {
                    do
            {
                val_7.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), attachmentName:  this.ReadString(input:  input));
            }
            while(val_6 != 1);
            
            }
            
            val_1.Add(item:  val_7);
            goto label_19;
            label_10:
            Spine.TwoColorTimeline val_11 = new Spine.TwoColorTimeline(frameCount:  val_6);
            .slotIndex = val_160;
            if(input >= 2)
            {
                    do
            {
                int val_14 = Spine.SkeletonBinary.ReadInt(input:  input);
                val_161 = ((float)val_14 >> 24) / 255f;
                val_162 = ((float)(uint)(val_14 >> 8) & 255) / 255f;
                int val_19 = Spine.SkeletonBinary.ReadInt(input:  input);
                val_11.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), r:  val_161, g:  ((float)(uint)(val_14 >> 16) & 255) / 255f, b:  val_162, a:  ((float)val_14 & 255) / 255f, r2:  ((float)(uint)(val_19 >> 16) & 255) / 255f, g2:  ((float)(uint)(val_19 >> 8) & 255) / 255f, b2:  ((float)val_19 & 255) / 255f);
                if(0 < (val_6 - 1))
            {
                    this.ReadCurve(input:  input, frameIndex:  0, timeline:  val_11);
            }
            
            }
            while(val_6 != 1);
            
            }
            
            val_1.Add(item:  val_11);
            int val_25 = val_11.FrameCount << 3;
            val_25 = val_25 - 8;
            goto label_28;
            label_11:
            Spine.ColorTimeline val_26 = new Spine.ColorTimeline(frameCount:  val_6);
            .slotIndex = val_160;
            if(input >= 1)
            {
                    do
            {
                int val_29 = Spine.SkeletonBinary.ReadInt(input:  input);
                float val_158 = (float)(uint)(val_29 >> 16) & 255;
                float val_159 = (float)(uint)(val_29 >> 8) & 255;
                float val_160 = (float)val_29 & 255;
                val_158 = val_158 / 255f;
                val_159 = val_159 / 255f;
                val_160 = val_160 / 255f;
                val_26.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), r:  ((float)val_29 >> 24) / 255f, g:  val_158, b:  val_159, a:  val_160);
                if(0 < (val_6 - 1))
            {
                    this.ReadCurve(input:  input, frameIndex:  0, timeline:  val_26);
            }
            
            }
            while(val_6 != 1);
            
            }
            
            val_1.Add(item:  val_26);
            int val_33 = val_26.FrameCount;
            int val_34 = val_33 + (val_33 << 2);
            val_34 = val_34 - 5;
            label_28:
            label_19:
            val_163 = val_159;
            val_159 = System.Math.Max(val1:  val_163, val2:  (Spine.ColorTimeline)[1152921510610622528].frames[val_34]);
            label_12:
            if(1 < val_5)
            {
                goto label_40;
            }
            
            label_6:
            var val_36 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            if(1 < val_2)
            {
                goto label_41;
            }
            
            goto label_45;
            label_3:
            val_159 = 0f;
            label_45:
            int val_37 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            var val_38 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            if(val_37 < 1)
            {
                goto label_46;
            }
            
            label_77:
            val_160 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            int val_40 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_40 < 1)
            {
                goto label_49;
            }
            
            label_76:
            int val_41 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(input == 0)
            {
                goto label_53;
            }
            
            if((input - 1) > 2)
            {
                goto label_54;
            }
            
            if(input == 3)
            {
                goto label_55;
            }
            
            if(input != 2)
            {
                goto label_56;
            }
            
            goto label_57;
            label_53:
            Spine.RotateTimeline val_43 = new Spine.RotateTimeline(frameCount:  val_41);
            .boneIndex = val_160;
            if(val_40 >= 1)
            {
                    do
            {
                val_43.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), degrees:  this.ReadFloat(input:  input));
                if(0 < (val_41 - 1))
            {
                    this.ReadCurve(input:  input, frameIndex:  0, timeline:  val_43);
            }
            
            }
            while(val_41 != 1);
            
            }
            
            val_1.Add(item:  val_43);
            int val_47 = val_41 << 1;
            val_47 = val_47 - 2;
            goto label_64;
            label_55:
            label_57:
            val_162 = 1f;
            if((new Spine.ShearTimeline(frameCount:  val_41)) != null)
            {
                goto label_65;
            }
            
            label_56:
            Spine.TranslateTimeline val_49 = new Spine.TranslateTimeline(frameCount:  val_41);
            val_162 = this.<Scale>k__BackingField;
            label_65:
            .boneIndex = val_160;
            if(input >= 2)
            {
                    do
            {
                val_161 = this.ReadFloat(input:  input);
                val_49.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), x:  val_162 * val_161, y:  val_162 * (this.ReadFloat(input:  input)));
                if(0 < (val_41 - 1))
            {
                    this.ReadCurve(input:  input, frameIndex:  0, timeline:  val_49);
            }
            
            }
            while(val_41 != 1);
            
            }
            
            val_1.Add(item:  val_49);
            int val_56 = val_41 + (val_41 << 1);
            val_56 = val_56 - 3;
            label_64:
            val_163 = val_159;
            val_159 = System.Math.Max(val1:  val_163, val2:  (Spine.TranslateTimeline)[1152921510610708544].frames[val_56]);
            label_54:
            if(1 < val_40)
            {
                goto label_76;
            }
            
            label_49:
            var val_58 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            if(1 < val_37)
            {
                goto label_77;
            }
            
            label_46:
            int val_59 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            var val_60 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            if(val_59 >= 1)
            {
                    val_160 = 1152921510609964416;
                do
            {
                int val_62 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                Spine.IkConstraintTimeline val_63 = new Spine.IkConstraintTimeline(frameCount:  val_62);
                .ikConstraintIndex = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                if(val_59 >= 1)
            {
                    do
            {
                val_161 = this.ReadFloat(input:  input);
                val_63.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), mix:  val_161, bendDirection:  (int)(Spine.SkeletonBinary.ReadSByte(input:  input)) & 255);
                if(0 < (val_62 - 1))
            {
                    this.ReadCurve(input:  input, frameIndex:  0, timeline:  val_63);
            }
            
            }
            while(val_62 != 1);
            
            }
            
                val_1.Add(item:  val_63);
                int val_68 = val_62 + (val_62 << 1);
                val_68 = val_68 - 3;
                val_163 = val_159;
                val_159 = System.Math.Max(val1:  val_163, val2:  (Spine.IkConstraintTimeline)[1152921510610749504].frames[val_68]);
                var val_70 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            }
            while(1 < val_59);
            
            }
            
            int val_71 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            val_166 = null;
            var val_72 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            if(val_71 >= 1)
            {
                    val_160 = 1152921510609964416;
                var val_165 = 0;
                do
            {
                int val_74 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                Spine.TransformConstraintTimeline val_75 = new Spine.TransformConstraintTimeline(frameCount:  val_74);
                .transformConstraintIndex = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                if(val_71 >= 1)
            {
                    do
            {
                val_161 = this.ReadFloat(input:  input);
                val_162 = this.ReadFloat(input:  input);
                val_75.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), rotateMix:  val_161, translateMix:  this.ReadFloat(input:  input), scaleMix:  val_162, shearMix:  this.ReadFloat(input:  input));
                if(0 < (val_74 - 1))
            {
                    this.ReadCurve(input:  input, frameIndex:  0, timeline:  val_75);
            }
            
            }
            while(val_74 != 1);
            
            }
            
                val_1.Add(item:  val_75);
                int val_82 = val_74 + (val_74 << 2);
                val_82 = val_82 - 5;
                val_163 = val_159;
                val_165 = val_165 + 1;
                val_159 = System.Math.Max(val1:  val_163, val2:  (Spine.TransformConstraintTimeline)[1152921510610790464].frames[val_82]);
                val_166 = null;
                var val_84 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            }
            while(val_165 < val_71);
            
            }
            
            val_169 = input;
            int val_85 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            val_170 = null;
            var val_86 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            if(val_85 < 1)
            {
                goto label_112;
            }
            
            label_145:
            var val_166 = skeletonData + 88 + 16;
            val_160 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            val_166 = val_166 + (val_160 << 3);
            int val_88 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            if(val_88 < 1)
            {
                goto label_119;
            }
            
            var val_170 = 0;
            label_144:
            sbyte val_90 = (Spine.SkeletonBinary.ReadSByte(input:  val_169)) & 255;
            int val_91 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            if(val_90 < 2)
            {
                goto label_122;
            }
            
            if(val_90 != 2)
            {
                goto label_123;
            }
            
            Spine.PathConstraintMixTimeline val_92 = new Spine.PathConstraintMixTimeline(frameCount:  val_91);
            val_169 = val_91 - 1;
            .pathConstraintIndex = val_160;
            if(val_90 >= 2)
            {
                    var val_167 = 0;
                do
            {
                val_161 = this.ReadFloat(input:  input);
                val_92.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), rotateMix:  val_161, translateMix:  this.ReadFloat(input:  input));
                if(val_167 < val_169)
            {
                    this.ReadCurve(input:  input, frameIndex:  0, timeline:  val_92);
            }
            
                val_167 = val_167 + 1;
            }
            while(val_91 != val_167);
            
            }
            
            val_1.Add(item:  val_92);
            val_173 = (Spine.PathConstraintMixTimeline)[1152921510610831424].frames;
            val_169 = input;
            val_174 = (Spine.PathConstraintMixTimeline)[1152921510610831424].frames.Length;
            val_175 = (val_91 + (val_91 << 1)) - 3;
            goto label_130;
            label_122:
            if(val_90 == 1)
            {
                    Spine.PathConstraintSpacingTimeline val_97 = null;
                val_176 = val_97;
                val_97 = new Spine.PathConstraintSpacingTimeline(frameCount:  val_91);
                var val_98 = (((skeletonData + 88 + 16 + (val_87) << 3) + 32 + 52) < 2) ? 1 : 0;
            }
            else
            {
                    Spine.PathConstraintPositionTimeline val_99 = null;
                val_176 = val_99;
                val_99 = new Spine.PathConstraintPositionTimeline(frameCount:  val_91);
                var val_100 = (((skeletonData + 88 + 16 + (val_87) << 3) + 32 + 48) == 0) ? 1 : 0;
            }
            
            val_169 = val_91 - 1;
            .pathConstraintIndex = val_160;
            if(val_100 >= 0)
            {
                    var val_168 = 0;
                do
            {
                val_99.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  input), value:  ((val_100 != 0) ? this.<Scale>k__BackingField : 1f) * (this.ReadFloat(input:  input)));
                if(val_168 < val_169)
            {
                    this.ReadCurve(input:  input, frameIndex:  0, timeline:  val_99);
            }
            
                val_168 = val_168 + 1;
            }
            while(val_91 != val_168);
            
            }
            
            val_1.Add(item:  val_99);
            val_173 = (Spine.PathConstraintPositionTimeline)[1152921510610876480].frames;
            val_169 = input;
            val_174 = (Spine.PathConstraintPositionTimeline)[1152921510610876480].frames.Length;
            val_175 = (val_91 << 1) - 2;
            label_130:
            val_163 = val_159;
            val_159 = System.Math.Max(val1:  val_163, val2:  val_173[val_175]);
            label_123:
            val_170 = val_170 + 1;
            if(val_170 < val_88)
            {
                goto label_144;
            }
            
            label_119:
            val_170 = null;
            var val_107 = ((Spine.SkeletonBinary.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
            if(1 < val_85)
            {
                goto label_145;
            }
            
            label_112:
            int val_108 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            if(val_108 < 1)
            {
                goto label_148;
            }
            
            val_161 = 1f;
            label_202:
            var val_110 = (skeletonData + 40 + 16) + ((Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true)) << 3);
            int val_111 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            if(val_111 < 1)
            {
                goto label_155;
            }
            
            val_180 = 0;
            label_201:
            int val_112 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            int val_113 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            if(val_113 < 1)
            {
                goto label_158;
            }
            
            label_200:
            int val_116 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            Spine.DeformTimeline val_117 = new Spine.DeformTimeline(frameCount:  val_116);
            int val_118 = val_116 - 1;
            .slotIndex = val_112;
            .attachment = (skeletonData + 40 + 16 + (val_109) << 3) + 32.GetAttachment(slotIndex:  val_112, name:  this.ReadString(input:  val_169));
            var val_173 = 0;
            int val_119 = val_160 + 32;
            label_194:
            int val_121 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            if(val_121 == 0)
            {
                goto label_172;
            }
            
            val_182 = val_121;
            float[] val_122 = new float[0];
            val_183 = val_122;
            int val_123 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            int val_124 = val_123 + val_182;
            if((this.<Scale>k__BackingField) != val_161)
            {
                goto label_175;
            }
            
            if(val_123 >= val_124)
            {
                goto label_183;
            }
            
            do
            {
                val_182 = (long)val_123 + 1;
                val_183[((long)(int)(val_123)) << 2] = this.ReadFloat(input:  input);
            }
            while(val_182 < (long)val_124);
            
            goto label_183;
            label_172:
            val_169 = input;
            val_183 = val_160;
            val_183 = new float[0];
            goto label_189;
            label_175:
            if(val_123 < val_124)
            {
                    do
            {
                float val_127 = this.ReadFloat(input:  input);
                val_182 = (long)val_123 + 1;
                val_127 = (this.<Scale>k__BackingField) * val_127;
                val_183[((long)(int)(val_123)) << 2] = val_127;
            }
            while(val_182 < (long)val_124);
            
            }
            
            label_183:
            val_169 = input;
            val_158 = val_158;
            int val_171 = val_122.Length;
            if(val_171 >= 1)
            {
                    val_171 = val_171 & 4294967295;
                var val_172 = 0;
                do
            {
                mem2[0] = null + ((val_87 + 32) + 0);
                val_172 = val_172 + 1;
            }
            while(val_172 < (long)val_171);
            
            }
            
            label_189:
            val_117.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  val_169), vertices:  val_122);
            if(val_173 < val_118)
            {
                    this.ReadCurve(input:  val_169, frameIndex:  0, timeline:  val_117);
            }
            
            val_173 = val_173 + 1;
            if(val_173 < val_116)
            {
                goto label_194;
            }
            
            val_1.Add(item:  val_117);
            var val_175 = 0;
            val_163 = val_159;
            val_175 = val_175 + 1;
            val_159 = System.Math.Max(val1:  val_163, val2:  (Spine.DeformTimeline)[1152921510610925632].frames[val_118]);
            if(val_175 < val_113)
            {
                goto label_200;
            }
            
            label_158:
            val_179 = val_180 + 1;
            if(val_179 < val_111)
            {
                goto label_201;
            }
            
            label_155:
            var val_176 = 0;
            val_176 = val_176 + 1;
            if(val_176 < val_108)
            {
                goto label_202;
            }
            
            label_148:
            int val_130 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            int val_131 = val_130 - 1;
            if(val_176 >= val_108)
            {
                    Spine.DrawOrderTimeline val_132 = new Spine.DrawOrderTimeline(frameCount:  val_130);
                val_160 = mem[skeletonData + 32 + 24];
                val_160 = skeletonData + 32 + 24;
                do
            {
                int val_135 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
                int[] val_136 = new int[0];
                if((((long)val_160 - 1) & 2147483648) == 0)
            {
                    var val_177 = (long)val_160 - 1;
                do
            {
                val_177 = val_177 - 1;
                val_136[((long)(int)((skeletonData + 32 + 24 - 1))) << 2] = 0;
            }
            while((val_177 & 2147483648) == 0);
            
            }
            
                int val_137 = val_160 - val_135;
                int[] val_138 = new int[0];
                if(val_135 >= 1)
            {
                    val_185 = 0;
                val_186 = 0;
                var val_178 = 0;
                do
            {
                int val_139 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
                if(val_185 != val_139)
            {
                    do
            {
                val_138[0] = val_185;
            }
            while(val_139 != (val_185 + 1));
            
                val_186 = val_186 + 1;
                val_185 = val_139;
            }
            
                val_187 = val_185 + 1;
                val_178 = val_178 + 1;
                val_136[((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) + val_185) << 2] = val_185;
            }
            while(val_178 < val_135);
            
            }
            else
            {
                    val_186 = 0;
                val_187 = 0;
            }
            
                if(val_187 < val_160)
            {
                    do
            {
                val_188 = val_186 + 1;
                val_138[0] = val_187;
            }
            while((val_187 + 1) < val_160);
            
            }
            else
            {
                    val_188 = val_186;
            }
            
                if((((long)val_160 - 1) & 2147483648) == 0)
            {
                    var val_181 = (long)val_160 - 1;
                do
            {
                if((val_136[((long)(int)((skeletonData + 32 + 24 - 1))) << 2]) == 1)
            {
                    val_188 = val_188 - 1;
                val_136[((long)(int)((skeletonData + 32 + 24 - 1))) << 2] = val_138[val_188 << 2];
            }
            
                val_181 = val_181 - 1;
            }
            while((val_181 & 2147483648) == 0);
            
            }
            
                val_132.SetFrame(frameIndex:  0, time:  this.ReadFloat(input:  val_169), drawOrder:  val_136);
                val_169 = input;
            }
            while(1 < val_130);
            
                val_1.Add(item:  val_132);
                var val_182 = mem[1152921510610974800];
                val_182 = val_182 + (val_131 << 2);
                val_163 = val_159;
                val_159 = System.Math.Max(val1:  val_163, val2:  (mem[1152921510610974800] + ((val_130 - 1)) << 2) + 32);
            }
            
            int val_146 = Spine.SkeletonBinary.ReadVarint(input:  val_169, optimizePositive:  true);
            if(val_131 >= (mem[1152921510610974800] + 24))
            {
                    Spine.EventTimeline val_148 = new Spine.EventTimeline(frameCount:  val_146);
                val_160 = 1152921504863928320;
                var val_183 = 0;
                do
            {
                var val_151 = (skeletonData + 56 + 16) + ((Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true)) << 3);
                .intValue = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  false);
                val_158 = val_158;
                .floatValue = this.ReadFloat(input:  input);
                if(input != 0)
            {
                    string val_155 = this.ReadString(input:  input);
            }
            else
            {
                    val_189 = mem[(skeletonData + 56 + 16 + (val_150) << 3) + 32 + 32];
                val_189 = (skeletonData + 56 + 16 + (val_150) << 3) + 32 + 32;
            }
            
                .stringValue = val_189;
                val_148.SetFrame(frameIndex:  0, e:  new Spine.Event(time:  this.ReadFloat(input:  input), data:  (skeletonData + 56 + 16 + (val_150) << 3) + 32));
                val_183 = val_183 + 1;
            }
            while(val_183 < val_146);
            
                val_1.Add(item:  val_148);
                val_190 = val_1;
                val_159 = System.Math.Max(val1:  val_159, val2:  (Spine.EventTimeline)[1152921510610987072].frames[val_146 - 1]);
                val_1.TrimExcess();
                val_191 = skeletonData;
            }
            else
            {
                    val_190 = val_1;
                val_1.TrimExcess();
                val_191 = skeletonData;
            }
            
            skeletonData + 64.Add(item:  new Spine.Animation(name:  name, timelines:  val_1, duration:  val_159));
        }
        private void ReadCurve(System.IO.Stream input, int frameIndex, Spine.CurveTimeline timeline)
        {
            if(input != 2)
            {
                    if(input != 1)
            {
                    return;
            }
            
                timeline.SetStepped(frameIndex:  frameIndex);
                return;
            }
            
            timeline.SetCurve(frameIndex:  frameIndex, cx1:  this.ReadFloat(input:  input), cy1:  this.ReadFloat(input:  input), cx2:  this.ReadFloat(input:  input), cy2:  this.ReadFloat(input:  input));
        }
        private static sbyte ReadSByte(System.IO.Stream input)
        {
            if(input == 1)
            {
                    throw new System.IO.EndOfStreamException();
            }
            
            return (sbyte)input;
        }
        private static bool ReadBoolean(System.IO.Stream input)
        {
            return (bool)(input != 0) ? 1 : 0;
        }
        private float ReadFloat(System.IO.Stream input)
        {
            this.buffer[0] = input;
            this.buffer[0] = input;
            this.buffer[0] = input;
            this.buffer[0] = input;
            return System.BitConverter.ToSingle(value:  this.buffer, startIndex:  0);
        }
        private static int ReadInt(System.IO.Stream input)
        {
            System.IO.Stream val_2 = input;
            System.IO.Stream val_1 = input << 16;
            val_1 = val_1 + (input << 24);
            val_1 = val_1 + (input << 8);
            val_2 = val_1 + val_2;
            return (int)val_2;
        }
        private static int ReadVarint(System.IO.Stream input, bool optimizePositive)
        {
            var val_3;
            var val_5;
            val_3 = input & 127;
            if(optimizePositive == true)
            {
                    return (int)val_5;
            }
            
            val_5 = (-(val_3 & 1)) ^ (val_3 >> 1);
            return (int)val_5;
        }
        private string ReadString(System.IO.Stream input)
        {
            var val_5;
            System.Byte[] val_6;
            int val_1 = Spine.SkeletonBinary.ReadVarint(input:  input, optimizePositive:  true);
            if(val_1 == 0)
            {
                goto label_3;
            }
            
            int val_2 = val_1 - 1;
            if()
            {
                goto label_4;
            }
            
            val_5 = "";
            return (string)val_5;
            label_3:
            val_5 = 0;
            return (string)val_5;
            label_4:
            val_6 = this.buffer;
            if(val_2 > this.buffer.Length)
            {
                    byte[] val_3 = new byte[0];
                val_6 = val_3;
            }
            
            Spine.SkeletonBinary.ReadFully(input:  input, buffer:  val_3, offset:  0, length:  val_2);
            System.Text.Encoding val_4 = System.Text.Encoding.UTF8;
            goto typeof(System.Text.Encoding).__il2cppRuntimeField_360;
        }
        private static void ReadFully(System.IO.Stream input, byte[] buffer, int offset, int length)
        {
            int val_2 = length;
            int val_2 = offset;
            if(val_2 < 1)
            {
                    return;
            }
            
            do
            {
                if(input <= 0)
            {
                    throw new System.IO.EndOfStreamException();
            }
            
                val_2 = val_2 - input;
                val_2 = input + val_2;
            }
            while(val_2 > 0);
        
        }
        private static SkeletonBinary()
        {
            Spine.SkeletonBinary.TransformModeValues = new Spine.TransformMode[5];
        }
    
    }

}
