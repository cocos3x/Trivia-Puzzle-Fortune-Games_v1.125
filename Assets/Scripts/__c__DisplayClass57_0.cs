using UnityEngine;
private sealed class SweepstakesSDK.<>c__DisplayClass57_0
{
    // Fields
    public twelvegigs.sweepstakes.SweepstakesSDK <>4__this;
    public System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction;
    
    // Methods
    public SweepstakesSDK.<>c__DisplayClass57_0()
    {
    
    }
    internal void <DoPost>b__0(string method, System.Collections.Generic.Dictionary<string, object> data)
    {
        UnityEngine.Debug.LogError(message:  "response from \'" + method + "\':"("\':"));
        UnityEngine.Debug.LogError(message:  PrettyPrint.printJSON(obj:  data, types:  false, singleLineOutput:  false));
        this.<>4__this.OnSweepstakesResponse(method:  0, data:  data, onCompleteFunction:  this.onCompleteFunction);
    }

}
