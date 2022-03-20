using UnityEngine;

namespace SLC.Minigames.SnackBlock
{
    public class SnakeBlockController : MonoBehaviour
    {
        // Fields
        private UnityEngine.Camera snakeBlockCamera;
        public int ticksPerTail;
        private System.Collections.Generic.List<UnityEngine.Vector3> prevXPos;
        private System.Collections.Generic.List<UnityEngine.GameObject> myTails;
        private int _livesUsed;
        private UnityEngine.GameObject tailPrefab;
        private float speed;
        private float cachedSpeed;
        private float startingXPos;
        private float startingXPixelPos;
        private bool alreadyTouching;
        private float minXValue;
        private float maxXValue;
        private float _liveDeductionInterval;
        private System.Collections.IEnumerator losingLife;
        private SLC.Minigames.SnackBlock.SnakeBlockBlock curCollidingWith;
        private UnityEngine.RaycastHit2D[] hitStuff;
        private UnityEngine.RaycastHit2D[] hitStuffVert;
        private bool hittingBlock;
        private int startingLifes;
        private float removeTailProgress;
        private UnityEngine.Transform tailparent;
        private bool resetting;
        private bool usePhysTails;
        private float snakeRadius;
        private UnityEngine.GameObject tailDeathParticles;
        private float worldWidth;
        private float worldMin;
        private float worldMax;
        private SLC.Minigames.SnackBlock.SnakeBlockBlock currentForwardCollisionBlock;
        private float cameraYOffset;
        private float xInputThisFrame;
        private UnityEngine.Rigidbody2D myRigidBody2D;
        
        // Properties
        private int livesRemaining { get; }
        public int LivesUsed { get; }
        private float liveDeductionInterval { get; }
        
        // Methods
        private int get_livesRemaining()
        {
            return 26336;
        }
        public int get_LivesUsed()
        {
            return (int)this._livesUsed;
        }
        private float get_liveDeductionInterval()
        {
            twelvegigs.storage.JsonDictionary val_6;
            float val_7;
            if(this._liveDeductionInterval > 0f)
            {
                    return val_7;
            }
            
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_6 = val_1.currentKnobsData;
            if((val_6.Contains(key:  "econ")) != false)
            {
                    val_6 = val_6.getJsonDictionary(key:  "econ");
            }
            
            if((val_6.Contains(key:  "ctt")) != false)
            {
                    val_7 = this._liveDeductionInterval;
                float val_5 = val_6.getFloat(key:  "ctt", defaultValue:  val_7);
            }
            else
            {
                    val_7 = 0.33f;
            }
            
            this._liveDeductionInterval = val_7;
            return val_7;
        }
        private void Start()
        {
            float val_1 = this.snakeBlockCamera.aspect;
            val_1 = 0.5625f / val_1;
            val_1 = val_1 * 5.5f;
            this.snakeBlockCamera.orthographicSize = val_1;
            UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 val_3 = this.snakeBlockCamera.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            this.minXValue = val_3.x;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
            UnityEngine.Vector3 val_5 = this.snakeBlockCamera.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
            this.maxXValue = val_5.x;
            float val_20 = this.snakeRadius;
            this.myRigidBody2D = this.GetComponent<UnityEngine.Rigidbody2D>();
            val_20 = val_20 + val_20;
            UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  val_20, y:  val_20);
            this.gameObject.GetComponent<UnityEngine.BoxCollider2D>().size = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
            this.gameObject.GetComponent<UnityEngine.SpriteRenderer>().size = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
            UnityEngine.Vector3 val_12 = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 val_13 = this.snakeBlockCamera.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
            this.worldMin = val_13.x;
            UnityEngine.Vector3 val_15 = new UnityEngine.Vector3(x:  (float)UnityEngine.Screen.width, y:  0f, z:  0f);
            UnityEngine.Vector3 val_16 = this.snakeBlockCamera.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z});
            this.worldMax = val_16.x;
            val_16.x = val_16.x - this.worldMin;
            this.worldWidth = val_16.x;
            SLC.Minigames.SnackBlock.SnakeBlockManager val_17 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            System.Delegate val_19 = System.Delegate.Combine(a:  val_17.uiCont.dragInput.HandleDragAction, b:  new System.Action<System.Single>(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockController::HandleHorizInput(float screenDragAmount)));
            if(val_19 != null)
            {
                    if(null != null)
            {
                goto label_19;
            }
            
            }
            
            val_17.uiCont.dragInput.HandleDragAction = val_19;
            return;
            label_19:
        }
        public void Init(bool reset)
        {
            int val_15;
            this.prevXPos = new System.Collections.Generic.List<UnityEngine.Vector3>();
            this.enabled = true;
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
            this.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
            if(reset != false)
            {
                    val_15 = this.startingLifes;
            }
            else
            {
                    val_15 = this.myTails + 24;
            }
            
            this.myTails.Clear();
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.tailparent);
            if(null >= 1)
            {
                    do
            {
                this.AddTail();
                System.Collections.Generic.List<UnityEngine.GameObject> val_4 = 1152921504687730688 - 1;
            }
            while(null != 1);
            
            }
            
            if(reset != false)
            {
                    this._livesUsed = 0;
            }
            
            this.removeTailProgress = this.liveDeductionInterval;
            float val_7 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.getSpeedForLevel;
            this.speed = val_7;
            this.cachedSpeed = val_7;
            UnityEngine.Vector3 val_10 = this.transform.position;
            UnityEngine.Vector3 val_12 = this.snakeBlockCamera.transform.position;
            UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  0f, y:  val_10.y + this.cameraYOffset, z:  val_12.z);
            this.snakeBlockCamera.transform.position = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
        }
        public System.Collections.IEnumerator Continue()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new SnakeBlockController.<Continue>d__41();
        }
        private void FixedUpdate()
        {
            System.Collections.Generic.List<UnityEngine.GameObject> val_24;
            SLC.Minigames.SnackBlock.SnakeBlockManager val_1 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            if(val_1.isPaused == true)
            {
                    return;
            }
            
            UnityEngine.Vector2 val_2 = this.DesiredXMovementVector(xInput:  this.xInputThisFrame);
            UnityEngine.Vector2 val_3 = this.DesiredYMovementVector();
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y}, b:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
            UnityEngine.Vector2 val_5 = this.myRigidBody2D.position;
            UnityEngine.Vector2 val_6 = val_4.x.normalized;
            UnityEngine.Vector2 val_7 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y}, d:  4f);
            UnityEngine.Vector2 val_8 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y}, b:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
            UnityEngine.Vector2 val_9 = UnityEngine.Vector2.up;
            UnityEngine.Vector2 val_10 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y}, b:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y});
            UnityEngine.Vector2 val_11 = this.myRigidBody2D.position;
            UnityEngine.Vector2 val_12 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_10.x, y = val_10.y}, b:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y});
            UnityEngine.Vector3 val_13 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y});
            float val_25 = val_13.y;
            float val_24 = val_25;
            val_24 = val_24 * 57.29578f;
            val_25 = val_24 + 0f;
            float val_27 = -90f;
            float val_26 = 7f;
            val_26 = UnityEngine.Time.fixedDeltaTime * val_26;
            val_27 = val_25 + val_27;
            this.myRigidBody2D.MoveRotation(angle:  UnityEngine.Mathf.LerpAngle(a:  this.myRigidBody2D.rotation, b:  val_27, t:  val_26));
            UnityEngine.Vector2 val_17 = this.myRigidBody2D.position;
            UnityEngine.Vector2 val_18 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y}, b:  new UnityEngine.Vector2() {x = val_17.x, y = val_17.y});
            this.myRigidBody2D.MovePosition(position:  new UnityEngine.Vector2() {x = val_18.x, y = val_18.y});
            this.xInputThisFrame = 0f;
            this.CalcuateTailStuff();
            if(this.usePhysTails != false)
            {
                    return;
            }
            
            if(this.myTails == null)
            {
                    if(this.ticksPerTail < 0)
            {
                    return;
            }
            
            }
            
            UnityEngine.Vector3 val_20 = this.transform.position;
            this.prevXPos.Insert(index:  0, item:  new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z});
            val_24 = this.myTails;
            if((public System.Void System.Collections.Generic.List<UnityEngine.Vector3>::Insert(int index, UnityEngine.Vector3 item)) == 0)
            {
                    return;
            }
            
            if(1152921519897898656 >= 1)
            {
                    var val_31 = 0;
                do
            {
                System.Collections.Generic.List<UnityEngine.Vector3> val_29 = this.prevXPos;
                int val_28 = this.ticksPerTail;
                val_28 = val_28 * val_31;
                val_29 = val_29 - 1;
                if(val_28 <= val_29)
            {
                    if(val_31 >= 1152921519897898656)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                int val_30 = this.ticksPerTail;
                int val_22 = val_30 * val_31;
                if(val_29 <= val_22)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_30 = val_30 + ((long)val_22 * 12);
                transform.position = new UnityEngine.Vector3() {x = ((long)(int)((this.ticksPerTail * 0)) * 12) + this.ticksPerTail + 32, y = ((long)(int)((this.ticksPerTail * 0)) * 12) + this.ticksPerTail + 32 + 4, z = ((long)(int)((this.ticksPerTail * 0)) * 12) + this.ticksPerTail + 40};
                val_24 = this.myTails;
            }
            
                val_31 = val_31 + 1;
            }
            while(val_31 < val_30);
            
            }
            
            val_30 = this.ticksPerTail * val_30;
            if((long)val_22 <= val_30)
            {
                    return;
            }
            
            this.prevXPos.RemoveAt(index:  (long)val_22 - 1);
        }
        private UnityEngine.Vector2 DesiredYMovementVector()
        {
            SLC.Minigames.SnackBlock.SnakeBlockManager val_1 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            if(val_1.isPaused != false)
            {
                    return UnityEngine.Vector2.zero;
            }
            
            if(this.speed == 0f)
            {
                    return UnityEngine.Vector2.zero;
            }
            
            if(this.ForwardCollision() == true)
            {
                    return UnityEngine.Vector2.zero;
            }
            
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.up;
            float val_6 = this.speed;
            val_6 = 1f / val_6;
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, d:  val_6);
            return UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y}, d:  UnityEngine.Time.fixedDeltaTime);
        }
        private UnityEngine.Vector2 DesiredXMovementVector(float xInput)
        {
            float val_30;
            float val_35;
            float val_36;
            var val_37;
            val_30 = xInput;
            SLC.Minigames.SnackBlock.SnakeBlockManager val_1 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            if(val_1.isPaused != false)
            {
                    UnityEngine.Vector2 val_2 = UnityEngine.Vector2.zero;
                return new UnityEngine.Vector2() {x = val_25.x, y = val_25.y};
            }
            
            float val_26 = this.worldWidth;
            val_26 = val_26 * val_30;
            UnityEngine.Vector3 val_4 = this.transform.position;
            this.startingXPos = val_4.x;
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.zero;
            if(val_26 > 0f)
            {
                    UnityEngine.Vector2 val_6 = UnityEngine.Vector2.right;
            }
            else
            {
                    UnityEngine.Vector2 val_7 = UnityEngine.Vector2.left;
            }
            
            UnityEngine.Vector3 val_9 = this.transform.position;
            UnityEngine.Vector2 val_10 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
            val_35 = this.worldMin + this.snakeRadius;
            val_36 = this.worldMax - this.snakeRadius;
            int val_11 = UnityEngine.Physics2D.CircleCastNonAlloc(origin:  new UnityEngine.Vector2() {x = val_10.x, y = val_10.y}, radius:  this.snakeRadius, direction:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y}, results:  this.hitStuff, distance:  Infinityf);
            if(val_11 < 1)
            {
                goto label_41;
            }
            
            val_37 = 0;
            var val_28 = 32;
            label_34:
            if((this.hitStuff[val_28].transform.GetComponent<SLC.Minigames.SnackBlock.SnakeBlockBlock>()) == 0)
            {
                goto label_28;
            }
            
            SLC.Minigames.SnackBlock.SnakeBlockBlock val_16 = this.hitStuff[val_28].transform.GetComponent<SLC.Minigames.SnackBlock.SnakeBlockBlock>();
            SLC.Minigames.SnackBlock.SnakeGridSpaceType val_27 = val_16.myType;
            val_27 = val_27 | 2;
            if(val_27 == 3)
            {
                goto label_33;
            }
            
            label_28:
            val_37 = val_37 + 1;
            val_28 = val_28 + 36;
            if(val_37 < (long)val_11)
            {
                goto label_34;
            }
            
            goto label_41;
            label_33:
            UnityEngine.Vector2 val_17 = UnityEngine.Vector2.right;
            if((val_7.x.Equals(other:  new UnityEngine.Vector2() {x = val_17.x, y = val_17.y})) != false)
            {
                    UnityEngine.Vector2 val_19 = this.hitStuff[val_28].point;
                float val_29 = val_7.x;
                val_29 = val_29 * this.snakeRadius;
                val_36 = val_19.x - val_29;
            }
            else
            {
                    UnityEngine.Vector2 val_20 = this.hitStuff[val_28].point;
                float val_30 = val_7.x;
                val_30 = val_30 * this.snakeRadius;
                val_35 = val_20.x - val_30;
            }
            
            label_41:
            val_30 = UnityEngine.Mathf.Clamp(value:  val_26 + val_4.x, min:  val_35, max:  val_36);
            UnityEngine.Vector3 val_24 = this.transform.position;
            val_24.x = val_30 - val_24.x;
            UnityEngine.Vector2 val_25 = new UnityEngine.Vector2(x:  val_24.x, y:  0f);
            return new UnityEngine.Vector2() {x = val_25.x, y = val_25.y};
        }
        private void Update()
        {
            SLC.Minigames.SnackBlock.SnakeBlockManager val_1 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            if(val_1.isPaused == true)
            {
                    return;
            }
            
            if((UnityEngine.Input.GetKeyDown(key:  116)) == false)
            {
                    return;
            }
            
            this.AddTail();
        }
        private void LateUpdate()
        {
            SLC.Minigames.SnackBlock.SnakeBlockManager val_1 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            if(val_1.isPaused == true)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_4 = this.transform.position;
            UnityEngine.Vector3 val_6 = this.snakeBlockCamera.transform.position;
            UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  0f, y:  val_4.y + this.cameraYOffset, z:  val_6.z);
            this.snakeBlockCamera.transform.position = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        }
        private void HandleHorizInput(float screenDragAmount)
        {
            this.xInputThisFrame = screenDragAmount;
        }
        private bool ForwardCollision()
        {
            var val_13;
            var val_14;
            var val_15;
            this.currentForwardCollisionBlock = 0;
            UnityEngine.Vector3 val_2 = this.transform.position;
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.up;
            float val_13 = 1f;
            val_13 = val_13 / this.speed;
            int val_7 = UnityEngine.Physics2D.CircleCastNonAlloc(origin:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, radius:  this.snakeRadius, direction:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y}, results:  this.hitStuffVert, distance:  val_13 * UnityEngine.Time.fixedDeltaTime);
            if(val_7 < 1)
            {
                goto label_6;
            }
            
            val_13 = 0;
            val_14 = 32;
            label_18:
            if((this.hitStuffVert[val_14].transform.GetComponent<SLC.Minigames.SnackBlock.SnakeBlockBlock>()) == 0)
            {
                goto label_12;
            }
            
            this.currentForwardCollisionBlock = this.hitStuffVert[val_14].transform.GetComponent<SLC.Minigames.SnackBlock.SnakeBlockBlock>();
            SLC.Minigames.SnackBlock.SnakeGridSpaceType val_14 = val_12.myType;
            val_14 = val_14 - 1;
            if(val_14 < 3)
            {
                goto label_17;
            }
            
            this.currentForwardCollisionBlock = 0;
            label_12:
            val_13 = val_13 + 1;
            val_14 = val_14 + 36;
            if(val_13 < (long)val_7)
            {
                goto label_18;
            }
            
            label_6:
            val_15 = 0;
            this.speed = this.cachedSpeed;
            return (bool)val_15;
            label_17:
            val_15 = 1;
            return (bool)val_15;
        }
        private void CalcuateTailStuff()
        {
            float val_23;
            if(this.resetting == true)
            {
                    return;
            }
            
            if(this.currentForwardCollisionBlock == 0)
            {
                    this.removeTailProgress = this.liveDeductionInterval;
                return;
            }
            
            SLC.Minigames.SnackBlock.SnakeGridSpaceType val_23 = this.currentForwardCollisionBlock.myType;
            if(val_23 == 2)
            {
                    label_37:
                this.OnWordBlockCollision();
                this.currentForwardCollisionBlock.transform.parent.gameObject.SetActive(value:  false);
            }
            else
            {
                    val_23 = this.removeTailProgress + UnityEngine.Time.deltaTime;
                this.removeTailProgress = val_23;
                if((val_23 >= this.liveDeductionInterval) && (val_23 >= 1))
            {
                    this.removeTailProgress = 0f;
                if(val_23 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_23 = val_23 + ((val_23 - 1) << 3);
                UnityEngine.Vector3 val_10 = this.myTails.transform.position;
                val_23 = val_10.x;
                UnityEngine.Quaternion val_12 = this.myTails.transform.rotation;
                UnityEngine.GameObject val_13 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.tailDeathParticles, position:  new UnityEngine.Vector3() {x = val_23, y = val_10.y, z = val_10.z}, rotation:  new UnityEngine.Quaternion() {x = val_12.x, y = val_12.y, z = val_12.z, w = val_12.w});
                bool val_14 = this.myTails.Remove(item:  this.myTails);
                int val_24 = this._livesUsed;
                val_24 = val_24 + 1;
                this._livesUsed = val_24;
                UnityEngine.Object.Destroy(obj:  this.myTails.gameObject);
                MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Collision", clipIndex:  0, volumeScale:  1f);
                if(this.livesRemaining <= 0)
            {
                    this.enabled = false;
                MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.HandleFailed();
                if(this.currentForwardCollisionBlock.myType != 3)
            {
                    this.currentForwardCollisionBlock.transform.parent.gameObject.SetActive(value:  false);
            }
            
            }
            
                if(this.currentForwardCollisionBlock.myType == 3)
            {
                    if(this.currentForwardCollisionBlock.RemoveLastLetter() == true)
            {
                goto label_37;
            }
            
            }
            
            }
            
            }
            
            this.currentForwardCollisionBlock = 0;
        }
        private void OnTriggerEnter2D(UnityEngine.Collider2D col)
        {
            if((col.gameObject.GetComponent<SLC.Minigames.SnackBlock.SnakeBlockBlock>()) == 0)
            {
                    return;
            }
            
            this.curCollidingWith = col.gameObject.GetComponent<SLC.Minigames.SnackBlock.SnakeBlockBlock>();
            if(val_5.myType == 4)
            {
                goto label_8;
            }
            
            if(val_5.myType != 3)
            {
                    if(val_5.myType != 2)
            {
                    return;
            }
            
            }
            
            this = 1152921504893161472;
            SLC.Minigames.SnackBlock.SnakeBlockManager val_6 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            if(val_6.hasFTUXCollided == false)
            {
                goto label_14;
            }
            
            return;
            label_8:
            col.gameObject.SetActive(value:  false);
            this.AddTail();
            return;
            label_14:
            MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.DisableAvoidText();
        }
        private void OnWordBlockCollision()
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "CorrectWord", clipIndex:  0, volumeScale:  1f);
            MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.HandleComplete();
            float val_4 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance.getSpeedForLevel;
            this.speed = val_4;
            this.cachedSpeed = val_4;
        }
        private void AddTail()
        {
            System.Collections.Generic.List<UnityEngine.GameObject> val_26;
            var val_27;
            System.Collections.Generic.List<UnityEngine.GameObject> val_28;
            val_26 = this;
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "AddTail", clipIndex:  0, volumeScale:  1f);
            float val_25 = this.snakeRadius;
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.tailPrefab, parent:  this.tailparent);
            float val_3 = val_25 * 0.75f;
            UnityEngine.SpriteRenderer val_4 = val_2.GetComponent<UnityEngine.SpriteRenderer>();
            val_25 = val_3 + val_3;
            UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  val_25, y:  val_25);
            val_4.size = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
            val_2.GetComponent<UnityEngine.CircleCollider2D>().radius = val_3;
            this.myTails.Add(item:  val_2);
            val_2.GetComponent<UnityEngine.SpriteRenderer>().sortingOrder = ~this.myTails;
            System.Collections.Generic.List<UnityEngine.GameObject> val_26 = this.myTails;
            val_27 = val_2.transform;
            if(val_4 == 1)
            {
                    if(this.transform != null)
            {
                goto label_14;
            }
            
            }
            
            if(val_26 <= 1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_26 = val_26 + ((val_26 - 2) << 3);
            label_14:
            UnityEngine.Vector3 val_12 = 0.transform.position;
            UnityEngine.Vector3 val_13 = UnityEngine.Vector3.down;
            UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, d:  val_25);
            UnityEngine.Vector3 val_15 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, b:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
            val_27.position = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
            if(this.usePhysTails == false)
            {
                    return;
            }
            
            UnityEngine.Rigidbody2D val_16 = val_2.AddComponent<UnityEngine.Rigidbody2D>();
            val_27 = val_16;
            val_16.drag = 1000f;
            val_27.angularDrag = 0f;
            val_27.gravityScale = 0f;
            val_28 = this.myTails;
            if(W9 >= 1)
            {
                    UnityEngine.DistanceJoint2D val_17 = val_2.AddComponent<UnityEngine.DistanceJoint2D>();
                val_27 = val_17;
                val_17.maxDistanceOnly = true;
                val_27.autoConfigureDistance = false;
                val_27.autoConfigureConnectedAnchor = false;
                UnityEngine.Vector2 val_18 = UnityEngine.Vector2.zero;
                val_27.anchor = new UnityEngine.Vector2() {x = val_18.x, y = val_18.y};
                UnityEngine.Vector2 val_19 = UnityEngine.Vector2.zero;
                val_27.connectedAnchor = new UnityEngine.Vector2() {x = val_19.x, y = val_19.y};
                float val_27 = (float)val_19.x;
                val_27 = val_25 * val_27;
                val_27.distance = val_27;
                val_27.connectedBody = this.GetComponent<UnityEngine.Rigidbody2D>();
                val_28 = this.myTails;
            }
            
            if(val_28 <= 1)
            {
                    return;
            }
            
            UnityEngine.DistanceJoint2D val_21 = val_2.AddComponent<UnityEngine.DistanceJoint2D>();
            val_21.maxDistanceOnly = true;
            val_21.autoConfigureDistance = false;
            val_21.autoConfigureConnectedAnchor = false;
            UnityEngine.Vector2 val_22 = UnityEngine.Vector2.zero;
            val_21.anchor = new UnityEngine.Vector2() {x = val_22.x, y = val_22.y};
            UnityEngine.Vector2 val_23 = UnityEngine.Vector2.zero;
            val_21.connectedAnchor = new UnityEngine.Vector2() {x = val_23.x, y = val_23.y};
            val_21.distance = val_25;
            val_26 = this.myTails;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_21.connectedBody = (UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + ((UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished - 2)) << 3) + 32.GetComponent<UnityEngine.Rigidbody2D>();
        }
        public SnakeBlockController()
        {
            this.ticksPerTail = 10;
            this.prevXPos = new System.Collections.Generic.List<UnityEngine.Vector3>();
            this.myTails = new System.Collections.Generic.List<UnityEngine.GameObject>();
            this.speed = 0.02f;
            this._liveDeductionInterval = -1f;
            this.hitStuff = new UnityEngine.RaycastHit2D[10];
            this.hitStuffVert = new UnityEngine.RaycastHit2D[10];
            this.startingLifes = 3;
            this.usePhysTails = true;
            this.snakeRadius = 0.3f;
            this.cameraYOffset = -3f;
        }
    
    }

}
