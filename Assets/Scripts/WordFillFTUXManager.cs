using UnityEngine;
public class WordFillFTUXManager : MonoSingleton<WordFillFTUXManager>
{
    // Fields
    private UnityEngine.UI.Text FTUXText;
    private UnityEngine.GameObject FTUXHand;
    private bool <ftux>k__BackingField;
    private float x1;
    private float x2;
    private float x3;
    private float y1;
    private float y2;
    private float y3;
    private float curveTime;
    private const float curveEnd = 1.3;
    private const float curveFade = 0.4;
    private bool animatingCurve;
    private string[] ftuxMessages;
    private int[] ftuxLetterPos;
    private int ftuxPhase;
    
    // Properties
    public bool ftux { get; set; }
    
    // Methods
    public bool get_ftux()
    {
        return (bool)this.<ftux>k__BackingField;
    }
    protected void set_ftux(bool value)
    {
        this.<ftux>k__BackingField = value;
    }
    private void Update()
    {
        float val_20;
        float val_21;
        if((this.<ftux>k__BackingField) != true)
        {
                this.EndFTUX();
        }
        
        if(this.animatingCurve == false)
        {
                return;
        }
        
        float val_16 = this.curveTime;
        float val_1 = UnityEngine.Time.deltaTime;
        val_16 = val_16 + val_1;
        this.curveTime = val_16;
        val_1 = val_16 / 1.3f;
        val_20 = 1f;
        float val_17 = val_20;
        float val_3 = UnityEngine.Mathf.Min(a:  UnityEngine.Mathf.Max(a:  val_1, b:  0f), b:  val_17);
        float val_18 = this.y1;
        float val_19 = this.x1;
        val_17 = val_20 - val_3;
        float val_4 = val_17 * val_17;
        val_18 = val_4 * val_18;
        val_19 = val_4 * val_19;
        float val_20 = this.y2;
        val_17 = val_17 + val_17;
        val_17 = val_3 * val_17;
        val_3 = val_3 * val_3;
        val_20 = val_17 * val_20;
        val_17 = val_17 * this.x2;
        val_3 = val_3 * this.x3;
        val_17 = val_19 + val_17;
        UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  val_17 + val_3, y:  (val_18 + val_20) + (val_3 * this.y3));
        this.FTUXHand.transform.position = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
        float val_21 = this.curveTime;
        val_21 = val_20;
        if(val_21 < 0)
        {
                val_21 = 1f - val_21;
            val_20 = (val_21 + val_21) + 1f;
        }
        
        if(val_21 > 1.3f)
        {
                float val_12 = 1.3f - val_21;
            val_21 = val_21 + 1f;
            val_12 = val_12 + val_12;
            val_21 = val_21 + (-1.3f);
            val_20 = val_12 + 1f;
        }
        
        UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  val_21, y:  val_21, z:  1f);
        this.FTUXHand.transform.localScale = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
        PluginExtension.SetColorAlpha(graphic:  this.FTUXHand.GetComponent<UnityEngine.UI.Image>(), a:  val_20);
        if(this.curveTime <= 1.7f)
        {
                return;
        }
        
        this.curveTime = -0.4f;
    }
    public void EndFTUX()
    {
        this.<ftux>k__BackingField = false;
        this.enabled = false;
        this.FTUXText.enabled = false;
        this.HideHand();
    }
    public void SetLevel(int lev)
    {
        if(lev == 1)
        {
            goto label_0;
        }
        
        if(lev != 0)
        {
            goto label_1;
        }
        
        this.ftuxPhase = 0;
        this.<ftux>k__BackingField = true;
        this.enabled = true;
        return;
        label_0:
        this.ftuxPhase = 3;
        this.<ftux>k__BackingField = true;
        this.enabled = lev;
        return;
        label_1:
        this.EndFTUX();
    }
    public bool IsFtuxLevel(int lev)
    {
        return (bool)(lev < 2) ? 1 : 0;
    }
    public int GetFtuxLevelSize(int lev)
    {
        return 6;
    }
    public float GetFtuxLevelTime(int lev)
    {
        return 30f;
    }
    public SLC.Minigames.WordFill.WordFillLevel GetFtuxLevel(int lev)
    {
        return (SLC.Minigames.WordFill.WordFillLevel)new SLC.Minigames.WordFill.WordFillFtuxLevel(lev:  lev);
    }
    public string GetFtuxLevelCategory(int lev)
    {
        return (string)(lev == 0) ? "Colors" : "Birds";
    }
    public void FtuxProceed()
    {
        if((this.<ftux>k__BackingField) == false)
        {
                return;
        }
        
        int val_5 = this.ftuxPhase;
        val_5 = val_5 + 1;
        this.ftuxPhase = val_5;
        this.FTUXText.gameObject.SetActive(value:  false);
        this.HideHand();
        if(this.ftuxPhase < this.ftuxMessages.Length)
        {
                SLC.Minigames.WordFill.WordFillUIController val_2 = MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance;
            val_2.overlay = true;
            UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.ShowFTUXElements());
            return;
        }
        
        this.EndFTUX();
    }
    public string RequiredFtuxAnswer()
    {
        var val_2;
        var val_3;
        if((this.<ftux>k__BackingField) == false)
        {
            goto label_1;
        }
        
        if(this.ftuxPhase == 2)
        {
            goto label_2;
        }
        
        if(this.ftuxPhase != 1)
        {
                return (string)(this.ftuxPhase == 4) ? "HOW" : 0;
        }
        
        val_2 = "RED";
        return (string)(this.ftuxPhase == 4) ? "HOW" : 0;
        label_1:
        val_3 = 0;
        return (string)(this.ftuxPhase == 4) ? "HOW" : 0;
        label_2:
        val_2 = "TAN";
        return (string)(this.ftuxPhase == 4) ? "HOW" : 0;
    }
    private System.Collections.IEnumerator ShowFTUXElements()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordFillFTUXManager.<ShowFTUXElements>d__29();
    }
    public void ShowHand(UnityEngine.Transform one, UnityEngine.Transform two, UnityEngine.Transform three)
    {
        UnityEngine.Vector3 val_1 = one.position;
        this.x1 = val_1.x;
        UnityEngine.Vector3 val_2 = two.position;
        this.x2 = val_2.x;
        UnityEngine.Vector3 val_3 = three.position;
        this.x3 = val_3.x;
        UnityEngine.Vector3 val_4 = one.position;
        this.y1 = val_4.y;
        UnityEngine.Vector3 val_5 = two.position;
        this.y2 = val_5.y;
        UnityEngine.Vector3 val_6 = three.position;
        this.y3 = val_6.y;
        UnityEngine.Vector3 val_8 = one.position;
        this.FTUXHand.transform.position = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        this.FTUXHand.SetActive(value:  true);
        this.curveTime = -0.4f;
        this.animatingCurve = true;
    }
    public void HideHand()
    {
        this.FTUXHand.SetActive(value:  false);
        this.animatingCurve = false;
    }
    public WordFillFTUXManager()
    {
        int val_3;
        string[] val_1 = new string[5];
        val_3 = val_1.Length;
        val_1[0] = "";
        val_3 = val_1.Length;
        val_1[1] = "Find words that match the theme";
        val_3 = val_1.Length;
        val_1[2] = "Complete levels by finding every word";
        val_3 = val_1.Length;
        val_1[3] = "";
        val_3 = val_1.Length;
        val_1[4] = "Extra words award more time!";
        this.ftuxMessages = val_1;
        this.ftuxLetterPos = new int[30] {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 0, 2, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1};
    }

}
