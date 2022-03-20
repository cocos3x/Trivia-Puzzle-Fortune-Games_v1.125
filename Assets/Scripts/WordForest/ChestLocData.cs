using UnityEngine;

namespace WordForest
{
    public class ChestLocData
    {
        // Fields
        public int GameLevel;
        public System.Collections.Generic.List<WordForest.ChestData> ChestsData;
        
        // Methods
        public string Serialize()
        {
            string val_8;
            var val_9;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "GameLevel", value:  this.GameLevel);
            System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
            List.Enumerator<T> val_3 = this.ChestsData.GetEnumerator();
            label_6:
            val_8 = public System.Boolean List.Enumerator<WordForest.ChestData>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_3;
            }
            
            val_9 = 0;
            if(val_9 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = val_9.Serialize();
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_2.Add(item:  val_8);
            goto label_6;
            label_3:
            0.Dispose();
            val_1.Add(key:  "ChestsData", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_2));
            return (string)Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1);
        }
        public ChestLocData()
        {
            this.GameLevel = 0;
            this.ChestsData = new System.Collections.Generic.List<WordForest.ChestData>();
        }
        public ChestLocData(string serialized)
        {
            this.GameLevel = 0;
            this.ChestsData = new System.Collections.Generic.List<WordForest.ChestData>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.String, System.Object>>(value:  serialized);
            this.GameLevel = System.Int32.Parse(s:  val_2.Item["GameLevel"]);
            List.Enumerator<T> val_7 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  val_2.Item["ChestsData"]).GetEnumerator();
            label_9:
            if(0.MoveNext() == false)
            {
                goto label_7;
            }
            
            if(this.ChestsData == null)
            {
                    throw new NullReferenceException();
            }
            
            this.ChestsData.Add(item:  new WordForest.ChestData(serialized:  0));
            goto label_9;
            label_7:
            0.Dispose();
        }
    
    }

}
