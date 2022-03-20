using UnityEngine;
public class CategoryPacksGameplayUI : MonoSingleton<CategoryPacksGameplayUI>
{
    // Fields
    private bool isInitialized;
    
    // Properties
    private UnityEngine.UI.Image CategoryLetterCellImagePrefab { get; }
    
    // Methods
    private UnityEngine.UI.Image get_CategoryLetterCellImagePrefab()
    {
        UnityEngine.Object val_6;
        UnityEngine.UI.Image val_7;
        val_6 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_3 = MonoSingleton<ThemesHandler>.Instance;
        val_6 = val_3.theme;
        val_7 = 0;
        if(val_6 == 0)
        {
                return val_7;
        }
        
        ThemesHandler val_5 = MonoSingleton<ThemesHandler>.Instance;
        val_7 = val_5.theme.categoryLetterCell;
        return val_7;
    }
    private void OnSceneChanged(UnityEngine.SceneManagement.Scene outgoingScene, UnityEngine.SceneManagement.Scene incomingScene)
    {
        var val_13;
        var val_14;
        System.Action<GameLevel> val_15;
        GameBehavior val_1 = App.getBehavior;
        string val_2 = incomingScene.m_Handle.name;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                val_13 = null;
            if(CategoryPacksManager.IsPlaying != false)
        {
                val_14 = null;
            this.isInitialized = CategoryPacksManager.IsPlaying;
            WordRegion val_6 = WordRegion.instance;
            System.Action<GameLevel> val_7 = null;
            val_15 = val_7;
            val_7 = new System.Action<GameLevel>(object:  this, method:  System.Void CategoryPacksGameplayUI::OnLevelLoaded(GameLevel gameLevel));
            val_6.addOnLevelLoadedAction(callback:  val_7);
            val_6.UpdateLevelName();
            return;
        }
        
        }
        
        if(this.isInitialized == false)
        {
                return;
        }
        
        val_15 = 1152921504879157248;
        if(WordRegion.instance != 0)
        {
                WordRegion val_10 = WordRegion.instance;
            val_15 = val_10.OnLevelLoaded;
            System.Delegate val_12 = System.Delegate.Remove(source:  val_15, value:  new System.Action<GameLevel>(object:  this, method:  System.Void CategoryPacksGameplayUI::OnLevelLoaded(GameLevel gameLevel)));
            if(val_12 != null)
        {
                if(null != null)
        {
            goto label_25;
        }
        
        }
        
            val_10.OnLevelLoaded = val_12;
        }
        
        bool val_13 = this.isInitialized;
        val_13 = val_13 ^ 1;
        this.isInitialized = val_13;
        return;
        label_25:
    }
    public override void InitMonoSingleton()
    {
        UnityEngine.SceneManagement.SceneManager.add_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void CategoryPacksGameplayUI::OnSceneChanged(UnityEngine.SceneManagement.Scene outgoingScene, UnityEngine.SceneManagement.Scene incomingScene)));
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void CategoryPacksGameplayUI::OnSceneChanged(UnityEngine.SceneManagement.Scene outgoingScene, UnityEngine.SceneManagement.Scene incomingScene)));
    }
    private void OnLevelLoaded(GameLevel gameLevel)
    {
        var val_15;
        var val_16;
        string val_17;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        val_15 = MonoSingleton<CategoryPacksManager>.Instance;
        WordRegion val_5 = WordRegion.instance;
        if((X22 + 24) < 1)
        {
                return;
        }
        
        val_16 = 4;
        label_19:
        if((X22 + 24) <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_17 = X22 + 16 + 32 + 24.ToUpper();
        if((System.String.op_Equality(a:  val_17, b:  gameLevel.word.Replace(oldValue:  "|", newValue:  "").ToUpper())) == true)
        {
            goto label_18;
        }
        
        val_16 = val_16 + 1;
        if((val_16 - 4) < (X22 + 24))
        {
            goto label_19;
        }
        
        return;
        label_18:
        if((X22 + 24) <= (val_16 - 4))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X22 + 16 + 32 + 40 + 24) < 1)
        {
                return;
        }
        
        do
        {
            if((X22 + 16 + 32 + 40 + 24) <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_17 = X22 + 16 + 32 + 40 + 16;
            val_17 = val_17 + 0;
            val_17 = (X22 + 16 + 32 + 40 + 16 + 0) + 32.gameObject.transform;
            UnityEngine.UI.Image val_14 = UnityEngine.Object.Instantiate<UnityEngine.UI.Image>(original:  this.CategoryLetterCellImagePrefab, parent:  val_17);
            val_14.transform.SetAsFirstSibling();
            CategoryColor val_16 = val_15.GetColor(colorCode:  val_3.<CurrentCategoryPackInfo>k__BackingField.color);
            if(val_16 != null)
        {
                val_17 = val_16;
            val_14.sprite = val_16.tileSprite;
            val_14.color = new UnityEngine.Color() {r = val_16.colorValue};
        }
        
            val_16 = 0 + 1;
        }
        while(val_16 < (X22 + 16 + 32 + 40 + 24));
    
    }
    private void UpdateLevelName()
    {
        object val_14;
        int val_15;
        CategoryPacksManager val_1 = MonoSingleton<CategoryPacksManager>.Instance;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_1.<CurrentCategoryPackInfo>k__BackingField) == null)
        {
            goto label_4;
        }
        
        val_14 = val_1.GetWordBank(packId:  val_1.<CurrentCategoryPackInfo>k__BackingField.packId);
        object[] val_3 = new object[4];
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = val_3.Length;
        val_3[0] = val_1.<CurrentCategoryPackInfo>k__BackingField.title;
        if((val_1.<CurrentCategoryPackInfo>k__BackingField.suffix) != null)
        {
                val_15 = val_3.Length;
        }
        
        val_3[1] = val_1.<CurrentCategoryPackInfo>k__BackingField.suffix;
        val_3[2] = (val_1.GetPackProgress(packId:  val_1.<CurrentCategoryPackInfo>k__BackingField.packId)) + 1;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14 = val_14.Size;
        val_3[3] = val_14;
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_8.levelNameGroup == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_9 = val_8.levelNameGroup.transform;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14 = val_9;
        if(null != null)
        {
            goto label_24;
        }
        
        UnityEngine.Vector2 val_10 = val_14.sizeDelta;
        UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  500f, y:  val_10.y);
        val_14.sizeDelta = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
        MainController val_12 = MainController.instance;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.SetLevelName(str:  System.String.Format(format:  "{0} {1} - {2}/{3}", args:  val_3), isVisible:  true);
        return;
        label_4:
        object[] val_13 = new object[4];
        throw new NullReferenceException();
        label_24:
    }
    public CategoryPacksGameplayUI()
    {
    
    }

}
