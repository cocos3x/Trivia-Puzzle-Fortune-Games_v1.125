using UnityEngine;

namespace EpicToonFX
{
    public class ETFXButtonScript : MonoBehaviour
    {
        // Fields
        public UnityEngine.GameObject Button;
        private UnityEngine.UI.Text MyButtonText;
        private string projectileParticleName;
        private EpicToonFX.ETFXFireProjectile effectScript;
        private ETFXProjectileScript projectileScript;
        public float buttonsX;
        public float buttonsY;
        public float buttonsSizeX;
        public float buttonsSizeY;
        public float buttonsDistance;
        
        // Methods
        private void Start()
        {
            this.effectScript = UnityEngine.GameObject.Find(name:  "ETFXFireProjectile").GetComponent<EpicToonFX.ETFXFireProjectile>();
            this.getProjectileNames();
            this.MyButtonText = this.Button.transform.Find(n:  "Text").GetComponent<UnityEngine.UI.Text>();
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        private void Update()
        {
            if(this.MyButtonText != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public void getProjectileNames()
        {
            this.projectileScript = this.effectScript.projectiles[this.effectScript.currentProjectile].GetComponent<ETFXProjectileScript>();
            this.projectileParticleName = val_1.projectileParticle.name;
        }
        public bool overButton()
        {
            var val_14;
            UnityEngine.Rect val_1 = new UnityEngine.Rect(x:  this.buttonsX, y:  this.buttonsY, width:  this.buttonsSizeX, height:  this.buttonsSizeY);
            float val_14 = this.buttonsDistance;
            val_14 = this.buttonsX + val_14;
            UnityEngine.Rect val_2 = new UnityEngine.Rect(x:  val_14, y:  this.buttonsY, width:  this.buttonsSizeX, height:  this.buttonsSizeY);
            UnityEngine.Vector3 val_3 = UnityEngine.Input.mousePosition;
            UnityEngine.Vector3 val_5 = UnityEngine.Input.mousePosition;
            val_5.y = (float)UnityEngine.Screen.height - val_5.y;
            UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  val_3.x, y:  val_5.y);
            if((val_1.m_XMin.Contains(point:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y})) != false)
            {
                    val_14 = 1;
                return (bool)val_2.m_XMin.Contains(point:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y});
            }
            
            UnityEngine.Vector3 val_8 = UnityEngine.Input.mousePosition;
            UnityEngine.Vector3 val_10 = UnityEngine.Input.mousePosition;
            val_10.y = (float)UnityEngine.Screen.height - val_10.y;
            UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  val_8.x, y:  val_10.y);
            return (bool)val_2.m_XMin.Contains(point:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y});
        }
        public ETFXButtonScript()
        {
        
        }
    
    }

}
