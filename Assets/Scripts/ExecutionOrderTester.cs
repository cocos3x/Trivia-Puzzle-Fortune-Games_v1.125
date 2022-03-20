using UnityEngine;
public class ExecutionOrderTester : MonoBehaviour
{
    // Fields
    public bool doLog;
    public bool doLogAwake;
    public bool doLogOnEnable;
    public bool doLogStart;
    public bool doLogFixedUpdate;
    public bool doLogUpdate;
    public bool doLogLateUpdate;
    public bool doLogOnBecameVisible;
    public bool doLogOnBecameInvisible;
    public bool doLogOnDisable;
    public bool doLogOnDestroy;
    private bool useErrors;
    
    // Methods
    private void Awake()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogAwake == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - Awake");
    }
    private void OnEnable()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogOnEnable == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - OnEnable");
    }
    private void Start()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogStart == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - Start");
    }
    private void FixedUpdate()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogFixedUpdate == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - FixedUpdate");
    }
    private void Update()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogUpdate == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - Update");
    }
    private void LateUpdate()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogLateUpdate == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - LateUpdate");
    }
    private void OnBecameVisibile()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogOnBecameVisible == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - OnBecameVisibile");
    }
    private void OnBecameInvisibile()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogOnBecameInvisible == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - OnBecameInvisibile");
    }
    private void OnDisable()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogOnDisable == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - OnDisable");
    }
    private void OnDestroy()
    {
        if(this.doLog == false)
        {
                return;
        }
        
        if(this.doLogOnDestroy == false)
        {
                return;
        }
        
        this.Log(message:  "[ExecutionOrderTester] - OnDestroy");
    }
    private void Log(string message)
    {
        string val_5 = message;
        UnityEngine.GameObject val_1 = this.gameObject;
        if(val_1 != 0)
        {
                val_5 = val_5 + ": "(": ") + val_1.name;
        }
        
        if(this.useErrors != false)
        {
                UnityEngine.Debug.LogError(message:  val_5, context:  val_1);
            return;
        }
        
        UnityEngine.Debug.LogWarning(message:  val_5, context:  val_1);
    }
    public ExecutionOrderTester()
    {
        this.doLog = true;
        this.doLogOnEnable = true;
        this.doLogOnDisable = true;
    }

}
