using UnityEngine;
public class RemoteResourcesLoadingController
{
    // Methods
    public static void DownloadItem(string uri, string fileName, string fileExtention, string localDirectory, System.Action<bool, byte[]> callback)
    {
        RemoteResourcesLoadingController.CreateRequest(uri:  uri, fileName:  fileName, fileExtention:  fileExtention, localDirectory:  localDirectory, callback:  callback);
    }
    private static void CreateRequest(string uri, string fileName, string fileExtention, string localDirectory, System.Action<bool, byte[]> callback)
    {
        object val_1 = 23173;
        val_1 = new System.Object();
        RemoteResourcesLoadingRequestHandler val_3 = new UnityEngine.GameObject(name:  uri).AddComponent<RemoteResourcesLoadingRequestHandler>();
        UnityEngine.Networking.UnityWebRequest val_4 = UnityEngine.Networking.UnityWebRequest.Get(uri:  uri);
        val_4.timeout = 30;
        val_3.req = val_4;
        val_3.callback = new System.Action<System.Boolean, System.Byte[]>(object:  val_1, method:  System.Void RemoteResourcesLoadingController.<>c__DisplayClass1_0::<CreateRequest>b__0(bool isRequestSuccess, byte[] data));
    }
    public RemoteResourcesLoadingController()
    {
    
    }

}
