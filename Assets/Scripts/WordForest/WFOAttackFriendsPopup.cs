using UnityEngine;

namespace WordForest
{
    public class WFOAttackFriendsPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private WordForest.WFOAttackFriendsListItem prefabListItem;
        private UnityEngine.UI.ScrollRect scrollRect;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOAttackFriendsPopup::CloseWindow()));
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public void Initialize(System.Collections.Generic.List<WordForest.UserForestProfile> friendsList)
        {
            var val_3;
            System.Action<WordForest.UserForestProfile> val_4;
            if(friendsList == null)
            {
                    return;
            }
            
            if(true < 1)
            {
                    return;
            }
            
            var val_4 = 4;
            val_4 = 0;
            if(val_4 >= true)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(0 != 0)
            {
                    val_3 = UnityEngine.Object.Instantiate<WordForest.WFOAttackFriendsListItem>(original:  this.prefabListItem, parent:  this.scrollRect.m_Content);
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                System.Action<WordForest.UserForestProfile> val_2 = null;
                val_4 = val_2;
                val_2 = new System.Action<WordForest.UserForestProfile>(object:  this, method:  System.Void WordForest.WFOAttackFriendsPopup::OnItemClicked(WordForest.UserForestProfile targetForest));
                val_3.Initialize(data:  UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32, onBtnClicked:  val_2);
            }
            
            var val_3 = val_4 - 3;
            val_4 = val_4 + 1;
        }
        private void OnItemClicked(WordForest.UserForestProfile targetForest)
        {
            .targetForest = targetForest;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            MonoSingleton<WordForest.RaidAttackScreenTransition>.Instance.ExtendCurtains(sceneType:  0, onComplete:  new System.Action(object:  new WFOAttackFriendsPopup.<>c__DisplayClass6_0(), method:  System.Void WFOAttackFriendsPopup.<>c__DisplayClass6_0::<OnItemClicked>b__0()));
        }
        public WFOAttackFriendsPopup()
        {
        
        }
    
    }

}
