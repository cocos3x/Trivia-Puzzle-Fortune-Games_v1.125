using UnityEngine;
public class LineDrawer : MonoBehaviour
{
    // Fields
    public const string Event_OnEnableAllLetters = "OnEnableAllLetters";
    public System.Collections.Generic.List<UnityEngine.Vector3> letterPositions;
    public System.Collections.Generic.List<bool> allowedPositions;
    public System.Collections.Generic.List<int> currentIndexes;
    public System.Collections.Generic.List<UnityEngine.Vector3> points;
    public System.Collections.Generic.List<UnityEngine.Vector3> positions;
    public TextPreview textPreview;
    private UnityEngine.LineRenderer lineRenderer;
    private UnityEngine.Vector2 mousePoint;
    public static LineDrawer instance;
    private bool isDragging;
    private int downOnIndex;
    public LineDrawerParticles lineDrawerParticles;
    
    // Methods
    private void Awake()
    {
        LineDrawer.instance = this;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnEnableAllLetters");
    }
    private void OnEnableAllLetters()
    {
        this.AllowAll();
    }
    private void Start()
    {
        UnityEngine.LineRenderer val_1 = this.GetComponent<UnityEngine.LineRenderer>();
        this.lineRenderer = val_1;
        val_1.sortingLayerName = "MyLineRenderer";
        if((MonoSingleton<ThemesHandler>.Instance) != 0)
        {
                ThemesHandler val_4 = MonoSingleton<ThemesHandler>.Instance;
            this.lineRenderer.startColor = new UnityEngine.Color() {r = val_4.theme.themeSettings.lineDragColor};
            ThemesHandler val_5 = MonoSingleton<ThemesHandler>.Instance;
            this.lineRenderer.endColor = new UnityEngine.Color() {r = val_5.theme.themeSettings.lineDragColor};
        }
        
        WordRegion val_6 = WordRegion.instance;
        val_6.onWordFound.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void LineDrawer::OnWordFound()));
    }
    private bool NearestEnabled(int letterIndex)
    {
        var val_2;
        bool val_2 = true;
        if(val_2 >= 1)
        {
                if(val_2 <= letterIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2 = val_2 + (letterIndex << );
            var val_1 = (((true + (letterIndex) << ) + 32) != 0) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    private void AllowAll()
    {
        var val_1 = 0;
        do
        {
            if(val_1 >= true)
        {
                return;
        }
        
            this.allowedPositions.set_Item(index:  0, value:  true);
            val_1 = val_1 + 1;
        }
        while(this.allowedPositions != null);
        
        throw new NullReferenceException();
    }
    public void BeginDrag()
    {
        MainController val_1 = MainController.instance;
        if(val_1.isGameComplete == true)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDragBegin");
        this.isDragging = true;
    }
    public void DoDrag(UnityEngine.Vector2 mousePos)
    {
        MainController val_1 = MainController.instance;
        if(val_1.isGameComplete == true)
        {
                return;
        }
        
        this.mousePoint = mousePos;
        mem[1152921515441720644] = mousePos.y;
        int val_2 = Pan.tappingAllowed.IsInRectofAnyTile(mousePos:  new UnityEngine.Vector2() {x = mousePos.x, y = mousePos.y});
        if((val_2 == 1) || ((this.NearestEnabled(letterIndex:  val_2)) == false))
        {
            goto label_28;
        }
        
        var val_4 = W9 - 2;
        if(val_2 < 1)
        {
            goto label_10;
        }
        
        val_4 = X10 + (val_4 << 2);
        if(((X10 + ((W9 - 2)) << 2) + 32) != val_2)
        {
            goto label_10;
        }
        
        var val_5 = W9 - 1;
        val_5 = X10 + (val_5 << 2);
        Pan.tappingAllowed.HighlightLetter(i:  (X10 + ((W9 - 1)) << 2) + 32, state:  false);
        this.currentIndexes.RemoveAt(index:  Pan.tappingAllowed - 1);
        this.textPreview.SetIndexes(indexes:  this.currentIndexes);
        goto label_15;
        label_10:
        if((this.currentIndexes.Contains(item:  val_2)) != true)
        {
                Pan.tappingAllowed.HighlightLetter(i:  val_2, state:  true);
            this.currentIndexes.Add(item:  val_2);
            this.textPreview.SetIndexes(indexes:  this.currentIndexes);
            WGAudioController val_8 = MonoSingleton<WGAudioController>.Instance;
            val_8.sound.PlayGameSpecificSound(id:  "LetterSelect", clipIndex:  this.currentIndexes - 1);
        }
        
        label_15:
        if(this.currentIndexes >= 1)
        {
                this.textPreview.SetActive(isActive:  true, useButtons:  false);
            this.textPreview.FadeIn();
        }
        else
        {
                this.textPreview.SetActive(isActive:  false, useButtons:  false);
        }
        
        label_28:
        this.BuildPoints(includeMousePoint:  true);
        if(this.currentIndexes < 2)
        {
                return;
        }
        
        if(this.isDragging == false)
        {
                return;
        }
        
        this.positions = iTween.GetSmoothPoints(points:  this.points.ToArray(), smooth:  8);
        this.lineRenderer.positionCount = 8;
        this.lineRenderer.SetPositions(positions:  this.positions.ToArray());
    }
    public void EndDrag(bool checkAnswer = True)
    {
        if(this.textPreview.IsInvisibleOrFading() != false)
        {
                return;
        }
        
        if(checkAnswer != false)
        {
                WordRegion val_2 = WordRegion.instance;
            string val_3 = this.textPreview.GetText();
        }
        else
        {
                this.textPreview.FadeOut();
        }
        
        this.isDragging = false;
        this.currentIndexes.Clear();
        this.lineRenderer.positionCount = 0;
        Pan.tappingAllowed.UnhighlightAllLetters();
    }
    public void DoPointerDown(UnityEngine.Vector2 mousePos)
    {
        System.Collections.Generic.List<System.Int32> val_9;
        MainController val_1 = MainController.instance;
        if(val_1.isGameComplete == true)
        {
                return;
        }
        
        if(this.isDragging != false)
        {
                return;
        }
        
        this.mousePoint = mousePos;
        mem[1152921515442297924] = mousePos.y;
        this.downOnIndex = 0;
        int val_2 = Pan.tappingAllowed.IsInRectofAnyTile(mousePos:  new UnityEngine.Vector2() {x = mousePos.x, y = mousePos.y});
        if((val_2 != 1) && ((this.NearestEnabled(letterIndex:  val_2)) != false))
        {
                val_9 = this.currentIndexes;
            if(W9 == 0)
        {
                Pan.tappingAllowed.HighlightLetter(i:  val_2, state:  true);
            this.currentIndexes.Add(item:  val_2);
            this.textPreview.SetIndexes(indexes:  this.currentIndexes);
            WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
            val_4.sound.PlayGameSpecificSound(id:  "LetterSelect", clipIndex:  this.currentIndexes - 1);
            val_9 = this.currentIndexes;
            this.downOnIndex = val_2;
        }
        
            if(val_9 >= 1)
        {
                this.textPreview.SetActive(isActive:  true, useButtons:  false);
            this.textPreview.FadeIn();
        }
        else
        {
                this.textPreview.SetActive(isActive:  false, useButtons:  false);
        }
        
        }
        
        this.BuildPoints(includeMousePoint:  false);
        if(val_9 < 2)
        {
                this.lineRenderer.positionCount = 0;
            return;
        }
        
        this.positions = iTween.GetSmoothPoints(points:  this.points.ToArray(), smooth:  8);
        this.lineRenderer.positionCount = 8;
        this.lineRenderer.SetPositions(positions:  this.positions.ToArray());
    }
    public void DoPointerUp(UnityEngine.Vector2 mousePos)
    {
        System.Collections.Generic.List<System.Int32> val_17;
        MainController val_1 = MainController.instance;
        if(val_1.isGameComplete == true)
        {
                return;
        }
        
        if(this.isDragging != false)
        {
                return;
        }
        
        this.mousePoint = mousePos;
        mem[1152921515442723268] = mousePos.y;
        int val_2 = Pan.tappingAllowed.IsInRectofAnyTile(mousePos:  new UnityEngine.Vector2() {x = mousePos.x, y = mousePos.y});
        if((val_2 == 1) || ((this.NearestEnabled(letterIndex:  val_2)) == false))
        {
            goto label_41;
        }
        
        val_17 = this.currentIndexes;
        if(val_2 < 1)
        {
            goto label_13;
        }
        
        var val_5 = X11 + ((W10 - 1) << 2);
        if(((X11 + ((W10 - 1)) << 2) + 32) == val_2)
        {
                if(this.downOnIndex != val_2)
        {
            goto label_12;
        }
        
        }
        
        if(W10 < 2)
        {
            goto label_13;
        }
        
        val_17 = this.currentIndexes;
        if((val_17.Contains(item:  val_2)) == false)
        {
            goto label_14;
        }
        
        int val_18 = val_2;
        int val_7 = val_17.IndexOf(item:  val_18);
        var val_17 = 0;
        label_20:
        val_17 = val_17 & 4294967295;
        if(val_17 >= val_17)
        {
            goto label_17;
        }
        
        if(val_17 >= val_17)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        Pan.tappingAllowed.HighlightLetter(i:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, state:  (val_17 <= (long)val_7) ? 1 : 0);
        val_17 = val_17 + 1;
        if(this.currentIndexes != null)
        {
            goto label_20;
        }
        
        label_12:
        val_17 = val_17 + (((long)(int)((W10 - 1))) << 2);
        Pan.tappingAllowed.HighlightLetter(i:  val_2, state:  false);
        this.currentIndexes.RemoveAt(index:  val_17 - 1);
        goto label_24;
        label_14:
        label_13:
        if((val_17.Contains(item:  val_2)) == true)
        {
            goto label_35;
        }
        
        Pan.tappingAllowed.HighlightLetter(i:  val_2, state:  true);
        this.currentIndexes.Add(item:  val_2);
        this.textPreview.SetIndexes(indexes:  this.currentIndexes);
        WGAudioController val_11 = MonoSingleton<WGAudioController>.Instance;
        val_11.sound.PlayGameSpecificSound(id:  "LetterSelect", clipIndex:  this.currentIndexes - 1);
        goto label_35;
        label_17:
        val_18 = val_7 + 1;
        this.currentIndexes.RemoveRange(index:  val_18, count:  val_17 + (~val_7));
        label_24:
        this.textPreview.SetIndexes(indexes:  this.currentIndexes);
        label_35:
        if(this.currentIndexes >= 1)
        {
                this.textPreview.SetActive(isActive:  true, useButtons:  true);
            this.textPreview.FadeIn();
        }
        else
        {
                this.textPreview.SetActive(isActive:  false, useButtons:  false);
        }
        
        label_41:
        this.BuildPoints(includeMousePoint:  false);
        if(this.currentIndexes < 2)
        {
                this.lineRenderer.positionCount = 0;
            return;
        }
        
        this.positions = iTween.GetSmoothPoints(points:  this.points.ToArray(), smooth:  8);
        this.lineRenderer.positionCount = 8;
        this.lineRenderer.SetPositions(positions:  this.positions.ToArray());
    }
    private void BuildPoints(bool includeMousePoint = True)
    {
        var val_2;
        var val_3;
        var val_9;
        var val_10;
        this.points.Clear();
        List.Enumerator<T> val_1 = this.currentIndexes.GetEnumerator();
        var val_9 = val_2;
        label_7:
        if(val_3.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(this.letterPositions == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_9 <= val_9)
        {
                val_10 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(this.points == null)
        {
                throw new NullReferenceException();
        }
        
        val_9 = val_9 + (val_9 * 12);
        this.points.Add(item:  new UnityEngine.Vector3() {x = (val_2 * 12) + val_2 + 32, y = (val_2 * 12) + val_2 + 32 + 4, z = (val_2 * 12) + val_2 + 40});
        goto label_7;
        label_3:
        val_3.Dispose();
        if(includeMousePoint == false)
        {
                return;
        }
        
        if(this.currentIndexes != 1)
        {
            goto label_10;
        }
        
        val_9 = 1152921515443039044;
        label_19:
        UnityEngine.Vector3 val_6 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = this.mousePoint.x, y = 3.482081E-29f});
        UnityEngine.Vector3 val_7 = UnityEngine.Camera.main.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        this.points.Add(item:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = 90f});
        return;
        label_10:
        if(this.points < 1)
        {
                return;
        }
        
        val_9 = 1152921515443039040;
        if((Pan.tappingAllowed.IsInRectofAnyTile(mousePos:  new UnityEngine.Vector2() {x = this.mousePoint})) == 1)
        {
            goto label_19;
        }
    
    }
    public bool IsDragging()
    {
        return (bool)this.isDragging;
    }
    public void MakeParticles()
    {
        System.Collections.Generic.List<UnityEngine.Vector3> val_1 = new System.Collections.Generic.List<UnityEngine.Vector3>();
        var val_5 = 0;
        label_7:
        if(val_5 >= 1152921509962421840)
        {
            goto label_2;
        }
        
        if(val_5 >= 44364928)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44364928 <= "Club Level")
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1.Add(item:  new UnityEngine.Vector3() {x = mem[-4611685888345778464], y = mem[-4611685888345778460], z = mem[-4611685888345778456]});
        val_5 = val_5 + 1;
        if(this.currentIndexes != null)
        {
            goto label_7;
        }
        
        label_2:
        if((UnityEngine.Object.op_Implicit(exists:  this.lineDrawerParticles)) == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_4 = this.lineDrawerParticles.StartCoroutine(routine:  this.lineDrawerParticles.PlayInSequence(selectedPositions:  val_1));
    }
    public void OnWordFound()
    {
        if(this.currentIndexes == null)
        {
                return;
        }
        
        this.MakeParticles();
    }
    public LineDrawer()
    {
        this.letterPositions = new System.Collections.Generic.List<UnityEngine.Vector3>();
        this.allowedPositions = new System.Collections.Generic.List<System.Boolean>();
        this.currentIndexes = new System.Collections.Generic.List<System.Int32>();
        this.points = new System.Collections.Generic.List<UnityEngine.Vector3>();
        this.positions = new System.Collections.Generic.List<UnityEngine.Vector3>();
        this.downOnIndex = 0;
    }

}
