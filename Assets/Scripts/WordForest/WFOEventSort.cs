using UnityEngine;

namespace WordForest
{
    public class WFOEventSort : IComparer<WGEventHandler>
    {
        // Methods
        protected int GetSortOrder(string eventId)
        {
            var val_10;
            uint val_1 = _PrivateImplementationDetails_.ComputeStringHash(s:  eventId);
            if(val_1 > (-1392364358))
            {
                goto label_1;
            }
            
            if(val_1 > 999457290)
            {
                goto label_2;
            }
            
            if(val_1 == 145907821)
            {
                goto label_3;
            }
            
            if((val_1 != 999457290) || ((System.String.op_Equality(a:  eventId, b:  "AttackMadness")) == false))
            {
                goto label_26;
            }
            
            val_10 = 1;
            return 999;
            label_1:
            if(val_1 > (-1050565114))
            {
                goto label_7;
            }
            
            if(val_1 == (-1129030916))
            {
                goto label_8;
            }
            
            if((val_1 != (-1050565114)) || ((System.String.op_Equality(a:  eventId, b:  "ForestMaster")) == false))
            {
                goto label_26;
            }
            
            val_10 = 4;
            return 999;
            label_2:
            if(val_1 == (-1392364358))
            {
                goto label_12;
            }
            
            if((val_1 != 1751534916) || ((System.String.op_Equality(a:  eventId, b:  "HotNSpicy")) == false))
            {
                goto label_26;
            }
            
            val_10 = 3;
            return 999;
            label_7:
            if(val_1 == (-623396922))
            {
                goto label_16;
            }
            
            if((val_1 != (-84738646)) || ((System.String.op_Equality(a:  eventId, b:  "LightningLevels")) == false))
            {
                goto label_26;
            }
            
            val_10 = 5;
            return 999;
            label_3:
            if((System.String.op_Equality(a:  eventId, b:  "IslandParadiseSymbol")) == false)
            {
                goto label_26;
            }
            
            val_10 = 7;
            return 999;
            label_8:
            if((System.String.op_Equality(a:  eventId, b:  "WordHunt")) == false)
            {
                goto label_26;
            }
            
            val_10 = 8;
            return 999;
            label_12:
            if((System.String.op_Equality(a:  eventId, b:  "WildWordWeekend")) == false)
            {
                goto label_26;
            }
            
            val_10 = 6;
            return 999;
            label_16:
            if((System.String.op_Equality(a:  eventId, b:  "RaidMadness")) != false)
            {
                    val_10 = 2;
                return 999;
            }
            
            label_26:
            val_10 = 999;
            return 999;
        }
        public int Compare(WGEventHandler eventA, WGEventHandler eventB)
        {
            var val_10;
            string val_1 = eventA.EventType;
            string val_3 = eventB.EventType;
            if((val_1.GetSortOrder(eventId:  val_1)) > (val_3.GetSortOrder(eventId:  val_3)))
            {
                    val_10 = 1;
                return (int)((val_5.GetSortOrder(eventId:  string val_5 = eventA.EventType)) < (val_7.GetSortOrder(eventId:  string val_7 = eventB.EventType))) ? -1 : 0;
            }
            
            return (int)((val_5.GetSortOrder(eventId:  val_5)) < (val_7.GetSortOrder(eventId:  val_7))) ? -1 : 0;
        }
        public WFOEventSort()
        {
        
        }
    
    }

}
