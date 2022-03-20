using UnityEngine;

namespace SLC.Minigames
{
    public class MinigameButton : MonoBehaviour
    {
        // Fields
        private TMPro.TMP_Text minigameName;
        private UGUINetworkedButton minigameButton;
        private UnityEngine.UI.Image minigameIcon;
        private UnityEngine.UI.Image DLCButtonImage;
        private UnityEngine.UI.Image spinningAnimation;
        private UnityEngine.UI.Slider rankSlider;
        private UnityEngine.UI.Image rankSliderFill;
        private TMPro.TMP_Text rankText;
        private SLC.Minigames.MinigamesPopup myParentPopup;
        private int index;
        private string myGameName;
        private bool isLoaded;
        private bool isLoading;
        
        // Properties
        private bool IsLoading { get; set; }
        
        // Methods
        private bool get_IsLoading()
        {
            var val_5;
            bool val_2 = (UnityEngine.Object.op_Inequality(x:  this.myParentPopup, y:  0)) ^ 1;
            val_5 = ((this.isLoading == true) ? 1 : 0) & val_2;
            if(val_2 == true)
            {
                    return (bool)(this.myParentPopup.someMinigameLoading == true) ? 1 : 0;
            }
            
            if(this.isLoading == false)
            {
                    return (bool)(this.myParentPopup.someMinigameLoading == true) ? 1 : 0;
            }
            
            return (bool)(this.myParentPopup.someMinigameLoading == true) ? 1 : 0;
        }
        private void set_IsLoading(bool value)
        {
            this.isLoading = value;
            if((UnityEngine.Object.op_Implicit(exists:  this.myParentPopup)) == false)
            {
                    return;
            }
            
            this.myParentPopup.ToggleLoading(isLoading:  this.isLoading);
        }
        public void ToggleInteractable(bool interactable)
        {
            if(this.minigameButton != null)
            {
                    this.minigameButton.interactable = interactable;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void Setup(string gameName, int minigameIndex, int reqLevel, UnityEngine.Sprite gameIcon, string displayGameName, SLC.Minigames.MinigamesPopup parentPopup)
        {
            var val_9;
            var val_10;
            this.myParentPopup = parentPopup;
            this.minigameIcon.sprite = gameIcon;
            System.Action<System.Boolean> val_1 = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.MinigameButton::OnNetworkedButtonResult(bool result));
            this.minigameButton.OnConnectionClick = val_1;
            val_1.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigameButton::OnMyButtonClick()));
            this.index = minigameIndex;
            this.myGameName = gameName;
            val_9 = null;
            val_9 = null;
            AppConfigs val_3 = App.Configuration;
            MiniGame val_4 = val_3.minigamesConfig.GetMiniGameById(id:  this.myGameName);
            AppConfigs val_5 = App.Configuration;
            if((App.dlcManager.IsAssetAvailable(bundleName:  val_4.dlcPack, version:  val_5.dlcConfig.version)) != false)
            {
                    this.isLoaded = true;
                val_10 = 0;
            }
            else
            {
                    this.isLoaded = false;
                val_10 = 1;
            }
            
            this.DLCButtonImage.enabled = true;
            this.spinningAnimation.gameObject.SetActive(value:  false);
            this.UpdateSliderToRank(mgPlayerData:  SLC.Minigames.MinigameManager.LoadMiniGameData(minigameId:  gameName));
        }
        private void OnMyButtonClick()
        {
            if(this.IsLoading == true)
            {
                    return;
            }
            
            if(this.isLoaded == false)
            {
                    return;
            }
            
            MonoSingleton<Bootstrapper>.Instance.HandlePlayMinigame(minigame:  this.index);
            this.IsLoading = true;
            this.minigameButton.OnConnectionClick = 0;
        }
        private void OnNetworkedButtonResult(bool result)
        {
            string val_19;
            object val_20;
            int val_21;
            var val_22;
            System.Func<System.Boolean> val_24;
            var val_25;
            var val_26;
            val_20 = this;
            if(result != true)
            {
                    if(this.isLoaded == false)
            {
                goto label_2;
            }
            
            }
            
            if(this.IsLoading == true)
            {
                    return;
            }
            
            if(this.isLoaded == false)
            {
                goto label_4;
            }
            
            val_19 = 1152921515625720848;
            Bootstrapper val_2 = MonoSingleton<Bootstrapper>.Instance;
            if(val_2.IsLoadingScene == true)
            {
                    return;
            }
            
            MonoSingleton<Bootstrapper>.Instance.HandlePlayMinigame(minigame:  this.index);
            this.IsLoading = true;
            return;
            label_2:
            MonoSingleton<WGWindowManager>.Instance.CloseCurrentWindow();
            val_20 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false);
            val_19 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
            bool[] val_9 = new bool[2];
            val_9[0] = true;
            string[] val_10 = new string[2];
            val_21 = val_10.Length;
            val_10[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_21 = val_10.Length;
            val_10[1] = "NULL";
            System.Func<System.Boolean>[] val_12 = new System.Func<System.Boolean>[2];
            val_22 = null;
            val_22 = null;
            val_24 = MinigameButton.<>c.<>9__19_0;
            if(val_24 == null)
            {
                    System.Func<System.Boolean> val_13 = null;
                val_24 = val_13;
                val_13 = new System.Func<System.Boolean>(object:  MinigameButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean MinigameButton.<>c::<OnNetworkedButtonResult>b__19_0());
                MinigameButton.<>c.<>9__19_0 = val_24;
            }
            
            val_12[0] = val_24;
            val_25 = null;
            val_25 = null;
            val_20.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  val_19, shownButtons:  val_9, buttonTexts:  val_10, showClose:  false, buttonCallbacks:  val_12, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
            return;
            label_4:
            this.spinningAnimation.gameObject.SetActive(value:  true);
            this.DLCButtonImage.enabled = false;
            this.IsLoading = true;
            val_26 = null;
            val_26 = null;
            AppConfigs val_15 = App.Configuration;
            MiniGame val_16 = val_15.minigamesConfig.GetMiniGameById(id:  this.myGameName);
            AppConfigs val_17 = App.Configuration;
            App.dlcManager.DownloadResource(bundlePath:  "word_games", bundleName:  val_16.dlcPack, bundleVersion:  val_17.dlcConfig.version, onDownloadedCallback:  new System.Action<UnityEngine.AssetBundle>(object:  this, method:  System.Void SLC.Minigames.MinigameButton::PlayGame(UnityEngine.AssetBundle loaded)));
        }
        private void PlayGame(UnityEngine.AssetBundle loaded)
        {
            if(this == 0)
            {
                    return;
            }
            
            Bootstrapper val_2 = MonoSingleton<Bootstrapper>.Instance;
            if(val_2.IsLoadingScene != false)
            {
                    return;
            }
            
            this.spinningAnimation.gameObject.SetActive(value:  false);
            MonoSingleton<Bootstrapper>.Instance.HandlePlayMinigame(minigame:  this.index);
        }
        private void UpdateSliderToRank(SLC.Minigames.MinigamePlayerData mgPlayerData)
        {
            string val_1 = SLC.Minigames.MinigameLevelRank.RankIndexToName(index:  mgPlayerData.rankIndex);
            string val_5 = System.String.Format(format:  "{0} {1}", arg0:  val_1.ToUpper(), arg1:  SLC.Minigames.MinigamesUtils.RomanNumeralize(num:  mgPlayerData.GetCheckpointsCompletedInRank()));
            float val_6 = mgPlayerData.LevelsForNextRank();
            UnityEngine.Color32 val_7 = SLC.Minigames.MinigameLevelRank.RankColors.Item[val_1];
            val_7.r = val_7.r & 4294967295;
            UnityEngine.Color val_8 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_7.r, g = val_7.r, b = val_7.r, a = val_7.r});
            this.rankSliderFill.color = new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a};
        }
        public MinigameButton()
        {
            this.index = 0;
            this.myGameName = "";
        }
    
    }

}
