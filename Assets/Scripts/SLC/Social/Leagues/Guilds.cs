using UnityEngine;

namespace SLC.Social.Leagues
{
    public class Guilds : Dictionary<int, SLC.Social.Leagues.Guild>
    {
        // Methods
        public void Update(System.Collections.Generic.List<object> guilds, EncodableModel.TemplateModel fromModel = 0)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2;
            var val_3;
            string val_9;
            List.Enumerator<T> val_1 = guilds.GetEnumerator();
            label_12:
            val_9 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_3.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_2 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = null;
            val_9 = "id";
            if(val_2.Item[val_9] == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = null;
            SLC.Social.Leagues.Guild val_6 = new SLC.Social.Leagues.Guild();
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_6.Decode(jasonObject:  val_2, sourceModel:  fromModel);
            if((this.ContainsKey(key:  19914752)) == false)
            {
                goto label_9;
            }
            
            val_9 = 1152921504626761728;
            SLC.Social.Leagues.Guild val_8 = this.Item[19914752];
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8.Merge(model:  val_6);
            goto label_12;
            label_9:
            this.Add(key:  19914752, value:  val_6);
            goto label_12;
            label_2:
            val_3.Dispose();
        }
        public void AddGuild(int id, SLC.Social.Leagues.Guild toAdd)
        {
            if(toAdd == null)
            {
                    return;
            }
            
            if((this.ContainsKey(key:  id)) != false)
            {
                    this.Item[id].Merge(model:  toAdd);
                return;
            }
            
            this.Add(key:  id, value:  toAdd);
        }
        public void RemoveKnownGuild(int id)
        {
            bool val_1 = this.Remove(key:  id);
        }
        public Guilds()
        {
        
        }
    
    }

}
