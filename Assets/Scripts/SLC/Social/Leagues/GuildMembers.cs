using UnityEngine;

namespace SLC.Social.Leagues
{
    public class GuildMembers : Dictionary<int, SLC.Social.Profile>
    {
        // Methods
        public void UpdateMembers(System.Collections.Generic.List<object> guildMembers, EncodableModel.TemplateModel fromModel = 0, int excludeId = -1)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2;
            var val_3;
            string val_9;
            List.Enumerator<T> val_1 = guildMembers.GetEnumerator();
            label_14:
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
            if(excludeId != 1)
            {
                    if(null == excludeId)
            {
                goto label_14;
            }
            
            }
            
            SLC.Social.Profile val_6 = null;
            val_9 = 0;
            val_6 = new SLC.Social.Profile();
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_6.Decode(jasonObject:  val_2, sourceModel:  fromModel);
            if((this.ContainsKey(key:  19914752)) == false)
            {
                goto label_11;
            }
            
            val_9 = 1152921504626761728;
            if(this.Item[19914752] == null)
            {
                    throw new NullReferenceException();
            }
            
            goto label_14;
            label_11:
            this.Add(key:  19914752, value:  val_6);
            goto label_14;
            label_2:
            val_3.Dispose();
        }
        public void UpdateMembers(System.Collections.Generic.List<SLC.Social.Leagues.GuildJoinRequest> requests)
        {
            var val_2;
            var val_3;
            int val_7;
            var val_8;
            List.Enumerator<T> val_1 = requests.GetEnumerator();
            label_10:
            val_7 = public System.Boolean List.Enumerator<SLC.Social.Leagues.GuildJoinRequest>::MoveNext();
            if(val_3.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_2 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_2 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_7 = mem[val_2 + 16 + 16];
            val_7 = val_2 + 16 + 16;
            val_8 = this;
            if((this.ContainsKey(key:  val_7)) == false)
            {
                goto label_5;
            }
            
            if((val_2 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_7 = mem[val_2 + 16 + 16];
            val_7 = val_2 + 16 + 16;
            if(this.Item[val_7] == null)
            {
                    throw new NullReferenceException();
            }
            
            goto label_10;
            label_5:
            if((val_2 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            this.Add(key:  val_2 + 16 + 16, value:  val_2 + 16);
            goto label_10;
            label_2:
            val_3.Dispose();
        }
        public override string ToString()
        {
            return System.String.Format(format:  "[GuildMembers] {0}", arg0:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        }
        public GuildMembers()
        {
        
        }
    
    }

}
