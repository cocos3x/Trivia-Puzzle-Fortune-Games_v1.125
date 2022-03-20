using UnityEngine;

namespace Spine
{
    internal class EventQueue
    {
        // Fields
        private readonly System.Collections.Generic.List<Spine.EventQueue.EventQueueEntry> eventQueueEntries;
        public bool drainDisabled;
        private readonly Spine.AnimationState state;
        private readonly Spine.Pool<Spine.TrackEntry> trackEntryPool;
        private System.Action AnimationsChanged;
        
        // Methods
        public void add_AnimationsChanged(System.Action value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.AnimationsChanged, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.AnimationsChanged != 1152921510542587760);
            
            return;
            label_2:
        }
        public void remove_AnimationsChanged(System.Action value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.AnimationsChanged, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.AnimationsChanged != 1152921510542724336);
            
            return;
            label_2:
        }
        public EventQueue(Spine.AnimationState state, System.Action HandleAnimationsChanged, Spine.Pool<Spine.TrackEntry> trackEntryPool)
        {
            this.eventQueueEntries = new System.Collections.Generic.List<EventQueueEntry>();
            val_2 = new System.Object();
            this.state = state;
            this.add_AnimationsChanged(value:  HandleAnimationsChanged);
            this.trackEntryPool = val_2;
        }
        public void Start(Spine.TrackEntry entry)
        {
            this.eventQueueEntries.Add(item:  new EventQueueEntry() {entry = entry});
            if(this.AnimationsChanged == null)
            {
                    return;
            }
            
            this.AnimationsChanged.Invoke();
        }
        public void Interrupt(Spine.TrackEntry entry)
        {
            this.eventQueueEntries.Add(item:  new EventQueueEntry() {type = 4.94065645841247E-324, entry = entry});
        }
        public void End(Spine.TrackEntry entry)
        {
            this.eventQueueEntries.Add(item:  new EventQueueEntry() {type = 9.88131291682493E-324, entry = entry});
            if(this.AnimationsChanged == null)
            {
                    return;
            }
            
            this.AnimationsChanged.Invoke();
        }
        public void Dispose(Spine.TrackEntry entry)
        {
            this.eventQueueEntries.Add(item:  new EventQueueEntry() {type = 1.48219693752374E-323, entry = entry});
        }
        public void Complete(Spine.TrackEntry entry)
        {
            this.eventQueueEntries.Add(item:  new EventQueueEntry() {type = 1.97626258336499E-323, entry = entry});
        }
        public void Event(Spine.TrackEntry entry, Spine.Event e)
        {
            this.eventQueueEntries.Add(item:  new EventQueueEntry() {type = 2.47032822920623E-323, entry = entry, e = e});
        }
        public void Drain()
        {
            if(this.drainDisabled == true)
            {
                    return;
            }
            
            bool val_1 = true;
            this.drainDisabled = val_1;
            if(val_1 < 1)
            {
                goto label_3;
            }
            
            var val_4 = 0;
            var val_3 = 0;
            label_29:
            if(val_3 >= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + val_4;
            if(((true + 0) + 32) > 5)
            {
                goto label_28;
            }
            
            var val_2 = 32576444 + ((true + 0) + 32) << 2;
            val_2 = val_2 + 32576444;
            goto (32576444 + ((true + 0) + 32) << 2 + 32576444);
            label_28:
            val_3 = val_3 + 1;
            val_4 = val_4 + 24;
            if(val_3 < val_1)
            {
                goto label_29;
            }
            
            label_3:
            this.eventQueueEntries.Clear();
            this.drainDisabled = false;
        }
        public void Clear()
        {
            this.eventQueueEntries.Clear();
        }
    
    }

}
