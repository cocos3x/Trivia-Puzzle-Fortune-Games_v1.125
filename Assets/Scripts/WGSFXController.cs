using UnityEngine;
public class WGSFXController : MonoSingleton<WGSFXController>
{
    // Fields
    private System.Collections.Generic.Dictionary<string, UnityEngine.ParticleSystem> loadedSFX;
    private PrefabsFromFolder prefabsFromFolder;
    private UnityEngine.ParticleSystem sfx;
    
    // Methods
    public UnityEngine.ParticleSystem PlaySFX(WGSFXController.SFXType reqType, UnityEngine.RectTransform parent, bool playImmediate = True)
    {
        playImmediate = playImmediate;
        return (UnityEngine.ParticleSystem)this.PlaySFX(name:  reqType.ToString(), parent:  parent, playImmediate:  playImmediate);
    }
    public UnityEngine.ParticleSystem PlaySFX(string name, UnityEngine.RectTransform parent, bool playImmediate = True)
    {
        UnityEngine.ParticleSystem val_1 = this.LoadSFX(name:  name);
        MainModule val_2 = val_1.main;
        val_2.m_ParticleSystem.playOnAwake = playImmediate;
        UnityEngine.ParticleSystem val_4 = UnityEngine.Object.Instantiate<UnityEngine.ParticleSystem>(original:  val_1, parent:  parent);
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        val_4.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        return val_4;
    }
    private UnityEngine.ParticleSystem LoadSFX(string name)
    {
        string val_8;
        UnityEngine.ParticleSystem val_9;
        val_8 = name;
        if((this.loadedSFX.ContainsKey(key:  val_8)) != false)
        {
                UnityEngine.ParticleSystem val_2 = this.loadedSFX.Item[val_8];
            this.sfx = val_2;
            if(val_2 != 0)
        {
                val_9 = this.sfx;
            return (UnityEngine.ParticleSystem)val_9;
        }
        
            bool val_4 = this.loadedSFX.Remove(key:  val_8);
        }
        
        val_9 = this.prefabsFromFolder.LoadLooselyNamedPrefab<UnityEngine.ParticleSystem>(prefabName:  val_8);
        if(val_9 != 0)
        {
                this.loadedSFX.Add(key:  val_8, value:  val_9);
            return (UnityEngine.ParticleSystem)val_9;
        }
        
        val_8 = "no particle system found on loaded SFX asset " + val_8;
        UnityEngine.Debug.LogError(message:  val_8);
        val_9 = 0;
        return (UnityEngine.ParticleSystem)val_9;
    }
    public WGSFXController()
    {
        this.loadedSFX = new System.Collections.Generic.Dictionary<System.String, UnityEngine.ParticleSystem>();
    }

}
