using UnityEngine;
public class ETFXSceneManager : MonoBehaviour
{
    // Fields
    public bool GUIHide;
    public bool GUIHide2;
    public bool GUIHide3;
    public bool GUIHide4;
    
    // Methods
    public void LoadScene2DDemo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_2ddemo");
    }
    public void LoadSceneCards()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_cards");
    }
    public void LoadSceneCombat()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_combat");
    }
    public void LoadSceneDecals()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_decals");
    }
    public void LoadSceneDecals2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_decals2");
    }
    public void LoadSceneEmojis()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_emojis");
    }
    public void LoadSceneEmojis2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_emojis2");
    }
    public void LoadSceneExplosions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_explosions");
    }
    public void LoadSceneExplosions2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_explosions2");
    }
    public void LoadSceneFire()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_fire");
    }
    public void LoadSceneFire2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_fire2");
    }
    public void LoadSceneFire3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_fire3");
    }
    public void LoadSceneFireworks()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_fireworks");
    }
    public void LoadSceneFlares()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_flares");
    }
    public void LoadSceneMagic()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_magic");
    }
    public void LoadSceneMagic2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_magic2");
    }
    public void LoadSceneMagic3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_magic3");
    }
    public void LoadSceneMainDemo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_maindemo");
    }
    public void LoadSceneMissiles()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_missiles");
    }
    public void LoadScenePortals()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_portals");
    }
    public void LoadScenePortals2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_portals2");
    }
    public void LoadScenePowerups()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_powerups");
    }
    public void LoadScenePowerups2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_powerups2");
    }
    public void LoadSceneSparkles()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_sparkles");
    }
    public void LoadSceneSwordCombat()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_swordcombat");
    }
    public void LoadSceneSwordCombat2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_swordcombat2");
    }
    public void LoadSceneMoney()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_money");
    }
    public void LoadSceneHealing()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_healing");
    }
    public void LoadSceneWind()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName:  "etfx_wind");
    }
    private void Update()
    {
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        if((UnityEngine.Input.GetKeyDown(key:  108)) != false)
        {
                this.GUIHide = this.GUIHide ^ 1;
            if(this.GUIHide != false)
        {
                val_16 = 1;
        }
        else
        {
                val_16 = 0;
        }
        
            UnityEngine.GameObject.Find(name:  "CanvasSceneSelect").GetComponent<UnityEngine.Canvas>().enabled = false;
        }
        
        bool val_5 = UnityEngine.Input.GetKeyDown(key:  106);
        if(val_5 != false)
        {
                this.GUIHide2 = this.GUIHide2 ^ 1;
            if(this.GUIHide2 != false)
        {
                val_17 = 1;
        }
        else
        {
                val_17 = 0;
        }
        
            UnityEngine.GameObject.Find(name:  val_5).GetComponent<UnityEngine.Canvas>().enabled = false;
        }
        
        if((UnityEngine.Input.GetKeyDown(key:  104)) != false)
        {
                this.GUIHide3 = this.GUIHide3 ^ 1;
            if(this.GUIHide3 != false)
        {
                val_18 = 1;
        }
        else
        {
                val_18 = 0;
        }
        
            UnityEngine.GameObject.Find(name:  "ParticleSysDisplayCanvas").GetComponent<UnityEngine.Canvas>().enabled = false;
        }
        
        if((UnityEngine.Input.GetKeyDown(key:  107)) == false)
        {
                return;
        }
        
        bool val_16 = this.GUIHide4;
        val_16 = val_16 ^ 1;
        this.GUIHide4 = val_16;
        if(this.GUIHide3 != false)
        {
                val_19 = 0;
        }
        else
        {
                val_19 = 1;
        }
        
        UnityEngine.GameObject.Find(name:  "CanvasTips").GetComponent<UnityEngine.Canvas>().enabled = true;
    }
    public ETFXSceneManager()
    {
    
    }

}
