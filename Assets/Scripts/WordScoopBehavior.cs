using UnityEngine;
public class WordScoopBehavior : MonoBehaviour
{
    // Fields
    private TMPro.TextMeshPro myText;
    private UnityEngine.SpriteRenderer sr;
    private string word;
    private bool isCorrect;
    private float mySpeed;
    private float delta;
    private UnityEngine.Transform killPos;
    
    // Properties
    public string Word { get; }
    public UnityEngine.Sprite ScoopSprite { get; }
    public bool IsCorrect { get; }
    
    // Methods
    public string get_Word()
    {
        return (string)this.word;
    }
    public UnityEngine.Sprite get_ScoopSprite()
    {
        if(this.sr != null)
        {
                return this.sr.sprite;
        }
        
        throw new NullReferenceException();
    }
    public bool get_IsCorrect()
    {
        return (bool)this.isCorrect;
    }
    private void Start()
    {
        WordDropManager val_1 = MonoSingleton<WordDropManager>.Instance;
        this.killPos = val_1.wordDropController.killTransform;
    }
    public void SetScoop(float newSpeed, string newWord, bool status, UnityEngine.Sprite newSprite)
    {
        this.mySpeed = newSpeed;
        this.word = newWord;
        this.myText.text = newWord;
        this.isCorrect = status;
        this.sr.sprite = newSprite;
    }
    private void Update()
    {
        WordDropManager val_1 = MonoSingleton<WordDropManager>.Instance;
        if(val_1.isPaused == true)
        {
                return;
        }
        
        float val_2 = UnityEngine.Time.deltaTime;
        val_2 = this.delta + val_2;
        this.delta = val_2;
        UnityEngine.Vector3 val_4 = this.transform.position;
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  val_4.x, y:  UnityEngine.Mathf.Lerp(a:  5f, b:  -5.05f, t:  this.delta / this.mySpeed));
        UnityEngine.Vector3 val_9 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
        this.transform.position = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        if(val_7.y > (-5f))
        {
                return;
        }
        
        this.DestroyAndCheck();
    }
    private void DestroyAndCheck()
    {
        if(this.isCorrect != false)
        {
                MonoSingleton<WordDropManager>.Instance.HandleFail();
        }
        else
        {
                WordDropManager val_2 = MonoSingleton<WordDropManager>.Instance;
            if(val_2.playerScoops == 1)
        {
                UnityEngine.Debug.Log(message:  "FTUX done");
            MonoSingleton<WordDropFTUXManager>.Instance.EndFTUX();
        }
        
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public WordScoopBehavior()
    {
    
    }

}
