using UnityEngine;

namespace SRDebugger.UI.Tabs
{
    public class InfoTabController : SRMonoBehaviourEx
    {
        // Fields
        public const char Tick = '\x2713';
        public const char Cross = '\xd7';
        public const string NameColor = "#BCBCBC";
        private System.Collections.Generic.Dictionary<string, SRDebugger.UI.Controls.InfoBlock> _infoBlocks;
        public SRDebugger.UI.Controls.InfoBlock InfoBlockPrefab;
        public UnityEngine.RectTransform LayoutContainer;
        
        // Methods
        protected override void OnEnable()
        {
            this.OnEnable();
            this.Refresh();
        }
        public void Refresh()
        {
            var val_14;
            string val_19;
            SRDebugger.Services.ISystemInformationService val_1 = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.ISystemInformationService>();
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_19 = 0;
            val_19 = val_19 + 1;
            val_14 = 0;
            System.Collections.Generic.IEnumerable<System.String> val_3 = val_1.GetCategories();
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_20 = 0;
            val_20 = val_20 + 1;
            val_14 = 0;
            System.Collections.Generic.IEnumerator<T> val_5 = val_3.GetEnumerator();
            label_26:
            var val_21 = 0;
            val_21 = val_21 + 1;
            val_14 = 0;
            if(val_5.MoveNext() == false)
            {
                goto label_18;
            }
            
            var val_22 = 0;
            val_22 = val_22 + 1;
            val_19 = val_5.Current;
            if(this._infoBlocks == null)
            {
                    throw new NullReferenceException();
            }
            
            if((this._infoBlocks.ContainsKey(key:  val_19)) == true)
            {
                goto label_26;
            }
            
            if(this._infoBlocks == null)
            {
                    throw new NullReferenceException();
            }
            
            this._infoBlocks.Add(key:  val_19, value:  this.CreateBlock(title:  val_19));
            goto label_26;
            label_18:
            val_19 = 0;
            if(val_5 != null)
            {
                    var val_23 = 0;
                val_23 = val_23 + 1;
                val_14 = 0;
                val_5.Dispose();
            }
            
            if(val_19 != 0)
            {
                    throw val_19;
            }
            
            if(0 != 1)
            {
                    var val_13 = (82 == 82) ? 1 : 0;
                val_13 = ((0 >= 0) ? 1 : 0) & val_13;
                val_13 = 0 - val_13;
                val_13 = val_13 + 1;
                val_19 = (long)val_13;
            }
            else
            {
                    val_19 = 0;
            }
            
            if(this._infoBlocks == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_15 = this._infoBlocks.GetEnumerator();
            label_41:
            if(0.MoveNext() == false)
            {
                goto label_36;
            }
            
            var val_24 = 0;
            val_24 = val_24 + 1;
            val_14 = 1;
            System.Collections.Generic.IList<SRDebugger.InfoEntry> val_18 = val_1.GetInfo(category:  0);
            val_18.FillInfoBlock(block:  0, info:  val_18);
            goto label_41;
            label_36:
            0.Dispose();
        }
        private void FillInfoBlock(SRDebugger.UI.Controls.InfoBlock block, System.Collections.Generic.IList<SRDebugger.InfoEntry> info)
        {
            var val_28;
            SRDebugger.UI.Controls.InfoBlock val_29;
            var val_31;
            var val_34;
            var val_39;
            var val_41;
            val_28 = info;
            val_29 = block;
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            if(val_28 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_34 = 0;
            val_34 = val_34 + 1;
            System.Collections.Generic.IEnumerator<T> val_3 = val_28.GetEnumerator();
            val_29 = val_3;
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_31 = 0;
            goto label_7;
            label_18:
            var val_35 = 0;
            val_35 = val_35 + 1;
            if(val_29.Current == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            label_7:
            var val_36 = 0;
            val_36 = val_36 + 1;
            if(val_29.MoveNext() == true)
            {
                goto label_18;
            }
            
            val_34 = 0;
            if(val_29 != null)
            {
                    var val_37 = 0;
                val_37 = val_37 + 1;
                val_29.Dispose();
            }
            
            if(val_34 != 0)
            {
                    throw val_34 = ???;
            }
            
            if(0 != 1)
            {
                    var val_10 = (73 == 73) ? 1 : 0;
                val_10 = ((0 >= 0) ? 1 : 0) & val_10;
                val_10 = 0 - val_10;
                val_10 = val_10 + 1;
            }
            
            var val_38 = 0;
            val_38 = val_38 + 1;
            val_28 = val_28.GetEnumerator();
            val_34 = ">";
            label_54:
            var val_39 = 0;
            val_39 = val_39 + 1;
            val_39 = public System.Boolean System.Collections.IEnumerator::MoveNext();
            if(val_28.MoveNext() == false)
            {
                goto label_36;
            }
            
            var val_40 = 0;
            val_40 = val_40 + 1;
            val_29 = val_28.Current;
            if((1 & 1) == 0)
            {
                goto label_41;
            }
            
            if(val_1 != null)
            {
                goto label_42;
            }
            
            throw new NullReferenceException();
            label_41:
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Text.StringBuilder val_19 = val_1.AppendLine();
            label_42:
            System.Text.StringBuilder val_20 = val_1.Append(value:  "<color=");
            System.Text.StringBuilder val_21 = val_1.Append(value:  "#BCBCBC");
            System.Text.StringBuilder val_22 = val_1.Append(value:  ">");
            if(val_29 == 0)
            {
                    throw new NullReferenceException();
            }
            
            System.Text.StringBuilder val_23 = val_1.Append(value:  val_18 + 16);
            System.Text.StringBuilder val_24 = val_1.Append(value:  ": ");
            System.Text.StringBuilder val_25 = val_1.Append(value:  "</color>");
            if((val_18 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_41 = mem[val_18 + 16 + 16];
            val_41 = val_18 + 16 + 16;
            goto label_47;
            label_48:
            System.Text.StringBuilder val_26 = val_1.Append(value:  ' ');
            val_41 = val_41 + 1;
            label_47:
            if(val_41 <= ((((val_5 + 16 + 16) > val_31) ? (val_5 + 16 + 16) : (val_31)) + 2))
            {
                goto label_48;
            }
            
            if(val_29.Value != null)
            {
                    if(null == null)
            {
                goto label_50;
            }
            
            }
            
            System.Text.StringBuilder val_29 = val_1.Append(value:  val_29.Value);
            goto label_54;
            label_50:
            if(val_29.Value == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Text.StringBuilder val_32 = val_1.Append(value:  (null == 0) ? 215 : 10003);
            goto label_54;
            label_36:
            val_29 = 0;
            if(val_28 != null)
            {
                    var val_41 = 0;
                val_41 = val_41 + 1;
                val_39 = public System.Void System.IDisposable::Dispose();
                val_28.Dispose();
            }
            
            if(val_29 != 0)
            {
                    throw val_29 = ???;
            }
            
            if(val_29 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((block + 72) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_28 = ???;
            goto block + 72 + 1504;
        }
        private SRDebugger.UI.Controls.InfoBlock CreateBlock(string title)
        {
            SRDebugger.UI.Controls.InfoBlock val_1 = SRInstantiate.Instantiate<SRDebugger.UI.Controls.InfoBlock>(prefab:  this.InfoBlockPrefab);
            val_1.CachedTransform.SetParent(parent:  this.LayoutContainer, worldPositionStays:  false);
            return val_1;
        }
        public InfoTabController()
        {
            this._infoBlocks = new System.Collections.Generic.Dictionary<System.String, SRDebugger.UI.Controls.InfoBlock>();
        }
    
    }

}
