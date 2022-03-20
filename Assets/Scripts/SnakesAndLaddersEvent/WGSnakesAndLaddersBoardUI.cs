using UnityEngine;

namespace SnakesAndLaddersEvent
{
    public class WGSnakesAndLaddersBoardUI : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.ScrollRect boardScrollRect;
        private System.Collections.Generic.List<UnityEngine.Transform> boards;
        private UnityEngine.GameObject boardSpacePrefab;
        private UnityEngine.GameObject pawnPrefab;
        private float pawnMoveDurationInSec;
        private SnakesAndLaddersEvent.Board currentBoard;
        private UnityEngine.GameObject pawn;
        private UnityEngine.Transform board;
        private System.Collections.Generic.List<float> scrollPositions;
        private FrameSkipper frameSkipper;
        
        // Methods
        private void Awake()
        {
            this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        }
        private void OnEnable()
        {
            this.UpdateBoard(forceUpdateBoard:  0);
        }
        public SnakesAndLaddersBoardSpace GetBoardSpace(int num)
        {
            .num = num;
            return System.Linq.Enumerable.ToList<SnakesAndLaddersBoardSpace>(source:  this.board.GetComponentsInChildren<SnakesAndLaddersBoardSpace>()).Find(match:  new System.Predicate<SnakesAndLaddersBoardSpace>(object:  new WGSnakesAndLaddersBoardUI.<>c__DisplayClass12_0(), method:  System.Boolean WGSnakesAndLaddersBoardUI.<>c__DisplayClass12_0::<GetBoardSpace>b__0(SnakesAndLaddersBoardSpace x)));
        }
        public void UpdateBoard(SnakesAndLaddersEvent.Board forceUpdateBoard)
        {
            var val_5;
            var val_6;
            System.Collections.Generic.List<UnityEngine.Transform> val_22;
            SnakesAndLaddersEvent.Board val_23;
            var val_24;
            var val_25;
            UnityEngine.Transform val_26;
            var val_27;
            val_23 = forceUpdateBoard;
            if(this.currentBoard != null)
            {
                    if(this.currentBoard.IsFinished() == false)
            {
                    return;
            }
            
            }
            
            if(val_23 != null)
            {
                    this.currentBoard = val_23;
            }
            else
            {
                    if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
            {
                    throw new NullReferenceException();
            }
            
                SnakesAndLaddersEvent.Board val_2 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetCurrentBoard();
                val_23 = val_2;
                this.currentBoard = val_2;
                if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            val_22 = this.boards;
            int val_3 = val_23.GetIndex();
            if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            this.board = (SnakesAndLaddersEventHandler.__il2cppRuntimeField_static_fields + (val_3) << 3) + 32;
            if(this.boards == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_4 = this.boards.GetEnumerator();
            val_24 = 1152921518013924256;
            label_17:
            val_25 = public System.Boolean List.Enumerator<UnityEngine.Transform>::MoveNext();
            if(val_6.MoveNext() == false)
            {
                goto label_11;
            }
            
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_25 = 0;
            val_26 = this.board;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object val_24 = val_26.gameObject;
            val_24 = UnityEngine.Object.op_Equality(x:  val_5.gameObject, y:  val_24);
            val_5.gameObject.SetActive(value:  val_24);
            goto label_17;
            label_11:
            val_6.Dispose();
            if(this.board == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.boardScrollRect == null)
            {
                    throw new NullReferenceException();
            }
            
            this.boardScrollRect.m_Content = this.board.GetComponent<UnityEngine.RectTransform>();
            this.SetupScrollPositions();
            MethodExtensionForMonoBehaviourTransform.DestroyChildrenImmediate(t:  this.board);
            if(this.currentBoard == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_27 = 0;
            var val_28 = 1;
            label_35:
            if(this.currentBoard.Definition == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_25 = this.currentBoard.Definition.MaxSpaceCount;
            val_25 = val_25 * 715827883;
            val_25 = val_25 >> 32;
            val_25 = val_25 + (val_25 >> 63);
            if(val_27 >= val_25)
            {
                goto label_22;
            }
            
            if(this.currentBoard == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_14 = val_27 + 0;
            val_27 = 4;
            val_14 = val_14 << 1;
            val_24 = 0;
            SnakesAndLaddersEvent.BoardSpace val_16 = ((val_27 & 1) != 0) ? (val_14) : (val_14 + 5);
            label_33:
            SnakesAndLaddersEvent.BoardDefinition val_26 = this.currentBoard.Definition;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_22 = this.currentBoard.Definition.BoardSpaces;
            if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_26 <= val_16)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(this.board == null)
            {
                    throw new NullReferenceException();
            }
            
            val_22 = this.boardSpacePrefab;
            val_26 = val_26 + (val_16 << 3);
            UnityEngine.GameObject val_18 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_22, parent:  this.board.transform);
            if(val_18 == null)
            {
                    throw new NullReferenceException();
            }
            
            SnakesAndLaddersBoardSpace val_19 = val_18.GetComponent<SnakesAndLaddersBoardSpace>();
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19.Setup(numberSpace:  val_16);
            if(val_24 > 4)
            {
                goto label_32;
            }
            
            val_24 = val_24 + 1;
            var val_21 = ((val_27 & 1) != 0) ? (val_28 + val_24) : (val_27);
            val_27 = val_27 - 1;
            if(this.currentBoard != null)
            {
                goto label_33;
            }
            
            throw new NullReferenceException();
            label_32:
            var val_29 = 4;
            val_27 = val_27 + 1;
            val_28 = val_28 + 6;
            val_29 = val_29 + 6;
            if(this.currentBoard != null)
            {
                goto label_35;
            }
            
            throw new NullReferenceException();
            label_22:
            UnityEngine.Coroutine val_23 = this.StartCoroutine(routine:  this.ShowTargetArea());
        }
        public void MovePawn(int start, int end, int final, System.Action onPawnLanded)
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.MovePawnAndScrollCoroutine(start:  start, end:  end, final:  final, onPawnLanded:  onPawnLanded));
        }
        private void SetupScrollPositions()
        {
            var val_6;
            this.scrollPositions = new System.Collections.Generic.List<System.Single>();
            int val_2 = this.currentBoard.Definition.GetRows();
            float val_7 = (float)val_2;
            float val_3 = 1f / val_7;
            val_7 = val_3 * 0.7f;
            this.scrollPositions.Add(item:  val_7);
            if(val_2 < 2)
            {
                goto label_4;
            }
            
            var val_9 = 2;
            label_13:
            if(val_2 != val_9)
            {
                goto label_5;
            }
            
            if(this.currentBoard.GetIndex() != 3)
            {
                    if(this.currentBoard.GetIndex() != 4)
            {
                goto label_9;
            }
            
            }
            
            label_9:
            val_6 = public System.Void System.Collections.Generic.List<System.Single>::Add(System.Single item);
            goto label_11;
            label_5:
            val_6 = public System.Void System.Collections.Generic.List<System.Single>::Add(System.Single item);
            float val_8 = (float)val_9 - 1;
            val_8 = val_3 * val_8;
            label_11:
            this.scrollPositions.Add(item:  val_8);
            val_9 = val_9 + 1;
            if(val_9 < val_2)
            {
                goto label_13;
            }
            
            label_4:
            this.scrollPositions.Add(item:  1f);
        }
        private System.Collections.IEnumerator ShowTargetArea()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WGSnakesAndLaddersBoardUI.<ShowTargetArea>d__16();
        }
        private void SpawnPawn(int num)
        {
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.pawnPrefab, parent:  this.boardScrollRect.transform);
            this.pawn = val_2;
            val_2.transform.parent = this.GetBoardSpace(num:  num).transform;
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
            this.pawn.transform.localPosition = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        }
        private int GetRowIndex(int spaceNum)
        {
            int val_1 = spaceNum - 1;
            val_1 = val_1 >> 32;
            return (int)val_1 + (val_1 >> 63);
        }
        private bool IsDifferentRow(int num1, int num2)
        {
            int val_1 = num1 - 1;
            int val_2 = num2 - 1;
            val_1 = val_1 >> 32;
            val_1 = val_1 + (val_1 >> 63);
            return (bool)(val_1 != 0) ? 1 : 0;
        }
        private System.Collections.IEnumerator ScrollToPosition(int startSpace, int endSpace)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .startSpace = startSpace;
            .endSpace = endSpace;
            return (System.Collections.IEnumerator)new WGSnakesAndLaddersBoardUI.<ScrollToPosition>d__20();
        }
        private void StartScrolling(bool fromBottomToTop, float targetScrollPosition, float interpolation)
        {
            float val_7;
            float val_7 = interpolation;
            val_7 = this.boardScrollRect.verticalNormalizedPosition + val_7;
            if(fromBottomToTop == false)
            {
                goto label_2;
            }
            
            val_7 = val_7;
            float val_2 = UnityEngine.Mathf.Min(a:  val_7, b:  targetScrollPosition);
            if(this.boardScrollRect != null)
            {
                goto label_5;
            }
            
            label_2:
            val_7 = val_7;
            label_5:
            this.boardScrollRect.verticalNormalizedPosition = UnityEngine.Mathf.Max(a:  val_7, b:  targetScrollPosition);
            if(this.boardScrollRect.verticalNormalizedPosition > 0f)
            {
                    if(this.boardScrollRect.verticalNormalizedPosition < 1f)
            {
                    if(this.boardScrollRect.verticalNormalizedPosition != targetScrollPosition)
            {
                    return;
            }
            
            }
            
            }
            
            this.frameSkipper.updateLogic = 0;
        }
        private void SnapToPosition(int spaceNum)
        {
            int val_3 = spaceNum;
            int val_1 = val_3 - 1;
            val_1 = val_1 >> 32;
            val_3 = val_1 + (val_1 >> 63);
            if(W10 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + (val_3 << 2);
            this.boardScrollRect.verticalNormalizedPosition = (((spaceNum - 1) >> 32) + ((((spaceNum - 1) >> 32) + ((spaceNum - 1) >> 63))) << 2) + 32;
        }
        private void SetPawnOnTop()
        {
            this.pawn.transform.parent = this.transform;
        }
        private System.Collections.IEnumerator MovePawnAndScrollCoroutine(int start, int end, int final, System.Action onPawnLanded)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .start = start;
            .end = end;
            .final = final;
            .onPawnLanded = onPawnLanded;
            return (System.Collections.IEnumerator)new WGSnakesAndLaddersBoardUI.<MovePawnAndScrollCoroutine>d__24();
        }
        public WGSnakesAndLaddersBoardUI()
        {
            this.pawnMoveDurationInSec = 0.5f;
        }
    
    }

}
