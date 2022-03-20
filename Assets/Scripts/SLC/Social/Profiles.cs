using UnityEngine;

namespace SLC.Social
{
    public class Profiles : Dictionary<int, SLC.Social.Profile>
    {
        // Methods
        public void Update(System.Collections.Generic.List<object> profiles, EncodableModel.TemplateModel fromModel = 0)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2;
            var val_3;
            string val_9;
            List.Enumerator<T> val_1 = profiles.GetEnumerator();
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
            val_9 = "m_id";
            if(val_2.Item[val_9] == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = null;
            SLC.Social.Profile val_6 = new SLC.Social.Profile();
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
            if(this.Item[19914752] == null)
            {
                    throw new NullReferenceException();
            }
            
            goto label_12;
            label_9:
            this.Add(key:  19914752, value:  val_6);
            goto label_12;
            label_2:
            val_3.Dispose();
        }
        public void AddProfile(int id, SLC.Social.Profile toAdd)
        {
            SLC.Social.Profile val_9;
            var val_10;
            val_9 = toAdd;
            val_10 = this;
            if(val_9 == null)
            {
                    return;
            }
            
            if((this.ContainsKey(key:  id)) != false)
            {
                    SLC.Social.Profile val_2 = this.Item[id];
                val_9 = ???;
                val_10 = ???;
            }
            else
            {
                    this.Add(key:  id, value:  val_9);
            }
        
        }
        public void RemoveKnownProfile(int id)
        {
            bool val_1 = this.Remove(key:  id);
        }
        public Profiles()
        {
        
        }
    
    }

}
