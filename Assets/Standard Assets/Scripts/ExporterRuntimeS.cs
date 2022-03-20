using UnityEngine;
public class ExporterRuntimeS : ScriptableObject
{
    // Fields
    private static int vertexOffset;
    private static int normalOffset;
    private static int uvOffset;
    
    // Methods
    private static string MeshToString(UnityEngine.MeshFilter mf, System.Collections.Generic.Dictionary<string, OMATRuntime> materialList)
    {
        var val_45;
        var val_46;
        float val_49;
        float val_50;
        object val_51;
        var val_52;
        var val_54;
        var val_55;
        val_45 = mf.sharedMesh;
        System.Text.StringBuilder val_4 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_8 = val_4.Append(value:  "g ").Append(value:  mf.name).Append(value:  "\n");
        int val_47 = val_9.Length;
        if(val_47 >= 1)
        {
                val_46 = 1152921504622129152;
            var val_48 = 0;
            val_47 = val_47 & 4294967295;
            do
        {
            UnityEngine.Vector3 val_11 = mf.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = 1.187865E-20f, y = 1.187865E-20f, z = 1.187865E-20f});
            val_49 = val_11.y;
            val_50 = val_11.z;
            val_51 = -val_11.x;
            System.Text.StringBuilder val_13 = val_4.Append(value:  System.String.Format(format:  "v {0} {1} {2}\n", arg0:  -val_11.x, arg1:  val_49, arg2:  val_50));
            val_48 = val_48 + 1;
        }
        while(val_48 < (val_9.Length << ));
        
        }
        
        System.Text.StringBuilder val_14 = val_4.Append(value:  "\n");
        int val_49 = val_15.Length;
        if(val_49 >= 1)
        {
                val_46 = 1152921504622129152;
            var val_50 = 0;
            val_49 = val_49 & 4294967295;
            do
        {
            UnityEngine.Vector3 val_17 = mf.transform.TransformDirection(direction:  new UnityEngine.Vector3() {x = 1.187865E-20f, y = 1.187865E-20f, z = 1.187865E-20f});
            val_49 = val_17.y;
            val_50 = val_17.z;
            val_51 = -val_17.x;
            System.Text.StringBuilder val_19 = val_4.Append(value:  System.String.Format(format:  "vn {0} {1} {2}\n", arg0:  -val_17.x, arg1:  val_49, arg2:  val_50));
            val_50 = val_50 + 1;
        }
        while(val_50 < (val_15.Length << ));
        
        }
        
        System.Text.StringBuilder val_20 = val_4.Append(value:  "\n");
        int val_51 = val_21.Length;
        val_52 = val_45.uv;
        if(val_51 >= 1)
        {
                val_51 = 1152921504762331136;
            val_46 = "vt {0} {1}\n";
            var val_52 = 0;
            val_51 = val_51 & 4294967295;
            do
        {
            UnityEngine.Vector3 val_22 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = 1.187534E-20f, y = 1.187534E-20f});
            val_49 = val_22.y;
            System.Text.StringBuilder val_24 = val_4.Append(value:  System.String.Format(format:  "vt {0} {1}\n", arg0:  val_22.x, arg1:  val_49));
            val_52 = val_52 + 1;
        }
        while(val_52 < (val_21.Length << ));
        
        }
        
        if(val_45.subMeshCount >= 1)
        {
                val_46 = 1152921504619999232;
            do
        {
            System.Text.StringBuilder val_26 = val_4.Append(value:  "\n");
            UnityEngine.Material[] val_28 = (mf.GetComponent<UnityEngine.Renderer>().sharedMaterials) + 0;
            System.Text.StringBuilder val_31 = val_4.Append(value:  "usemtl ").Append(value:  (val_3 + 0) + 32.name).Append(value:  "\n");
            System.Text.StringBuilder val_35 = val_4.Append(value:  "usemap ").Append(value:  (val_3 + 0) + 32.name).Append(value:  "\n");
            if(0 >= (val_3 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
            if(((val_3 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
            string val_36 = (val_3 + 0) + 32.name;
            if(materialList == 0)
        {
                throw new NullReferenceException();
        }
        
            materialList.Add(key:  val_36, value:  new OMATRuntime() {name = val_36, cls = new UnityEngine.Color() {r = 0f, g = 0f, b = 0f, a = 0f}});
            System.Int32[] val_37 = val_45.GetTriangles(submesh:  0);
            if(val_37.Length >= 1)
        {
                var val_59 = 2;
            do
        {
            val_54 = null;
            val_54 = null;
            int val_54 = ExporterRuntimeS.vertexOffset;
            val_54 = val_37[0] + val_54;
            val_54 = val_54 + 1;
            var val_38 = 0 + 1;
            val_51 = val_54;
            int val_56 = ExporterRuntimeS.normalOffset;
            val_56 = (val_37[(val_59 - 1) << 2]) + val_56;
            val_56 = val_56 + 1;
            val_38 = val_38 + 1;
            int val_58 = ExporterRuntimeS.uvOffset;
            val_58 = val_37[8] + val_58;
            val_58 = val_58 + 1;
            System.Text.StringBuilder val_41 = val_4.Append(value:  System.String.Format(format:  "f {1}/{1}/{1} {0}/{0}/{0} {2}/{2}/{2}\n", arg0:  val_54, arg1:  val_56, arg2:  val_58));
            val_59 = val_59 + 3;
        }
        while((val_38 + 1) < val_37.Length);
        
        }
        
            val_52 = 0 + 1;
            val_45 = val_45;
        }
        while(val_52 < val_45.subMeshCount);
        
        }
        
        val_55 = null;
        val_55 = null;
        UnityEngine.Vector3[] val_44 = val_45.vertices;
        int val_60 = val_44.Length;
        val_60 = ExporterRuntimeS.vertexOffset + val_60;
        ExporterRuntimeS.vertexOffset = val_60;
        UnityEngine.Vector3[] val_45 = val_45.normals;
        int val_61 = val_45.Length;
        val_61 = ExporterRuntimeS.normalOffset + val_61;
        ExporterRuntimeS.normalOffset = val_61;
        UnityEngine.Vector2[] val_46 = val_45.uv;
        int val_62 = val_46.Length;
        val_62 = ExporterRuntimeS.uvOffset + val_62;
        ExporterRuntimeS.uvOffset = val_62;
        return (string)val_4;
    }
    private static void Clear()
    {
        null = null;
        ExporterRuntimeS.vertexOffset = 0;
        ExporterRuntimeS.normalOffset = 0;
        ExporterRuntimeS.uvOffset = 0;
    }
    private static System.Collections.Generic.Dictionary<string, OMATRuntime> PrepareFileWrite()
    {
        ExporterRuntimeS.Clear();
        return (System.Collections.Generic.Dictionary<System.String, OMATRuntime>)new System.Collections.Generic.Dictionary<System.String, OMATRuntime>();
    }
    private static void MaterialsToFile(System.Collections.Generic.Dictionary<string, OMATRuntime> materialList, string folder, string filename)
    {
        string val_4;
        var val_7;
        string val_16;
        string val_17;
        val_16 = folder;
        System.IO.StreamWriter val_2 = new System.IO.StreamWriter(path:  val_16 + "/"("/") + filename + ".mtl");
        Dictionary.Enumerator<TKey, TValue> val_3 = materialList.GetEnumerator();
        label_8:
        if(val_7.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_4 == 0)
        {
            goto label_8;
        }
        
        int val_9 = val_4.LastIndexOf(value:  '/');
        val_17 = val_4;
        if((val_9 & 2147483648) == 0)
        {
                string val_11 = val_4.Substring(startIndex:  val_9 + 1);
            if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
            val_17 = val_11.Trim();
        }
        
        string val_13 = val_16 + "/"("/") + val_17;
        if((System.IO.File.Exists(path:  val_13)) == true)
        {
            goto label_8;
        }
        
        System.IO.File.Copy(sourceFileName:  val_4, destFileName:  val_13);
        goto label_8;
        label_2:
        val_16 = 0;
        val_7.Dispose();
        if(val_16 != 0)
        {
                throw val_16;
        }
        
        if(val_2 != null)
        {
                var val_16 = 0;
            val_16 = val_16 + 1;
            val_2.Dispose();
        }
        
        if(val_16 != 0)
        {
                throw val_16;
        }
    
    }
    private static void MeshesToFile(UnityEngine.MeshFilter[] mf, string folder, string filename)
    {
        var val_7;
        var val_8;
        System.Collections.Generic.Dictionary<System.String, OMATRuntime> val_1 = ExporterRuntimeS.PrepareFileWrite();
        System.IO.StreamWriter val_3 = new System.IO.StreamWriter(path:  folder + "/"("/") + filename + ".obj");
        val_8 = "mtllib ./"("mtllib ./") + filename + ".mtl\n";
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_7 = mf.Length;
        if(val_7 >= 1)
        {
                var val_8 = 0;
            val_7 = val_7 & 4294967295;
            do
        {
            string val_5 = ExporterRuntimeS.MeshToString(mf:  1152921506814855056, materialList:  val_1);
            val_8 = val_8 + 1;
        }
        while(val_8 < (mf.Length << ));
        
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_3.Dispose();
        if(0 == 0)
        {
                ExporterRuntimeS.MaterialsToFile(materialList:  val_1, folder:  folder, filename:  filename);
            return;
        }
        
        val_7 = ???;
        val_8 = 0;
        throw val_7;
    }
    public static void ExportGOToOBJ(UnityEngine.Transform[] selection, string mainPath, string filename)
    {
        string val_15;
        string val_16;
        System.Collections.ArrayList val_17;
        UnityEngine.MeshFilter[] val_18;
        var val_19;
        object val_20;
        val_15 = filename;
        val_16 = mainPath;
        string val_1 = val_16 + "/"("/") + val_15 + "/"("/");
        System.IO.DirectoryInfo val_2 = System.IO.Directory.CreateDirectory(path:  val_1);
        System.Collections.ArrayList val_3 = new System.Collections.ArrayList();
        if(selection.Length >= 1)
        {
                val_17 = 0;
            do
        {
            int val_16 = val_5.Length;
            val_18 = selection[0].GetComponentsInChildren(t:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
            if(val_16 >= 1)
        {
                var val_17 = 0;
            val_16 = val_16 & 4294967295;
            do
        {
            val_17 = val_17 + 1;
        }
        while(val_17 < (val_5.Length << ));
        
            val_17 = val_17 + val_17;
        }
        
            val_19 = 0 + 1;
        }
        while(val_19 < selection.Length);
        
        }
        else
        {
                val_17 = 0;
        }
        
        if(val_17 >= 1)
        {
                UnityEngine.MeshFilter[] val_6 = new UnityEngine.MeshFilter[1549374320];
            val_18 = val_6;
            if(val_3 >= 1)
        {
                val_19 = 1152921504759828480;
            var val_18 = 0;
            do
        {
            val_17 = val_3;
            if(val_3 != null)
        {
                if((null != null) || (null != null))
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
            mem2[0] = val_17;
            val_18 = val_18 + 1;
        }
        while(val_18 < (val_3 << ));
        
        }
        
            if((val_15.Equals(value:  "")) != false)
        {
                val_15 = selection[0].gameObject.name;
        }
        
            int val_10 = val_15.LastIndexOf(value:  '/');
            if((val_10 & 2147483648) == 0)
        {
                val_15 = val_15.Substring(startIndex:  val_10 + 1).Trim();
        }
        
            ExporterRuntimeS.MeshesToFile(mf:  val_6, folder:  val_1, filename:  val_15);
            val_16 = "Exported: "("Exported: ") + val_1 + "/"("/") + val_15;
            val_20 = val_16;
        }
        else
        {
                val_20 = "Error exporting. Make sure you selected the object.";
        }
        
        UnityEngine.Debug.Log(message:  val_20);
    }
    public ExporterRuntimeS()
    {
    
    }
    private static ExporterRuntimeS()
    {
    
    }

}
