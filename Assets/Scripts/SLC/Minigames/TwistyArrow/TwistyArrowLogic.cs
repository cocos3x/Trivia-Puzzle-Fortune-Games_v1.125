using UnityEngine;

namespace SLC.Minigames.TwistyArrow
{
    public class TwistyArrowLogic : MonoSingleton<SLC.Minigames.TwistyArrow.TwistyArrowLogic>
    {
        // Fields
        private SLC.Minigames.TwistyArrow.TwistyWheel Wheel;
        private SLC.Minigames.TwistyArrow.WordBow bow;
        private UnityEngine.GameObject ArrowPrefab;
        private UnityEngine.Transform FlyingArrowsContainer;
        private UnityEngine.Transform StuckArrowsContainer;
        private float WheelRadius;
        private float ArrowHeight;
        private float ArrowHeadLength;
        private float FlyingArrowSpeed;
        private float distanceHit;
        private System.Collections.Generic.List<float> WordRegionRanges;
        private System.Collections.Generic.List<int> RegionsHit;
        private int badRegionIndex;
        
        // Properties
        public float SpeedMultiplier { get; }
        
        // Methods
        public float get_SpeedMultiplier()
        {
            if(this.Wheel != null)
            {
                    return (float)this.Wheel.speedMultiplier;
            }
            
            throw new NullReferenceException();
        }
        public override void InitMonoSingleton()
        {
            float val_1 = this.WheelRadius;
            val_1 = val_1 - this.ArrowHeadLength;
            this.distanceHit = val_1;
        }
        private void Update()
        {
            var val_9;
            var val_12;
            if((MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1._IsPlaying == false)
            {
                    return;
            }
            
            if(this.FlyingArrowsContainer == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.FlyingArrowsContainer.childCount < 1)
            {
                goto label_6;
            }
            
            if(this.FlyingArrowsContainer == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Collections.IEnumerator val_3 = this.FlyingArrowsContainer.GetEnumerator();
            val_9 = 1152921504683417600;
            label_21:
            var val_10 = 0;
            val_10 = val_10 + 1;
            if(val_3.MoveNext() == false)
            {
                goto label_13;
            }
            
            var val_11 = 0;
            val_11 = val_11 + 1;
            object val_7 = val_3.Current;
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            this.CheckCollision(arrow:  val_7.GetComponent<SLC.Minigames.TwistyArrow.FlyingArrow>());
            goto label_21;
            label_13:
            val_9 = 0;
            if(X0 == false)
            {
                goto label_22;
            }
            
            var val_14 = X0;
            if((X0 + 294) == 0)
            {
                goto label_26;
            }
            
            var val_12 = X0 + 176;
            var val_13 = 0;
            val_12 = val_12 + 8;
            label_25:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_24;
            }
            
            val_13 = val_13 + 1;
            val_12 = val_12 + 16;
            if(val_13 < (X0 + 294))
            {
                goto label_25;
            }
            
            goto label_26;
            label_24:
            val_14 = val_14 + (((X0 + 176 + 8)) << 4);
            val_12 = val_14 + 304;
            label_26:
            X0.Dispose();
            label_22:
            if(val_9 != 0)
            {
                    throw val_9;
            }
            
            label_6:
            if((UnityEngine.Input.GetKeyDown(key:  32)) == false)
            {
                    return;
            }
            
            this.FireArrow();
        }
        public void Setup(string[] words, float secondsPerRotation)
        {
            this.RegionsHit = new System.Collections.Generic.List<System.Int32>();
            this.badRegionIndex = 0;
            this.ClearStuckArrows();
            this.ClearFlyingArrows();
            this.Wheel.Setup(words:  words, secondsPerRotation:  secondsPerRotation);
            float val_4 = this.WheelRadius;
            val_4 = val_4 + val_4;
            UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  val_4, y:  val_4);
            this.Wheel.transform.sizeDelta = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
        }
        public void FireArrow()
        {
            this.bow.OnFire();
            UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.ArrowPrefab, parent:  this.FlyingArrowsContainer).GetComponent<SLC.Minigames.TwistyArrow.FlyingArrow>().SetSpeed(_speed:  this.FlyingArrowSpeed);
        }
        public void HandleHitArrow()
        {
            SLC.Minigames.TwistyArrow.TwistyGameManager val_1 = MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance;
            if(val_1._IsPlaying == false)
            {
                    return;
            }
            
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "ArrowHitArrow", clipIndex:  0, volumeScale:  1f);
            this.HandleFailure(hitBadRegion:  false);
        }
        private void CheckCollision(SLC.Minigames.TwistyArrow.FlyingArrow arrow)
        {
            int val_20;
            UnityEngine.Vector3 val_2 = this.Wheel.transform.localPosition;
            UnityEngine.Vector3 val_4 = arrow.transform.localPosition;
            val_4.y = val_2.y - val_4.y;
            if(val_4.y > this.WheelRadius)
            {
                    return;
            }
            
            arrow.ClearRigidBody();
            this.Wheel.PlaySound();
            UnityEngine.Vector3 val_7 = this.Wheel.transform.localEulerAngles;
            .angle = val_7.z;
            val_20 = this.WordRegionRanges.FindIndex(match:  new System.Predicate<System.Single>(object:  new TwistyArrowLogic.<>c__DisplayClass20_0(), method:  System.Boolean TwistyArrowLogic.<>c__DisplayClass20_0::<CheckCollision>b__0(float a)));
            UnityEngine.Vector3 val_12 = this.Wheel.transform.localPosition;
            UnityEngine.Vector3 val_14 = this.Wheel.transform.localPosition;
            val_14.y = val_14.y - this.distanceHit;
            UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  val_12.x, y:  val_14.y);
            UnityEngine.Vector3 val_16 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_15.x, y = val_15.y});
            arrow.transform.localPosition = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
            arrow.transform.SetParent(p:  this.StuckArrowsContainer);
            arrow.SetNormalColliderActive(state:  false);
            UnityEngine.Coroutine val_19 = this.StartCoroutine(routine:  arrow.DelayActiveCollider(arrow:  arrow));
            this.HandleHitRegion(regionIndex:  val_20);
        }
        private System.Collections.IEnumerator DelayActiveCollider(SLC.Minigames.TwistyArrow.FlyingArrow arrow)
        {
            .<>1__state = 0;
            .arrow = arrow;
            return (System.Collections.IEnumerator)new TwistyArrowLogic.<DelayActiveCollider>d__21();
        }
        private void HandleHitRegion(int regionIndex)
        {
            SLC.Minigames.TwistyArrow.TwistyGameManager val_1 = MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance;
            if(val_1._IsPlaying == false)
            {
                    return;
            }
            
            if(this.badRegionIndex == regionIndex)
            {
                    this.HandleFailure(hitBadRegion:  true);
                return;
            }
            
            if((this.RegionsHit.Contains(item:  regionIndex)) == true)
            {
                    return;
            }
            
            this.RegionsHit.Add(item:  regionIndex);
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "CorrectWord", volumeScale:  0.9f);
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyUIController>.Instance.ShowCheck();
            this.Wheel.IncreSpeed();
            if(this.RegionsHit < 4)
            {
                    return;
            }
            
            this.HandleLevelComplete();
        }
        private void HandleLevelComplete()
        {
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance.HandleLevelComplete();
            this.ClearFlyingArrows();
        }
        private void HandleFailure(bool hitBadRegion)
        {
            if(hitBadRegion != false)
            {
                    MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance.HandleFailure();
                MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "WrongWord", clipIndex:  0, volumeScale:  1f);
                MonoSingleton<SLC.Minigames.TwistyArrow.TwistyUIController>.Instance.ShowX();
                this.ClearFlyingArrows();
                return;
            }
            
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance.HandleSoftFailure();
        }
        private void ClearStuckArrows()
        {
            var val_6;
            var val_7;
            var val_10;
            if(this.StuckArrowsContainer == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7 = this.StuckArrowsContainer.GetEnumerator();
            label_17:
            var val_7 = 0;
            val_7 = val_7 + 1;
            if(val_7.MoveNext() == false)
            {
                goto label_7;
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            object val_5 = val_7.Current;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_5.gameObject);
            goto label_17;
            label_7:
            val_6 = 0;
            if(X0 == false)
            {
                goto label_18;
            }
            
            var val_11 = X0;
            val_7 = X0;
            if((X0 + 294) == 0)
            {
                goto label_22;
            }
            
            var val_9 = X0 + 176;
            var val_10 = 0;
            val_9 = val_9 + 8;
            label_21:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_20;
            }
            
            val_10 = val_10 + 1;
            val_9 = val_9 + 16;
            if(val_10 < (X0 + 294))
            {
                goto label_21;
            }
            
            goto label_22;
            label_20:
            val_11 = val_11 + (((X0 + 176 + 8)) << 4);
            val_10 = val_11 + 304;
            label_22:
            val_7.Dispose();
            label_18:
            if(val_6 != 0)
            {
                    throw 41967616;
            }
        
        }
        private void ClearFlyingArrows()
        {
            var val_6;
            var val_7;
            var val_10;
            if(this.FlyingArrowsContainer == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7 = this.FlyingArrowsContainer.GetEnumerator();
            label_17:
            var val_7 = 0;
            val_7 = val_7 + 1;
            if(val_7.MoveNext() == false)
            {
                goto label_7;
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            object val_5 = val_7.Current;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_5.gameObject);
            goto label_17;
            label_7:
            val_6 = 0;
            if(X0 == false)
            {
                goto label_18;
            }
            
            var val_11 = X0;
            val_7 = X0;
            if((X0 + 294) == 0)
            {
                goto label_22;
            }
            
            var val_9 = X0 + 176;
            var val_10 = 0;
            val_9 = val_9 + 8;
            label_21:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_20;
            }
            
            val_10 = val_10 + 1;
            val_9 = val_9 + 16;
            if(val_10 < (X0 + 294))
            {
                goto label_21;
            }
            
            goto label_22;
            label_20:
            val_11 = val_11 + (((X0 + 176 + 8)) << 4);
            val_10 = val_11 + 304;
            label_22:
            val_7.Dispose();
            label_18:
            if(val_6 != 0)
            {
                    throw 41967616;
            }
        
        }
        public TwistyArrowLogic()
        {
            this.FlyingArrowSpeed = 15f;
            this.ArrowHeight = 150f;
            this.ArrowHeadLength = 15f;
            System.Collections.Generic.List<System.Single> val_1 = new System.Collections.Generic.List<System.Single>();
            val_1.Add(item:  0f);
            val_1.Add(item:  -72f);
            val_1.Add(item:  -144f);
            val_1.Add(item:  144f);
            val_1.Add(item:  72f);
            this.WordRegionRanges = val_1;
        }
    
    }

}
