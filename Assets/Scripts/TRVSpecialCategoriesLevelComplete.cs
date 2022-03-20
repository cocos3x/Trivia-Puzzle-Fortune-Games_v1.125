using UnityEngine;
public class TRVSpecialCategoriesLevelComplete : MonoBehaviour
{
    // Fields
    private TRVLevelComplete myPopup;
    private UnityEngine.UI.Text descText;
    private UnityEngine.UI.Image fillBar;
    private System.Collections.Generic.List<TRVDynamicSliderTick> sliderTicks;
    private UnityEngine.GameObject specialBarParent;
    private UnityEngine.UI.Button nextLevelButton;
    private UnityEngine.UI.Button continueButton;
    
    // Methods
    public void Init(TRVQuizProgress currentQuiz, TRVLevelComplete lcPopup)
    {
        object val_41;
        var val_42;
        var val_47;
        var val_48;
        var val_49;
        System.Func<System.Int32, System.Boolean> val_51;
        var val_52;
        UnityEngine.UI.Image val_53;
        var val_54;
        val_41 = this;
        this.continueButton.gameObject.SetActive(value:  false);
        this.specialBarParent.gameObject.SetActive(value:  false);
        return;
        label_40:
        if( >= 1152921517382644384)
        {
            goto label_35;
        }
        
        if(1152921517382644384 <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(1152921515450617360 <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_47 = System.Void ShortcutExtensionsTextMeshPro.<>c__DisplayClass5_0::<DOFaceFade>b__1(UnityEngine.Color x);
        if(1152921515450617360 <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_47 = "WGStoreItem_spins";
        }
        
        Init(myValue:  179398208, maxValue:  null, myDisplayAmount:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 40.Item[-1082943552], lastTickOffset:  0, isComplete:  false);
         =  + 1;
        if( < 44328216)
        {
            goto label_40;
        }
        
        label_35:
        val_48 = null;
        val_49 = 1152921504964726784;
        val_51 = TRVSpecialCategoriesLevelComplete.<>c.<>9__7_1;
        if(val_51 == null)
        {
                System.Func<System.Int32, System.Boolean> val_18 = null;
            val_51 = val_18;
            val_18 = new System.Func<System.Int32, System.Boolean>(object:  TRVSpecialCategoriesLevelComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVSpecialCategoriesLevelComplete.<>c::<Init>b__7_1(int x));
            TRVSpecialCategoriesLevelComplete.<>c.<>9__7_1 = val_51;
        }
        
        int val_19 = System.Linq.Enumerable.FirstOrDefault<System.Int32>(source:  System.Linq.Enumerable.ToList<System.Int32>(source:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 40.Keys), predicate:  val_18);
        val_52 = val_19;
        if(val_19 == 0)
        {
                if((public static System.Int32 System.Linq.Enumerable::FirstOrDefault<System.Int32>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_52 = mem[222179988];
        }
        
        val_53 = this.fillBar;
        string val_42 = TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID;
        if(0 == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_42 = val_42 + ((0 - 1) << 2);
        float val_43 = (float)(TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + ((0 - 1)) << 2) + 32;
        val_43 = ((float)TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72) / val_43;
        val_53.fillAmount = val_43;
        val_54 = mem[TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72];
        val_54 = TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 72;
        if(val_54 == )
        {
                this.nextLevelButton.gameObject.SetActive(value:  false);
            this.continueButton.gameObject.SetActive(value:  true);
            this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVSpecialCategoriesLevelComplete::OnContinueClicked()));
            string val_24 = System.String.Format(format:  "Category {0} Event Complete!", arg0:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID + 64);
            val_41 = ???;
            val_52 = ???;
            val_54 = ???;
            val_53 = ???;
            val_42 = ???;
            val_49 = ???;
        }
        else
        {
                this.descText.SetActive(value:  true);
            val_41 + 72.gameObject.SetActive(value:  false);
            if((val_42 + 3954) == 0)
        {
                mem2[0] = 1;
        }
        
            object val_26 = val_52 - (val_49 + 184 + 72);
            string val_28 = System.String.Format(format:  "Complete {0} level{1} for the next reward!", arg0:  val_26, arg1:  (val_26 > 1) ? "s" : "");
        }
    
    }
    private void OnStartNextLevel()
    {
        null = null;
        TRVMainController.noAnswerSelectedCharacter = 2;
        MonoSingleton<TRVMainController>.Instance.InitSpecialCategories();
    }
    private void OnContinueClicked()
    {
        if(this.myPopup != null)
        {
                this.myPopup.Close(showAd:  false, load:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    public TRVSpecialCategoriesLevelComplete()
    {
    
    }

}
