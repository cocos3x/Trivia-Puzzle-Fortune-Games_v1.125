using UnityEngine;
public class LineKeyboardInput : MonoBehaviour
{
    // Fields
    public LineDrawer lineDrawer;
    public TextPreview textPreview;
    private UnityEngine.LineRenderer lineRenderer;
    private UnityEngine.Vector3 mousePoint;
    private bool didValidInput;
    private bool cancelInput;
    private string invalidInputLetters;
    
    // Properties
    public System.Collections.Generic.List<int> currentIndexes { get; }
    public System.Collections.Generic.List<UnityEngine.Vector3> points { get; }
    public System.Collections.Generic.List<UnityEngine.Vector3> positions { get; }
    public System.Collections.Generic.List<bool> allowedPositions { get; }
    private System.Collections.Generic.List<UnityEngine.Vector3> letterPositions { get; }
    
    // Methods
    public System.Collections.Generic.List<int> get_currentIndexes()
    {
        if(this.lineDrawer != null)
        {
                return (System.Collections.Generic.List<System.Int32>)this.lineDrawer.currentIndexes;
        }
        
        throw new NullReferenceException();
    }
    public System.Collections.Generic.List<UnityEngine.Vector3> get_points()
    {
        if(this.lineDrawer != null)
        {
                return (System.Collections.Generic.List<UnityEngine.Vector3>)this.lineDrawer.points;
        }
        
        throw new NullReferenceException();
    }
    public System.Collections.Generic.List<UnityEngine.Vector3> get_positions()
    {
        if(this.lineDrawer != null)
        {
                return (System.Collections.Generic.List<UnityEngine.Vector3>)this.lineDrawer.positions;
        }
        
        throw new NullReferenceException();
    }
    public System.Collections.Generic.List<bool> get_allowedPositions()
    {
        if(this.lineDrawer != null)
        {
                return (System.Collections.Generic.List<System.Boolean>)this.lineDrawer.allowedPositions;
        }
        
        throw new NullReferenceException();
    }
    private System.Collections.Generic.List<UnityEngine.Vector3> get_letterPositions()
    {
        if(this.lineDrawer != null)
        {
                return (System.Collections.Generic.List<UnityEngine.Vector3>)this.lineDrawer.letterPositions;
        }
        
        throw new NullReferenceException();
    }
    private void Awake()
    {
        if(this.lineDrawer != 0)
        {
                return;
        }
        
        this.lineDrawer = this.GetComponent<LineDrawer>();
    }
    private void Start()
    {
        UnityEngine.LineRenderer val_1 = this.GetComponent<UnityEngine.LineRenderer>();
        this.lineRenderer = val_1;
        val_1.sortingLayerName = "MyLineRenderer";
    }
    private bool SelectedEnabled(int letterIndex)
    {
        LineDrawer val_1 = this.lineDrawer;
        if(val_1 <= letterIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + (letterIndex << );
        return (bool)(this.lineDrawer + (letterIndex) << ).allowedPositions;
    }
    private void Update()
    {
    
    }
    private void BuildPoints()
    {
        var val_2;
        var val_3;
        System.Collections.Generic.List<UnityEngine.Vector3> val_7;
        var val_8;
        val_7 = this;
        this.lineDrawer.points.Clear();
        List.Enumerator<T> val_1 = this.lineDrawer.currentIndexes.GetEnumerator();
        label_10:
        if(val_3.MoveNext() == false)
        {
            goto label_5;
        }
        
        LineDrawer val_7 = this.lineDrawer;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.lineDrawer.letterPositions == null)
        {
                throw new NullReferenceException();
        }
        
        if(W9 <= val_2)
        {
                val_8 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(this.lineDrawer.points == null)
        {
                throw new NullReferenceException();
        }
        
        val_7 = val_7 + (val_2 * 12);
        this.lineDrawer.points.Add(item:  new UnityEngine.Vector3() {x = (val_2 * 12) + this.lineDrawer + 32, y = (val_2 * 12) + this.lineDrawer + 32 + 4, z = (val_2 * 12) + this.lineDrawer + 40});
        goto label_10;
        label_5:
        val_3.Dispose();
        if(this.lineDrawer.currentIndexes != 1)
        {
                return;
        }
        
        val_7 = this.lineDrawer.points;
        if(this.lineDrawer == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = 0;
        UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  0f, y:  -0.15f, z:  0f);
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = this.lineDrawer.allowedPositions, y = V9.16B, z = this.lineDrawer.currentIndexes}, b:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
        val_7.Add(item:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
    }
    public void CancelInput(bool force = False)
    {
        if((this.didValidInput != true) && (force != true))
        {
                return;
        }
        
        this.cancelInput = true;
    }
    public LineKeyboardInput()
    {
        this.invalidInputLetters = "àáèéìíòóùúñ";
    }

}
