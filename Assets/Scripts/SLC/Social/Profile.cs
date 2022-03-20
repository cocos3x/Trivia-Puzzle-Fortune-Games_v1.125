using UnityEngine;

namespace SLC.Social
{
    public class Profile : EncodableModel
    {
        // Fields
        public int ServerId;
        public string Name;
        public int Level;
        public int LifetimeLeaguePoints;
        public int LastSeasonLeaguePoints;
        public int BestSeasonLeaguePoints;
        public int LastSeasonRankInClub;
        public int AvatarId;
        public string Portrait_ID;
        public string FacebookId;
        public bool UseFacebook;
        public bool IsAdmin;
        public int GuildServerId;
        public int UserId;
        public int firstJoinedClubAt;
        public decimal leaguePoints;
        public bool GuildMaster;
        public bool Officer;
        public int contributedAt;
        public string leagueCoins;
        public int PendingGuildRequestId;
        public bool mvp;
        public decimal mvpReward;
        public int goldenCurrency;
        public bool hasSubscriptionActive;
        public bool isMemberActive;
        public string _wordIQ;
        
        // Properties
        public bool hasJoinedClub { get; }
        public float WordIQ { get; set; }
        public int GuildMemberId { get; set; }
        public System.DateTime GetContributedAt { get; }
        public decimal GetLeagueCoins { get; }
        
        // Methods
        public bool get_hasJoinedClub()
        {
            return (bool)(this.firstJoinedClubAt != 0) ? 1 : 0;
        }
        public float get_WordIQ()
        {
            if((System.String.IsNullOrEmpty(value:  this._wordIQ)) != false)
            {
                    this._wordIQ = WordIQManager.BaseIQ.ToString();
                float val_4 = WordIQManager.BaseIQ;
                return (float)WordIQManager.BaseIQ;
            }
            
            bool val_7 = System.Single.TryParse(s:  this._wordIQ, result: out  float val_6 = 0f);
            return (float)WordIQManager.BaseIQ;
        }
        public void set_WordIQ(float value)
        {
            this._wordIQ = value.ToString();
        }
        public int get_GuildMemberId()
        {
            return (int)this.ServerId;
        }
        public void set_GuildMemberId(int value)
        {
            this.ServerId = value;
        }
        public System.DateTime get_GetContributedAt()
        {
            System.DateTime val_1 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, millisecond:  0);
            System.DateTime val_2 = val_1.dateData.AddSeconds(value:  (double)this.contributedAt);
            return (System.DateTime)val_2.dateData;
        }
        public decimal get_GetLeagueCoins()
        {
            return System.Decimal.Parse(s:  this.leagueCoins, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public override void Merge(EncodableModel model)
        {
            System.Collections.Generic.IEnumerable<TSource> val_14;
            var val_15;
            var val_16;
            System.Func<System.Reflection.FieldInfo, System.Boolean> val_18;
            val_15 = model;
            if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = this.GetType();
            System.Type val_2 = val_15.GetType();
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_14 & 1) == 0)
            {
                    return;
            }
            
            val_14 = val_15.GetType();
            System.Type val_4 = this.GetType();
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_14 & 1) == 0)
            {
                    return;
            }
            
            System.Type val_5 = this.GetType();
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = val_5;
            val_16 = null;
            val_16 = null;
            val_18 = Profile.<>c.<>9__39_0;
            if(val_18 == null)
            {
                    System.Func<System.Reflection.FieldInfo, System.Boolean> val_6 = null;
                val_18 = val_6;
                val_6 = new System.Func<System.Reflection.FieldInfo, System.Boolean>(object:  Profile.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean Profile.<>c::<Merge>b__39_0(System.Reflection.FieldInfo field));
                Profile.<>c.<>9__39_0 = val_18;
            }
            
            System.Collections.Generic.IEnumerable<TSource> val_7 = System.Linq.Enumerable.Where<System.Reflection.FieldInfo>(source:  val_14, predicate:  val_6);
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_17 = 0;
            val_17 = val_17 + 1;
            val_14 = val_7.GetEnumerator();
            label_30:
            var val_18 = 0;
            val_18 = val_18 + 1;
            if(val_14.MoveNext() == false)
            {
                goto label_22;
            }
            
            var val_19 = 0;
            val_19 = val_19 + 1;
            T val_13 = val_14.Current;
            System.Type val_14 = val_15.GetType();
            if(val_13 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Reflection.FieldInfo val_15 = val_14.GetField(name:  val_13);
            if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_13.SetValue(obj:  this, value:  val_15);
            goto label_30;
            label_22:
            val_15 = 0;
            if(val_14 != null)
            {
                    var val_20 = 0;
                val_20 = val_20 + 1;
                val_14.Dispose();
            }
            
            if(val_15 != 0)
            {
                    throw val_15;
            }
        
        }
        public override string ToString()
        {
            return System.String.Format(format:  "[Profile: {0}]", arg0:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this, formatting:  1));
        }
        public Profile()
        {
            this.Level = 1;
            this.Name = "Player";
            this.LastSeasonRankInClub = 0;
            this.Portrait_ID = System.String.alignConst;
            this.GuildServerId = 0;
            this.FacebookId = "";
            this._wordIQ = "";
        }
    
    }

}
