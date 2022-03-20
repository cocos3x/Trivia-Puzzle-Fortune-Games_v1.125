using UnityEngine;

namespace Spine
{
    public class TrackEntry : Pool.IPoolable<Spine.TrackEntry>
    {
        // Fields
        internal Spine.Animation animation;
        internal Spine.TrackEntry next;
        internal Spine.TrackEntry mixingFrom;
        internal int trackIndex;
        internal bool loop;
        internal float eventThreshold;
        internal float attachmentThreshold;
        internal float drawOrderThreshold;
        internal float animationStart;
        internal float animationEnd;
        internal float animationLast;
        internal float nextAnimationLast;
        internal float delay;
        internal float trackTime;
        internal float trackLast;
        internal float nextTrackLast;
        internal float trackEnd;
        internal float timeScale;
        internal float alpha;
        internal float mixTime;
        internal float mixDuration;
        internal float interruptAlpha;
        internal float totalAlpha;
        internal readonly Spine.ExposedList<int> timelineData;
        internal readonly Spine.ExposedList<Spine.TrackEntry> timelineDipMix;
        internal readonly Spine.ExposedList<float> timelinesRotation;
        private Spine.AnimationState.TrackEntryDelegate Start;
        private Spine.AnimationState.TrackEntryDelegate Interrupt;
        private Spine.AnimationState.TrackEntryDelegate End;
        private Spine.AnimationState.TrackEntryDelegate Dispose;
        private Spine.AnimationState.TrackEntryDelegate Complete;
        private Spine.AnimationState.TrackEntryEventDelegate Event;
        
        // Properties
        public int TrackIndex { get; }
        public Spine.Animation Animation { get; }
        public bool Loop { get; set; }
        public float Delay { get; set; }
        public float TrackTime { get; set; }
        public float TrackEnd { get; set; }
        public float AnimationStart { get; set; }
        public float AnimationEnd { get; set; }
        public float AnimationLast { get; set; }
        public float AnimationTime { get; }
        public float TimeScale { get; set; }
        public float Alpha { get; set; }
        public float EventThreshold { get; set; }
        public float AttachmentThreshold { get; set; }
        public float DrawOrderThreshold { get; set; }
        public Spine.TrackEntry Next { get; }
        public bool IsComplete { get; }
        public float MixTime { get; set; }
        public float MixDuration { get; set; }
        public Spine.TrackEntry MixingFrom { get; }
        
        // Methods
        public void Reset()
        {
            this.animation = 0;
            this.next = 0;
            this.mixingFrom = 0;
            this.timelineData.Clear(clearArray:  true);
            this.timelineDipMix.Clear(clearArray:  true);
            this.timelinesRotation.Clear(clearArray:  true);
            this.End = 0;
            this.Complete = 0;
            this.Start = 0;
        }
        internal Spine.TrackEntry SetTimelineData(Spine.TrackEntry to, Spine.ExposedList<Spine.TrackEntry> mixingToArray, System.Collections.Generic.HashSet<int> propertyIDs)
        {
            int val_14;
            Spine.TrackEntry val_15;
            var val_16;
            var val_17;
            val_14 = this;
            if(to != null)
            {
                    mixingToArray.Add(item:  to);
            }
            
            val_15 = val_14;
            if(this.mixingFrom != null)
            {
                    val_15 = this.mixingFrom;
            }
            
            if(to != null)
            {
                    mixingToArray.RemoveAt(index:  44210391);
            }
            
            Spine.ExposedList<T> val_1 = this.timelineData.Resize(newSize:  mixingToArray);
            this.timelineDipMix.Clear(clearArray:  true);
            Spine.ExposedList<T> val_2 = this.timelineDipMix.Resize(newSize:  mixingToArray);
            if(mixingToArray < 1)
            {
                    return val_15;
            }
            
            val_16 = 1152921504861052928;
            goto label_50;
            label_40:
            var val_3 = X27 + ((X28) << 2);
            mem2[0] = 3;
            var val_4 = (???) + ((X28) << 3);
            val_16 = to;
            mem2[0] = 1;
            goto label_47;
            label_50:
            var val_5 = X26 + 0;
            var val_18 = (X26 + 0) + 32;
            if(((X26 + 0) + 32 + 294) == 0)
            {
                goto label_30;
            }
            
            var val_15 = (X26 + 0) + 32 + 176;
            var val_16 = 0;
            val_15 = val_15 + 8;
            label_29:
            if((((X26 + 0) + 32 + 176 + 8) + -8) == null)
            {
                goto label_28;
            }
            
            val_16 = val_16 + 1;
            val_15 = val_15 + 16;
            if(val_16 < ((X26 + 0) + 32 + 294))
            {
                goto label_29;
            }
            
            goto label_30;
            label_28:
            var val_17 = val_15;
            val_17 = val_17 + 1;
            val_18 = val_18 + val_17;
            val_17 = val_18 + 304;
            label_30:
            val_14 = (X26 + 0) + 32.PropertyId;
            if((propertyIDs.Add(item:  val_14)) == false)
            {
                goto label_32;
            }
            
            if((to == null) || ((to.HasTimeline(id:  val_14)) == false))
            {
                goto label_34;
            }
            
            if((41934847 & 2147483648) == 0)
            {
                    do
            {
                var val_9 = X25 + 335478776;
                if(((X25 + 335478776) + 32.HasTimeline(id:  val_14)) != true)
            {
                    if(((X25 + 335478776) + 32 + 108) > 0f)
            {
                goto label_40;
            }
            
            }
            
            }
            while(((X25 + 335478776) + 32 + 108) >= 0);
            
            }
            
            val_16 = val_16;
            var val_11 = X27 + 0;
            mem2[0] = 2;
            goto label_47;
            label_32:
            var val_12 = X27 + 0;
            mem2[0] = 0;
            goto label_47;
            label_34:
            var val_13 = X27 + 0;
            mem2[0] = 1;
            label_47:
            if((0 + 1) < mixingToArray)
            {
                goto label_50;
            }
            
            return val_15;
        }
        private bool HasTimeline(int id)
        {
            var val_3;
            var val_4;
            var val_5;
            if(41934848 < 1)
            {
                goto label_3;
            }
            
            val_3 = 0;
            label_12:
            var val_1 = X22 + 0;
            var val_6 = (X22 + 0) + 32;
            if(((X22 + 0) + 32 + 294) == 0)
            {
                goto label_10;
            }
            
            var val_3 = (X22 + 0) + 32 + 176;
            var val_4 = 0;
            val_3 = val_3 + 8;
            label_9:
            if((((X22 + 0) + 32 + 176 + 8) + -8) == null)
            {
                goto label_8;
            }
            
            val_4 = val_4 + 1;
            val_3 = val_3 + 16;
            if(val_4 < ((X22 + 0) + 32 + 294))
            {
                goto label_9;
            }
            
            goto label_10;
            label_8:
            var val_5 = val_3;
            val_5 = val_5 + 1;
            val_6 = val_6 + val_5;
            val_4 = val_6 + 304;
            label_10:
            if(((X22 + 0) + 32.PropertyId) == id)
            {
                goto label_11;
            }
            
            val_3 = val_3 + 1;
            if(val_3 < 41934848)
            {
                goto label_12;
            }
            
            label_3:
            val_5 = 0;
            return (bool)val_5;
            label_11:
            val_5 = 1;
            return (bool)val_5;
        }
        public int get_TrackIndex()
        {
            return (int)this.trackIndex;
        }
        public Spine.Animation get_Animation()
        {
            return (Spine.Animation)this.animation;
        }
        public bool get_Loop()
        {
            return (bool)this.loop;
        }
        public void set_Loop(bool value)
        {
            this.loop = value;
        }
        public float get_Delay()
        {
            return (float)this.delay;
        }
        public void set_Delay(float value)
        {
            this.delay = value;
        }
        public float get_TrackTime()
        {
            return (float)this.trackTime;
        }
        public void set_TrackTime(float value)
        {
            this.trackTime = value;
        }
        public float get_TrackEnd()
        {
            return (float)this.trackEnd;
        }
        public void set_TrackEnd(float value)
        {
            this.trackEnd = value;
        }
        public float get_AnimationStart()
        {
            return (float)this.animationStart;
        }
        public void set_AnimationStart(float value)
        {
            this.animationStart = value;
        }
        public float get_AnimationEnd()
        {
            return (float)this.animationEnd;
        }
        public void set_AnimationEnd(float value)
        {
            this.animationEnd = value;
        }
        public float get_AnimationLast()
        {
            return (float)this.animationLast;
        }
        public void set_AnimationLast(float value)
        {
            this.animationLast = value;
            this.nextAnimationLast = value;
        }
        public float get_AnimationTime()
        {
            float val_3;
            if(this.loop == false)
            {
                    return System.Math.Min(val1:  this.trackTime + this.animationStart, val2:  this.animationEnd);
            }
            
            val_3 = this.animationStart;
            if((this.animationEnd - val_3) == 0f)
            {
                    return (float)val_3;
            }
            
            val_3 = val_3 + this.trackTime;
            return (float)val_3;
        }
        public float get_TimeScale()
        {
            return (float)this.timeScale;
        }
        public void set_TimeScale(float value)
        {
            this.timeScale = value;
        }
        public float get_Alpha()
        {
            return (float)this.alpha;
        }
        public void set_Alpha(float value)
        {
            this.alpha = value;
        }
        public float get_EventThreshold()
        {
            return (float)this.eventThreshold;
        }
        public void set_EventThreshold(float value)
        {
            this.eventThreshold = value;
        }
        public float get_AttachmentThreshold()
        {
            return (float)this.attachmentThreshold;
        }
        public void set_AttachmentThreshold(float value)
        {
            this.attachmentThreshold = value;
        }
        public float get_DrawOrderThreshold()
        {
            return (float)this.drawOrderThreshold;
        }
        public void set_DrawOrderThreshold(float value)
        {
            this.drawOrderThreshold = value;
        }
        public Spine.TrackEntry get_Next()
        {
            return (Spine.TrackEntry)this.next;
        }
        public bool get_IsComplete()
        {
            float val_2 = this.animationStart;
            val_2 = this.animationEnd - val_2;
            return (bool)(this.trackTime >= val_2) ? 1 : 0;
        }
        public float get_MixTime()
        {
            return (float)this.mixTime;
        }
        public void set_MixTime(float value)
        {
            this.mixTime = value;
        }
        public float get_MixDuration()
        {
            return (float)this.mixDuration;
        }
        public void set_MixDuration(float value)
        {
            this.mixDuration = value;
        }
        public Spine.TrackEntry get_MixingFrom()
        {
            return (Spine.TrackEntry)this.mixingFrom;
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
            while(this.Start != 1152921510539840592);
            
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
            while(this.Start != 1152921510539977168);
            
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
            while(this.Interrupt != 1152921510540113752);
            
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
            while(this.Interrupt != 1152921510540250328);
            
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
            while(this.End != 1152921510540386912);
            
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
            while(this.End != 1152921510540523488);
            
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
            while(this.Dispose != 1152921510540660072);
            
            return;
            label_2:
        }
        public void remove_Dispose(Spine.AnimationState.TrackEntryDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.Dispose, value:  value)) != null)
            {
                    if(null != 31056744)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Dispose != 1152921510540796648);
            
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
            while(this.Complete != 1152921510540933232);
            
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
            while(this.Complete != 1152921510541069808);
            
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
            while(this.Event != 1152921510541206392);
            
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
            while(this.Event != 1152921510541342968);
            
            return;
            label_2:
        }
        internal void OnStart()
        {
            if(this.Start == null)
            {
                    return;
            }
            
            this.Start.Invoke(trackEntry:  this);
        }
        internal void OnInterrupt()
        {
            if(this.Interrupt == null)
            {
                    return;
            }
            
            this.Interrupt.Invoke(trackEntry:  this);
        }
        internal void OnEnd()
        {
            if(this.End == null)
            {
                    return;
            }
            
            this.End.Invoke(trackEntry:  this);
        }
        internal void OnDispose()
        {
            if(this.Dispose == null)
            {
                    return;
            }
            
            this.Dispose.Invoke(trackEntry:  this);
        }
        internal void OnComplete()
        {
            if(this.Complete == null)
            {
                    return;
            }
            
            this.Complete.Invoke(trackEntry:  this);
        }
        internal void OnEvent(Spine.Event e)
        {
            if(this.Event == null)
            {
                    return;
            }
            
            this.Event.Invoke(trackEntry:  this, e:  e);
        }
        public void ResetRotationDirections()
        {
            this.timelinesRotation.Clear(clearArray:  true);
        }
        public override string ToString()
        {
            return (string)(this.animation == 0) ? "<none>" : this.animation.name;
        }
        public TrackEntry()
        {
            this.timeScale = 1f;
            this.timelineData = new Spine.ExposedList<System.Int32>();
            this.timelineDipMix = new Spine.ExposedList<Spine.TrackEntry>();
            this.timelinesRotation = new Spine.ExposedList<System.Single>();
        }
    
    }

}
