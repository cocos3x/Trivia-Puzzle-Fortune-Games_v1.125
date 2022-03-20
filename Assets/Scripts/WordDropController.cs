using UnityEngine;
public class WordDropController : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject wordScoop;
    private UnityEngine.RectTransform wordScoopArea;
    public UnityEngine.Transform killTransform;
    private UnityEngine.Transform dropHolder;
    private UnityEngine.Sprite[] scoopSprites;
    private RandomSet randomSet;
    private int counter;
    private string[] myWords;
    private float timer;
    private float nextTime;
    private bool hasStarted;
    private WordDropFTUXManager ftuxManager;
    private int ftuxCounter;
    
    // Methods
    public void BeginDrops()
    {
        this.myWords = MonoSingleton<WordDropManager>.Instance.GetNextLevelData();
        this.randomSet.addIntRange(lowest:  0, highest:  val_2.Length - 1);
        this.hasStarted = true;
        this.timer = 0f;
        this.nextTime = 5f;
    }
    public void ResetDrops()
    {
        this.ftuxCounter = 0;
        this.myWords = MonoSingleton<WordDropManager>.Instance.GetNextLevelData();
        this.counter = 0;
        this.nextTime = 5f;
        this.randomSet.clear();
        this.randomSet.addIntRange(lowest:  0, highest:  this.myWords.Length - 1);
    }
    private void Update()
    {
        float val_13;
        if(this.hasStarted == false)
        {
                return;
        }
        
        WordDropManager val_1 = MonoSingleton<WordDropManager>.Instance;
        if(val_1.isPaused == true)
        {
                return;
        }
        
        float val_2 = UnityEngine.Time.deltaTime;
        val_2 = this.timer + val_2;
        this.timer = val_2;
        if(val_2 <= this.nextTime)
        {
                return;
        }
        
        if(this.ftuxManager.ftux == false)
        {
            goto label_8;
        }
        
        this.CreateWordScoop();
        val_13 = (MonoSingleton<WordDropManager>.Instance.LevelSpeed) * 0.5f;
        float val_7 = UnityEngine.Random.Range(min:  val_13, max:  MonoSingleton<WordDropManager>.Instance.LevelSpeed);
        goto label_13;
        label_8:
        WordDropManager val_8 = MonoSingleton<WordDropManager>.Instance;
        if(val_8.playerScoops != 1)
        {
            goto label_17;
        }
        
        MonoSingleton<WordDropFTUXManager>.Instance.SecondLevelFTUX();
        this.CreateIncorrectFTUXScoop();
        goto label_21;
        label_17:
        WordDropManager val_10 = MonoSingleton<WordDropManager>.Instance;
        if(val_10.playerScoops > 0)
        {
            goto label_25;
        }
        
        this.CreateCorrectFTUXScoop();
        label_21:
        val_13 = 7f;
        label_13:
        this.nextTime = val_13;
        label_25:
        int val_13 = this.counter;
        this.timer = 0f;
        val_13 = val_13 + 1;
        this.counter = val_13;
        if(val_13 < 4)
        {
                return;
        }
        
        this.myWords = MonoSingleton<WordDropManager>.Instance.GetNextLevelData();
        this.counter = 0;
        this.randomSet.reset();
    }
    public void CreateIncorrectFTUXScoop()
    {
        UnityEngine.Rect val_2 = this.wordScoopArea.rect;
        UnityEngine.Rect val_4 = this.wordScoopArea.rect;
        UnityEngine.Vector3 val_8 = this.wordScoopArea.transform.position;
        UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  UnityEngine.Random.Range(min:  val_2.m_XMin.xMin, max:  val_4.m_XMin.xMax), y:  val_8.y, z:  0f);
        UnityEngine.Quaternion val_10 = UnityEngine.Quaternion.identity;
        UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.wordScoop, position:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, rotation:  new UnityEngine.Quaternion() {x = val_10.x, y = val_10.y, z = val_10.z, w = val_10.w}, parent:  this.dropHolder).GetComponent<WordScoopBehavior>().SetScoop(newSpeed:  MonoSingleton<WordDropManager>.Instance.LevelSpeed, newWord:  this.myWords[0], status:  false, newSprite:  this.scoopSprites[UnityEngine.Random.Range(min:  0, max:  this.scoopSprites.Length)]);
        UnityEngine.Debug.Log(message:  "FTUX incorrect word: "("FTUX incorrect word: ") + this.myWords[0]);
    }
    public void CreateCorrectFTUXScoop()
    {
        int val_17 = this.ftuxCounter;
        val_17 = val_17 + 1;
        this.ftuxCounter = val_17;
        UnityEngine.Rect val_2 = this.wordScoopArea.rect;
        UnityEngine.Rect val_4 = this.wordScoopArea.rect;
        UnityEngine.Vector3 val_8 = this.wordScoopArea.transform.position;
        UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  UnityEngine.Random.Range(min:  val_2.m_XMin.xMin, max:  val_4.m_XMin.xMax), y:  val_8.y, z:  0f);
        UnityEngine.Quaternion val_10 = UnityEngine.Quaternion.identity;
        UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.wordScoop, position:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, rotation:  new UnityEngine.Quaternion() {x = val_10.x, y = val_10.y, z = val_10.z, w = val_10.w}, parent:  this.dropHolder).GetComponent<WordScoopBehavior>().SetScoop(newSpeed:  MonoSingleton<WordDropManager>.Instance.LevelSpeed, newWord:  this.myWords[this.ftuxCounter], status:  (this.ftuxCounter != 0) ? 1 : 0, newSprite:  this.scoopSprites[UnityEngine.Random.Range(min:  0, max:  this.scoopSprites.Length)]);
        UnityEngine.Debug.Log(message:  "FTUX correct word: "("FTUX correct word: ") + this.myWords[this.ftuxCounter]);
    }
    public void CreateWordScoop()
    {
        int val_2 = this.randomSet.roll(unweighted:  false);
        UnityEngine.Rect val_3 = this.wordScoopArea.rect;
        UnityEngine.Rect val_5 = this.wordScoopArea.rect;
        UnityEngine.Vector3 val_9 = this.wordScoopArea.transform.position;
        UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  UnityEngine.Random.Range(min:  val_3.m_XMin.xMin, max:  val_5.m_XMin.xMax), y:  val_9.y, z:  0f);
        UnityEngine.Quaternion val_11 = UnityEngine.Quaternion.identity;
        UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.wordScoop, position:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, rotation:  new UnityEngine.Quaternion() {x = val_11.x, y = val_11.y, z = val_11.z, w = val_11.w}, parent:  this.dropHolder).GetComponent<WordScoopBehavior>().SetScoop(newSpeed:  MonoSingleton<WordDropManager>.Instance.LevelSpeed, newWord:  this.myWords[val_2], status:  (val_2 != 0) ? 1 : 0, newSprite:  this.scoopSprites[UnityEngine.Random.Range(min:  0, max:  this.scoopSprites.Length)]);
    }
    public WordDropController()
    {
        this.randomSet = new RandomSet();
    }

}
