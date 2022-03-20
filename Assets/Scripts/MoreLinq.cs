using UnityEngine;
public static class MoreLinq
{
    // Methods
    public static TSource MaxBy<TSource, TKey>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> selector)
    {
        goto __RuntimeMethodHiddenParam + 48 + 16;
    }
    public static TSource MaxBy<TSource, TKey>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> selector, System.Collections.Generic.IComparer<TKey> comparer)
    {
        var val_13;
        var val_15;
        var val_17;
        var val_19;
        var val_20;
        var val_21;
        string val_27;
        val_13 = __RuntimeMethodHiddenParam;
        if(source == null)
        {
            goto label_1;
        }
        
        if(selector == 0)
        {
            goto label_2;
        }
        
        if(comparer == null)
        {
            goto label_3;
        }
        
        var val_15 = 0;
        val_15 = val_15 + 1;
        val_15 = source;
        var val_16 = 0;
        val_16 = val_16 + 1;
        val_17 = public System.Boolean System.Collections.IEnumerator::MoveNext();
        if(val_15.MoveNext() == false)
        {
                throw new System.InvalidOperationException(message:  "Sequence contains no elements");
        }
        
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_17 = __RuntimeMethodHiddenParam + 48 + 8;
        val_19 = val_15;
        val_20 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(source, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0) + 8;
        val_21 = selector;
        goto label_20;
        label_35:
        var val_18 = 0;
        val_18 = val_18 + 1;
        var val_19 = 0;
        val_19 = val_19 + 1;
        var val_7 = (comparer < 1) ? (val_21) : selector;
        var val_9 = (comparer < 1) ? (val_20) : ((VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(source, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0) + 8);
        label_20:
        var val_20 = 0;
        val_20 = val_20 + 1;
        if(val_15.MoveNext() == true)
        {
            goto label_35;
        }
        
        val_13 = 0;
        if(val_15 != null)
        {
                var val_21 = 0;
            val_21 = val_21 + 1;
            val_15.Dispose();
        }
        
        if(val_13 != 0)
        {
                throw val_13;
        }
        
        return (System.Collections.Generic.KeyValuePair<System.Object, System.Int32>)(comparer < 1) ? (val_19) : (val_15);
        label_1:
        val_27 = "source";
        goto label_43;
        label_2:
        val_27 = "selector";
        goto label_43;
        label_3:
        System.ArgumentNullException val_13 = null;
        val_27 = "comparer";
        label_43:
        val_15 = val_13;
        val_13 = new System.ArgumentNullException(paramName:  val_27);
        throw val_15;
    }
    public static TSource MinBy<TSource, TKey>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> selector)
    {
        goto __RuntimeMethodHiddenParam + 48 + 16;
    }
    public static TSource MinBy<TSource, TKey>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> selector, System.Collections.Generic.IComparer<TKey> comparer)
    {
        var val_13;
        var val_15;
        var val_17;
        var val_19;
        var val_20;
        var val_21;
        string val_27;
        val_13 = __RuntimeMethodHiddenParam;
        if(source == null)
        {
            goto label_1;
        }
        
        if(selector == 0)
        {
            goto label_2;
        }
        
        if(comparer == null)
        {
            goto label_3;
        }
        
        var val_15 = 0;
        val_15 = val_15 + 1;
        val_15 = source;
        var val_16 = 0;
        val_16 = val_16 + 1;
        val_17 = public System.Boolean System.Collections.IEnumerator::MoveNext();
        if(val_15.MoveNext() == false)
        {
                throw new System.InvalidOperationException(message:  "Sequence contains no elements");
        }
        
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_17 = __RuntimeMethodHiddenParam + 48 + 8;
        val_19 = val_15;
        val_20 = (VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(source, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0) + 8;
        val_21 = selector;
        goto label_20;
        label_35:
        var val_18 = 0;
        val_18 = val_18 + 1;
        var val_19 = 0;
        val_19 = val_19 + 1;
        var val_7 = (comparer >= 0) ? (val_21) : selector;
        var val_9 = (comparer >= 0) ? (val_20) : ((VirtualInvokeData*)GetInterfaceInvokeDataFromVTable(source, typeof(__RuntimeMethodHiddenParam + 48 + 8), slot: 0) + 8);
        label_20:
        var val_20 = 0;
        val_20 = val_20 + 1;
        if(val_15.MoveNext() == true)
        {
            goto label_35;
        }
        
        val_13 = 0;
        if(val_15 != null)
        {
                var val_21 = 0;
            val_21 = val_21 + 1;
            val_15.Dispose();
        }
        
        if(val_13 != 0)
        {
                throw val_13;
        }
        
        return (System.Collections.Generic.KeyValuePair<System.Object, System.Int32>)(comparer >= 0) ? (val_19) : (val_15);
        label_1:
        val_27 = "source";
        goto label_43;
        label_2:
        val_27 = "selector";
        goto label_43;
        label_3:
        System.ArgumentNullException val_13 = null;
        val_27 = "comparer";
        label_43:
        val_15 = val_13;
        val_13 = new System.ArgumentNullException(paramName:  val_27);
        throw val_15;
    }

}
