using UnityEngine;

namespace twelvegigs.storage
{
    public class StorageManager
    {
        // Fields
        private string resourcesPath;
        private twelvegigs.storage.KnobsModel knobsModel;
        private System.Collections.Generic.Dictionary<string, object> rawKnobsResponse;
        private System.Collections.Generic.Dictionary<string, object> sortedKnobsDisplay;
        
        // Methods
        public StorageManager(string resourcesPath)
        {
            this.resourcesPath = "";
            this.rawKnobsResponse = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            this.resourcesPath = resourcesPath;
        }
        public void initialize()
        {
            this.knobsModel = new twelvegigs.storage.KnobsModel();
        }
        public void OnDataUpdate(System.Collections.Generic.Dictionary<string, object> response)
        {
            this.OnResponseUpdateData(response:  response);
        }
        private void OnResponseUpdateData(System.Collections.Generic.Dictionary<string, object> response)
        {
            string val_10;
            var val_11;
            var val_20;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_21;
            var val_22;
            var val_23;
            var val_24;
            object val_25;
            object val_26;
            var val_27;
            var val_28;
            var val_29;
            var val_30;
            string val_31;
            string val_32;
            val_21 = response;
            if(val_21 == null)
            {
                    return;
            }
            
            val_22 = "meta";
            if((val_21.ContainsKey(key:  "meta")) == false)
            {
                    return;
            }
            
            val_23 = public System.Object System.Collections.Generic.Dictionary<System.String, System.Object>::get_Item(System.String key);
            object val_2 = val_21.Item["meta"];
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = val_2;
            val_20 = null;
            if(X0 == false)
            {
                goto label_4;
            }
            
            val_25 = null;
            if(X0 == false)
            {
                goto label_5;
            }
            
            var val_25 = X0;
            val_20 = X0;
            val_26 = "versions";
            if((X0 + 294) == 0)
            {
                goto label_6;
            }
            
            var val_22 = X0 + 176;
            var val_23 = 0;
            val_22 = val_22 + 8;
            label_8:
            if(((X0 + 176 + 8) + -8) == val_25)
            {
                goto label_7;
            }
            
            val_23 = val_23 + 1;
            val_22 = val_22 + 16;
            if(val_23 < (X0 + 294))
            {
                goto label_8;
            }
            
            label_6:
            val_23 = 4;
            goto label_9;
            label_7:
            var val_24 = val_22;
            val_24 = val_24 + 4;
            val_25 = val_25 + val_24;
            val_27 = val_25 + 304;
            label_9:
            if((val_20.Contains(key:  val_26)) == false)
            {
                    return;
            }
            
            val_28 = public System.Object System.Collections.Generic.Dictionary<System.String, System.Object>::get_Item(System.String key);
            object val_4 = val_21.Item["meta"];
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20 = null;
            val_25 = val_4;
            if(X0 == false)
            {
                goto label_12;
            }
            
            val_26 = null;
            if(X0 == false)
            {
                goto label_13;
            }
            
            var val_28 = X0;
            val_25 = "versions";
            val_20 = X0;
            if((X0 + 294) == 0)
            {
                goto label_14;
            }
            
            var val_26 = X0 + 176;
            var val_27 = 0;
            val_26 = val_26 + 8;
            label_16:
            if(((X0 + 176 + 8) + -8) == val_26)
            {
                goto label_15;
            }
            
            val_27 = val_27 + 1;
            val_26 = val_26 + 16;
            if(val_27 < (X0 + 294))
            {
                goto label_16;
            }
            
            label_14:
            val_28 = 0;
            goto label_17;
            label_15:
            val_28 = val_28 + (((X0 + 176 + 8)) << 4);
            val_29 = val_28 + 304;
            label_17:
            object val_5 = val_20.Item[val_25];
            this.rawKnobsResponse = val_21;
            if((val_21.ContainsKey(key:  "data")) == false)
            {
                    return;
            }
            
            object val_7 = val_21.Item["data"];
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20 = 1152921504685600768;
            Dictionary.Enumerator<TKey, TValue> val_8 = val_7.GetEnumerator();
            val_30 = 1152921510193071136;
            val_22 = 0;
            label_33:
            if(val_11.MoveNext() == false)
            {
                goto label_22;
            }
            
            val_31 = val_10;
            val_32 = "knobs";
            if((System.String.op_Equality(a:  val_31, b:  val_32)) == false)
            {
                goto label_33;
            }
            
            if(val_10 == 0)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.KeyCollection.Enumerator<TKey, TValue> val_15 = val_10.Keys.GetEnumerator();
            label_29:
            if(val_11.MoveNext() == false)
            {
                goto label_28;
            }
            
            UnityEngine.PlayerPrefs.SetString(key:  val_10, value:  MiniJSON.Json.Serialize(obj:  val_10.Item[val_10]));
            goto label_29;
            label_28:
            val_21 = 0;
            var val_19 = val_22 + 1;
            mem2[0] = 227;
            val_11.Dispose();
            if(val_21 != 0)
            {
                goto label_30;
            }
            
            if((val_19 == 1) || ((1152921520031169632 + ((val_22 + 1)) << 2) != 227))
            {
                goto label_33;
            }
            
            var val_29 = 0;
            val_29 = val_29 ^ (val_19 >> 31);
            var val_20 = val_19 + val_29;
            goto label_33;
            label_22:
            var val_21 = val_22 + 1;
            mem2[0] = 252;
            val_11.Dispose();
            return;
            label_4:
            label_5:
            label_12:
            label_13:
            label_30:
            val_31 = val_21;
            val_32 = 0;
            throw val_31;
        }
        public object EncodeInitialVersions()
        {
            System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            var val_3 = 0;
            val_3 = val_3 + 1;
            val_1.Add(key:  "knobs", value:  "1");
            return (object)val_1;
        }
        public twelvegigs.storage.KnobsModel getKnobs()
        {
            return (twelvegigs.storage.KnobsModel)this.knobsModel;
        }
        public string getRawKnobsResponse()
        {
            object val_8;
            var val_9;
            var val_15;
            object val_16;
            var val_17;
            if(this.sortedKnobsDisplay != null)
            {
                    return (string)PrettyPrint.printJSON(obj:  this.sortedKnobsDisplay, types:  false, singleLineOutput:  false);
            }
            
            twelvegigs.storage.JsonDictionary val_1 = 27022.getWordGameplayKnobs();
            var val_15 = 0;
            val_15 = val_15 + 1;
            System.Collections.Generic.List<System.String> val_5 = null;
            val_15 = public System.Void System.Collections.Generic.List<System.String>::.ctor(System.Collections.Generic.IEnumerable<T> collection);
            val_5 = new System.Collections.Generic.List<System.String>(collection:  System.Linq.Enumerable.Cast<System.String>(source:  val_1.dataSource.Keys));
            val_5.Sort();
            this.sortedKnobsDisplay = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            List.Enumerator<T> val_7 = val_5.GetEnumerator();
            label_19:
            val_16 = public System.Boolean List.Enumerator<System.String>::MoveNext();
            bool val_10 = val_9.MoveNext();
            if(val_10 == false)
            {
                goto label_10;
            }
            
            if(this.knobsModel == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_10.getWordGameplayKnobs() == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_11.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_16 = 0;
            val_16 = val_16 + 1;
            val_15 = 0;
            val_17 = val_11.dataSource;
            val_16 = val_8;
            if(this.sortedKnobsDisplay == null)
            {
                    throw new NullReferenceException();
            }
            
            this.sortedKnobsDisplay.Add(key:  val_8, value:  val_17.Item[val_16]);
            goto label_19;
            label_10:
            val_9.Dispose();
            return (string)PrettyPrint.printJSON(obj:  this.sortedKnobsDisplay, types:  false, singleLineOutput:  false);
        }
    
    }

}
