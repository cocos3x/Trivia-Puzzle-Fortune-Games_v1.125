using UnityEngine;

namespace SRF
{
    public static class SRFIListExtensions
    {
        // Methods
        public static T Random<T>(System.Collections.Generic.IList<T> list)
        {
            var val_8;
            var val_10;
            var val_12;
            var val_15;
            var val_16;
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_8 = 0;
            val_10 = mem[(VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48), slot: 0) + 8];
            val_10 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48), slot: 0) + 8;
            if(list == null)
            {
                    throw new System.IndexOutOfRangeException(message:  "List needs at least one entry to call Random()");
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_10 = __RuntimeMethodHiddenParam + 48;
            val_8 = 0;
            val_12 = mem[(VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48), slot: 0) + 8];
            val_12 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48), slot: 0) + 8;
            if(list != 1)
            {
                goto label_13;
            }
            
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_8 = 0;
            goto label_18;
            label_13:
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_12 = __RuntimeMethodHiddenParam + 48;
            goto label_23;
            label_18:
            val_15 = mem[(VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0)];
            val_15 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0);
            goto (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0);
            label_23:
            val_16 = 0;
            int val_5 = UnityEngine.Random.Range(min:  0, max:  list);
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_16 = 0;
            val_15 = mem[(VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0)];
            val_15 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0);
            goto (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0);
        }
        public static T RandomOrDefault<T>(System.Collections.Generic.IList<T> list)
        {
            System.Collections.Generic.IList<T> val_7 = list;
            var val_7 = 0;
            val_7 = val_7 + 1;
            if(val_7 == null)
            {
                    return 0;
            }
            
            val_7 = ???;
            goto __RuntimeMethodHiddenParam + 48 + 8;
        }
        public static T PopLast<T>(System.Collections.Generic.IList<T> list)
        {
            var val_7;
            var val_9;
            var val_12;
            var val_13;
            var val_7 = 0;
            val_7 = val_7 + 1;
            val_7 = 0;
            val_9 = mem[(VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48), slot: 0) + 8];
            val_9 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48), slot: 0) + 8;
            if(list == null)
            {
                    throw new System.InvalidOperationException();
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_9 = __RuntimeMethodHiddenParam + 48;
            val_7 = 0;
            System.Collections.Generic.IList<T> val_9 = list;
            val_9 = val_9 - 1;
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_7 = 0;
            val_12 = mem[(VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0) + 8];
            val_12 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(list, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0) + 8;
            val_13 = val_9;
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_13 = __RuntimeMethodHiddenParam + 48;
            val_12 = 0;
            System.Collections.Generic.IList<T> val_12 = list;
            val_12 = val_12 - 1;
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_12 = 4;
            return (Row)list;
        }
    
    }

}
