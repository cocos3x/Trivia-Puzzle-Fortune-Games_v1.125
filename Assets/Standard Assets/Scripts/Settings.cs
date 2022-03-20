using UnityEngine;
[Serializable]
public struct MeshGenerator.Settings
{
    // Fields
    public bool useClipping;
    public float zSpacing;
    public bool pmaVertexColors;
    public bool tintBlack;
    public bool calculateTangents;
    public bool addNormals;
    public bool immutableTriangles;
    
    // Properties
    public static Spine.Unity.MeshGenerator.Settings Default { get; }
    
    // Methods
    public static Spine.Unity.MeshGenerator.Settings get_Default()
    {
        return new MeshGenerator.Settings() {useClipping = true, zSpacing = 0f, pmaVertexColors = true, tintBlack = false, calculateTangents = false, addNormals = false, immutableTriangles = false};
    }

}
