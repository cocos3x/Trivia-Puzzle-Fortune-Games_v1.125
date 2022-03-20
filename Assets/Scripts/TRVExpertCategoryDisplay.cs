using UnityEngine;
public class TRVExpertCategoryDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text titleText;
    private System.Collections.Generic.Dictionary<TRVExpert, TRVExpertDisplay> <myDisplays>k__BackingField;
    private TRVCategoryExpertEcon myEcon;
    
    // Properties
    public System.Collections.Generic.Dictionary<TRVExpert, TRVExpertDisplay> myDisplays { get; set; }
    
    // Methods
    public System.Collections.Generic.Dictionary<TRVExpert, TRVExpertDisplay> get_myDisplays()
    {
        return (System.Collections.Generic.Dictionary<TRVExpert, TRVExpertDisplay>)this.<myDisplays>k__BackingField;
    }
    private void set_myDisplays(System.Collections.Generic.Dictionary<TRVExpert, TRVExpertDisplay> value)
    {
        this.<myDisplays>k__BackingField = value;
    }
    public void Init(TRVExpertDisplay displayPrefab, TRVCategoryExpertEcon incEcon, TRVExpertsCollectionPopup myPopup)
    {
        TRVExpert val_11;
        var val_12;
        var val_28;
        TRVExpertCategoryDisplay.<>c__DisplayClass6_0 val_29;
        var val_30;
        System.Func<TRVExpert, System.String> val_32;
        var val_33;
        System.Func<TRVExpert, System.Int32> val_35;
        System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData> val_36;
        UnityEngine.Transform val_37;
        TRVExpertProgressData val_38;
        val_28 = this;
        TRVExpertCategoryDisplay.<>c__DisplayClass6_0 val_1 = null;
        val_29 = val_1;
        val_1 = new TRVExpertCategoryDisplay.<>c__DisplayClass6_0();
        .myPopup = myPopup;
        this.myEcon = incEcon;
        this.<myDisplays>k__BackingField = new System.Collections.Generic.Dictionary<TRVExpert, TRVExpertDisplay>();
        string val_3 = this.myEcon.GetLocalizedName;
        TRVExpertsController val_4 = MonoSingleton<TRVExpertsController>.Instance;
        .pd = val_4.myExperts;
        val_30 = null;
        val_30 = null;
        val_32 = TRVExpertCategoryDisplay.<>c.<>9__6_0;
        if(val_32 == null)
        {
                System.Func<TRVExpert, System.String> val_5 = null;
            val_32 = val_5;
            val_5 = new System.Func<TRVExpert, System.String>(object:  TRVExpertCategoryDisplay.<>c.__il2cppRuntimeField_static_fields, method:  System.String TRVExpertCategoryDisplay.<>c::<Init>b__6_0(TRVExpert x));
            TRVExpertCategoryDisplay.<>c.<>9__6_0 = val_32;
        }
        
        val_33 = null;
        val_33 = null;
        val_35 = TRVExpertCategoryDisplay.<>c.<>9__6_1;
        if(val_35 == null)
        {
                System.Func<TRVExpert, System.Int32> val_7 = null;
            val_35 = val_7;
            val_7 = new System.Func<TRVExpert, System.Int32>(object:  TRVExpertCategoryDisplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVExpertCategoryDisplay.<>c::<Init>b__6_1(TRVExpert x));
            TRVExpertCategoryDisplay.<>c.<>9__6_1 = val_35;
        }
        
        List.Enumerator<T> val_10 = System.Linq.Enumerable.ToList<TRVExpert>(source:  System.Linq.Enumerable.OrderBy<TRVExpert, System.Int32>(source:  System.Linq.Enumerable.OrderBy<TRVExpert, System.String>(source:  this.myEcon.experts, keySelector:  val_5), keySelector:  val_7)).GetEnumerator();
        label_45:
        if(val_12.MoveNext() == false)
        {
            goto label_19;
        }
        
        TRVExpertCategoryDisplay.<>c__DisplayClass6_1 val_14 = null;
        val_37 = 0;
        val_14 = new TRVExpertCategoryDisplay.<>c__DisplayClass6_1();
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        .expertData = val_11;
        .CS$<>8__locals1 = val_29;
        TRVExpertCategoryDisplay.<>c__DisplayClass6_2 val_15 = null;
        val_37 = 0;
        val_15 = new TRVExpertCategoryDisplay.<>c__DisplayClass6_2();
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        .CS$<>8__locals2 = val_14;
        val_37 = this.transform;
        TRVExpertDisplay val_17 = UnityEngine.Object.Instantiate<TRVExpertDisplay>(original:  displayPrefab, parent:  val_37);
        .newExpert = val_17;
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.CS$<>8__locals1) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.expertData) == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.CS$<>8__locals1.pd;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.expertData.expertName;
        if((val_36.ContainsKey(key:  val_37)) == false)
        {
            goto label_28;
        }
        
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.CS$<>8__locals1) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.expertData) == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.CS$<>8__locals1.pd;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.expertData.expertName;
        val_38 = val_36.Item[val_37];
        if(val_17 != null)
        {
            goto label_33;
        }
        
        throw new NullReferenceException();
        label_28:
        val_38 = 0;
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        label_33:
        val_36 = val_17;
        val_37 = (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.expertData;
        val_36.Init(me:  val_37, progress:  val_38, upgraded:  false, showName:  false);
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2) == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = this.<myDisplays>k__BackingField;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.expertData;
        val_36.Add(key:  val_37, value:  (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].newExpert);
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.CS$<>8__locals1) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.expertData) == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.CS$<>8__locals1.pd;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_36.ContainsKey(key:  (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].CS$<>8__locals2.expertData.expertName)) == false)
        {
            goto label_45;
        }
        
        val_37 = public static UnityEngine.UI.Button MethodExtensionForMonoBehaviourTransform::GetOrAddComponent<UnityEngine.UI.Button>(UnityEngine.Component child);
        if((MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.Button>(child:  (TRVExpertCategoryDisplay.<>c__DisplayClass6_2)[1152921517143257296].newExpert)) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Events.UnityAction val_22 = null;
        val_37 = val_15;
        val_22 = new UnityEngine.Events.UnityAction(object:  val_15, method:  System.Void TRVExpertCategoryDisplay.<>c__DisplayClass6_2::<Init>b__2());
        if(val_21.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        val_21.m_OnClick.AddListener(call:  val_22);
        goto label_45;
        label_19:
        val_12.Dispose();
        if(this.myEcon.upgradeOnlyEcon == false)
        {
                return;
        }
        
        val_29 = 1152921517143114256;
        if((this.gameObject.GetComponent<UnityEngine.UI.GridLayoutGroup>()) == 0)
        {
                return;
        }
        
        UnityEngine.UI.GridLayoutGroup val_27 = this.gameObject.GetComponent<UnityEngine.UI.GridLayoutGroup>();
        val_28 = val_27;
        val_27.left = 15;
        val_28.childAlignment = 0;
        val_28.startCorner = 0;
    }
    public void RefreshDisplay()
    {
        TRVExpert val_4;
        var val_5;
        System.Collections.Generic.Dictionary<TRVExpert, TRVExpertDisplay> val_23;
        string val_24;
        TRVExpertProgressData val_25;
        var val_26;
        System.Func<System.Collections.Generic.KeyValuePair<TRVExpert, TRVExpertDisplay>, System.Boolean> val_28;
        if(this.myEcon == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.myEcon.upgradeOnlyEcon == false)
        {
                return;
        }
        
        if((MonoSingleton<TRVExpertsController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_23 = this.<myDisplays>k__BackingField;
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<TRVExpert, TRVExpertDisplay>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_2 = val_23.Keys;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = val_2.GetEnumerator();
        label_32:
        val_24 = public System.Boolean Dictionary.KeyCollection.Enumerator<TRVExpert, TRVExpertDisplay>::MoveNext();
        if(val_5.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_1.myExperts == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = mem[val_4 + 16];
        val_24 = val_4 + 16;
        if((val_1.myExperts.ContainsKey(key:  val_24)) == false)
        {
            goto label_32;
        }
        
        if((MonoSingleton<TRVExpertsController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = mem[val_4 + 16];
        val_24 = val_4 + 16;
        if(val_8.myEcon == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_4;
        if((val_8.myEcon.getReqFromExpert(exp:  val_24, prog:  val_1.myExperts.Item[val_24])) == null)
        {
            goto label_16;
        }
        
        val_24 = mem[val_4 + 16];
        val_24 = val_4 + 16;
        if(val_1.myExperts.Item[val_24] == null)
        {
                throw new NullReferenceException();
        }
        
        val_23 = this.<myDisplays>k__BackingField;
        if((val_11.<cardsOwned>k__BackingField) >= val_10.cardsNeeded)
        {
            goto label_18;
        }
        
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_4;
        TRVExpertDisplay val_12 = val_23.Item[val_24];
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = 0;
        UnityEngine.GameObject val_13 = val_12.gameObject;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13.SetActive(value:  false);
        goto label_32;
        label_16:
        val_23 = this.<myDisplays>k__BackingField;
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_4;
        TRVExpertDisplay val_14 = val_23.Item[val_24];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = 0;
        UnityEngine.GameObject val_15 = val_14.gameObject;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15.SetActive(value:  false);
        goto label_32;
        label_18:
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        TRVExpertDisplay val_16 = val_23.Item[val_4];
        if((val_1.myExperts.ContainsKey(key:  val_4 + 16)) == false)
        {
            goto label_28;
        }
        
        val_25 = val_1.myExperts.Item[val_4 + 16];
        if(val_16 != null)
        {
            goto label_29;
        }
        
        label_28:
        val_25 = 0;
        label_29:
        val_16.Init(me:  val_4, progress:  val_25, upgraded:  false, showName:  false);
        goto label_32;
        label_8:
        val_5.Dispose();
        val_26 = null;
        val_26 = null;
        val_28 = TRVExpertCategoryDisplay.<>c.<>9__7_0;
        if(val_28 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<TRVExpert, TRVExpertDisplay>, System.Boolean> val_19 = null;
            val_28 = val_19;
            val_19 = new System.Func<System.Collections.Generic.KeyValuePair<TRVExpert, TRVExpertDisplay>, System.Boolean>(object:  TRVExpertCategoryDisplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVExpertCategoryDisplay.<>c::<RefreshDisplay>b__7_0(System.Collections.Generic.KeyValuePair<TRVExpert, TRVExpertDisplay> x));
            TRVExpertCategoryDisplay.<>c.<>9__7_0 = val_28;
        }
        
        if((System.Linq.Enumerable.All<System.Collections.Generic.KeyValuePair<TRVExpert, TRVExpertDisplay>>(source:  this.<myDisplays>k__BackingField, predicate:  val_19)) == false)
        {
                return;
        }
        
        val_24 = 0;
        UnityEngine.GameObject val_21 = this.gameObject;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21.SetActive(value:  false);
    }
    public TRVExpertCategoryDisplay()
    {
    
    }

}
