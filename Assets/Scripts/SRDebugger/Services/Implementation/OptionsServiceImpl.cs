using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class OptionsServiceImpl : IOptionsService
    {
        // Fields
        private System.EventHandler OptionsUpdated;
        private System.EventHandler<System.ComponentModel.PropertyChangedEventArgs> OptionsValueUpdated;
        private readonly System.Collections.Generic.Dictionary<object, System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition>> _optionContainerLookup;
        private readonly System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition> _options;
        private readonly System.Collections.Generic.IList<SRDebugger.Internal.OptionDefinition> _optionsReadonly;
        
        // Properties
        public System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> Options { get; }
        
        // Methods
        public void add_OptionsUpdated(System.EventHandler value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.OptionsUpdated, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OptionsUpdated != 1152921519561879248);
            
            return;
            label_2:
        }
        public void remove_OptionsUpdated(System.EventHandler value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.OptionsUpdated, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OptionsUpdated != 1152921519562015824);
            
            return;
            label_2:
        }
        public void add_OptionsValueUpdated(System.EventHandler<System.ComponentModel.PropertyChangedEventArgs> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.OptionsValueUpdated, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OptionsValueUpdated != 1152921519562152408);
            
            return;
            label_2:
        }
        public void remove_OptionsValueUpdated(System.EventHandler<System.ComponentModel.PropertyChangedEventArgs> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.OptionsValueUpdated, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OptionsValueUpdated != 1152921519562288984);
            
            return;
            label_2:
        }
        public System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> get_Options()
        {
            return (System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition>)this._optionsReadonly;
        }
        public OptionsServiceImpl()
        {
            var val_5;
            var val_6;
            this._optionContainerLookup = new System.Collections.Generic.Dictionary<System.Object, System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition>>();
            this._options = new System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition>();
            this._optionsReadonly = new System.Collections.ObjectModel.ReadOnlyCollection<SRDebugger.Internal.OptionDefinition>(list:  this._options);
            val_5 = null;
            val_5 = null;
            this.AddContainer(obj:  SROptions._current);
            val_6 = null;
            val_6 = null;
            SROptions._current.add_PropertyChanged(value:  new SROptionsPropertyChanged(object:  this, method:  System.Void SRDebugger.Services.Implementation.OptionsServiceImpl::OnSROptionsPropertyChanged(object sender, string propertyName)));
        }
        public void Scan(object obj)
        {
            this.AddContainer(obj:  obj);
        }
        public void AddContainer(object obj)
        {
            IntPtr val_8;
            var val_9;
            if((this._optionContainerLookup.ContainsKey(key:  obj)) == true)
            {
                    throw new System.Exception(message:  "An object should only be added once.");
            }
            
            System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> val_2 = SRDebugger.Internal.SRDebuggerUtil.ScanForOptions(obj:  obj);
            this._optionContainerLookup.Add(key:  obj, value:  val_2);
            var val_7 = 0;
            val_7 = val_7 + 1;
            if(val_2.Count < 1)
            {
                    return;
            }
            
            this._options.AddRange(collection:  val_2);
            this.OnOptionsUpdated();
            if(X0 == false)
            {
                    return;
            }
            
            System.ComponentModel.PropertyChangedEventHandler val_5 = null;
            val_8 = System.Void SRDebugger.Services.Implementation.OptionsServiceImpl::OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs);
            val_5 = new System.ComponentModel.PropertyChangedEventHandler(object:  this, method:  val_8);
            var val_10 = X0;
            if((X0 + 294) == 0)
            {
                goto label_12;
            }
            
            var val_8 = X0 + 176;
            var val_9 = 0;
            val_8 = val_8 + 8;
            label_14:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_13;
            }
            
            val_9 = val_9 + 1;
            val_8 = val_8 + 16;
            if(val_9 < (X0 + 294))
            {
                goto label_14;
            }
            
            label_12:
            val_8 = 0;
            goto label_15;
            label_13:
            val_10 = val_10 + (((X0 + 176 + 8)) << 4);
            val_9 = val_10 + 304;
            label_15:
            X0.add_PropertyChanged(value:  val_5);
        }
        public void RemoveContainer(object obj)
        {
            var val_11;
            var val_13;
            var val_14;
            System.ComponentModel.PropertyChangedEventHandler val_18;
            IntPtr val_19;
            var val_20;
            if(this._optionContainerLookup == null)
            {
                    throw new NullReferenceException();
            }
            
            if((this._optionContainerLookup.ContainsKey(key:  obj)) == false)
            {
                    return;
            }
            
            if(this._optionContainerLookup == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this._optionContainerLookup == null)
            {
                    throw new NullReferenceException();
            }
            
            val_11 = this._optionContainerLookup.Item[obj];
            bool val_3 = this._optionContainerLookup.Remove(key:  obj);
            if(val_11 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_13 = val_11.GetEnumerator();
            val_14 = 1152921504683417600;
            label_21:
            var val_14 = 0;
            val_14 = val_14 + 1;
            if(val_13.MoveNext() == false)
            {
                goto label_15;
            }
            
            var val_15 = 0;
            val_15 = val_15 + 1;
            if(this._options == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_10 = this._options.Remove(item:  val_13.Current);
            goto label_21;
            label_15:
            val_14 = 0;
            if(val_13 != null)
            {
                    var val_16 = 0;
                val_16 = val_16 + 1;
                val_13.Dispose();
            }
            
            if(val_14 != 0)
            {
                    throw val_14;
            }
            
            if(X0 == false)
            {
                goto label_28;
            }
            
            System.ComponentModel.PropertyChangedEventHandler val_12 = null;
            val_18 = val_12;
            val_19 = System.Void SRDebugger.Services.Implementation.OptionsServiceImpl::OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs);
            val_12 = new System.ComponentModel.PropertyChangedEventHandler(object:  this, method:  val_19);
            var val_20 = X0;
            if((X0 + 294) == 0)
            {
                goto label_29;
            }
            
            var val_17 = X0 + 176;
            var val_18 = 0;
            val_17 = val_17 + 8;
            label_31:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_30;
            }
            
            val_18 = val_18 + 1;
            val_17 = val_17 + 16;
            if(val_18 < (X0 + 294))
            {
                goto label_31;
            }
            
            label_29:
            val_19 = 1;
            goto label_32;
            label_30:
            var val_19 = val_17;
            val_19 = val_19 + 1;
            val_20 = val_20 + val_19;
            val_20 = val_20 + 304;
            label_32:
            X0.remove_PropertyChanged(value:  val_12);
            label_28:
            this.OnOptionsUpdated();
        }
        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if(this.OptionsValueUpdated == null)
            {
                    return;
            }
            
            this.OptionsValueUpdated.Invoke(sender:  this, e:  propertyChangedEventArgs);
        }
        private void OnSROptionsPropertyChanged(object sender, string propertyName)
        {
            this.OnPropertyChanged(sender:  propertyName, propertyChangedEventArgs:  new System.ComponentModel.PropertyChangedEventArgs(propertyName:  propertyName));
        }
        private void OnOptionsUpdated()
        {
            var val_1;
            if(this.OptionsUpdated == null)
            {
                    return;
            }
            
            val_1 = null;
            val_1 = null;
            this.OptionsUpdated.Invoke(sender:  this, e:  System.EventArgs.Empty);
        }
    
    }

}
