using UnityEngine;

namespace WordForest
{
    public class WFOForestListPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.Transform mainContentGroup;
        private UnityEngine.CanvasGroup backgroundGroup;
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.Transform forestItemParent;
        private WordForest.WFOForestListItem forestItemPrefab;
        private UnityEngine.UI.ScrollRect scrollView;
        private UnityEngine.Texture[] forestIcons;
        private System.Collections.Generic.List<WordForest.WFOForestListItem> forestList;
        private bool unlockingNewForest;
        private int currentForestID;
        private System.Action TweenInCompleteCallback;
        private System.Action TweenOutBeginCallback;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestListPopup::OnCloseButtonClicked()));
            WordForest.WFOForestManager val_2 = MonoSingleton<WordForest.WFOForestManager>.Instance;
            WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            int val_5 = val_3.currentForestID;
            val_5 = val_5 - 1;
            this.currentForestID = val_5;
            this.GenerateForestList();
            DG.Tweening.Sequence val_4 = this.ScrollToForest(index:  this.currentForestID, instant:  true);
            this.TweenIn();
        }
        private void OnDisable()
        {
            DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void WordForest.WFOForestListPopup::OnAndroidBackButtonPressed()));
        }
        public void SetUnlockNewForest()
        {
            this.unlockingNewForest = true;
        }
        public void SetOnTweenInCompleteCallback(System.Action callback)
        {
            System.Delegate val_1 = System.Delegate.Combine(a:  this.TweenInCompleteCallback, b:  callback);
            if(val_1 != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            this.TweenInCompleteCallback = val_1;
            return;
            label_2:
        }
        public void SetOnTweenOutBeginCallback(System.Action callback)
        {
            System.Delegate val_1 = System.Delegate.Combine(a:  this.TweenOutBeginCallback, b:  callback);
            if(val_1 != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            this.TweenOutBeginCallback = val_1;
            return;
            label_2:
        }
        private void GenerateForestList()
        {
            this.forestList = new System.Collections.Generic.List<WordForest.WFOForestListItem>();
            WordForest.WFOGameEcon val_2 = App.GetGameSpecificEcon<WordForest.WFOGameEcon>();
            if(<0)
            {
                    return;
            }
            
            long val_7 = 44174743;
            do
            {
                WordForest.WFOForestListItem val_3 = UnityEngine.Object.Instantiate<WordForest.WFOForestListItem>(original:  this.forestItemPrefab, parent:  this.forestItemParent);
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_3.SetForestInfo(forestIndex:  44174743, forestData:  new WordForest.WFOForestData() {level = 1179403647, forestName = 1179403647, initialCost = (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 44174775) + 16, costIncrease = (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 44174775) + 16, stages = (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 44174775) + 16, bgType = 1179403647}, onItemClicked:  new System.Action(object:  this, method:  System.Void WordForest.WFOForestListPopup::OnCloseButtonClicked()), forestTexture:  this.forestIcons[val_7]);
                int val_6 = this.currentForestID;
                if(val_7 < val_6)
            {
                    val_3.SetCompleted();
            }
            else
            {
                    val_6 = val_6 & 4294967295;
                if(val_7 == val_6)
            {
                    val_3.SetCurrent();
            }
            else
            {
                    val_3.SetLocked();
            }
            
            }
            
                this.forestList.Insert(index:  0, item:  val_3);
                val_7 = val_7 - 1;
            }
            while((val_7 & 2147483648) == 0);
        
        }
        private DG.Tweening.Sequence ScrollToForest(int index, bool instant = True)
        {
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            System.Collections.Generic.List<WordForest.WFOForestListItem> val_4 = this.forestList;
            float val_5 = (float)index;
            val_4 = val_4 - 1;
            val_5 = val_5 / (float)val_4;
            if(instant != false)
            {
                    this.scrollView.verticalNormalizedPosition = val_5;
                return val_1;
            }
            
            DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOVerticalNormalizedPos(target:  this.scrollView, endValue:  val_5, duration:  0.3f, snapping:  false));
            return val_1;
        }
        private void TweenIn()
        {
            UnityEngine.Rect val_1 = this.mainContentGroup.rect;
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_1.m_XMin.width, y:  0f, z:  0f);
            this.mainContentGroup.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
            this.backgroundGroup.alpha = 0f;
            DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveX(target:  this.mainContentGroup, endValue:  0f, duration:  0.5f, snapping:  false), delay:  0.1f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestListPopup::OnTweenInComplete()));
            DG.Tweening.Tweener val_8 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundGroup, endValue:  1f, duration:  0.5f);
        }
        private void OnTweenInComplete()
        {
            if(this.TweenInCompleteCallback != null)
            {
                    this.TweenInCompleteCallback.Invoke();
            }
            
            if(this.unlockingNewForest != false)
            {
                    this.DoUnlockNewForestSequence();
                this.unlockingNewForest = false;
            }
            
            DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void WordForest.WFOForestListPopup::OnAndroidBackButtonPressed()));
        }
        private void DoUnlockNewForestSequence()
        {
            DG.Tweening.TweenCallback val_15;
            var val_16;
            DG.Tweening.TweenCallback val_18;
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            int val_15 = this.currentForestID;
            int val_2 = val_15 + 1;
            this.currentForestID = val_2;
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  this.ScrollToForest(index:  val_2, instant:  false));
            if(val_15 <= this.currentForestID)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_15 = val_15 + ((this.currentForestID) << 3);
            DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  (this.currentForestID + (this.currentForestID) << 3) + 32.DoUnlockSequence());
            int val_16 = this.currentForestID;
            int val_7 = val_16 - 1;
            if(W9 <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_16 = val_16 + (val_7 << 3);
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  (this.currentForestID + ((this.currentForestID - 1)) << 3) + 32, method:  public System.Void WordForest.WFOForestListItem::SetCompleted()));
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  1f);
            DG.Tweening.TweenCallback val_11 = null;
            val_15 = val_11;
            val_11 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestListPopup::OnCloseButtonClicked());
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  val_11);
            val_16 = null;
            val_16 = null;
            val_18 = WFOForestListPopup.<>c.<>9__21_0;
            if(val_18 == null)
            {
                    DG.Tweening.TweenCallback val_13 = null;
                val_18 = val_13;
                val_13 = new DG.Tweening.TweenCallback(object:  WFOForestListPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOForestListPopup.<>c::<DoUnlockNewForestSequence>b__21_0());
                WFOForestListPopup.<>c.<>9__21_0 = val_18;
            }
            
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  val_13);
        }
        private void OnAndroidBackButtonPressed()
        {
            this.OnCloseButtonClicked();
        }
        private void OnCloseButtonClicked()
        {
            if(this.TweenOutBeginCallback != null)
            {
                    this.TweenOutBeginCallback.Invoke();
            }
            
            UnityEngine.Rect val_1 = this.mainContentGroup.rect;
            DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveX(target:  this.mainContentGroup, endValue:  val_1.m_XMin.width, duration:  0.5f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestListPopup::<OnCloseButtonClicked>b__23_0()));
            DG.Tweening.Tweener val_6 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundGroup, endValue:  0f, duration:  0.5f);
        }
        public WFOForestListPopup()
        {
        
        }
        private void <OnCloseButtonClicked>b__23_0()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
    
    }

}
