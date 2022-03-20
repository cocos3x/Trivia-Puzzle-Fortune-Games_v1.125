using UnityEngine;
public class TRVCategoryUnlockPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button unlockButton;
    private UnityEngine.UI.Text newCategoryText;
    private UnityEngine.UI.Text continueText;
    private UnityEngine.ParticleSystem revealFlourish;
    
    // Methods
    private void OnEnable()
    {
        this.unlockButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVCategoryUnlockPopup::UnlockCategory()));
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void UnlockCategory()
    {
        var val_6;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_8;
        val_6 = null;
        val_6 = null;
        val_8 = TRVCategoryUnlockPopup.<>c.<>9__5_0;
        if(val_8 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_3 = null;
            val_8 = val_3;
            val_3 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean>(object:  TRVCategoryUnlockPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVCategoryUnlockPopup.<>c::<UnlockCategory>b__5_0(System.Collections.Generic.KeyValuePair<string, int> x));
            TRVCategoryUnlockPopup.<>c.<>9__5_0 = val_8;
        }
        
        System.Collections.Generic.KeyValuePair<System.String, System.Int32> val_4 = System.Linq.Enumerable.FirstOrDefault<System.Collections.Generic.KeyValuePair<System.String, System.Int32>>(source:  MonoSingleton<TRVDataParser>.Instance.CategoryUnlockLevels, predicate:  val_3);
        this.revealFlourish.Play();
        this.unlockButton.m_OnClick.RemoveAllListeners();
        this.unlockButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVCategoryUnlockPopup::Close()));
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void Close()
    {
        this.gameObject.SetActive(value:  false);
        bool val_3 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        MonoSingleton<TRVMainController>.Instance.Init(currentlySelectedCategores:  0, fromReroll:  false);
    }
    public TRVCategoryUnlockPopup()
    {
    
    }

}
