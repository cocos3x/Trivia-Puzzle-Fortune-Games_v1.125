using UnityEngine;

namespace SLC.Minigames.WordDrop
{
    public class IceCreamController : MonoBehaviour
    {
        // Fields
        private System.Collections.Generic.List<UnityEngine.GameObject> myTails;
        private UnityEngine.GameObject tailPrefab;
        private float startingXPos;
        private float startingXPixelPos;
        private bool alreadyTouching;
        private float minXValue;
        private float maxXValue;
        private WordScoopBehavior curCollidingWith;
        private UnityEngine.Transform tailparent;
        private UnityEngine.GameObject coneObject;
        private bool usePhysTails;
        private float worldWidth;
        private float worldMin;
        private float worldMax;
        
        // Methods
        private void Awake()
        {
            this.InitCone();
        }
        private void Start()
        {
            UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 val_3 = UnityEngine.Camera.main.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            this.minXValue = val_3.x;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
            UnityEngine.Vector3 val_6 = UnityEngine.Camera.main.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
            this.maxXValue = val_6.x;
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 val_9 = UnityEngine.Camera.main.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
            this.worldMin = val_9.x;
            UnityEngine.Vector3 val_12 = new UnityEngine.Vector3(x:  (float)UnityEngine.Screen.width, y:  0f, z:  0f);
            UnityEngine.Vector3 val_13 = UnityEngine.Camera.main.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
            this.worldMax = val_13.x;
            val_13.x = val_13.x - this.worldMin;
            this.worldWidth = val_13.x;
            WordDropUIController val_14 = MonoSingleton<WordDropUIController>.Instance;
            System.Delegate val_16 = System.Delegate.Combine(a:  val_14.inputEventsHandler.HandleDragAction, b:  new System.Action<System.Single>(object:  this, method:  System.Void SLC.Minigames.WordDrop.IceCreamController::HandleHorizInput(float screenDragAmount)));
            if(val_16 != null)
            {
                    if(null != null)
            {
                goto label_12;
            }
            
            }
            
            val_14.inputEventsHandler.HandleDragAction = val_16;
            return;
            label_12:
        }
        private void HandleHorizInput(float screenDragAmount)
        {
            float val_10 = screenDragAmount;
            WordDropManager val_1 = MonoSingleton<WordDropManager>.Instance;
            if(val_1.isPaused == true)
            {
                    return;
            }
            
            float val_3 = this.worldWidth * val_10;
            UnityEngine.Vector3 val_4 = this.transform.position;
            this.startingXPos = val_4.x;
            val_3 = val_3 + val_4.x;
            val_10 = UnityEngine.Mathf.Clamp(value:  val_3, min:  this.worldMin, max:  this.worldMax);
            UnityEngine.Vector3 val_8 = this.transform.position;
            UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  val_10, y:  val_8.y);
            this.transform.position = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        }
        private void InitCone()
        {
            UnityEngine.Rigidbody2D val_1 = this.coneObject.AddComponent<UnityEngine.Rigidbody2D>();
            UnityEngine.HingeJoint2D val_2 = this.coneObject.AddComponent<UnityEngine.HingeJoint2D>();
            val_1.drag = 0f;
            val_1.angularDrag = 30f;
            val_1.gravityScale = 3f;
            val_2.autoConfigureConnectedAnchor = false;
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
            val_2.anchor = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0f, y:  -0.5f);
            val_2.connectedAnchor = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
            val_2.connectedBody = this.GetComponent<UnityEngine.Rigidbody2D>();
        }
        public void Init(bool reset)
        {
            this.myTails.Clear();
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.tailparent);
            this.coneObject.GetComponent<UnityEngine.HingeJoint2D>().connectedBody = this.GetComponent<UnityEngine.Rigidbody2D>();
        }
        private void Update()
        {
            WordDropManager val_1 = MonoSingleton<WordDropManager>.Instance;
            if(val_1.isPaused == true)
            {
                    return;
            }
            
            if((UnityEngine.Input.GetKeyDown(key:  116)) == false)
            {
                    return;
            }
            
            this.AddTail(word:  this.myTails.ToString(), sprite:  0);
        }
        private void OnTriggerEnter2D(UnityEngine.Collider2D col)
        {
            WordScoopBehavior val_15 = col.gameObject.GetComponent<WordScoopBehavior>();
            if(val_15 == 0)
            {
                    return;
            }
            
            this.curCollidingWith = col.gameObject.GetComponent<WordScoopBehavior>();
            if(val_5.isCorrect != false)
            {
                    WordScoopBehavior val_7 = col.gameObject.GetComponent<WordScoopBehavior>();
                val_15 = val_7.word;
                this.AddTail(word:  val_15, sprite:  col.gameObject.GetComponent<WordScoopBehavior>().ScoopSprite);
                MonoSingleton<WordDropManager>.Instance.AddScoop();
                MonoSingleton<WordDropManager>.Instance.HandleLevelComplete();
            }
            else
            {
                    MonoSingleton<WordDropManager>.Instance.HandleFail();
            }
            
            UnityEngine.Object.Destroy(obj:  this.curCollidingWith.gameObject);
        }
        private void AddTail(string word, UnityEngine.Sprite sprite)
        {
            UnityEngine.Sprite val_19;
            var val_20;
            val_19 = sprite;
            val_20 = this;
            UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.tailPrefab, parent:  this.tailparent);
            this.myTails.Insert(index:  0, item:  val_1);
            UnityEngine.Vector3 val_4 = this.transform.position;
            val_1.transform.position = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
            val_1.GetComponentInChildren<TMPro.TextMeshPro>().text = word;
            val_1.GetComponent<UnityEngine.SpriteRenderer>().sprite = val_19;
            val_1.GetComponent<UnityEngine.SpriteRenderer>().sortingOrder = -1961158656;
            val_1.name = "tail " + this.myTails;
            if(this.usePhysTails == false)
            {
                    return;
            }
            
            UnityEngine.Rigidbody2D val_9 = val_1.AddComponent<UnityEngine.Rigidbody2D>();
            UnityEngine.HingeJoint2D val_10 = val_1.AddComponent<UnityEngine.HingeJoint2D>();
            val_9.drag = 0f;
            val_9.angularDrag = 30f;
            val_9.gravityScale = 3f;
            val_10.autoConfigureConnectedAnchor = false;
            UnityEngine.Vector2 val_11 = UnityEngine.Vector2.zero;
            val_10.anchor = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
            UnityEngine.Vector2 val_12 = new UnityEngine.Vector2(x:  0f, y:  0f);
            val_10.connectedAnchor = new UnityEngine.Vector2() {x = val_12.x, y = val_12.y};
            val_10.connectedBody = this.GetComponent<UnityEngine.Rigidbody2D>();
            if(1152921504619999232 >= 2)
            {
                    val_10.GetComponent<UnityEngine.HingeJoint2D>().connectedBody = val_9;
                if(this.myTails <= 1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                UnityEngine.Vector2 val_16 = new UnityEngine.Vector2(x:  0f, y:  -0.5f);
                0.GetComponent<UnityEngine.HingeJoint2D>().connectedAnchor = new UnityEngine.Vector2() {x = val_16.x, y = val_16.y};
            }
            
            val_20 = this.coneObject.GetComponent<UnityEngine.HingeJoint2D>();
            val_19 = 44454607;
            if((public UnityEngine.HingeJoint2D UnityEngine.GameObject::GetComponent<UnityEngine.HingeJoint2D>()) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_20.connectedBody = mem[400091496].GetComponent<UnityEngine.Rigidbody2D>();
        }
        public void DeleteWordScoops()
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.BreakJoints());
        }
        private System.Collections.IEnumerator BreakJoints()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new IceCreamController.<BreakJoints>d__23();
        }
        public IceCreamController()
        {
            this.myTails = new System.Collections.Generic.List<UnityEngine.GameObject>();
            this.usePhysTails = true;
        }
    
    }

}
