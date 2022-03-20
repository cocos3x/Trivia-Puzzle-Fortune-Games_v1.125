using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesEconomy
    {
        // Fields
        public static decimal CostToCreate;
        public static int LeaguesPerGroup;
        public static SLC.Social.Leagues.GuildLevel[] GuildLevels;
        private static System.Decimal[] SupportOptions;
        public static System.TimeSpan AllowedDonationInterval;
        private static System.Decimal[] RequirementOptions;
        public static decimal MultiplierCostScale;
        public static System.Decimal[] MultiplierOptions;
        public static SLC.Social.Leagues.SeasonRewards seasonRewards;
        
        // Methods
        public static void UpdateGuildRanksEconomy(System.Collections.Generic.List<object> response)
        {
            var val_3;
            var val_4;
            var val_16;
            string val_18;
            var val_19;
            System.Func<SLC.Social.Leagues.GuildLevel, System.Int32> val_21;
            var val_22;
            System.Collections.Generic.List<SLC.Social.Leagues.GuildLevel> val_1 = new System.Collections.Generic.List<SLC.Social.Leagues.GuildLevel>();
            List.Enumerator<T> val_2 = response.GetEnumerator();
            val_16 = 1152921510211410768;
            label_15:
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            SLC.Social.Leagues.GuildLevel val_6 = null;
            val_18 = 0;
            val_6 = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 0;
            .RequiredCoinSupport = 0;
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_18 = "max_members";
            object val_8 = Item[val_18];
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_18 = 0;
            .MaximumMembers = System.Int32.Parse(s:  val_8);
            val_18 = "coin_support";
            object val_11 = Item[val_18];
            if(val_11 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_18 = 0;
            .RequiredCoinSupport = System.Int32.Parse(s:  val_11);
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_6);
            goto label_15;
            label_2:
            val_4.Dispose();
            val_19 = null;
            val_19 = null;
            val_21 = LeaguesEconomy.<>c.<>9__8_0;
            if(val_21 == null)
            {
                    System.Func<SLC.Social.Leagues.GuildLevel, System.Int32> val_13 = null;
                val_21 = val_13;
                val_13 = new System.Func<SLC.Social.Leagues.GuildLevel, System.Int32>(object:  LeaguesEconomy.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LeaguesEconomy.<>c::<UpdateGuildRanksEconomy>b__8_0(SLC.Social.Leagues.GuildLevel x));
                LeaguesEconomy.<>c.<>9__8_0 = val_21;
            }
            
            val_22 = null;
            val_22 = null;
            SLC.Social.Leagues.LeaguesEconomy.GuildLevels = System.Linq.Enumerable.ToArray<SLC.Social.Leagues.GuildLevel>(source:  System.Linq.Enumerable.OrderBy<SLC.Social.Leagues.GuildLevel, System.Int32>(source:  val_1, keySelector:  val_13));
        }
        public static void UpdateRequirementOptions(System.Collections.Generic.List<object> response)
        {
            string val_3;
            var val_4;
            System.IFormatProvider val_9;
            string val_10;
            var val_11;
            System.Collections.Generic.List<System.Decimal> val_1 = new System.Collections.Generic.List<System.Decimal>();
            List.Enumerator<T> val_2 = response.GetEnumerator();
            label_9:
            val_9 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_10 = val_3;
            if(val_10 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_10 = val_10;
            val_9 = System.Globalization.CultureInfo.InvariantCulture;
            decimal val_7 = System.Decimal.Parse(s:  val_10, provider:  val_9);
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
            goto label_9;
            label_2:
            val_4.Dispose();
            val_11 = null;
            val_11 = null;
            SLC.Social.Leagues.LeaguesEconomy.RequirementOptions = val_1.ToArray();
        }
        public static void UpdateContributionOptions(System.Collections.Generic.List<object> response)
        {
            string val_3;
            var val_4;
            System.IFormatProvider val_9;
            string val_10;
            var val_11;
            System.Collections.Generic.List<System.Decimal> val_1 = new System.Collections.Generic.List<System.Decimal>();
            List.Enumerator<T> val_2 = response.GetEnumerator();
            label_9:
            val_9 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_10 = val_3;
            if(val_10 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_10 = val_10;
            val_9 = System.Globalization.CultureInfo.InvariantCulture;
            decimal val_7 = System.Decimal.Parse(s:  val_10, provider:  val_9);
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
            goto label_9;
            label_2:
            val_4.Dispose();
            val_11 = null;
            val_11 = null;
            SLC.Social.Leagues.LeaguesEconomy.SupportOptions = val_1.ToArray();
        }
        public static void UpdateMultiplierOptions(System.Collections.Generic.List<object> response)
        {
            string val_3;
            var val_4;
            T[] val_10;
            System.IFormatProvider val_11;
            string val_12;
            var val_13;
            System.Collections.Generic.List<System.Decimal> val_1 = null;
            val_10 = val_1;
            val_1 = new System.Collections.Generic.List<System.Decimal>();
            List.Enumerator<T> val_2 = response.GetEnumerator();
            label_10:
            val_11 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_12 = val_3;
            if(val_12 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_12 = val_12;
            val_11 = System.Globalization.CultureInfo.InvariantCulture;
            decimal val_7 = System.Decimal.Parse(s:  val_12, provider:  val_11);
            if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
            {
                goto label_8;
            }
            
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
            goto label_10;
            label_2:
            val_4.Dispose();
            val_10 = val_1.ToArray();
            val_13 = null;
            val_13 = null;
            SLC.Social.Leagues.LeaguesEconomy.MultiplierOptions = val_10;
            return;
            label_8:
            val_4.Dispose();
        }
        public static void UpdateSeasonRewardsEconomy(System.Collections.Generic.Dictionary<string, object> response)
        {
            string val_3;
            var val_4;
            var val_8;
            string val_9;
            SLC.Social.Leagues.SeasonRewards val_10;
            var val_11;
            val_8 = null;
            val_8 = null;
            SLC.Social.Leagues.LeaguesEconomy.seasonRewards.Clear();
            Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = response.Keys.GetEnumerator();
            label_14:
            if(val_4.MoveNext() == false)
            {
                goto label_6;
            }
            
            SLC.Social.Leagues.SeasonReward val_6 = new SLC.Social.Leagues.SeasonReward();
            val_9 = val_3;
            object val_7 = response.Item[val_9];
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = 0;
            val_6.Decode(jasonObject:  null, sourceModel:  0);
            val_11 = null;
            val_11 = null;
            val_10 = SLC.Social.Leagues.LeaguesEconomy.seasonRewards;
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10.Add(key:  val_3, value:  val_6);
            goto label_14;
            label_6:
            val_4.Dispose();
        }
        public static SLC.Social.Leagues.GuildLevel GetCurrentLevel(int level)
        {
            null = null;
            SLC.Social.Leagues.GuildLevel[] val_2 = SLC.Social.Leagues.LeaguesEconomy.GuildLevels;
            val_2 = val_2 + ((level - 1) << 3);
            return (SLC.Social.Leagues.GuildLevel)(SLC.Social.Leagues.LeaguesEconomy.GuildLevels + ((level - 1)) << 3) + 32;
        }
        public static SLC.Social.Leagues.GuildLevel GetNextLevel(int level)
        {
            null = null;
            SLC.Social.Leagues.GuildLevel[] val_3 = SLC.Social.Leagues.LeaguesEconomy.GuildLevels + ((UnityEngine.Mathf.Min(a:  level, b:  SLC.Social.Leagues.LeaguesEconomy.GuildLevels.Length - 1)) << 3);
            return (SLC.Social.Leagues.GuildLevel)(SLC.Social.Leagues.LeaguesEconomy.GuildLevels + (val_2) << 3) + 32;
        }
        public static decimal GetSupportOption(int index)
        {
            null = null;
            System.Decimal[] val_1 = SLC.Social.Leagues.LeaguesEconomy.SupportOptions;
            val_1 = val_1 + (((long)(int)(index)) << 4);
            return new System.Decimal() {flags = (SLC.Social.Leagues.LeaguesEconomy.SupportOptions + ((long)(int)(index)) << 4) + 32, hi = (SLC.Social.Leagues.LeaguesEconomy.SupportOptions + ((long)(int)(index)) << 4) + 32, lo = (SLC.Social.Leagues.LeaguesEconomy.SupportOptions + ((long)(int)(index)) << 4) + 32 + 8, mid = (SLC.Social.Leagues.LeaguesEconomy.SupportOptions + ((long)(int)(index)) << 4) + 32 + 8};
        }
        public static System.Decimal[] GetRequirementOptions()
        {
            null = null;
            return (System.Decimal[])SLC.Social.Leagues.LeaguesEconomy.RequirementOptions;
        }
        public static int GetIndexOfRequirementOption(decimal req)
        {
            var val_3;
            var val_4;
            var val_5;
            val_3 = 0;
            val_4 = 0;
            goto label_1;
            label_11:
            val_3 = 1;
            label_1:
            val_5 = null;
            val_5 = null;
            if(val_3 < SLC.Social.Leagues.LeaguesEconomy.RequirementOptions.Length)
            {
                goto label_11;
            }
            
            return (int)((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + 32, hi = SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + 32, lo = SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + 32 + 8, mid = SLC.Social.Leagues.LeaguesEconomy.RequirementOptions + 32 + 8}, d2:  new System.Decimal() {flags = req.flags, hi = req.hi, lo = req.lo, mid = req.mid})) != true) ? (val_3) : (val_4);
        }
        public static SLC.Social.Leagues.SeasonReward GetSeasonRewardForTier(SLC.Social.Leagues.GuildTier tier)
        {
            var val_4 = null;
            return (SLC.Social.Leagues.SeasonReward)SLC.Social.Leagues.LeaguesEconomy.seasonRewards.Item[tier.ToString().Replace(oldValue:  "_", newValue:  " ")];
        }
        public static decimal GetRewardedCoinsPerDay(decimal totalRewardedCoins, int totalLeagues)
        {
            decimal val_2 = System.Decimal.op_Explicit(value:  UnityEngine.Mathf.Max(a:  (float)totalLeagues, b:  1f));
            decimal val_3 = new System.Decimal(value:  7);
            decimal val_4 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.flags, lo = val_3.lo, mid = val_3.lo});
            decimal val_5 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = totalRewardedCoins.flags, hi = totalRewardedCoins.hi, lo = totalRewardedCoins.lo, mid = totalRewardedCoins.mid}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
            return new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid};
        }
        public LeaguesEconomy()
        {
        
        }
        private static LeaguesEconomy()
        {
            decimal val_1 = new System.Decimal(value:  120);
            SLC.Social.Leagues.LeaguesEconomy.CostToCreate = val_1.flags;
            SLC.Social.Leagues.LeaguesEconomy.LeaguesPerGroup = 15;
            SLC.Social.Leagues.GuildLevel[] val_2 = new SLC.Social.Leagues.GuildLevel[20];
            .MaximumMembers = 10;
            .RequiredCoinSupport = 0;
            val_2[0] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 15;
            .RequiredCoinSupport = 1000;
            val_2[1] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 20;
            .RequiredCoinSupport = 1250;
            val_2[2] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 25;
            .RequiredCoinSupport = 1500;
            val_2[3] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 30;
            .RequiredCoinSupport = 2000;
            val_2[4] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 35;
            .RequiredCoinSupport = 2500;
            val_2[5] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 40;
            .RequiredCoinSupport = 3000;
            val_2[6] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 45;
            .RequiredCoinSupport = 4000;
            val_2[7] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 50;
            .RequiredCoinSupport = 5000;
            val_2[8] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 55;
            .RequiredCoinSupport = 7500;
            val_2[9] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 60;
            .RequiredCoinSupport = 10000;
            val_2[10] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 65;
            .RequiredCoinSupport = 12500;
            val_2[11] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 70;
            .RequiredCoinSupport = 15000;
            val_2[12] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 75;
            .RequiredCoinSupport = 17500;
            val_2[13] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 80;
            .RequiredCoinSupport = 20000;
            val_2[14] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 85;
            .RequiredCoinSupport = 22500;
            val_2[15] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 90;
            .RequiredCoinSupport = 25000;
            val_2[16] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 95;
            .RequiredCoinSupport = 27500;
            val_2[17] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 97;
            .RequiredCoinSupport = 30000;
            val_2[18] = new SLC.Social.Leagues.GuildLevel();
            .MaximumMembers = 100;
            .RequiredCoinSupport = 35000;
            val_2[19] = new SLC.Social.Leagues.GuildLevel();
            SLC.Social.Leagues.LeaguesEconomy.GuildLevels = val_2;
            decimal[] val_23 = new decimal[3];
            decimal val_24 = new System.Decimal(value:  50);
            val_23[0] = val_24.flags;
            decimal val_25 = new System.Decimal(value:  150);
            val_23[1] = val_25.flags;
            decimal val_26 = new System.Decimal(value:  250);
            val_23[2] = val_26.flags;
            SLC.Social.Leagues.LeaguesEconomy.SupportOptions = val_23;
            System.TimeSpan val_27 = System.TimeSpan.FromDays(value:  1);
            SLC.Social.Leagues.LeaguesEconomy.AllowedDonationInterval = val_27._ticks;
            decimal[] val_28 = new decimal[7];
            decimal val_29 = new System.Decimal(value:  244);
            val_28[1] = val_29.flags;
            decimal val_30 = new System.Decimal(value:  232);
            val_28[2] = val_30.flags;
            decimal val_31 = new System.Decimal(value:  196);
            val_28[3] = val_31.flags;
            decimal val_32 = new System.Decimal(value:  136);
            val_28[4] = val_32.flags;
            decimal val_33 = new System.Decimal(value:  16);
            val_28[5] = val_33.flags;
            decimal val_34 = new System.Decimal(value:  168);
            val_28[6] = val_34.flags;
            SLC.Social.Leagues.LeaguesEconomy.RequirementOptions = val_28;
            decimal val_35 = new System.Decimal(value:  100);
            SLC.Social.Leagues.LeaguesEconomy.MultiplierCostScale = val_35.flags;
            decimal[] val_36 = new decimal[4];
            decimal val_37 = new System.Decimal(lo:  1, mid:  0, hi:  0, isNegative:  false, scale:  1);
            val_36[0] = val_37.flags;
            decimal val_38 = new System.Decimal(lo:  2, mid:  0, hi:  0, isNegative:  false, scale:  1);
            val_36[1] = val_38.flags;
            decimal val_39 = new System.Decimal(lo:  5, mid:  0, hi:  0, isNegative:  false, scale:  1);
            decimal val_40;
            val_36[2] = val_39.flags;
            val_40 = new System.Decimal(lo:  10, mid:  0, hi:  0, isNegative:  false, scale:  1);
            val_36[3] = val_40.flags;
            SLC.Social.Leagues.LeaguesEconomy.MultiplierOptions = val_36;
            SLC.Social.Leagues.LeaguesEconomy.seasonRewards = new SLC.Social.Leagues.SeasonRewards();
        }
    
    }

}
