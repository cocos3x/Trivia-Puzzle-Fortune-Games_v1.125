using UnityEngine;
public class ParticleEffectsLibrary : MonoBehaviour
{
    // Fields
    public static ParticleEffectsLibrary GlobalAccess;
    public int TotalEffects;
    public int CurrentParticleEffectIndex;
    public int CurrentParticleEffectNum;
    public UnityEngine.Vector3[] ParticleEffectSpawnOffsets;
    public float[] ParticleEffectLifetimes;
    public UnityEngine.GameObject[] ParticleEffectPrefabs;
    private string effectNameString;
    private System.Collections.Generic.List<UnityEngine.Transform> currentActivePEList;
    private UnityEngine.Vector3 spawnPosition;
    
    // Methods
    private void Awake()
    {
        UnityEngine.GameObject[] val_7;
        int val_8;
        int val_9;
        int val_10;
        ParticleEffectsLibrary.GlobalAccess = this;
        val_7 = this.ParticleEffectPrefabs;
        this.currentActivePEList = new System.Collections.Generic.List<UnityEngine.Transform>();
        this.CurrentParticleEffectNum = 1;
        mem[1152921515807470280] = this.ParticleEffectPrefabs.Length;
        if(this.ParticleEffectPrefabs.Length != this.ParticleEffectSpawnOffsets.Length)
        {
                UnityEngine.Debug.LogError(message:  "ParticleEffectsLibrary-ParticleEffectSpawnOffset: Not all arrays match length, double check counts.");
            val_7 = this.ParticleEffectPrefabs;
        }
        
        if(mem[1152921515807470280] != this.ParticleEffectPrefabs.Length)
        {
                UnityEngine.Debug.LogError(message:  "ParticleEffectsLibrary-ParticleEffectPrefabs: Not all arrays match length, double check counts.");
        }
        
        string[] val_2 = new string[6];
        val_8 = val_2.Length;
        val_2[0] = this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].name;
        val_8 = val_2.Length;
        val_2[1] = " (";
        val_9 = val_2.Length;
        val_2[2] = this.CurrentParticleEffectNum.ToString();
        val_9 = val_2.Length;
        val_2[3] = " of ";
        val_10 = val_2.Length;
        val_2[4] = mem[1152921515807470280].ToString();
        val_10 = val_2.Length;
        val_2[5] = ")";
        this.effectNameString = +val_2;
    }
    private void Start()
    {
    
    }
    public string GetCurrentPENameString()
    {
        int val_5;
        int val_6;
        int val_7;
        string[] val_1 = new string[6];
        val_5 = val_1.Length;
        val_1[0] = this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].name;
        val_5 = val_1.Length;
        val_1[1] = " (";
        val_6 = val_1.Length;
        val_1[2] = this.CurrentParticleEffectNum.ToString();
        val_6 = val_1.Length;
        val_1[3] = " of ";
        val_7 = val_1.Length;
        val_1[4] = this.TotalEffects.ToString();
        val_7 = val_1.Length;
        val_1[5] = ")";
        return +val_1;
    }
    public void PreviousParticleEffect()
    {
        int val_9;
        int val_10;
        int val_11;
        int val_12;
        val_9 = this.CurrentParticleEffectIndex;
        if((this.ParticleEffectLifetimes[(long)val_9] == 0f) && (this.ParticleEffectLifetimes[(long)val_9] >= 1))
        {
                var val_11 = 4;
            if(0 >= this.ParticleEffectLifetimes[(long)val_9])
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((this.CurrentParticleEffectIndex + 32) != 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Object.Destroy(obj:  UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32.gameObject);
        }
        
            var val_3 = val_11 - 3;
            val_11 = val_11 + 1;
            this.currentActivePEList.Clear();
            val_9 = this.CurrentParticleEffectIndex;
        }
        
        if(val_9 <= 0)
        {
                val_9 = this.TotalEffects;
        }
        
        this.CurrentParticleEffectNum = val_9;
        this.CurrentParticleEffectIndex = val_9 - 1;
        string[] val_5 = new string[6];
        val_10 = val_5.Length;
        val_5[0] = this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].name;
        val_10 = val_5.Length;
        val_5[1] = " (";
        val_11 = val_5.Length;
        val_5[2] = this.CurrentParticleEffectNum.ToString();
        val_11 = val_5.Length;
        val_5[3] = " of ";
        val_12 = val_5.Length;
        val_5[4] = this.TotalEffects.ToString();
        val_12 = val_5.Length;
        val_5[5] = ")";
        this.effectNameString = +val_5;
    }
    public void NextParticleEffect()
    {
        int val_9;
        int val_10;
        int val_11;
        int val_12;
        val_9 = this.CurrentParticleEffectIndex;
        if((this.ParticleEffectLifetimes[(long)val_9] == 0f) && (this.ParticleEffectLifetimes[(long)val_9] >= 1))
        {
                var val_11 = 4;
            if(0 >= this.ParticleEffectLifetimes[(long)val_9])
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((this.CurrentParticleEffectIndex + 32) != 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Object.Destroy(obj:  UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32.gameObject);
        }
        
            var val_3 = val_11 - 3;
            val_11 = val_11 + 1;
            this.currentActivePEList.Clear();
            val_9 = this.CurrentParticleEffectIndex;
        }
        
        int val_12 = this.TotalEffects;
        val_12 = val_12 - 1;
        int val_4 = (val_9 >= val_12) ? 0 : (val_9 + 1);
        val_12 = val_4 + 1;
        this.CurrentParticleEffectIndex = val_4;
        mem[1152921515808554480] = val_12;
        string[] val_5 = new string[6];
        val_10 = val_5.Length;
        val_5[0] = this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex].name;
        val_10 = val_5.Length;
        val_5[1] = " (";
        val_11 = val_5.Length;
        val_5[2] = mem[1152921515808554480].ToString();
        val_11 = val_5.Length;
        val_5[3] = " of ";
        val_12 = val_5.Length;
        val_5[4] = val_12.ToString();
        val_12 = val_5.Length;
        val_5[5] = ")";
        this.effectNameString = +val_5;
    }
    public void SpawnParticleEffect(UnityEngine.Vector3 positionInWorldToSpawn)
    {
        UnityEngine.Vector3[] val_8 = this.ParticleEffectSpawnOffsets;
        val_8 = val_8 + (this.CurrentParticleEffectIndex * 12);
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = positionInWorldToSpawn.x, y = positionInWorldToSpawn.y, z = positionInWorldToSpawn.z}, b:  new UnityEngine.Vector3() {x = (this.CurrentParticleEffectIndex * 12) + this.ParticleEffectSpawnOffsets + 32, y = (this.CurrentParticleEffectIndex * 12) + this.ParticleEffectSpawnOffsets + 32 + 4, z = (this.CurrentParticleEffectIndex * 12) + this.ParticleEffectSpawnOffsets + 40});
        this.spawnPosition = val_1;
        mem[1152921515809002532] = val_1.y;
        mem[1152921515809002536] = val_1.z;
        UnityEngine.GameObject val_9 = this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex];
        UnityEngine.Quaternion val_3 = val_9.transform.rotation;
        UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_9, position:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, rotation:  new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w});
        val_4.name = "PE_" + this.ParticleEffectPrefabs[this.CurrentParticleEffectIndex];
        if(this.ParticleEffectLifetimes[this.CurrentParticleEffectIndex] == 0f)
        {
                this.currentActivePEList.Add(item:  val_4.transform);
        }
        
        this.currentActivePEList.Add(item:  val_4.transform);
        float val_12 = this.ParticleEffectLifetimes[this.CurrentParticleEffectIndex];
        if(val_12 == 0f)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  val_4, t:  val_12);
    }
    public ParticleEffectsLibrary()
    {
        this.effectNameString = "";
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
        this.spawnPosition = val_1;
        mem[1152921515809335716] = val_1.y;
        mem[1152921515809335720] = val_1.z;
    }

}
