using UnityEngine;

namespace WordForest
{
    public class WFOForestRewardChestPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text labelQtyCoins;
        private UnityEngine.UI.Text labelQtyAcorns;
        private UnityEngine.UI.Button buttonCollect;
        private GridCoinCollectAnimationInstantiator coinsAnimControl;
        private GoldenCurrencyCollectAnimationInstantiator acornsAnimControl;
        private WordForest.WFOForestChestData chest;
        private System.Action OnCollectCallback;
        
        // Methods
        private void Start()
        {
            this.buttonCollect.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestRewardChestPopup::OnCollectClicked()));
            this.Initialize();
        }
        public void AddOnCollectCallback(System.Action callback)
        {
            System.Delegate val_1 = System.Delegate.Combine(a:  this.OnCollectCallback, b:  callback);
            if(val_1 != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            this.OnCollectCallback = val_1;
            return;
            label_2:
        }
        private void Initialize()
        {
            WordForest.WFOForestChestData val_3;
            var val_4;
            WordForest.WFOForestChestData val_2 = MonoSingleton<WordForest.WFOForestManager>.Instance.GetCurrentChestData();
            this.chest = val_3;
            mem[1152921518130689392] = val_4;
            string val_5 = this.chest.ToString();
            string val_6 = mem[1152921518130689392].ToString();
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        private void OnCollectClicked()
        {
            this.buttonCollect.interactable = false;
            Player val_1 = App.Player;
            Player val_2 = App.Player;
            bool val_4 = MonoSingleton<WordForest.WFOForestManager>.Instance.CollectForestChest();
            Player val_5 = App.Player;
            this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X22, mid = X22}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            Player val_6 = App.Player;
            decimal val_7 = System.Decimal.op_Implicit(value:  val_6._stars);
            this.acornsAnimControl.Play(fromValue:  val_2._stars, toValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
            DG.Tweening.Tween val_9 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestRewardChestPopup::<OnCollectClicked>b__10_0()), ignoreTimeScale:  true);
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public WFOForestRewardChestPopup()
        {
        
        }
        private void <OnCollectClicked>b__10_0()
        {
            if(this.OnCollectCallback != null)
            {
                    this.OnCollectCallback.Invoke();
            }
            
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
    
    }

}
