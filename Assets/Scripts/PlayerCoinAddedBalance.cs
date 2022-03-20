using UnityEngine;
public class PlayerCoinAddedBalance : MonoBehaviour
{
    // Fields
    private UnityEngine.CanvasGroup canvasGroup;
    private bool isShowing;
    private int showingValue;
    private float remainingTime;
    private float showDuration;
    private UnityEngine.RectTransform slideOut;
    private UnityEngine.Vector2 slideOutPosition;
    private UnityEngine.Vector2 slideInPosition;
    private UnityEngine.UI.Text text;
    private UnityEngine.GameObject[] opposingPartners;
    private bool bumped;
    private DG.Tweening.Tweener punchScale;
    
    // Methods
    private void Start()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.canvasGroup)) != false)
        {
                this.canvasGroup.alpha = 0f;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.slideOut)) != false)
        {
                UnityEngine.Vector2 val_3 = this.slideOut.anchoredPosition;
            this.slideOutPosition = val_3;
            mem[1152921518035146476] = val_3.y;
            UnityEngine.Vector2 val_4 = this.slideOut.anchoredPosition;
            UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  0f, y:  val_4.y);
            UnityEngine.Vector2 val_6 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
            this.slideInPosition = val_6;
            mem[1152921518035146484] = val_6.y;
            this.slideOut.anchoredPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        }
        
        UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  0.2f, y:  0.2f, z:  0.2f);
        this.punchScale = DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.text.transform, punch:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, duration:  0.15f, vibrato:  5, elasticity:  8f);
    }
    private void OnEnable()
    {
        this.showingValue = 0;
    }
    private void Update()
    {
        if((UnityEngine.Input.GetKeyUp(key:  98)) != false)
        {
                if(UnityEngine.Application.isEditor != false)
        {
                this.Add(addAmount:  1);
        }
        
        }
        
        if(this.isShowing == false)
        {
                return;
        }
        
        float val_3 = UnityEngine.Time.deltaTime;
        val_3 = this.remainingTime - val_3;
        this.remainingTime = val_3;
        if(val_3 <= 0f)
        {
                this.Hide();
        }
        
        if(this.bumped == true)
        {
                return;
        }
        
        float val_9 = this.showDuration;
        val_9 = val_9 * 0.8f;
        if(this.remainingTime >= 0)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.punchScale, complete:  false);
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
        this.text.transform.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        UnityEngine.Vector3 val_7 = new UnityEngine.Vector3(x:  0.2f, y:  0.2f, z:  0.2f);
        this.punchScale = DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.text.transform, punch:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, duration:  0.15f, vibrato:  5, elasticity:  8f);
        this.bumped = true;
    }
    public void Add(int addAmount)
    {
        int val_8 = this.showingValue;
        val_8 = val_8 + addAmount;
        this.showingValue = val_8;
        string val_2 = "+"("+") + this.showingValue.ToString(format:  "n0")(this.showingValue.ToString(format:  "n0"));
        DG.Tweening.TweenExtensions.Kill(t:  this.punchScale, complete:  false);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
        this.text.transform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  0.08f, y:  0.08f, z:  0.08f);
        this.punchScale = DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.text.transform, punch:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, duration:  0.08f, vibrato:  5, elasticity:  8f);
        if(this.isShowing != true)
        {
                this.Show();
        }
        
        this.remainingTime = this.showDuration;
    }
    public void Add(int addAmount, float delay)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.AddDelayed(addAmount:  addAmount, delay:  delay));
    }
    private System.Collections.IEnumerator AddDelayed(int addAmount, float delay)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .addAmount = addAmount;
        .delay = delay;
        return (System.Collections.IEnumerator)new PlayerCoinAddedBalance.<AddDelayed>d__17();
    }
    private void Show()
    {
        this.CancelInvoke(methodName:  "Invoke_ShowPartners");
        this.isShowing = true;
        if((UnityEngine.Object.op_Implicit(exists:  this.slideOut)) != false)
        {
                DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.slideOut, endValue:  new UnityEngine.Vector2() {x = this.slideOutPosition}, duration:  0.25f, snapping:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.canvasGroup)) != false)
        {
                DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  1f, duration:  0.5f);
        }
        
        this.ShowOpposingPartners(showThem:  false);
    }
    private void Hide()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.canvasGroup)) != false)
        {
                DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  0f, duration:  0.5f);
        }
        
        this.Invoke(methodName:  "Invoke_ShowPartners", time:  0.5f);
        if((UnityEngine.Object.op_Implicit(exists:  this.slideOut)) != false)
        {
                DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.slideOut, endValue:  new UnityEngine.Vector2() {x = this.slideInPosition, y = 0.5f}, duration:  0.25f, snapping:  false);
        }
        
        this.showingValue = 0;
        this.isShowing = false;
    }
    private void Invoke_ShowPartners()
    {
        this.ShowOpposingPartners(showThem:  true);
    }
    private void ShowOpposingPartners(bool showThem)
    {
        var val_3 = 0;
        do
        {
            if(val_3 >= this.opposingPartners.Length)
        {
                return;
        }
        
            this.opposingPartners[val_3].SetActive(value:  showThem);
            val_3 = val_3 + 1;
        }
        while(this.opposingPartners != null);
        
        throw new NullReferenceException();
    }
    public PlayerCoinAddedBalance()
    {
        this.showDuration = 3f;
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  -330f, y:  0f);
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
        this.slideOutPosition = val_2;
        mem[1152921518036704940] = val_2.y;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  0f, y:  0f);
        UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        this.slideInPosition = val_4;
        mem[1152921518036704948] = val_4.y;
    }

}
