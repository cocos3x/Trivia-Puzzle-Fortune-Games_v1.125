using UnityEngine;
public class LightningEffects : MonoBehaviour
{
    // Fields
    private int numOfSegments;
    private UnityEngine.Color color;
    private float posRange;
    private UnityEngine.LineRenderer lineRenderer;
    private UnityEngine.Vector3 start;
    private UnityEngine.Vector3 end;
    private float length;
    private bool isVertical;
    private float chaoticTen;
    private FrameSkipper frameSkipper;
    
    // Methods
    private void Awake()
    {
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this.transform);
        val_2.updateLogic = new System.Action(object:  this, method:  System.Void LightningEffects::UpdateLightningEffects());
        this.frameSkipper._framesToSkip = 5;
        float val_4 = UnityEngine.Random.Range(min:  1f, max:  2f);
        val_4 = val_4 * 10f;
        this.chaoticTen = val_4;
    }
    private void UpdateLightningEffects()
    {
        if((this.numOfSegments - 1) > 1)
        {
                var val_10 = 1;
            do
        {
            float val_9 = this.length;
            val_9 = val_9 * 1f;
            if(this.isVertical != false)
        {
            
        }
        else
        {
                UnityEngine.Vector3 val_4;
        }
        
            val_4 = new UnityEngine.Vector3(x:  val_9 / (float)this.numOfSegments, y:  UnityEngine.Random.Range(min:  this.posRange, max:  -this.posRange), z:  0f);
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = this.start, y = V11.16B, z = V12.16B}, b:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
            this.lineRenderer.SetPosition(index:  1, position:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
            val_10 = val_10 + 1;
        }
        while(val_10 < (this.numOfSegments - 1));
        
        }
        
        this.lineRenderer.startColor = new UnityEngine.Color() {r = this.color, g = val_5.y, b = val_5.z, a = val_4.x};
        this.lineRenderer.endColor = new UnityEngine.Color() {r = this.color, g = val_5.y, b = val_5.z, a = val_4.x};
        float val_7 = UnityEngine.Time.deltaTime;
        val_7 = this.chaoticTen * val_7;
        val_7 = val_4.x - val_7;
        mem[1152921516491452072] = (val_7 <= 0f) ? 1f : (val_7);
    }
    public void Setup(UnityEngine.Vector3 start, UnityEngine.Vector3 end)
    {
        var val_6;
        UnityEngine.LineRenderer val_1 = this.GetComponent<UnityEngine.LineRenderer>();
        this.lineRenderer = val_1;
        val_1.positionCount = this.numOfSegments;
        this.start = start;
        mem[1152921516491596860] = start.y;
        mem[1152921516491596864] = start.z;
        this.end = end;
        mem[1152921516491596872] = end.y;
        mem[1152921516491596876] = end.z;
        val_6 = null;
        val_6 = null;
        this.isVertical = ((start.x ?? end.x) < 0) ? 1 : 0;
        this.lineRenderer.startWidth = 0.1f;
        this.lineRenderer.endWidth = 0.1f;
        this.length = UnityEngine.Vector3.Distance(a:  new UnityEngine.Vector3() {x = start.x, y = start.y, z = start.z}, b:  new UnityEngine.Vector3() {x = end.x, y = end.y, z = end.z});
        this.lineRenderer.SetPosition(index:  0, position:  new UnityEngine.Vector3() {x = start.x, y = start.y, z = start.z});
        this.lineRenderer.SetPosition(index:  this.numOfSegments - 1, position:  new UnityEngine.Vector3() {x = end.x, y = end.y, z = end.z});
    }
    public LightningEffects()
    {
        this.numOfSegments = 10;
        this.posRange = 0.2f;
        this.chaoticTen = 1f;
    }

}
