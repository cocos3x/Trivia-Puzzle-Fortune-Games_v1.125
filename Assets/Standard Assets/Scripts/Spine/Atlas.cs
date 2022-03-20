using UnityEngine;

namespace Spine
{
    public class Atlas
    {
        // Fields
        private readonly System.Collections.Generic.List<Spine.AtlasPage> pages;
        private System.Collections.Generic.List<Spine.AtlasRegion> regions;
        private Spine.TextureLoader textureLoader;
        
        // Methods
        public Atlas(string path, Spine.TextureLoader textureLoader)
        {
            this.pages = new System.Collections.Generic.List<Spine.AtlasPage>();
            this.regions = new System.Collections.Generic.List<Spine.AtlasRegion>();
            System.IO.StreamReader val_3 = new System.IO.StreamReader(path:  path);
            this.Load(reader:  val_3, imagesDir:  System.IO.Path.GetDirectoryName(path:  path), textureLoader:  textureLoader);
            if(val_3 == null)
            {
                goto label_14;
            }
            
            label_13:
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_3.Dispose();
            label_14:
            if(0 != 0)
            {
                    throw 0;
            }
            
            return;
            label_19:
            if( != 1)
            {
                goto label_12;
            }
            
            if(val_3 != null)
            {
                goto label_13;
            }
            
            goto label_14;
            label_12:
            mem[8] = null;
            goto label_19;
        }
        public Atlas(System.IO.TextReader reader, string dir, Spine.TextureLoader textureLoader)
        {
            this.pages = new System.Collections.Generic.List<Spine.AtlasPage>();
            this.regions = new System.Collections.Generic.List<Spine.AtlasRegion>();
            val_3 = new System.Object();
            this.Load(reader:  reader, imagesDir:  string val_3 = dir, textureLoader:  textureLoader);
        }
        public Atlas(System.Collections.Generic.List<Spine.AtlasPage> pages, System.Collections.Generic.List<Spine.AtlasRegion> regions)
        {
            this.pages = new System.Collections.Generic.List<Spine.AtlasPage>();
            this.regions = new System.Collections.Generic.List<Spine.AtlasRegion>();
            val_3 = new System.Object();
            this.pages = pages;
            this.regions = val_3;
            this.textureLoader = 0;
        }
        private void Load(System.IO.TextReader reader, string imagesDir, Spine.TextureLoader textureLoader)
        {
            var val_57;
            Spine.AtlasPage val_58;
            string val_59;
            var val_60;
            if(textureLoader == null)
            {
                    throw new System.ArgumentNullException(paramName:  "textureLoader cannot be null.");
            }
            
            this.textureLoader = textureLoader;
            string[] val_1 = new string[4];
            if(reader == null)
            {
                    return;
            }
            
            val_57 = 1;
            goto label_76;
            label_39:
            val_58 = 0;
            goto label_5;
            label_40:
            Spine.AtlasPage val_2 = null;
            val_58 = val_2;
            val_2 = new Spine.AtlasPage();
            .name = reader;
            if((Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1)) == 2)
            {
                    .width = System.Int32.Parse(s:  val_1[0]);
                .height = System.Int32.Parse(s:  val_1[1]);
                int val_6 = Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1);
            }
            
            object val_8 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_1[0], ignoreCase:  false);
            .format = null;
            int val_9 = Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1);
            object val_11 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_1[0], ignoreCase:  false);
            .minFilter = null;
            object val_13 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_1[1], ignoreCase:  false);
            .magFilter = null;
            string val_14 = Spine.Atlas.ReadValue(reader:  reader);
            .uWrap = 1;
            if((System.String.op_Equality(a:  val_14, b:  "x")) != false)
            {
                    .uWrap = 2;
            }
            else
            {
                    if((System.String.op_Equality(a:  val_14, b:  "y")) != false)
            {
                    .vWrap = 2;
            }
            else
            {
                    if((System.String.op_Equality(a:  val_14, b:  "xy")) != false)
            {
                    .uWrap = 2;
            }
            
            }
            
            }
            
            val_59 = System.IO.Path.Combine(path1:  imagesDir, path2:  reader);
            Spine.TextureLoader val_63 = textureLoader;
            if((textureLoader + 294) == 0)
            {
                goto label_35;
            }
            
            var val_61 = textureLoader + 176;
            var val_62 = 0;
            val_61 = val_61 + 8;
            label_34:
            if(((textureLoader + 176 + 8) + -8) == null)
            {
                goto label_33;
            }
            
            val_62 = val_62 + 1;
            val_61 = val_61 + 16;
            if(val_62 < (textureLoader + 294))
            {
                goto label_34;
            }
            
            goto label_35;
            label_33:
            val_63 = val_63 + (((textureLoader + 176 + 8)) << 4);
            val_60 = val_63 + 304;
            label_35:
            textureLoader.Load(page:  val_2, path:  val_59);
            this.pages.Add(item:  val_2);
            label_5:
            var val_19 = (val_58 == 0) ? 1 : 0;
            goto label_37;
            label_76:
            string val_20 = reader.Trim();
            if(val_20.m_stringLength == 0)
            {
                goto label_39;
            }
            
            if((val_57 & 1) != 0)
            {
                goto label_40;
            }
            
            Spine.AtlasRegion val_21 = null;
            val_59 = val_21;
            val_21 = new Spine.AtlasRegion();
            .page = 0;
            .name = reader;
            .rotate = System.Boolean.Parse(value:  Spine.Atlas.ReadValue(reader:  reader));
            int val_25 = Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1);
            int val_26 = System.Int32.Parse(s:  val_1[0]);
            int val_27 = System.Int32.Parse(s:  val_1[1]);
            int val_28 = Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1);
            int val_29 = System.Int32.Parse(s:  val_1[0]);
            int val_30 = System.Int32.Parse(s:  val_1[1]);
            float val_68 = 4194311f;
            val_68 = (float)val_26 / val_68;
            .u = val_68;
            var val_31 = ((Spine.AtlasRegion)[1152921510547631104].rotate == false) ? (val_29) : (val_30);
            float val_69 = 1769500f;
            val_69 = (float)val_27 / val_69;
            .v = val_69;
            val_31 = val_31 + val_26;
            var val_32 = ((Spine.AtlasRegion)[1152921510547631104].rotate == false) ? (val_30) : (val_29);
            float val_70 = 4194311f;
            val_70 = (float)val_31 / val_70;
            .u2 = val_70;
            val_32 = val_32 + val_27;
            .x = val_26;
            .y = val_27;
            float val_71 = 1769500f;
            val_71 = (float)val_32 / val_71;
            .v2 = val_71;
            .width = (val_29 < 0) ? (-val_29) : (val_29);
            .height = (val_30 < 0) ? (-val_30) : (val_30);
            if((Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1)) == 4)
            {
                    int[] val_36 = new int[4];
                val_36[0] = System.Int32.Parse(s:  val_1[0]);
                val_36[0] = System.Int32.Parse(s:  val_1[1]);
                val_36[1] = System.Int32.Parse(s:  val_1[2]);
                val_36[1] = System.Int32.Parse(s:  val_1[3]);
                .splits = val_36;
                if((Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1)) == 4)
            {
                    int[] val_42 = new int[4];
                val_42[0] = System.Int32.Parse(s:  val_1[0]);
                val_42[0] = System.Int32.Parse(s:  val_1[1]);
                val_42[1] = System.Int32.Parse(s:  val_1[2]);
                val_42[1] = System.Int32.Parse(s:  val_1[3]);
                .pads = val_42;
                int val_47 = Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1);
            }
            
            }
            
            .originalWidth = System.Int32.Parse(s:  val_1[0]);
            .originalHeight = System.Int32.Parse(s:  val_1[1]);
            int val_50 = Spine.Atlas.ReadTuple(reader:  reader, tuple:  val_1);
            .offsetX = (float)System.Int32.Parse(s:  val_1[0]);
            .offsetY = (float)System.Int32.Parse(s:  val_1[1]);
            .index = System.Int32.Parse(s:  Spine.Atlas.ReadValue(reader:  reader));
            this.regions.Add(item:  val_21);
            label_37:
            if(reader != null)
            {
                goto label_76;
            }
        
        }
        private static string ReadValue(System.IO.TextReader reader)
        {
            int val_1 = reader.IndexOf(value:  ':');
            if(val_1 == 1)
            {
                    throw new System.Exception(message:  "Invalid line: "("Invalid line: ") + ???(???));
            }
            
            return reader.Substring(startIndex:  val_1 + 1).Trim();
        }
        private static int ReadTuple(System.IO.TextReader reader, string[] tuple)
        {
            var val_11;
            var val_12;
            int val_13;
            int val_1 = reader.IndexOf(value:  ':');
            if(val_1 == 1)
            {
                    throw new System.Exception(message:  "Invalid line: "("Invalid line: ") + ???(???));
            }
            
            val_12 = 0;
            val_13 = val_1 + 1;
            label_10:
            int val_11 = val_13;
            int val_2 = reader.IndexOf(value:  ',', startIndex:  val_11);
            if(val_2 == 1)
            {
                goto label_4;
            }
            
            val_11 = val_2;
            val_11 = val_2 - val_13;
            mem2[0] = reader.Substring(startIndex:  val_13, length:  val_11).Trim();
            val_13 = val_11 + 1;
            if(val_12 <= 1)
            {
                goto label_10;
            }
            
            val_12 = val_12 + 1;
            label_4:
            tuple[val_12] = reader.Substring(startIndex:  val_13).Trim();
            return (int)val_12 + 1;
        }
        public void FlipV()
        {
            bool val_1 = true;
            if(41984000 < 1)
            {
                    return;
            }
            
            var val_2 = 0;
            do
            {
                if(val_1 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1 = val_1 + 0;
                float val_3 = (true + 0) + 32 + 52;
                float val_4 = (true + 0) + 32 + 60;
                val_2 = val_2 + 1;
                val_3 = 1f - val_3;
                val_4 = 1f - val_4;
                mem2[0] = val_3;
                mem2[0] = val_4;
                if(val_2 >= 41984000)
            {
                    return;
            }
            
            }
            while(this.regions != null);
            
            throw new NullReferenceException();
        }
        public Spine.AtlasRegion FindRegion(string name)
        {
            var val_2;
            string val_3;
            var val_4;
            val_3 = name;
            bool val_2 = true;
            if(W22 < 1)
            {
                goto label_6;
            }
            
            val_2 = 0;
            label_7:
            if(val_2 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + 0;
            var val_3 = (true + 0) + 32;
            if((System.String.op_Equality(a:  (true + 0) + 32 + 24, b:  val_3)) == true)
            {
                goto label_5;
            }
            
            val_2 = val_2 + 1;
            if(val_2 < W22)
            {
                    if(this.regions != null)
            {
                goto label_7;
            }
            
            }
            
            label_6:
            val_4 = 0;
            return (Spine.AtlasRegion)val_4;
            label_5:
            val_3 = this.regions;
            if(val_3 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_3 = val_3 + 0;
            val_4 = mem[((true + 0) + 32 + 0) + 32];
            val_4 = ((true + 0) + 32 + 0) + 32;
            return (Spine.AtlasRegion)val_4;
        }
        public void Dispose()
        {
            System.Collections.Generic.List<Spine.AtlasPage> val_2;
            bool val_2 = true;
            if(this.textureLoader == null)
            {
                    return;
            }
            
            val_2 = this.pages;
            if(W22 < 1)
            {
                    return;
            }
            
            var val_4 = 0;
            do
            {
                if(val_2 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2 = val_2 + 0;
                val_2 = mem[(true + 0) + 32 + 48];
                val_2 = (true + 0) + 32 + 48;
                var val_3 = 0;
                val_3 = val_3 + 1;
                this.textureLoader.Unload(texture:  val_2);
                val_4 = val_4 + 1;
                if(val_4 >= W22)
            {
                    return;
            }
            
                val_2 = this.pages;
            }
            while(val_2 != null);
            
            throw new NullReferenceException();
        }
    
    }

}
