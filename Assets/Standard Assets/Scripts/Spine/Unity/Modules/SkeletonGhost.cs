using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonGhost : MonoBehaviour
    {
        // Fields
        private const UnityEngine.HideFlags GhostHideFlags = 1;
        private const string GhostingShaderName = "Spine/Special/SkeletonGhost";
        public bool ghostingEnabled;
        public float spawnRate;
        public UnityEngine.Color32 color;
        public bool additive;
        public int maximumGhosts;
        public float fadeSpeed;
        public UnityEngine.Shader ghostShader;
        public float textureFade;
        public bool sortWithDistanceOnly;
        public float zOffset;
        private float nextSpawnTime;
        private Spine.Unity.Modules.SkeletonGhostRenderer[] pool;
        private int poolIndex;
        private Spine.Unity.SkeletonRenderer skeletonRenderer;
        private UnityEngine.MeshRenderer meshRenderer;
        private UnityEngine.MeshFilter meshFilter;
        private readonly System.Collections.Generic.Dictionary<UnityEngine.Material, UnityEngine.Material> materialTable;
        
        // Methods
        private void Start()
        {
            var val_17;
            if(this.ghostShader == 0)
            {
                    this.ghostShader = UnityEngine.Shader.Find(name:  "Spine/Special/SkeletonGhost");
            }
            
            this.skeletonRenderer = this.GetComponent<Spine.Unity.SkeletonRenderer>();
            this.meshFilter = this.GetComponent<UnityEngine.MeshFilter>();
            this.meshRenderer = this.GetComponent<UnityEngine.MeshRenderer>();
            float val_6 = UnityEngine.Time.time;
            val_6 = val_6 + this.spawnRate;
            this.nextSpawnTime = val_6;
            this.pool = new Spine.Unity.Modules.SkeletonGhostRenderer[0];
            if(this.maximumGhosts >= 1)
            {
                    var val_17 = 0;
                do
            {
                System.Type[] val_11 = new System.Type[1];
                val_11[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
                UnityEngine.GameObject val_13 = new UnityEngine.GameObject(name:  this.gameObject.name + " Ghost", components:  val_11);
                this.pool[val_17] = val_13.GetComponent<Spine.Unity.Modules.SkeletonGhostRenderer>();
                val_13.SetActive(value:  false);
                val_13.hideFlags = 1;
                val_17 = val_17 + 1;
            }
            while(val_17 < this.maximumGhosts);
            
            }
            
            if(X0 == false)
            {
                    return;
            }
            
            var val_20 = X0;
            if((X0 + 294) == 0)
            {
                goto label_22;
            }
            
            var val_18 = X0 + 176;
            var val_19 = 0;
            val_18 = val_18 + 8;
            label_21:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_20;
            }
            
            val_19 = val_19 + 1;
            val_18 = val_18 + 16;
            if(val_19 < (X0 + 294))
            {
                goto label_21;
            }
            
            goto label_22;
            label_20:
            val_20 = val_20 + (((X0 + 176 + 8)) << 4);
            val_17 = val_20 + 304;
            label_22:
            X0.AnimationState.add_Event(value:  new AnimationState.TrackEntryEventDelegate(object:  this, method:  System.Void Spine.Unity.Modules.SkeletonGhost::OnEvent(Spine.TrackEntry trackEntry, Spine.Event e)));
        }
        private void OnEvent(Spine.TrackEntry trackEntry, Spine.Event e)
        {
            if((e.data.name.Equals(value:  "Ghosting", comparisonType:  4)) == false)
            {
                    return;
            }
            
            this.ghostingEnabled = (e.intValue > 0) ? 1 : 0;
            if(e.floatValue > 0f)
            {
                    this.spawnRate = e.floatValue;
            }
            
            if((System.String.IsNullOrEmpty(value:  e.stringValue)) == true)
            {
                    return;
            }
            
            UnityEngine.Color32 val_4 = Spine.Unity.Modules.SkeletonGhost.HexToColor(hex:  e.stringValue);
            this.color = val_4;
        }
        private void Ghosting(float val)
        {
            this.ghostingEnabled = (val > 0f) ? 1 : 0;
        }
        private void Update()
        {
            UnityEngine.Material val_21;
            if(this.ghostingEnabled == false)
            {
                    return;
            }
            
            if(UnityEngine.Time.time < this.nextSpawnTime)
            {
                    return;
            }
            
            UnityEngine.Material[] val_3 = this.meshRenderer.sharedMaterials;
            int val_21 = val_3.Length;
            if(val_21 < 1)
            {
                goto label_8;
            }
            
            var val_22 = 0;
            val_21 = val_21 & 4294967295;
            label_21:
            if((this.materialTable.ContainsKey(key:  1152921506161210128)) == false)
            {
                goto label_11;
            }
            
            val_21 = this.materialTable.Item[1152921506161210128];
            if(val_21 != null)
            {
                goto label_13;
            }
            
            goto label_18;
            label_11:
            UnityEngine.Material val_6 = null;
            val_21 = val_6;
            val_6 = new UnityEngine.Material(source:  1152921506161210128);
            val_6.shader = this.ghostShader;
            UnityEngine.Color val_7 = UnityEngine.Color.white;
            val_6.color = new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a};
            if((val_6.HasProperty(name:  "_TextureFade")) != false)
            {
                    val_6.SetFloat(name:  "_TextureFade", value:  this.textureFade);
            }
            
            this.materialTable.Add(key:  1152921506161210128, value:  val_6);
            if(val_21 == null)
            {
                goto label_18;
            }
            
            label_13:
            label_18:
            mem2[0] = val_21;
            val_22 = val_22 + 1;
            if(val_22 < (val_3.Length << ))
            {
                goto label_21;
            }
            
            label_8:
            UnityEngine.Transform val_9 = this.pool[this.poolIndex].gameObject.transform;
            val_9.parent = this.transform;
            UnityEngine.MeshRenderer val_24 = this.meshRenderer;
            val_24 = val_24.sortingOrder + this.sortWithDistanceOnly;
            this.pool[this.poolIndex].Initialize(mesh:  this.meshFilter.sharedMesh, materials:  val_3, color:  new UnityEngine.Color32() {r = this.color, g = this.color, b = this.color, a = this.color}, additive:  (this.additive == true) ? 1 : 0, speed:  this.fadeSpeed, sortingLayerID:  this.meshRenderer.sortingLayerID, sortingOrder:  val_24 - 1);
            UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  this.zOffset);
            val_9.localPosition = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
            UnityEngine.Quaternion val_17 = UnityEngine.Quaternion.identity;
            val_9.localRotation = new UnityEngine.Quaternion() {x = val_17.x, y = val_17.y, z = val_17.z, w = val_17.w};
            UnityEngine.Vector3 val_18 = UnityEngine.Vector3.one;
            val_9.localScale = new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z};
            val_9.parent = 0;
            int val_25 = this.poolIndex;
            val_25 = val_25 + 1;
            this.poolIndex = val_25;
            if(val_25 == this.pool.Length)
            {
                    this.poolIndex = 0;
            }
            
            float val_19 = UnityEngine.Time.time;
            val_19 = val_19 + this.spawnRate;
            this.nextSpawnTime = val_19;
        }
        private void OnDestroy()
        {
            if(this.maximumGhosts >= 1)
            {
                    var val_9 = 4;
                do
            {
                var val_1 = val_9 - 4;
                if(this.pool[0] != 0)
            {
                    this.pool[0].Cleanup();
            }
            
                val_9 = val_9 + 1;
            }
            while((val_9 - 3) < this.maximumGhosts);
            
            }
            
            Dictionary.ValueCollection.Enumerator<TKey, TValue> val_5 = this.materialTable.Values.GetEnumerator();
            label_16:
            if(0.MoveNext() == false)
            {
                goto label_13;
            }
            
            UnityEngine.Object.Destroy(obj:  0);
            goto label_16;
            label_13:
            0.Dispose();
        }
        private static UnityEngine.Color32 HexToColor(string hex)
        {
            byte val_13;
            var val_14;
            byte val_15;
            val_13 = hex;
            if(hex.m_stringLength <= 5)
            {
                goto label_2;
            }
            
            string val_1 = val_13.Replace(oldValue:  "#", newValue:  "");
            val_13 = System.Byte.Parse(s:  val_1.Substring(startIndex:  0, length:  2), style:  3);
            if(val_1.m_stringLength != 8)
            {
                goto label_4;
            }
            
            val_14 = System.Byte.Parse(s:  val_1.Substring(startIndex:  6, length:  2), style:  3);
            goto label_5;
            label_2:
            UnityEngine.Color val_10 = UnityEngine.Color.magenta;
            val_15 = 0;
            UnityEngine.Color32 val_11 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a});
            return new UnityEngine.Color32() {r = val_15, g = val_15, b = val_15, a = val_15};
            label_4:
            val_14 = 255;
            label_5:
            UnityEngine.Color32 val_12 = new UnityEngine.Color32(r:  val_13, g:  System.Byte.Parse(s:  val_1.Substring(startIndex:  2, length:  2), style:  3), b:  System.Byte.Parse(s:  val_1.Substring(startIndex:  4, length:  2), style:  3), a:  255);
            val_15 = val_12.r;
            return new UnityEngine.Color32() {r = val_15, g = val_15, b = val_15, a = val_15};
        }
        public SkeletonGhost()
        {
            this.ghostingEnabled = true;
            this.spawnRate = 0.05f;
            UnityEngine.Color32 val_1 = new UnityEngine.Color32(r:  255, g:  255, b:  255, a:  0);
            this.additive = true;
            this.maximumGhosts = 10;
            this.fadeSpeed = 10f;
            this.textureFade = 1f;
            this.color = val_1.r;
            this.materialTable = new System.Collections.Generic.Dictionary<UnityEngine.Material, UnityEngine.Material>();
        }
    
    }

}
