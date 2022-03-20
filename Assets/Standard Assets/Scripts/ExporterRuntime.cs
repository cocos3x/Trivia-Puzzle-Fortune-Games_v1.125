using UnityEngine;
public class ExporterRuntime : MonoBehaviour
{
    // Methods
    public void ExportObj(UnityEngine.GameObject mainObj, string path, string name)
    {
        ExporterRuntimeS.ExportGOToOBJ(selection:  mainObj.GetComponentsInChildren<UnityEngine.Transform>(), mainPath:  path, filename:  name);
    }
    public ExporterRuntime()
    {
    
    }

}
