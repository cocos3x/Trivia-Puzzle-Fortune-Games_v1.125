using UnityEngine;
public class MonoUtils : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Text letter;
    public LineWord lineWord;
    public UnityEngine.Transform textFlyTransform;
    public UnityEngine.GameObject rubyFly;
    public UnityEngine.GameObject levelButton;
    public UnityEngine.ParticleSystem tileTrailEffect;
    public static MonoUtils instance;
    
    // Properties
    public LetterTile letterTile { get; }
    public Cell cell { get; }
    
    // Methods
    public LetterTile get_letterTile()
    {
        ThemesHandler val_1 = MonoSingleton<ThemesHandler>.Instance;
        return (LetterTile)val_1.theme.themeSettings.LetterTile;
    }
    public Cell get_cell()
    {
        ThemesHandler val_1 = MonoSingleton<ThemesHandler>.Instance;
        return (Cell)val_1.theme.themeSettings.cellTile;
    }
    private void Awake()
    {
        MonoUtils.instance = this;
    }
    public MonoUtils()
    {
    
    }

}
