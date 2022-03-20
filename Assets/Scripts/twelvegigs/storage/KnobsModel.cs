using UnityEngine;

namespace twelvegigs.storage
{
    public class KnobsModel
    {
        // Methods
        private object IsDynamicKnob(string knobId)
        {
            string val_3 = knobId;
            string val_1 = UnityEngine.PlayerPrefs.GetString(key:  val_3 = knobId, defaultValue:  0);
            if(val_1 == null)
            {
                    return 0;
            }
            
            val_3 = val_1;
            if((System.String.op_Inequality(a:  val_1, b:  "")) == false)
            {
                    return 0;
            }
            
            return MiniJSON.Json.Deserialize(json:  val_3);
        }
        public twelvegigs.storage.JsonDictionary getUpdatePromptConfiguration()
        {
            if((this.IsDynamicKnob(knobId:  "update_prompt")) != null)
            {
                    new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
                return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
            }
            
            new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary();
            return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
        }
        public System.Collections.IDictionary getGenericNofications()
        {
            var val_3;
            var val_4;
            if((this.IsDynamicKnob(knobId:  "generic_notifications")) != null)
            {
                    val_4 = 1152921504683257856;
            }
            else
            {
                    val_4 = 1152921504683257856;
                val_3 = new twelvegigs.storage.JsonDictionary();
            }
        
        }
        public System.Collections.IDictionary getSalesLogic()
        {
            var val_3;
            var val_4;
            if((this.IsDynamicKnob(knobId:  "sales_logic")) != null)
            {
                    val_4 = 1152921504683257856;
            }
            else
            {
                    val_4 = 1152921504683257856;
                val_3 = new twelvegigs.storage.JsonDictionary();
            }
        
        }
        public System.Collections.IDictionary getInstallRecapture()
        {
            var val_3;
            var val_4;
            if((this.IsDynamicKnob(knobId:  "installrecapture")) != null)
            {
                    val_4 = 1152921504683257856;
            }
            else
            {
                    val_4 = 1152921504683257856;
                val_3 = new twelvegigs.storage.JsonDictionary();
            }
        
        }
        public twelvegigs.storage.JsonDictionary getGameplayKnobs()
        {
            if((this.IsDynamicKnob(knobId:  "gameplay")) != null)
            {
                    new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
                return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
            }
            
            new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary();
            return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
        }
        public twelvegigs.storage.JsonDictionary getWordGameplayKnobs()
        {
            if((this.IsDynamicKnob(knobId:  "word_gameplay")) != null)
            {
                    new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
                return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
            }
            
            new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary();
            return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
        }
        public twelvegigs.storage.JsonDictionary getSudokuGameplayKnobs()
        {
            if((this.IsDynamicKnob(knobId:  "sudoku_gameplay")) != null)
            {
                    new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
                return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
            }
            
            new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary();
            return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
        }
        public twelvegigs.storage.JsonDictionary getWordPetsGameplayKnobs()
        {
            if((this.IsDynamicKnob(knobId:  "wordpets_gameplay")) != null)
            {
                    new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
                return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
            }
            
            new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary();
            return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
        }
        public twelvegigs.storage.JsonDictionary getMinigameKnobs()
        {
            if((this.IsDynamicKnob(knobId:  "minigame_data")) != null)
            {
                    new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
                return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
            }
            
            new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary();
            return (twelvegigs.storage.JsonDictionary)new twelvegigs.storage.JsonDictionary();
        }
        public KnobsModel()
        {
        
        }
    
    }

}
