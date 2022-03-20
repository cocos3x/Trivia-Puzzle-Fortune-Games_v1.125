using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonGhostRenderer : MonoBehaviour
    {
        // Fields
        public float fadeSpeed;
        private UnityEngine.Color32[] colors;
        private UnityEngine.Color32 black;
        private UnityEngine.MeshFilter meshFilter;
        private UnityEngine.MeshRenderer meshRenderer;
        
        // Methods
        private void Awake()
        {
            this.meshRenderer = this.gameObject.AddComponent<UnityEngine.MeshRenderer>();
            this.meshFilter = this.gameObject.AddComponent<UnityEngine.MeshFilter>();
        }
        public void Initialize(UnityEngine.Mesh mesh, UnityEngine.Material[] materials, UnityEngine.Color32 color, bool additive, float speed, int sortingLayerID, int sortingOrder)
        {
            this.StopAllCoroutines();
            this.gameObject.SetActive(value:  true);
            this.meshRenderer.sharedMaterials = materials;
            this.meshRenderer.sortingLayerID = sortingLayerID;
            this.meshRenderer.sortingOrder = sortingOrder;
            this.meshFilter.sharedMesh = UnityEngine.Object.Instantiate<UnityEngine.Mesh>(original:  mesh);
            UnityEngine.Color32[] val_4 = this.meshFilter.sharedMesh.colors32;
            byte val_5 = color.r >> 24;
            val_5 = val_5 + color.r;
            val_5 = val_5 + (color.r >> 8);
            this.colors = val_4;
            if(val_5 == (color.r >> 16))
            {
                goto label_12;
            }
            
            var val_11 = 0;
            label_14:
            if(val_11 >= (val_4.Length << ))
            {
                goto label_12;
            }
            
            val_4[0] = color;
            val_11 = val_11 + 1;
            if(this.colors != null)
            {
                goto label_14;
            }
            
            throw new NullReferenceException();
            label_12:
            this.fadeSpeed = speed;
            if(additive != false)
            {
                    System.Collections.IEnumerator val_8 = this.FadeAdditive();
            }
            
            UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.Fade());
        }
        private System.Collections.IEnumerator Fade()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new SkeletonGhostRenderer.<Fade>d__7();
        }
        private System.Collections.IEnumerator FadeAdditive()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new SkeletonGhostRenderer.<FadeAdditive>d__8();
        }
        public void Cleanup()
        {
            if(this.meshFilter != 0)
            {
                    if(this.meshFilter.sharedMesh != 0)
            {
                    UnityEngine.Object.Destroy(obj:  this.meshFilter.sharedMesh);
            }
            
            }
            
            UnityEngine.Object.Destroy(obj:  this.gameObject);
        }
        public SkeletonGhostRenderer()
        {
            this.fadeSpeed = 10f;
            UnityEngine.Color32 val_1 = new UnityEngine.Color32(r:  0, g:  0, b:  0, a:  0);
            this.black = val_1.r;
        }
    
    }

}
