using UnityEngine;

namespace SLC.Social.Leagues
{
    public class Guild : EncodableModel
    {
        // Fields
        public string Name;
        public int AvatarId;
        public string Motto;
        public int tier;
        public int group;
        public int rank;
        public int maximumMembers;
        public bool InviteRequired;
        public int requiredVIPLevel;
        public int ServerId;
        public int MemberCount;
        public decimal LeaguePoints;
        public decimal LeaguePointsMultiplier;
        public string LeagueContributedCoins;
        public string TotalRewardedCoins;
        public decimal TotalPoints;
        public int EventPoints;
        public int TotalLeagues;
        public int guildLevel;
        public int ActiveMemberCount;
        public SLC.Social.Profile guildMaster;
        public SLC.Social.Leagues.GuildMembers members;
        public System.Collections.Generic.List<SLC.Social.Leagues.GuildJoinRequest> pendingRequests;
        public SLC.Social.Leagues.Conversation chat;
        public SLC.Social.Leagues.Conversation log;
        
        // Properties
        public decimal GetLeagueContributedCoins { get; }
        public decimal GetTotalRewardedCoins { get; }
        public SLC.Social.Leagues.GuildLevel Level { get; }
        public SLC.Social.Leagues.GuildLevel NextLevel { get; }
        public decimal LeaguePointsFinal { get; }
        public static int RandomIcon { get; }
        
        // Methods
        public decimal get_GetLeagueContributedCoins()
        {
            return System.Decimal.Parse(s:  this.LeagueContributedCoins, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public decimal get_GetTotalRewardedCoins()
        {
            return System.Decimal.Parse(s:  this.TotalRewardedCoins, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        public SLC.Social.Leagues.GuildLevel get_Level()
        {
            return SLC.Social.Leagues.LeaguesEconomy.GetCurrentLevel(level:  this.guildLevel);
        }
        public SLC.Social.Leagues.GuildLevel get_NextLevel()
        {
            return SLC.Social.Leagues.LeaguesEconomy.GetNextLevel(level:  this.guildLevel);
        }
        public decimal get_LeaguePointsFinal()
        {
            decimal val_1 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = this.LeaguePoints, hi = this.LeaguePoints, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = this.LeaguePointsMultiplier, hi = this.LeaguePointsMultiplier, lo = -2119654592, mid = 268435459});
            return System.Decimal.Floor(d:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
        }
        public decimal ProgressThisLevel(int currentLevel)
        {
            int val_3;
            int val_4;
            var val_5;
            var val_6;
            val_3 = 0;
            val_4 = 0;
            val_5 = 0;
            goto label_1;
            label_13:
            if(val_5 >= 38021)
            {
                    return new System.Decimal() {flags = val_4, hi = val_2.hi, lo = val_3, mid = val_2.mid};
            }
            
            decimal val_1 = System.Decimal.op_Implicit(value:  SLC.Social.Leagues.LeaguesEconomy.GuildLevels + 32 + 20);
            decimal val_2 = System.Decimal.op_Addition(d1:  new System.Decimal(), d2:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
            val_4 = val_2.flags;
            val_3 = val_2.lo;
            val_5 = 1;
            label_1:
            val_6 = null;
            val_6 = null;
            if(val_5 < currentLevel)
            {
                goto label_13;
            }
            
            return new System.Decimal() {flags = val_4, hi = val_2.hi, lo = val_3, mid = val_2.mid};
        }
        public static SLC.Social.Leagues.Guild Create(string guildName, int guildIcon, string motto, SLC.Social.Profile guildMaster, bool requiresInvite, int vipLevelRequired)
        {
            .Name = guildName;
            .Motto = motto;
            .AvatarId = guildIcon;
            .requiredVIPLevel = vipLevelRequired;
            .InviteRequired = requiresInvite;
            .guildMaster = guildMaster;
            guildMaster.GuildMaster = true;
            return (SLC.Social.Leagues.Guild)new SLC.Social.Leagues.Guild();
        }
        public static int get_RandomIcon()
        {
            return 1;
        }
        public void RemoveMember(SLC.Social.Profile toRemove)
        {
            if((this.members.ContainsKey(key:  toRemove.ServerId)) == false)
            {
                    return;
            }
            
            bool val_2 = this.members.Remove(key:  toRemove.ServerId);
        }
        public void AddMember(SLC.Social.Profile toAdd)
        {
            if(toAdd == null)
            {
                    return;
            }
            
            if((this.members.ContainsKey(key:  toAdd.ServerId)) != false)
            {
                    SLC.Social.Profile val_2 = this.members.Item[toAdd.ServerId];
            }
            else
            {
                    this.members.Add(key:  toAdd.ServerId, value:  toAdd);
            }
            
            if(toAdd.GuildMaster == false)
            {
                    return;
            }
            
            this.guildMaster = toAdd;
        }
        public void AddInviteRequest(SLC.Social.Leagues.GuildJoinRequest toAdd)
        {
            this.pendingRequests.Add(item:  toAdd);
        }
        public void RemoveInvite(SLC.Social.Leagues.GuildJoinRequest toRemove)
        {
            if((this.pendingRequests.Contains(item:  toRemove)) == false)
            {
                    return;
            }
            
            bool val_2 = this.pendingRequests.Remove(item:  toRemove);
        }
        private void Destroy()
        {
            this.guildMaster = 0;
            this.members = 0;
        }
        public void MergeMembers(SLC.Social.Leagues.GuildMembers toMerge)
        {
            int val_4;
            var val_5;
            int val_16;
            SLC.Social.Leagues.GuildMembers val_17;
            System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
            Dictionary.Enumerator<TKey, TValue> val_2 = this.members.GetEnumerator();
            label_8:
            val_16 = public System.Boolean Dictionary.Enumerator<System.Int32, SLC.Social.Profile>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(toMerge == null)
            {
                    throw new NullReferenceException();
            }
            
            if((toMerge.ContainsKey(key:  val_4 + 16)) == false)
            {
                goto label_5;
            }
            
            System.TimeType val_8 = toMerge.Item[val_4 + 16];
            goto label_8;
            label_5:
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_4);
            goto label_8;
            label_2:
            val_5.Dispose();
            List.Enumerator<T> val_9 = val_1.GetEnumerator();
            label_12:
            val_16 = public System.Boolean List.Enumerator<System.Int32>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_10;
            }
            
            val_17 = this.members;
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_11 = val_17.Remove(key:  val_4);
            goto label_12;
            label_10:
            val_5.Dispose();
            Dictionary.Enumerator<TKey, TValue> val_12 = toMerge.GetEnumerator();
            label_18:
            val_16 = public System.Boolean Dictionary.Enumerator<System.Int32, SLC.Social.Profile>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_14;
            }
            
            val_17 = this.members;
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_16 = val_4;
            if((val_17.ContainsKey(key:  val_16)) == true)
            {
                goto label_18;
            }
            
            val_17 = this.members;
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_17.Add(key:  val_4, value:  val_4);
            goto label_18;
            label_14:
            val_5.Dispose();
        }
        public void MergeInvites(System.Collections.Generic.List<object> invitesToParse)
        {
            var val_3;
            var val_4;
            string val_10;
            System.Collections.Generic.List<SLC.Social.Leagues.GuildJoinRequest> val_11;
            var val_12;
            this.pendingRequests = new System.Collections.Generic.List<SLC.Social.Leagues.GuildJoinRequest>();
            List.Enumerator<T> val_2 = invitesToParse.GetEnumerator();
            label_14:
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_3 != 0)
            {
                    val_10 = null;
            }
            
            SLC.Social.Profile val_6 = null;
            val_10 = 0;
            val_6 = new SLC.Social.Profile();
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_10 = "membership";
            object val_7 = val_3.Item[val_10];
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_12 = 0;
            val_6.Decode(jasonObject:  null, sourceModel:  0);
            .sender = val_6;
            .requestedGuild = this;
            val_10 = "id";
            if(val_3.Item[val_10] == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10 = null;
            .ServerId = null;
            val_11 = this.pendingRequests;
            if(val_11 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_11.Add(item:  new SLC.Social.Leagues.GuildJoinRequest());
            goto label_14;
            label_2:
            val_4.Dispose();
        }
        public void MergeChat(System.Collections.Generic.List<object> toParse)
        {
            string val_2;
            var val_3;
            string val_5;
            this.chat.Clear();
            List.Enumerator<T> val_1 = toParse.GetEnumerator();
            val_5 = val_2;
            label_7:
            if(val_3.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(val_5 != 0)
            {
                    val_5 = null;
                if(val_5 != val_5)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            if(this.chat == null)
            {
                    throw new NullReferenceException();
            }
            
            this.chat.Add(item:  val_5);
            goto label_7;
            label_3:
            val_3.Dispose();
        }
        public void MergeLog(System.Collections.Generic.List<object> toParse)
        {
            string val_2;
            var val_3;
            string val_5;
            this.log.Clear();
            List.Enumerator<T> val_1 = toParse.GetEnumerator();
            val_5 = val_2;
            label_7:
            if(val_3.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(val_5 != 0)
            {
                    val_5 = null;
                if(val_5 != val_5)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            if(this.log == null)
            {
                    throw new NullReferenceException();
            }
            
            this.log.Add(item:  val_5);
            goto label_7;
            label_3:
            val_3.Dispose();
        }
        public SLC.Social.Profile[] GetMembers()
        {
            return System.Linq.Enumerable.ToArray<SLC.Social.Profile>(source:  this.members.Values);
        }
        public int GetRankInGuildById(int id)
        {
            var val_13;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Decimal> val_15;
            var val_16;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Decimal> val_18;
            var val_19;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Int32> val_21;
            System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, SLC.Social.Profile> val_23;
            .id = id;
            val_13 = null;
            val_13 = null;
            val_15 = Guild.<>c.<>9__49_0;
            if(val_15 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Decimal> val_2 = null;
                val_15 = val_2;
                val_2 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Decimal>(object:  Guild.<>c.__il2cppRuntimeField_static_fields, method:  System.Decimal Guild.<>c::<GetRankInGuildById>b__49_0(System.Collections.Generic.KeyValuePair<int, SLC.Social.Profile> x));
                Guild.<>c.<>9__49_0 = val_15;
            }
            
            val_16 = null;
            val_16 = null;
            val_18 = Guild.<>c.<>9__49_1;
            if(val_18 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Decimal> val_4 = null;
                val_18 = val_4;
                val_4 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Decimal>(object:  Guild.<>c.__il2cppRuntimeField_static_fields, method:  System.Decimal Guild.<>c::<GetRankInGuildById>b__49_1(System.Collections.Generic.KeyValuePair<int, SLC.Social.Profile> x));
                Guild.<>c.<>9__49_1 = val_18;
            }
            
            val_19 = null;
            val_19 = null;
            val_21 = Guild.<>c.<>9__49_2;
            if(val_21 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Int32> val_6 = null;
                val_21 = val_6;
                val_6 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Int32>(object:  Guild.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 Guild.<>c::<GetRankInGuildById>b__49_2(System.Collections.Generic.KeyValuePair<int, SLC.Social.Profile> t));
                val_19 = null;
                Guild.<>c.<>9__49_2 = val_21;
            }
            
            val_19 = null;
            val_23 = Guild.<>c.<>9__49_3;
            if(val_23 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, SLC.Social.Profile> val_7 = null;
                val_23 = val_7;
                val_7 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, SLC.Social.Profile>(object:  Guild.<>c.__il2cppRuntimeField_static_fields, method:  SLC.Social.Profile Guild.<>c::<GetRankInGuildById>b__49_3(System.Collections.Generic.KeyValuePair<int, SLC.Social.Profile> t));
                Guild.<>c.<>9__49_3 = val_23;
            }
            
            int val_12 = System.Linq.Enumerable.ToList<SLC.Social.Profile>(source:  System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Int32, SLC.Social.Profile>(source:  System.Linq.Enumerable.ThenByDescending<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Decimal>(source:  System.Linq.Enumerable.OrderByDescending<System.Collections.Generic.KeyValuePair<System.Int32, SLC.Social.Profile>, System.Decimal>(source:  this.members, keySelector:  val_2), keySelector:  val_4), keySelector:  val_6, elementSelector:  val_7).Values).FindIndex(match:  new System.Predicate<SLC.Social.Profile>(object:  new Guild.<>c__DisplayClass49_0(), method:  System.Boolean Guild.<>c__DisplayClass49_0::<GetRankInGuildById>b__4(SLC.Social.Profile x)));
            val_12 = val_12 + 1;
            return (int)val_12;
        }
        public override string ToString()
        {
            return System.String.Format(format:  "[Guild: {0}]", arg0:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        }
        public Guild()
        {
            decimal val_1;
            this.tier = 15;
            val_1 = new System.Decimal(lo:  10, mid:  0, hi:  0, isNegative:  false, scale:  1);
            this.guildLevel = 1;
            this.LeaguePointsMultiplier = val_1.flags;
            this.members = new SLC.Social.Leagues.GuildMembers();
            this.pendingRequests = new System.Collections.Generic.List<SLC.Social.Leagues.GuildJoinRequest>();
            this.chat = new SLC.Social.Leagues.Conversation();
            this.log = new SLC.Social.Leagues.Conversation();
        }
    
    }

}
