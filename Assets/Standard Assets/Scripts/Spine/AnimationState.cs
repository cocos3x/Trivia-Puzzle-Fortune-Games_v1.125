using UnityEngine;

namespace Spine
{
    public class AnimationState
    {
        // Fields
        private static readonly Spine.Animation EmptyAnimation;
        internal const int SUBSEQUENT = 0;
        internal const int FIRST = 1;
        internal const int DIP = 2;
        internal const int DIP_MIX = 3;
        private Spine.AnimationStateData data;
        private readonly Spine.ExposedList<Spine.TrackEntry> tracks;
        private readonly System.Collections.Generic.HashSet<int> propertyIDs;
        private readonly Spine.ExposedList<Spine.Event> events;
        private readonly Spine.EventQueue queue;
        private readonly Spine.ExposedList<Spine.TrackEntry> mixingTo;
        private bool animationsChanged;
        private float timeScale;
        private Spine.Pool<Spine.TrackEntry> trackEntryPool;
        private Spine.AnimationState.TrackEntryDelegate Start;
        private Spine.AnimationState.TrackEntryDelegate Interrupt;
        private Spine.AnimationState.TrackEntryDelegate End;
        private Spine.AnimationState.TrackEntryDelegate Dispose;
        private Spine.AnimationState.TrackEntryDelegate Complete;
        private Spine.AnimationState.TrackEntryEventDelegate Event;
        
        // Properties
        public Spine.AnimationStateData Data { get; }
        public Spine.ExposedList<Spine.TrackEntry> Tracks { get; }
        public float TimeScale { get; set; }
        
        // Methods
        public Spine.AnimationStateData get_Data()
        {
            return (Spine.AnimationStateData)this.data;
        }
        public Spine.ExposedList<Spine.TrackEntry> get_Tracks()
        {
            return (Spine.ExposedList<Spine.TrackEntry>)this.tracks;
        }
        public float get_TimeScale()
        {
            return (float)this.timeScale;
        }
        public void set_TimeScale(float value)
        {
            this.timeScale = value;
        }
        public void add_Start(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.Start, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Start != 1152921510528156752);
            
            return;
            label_2:
        }
        public void remove_Start(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.Start, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Start != 1152921510528293328);
            
            return;
            label_2:
        }
        public void add_Interrupt(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.Interrupt, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Interrupt != 1152921510528429912);
            
            return;
            label_2:
        }
        public void remove_Interrupt(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.Interrupt, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Interrupt != 1152921510528566488);
            
            return;
            label_2:
        }
        public void add_End(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.End, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.End != 1152921510528703072);
            
            return;
            label_2:
        }
        public void remove_End(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.End, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.End != 1152921510528839648);
            
            return;
            label_2:
        }
        public void add_Dispose(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.Dispose, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Dispose != 1152921510528976232);
            
            return;
            label_2:
        }
        public void remove_Dispose(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.Dispose, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Dispose != 1152921510529112808);
            
            return;
            label_2:
        }
        public void add_Complete(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.Complete, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Complete != 1152921510529249392);
            
            return;
            label_2:
        }
        public void remove_Complete(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.Complete, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Complete != 1152921510529385968);
            
            return;
            label_2:
        }
        public void add_Event(Spine.AnimationState.TrackEntryEventDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.Event, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Event != 1152921510529522552);
            
            return;
            label_2:
        }
        public void remove_Event(Spine.AnimationState.TrackEntryEventDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.Event, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Event != 1152921510529659128);
            
            return;
            label_2:
        }
        public AnimationState(Spine.AnimationStateData data)
        {
            this.tracks = new Spine.ExposedList<Spine.TrackEntry>();
            this.propertyIDs = new System.Collections.Generic.HashSet<System.Int32>();
            this.events = new Spine.ExposedList<Spine.Event>();
            this.mixingTo = new Spine.ExposedList<Spine.TrackEntry>();
            this.timeScale = 1f;
            this.trackEntryPool = new Spine.Pool<Spine.TrackEntry>(initialCapacity:  16, max:  2147483647);
            if(data == null)
            {
                    throw new System.ArgumentNullException(paramName:  "data", message:  "data cannot be null.");
            }
            
            this.data = data;
            this.queue = new Spine.EventQueue(state:  this, HandleAnimationsChanged:  new System.Action(object:  this, method:  System.Void Spine.AnimationState::HandleAnimationsChanged()), trackEntryPool:  this.trackEntryPool);
        }
        private void HandleAnimationsChanged()
        {
            this.animationsChanged = true;
        }
        public void Update(float delta)
        {
            Spine.EventQueue val_5;
            float val_6;
            if(W23 <= 0)
            {
                goto label_1;
            }
            
            var val_10 = 0;
            val_5 = this.queue;
            float val_1 = this.timeScale * delta;
            goto label_23;
            label_17:
            mem2[0] = 0;
            mem[this.queue].End(entry:  X21);
            this.DisposeNext(entry:  X21);
            goto label_15;
            label_23:
            var val_2 = X25 + 0;
            if(((X25 + 0) + 32) == 0)
            {
                goto label_15;
            }
            
            float val_4 = (X25 + 0) + 32 + 76;
            float val_5 = (X25 + 0) + 32 + 88;
            val_6 = val_1 * ((X25 + 0) + 32 + 96);
            mem2[0] = (X25 + 0) + 32 + 72;
            mem2[0] = val_5;
            if(val_4 <= 0f)
            {
                goto label_9;
            }
            
            val_4 = val_4 - val_6;
            mem2[0] = val_4;
            if(val_4 > 0f)
            {
                goto label_15;
            }
            
            val_6 = -val_4;
            mem2[0] = 0;
            label_9:
            if(((X25 + 0) + 32 + 24) == 0)
            {
                goto label_11;
            }
            
            val_5 = val_5 - ((X25 + 0) + 32 + 24 + 76);
            if(val_5 < 0f)
            {
                goto label_16;
            }
            
            float val_6 = (X25 + 0) + 32 + 24 + 96;
            mem2[0] = 0;
            val_6 = val_1 * val_6;
            val_5 = val_5 + val_6;
            mem2[0] = val_5;
            float val_7 = (X25 + 0) + 32 + 80;
            val_7 = val_6 + val_7;
            mem2[0] = val_7;
            this.SetCurrent(index:  0, current:  (X25 + 0) + 32 + 24, interrupt:  true);
            if(((X25 + 0) + 32 + 24 + 32) == 0)
            {
                goto label_15;
            }
            
            do
            {
                float val_8 = (X25 + 0) + 32 + 24 + 104;
                val_8 = val_6 + val_8;
                mem2[0] = val_8;
            }
            while(((X25 + 0) + 32 + 24 + 32 + 32) != 0);
            
            goto label_15;
            label_11:
            if(val_5 >= ((X25 + 0) + 32 + 92))
            {
                    if(((X25 + 0) + 32 + 32) == 0)
            {
                goto label_17;
            }
            
            }
            
            label_16:
            if((((X25 + 0) + 32 + 32) != 0) && ((this.UpdateMixingFrom(to:  (X25 + 0) + 32, delta:  val_1)) != false))
            {
                    mem2[0] = 0;
                if(((X25 + 0) + 32 + 32) != 0)
            {
                    do
            {
                mem[this.queue].End(entry:  (X25 + 0) + 32 + 32);
            }
            while(((X25 + 0) + 32 + 32 + 32) != 0);
            
            }
            
            }
            
            float val_9 = (X25 + 0) + 32 + 80;
            val_9 = val_6 + val_9;
            mem2[0] = val_9;
            label_15:
            val_10 = val_10 + 1;
            if(val_10 < X23)
            {
                goto label_23;
            }
            
            goto label_24;
            label_1:
            val_5 = this.queue;
            label_24:
            mem[this.queue].Drain();
        }
        private bool UpdateMixingFrom(Spine.TrackEntry to, float delta)
        {
            var val_1;
            if(to.mixingFrom == null)
            {
                goto label_1;
            }
            
            if(to.mixTime <= 0f)
            {
                goto label_5;
            }
            
            val_1 = this;
            if(to.mixTime < to.mixDuration)
            {
                    if(to.timeScale != 0f)
            {
                goto label_5;
            }
            
            }
            
            if(to.mixingFrom.totalAlpha != 0f)
            {
                    return (bool)val_1 & 1;
            }
            
            to.mixingFrom = to.mixingFrom.mixingFrom;
            to.interruptAlpha = to.mixingFrom.interruptAlpha;
            this.queue.End(entry:  to.mixingFrom);
            return (bool)val_1 & 1;
            label_1:
            val_1 = 1;
            return (bool)val_1 & 1;
            label_5:
            float val_2 = to.mixingFrom.timeScale;
            val_2 = val_2 * delta;
            val_2 = to.mixingFrom.trackTime + val_2;
            to.mixingFrom.animationLast = to.mixingFrom.nextAnimationLast;
            to.mixingFrom.trackLast = to.mixingFrom.nextTrackLast;
            to.mixingFrom.trackTime = val_2;
            float val_3 = to.timeScale;
            val_1 = 0;
            val_3 = val_3 * delta;
            val_3 = to.mixTime + val_3;
            to.mixTime = val_3;
            return (bool)val_1 & 1;
        }
        public bool Apply(Spine.Skeleton skeleton)
        {
            var val_15;
            Spine.AnimationState val_16;
            var val_17;
            var val_18;
            float val_19;
            float val_20;
            var val_21;
            var val_22;
            var val_23;
            var val_24;
            var val_25;
            val_16 = this;
            if(skeleton == null)
            {
                    throw new System.ArgumentNullException(paramName:  "skeleton", message:  "skeleton cannot be null.");
            }
            
            if(this.animationsChanged != false)
            {
                    this.AnimationsChanged();
            }
            
            if(W9 < 1)
            {
                goto label_4;
            }
            
            val_18 = 0;
            label_47:
            var val_1 = X10 + 0;
            if(((X10 + 0) + 32) == 0)
            {
                goto label_8;
            }
            
            val_19 = mem[(X10 + 0) + 32 + 76];
            val_19 = (X10 + 0) + 32 + 76;
            if(val_19 > 0f)
            {
                goto label_8;
            }
            
            val_20 = mem[(X10 + 0) + 32 + 100];
            val_20 = (X10 + 0) + 32 + 100;
            val_21 = 1;
            Spine.MixPose val_2 = (0 != 0) ? (val_21 + 1) : (val_21);
            if(((X10 + 0) + 32 + 32) != 0)
            {
                    val_20 = val_20 * (this.ApplyMixingFrom(to:  (X10 + 0) + 32, skeleton:  skeleton, currentPose:  val_2));
            }
            else
            {
                    val_19 = mem[(X10 + 0) + 32 + 80];
                val_19 = (X10 + 0) + 32 + 80;
                if(val_19 >= ((X10 + 0) + 32 + 92))
            {
                    float val_4 = (((X10 + 0) + 32 + 24) == 0) ? 0f : (val_20);
            }
            
            }
            
            float val_5 = (X10 + 0) + 32.AnimationTime;
            if(val_4 != 1f)
            {
                goto label_14;
            }
            
            if(((X10 + 0) + 32 + 16 + 16 + 24) < 1)
            {
                goto label_29;
            }
            
            label_23:
            var val_6 = ((X10 + 0) + 32 + 16 + 16 + 16) + 0;
            var val_16 = ((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32;
            val_21 = mem[((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 294];
            val_21 = ((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 294;
            if(val_21 == 0)
            {
                goto label_22;
            }
            
            var val_14 = ((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 176;
            var val_15 = 0;
            val_14 = val_14 + 8;
            label_21:
            if(((((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 176 + 8) + -8) == null)
            {
                goto label_20;
            }
            
            val_15 = val_15 + 1;
            val_14 = val_14 + 16;
            if(val_15 < val_21)
            {
                goto label_21;
            }
            
            goto label_22;
            label_20:
            val_21 = mem[(((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 176 + 8)];
            val_21 = val_14;
            val_16 = val_16 + (((((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 176 + 8)) << 4);
            val_23 = val_16 + 304;
            label_22:
            ((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32.Apply(skeleton:  skeleton, lastTime:  (X10 + 0) + 32 + 68, time:  val_5, events:  this.events, alpha:  1f, pose:  0, direction:  0);
            val_22 = 0 + 1;
            if(val_22 < ((X10 + 0) + 32 + 16 + 16 + 24))
            {
                goto label_23;
            }
            
            goto label_29;
            label_14:
            val_24 = mem[(X10 + 0) + 32 + 136];
            val_24 = (X10 + 0) + 32 + 136;
            val_21 = mem[(X10 + 0) + 32 + 136 + 24];
            val_21 = (X10 + 0) + 32 + 136 + 24;
            if(val_21 == 0)
            {
                    val_24.EnsureCapacity(min:  ((X10 + 0) + 32 + 16 + 16 + 24) << 1);
                val_24 = mem[(X10 + 0) + 32 + 136];
                val_24 = (X10 + 0) + 32 + 136;
            }
            
            if(((X10 + 0) + 32 + 16 + 16 + 24) < 1)
            {
                goto label_29;
            }
            
            var val_20 = 0;
            label_45:
            var val_9 = ((X10 + 0) + 32 + 120 + 16) + 0;
            var val_10 = ((X10 + 0) + 32 + 16 + 16 + 16) + 0;
            var val_19 = ((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32;
            val_21 = mem[((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 294];
            val_21 = ((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 294;
            if(val_21 == 0)
            {
                goto label_44;
            }
            
            var val_17 = ((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 176;
            var val_18 = 0;
            val_17 = val_17 + 8;
            label_43:
            if(((((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 176 + 8) + -8) == null)
            {
                goto label_42;
            }
            
            val_18 = val_18 + 1;
            val_17 = val_17 + 16;
            if(val_18 < val_21)
            {
                goto label_43;
            }
            
            goto label_44;
            label_42:
            val_21 = mem[(((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 176 + 8)];
            val_21 = val_17;
            val_19 = val_19 + (((((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32 + 176 + 8)) << 4);
            val_25 = val_19 + 304;
            label_44:
            ((X10 + 0) + 32 + 16 + 16 + 16 + 0) + 32.Apply(skeleton:  skeleton, lastTime:  (X10 + 0) + 32 + 68, time:  val_5, events:  this.events, alpha:  val_4, pose:  ((((X10 + 0) + 32 + 120 + 16 + 0) + 32) > 0) ? 0 : (val_2), direction:  0);
            val_20 = val_20 + 1;
            val_22 = val_2;
            if(val_20 < ((X10 + 0) + 32 + 16 + 16 + 24))
            {
                goto label_45;
            }
            
            label_29:
            val_16 = val_16;
            this.QueueEvents(entry:  (X10 + 0) + 32, animationTime:  val_5);
            this.events.Clear(clearArray:  false);
            mem2[0] = val_5;
            val_18 = 1;
            mem2[0] = (X10 + 0) + 32 + 80;
            val_17 = ???;
            label_8:
            val_15 = 0 + 1;
            if(val_15 < val_17)
            {
                goto label_47;
            }
            
            goto label_48;
            label_4:
            val_18 = 0;
            label_48:
            this.queue.Drain();
            return (bool)val_18 & 1;
        }
        private float ApplyMixingFrom(Spine.TrackEntry to, Spine.Skeleton skeleton, Spine.MixPose currentPose)
        {
            Spine.TrackEntry val_14;
            Spine.TrackEntry val_15;
            float val_16;
            Spine.ExposedList<Spine.Event> val_17;
            Spine.ExposedList<System.Single> val_19;
            Spine.MixPose val_20;
            float val_21;
            val_15 = to;
            if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = to.mixingFrom;
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(to.mixDuration == 0f)
            {
                    val_16 = 1f;
            }
            else
            {
                    val_16 = to.mixTime / to.mixDuration;
                if(val_16 > 1f)
            {
                    val_16 = 1f;
            }
            
            }
            
            if(val_16 < 0)
            {
                    val_17 = this.events;
            }
            else
            {
                    val_17 = 0;
            }
            
            float val_1 = val_14.AnimationTime;
            if(to.mixingFrom.animation == null)
            {
                    throw new NullReferenceException();
            }
            
            if(to.mixingFrom.animation.timelines == null)
            {
                    throw new NullReferenceException();
            }
            
            if(to.mixingFrom.timelineData == null)
            {
                    throw new NullReferenceException();
            }
            
            if(to.mixingFrom.timelineDipMix == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19 = to.mixingFrom.timelinesRotation;
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(to.mixingFrom.animation.timelines == null)
            {
                    Spine.ExposedList<T> val_3 = val_19.Resize(newSize:  W28 << 1);
                val_19 = to.mixingFrom.timelinesRotation;
                if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            to.mixingFrom.totalAlpha = 0f;
            if(W28 < 1)
            {
                goto label_17;
            }
            
            if(this == null)
            {
                    throw new NullReferenceException();
            }
            
            float val_4 = to.mixingFrom.alpha * to.interruptAlpha;
            float val_12 = 1f;
            val_12 = val_12 - val_16;
            float val_5 = val_12 * val_4;
            label_52:
            if(X22 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_7 = X22 + 0;
            if(((X22 + 0) + 32) == 0)
            {
                goto label_26;
            }
            
            if(((X22 + 0) + 32) == 2)
            {
                goto label_27;
            }
            
            if(((X22 + 0) + 32) != 1)
            {
                goto label_28;
            }
            
            val_20 = 0;
            val_21 = val_5;
            goto label_35;
            label_27:
            val_20 = 0;
            val_21 = val_4;
            goto label_35;
            label_26:
            val_20 = currentPose;
            val_21 = val_5;
            if(val_16 < 0)
            {
                goto label_35;
            }
            
            float val_13 = to.mixingFrom.totalAlpha;
            val_20 = currentPose;
            val_21 = val_5;
            val_13 = val_5 + val_13;
            to.mixingFrom.totalAlpha = val_13;
            goto label_39;
            label_28:
            if(X25 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_8 = X25 + 0;
            if(((X25 + 0) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
            float val_14 = 1f;
            val_14 = val_14 - (((X25 + 0) + 32 + 104) / ((X25 + 0) + 32 + 104 + 4));
            val_20 = 0;
            val_21 = val_4 * (System.Math.Max(val1:  0f, val2:  val_14));
            label_35:
            float val_15 = to.mixingFrom.totalAlpha;
            val_15 = val_21 + val_15;
            to.mixingFrom.totalAlpha = val_15;
            label_39:
            if(0 == 0)
            {
                goto label_51;
            }
            
            var val_16 = 0;
            var val_17 = 25769803786;
            label_50:
            if(mem[25769803778] == null)
            {
                goto label_49;
            }
            
            val_16 = val_16 + 1;
            val_17 = val_17 + 16;
            if(val_16 < 0)
            {
                goto label_50;
            }
            
            goto label_51;
            label_49:
            label_51:
            Spine.AnimationState.__il2cppRuntimeField_byval_arg.Apply(skeleton:  skeleton, lastTime:  to.mixingFrom.animationLast, time:  val_1, events:  val_17, alpha:  val_21, pose:  val_20, direction:  1);
            val_15 = 0 + 1;
            if(val_15 < X28)
            {
                goto label_52;
            }
            
            label_17:
            if((to + 108) > 0f)
            {
                    this.QueueEvents(entry:  val_14, animationTime:  val_1);
            }
            
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_17.Clear(clearArray:  false);
            to.mixingFrom.nextAnimationLast = val_1;
            to.mixingFrom.nextTrackLast = to.mixingFrom.trackTime;
            return val_16;
        }
        private static void ApplyRotateTimeline(Spine.RotateTimeline rotateTimeline, Spine.Skeleton skeleton, float time, float alpha, Spine.MixPose pose, float[] timelinesRotation, int i, bool firstFrame)
        {
            var val_45;
            var val_46;
            var val_47;
            var val_48;
            var val_49;
            float val_50;
            double val_51;
            var val_52;
            var val_53;
            float val_54;
            var val_55;
            float val_56;
            float val_57;
            float val_58;
            float val_59;
            val_46 = firstFrame;
            val_47 = i;
            val_48 = timelinesRotation;
            val_49 = pose;
            val_50 = alpha;
            val_51 = time;
            val_52 = skeleton;
            val_53 = rotateTimeline;
            if(val_46 != false)
            {
                    val_48[val_47 << 2] = 0f;
            }
            
            val_54 = 1f;
            if(val_50 != val_54)
            {
                goto label_4;
            }
            
            val_47 = ???;
            val_48 = ???;
            val_49 = ???;
            val_46 = ???;
            val_52 = ???;
            val_53 = ???;
            val_45 = ???;
            val_51 = ???;
            val_50 = ???;
            val_54 = ???;
            goto typeof(Spine.RotateTimeline).__il2cppRuntimeField_190;
            label_4:
            var val_44 = val_52 + 24 + 16;
            var val_54 = val_53 + 32 + 24;
            val_44 = val_44 + ((val_53 + 24) << 3);
            if((val_53 + 32 + 32) > val_51)
            {
                    if(val_49 != 0)
            {
                    return;
            }
            
                mem2[0] = (val_52 + 24 + 16 + (val_53 + 24) << 3) + 32 + 16 + 52;
                return;
            }
            
            var val_45 = -8589934592;
            val_45 = val_45 + ((val_53 + 32 + 24) << 32);
            val_45 = (val_53 + 32) + (val_45 >> 30);
            if(((val_53 + 32 + ((ulong)(-8589934592 + (val_53 + 32 + 24) << 32)) >> 30) + 32) > val_51)
            {
                    int val_1 = Spine.Animation.BinarySearch(values:  val_53 + 32, target:  val_51, step:  2);
                int val_2 = val_1 - 1;
                val_45 = val_1;
                int val_3 = val_45 - 2;
                var val_4 = (val_53 + 32) + (val_45 << 2);
                val_3 = (val_53 + 32) + (val_3 << 2);
                float val_46 = (val_53 + 32 + (val_1) << 2) + 32;
                val_2 = (val_53 + 32) + (val_2 << 2);
                val_46 = ((val_53 + 32 + ((val_1 - 2)) << 2) + 32) - val_46;
                val_46 = (val_51 - val_46) / val_46;
                val_46 = val_54 - val_46;
                float val_8 = val_53.GetCurvePercent(frameIndex:  (val_45 >> 1) - 1, percent:  val_46);
                int val_9 = val_45 + 1;
                val_9 = (val_53 + 32) + (val_9 << 2);
                float val_47 = (val_53 + 32 + ((val_1 + 1)) << 2) + 32;
                float val_50 = -360f;
                double val_51 = 16384.5;
                double val_52 = Infinity;
                val_47 = val_47 - ((val_53 + 32 + ((val_1 - 1)) << 2) + 32);
                double val_48 = (double)val_47 / val_50;
                val_48 = val_48 + val_51;
                val_48 = (val_48 == val_52) ? (-val_48) : (val_48);
                val_55 = mem[(val_52 + 24 + 16 + (val_53 + 24) << 3) + 32 + 16];
                val_55 = (val_52 + 24 + 16 + (val_53 + 24) << 3) + 32 + 16;
                int val_49 = (int)val_48;
                val_49 = 16384 - val_49;
                val_49 = val_49 * 360;
                val_47 = val_47 - (float)val_49;
                val_8 = val_8 * val_47;
                val_8 = ((val_53 + 32 + ((val_1 - 1)) << 2) + 32) + val_8;
                var val_53 = 16384;
                val_8 = val_8 + ((val_52 + 24 + 16 + (val_53 + 24) << 3) + 32 + 16 + 52);
                val_50 = val_8 / val_50;
                val_51 = (double)val_50 + val_51;
                val_52 = (val_51 == val_52) ? (-val_51) : (val_51);
                val_53 = val_53 - (int)val_52;
                val_53 = val_53 * 360;
                val_56 = val_8 - (float)val_53;
            }
            else
            {
                    val_55 = mem[(val_52 + 24 + 16 + (val_53 + 24) << 3) + 32 + 16];
                val_55 = (val_52 + 24 + 16 + (val_53 + 24) << 3) + 32 + 16;
                val_54 = val_54 << 32;
                val_54 = val_54 + (-4294967296);
                val_54 = (val_53 + 32) + (val_54 >> 30);
                val_56 = ((val_52 + 24 + 16 + (val_53 + 24) << 3) + 32 + 16 + 52) + ((val_53 + 32 + ((ulong)((val_53 + 32 + 24 << 32) + -4294967296)) >> 30) + 32);
            }
            
            val_55 = val_55 + 52;
            float val_12 = (val_49 == 0) ? (val_55) : (((val_52 + 24 + 16 + (val_53 + 24) << 3) + 32) + 56);
            val_57 = val_56 - val_12;
            if(val_57 != 0f)
            {
                goto label_29;
            }
            
            var val_13 = val_48 + (val_47 << 2);
            val_58 = mem[(val_48 + (val_47) << 2) + 32];
            val_58 = (val_48 + (val_47) << 2) + 32;
            goto label_32;
            label_29:
            float val_55 = -360f;
            val_55 = val_57 / val_55;
            double val_56 = (double)val_55;
            val_56 = val_56 + 16384.5;
            val_56 = (val_56 == Infinity) ? (-val_56) : (val_56);
            int val_57 = (int)val_56;
            val_57 = 16384 - val_57;
            val_57 = val_57 * 360;
            val_57 = val_57 - (float)val_57;
            val_54 = 0f;
            val_59 = val_57;
            if((val_46 & 1) == 0)
            {
                    var val_14 = val_47 + 1;
                var val_15 = val_48 + 32;
                val_54 = mem[(val_48 + 32) + (val_47) << 2];
                val_54 = (val_48 + 32) + (val_47) << 2;
                val_59 = mem[(val_48 + 32) + ((val_47 + 1)) << 2];
                val_59 = (val_48 + 32) + ((val_47 + 1)) << 2;
            }
            
            var val_16 = (val_57 > 0f) ? 1 : 0;
            if((System.Math.Sign(value:  val_59)) != (System.Math.Sign(value:  val_57)))
            {
                    if(System.Math.Abs(val_59) <= 90f)
            {
                goto label_42;
            }
            
            }
            
            val_53 = (val_54 >= 0f) ? 1 : 0;
            label_54:
            val_58 = (val_57 + val_54) - val_54;
            if((((val_57 > 0f) ? 1 : 0) ^ val_53) == 1)
            {
                    float val_59 = (float)(System.Math.Sign(value:  val_54)) * 360;
                val_58 = val_58 + val_59;
            }
            
            var val_25 = val_48 + (val_47 << 2);
            mem2[0] = val_58;
            label_32:
            var val_26 = val_47 + 1;
            val_26 = val_48 + (val_26 << 2);
            float val_60 = -360f;
            mem2[0] = val_57;
            val_59 = val_58 * val_50;
            val_59 = val_12 + val_59;
            val_60 = val_59 / val_60;
            double val_61 = (double)val_60;
            val_61 = val_61 + 16384.5;
            val_61 = (val_61 == Infinity) ? (-val_61) : (val_61);
            var val_62 = 16384;
            val_62 = val_62 - (int)val_61;
            val_62 = val_62 * 360;
            val_59 = val_59 - (float)val_62;
            mem2[0] = val_59;
            return;
            label_42:
            if(System.Math.Abs(val_54) <= 180f)
            {
                goto label_54;
            }
            
            val_54 = val_54 + ((float)(System.Math.Sign(value:  val_54)) * 360);
            goto label_54;
        }
        private void QueueEvents(Spine.TrackEntry entry, float animationTime)
        {
            var val_4;
            float val_1 = entry.animationEnd - entry.animationStart;
            if(W21 < 1)
            {
                goto label_2;
            }
            
            val_4 = 0;
            label_9:
            var val_2 = X22 + 0;
            if(((X22 + 0) + 32 + 24) < 0)
            {
                goto label_10;
            }
            
            if(((X22 + 0) + 32 + 24) <= entry.animationEnd)
            {
                    this.queue.Event(entry:  entry, e:  (X22 + 0) + 32);
            }
            
            val_4 = val_4 + 1;
            if(val_4 < W21)
            {
                goto label_9;
            }
            
            goto label_10;
            label_2:
            val_4 = 0;
            label_10:
            if(entry.loop == false)
            {
                goto label_11;
            }
            
            if(entry.trackLast > entry.trackTime)
            {
                goto label_12;
            }
            
            goto label_15;
            label_11:
            if((entry.animationEnd > animationTime) || (entry.animationLast >= 0))
            {
                goto label_15;
            }
            
            label_12:
            this.queue.Complete(entry:  entry);
            label_15:
            if(val_4 >= W21)
            {
                    return;
            }
            
            var val_4 = val_4;
            do
            {
                var val_3 = X22 + 0;
                if(((X22 + 0) + 32 + 24) >= 0)
            {
                    this.queue.Event(entry:  entry, e:  (X22 + 0) + 32);
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W21);
        
        }
        public void ClearTracks()
        {
            this.queue.drainDisabled = true;
            if(W22 >= 1)
            {
                    var val_1 = 0;
                do
            {
                this.ClearTrack(trackIndex:  0);
                val_1 = val_1 + 1;
            }
            while(W22 != val_1);
            
            }
            
            this.tracks.Clear(clearArray:  true);
            this.queue.drainDisabled = this.queue.drainDisabled;
            this.queue.Drain();
        }
        public void ClearTrack(int trackIndex)
        {
            Spine.TrackEntry val_1;
            Spine.ExposedList<Spine.TrackEntry> val_1 = this.tracks;
            if(W9 <= trackIndex)
            {
                    return;
            }
            
            val_1 = val_1 + (trackIndex << 3);
            if(X20 == 0)
            {
                    return;
            }
            
            this.queue.End(entry:  X20);
            this.DisposeNext(entry:  X20);
            val_1 = mem[X20 + 32];
            val_1 = X20 + 32;
            if(val_1 != 0)
            {
                    do
            {
                this.queue.End(entry:  val_1);
                mem2[0] = 0;
                val_1 = X20 + 32 + 32;
            }
            while((X20 + 32 + 32) != 0);
            
            }
            
            Spine.ExposedList<Spine.TrackEntry> val_2 = this.tracks;
            val_2 = val_2 + ((X20 + 40) << 3);
            mem2[0] = 0;
            this.queue.Drain();
        }
        private void SetCurrent(int index, Spine.TrackEntry current, bool interrupt)
        {
            Spine.TrackEntry val_1 = this.ExpandToIndex(index:  index);
            var val_2 = X24 + (index << 3);
            mem2[0] = current;
            if(val_1 != null)
            {
                    if(interrupt != false)
            {
                    this.queue.Interrupt(entry:  val_1);
            }
            
                current.mixingFrom = val_1;
                current.mixTime = 0f;
                if((val_1.mixingFrom != null) && (val_1.mixDuration > 0f))
            {
                    float val_4 = System.Math.Min(val1:  1f, val2:  val_1.mixTime / val_1.mixDuration);
                val_4 = current.interruptAlpha * val_4;
                current.interruptAlpha = val_4;
            }
            
                val_1.timelinesRotation.Clear(clearArray:  true);
            }
            
            this.queue.Start(entry:  current);
        }
        public Spine.TrackEntry SetAnimation(int trackIndex, string animationName, bool loop)
        {
            Spine.Animation val_1 = this.data.skeletonData.FindAnimation(animationName:  animationName);
            if(val_1 == null)
            {
                    throw new System.ArgumentException(message:  "Animation not found: "("Animation not found: ") + ???(???), paramName:  "animationName");
            }
            
            loop = loop;
            return this.SetAnimation(trackIndex:  trackIndex, animation:  val_1, loop:  loop);
        }
        public Spine.TrackEntry SetAnimation(int trackIndex, Spine.Animation animation, bool loop)
        {
            Spine.TrackEntry val_5;
            var val_6;
            if(animation == null)
            {
                    throw new System.ArgumentNullException(paramName:  "animation", message:  "animation cannot be null.");
            }
            
            Spine.TrackEntry val_1 = this.ExpandToIndex(index:  trackIndex);
            val_5 = val_1;
            if(val_1 == null)
            {
                goto label_2;
            }
            
            if(val_1.nextTrackLast != (-1f))
            {
                goto label_3;
            }
            
            var val_2 = X25 + (trackIndex << 3);
            mem2[0] = val_1.mixingFrom;
            this.queue.Interrupt(entry:  val_5);
            this.queue.End(entry:  val_5);
            this.DisposeNext(entry:  val_5);
            val_5 = val_1.mixingFrom;
            val_6 = 0;
            goto label_11;
            label_3:
            this.DisposeNext(entry:  val_5);
            label_2:
            val_6 = 1;
            label_11:
            loop = loop;
            Spine.TrackEntry val_3 = this.NewTrackEntry(trackIndex:  trackIndex, animation:  animation, loop:  loop, last:  val_5);
            this.SetCurrent(index:  trackIndex, current:  val_3, interrupt:  true);
            this.queue.Drain();
            return val_3;
        }
        public Spine.TrackEntry AddAnimation(int trackIndex, string animationName, bool loop, float delay)
        {
            Spine.Animation val_1 = this.data.skeletonData.FindAnimation(animationName:  animationName);
            if(val_1 == null)
            {
                    throw new System.ArgumentException(message:  "Animation not found: "("Animation not found: ") + ???(???), paramName:  "animationName");
            }
            
            loop = loop;
            return this.AddAnimation(trackIndex:  trackIndex, animation:  val_1, loop:  loop, delay:  delay);
        }
        public Spine.TrackEntry AddAnimation(int trackIndex, Spine.Animation animation, bool loop, float delay)
        {
            float val_9;
            Spine.TrackEntry val_10;
            val_9 = delay;
            if(animation == null)
            {
                    throw new System.ArgumentNullException(paramName:  "animation", message:  "animation cannot be null.");
            }
            
            Spine.TrackEntry val_1 = this.ExpandToIndex(index:  trackIndex);
            if(val_1 == null)
            {
                goto label_2;
            }
            
            do
            {
            
            }
            while(val_1.next != null);
            
            loop = loop;
            Spine.TrackEntry val_2 = this.NewTrackEntry(trackIndex:  trackIndex, animation:  animation, loop:  loop, last:  val_1);
            val_10 = val_2;
            val_1.next = val_2;
            if(val_9 > 0f)
            {
                goto label_4;
            }
            
            float val_3 = val_1.animationEnd - val_1.animationStart;
            if(val_3 != 0f)
            {
                goto label_5;
            }
            
            val_9 = 0f;
            if(val_10 != null)
            {
                goto label_11;
            }
            
            label_2:
            loop = loop;
            val_10 = this.NewTrackEntry(trackIndex:  trackIndex, animation:  animation, loop:  loop, last:  0);
            this.SetCurrent(index:  trackIndex, current:  val_10, interrupt:  true);
            this.queue.Drain();
            label_4:
            label_11:
            val_4.delay = val_9;
            return val_10;
            label_5:
            float val_5 = this.data.GetMix(from:  val_1.animation, to:  animation);
            float val_6 = val_1.trackTime / val_3;
            int val_9 = (int)(val_6 == Infinityf) ? (-(double)val_6) : ((double)val_6);
            val_9 = val_9 + 1;
            float val_10 = (float)val_9;
            val_10 = val_3 * val_10;
            val_5 = val_10 - val_5;
            val_9 = val_5 + val_9;
            if(val_10 != null)
            {
                goto label_11;
            }
            
            throw new NullReferenceException();
        }
        public Spine.TrackEntry SetEmptyAnimation(int trackIndex, float mixDuration)
        {
            null = null;
            val_1.mixDuration = mixDuration;
            val_1.trackEnd = mixDuration;
            return (Spine.TrackEntry)this.SetAnimation(trackIndex:  trackIndex, animation:  Spine.AnimationState.DIP_MIX, loop:  false);
        }
        public Spine.TrackEntry AddEmptyAnimation(int trackIndex, float mixDuration, float delay)
        {
            var val_2;
            float val_2 = delay;
            mixDuration = val_2 - mixDuration;
            val_2 = (val_2 <= 0f) ? (mixDuration) : (val_2);
            val_2 = null;
            val_2 = null;
            val_1.mixDuration = mixDuration;
            val_1.trackEnd = mixDuration;
            return (Spine.TrackEntry)this.AddAnimation(trackIndex:  trackIndex, animation:  Spine.AnimationState.DIP_MIX, loop:  false, delay:  val_2);
        }
        public void SetEmptyAnimations(float mixDuration)
        {
            this.queue.drainDisabled = true;
            if(W22 < 1)
            {
                goto label_6;
            }
            
            var val_2 = 0;
            label_7:
            Spine.TrackEntry val_1 = this.SetEmptyAnimation(trackIndex:  0, mixDuration:  mixDuration);
            val_2 = val_2 + 1;
            if(val_2 >= X22)
            {
                goto label_6;
            }
            
            if(this.tracks != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
            label_6:
            this.queue.drainDisabled = this.queue.drainDisabled;
            this.queue.Drain();
        }
        private Spine.TrackEntry ExpandToIndex(int index)
        {
            var val_1;
            bool val_1 = true;
            if(val_1 > index)
            {
                    val_1 = val_1 + (index << 3);
                val_1 = mem[(true + (index) << 3) + 32];
                val_1 = (true + (index) << 3) + 32;
                return (Spine.TrackEntry)val_1;
            }
            
            do
            {
                this.tracks.Add(item:  0);
            }
            while(val_1 <= index);
            
            val_1 = 0;
            return (Spine.TrackEntry)val_1;
        }
        private Spine.TrackEntry NewTrackEntry(int trackIndex, Spine.Animation animation, bool loop, Spine.TrackEntry last)
        {
            val_1.trackIndex = trackIndex;
            val_1.animation = animation;
            val_1.eventThreshold = 0f;
            val_1.attachmentThreshold = 0f;
            val_1.drawOrderThreshold = 0f;
            val_1.animationStart = 0f;
            val_1.loop = loop;
            val_1.alpha = 1f;
            val_1.mixTime = 0f;
            val_1.animationEnd = animation.duration;
            val_1.animationLast = ;
            val_1.nextAnimationLast = ;
            val_1.delay = 0f;
            val_1.trackTime = 0f;
            val_1.trackLast = ;
            val_1.nextTrackLast = ;
            val_1.trackEnd = 3.402823E+38f;
            val_1.timeScale = 1f;
            val_1.interruptAlpha = 1f;
            if(last != null)
            {
                    float val_3 = this.data.GetMix(from:  last.animation, to:  animation);
            }
            
            val_1.mixDuration = 0f;
            return (Spine.TrackEntry)this.trackEntryPool.Obtain();
        }
        private void DisposeNext(Spine.TrackEntry entry)
        {
            if(entry.next != null)
            {
                    do
            {
                this.queue.Dispose(entry:  entry.next);
            }
            while(entry.next.next != null);
            
            }
            
            entry.next = 0;
        }
        private void AnimationsChanged()
        {
            this.animationsChanged = false;
            this.propertyIDs.Clear();
            if(W22 < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            var val_1 = X23 + 32;
            do
            {
                if(((X23 + 32) + 0) != 0)
            {
                    Spine.TrackEntry val_2 = (X23 + 32) + 0.SetTimelineData(to:  0, mixingToArray:  this.mixingTo, propertyIDs:  this.propertyIDs);
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < X22);
        
        }
        public Spine.TrackEntry GetCurrent(int trackIndex)
        {
            var val_1;
            Spine.ExposedList<Spine.TrackEntry> val_1 = this.tracks;
            if(W9 > trackIndex)
            {
                    val_1 = val_1 + (trackIndex << 3);
                return (Spine.TrackEntry)val_1;
            }
            
            val_1 = 0;
            return (Spine.TrackEntry)val_1;
        }
        public override string ToString()
        {
            var val_14;
            var val_15;
            string val_16;
            var val_17;
            val_14 = this;
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            if(W22 < 1)
            {
                goto label_8;
            }
            
            label_9:
            val_16 = 0;
            if(val_1.Length >= 1)
            {
                    val_16 = ", ";
                System.Text.StringBuilder val_3 = val_1.Append(value:  val_16);
            }
            
            System.Text.StringBuilder val_4 = val_1.Append(value:  Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
            val_17 = 0 + 1;
            if(val_17 >= X22)
            {
                goto label_8;
            }
            
            if(this.tracks != null)
            {
                goto label_9;
            }
            
            throw new NullReferenceException();
            label_8:
            if(val_1.Length == 0)
            {
                    return "<none>";
            }
            
            val_14 = ???;
            val_15 = ???;
            val_17 = ???;
            goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
        }
        internal void OnStart(Spine.TrackEntry entry)
        {
            if(this.Start == null)
            {
                    return;
            }
            
            this.Start.Invoke(trackEntry:  entry);
        }
        internal void OnInterrupt(Spine.TrackEntry entry)
        {
            if(this.Interrupt == null)
            {
                    return;
            }
            
            this.Interrupt.Invoke(trackEntry:  entry);
        }
        internal void OnEnd(Spine.TrackEntry entry)
        {
            if(this.End == null)
            {
                    return;
            }
            
            this.End.Invoke(trackEntry:  entry);
        }
        internal void OnDispose(Spine.TrackEntry entry)
        {
            if(this.Dispose == null)
            {
                    return;
            }
            
            this.Dispose.Invoke(trackEntry:  entry);
        }
        internal void OnComplete(Spine.TrackEntry entry)
        {
            if(this.Complete == null)
            {
                    return;
            }
            
            this.Complete.Invoke(trackEntry:  entry);
        }
        internal void OnEvent(Spine.TrackEntry entry, Spine.Event e)
        {
            if(this.Event == null)
            {
                    return;
            }
            
            this.Event.Invoke(trackEntry:  entry, e:  e);
        }
        private static AnimationState()
        {
            Spine.AnimationState.DIP_MIX = new Spine.Animation(name:  "<empty>", timelines:  new Spine.ExposedList<Spine.Timeline>(), duration:  0f);
        }
    
    }

}
