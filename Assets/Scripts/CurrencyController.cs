using UnityEngine;
public class CurrencyController
{
    // Fields
    public const string CURRENCY = "ruby";
    public const int DEFAULT_CURRENCY = 10;
    private static System.Collections.Generic.Dictionary<CurrencyType, System.Action> onBalanceChanged;
    public static System.Action<System.Decimal> onBalanceIncreased;
    
    // Methods
    public static void AddCurrencyListener(System.Action onChangeAction, CurrencyType type)
    {
        System.Collections.Generic.Dictionary<CurrencyType, System.Action> val_5 = CurrencyController.onBalanceChanged;
        if(val_5 == null)
        {
                System.Collections.Generic.Dictionary<CurrencyType, System.Action> val_1 = new System.Collections.Generic.Dictionary<CurrencyType, System.Action>();
            CurrencyController.onBalanceChanged = val_1;
            val_5 = CurrencyController.onBalanceChanged;
        }
        
        if((val_1.ContainsKey(key:  type)) != false)
        {
                System.Delegate val_4 = System.Delegate.Combine(a:  val_1.Item[type], b:  onChangeAction);
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
            val_1.set_Item(key:  type, value:  val_4);
            return;
        }
        
        val_1.Add(key:  type, value:  onChangeAction);
        return;
        label_6:
    }
    public static void RemoveCurrencyListener(System.Action onChangeAction, CurrencyType type)
    {
        System.Collections.Generic.Dictionary<TKey, TValue> val_5;
        System.Collections.Generic.Dictionary<CurrencyType, System.Action> val_6 = CurrencyController.onBalanceChanged;
        if(val_6 == null)
        {
                System.Collections.Generic.Dictionary<CurrencyType, System.Action> val_1 = null;
            val_5 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<CurrencyType, System.Action>();
            CurrencyController.onBalanceChanged = val_5;
            val_6 = CurrencyController.onBalanceChanged;
        }
        
        if((val_1.ContainsKey(key:  type)) == false)
        {
                return;
        }
        
        System.Delegate val_4 = System.Delegate.Remove(source:  val_1.Item[type], value:  onChangeAction);
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        val_1.set_Item(key:  type, value:  val_4);
        return;
        label_6:
    }
    public static decimal GetBalance()
    {
        Player val_1 = App.Player;
        return new System.Decimal() {flags = val_1._credits, hi = val_1._credits};
    }
    public static void Debug_SetBalance(decimal value)
    {
        App.Player.SetCredits(amount:  new System.Decimal() {flags = value.flags, hi = value.hi, lo = value.lo, mid = value.mid});
    }
    public static void CreditBalance(decimal value, string source = "UnknownSource", System.Collections.Generic.Dictionary<string, object> externalParams, bool animated = False)
    {
        string val_8 = source;
        App.Player.AddCredits(amount:  new System.Decimal() {flags = value.flags, hi = value.hi, lo = value.lo, mid = value.mid}, source:  val_8 = source, subSource:  0, externalParams:  externalParams, doTrack:  true);
        if((CurrencyController.onBalanceChanged.ContainsKey(key:  0)) != false)
        {
                val_8 = 1152921513435291568;
            if(CurrencyController.onBalanceChanged.Item[0] != null)
        {
                CurrencyController.onBalanceChanged.Item[0].Invoke();
        }
        
        }
        
        if(CurrencyController.onBalanceIncreased != null)
        {
                CurrencyController.onBalanceIncreased.Invoke(obj:  new System.Decimal() {flags = value.flags, hi = value.hi, lo = value.lo, mid = value.mid});
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "CoinsStatViewUpdate", aData:  CurrencyStatView.GetAnimHT(shouldAnimate:  animated));
    }
    public static bool DebitBalance(decimal value, string source = "UnknownSource", System.Collections.Generic.Dictionary<string, object> externalParams, bool animated = False)
    {
        string val_11;
        var val_12;
        val_11 = source;
        decimal val_1 = CurrencyController.GetBalance();
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = value.flags, hi = value.hi, lo = value.lo, mid = value.mid})) != false)
        {
                val_12 = 0;
            return (bool)val_12;
        }
        
        decimal val_4 = System.Decimal.op_UnaryNegation(d:  new System.Decimal() {flags = value.flags, hi = value.hi, lo = value.lo, mid = value.mid});
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, source:  val_11, subSource:  0, externalParams:  externalParams, doTrack:  true);
        if((CurrencyController.onBalanceChanged != null) && ((CurrencyController.onBalanceChanged.ContainsKey(key:  0)) != false))
        {
                val_11 = 1152921513435291568;
            if(CurrencyController.onBalanceChanged.Item[0] != null)
        {
                CurrencyController.onBalanceChanged.Item[0].Invoke();
        }
        
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "CoinsStatViewUpdate", aData:  CurrencyStatView.GetAnimHT(shouldAnimate:  animated));
        val_12 = 1;
        return (bool)val_12;
    }
    public static void HandleBalanceChanged(CurrencyType type)
    {
        if((CurrencyController.onBalanceChanged != null) && ((CurrencyController.onBalanceChanged.ContainsKey(key:  type)) != false))
        {
                if(CurrencyController.onBalanceChanged.Item[type] != null)
        {
                CurrencyController.onBalanceChanged.Item[type].Invoke();
        }
        
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "CoinsStatViewUpdate", aData:  CurrencyStatView.GetAnimHT(shouldAnimate:  false));
    }
    public CurrencyController()
    {
    
    }

}
