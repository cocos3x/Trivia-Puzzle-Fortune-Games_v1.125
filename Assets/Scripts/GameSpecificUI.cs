using UnityEngine;
[Serializable]
public class GameSpecificUI : ScriptableObject
{
    // Fields
    private static GameSpecificUI m_currentGame;
    public UnityEngine.GameObject statViewPrefab;
    public GridCoinCollectAnimation gridCoinCollectAnimation;
    public AnimatedCoin animatedCoin;
    public UnityEngine.GameObject coinsGainedAnimContents;
    
    // Properties
    public static GameSpecificUI currentGame { get; }
    public AnimatedCoin AnimatedCoin { get; }
    public UnityEngine.GameObject CoinsGainedAnimContents { get; }
    
    // Methods
    public static GameSpecificUI get_currentGame()
    {
        if(GameSpecificUI.m_currentGame != 0)
        {
                return (GameSpecificUI)GameSpecificUI.m_currentGame;
        }
        
        GameSpecificUI.m_currentGame = WGResources.Load<GameSpecificUI>(fileName:  "UI/GameSpecificUI", extension:  ".asset", errorLog:  true);
        return (GameSpecificUI)GameSpecificUI.m_currentGame;
    }
    public AnimatedCoin get_AnimatedCoin()
    {
        if(App.ThemesHandler == 0)
        {
                return (AnimatedCoin)this.animatedCoin;
        }
        
        ThemesHandler val_3 = App.ThemesHandler;
        if(val_3.theme == 0)
        {
                return (AnimatedCoin)this.animatedCoin;
        }
        
        ThemesHandler val_5 = App.ThemesHandler;
        return val_5.theme.AnimatedCoin;
    }
    public UnityEngine.GameObject get_CoinsGainedAnimContents()
    {
        if(App.ThemesHandler == 0)
        {
                return (UnityEngine.GameObject)this.coinsGainedAnimContents;
        }
        
        ThemesHandler val_3 = App.ThemesHandler;
        if(val_3.theme == 0)
        {
                return (UnityEngine.GameObject)this.coinsGainedAnimContents;
        }
        
        ThemesHandler val_5 = App.ThemesHandler;
        return val_5.theme.CoinsGainedAnimContents;
    }
    public GameSpecificUI()
    {
    
    }

}
