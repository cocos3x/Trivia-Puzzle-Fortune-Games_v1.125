using UnityEngine;

namespace WordForest
{
    public class WFORevengePopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private WordForest.WFORevengeListItem prefabListItem;
        private UnityEngine.UI.ScrollRect scrollRect;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFORevengePopup::CloseWindow()));
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public void Initialize(WordForest.UserForestProfile randomUser, System.Collections.Generic.List<WordForest.UserForestProfile> revengeUserList)
        {
            WordForest.UserForestProfile val_5;
            System.Action<WordForest.UserForestProfile> val_6;
            val_5 = randomUser;
            System.Action<WordForest.UserForestProfile> val_2 = null;
            val_6 = val_2;
            val_2 = new System.Action<WordForest.UserForestProfile>(object:  this, method:  System.Void WordForest.WFORevengePopup::OnItemRandomClicked(WordForest.UserForestProfile targetForest));
            UnityEngine.Object.Instantiate<WordForest.WFORevengeListItem>(original:  this.prefabListItem, parent:  this.scrollRect.m_Content).Initialize(data:  val_5, onBtnClicked:  val_2, isRandomTarget:  true, buttonText:  "RANDOM");
            if(revengeUserList == null)
            {
                    return;
            }
            
            if("RANDOM" < 1)
            {
                    return;
            }
            
            var val_6 = 4;
            do
            {
                val_6 = 0;
                if(val_6 >= "RANDOM")
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_5 = UnityEngine.Object.Instantiate<WordForest.WFORevengeListItem>(original:  this.prefabListItem, parent:  this.scrollRect.m_Content);
                if(val_6 >= 1152921518181082480)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                System.Action<WordForest.UserForestProfile> val_4 = null;
                val_6 = val_4;
                val_4 = new System.Action<WordForest.UserForestProfile>(object:  this, method:  System.Void WordForest.WFORevengePopup::OnItemRevengeClicked(WordForest.UserForestProfile targetForest));
                val_5.Initialize(data:  "setOfflineMode", onBtnClicked:  val_4, isRandomTarget:  false, buttonText:  "REVENGE");
                val_6 = val_6 + 1;
            }
            while((val_6 - 3) < 1152921518181082480);
        
        }
        private void OnItemRandomClicked(WordForest.UserForestProfile targetForest)
        {
            .targetForest = targetForest;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            MonoSingleton<WordForest.RaidAttackScreenTransition>.Instance.ExtendCurtains(sceneType:  0, onComplete:  new System.Action(object:  new WFORevengePopup.<>c__DisplayClass6_0(), method:  System.Void WFORevengePopup.<>c__DisplayClass6_0::<OnItemRandomClicked>b__0()));
        }
        private void OnItemRevengeClicked(WordForest.UserForestProfile targetForest)
        {
            .targetForest = targetForest;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            MonoSingleton<WordForest.RaidAttackScreenTransition>.Instance.ExtendCurtains(sceneType:  0, onComplete:  new System.Action(object:  new WFORevengePopup.<>c__DisplayClass7_0(), method:  System.Void WFORevengePopup.<>c__DisplayClass7_0::<OnItemRevengeClicked>b__0()));
        }
        public WFORevengePopup()
        {
        
        }
    
    }

}
