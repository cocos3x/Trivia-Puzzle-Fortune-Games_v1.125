using UnityEngine;
public class UITheme : ScriptableObject
{
    // Fields
    public Themes themeType;
    public ThemeSettings themeSettings;
    public System.Collections.Generic.List<UnityEngine.Sprite> sprites;
    public System.Collections.Generic.List<UnityEngine.Texture> textures;
    public System.Collections.Generic.List<UnityEngine.Font> fonts;
    public System.Collections.Generic.List<ThemeTextSettings> themeTextSettings;
    private UnityEngine.GameObject statViewPrefab;
    private UnityEngine.GameObject _statViewPrefab;
    private UnityEngine.GameObject _statViewPrefab_anchored;
    private GridCoinCollectAnimation gridCoinCollectAnimation;
    private GridCoinCollectAnimation _gridCoinCollectAnimation;
    private AnimatedCoin animatedCoin;
    private AnimatedCoin _animatedCoin;
    private UnityEngine.GameObject coinsGainedAnimContents;
    private UnityEngine.GameObject _coinsGainedAnimContents;
    private UnityEngine.GameObject goldenCurrencyStatViewPrefab;
    private UnityEngine.GameObject _goldenCurrencyStatViewPrefab;
    private UnityEngine.GameObject _goldenCurrencyStatViewPrefab_anchored;
    private UnityEngine.GameObject goldCurrencyParticleSystem;
    private UnityEngine.GameObject _goldCurrencyParticleSystem;
    private UnityEngine.GameObject gemCurrencyStatViewPrefab;
    private UnityEngine.GameObject _gemCurrencyStatViewPrefab;
    private UnityEngine.GameObject _gemCurrencyStatViewPrefab_anchored;
    private UnityEngine.GameObject gemCurrencyParticleSystem;
    private UnityEngine.GameObject _gemCurrencyParticleSystem;
    private UnityEngine.GameObject coinCurrencyStatViewPrefab;
    private UnityEngine.GameObject _coinCurrencyStatViewPrefab;
    private UnityEngine.GameObject _coinCurrencyStatViewPrefab_anchored;
    private UnityEngine.GameObject coinCurrencyParticleSystem;
    private UnityEngine.GameObject _coinCurrencyParticleSystem;
    private UnityEngine.GameObject petsFoodStatViewPrefab;
    private UnityEngine.GameObject _petsFoodStatViewPrefab;
    private UnityEngine.GameObject _petsFoodStatViewPrefab_anchored;
    private UnityEngine.GameObject petsFoodCurrencyParticleSystem;
    private UnityEngine.GameObject _petsFoodCurrencyParticleSystem;
    private UnityEngine.GameObject _spinCurrencyStatViewPrefab;
    private UnityEngine.GameObject _spinCurrencyStatViewPrefab_anchored;
    private UnityEngine.GameObject _spinCurrencyParticleSystem;
    private UnityEngine.GameObject _streakCurrencyStatViewPrefab;
    private UnityEngine.GameObject _streakCurrencyStatViewPrefab_anchored;
    private UnityEngine.GameObject _diceRollStatViewPrefab;
    private UnityEngine.GameObject _diceRollStatViewPrefab_anchored;
    private UnityEngine.GameObject _diceRollCurrencyParticleSystem;
    private UnityEngine.GameObject _petsCardStatViewPrefab;
    private UnityEngine.GameObject _petsCardStatViewPrefab_anchored;
    private UnityEngine.GameObject _petsCardCurrencyParticleSystem;
    public WordIQCellOverlay wordIQCell;
    public WordIQLineAnim wordIQNewWordTag;
    private WordIQLineAnim wordIQNewWordAnswered;
    private WordIQLineAnim _wordIQNewWordAnswered;
    public UnityEngine.Sprite wordIQMilestoneColorableSprite;
    public UnityEngine.Sprite wordIQMilestoneMasterSprite;
    public UnityEngine.UI.Image categoryLetterCell;
    public UIThemeTemplate[] graphicTemplates;
    
    // Properties
    public UnityEngine.GameObject StatViewPrefab { get; }
    public UnityEngine.GameObject StatViewPrefab_anchored { get; }
    public GridCoinCollectAnimation GridCoinCollectAnimation { get; }
    public AnimatedCoin AnimatedCoin { get; }
    public UnityEngine.GameObject CoinsGainedAnimContents { get; }
    public UnityEngine.GameObject GoldenCurrencyStatViewPrefab { get; }
    public UnityEngine.GameObject GoldenCurrencyStatViewPrefab_anchored { get; }
    public UnityEngine.GameObject GoldCurrencyParticleSystem { get; }
    public UnityEngine.GameObject GemCurrencyStatViewPrefab { get; }
    public UnityEngine.GameObject GemCurrencyStatViewPrefab_anchored { get; }
    public UnityEngine.GameObject GemCurrencyParticleSystem { get; }
    public UnityEngine.GameObject CoinCurrencyStatViewPrefab { get; }
    public UnityEngine.GameObject CoinCurrencyStatViewPrefab_anchored { get; }
    public UnityEngine.GameObject CoinCurrencyParticleSystem { get; }
    public UnityEngine.GameObject PetsFoodStatViewPrefab { get; }
    public UnityEngine.GameObject PetsFoodStatViewPrefab_anchored { get; }
    public UnityEngine.GameObject PetsFoodCurrencyParticleSystem { get; }
    public UnityEngine.GameObject SpinCurrencyStatViewPrefab { get; }
    public UnityEngine.GameObject SpinCurrencyStatViewPrefab_anchored { get; }
    public UnityEngine.GameObject SpinCurrencyParticleSystem { get; }
    public UnityEngine.GameObject StreakStatViewPrefab { get; }
    public UnityEngine.GameObject StreakStatViewPrefab_anchored { get; }
    public UnityEngine.GameObject DiceRollStatViewPrefab { get; }
    public UnityEngine.GameObject DiceRollStatViewPrefab_anchored { get; }
    public UnityEngine.GameObject DiceRollCurrencyParticleSystem { get; }
    public UnityEngine.GameObject PetsCardStatViewPrefab { get; }
    public UnityEngine.GameObject PetCardsStatViewPrefab_anchored { get; }
    public UnityEngine.GameObject PetsCardCurrencyParticleSystem { get; }
    public WordIQLineAnim WordIQNewWordAnswered { get; }
    
    // Methods
    public UnityEngine.GameObject get_StatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._statViewPrefab == 0)
        {
                this._statViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Coins");
            return val_3;
        }
        
        val_3 = this._statViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_StatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._statViewPrefab_anchored == 0)
        {
                this._statViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Coins_anchored");
            return val_3;
        }
        
        val_3 = this._statViewPrefab_anchored;
        return val_3;
    }
    public GridCoinCollectAnimation get_GridCoinCollectAnimation()
    {
        GridCoinCollectAnimation val_3;
        if(this._gridCoinCollectAnimation == 0)
        {
                this._gridCoinCollectAnimation = PrefabLoader.LoadPrefab<GridCoinCollectAnimation>(featureName:  "StatViews");
            return val_3;
        }
        
        val_3 = this._gridCoinCollectAnimation;
        return val_3;
    }
    public AnimatedCoin get_AnimatedCoin()
    {
        AnimatedCoin val_3;
        if(this._animatedCoin == 0)
        {
                this._animatedCoin = PrefabLoader.LoadPrefab<AnimatedCoin>(featureName:  "StatViews");
            return val_3;
        }
        
        val_3 = this._animatedCoin;
        return val_3;
    }
    public UnityEngine.GameObject get_CoinsGainedAnimContents()
    {
        UnityEngine.GameObject val_3;
        if(this._coinsGainedAnimContents == 0)
        {
                this._coinsGainedAnimContents = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "Anim_Coins");
            return val_3;
        }
        
        val_3 = this._coinsGainedAnimContents;
        return val_3;
    }
    public UnityEngine.GameObject get_GoldenCurrencyStatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._goldenCurrencyStatViewPrefab == 0)
        {
                this._goldenCurrencyStatViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_GoldCurrency");
            return val_3;
        }
        
        val_3 = this._goldenCurrencyStatViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_GoldenCurrencyStatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._goldenCurrencyStatViewPrefab_anchored == 0)
        {
                this._goldenCurrencyStatViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_GoldCurrency_anchored");
            return val_3;
        }
        
        val_3 = this._goldenCurrencyStatViewPrefab_anchored;
        return val_3;
    }
    public UnityEngine.GameObject get_GoldCurrencyParticleSystem()
    {
        UnityEngine.GameObject val_3;
        if(this._goldCurrencyParticleSystem == 0)
        {
                this._goldCurrencyParticleSystem = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "Anim_GoldCurrency_Particles");
            return val_3;
        }
        
        val_3 = this._goldCurrencyParticleSystem;
        return val_3;
    }
    public UnityEngine.GameObject get_GemCurrencyStatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._gemCurrencyStatViewPrefab == 0)
        {
                this._gemCurrencyStatViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Gems");
            return val_3;
        }
        
        val_3 = this._gemCurrencyStatViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_GemCurrencyStatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._gemCurrencyStatViewPrefab_anchored == 0)
        {
                this._gemCurrencyStatViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Gems_anchored");
            return val_3;
        }
        
        val_3 = this._gemCurrencyStatViewPrefab_anchored;
        return val_3;
    }
    public UnityEngine.GameObject get_GemCurrencyParticleSystem()
    {
        UnityEngine.GameObject val_3;
        if(this._gemCurrencyParticleSystem == 0)
        {
                this._gemCurrencyParticleSystem = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "Anim_Gems_Particles");
            return val_3;
        }
        
        val_3 = this._gemCurrencyParticleSystem;
        return val_3;
    }
    public UnityEngine.GameObject get_CoinCurrencyStatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._coinCurrencyStatViewPrefab == 0)
        {
                this._coinCurrencyStatViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Coins_Particles");
            return val_3;
        }
        
        val_3 = this._coinCurrencyStatViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_CoinCurrencyStatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._coinCurrencyStatViewPrefab_anchored == 0)
        {
                this._coinCurrencyStatViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Coins_Particles_anchored");
            return val_3;
        }
        
        val_3 = this._coinCurrencyStatViewPrefab_anchored;
        return val_3;
    }
    public UnityEngine.GameObject get_CoinCurrencyParticleSystem()
    {
        UnityEngine.GameObject val_3;
        if(this._coinCurrencyParticleSystem == 0)
        {
                this._coinCurrencyParticleSystem = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "Anim_Coins_Particles");
            return val_3;
        }
        
        val_3 = this._coinCurrencyParticleSystem;
        return val_3;
    }
    public UnityEngine.GameObject get_PetsFoodStatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._petsFoodStatViewPrefab == 0)
        {
                this._petsFoodStatViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_PetFood");
            return val_3;
        }
        
        val_3 = this._petsFoodStatViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_PetsFoodStatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._petsFoodStatViewPrefab_anchored == 0)
        {
                this._petsFoodStatViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_PetFood_anchored");
            return val_3;
        }
        
        val_3 = this._petsFoodStatViewPrefab_anchored;
        return val_3;
    }
    public UnityEngine.GameObject get_PetsFoodCurrencyParticleSystem()
    {
        UnityEngine.GameObject val_3;
        if(this._petsFoodCurrencyParticleSystem == 0)
        {
                this._petsFoodCurrencyParticleSystem = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "Anim_PetFood_Particles");
            return val_3;
        }
        
        val_3 = this._petsFoodCurrencyParticleSystem;
        return val_3;
    }
    public UnityEngine.GameObject get_SpinCurrencyStatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._spinCurrencyStatViewPrefab == 0)
        {
                this._spinCurrencyStatViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Spins");
            return val_3;
        }
        
        val_3 = this._spinCurrencyStatViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_SpinCurrencyStatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._spinCurrencyStatViewPrefab_anchored == 0)
        {
                this._spinCurrencyStatViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Spins_anchored");
            return val_3;
        }
        
        val_3 = this._spinCurrencyStatViewPrefab_anchored;
        return val_3;
    }
    public UnityEngine.GameObject get_SpinCurrencyParticleSystem()
    {
        UnityEngine.GameObject val_3;
        if(this._spinCurrencyParticleSystem == 0)
        {
                this._spinCurrencyParticleSystem = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "Anim_Spins_Particles");
            return val_3;
        }
        
        val_3 = this._spinCurrencyParticleSystem;
        return val_3;
    }
    public UnityEngine.GameObject get_StreakStatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._streakCurrencyStatViewPrefab == 0)
        {
                this._streakCurrencyStatViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Streak");
            return val_3;
        }
        
        val_3 = this._streakCurrencyStatViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_StreakStatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._streakCurrencyStatViewPrefab_anchored == 0)
        {
                this._streakCurrencyStatViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_Streak_anchored");
            return val_3;
        }
        
        val_3 = this._streakCurrencyStatViewPrefab_anchored;
        return val_3;
    }
    public UnityEngine.GameObject get_DiceRollStatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._diceRollStatViewPrefab == 0)
        {
                this._diceRollStatViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_DiceRoll");
            return val_3;
        }
        
        val_3 = this._diceRollStatViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_DiceRollStatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._diceRollStatViewPrefab_anchored == 0)
        {
                this._diceRollStatViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_DiceRoll_anchored");
            return val_3;
        }
        
        val_3 = this._diceRollStatViewPrefab_anchored;
        return val_3;
    }
    public UnityEngine.GameObject get_DiceRollCurrencyParticleSystem()
    {
        UnityEngine.GameObject val_3;
        if(this._diceRollCurrencyParticleSystem == 0)
        {
                this._diceRollCurrencyParticleSystem = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "Anim_DiceRoll_Particles");
            return val_3;
        }
        
        val_3 = this._diceRollCurrencyParticleSystem;
        return val_3;
    }
    public UnityEngine.GameObject get_PetsCardStatViewPrefab()
    {
        UnityEngine.GameObject val_3;
        if(this._petsCardStatViewPrefab == 0)
        {
                this._petsCardStatViewPrefab = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_PetsCard");
            return val_3;
        }
        
        val_3 = this._petsCardStatViewPrefab;
        return val_3;
    }
    public UnityEngine.GameObject get_PetCardsStatViewPrefab_anchored()
    {
        UnityEngine.GameObject val_3;
        if(this._petsCardStatViewPrefab_anchored == 0)
        {
                this._petsCardStatViewPrefab_anchored = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "StatView_PetsCard_anchored");
            return val_3;
        }
        
        val_3 = this._petsCardStatViewPrefab_anchored;
        return val_3;
    }
    public UnityEngine.GameObject get_PetsCardCurrencyParticleSystem()
    {
        UnityEngine.GameObject val_3;
        if(this._petsCardCurrencyParticleSystem == 0)
        {
                this._petsCardCurrencyParticleSystem = PrefabLoader.LoadPrefab(featureName:  "StatViews", prefabName:  "Anim_PetsCard_Particles");
            return val_3;
        }
        
        val_3 = this._petsCardCurrencyParticleSystem;
        return val_3;
    }
    public WordIQLineAnim get_WordIQNewWordAnswered()
    {
        WordIQLineAnim val_3;
        if(this._wordIQNewWordAnswered == 0)
        {
                this._wordIQNewWordAnswered = PrefabLoader.LoadPrefab<WordIQLineAnim>(featureName:  "WordIQ");
            return val_3;
        }
        
        val_3 = this._wordIQNewWordAnswered;
        return val_3;
    }
    public UITheme()
    {
        this.themeSettings = new ThemeSettings();
        this.themeTextSettings = new System.Collections.Generic.List<ThemeTextSettings>();
    }

}
