using UnityEngine;

namespace RestaurantRivals
{
    public class CommonEventEconDataHelper
    {
        // Methods
        private static void Log(string str)
        {
        
        }
        public static int GetPlayerTier()
        {
            return 1;
        }
        public static void ParseRewardTierList(string rawLineStr, int pointsReqColIndex, int rewQtyColIndex, int rewTypeColIndex, int currRowIndex, ref System.Collections.Generic.List<RESEventRewardData> tierList)
        {
            int val_20;
            int val_21;
            int val_22;
            string val_23;
            var val_24;
            RESEventRewardType val_25;
            int val_26;
            int val_27;
            int val_28;
            char[] val_1 = new char[1];
            val_1[0] = '	';
            System.String[] val_2 = rawLineStr.Split(separator:  val_1);
            if((System.Int32.TryParse(s:  val_2[pointsReqColIndex], style:  111, provider:  System.Globalization.CultureInfo.InvariantCulture, result: out  (RESEventRewardData)[1152921519590322080].pointsReq)) != true)
            {
                    object[] val_7 = new object[7];
                val_7[0] = "Error parsing Points Req for cell [";
                val_20 = val_7.Length;
                val_7[1] = pointsReqColIndex;
                val_20 = val_7.Length;
                val_7[2] = ", ";
                val_21 = val_7.Length;
                val_7[3] = currRowIndex;
                val_21 = val_7.Length;
                val_7[4] = "] (Defaulting value to ";
                val_22 = val_7.Length;
                val_7[5] = (RESEventRewardData)[1152921519590322080].pointsReq;
                val_22 = val_7.Length;
                val_7[6] = ")";
                string val_8 = +val_7;
            }
            
            val_23 = val_2[rewQtyColIndex];
            if((System.Decimal.TryParse(s:  val_23, style:  111, provider:  System.Globalization.CultureInfo.InvariantCulture, result: out  new System.Decimal() {flags = (RESEventRewardData)[1152921519590322080].rewardQty, hi = (RESEventRewardData)[1152921519590322080].rewardQty, lo = (RESEventRewardData)[1152921519590322080].rewardQty, mid = (RESEventRewardData)[1152921519590322080].rewardQty})) != true)
            {
                    val_24 = null;
                val_24 = null;
                val_23 = (RESEventRewardData)[1152921519590322080].metaData;
                .rewardQty = System.Decimal.MinusOne;
                if(val_23 == null)
            {
                    System.Collections.Generic.Dictionary<System.String, System.Object> val_11 = null;
                val_23 = val_11;
                val_11 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
                .metaData = val_23;
            }
            
                EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  val_11, key:  "coinListId", newValue:  val_2[rewQtyColIndex] + 32);
            }
            
            string val_13 = val_2[rewTypeColIndex].Trim().ToLowerInvariant();
            if((System.String.op_Equality(a:  val_13, b:  "spins")) == false)
            {
                goto label_45;
            }
            
            label_75:
            val_25 = 2;
            goto label_50;
            label_45:
            if((System.String.op_Equality(a:  val_13, b:  "coins")) == false)
            {
                goto label_47;
            }
            
            val_25 = 1;
            goto label_50;
            label_47:
            if((System.String.op_Equality(a:  val_13, b:  "acorns")) == false)
            {
                goto label_49;
            }
            
            val_25 = 3;
            goto label_50;
            label_49:
            if((System.String.op_Equality(a:  val_13, b:  "food")) == false)
            {
                goto label_51;
            }
            
            val_25 = 4;
            label_50:
            .rewardType = val_25;
            tierList.Add(item:  new RESEventRewardData());
            return;
            label_51:
            object[] val_18 = new object[7];
            val_18[0] = "Error parsing Reward Type for cell [";
            val_26 = val_18.Length;
            val_18[1] = rewTypeColIndex;
            val_26 = val_18.Length;
            val_18[2] = ", ";
            val_27 = val_18.Length;
            val_18[3] = currRowIndex;
            val_27 = val_18.Length;
            val_18[4] = "] (Defaulting value to ";
            val_28 = val_18.Length;
            val_18[5] = 2;
            val_28 = val_18.Length;
            val_18[6] = ")";
            string val_19 = +val_18;
            goto label_75;
        }
        public static void ParseCoinValueTierList(string rawLineStr, int tierStartColumn, int tierLastColumn, int currRowIndex, ref System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>> tierList)
        {
            string val_15;
            char[] val_1 = new char[1];
            val_1[0] = '	';
            System.String[] val_2 = rawLineStr.Split(separator:  val_1);
            bool val_5 = System.Int32.TryParse(s:  val_2[0], style:  111, provider:  System.Globalization.CultureInfo.InvariantCulture, result: out  0);
            val_15 = val_2[1];
            bool val_8 = System.Int32.TryParse(s:  val_15, style:  111, provider:  System.Globalization.CultureInfo.InvariantCulture, result: out  0);
            if(tierStartColumn > tierLastColumn)
            {
                    return;
            }
            
            var val_17 = 0;
            do
            {
                bool val_11 = System.Decimal.TryParse(s:  val_2[tierStartColumn + val_17], style:  111, provider:  System.Globalization.CultureInfo.InvariantCulture, result: out  new System.Decimal());
                RESEventCoinValue val_12 = null;
                val_15 = val_12;
                val_12 = new RESEventCoinValue();
                .levelGrpMin = 0;
                .levelGrpMax = 0;
                .coinValue = 0m;
                if((mem[tierList + 24]) <= val_17)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_16 = mem[tierList + 16];
                val_16 = val_16 + 0;
                (mem[tierList + 16] + 0) + 32.Add(item:  val_12);
                val_17 = val_17 + 1;
            }
            while((tierStartColumn + val_17) <= tierLastColumn);
        
        }
        public static RESEventRewardData GetDynamicEventReward(System.Collections.Generic.List<RESEventRewardData> tierList, System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>> coinList, int rewardProgressLevel)
        {
            var val_26;
            string val_27;
            RESEventRewardData val_28;
            int val_29;
            var val_30;
            var val_32;
            string val_33;
            string val_34;
            string val_35;
            string val_36;
            var val_37;
            string val_38;
            string val_39;
            string val_40;
            string val_41;
            string val_42;
            string val_43;
            string val_44;
            string val_45;
            int val_46;
            var val_47;
            val_26 = rewardProgressLevel;
            bool val_26 = true;
            if(tierList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_26 <= val_26)
            {
                goto label_4;
            }
            
            if(val_26 <= val_26)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_26 = val_26 + (val_26 << 3);
            val_28 = mem[(true + (rewardProgressLevel) << 3) + 32];
            val_28 = (true + (rewardProgressLevel) << 3) + 32;
            if(val_28 == 0)
            {
                goto label_4;
            }
            
            if(val_26 <= val_26)
            {
                    val_29 = (long)val_26;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_26 = val_26 + (((long)(int)(rewardProgressLevel)) << 3);
                val_28 = mem[((true + (rewardProgressLevel) << 3) + ((long)(int)(rewardProgressLevel)) << 3) + 32];
                val_28 = ((true + (rewardProgressLevel) << 3) + ((long)(int)(rewardProgressLevel)) << 3) + 32;
            }
            
            RESEventRewardData val_1 = null;
            val_30 = val_1;
            val_1 = new RESEventRewardData(rData:  val_28);
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_32 = null;
            val_32 = null;
            if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = (RESEventRewardData)[1152921519590830608].rewardQty, hi = (RESEventRewardData)[1152921519590830608].rewardQty, lo = val_29, mid = val_29}, d2:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_30>>32&0x0})) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if((RESEventRewardData)[1152921519590830608].metaData == null)
            {
                goto label_11;
            }
            
            object val_3 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  (RESEventRewardData)[1152921519590830608].metaData, key:  "coinListId", defaultValue:  0);
            if(val_3 == null)
            {
                goto label_11;
            }
            
            var val_4 = (null == null) ? (val_3) : 0;
            goto label_12;
            label_4:
            val_30 = 0;
            return (RESEventRewardData)val_30;
            label_11:
            val_33 = 0;
            label_12:
            if((System.String.IsNullOrEmpty(value:  val_33)) == true)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if((RESEventRewardData)[1152921519590830608].rewardType == 3)
            {
                goto label_14;
            }
            
            if((RESEventRewardData)[1152921519590830608].rewardType != 1)
            {
                    return (RESEventRewardData)val_30;
            }
            
            uint val_6 = _PrivateImplementationDetails_.ComputeStringHash(s:  val_33);
            if(val_6 > (-1965411662))
            {
                goto label_16;
            }
            
            if(val_6 > (-2015744519))
            {
                goto label_17;
            }
            
            if(val_6 == (-2066077376))
            {
                goto label_18;
            }
            
            if(val_6 == (-2049299757))
            {
                goto label_19;
            }
            
            if(val_6 != (-2015744519))
            {
                    return (RESEventRewardData)val_30;
            }
            
            val_34 = "C1";
            goto label_21;
            label_14:
            uint val_7 = _PrivateImplementationDetails_.ComputeStringHash(s:  val_33);
            if(val_7 > (-1730819186))
            {
                goto label_22;
            }
            
            if(val_7 > (-1814707281))
            {
                goto label_23;
            }
            
            if(val_7 == (-1831484900))
            {
                goto label_24;
            }
            
            if(val_7 != (-1814707281))
            {
                    return (RESEventRewardData)val_30;
            }
            
            val_35 = "A9";
            goto label_26;
            label_16:
            if(val_6 > (-1881523567))
            {
                goto label_27;
            }
            
            if(val_6 == (-1948634043))
            {
                goto label_28;
            }
            
            if(val_6 == (-1898301186))
            {
                goto label_29;
            }
            
            if(val_6 != (-1881523567))
            {
                    return (RESEventRewardData)val_30;
            }
            
            val_35 = "C9";
            label_26:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_35)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_35 <= 8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44440768;
            goto label_97;
            label_22:
            if(val_7 > (-1680486329))
            {
                goto label_35;
            }
            
            if(val_7 == (-1714041567))
            {
                goto label_36;
            }
            
            if(val_7 != (-1680486329))
            {
                    return (RESEventRewardData)val_30;
            }
            
            val_34 = "A1";
            label_21:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_34)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if("A1" == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44324120;
            goto label_97;
            label_17:
            if(val_6 == (-1998966900))
            {
                goto label_42;
            }
            
            if(val_6 == (-1982189281))
            {
                goto label_43;
            }
            
            if(val_6 != (-1965411662))
            {
                    return (RESEventRewardData)val_30;
            }
            
            val_38 = "C4";
            goto label_45;
            label_27:
            if(val_6 == (-1535766056))
            {
                goto label_46;
            }
            
            if(val_6 == (-1518988437))
            {
                goto label_47;
            }
            
            if(val_6 != (-1485433199))
            {
                    return (RESEventRewardData)val_30;
            }
            
            val_27 = val_33;
            val_36 = "C12";
            if((System.String.op_Equality(a:  val_27, b:  val_36)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if("C12" <= 11)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44442504;
            goto label_97;
            label_23:
            if(val_7 == (-1764374424))
            {
                goto label_53;
            }
            
            if(val_7 == (-1747596805))
            {
                goto label_54;
            }
            
            if(val_7 != (-1730819186))
            {
                    return (RESEventRewardData)val_30;
            }
            
            val_39 = "A6";
            goto label_56;
            label_35:
            if(val_7 == (-1663708710))
            {
                goto label_57;
            }
            
            if(val_7 == (-1646931091))
            {
                goto label_58;
            }
            
            if(val_7 != (-929617067))
            {
                    return (RESEventRewardData)val_30;
            }
            
            val_40 = "A10";
            goto label_60;
            label_24:
            val_41 = "A8";
            goto label_61;
            label_36:
            val_42 = "A7";
            goto label_62;
            label_19:
            val_43 = "C3";
            goto label_63;
            label_29:
            val_41 = "C8";
            label_61:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_41)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_41 <= 7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44340768;
            goto label_97;
            label_43:
            val_42 = "C7";
            label_62:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_42)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_42 <= 6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44214872;
            goto label_97;
            label_47:
            val_40 = "C10";
            label_60:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_40)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_40 <= 9)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44388392;
            goto label_97;
            label_54:
            val_44 = "A5";
            goto label_76;
            label_58:
            val_43 = "A3";
            label_63:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_43)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_43 <= 2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44242624;
            goto label_97;
            label_18:
            val_45 = "C2";
            goto label_81;
            label_28:
            val_44 = "C5";
            label_76:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_44)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_44 <= 4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44430952;
            goto label_97;
            label_42:
            val_39 = "C6";
            label_56:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_39)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_39 <= 5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44521728;
            goto label_97;
            label_46:
            val_27 = val_33;
            val_36 = "C11";
            if((System.String.op_Equality(a:  val_27, b:  val_36)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if("C11" <= 10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44490088;
            goto label_97;
            label_53:
            val_38 = "A4";
            label_45:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_38)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_38 <= 3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44232144;
            goto label_97;
            label_57:
            val_45 = "A2";
            label_81:
            val_27 = val_33;
            if((System.String.op_Equality(a:  val_27, b:  val_45)) == false)
            {
                    return (RESEventRewardData)val_30;
            }
            
            if(coinList == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_45 <= 1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_37 = 44222288;
            label_97:
            Player val_20 = App.Player;
            if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = val_20;
            val_47 = null;
            val_47 = null;
            if(App.game == 18)
            {
                    if(WordForest.WFOPlayer.Instance == null)
            {
                    throw new NullReferenceException();
            }
            
                val_46 = val_21.currentForestID;
            }
            
            List.Enumerator<T> val_22 = GetEnumerator();
            label_113:
            if(0.MoveNext() == false)
            {
                goto label_110;
            }
            
            var val_24 = (val_46 > 1) ? 1 : 0;
            if(val_46 < 11993091)
            {
                goto label_113;
            }
            
            val_24 = val_24 & ((1 != 0) ? 1 : 0);
            if((val_24 & 1) != 0)
            {
                goto label_113;
            }
            
            .rewardQty = ;
            label_110:
            0.Dispose();
            return (RESEventRewardData)val_30;
        }
        public static System.Collections.Generic.List<RESEventRewardData> GetDynamicEventRewardList(System.Collections.Generic.List<RESEventRewardData> tierList, System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>> coinList)
        {
            var val_3;
            if(tierList != null)
            {
                    System.Collections.Generic.List<RESEventRewardData> val_1 = null;
                val_3 = val_1;
                val_1 = new System.Collections.Generic.List<RESEventRewardData>();
                if(1152921516275878464 < 1)
            {
                    return (System.Collections.Generic.List<RESEventRewardData>)val_3;
            }
            
                var val_3 = 0;
                do
            {
                val_1.Add(item:  RestaurantRivals.CommonEventEconDataHelper.GetDynamicEventReward(tierList:  tierList, coinList:  coinList, rewardProgressLevel:  0));
                val_3 = val_3 + 1;
            }
            while(val_3 < 1152921516275878464);
            
                return (System.Collections.Generic.List<RESEventRewardData>)val_3;
            }
            
            val_3 = 0;
            return (System.Collections.Generic.List<RESEventRewardData>)val_3;
        }
        public CommonEventEconDataHelper()
        {
        
        }
    
    }

}
