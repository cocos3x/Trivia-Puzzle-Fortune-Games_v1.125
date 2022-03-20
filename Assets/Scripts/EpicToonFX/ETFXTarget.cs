using UnityEngine;

namespace EpicToonFX
{
    public class ETFXTarget : MonoBehaviour
    {
        // Fields
        public UnityEngine.GameObject hitParticle;
        public UnityEngine.GameObject respawnParticle;
        private UnityEngine.Renderer targetRenderer;
        private UnityEngine.Collider targetCollider;
        
        // Methods
        private void Start()
        {
            this.targetRenderer = this.GetComponent<UnityEngine.Renderer>();
            this.targetCollider = this.GetComponent<UnityEngine.Collider>();
        }
        private void SpawnTarget()
        {
            this.targetRenderer.enabled = true;
            this.targetCollider.enabled = true;
            UnityEngine.Vector3 val_2 = this.transform.position;
            UnityEngine.Quaternion val_4 = this.transform.rotation;
            UnityEngine.Object.Destroy(obj:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.respawnParticle, position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, rotation:  new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w}), t:  3.5f);
        }
        private void OnTriggerEnter(UnityEngine.Collider col)
        {
            if((System.String.op_Equality(a:  col.tag, b:  "Missile")) == false)
            {
                    return;
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.hitParticle)) == false)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_5 = this.transform.position;
            UnityEngine.Quaternion val_7 = this.transform.rotation;
            UnityEngine.Object.Destroy(obj:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.hitParticle, position:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, rotation:  new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w}), t:  2f);
            this.targetRenderer.enabled = false;
            this.targetCollider.enabled = false;
            UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.Respawn());
        }
        private System.Collections.IEnumerator Respawn()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ETFXTarget.<Respawn>d__7();
        }
        public ETFXTarget()
        {
        
        }
    
    }

}
