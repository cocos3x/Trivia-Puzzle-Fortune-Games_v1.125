using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonGrid : MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
    {
        // Fields
        private const int MINIMUM_LENGTH_PER_WORD = 2;
        private string flyoutMessageNoMovesLeft;
        private string flyoutMessageWrongWordSubmitted;
        private UnityEngine.GameObject gridColumnPrefab;
        private UnityEngine.GameObject letterSlotPrefab;
        private UnityEngine.GameObject letterTilePrefab;
        private UnityEngine.GameObject letterSlotGridParent;
        private UnityEngine.GameObject letterTileParent;
        private System.Collections.Generic.Dictionary<int, UnityEngine.UI.VerticalLayoutGroup> gridColumnCollection;
        private System.Collections.Generic.Dictionary<int, SLC.Minigames.WordBalloon.WordBalloonLetterSlot> letterSlotCollection;
        private int initialColumnCount;
        private System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> currentInputQueue;
        private bool isInputModeOn;
        public System.Action OnGridChanged;
        public System.Action<bool, string> OnWordProcessed;
        
        // Properties
        public System.Collections.Generic.Dictionary<int, SLC.Minigames.WordBalloon.WordBalloonLetterSlot> LetterSlots { get; }
        public bool IsInputModeOn { get; }
        
        // Methods
        public System.Collections.Generic.Dictionary<int, SLC.Minigames.WordBalloon.WordBalloonLetterSlot> get_LetterSlots()
        {
            return (System.Collections.Generic.Dictionary<System.Int32, SLC.Minigames.WordBalloon.WordBalloonLetterSlot>)this.letterSlotCollection;
        }
        public bool get_IsInputModeOn()
        {
            return (bool)this.isInputModeOn;
        }
        private SLC.Minigames.WordBalloon.WordBalloonLetterSlot GetSlotFromUid(int id)
        {
            UnityEngine.Object val_5;
            var val_6;
            if((this.letterSlotCollection.ContainsKey(key:  id)) != false)
            {
                    val_5 = this.letterSlotCollection.Item[id];
                val_6 = 0;
                if(val_5 == 0)
            {
                    return (SLC.Minigames.WordBalloon.WordBalloonLetterSlot)val_6;
            }
            
                SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_4 = this.letterSlotCollection.Item[id];
                return (SLC.Minigames.WordBalloon.WordBalloonLetterSlot)val_6;
            }
            
            val_6 = 0;
            return (SLC.Minigames.WordBalloon.WordBalloonLetterSlot)val_6;
        }
        private SLC.Minigames.WordBalloon.WordBalloonLetterSlot GetSlotFromLetterValue(string letter)
        {
            var val_3;
            var val_4;
            string val_9;
            var val_10;
            var val_11;
            var val_12;
            var val_13;
            val_10 = letter;
            Dictionary.Enumerator<TKey, TValue> val_1 = this.letterSlotCollection.GetEnumerator();
            label_7:
            val_11 = public System.Boolean Dictionary.Enumerator<System.Int32, SLC.Minigames.WordBalloon.WordBalloonLetterSlot>::MoveNext();
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_13 = val_3;
            if(val_13 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_3 + 72) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_12 = mem[val_3 + 72 + 40];
            val_12 = val_3 + 72 + 40;
            if(val_12 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_11 = 0;
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = val_12.ToLowerInvariant();
            if((System.String.op_Equality(a:  val_9, b:  val_10.ToLowerInvariant())) == false)
            {
                goto label_7;
            }
            
            goto label_8;
            label_2:
            val_13 = 0;
            label_8:
            val_4.Dispose();
            return (SLC.Minigames.WordBalloon.WordBalloonLetterSlot)val_13;
        }
        private bool SlotHasLetterValue(SLC.Minigames.WordBalloon.WordBalloonLetterSlot comparisonSlot, string value)
        {
            if(comparisonSlot == 0)
            {
                    return false;
            }
            
            if(comparisonSlot.HasLetterTile == false)
            {
                    return false;
            }
            
            return System.String.op_Equality(a:  comparisonSlot.letterTile.value.ToLowerInvariant(), b:  value.ToLowerInvariant());
        }
        public void HighlightSlots(System.Collections.Generic.List<int> slotsToUse)
        {
            bool val_2 = true;
            if(val_2 < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            do
            {
                if(val_3 >= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2 = val_2 + 0;
                SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_1 = this.GetSlotFromUid(id:  (true + 0) + 32);
                val_1.letterTile.Highlight();
                val_3 = val_3 + 1;
            }
            while(val_3 < val_2);
        
        }
        public System.Collections.Generic.List<int> GetSolvableSlotSequence()
        {
            var val_22;
            System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordSolutionData> val_23;
            var val_24;
            var val_25;
            var val_26;
            SLC.Minigames.WordBalloon.LetterSlotLink val_27;
            var val_28;
            var val_29;
            SLC.Minigames.WordBalloon.WordBalloonManager val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if((val_1.<RemainingWords>k__BackingField) < 1)
            {
                goto label_5;
            }
            
            val_22 = 0;
            goto label_6;
            label_70:
            SLC.Minigames.WordBalloon.WordBalloonManager val_2 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            SLC.Minigames.WordBalloon.WordBalloonManager val_3 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            val_23 = val_3.<CurrentLevelData>k__BackingField.gridSolutionData;
            if((val_3.<CurrentLevelData>k__BackingField) <= val_22)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((val_2.<RemainingWords>k__BackingField.Contains(item:  SLC.Minigames.WordBalloon.WordBalloonLevelData.__il2cppRuntimeField_byval_arg + 16)) == false)
            {
                goto label_62;
            }
            
            SLC.Minigames.WordBalloon.WordBalloonManager val_5 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            val_23 = 0;
            if((val_5.<CurrentLevelData>k__BackingField) <= val_22)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_24 = mem[SLC.Minigames.WordBalloon.WordBalloonLevelData.__il2cppRuntimeField_byval_arg + 24];
            val_24 = SLC.Minigames.WordBalloon.WordBalloonLevelData.__il2cppRuntimeField_byval_arg + 24;
            val_25 = 0;
            val_26 = 4294967296;
            label_64:
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_25 = val_25 + 1;
            val_23 = this.GetSlotFromUid(id:  (SLC.Minigames.WordBalloon.WordBalloonLevelData.__il2cppRuntimeField_byval_arg + 24 + 16 + 0) + 32);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((val_23 == 0) || ((this.GetSlotFromUid(id:  (SLC.Minigames.WordBalloon.WordBalloonLevelData.__il2cppRuntimeField_byval_arg + 24 + 16 + 4) + 32)) == 0))
            {
                goto label_62;
            }
            
            val_27 = val_7.SlotLink;
            if((val_27 == 0) || (val_7.SlotLink.below != (val_8.<Uid>k__BackingField)))
            {
                goto label_40;
            }
            
            val_28 = 1152921510009150240;
            val_29 = 0;
            goto label_55;
            label_40:
            if(val_27 == 0)
            {
                goto label_47;
            }
            
            val_28 = 1152921510009150240;
            val_29 = 1;
            goto label_55;
            label_47:
            if(val_27 == 0)
            {
                goto label_54;
            }
            
            val_28 = 1152921510009150240;
            val_29 = 2;
            goto label_55;
            label_54:
            if(val_27 == 0)
            {
                goto label_61;
            }
            
            val_28 = 1152921510009150240;
            System.Nullable<System.Int32> val_15;
            val_29 = -2;
            label_55:
            val_15 = new System.Nullable<System.Int32>(value:  -2);
            label_61:
            if(0 == 0)
            {
                goto label_62;
            }
            
            if(0 == 0)
            {
                    System.Nullable<System.Int32> val_17 = new System.Nullable<System.Int32>(value:  val_15.HasValue.Value);
            }
            
            val_23 = val_17.HasValue.Value;
            val_26 = val_26 + 4294967296;
            if(val_23 == val_15.HasValue.Value)
            {
                goto label_64;
            }
            
            label_62:
            val_22 = 1;
            label_6:
            SLC.Minigames.WordBalloon.WordBalloonManager val_20 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if(val_22 < (val_20.<CurrentLevelData>k__BackingField.gridSolutionData))
            {
                goto label_70;
            }
            
            val_24 = this.GetSolvableSlotSequenceByScanningGrid();
            return (System.Collections.Generic.List<System.Int32>)val_24;
            label_5:
            val_24 = 0;
            return (System.Collections.Generic.List<System.Int32>)val_24;
        }
        private System.Collections.Generic.List<int> GetSolvableSlotSequenceByScanningGrid()
        {
            var val_7;
            SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_8;
            var val_23;
            var val_24;
            string val_25;
            var val_26;
            var val_27;
            SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_28;
            var val_29;
            var val_30;
            var val_31;
            val_23 = 1152921504893161472;
            SLC.Minigames.WordBalloon.WordBalloonManager val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if((val_1.<RemainingWords>k__BackingField) < 1)
            {
                goto label_10;
            }
            
            val_24 = 1152921504687730688;
            val_25 = 1152921510062986752;
            val_26 = 0;
            label_46:
            SLC.Minigames.WordBalloon.WordBalloonManager val_2 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if(val_26 >= (val_2.<RemainingWords>k__BackingField))
            {
                goto label_10;
            }
            
            SLC.Minigames.WordBalloon.WordBalloonManager val_3 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> val_4 = new System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>();
            Dictionary.Enumerator<TKey, TValue> val_5 = mem[1152921519851118296].GetEnumerator();
            label_26:
            if(val_7.MoveNext() == false)
            {
                goto label_17;
            }
            
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_8.HasLetterTile == false)
            {
                goto label_26;
            }
            
            if((val_8 + 72) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_8 + 72 + 40) == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_13 = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32.Chars[0].ToString();
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  val_8 + 72 + 40.ToLowerInvariant(), b:  val_13.ToLowerInvariant())) == false)
            {
                goto label_26;
            }
            
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_4.Add(item:  val_8);
            goto label_26;
            label_17:
            val_27 = 1;
            val_7.Dispose();
            if(val_27 != 1)
            {
                    var val_22 = 0;
                val_22 = val_22 ^ 0;
                val_27 = val_27 + val_22;
            }
            
            if(val_22 < 1)
            {
                goto label_29;
            }
            
            val_23 = 0;
            label_45:
            if(val_22 <= val_23)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_22 = val_22 + 0;
            val_28 = mem[((0 ^ 0) + 0) + 32 + 48];
            val_28 = ((0 ^ 0) + 0) + 32 + 48;
            System.Collections.Generic.List<System.Int32> val_16 = null;
            val_29 = val_16;
            val_16 = new System.Collections.Generic.List<System.Int32>();
            val_16.Add(item:  ((0 ^ 0) + 0) + 32 + 24);
            System.Collections.Generic.List<System.Int32> val_17 = null;
            val_24 = val_17;
            val_17 = new System.Collections.Generic.List<System.Int32>();
            val_26 = 1152921510479955696;
            val_17.Add(item:  ((0 ^ 0) + 0) + 32 + 24);
            val_30 = mem[(MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16];
            val_30 = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16;
            if(val_30 >= 2)
            {
                    var val_23 = 1;
                do
            {
                string val_19 = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32.Chars[1].ToString();
                val_25 = val_19;
                if(val_23 == val_30)
            {
                    if((val_19.SlotHasLetterValue(comparisonSlot:  val_28, value:  val_25)) != false)
            {
                    val_31 = val_29;
                val_16.Add(item:  ((0 ^ 0) + 0) + 32 + 48 + 24);
                val_28 = mem[((0 ^ 0) + 0) + 32 + 48 + 48];
                val_28 = ((0 ^ 0) + 0) + 32 + 48 + 48;
            }
            
            }
            
                if(val_23 == val_30)
            {
                    if((val_16.SlotHasLetterValue(comparisonSlot:  ((0 ^ 0) + 0) + 32 + 64, value:  val_25)) != false)
            {
                    val_17.Add(item:  ((0 ^ 0) + 0) + 32 + 64 + 24);
            }
            
            }
            
                val_30 = mem[(MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16];
                val_30 = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16;
                val_23 = val_23 + 1;
            }
            while(val_23 < val_30);
            
            }
            
            if(W9 == val_30)
            {
                    return (System.Collections.Generic.List<System.Int32>)val_29;
            }
            
            if(W9 == val_30)
            {
                goto label_44;
            }
            
            val_23 = val_23 + 1;
            if(val_23 < mem[1152921519851174808])
            {
                goto label_45;
            }
            
            label_29:
            var val_24 = val_26;
            val_24 = val_24 + 1;
            goto label_46;
            label_10:
            val_29 = 0;
            return (System.Collections.Generic.List<System.Int32>)val_29;
            label_44:
            val_29 = val_24;
            return (System.Collections.Generic.List<System.Int32>)val_29;
        }
        private bool CheckSlotsLinkedInDirection(SLC.Minigames.WordBalloon.WordBalloonLetterSlot originSlot, SLC.Minigames.WordBalloon.WordBalloonLetterSlot destinationSlot, SLC.Minigames.WordBalloon.SlotDirection directionToCheck, out System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> slotsInPath)
        {
            SLC.Minigames.WordBalloon.LetterSlotLink val_3;
            var val_4;
            SLC.Minigames.WordBalloon.SlotDirection val_3 = directionToCheck;
            System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> val_1 = new System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>();
            val_3 = val_3 - 1;
            if(val_3 > 3)
            {
                goto label_2;
            }
            
            var val_4 = 32555644;
            val_4 = (32555644 + ((directionToCheck - 1)) << 2) + val_4;
            goto (32555644 + ((directionToCheck - 1)) << 2 + 32555644);
            label_2:
            val_3 = 0;
            label_14:
            if(val_3 == 0)
            {
                goto label_9;
            }
            
            if(9733424 == (destinationSlot.<Uid>k__BackingField))
            {
                goto label_12;
            }
            
            val_1.Add(item:  val_3);
            if(val_3 > 3)
            {
                goto label_14;
            }
            
            var val_5 = 32555660 + ((directionToCheck - 1)) << 2;
            val_5 = val_5 + 32555660;
            goto (32555660 + ((directionToCheck - 1)) << 2 + 32555660);
            label_9:
            val_4 = 0;
            goto label_19;
            label_12:
            val_4 = 1;
            label_19:
            slotsInPath = val_1;
            return (bool)val_4;
        }
        public void RegisterSlotForInput(SLC.Minigames.WordBalloon.WordBalloonLetterSlot incomingSlot)
        {
            SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_10;
            System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> val_11;
            var val_12;
            SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_13;
            var val_14;
            val_10 = incomingSlot;
            .incomingSlot = val_10;
            val_11 = this.currentInputQueue;
            if(1152921505032671232 <= 0)
            {
                goto label_3;
            }
            
            if((val_11.Contains(item:  val_10)) == false)
            {
                goto label_4;
            }
            
            int val_4 = this.currentInputQueue.FindIndex(match:  new System.Predicate<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>(object:  new WordBalloonGrid.<>c__DisplayClass26_0(), method:  System.Boolean WordBalloonGrid.<>c__DisplayClass26_0::<RegisterSlotForInput>b__0(SLC.Minigames.WordBalloon.WordBalloonLetterSlot obj)));
            val_10 = 44457055;
            if(val_10 <= val_4)
            {
                    return;
            }
            
            val_12 = 1152921519851440960;
            do
            {
                if(1152921519851435840 <= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                1152921519851435840.__il2cppRuntimeField_2A65C80 + 72.ChangeState(incomingState:  0);
                this.currentInputQueue.RemoveAt(index:  44457055);
                val_10 = 44457054;
                if(val_10 <= val_4)
            {
                    return;
            }
            
            }
            while(this.currentInputQueue != null);
            
            label_3:
            val_13 = val_10;
            val_14 = public System.Void System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>::Add(SLC.Minigames.WordBalloon.WordBalloonLetterSlot item);
            goto label_15;
            label_4:
            if((public System.Boolean System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>::Contains(SLC.Minigames.WordBalloon.WordBalloonLetterSlot item)) == 0)
            {
                    val_11 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_10 = "Loading minigame index: {0}";
            System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> val_5 = 0;
            bool val_6 = this.CheckSlotsLinkedInDirection(originSlot:  val_10, destinationSlot:  (WordBalloonGrid.<>c__DisplayClass26_0)[1152921519851560448].incomingSlot, directionToCheck:  2, slotsInPath: out  val_5);
            if(val_6 != true)
            {
                    bool val_7 = val_6.CheckSlotsLinkedInDirection(originSlot:  val_10, destinationSlot:  (WordBalloonGrid.<>c__DisplayClass26_0)[1152921519851560448].incomingSlot, directionToCheck:  1, slotsInPath: out  val_5);
                if(val_7 != true)
            {
                    bool val_8 = val_7.CheckSlotsLinkedInDirection(originSlot:  val_10, destinationSlot:  (WordBalloonGrid.<>c__DisplayClass26_0)[1152921519851560448].incomingSlot, directionToCheck:  4, slotsInPath: out  val_5);
                if(val_8 != true)
            {
                    if((val_8.CheckSlotsLinkedInDirection(originSlot:  val_10, destinationSlot:  (WordBalloonGrid.<>c__DisplayClass26_0)[1152921519851560448].incomingSlot, directionToCheck:  3, slotsInPath: out  val_5)) == false)
            {
                    return;
            }
            
            }
            
            }
            
            }
            
            var val_12 = 0;
            label_27:
            if(val_12 >= 1152921519851424576)
            {
                goto label_23;
            }
            
            if(1152921519851424576 <= val_12)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            "Loading minigame index: {0}".__il2cppRuntimeField_48.ChangeState(incomingState:  0);
            val_12 = val_12 + 1;
            if(this.currentInputQueue != null)
            {
                goto label_27;
            }
            
            label_23:
            this.currentInputQueue.Clear();
            this.currentInputQueue.Add(item:  val_10);
            "Loading minigame index: {0}".__il2cppRuntimeField_48.ChangeState(incomingState:  1);
            val_12 = val_5;
            if((val_12 != 0) && (9733424 >= 1))
            {
                    var val_13 = 4;
                do
            {
                val_10 = this.currentInputQueue;
                var val_10 = val_13 - 4;
                if(9733424 <= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_10.Add(item:  mem[4306960419]);
                if(9733424 <= val_10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                mem[4306960419] + 72.ChangeState(incomingState:  1);
                val_13 = val_13 + 1;
            }
            while((val_13 - 4) < 9733424);
            
            }
            
            val_13 = (WordBalloonGrid.<>c__DisplayClass26_0)[1152921519851560448].incomingSlot;
            val_14 = public System.Void System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>::Add(SLC.Minigames.WordBalloon.WordBalloonLetterSlot item);
            label_15:
            this.currentInputQueue.Add(item:  val_13);
            (WordBalloonGrid.<>c__DisplayClass26_0)[1152921519851560448].incomingSlot.letterTile.ChangeState(incomingState:  1);
        }
        private void ResolveInput()
        {
            int val_16;
            if(W9 < 2)
            {
                goto label_62;
            }
            
            var val_1 = W9 - 1;
            if((X10 + 32 + 28) != (X10 + 32 + ((W9 - 1)) << 3 + 28))
            {
                goto label_5;
            }
            
            var val_16 = X10 + 32 + 32;
            val_16 = System.String.alignConst;
            if(val_16 > (X10 + 32 + ((W9 - 1)) << 3 + 32))
            {
                goto label_6;
            }
            
            label_14:
            var val_17 = 0;
            label_12:
            if(val_17 >= val_16)
            {
                goto label_20;
            }
            
            if(val_16 <= val_17)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_16 = val_16 + 0;
            string val_2 = val_16 + (X10 + 32 + 32 + 0) + 32 + 72 + 40((X10 + 32 + 32 + 0) + 32 + 72 + 40);
            val_17 = val_17 + 1;
            if(this.currentInputQueue != null)
            {
                goto label_12;
            }
            
            label_5:
            val_16 = System.String.alignConst;
            if((X10 + 32 + ((W9 - 1)) << 3 + 28) >= (X10 + 32 + 28))
            {
                goto label_14;
            }
            
            label_6:
            if((X10 + 32 + ((W9 - 1)) << 3 + 28) >= 0)
            {
                    label_21:
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_16 = val_16 + System.String.alignConst.__il2cppRuntimeField_EAE020 + 72 + 40(System.String.alignConst.__il2cppRuntimeField_EAE020 + 72 + 40);
                if((1152921504622239742 & 2147483648) == 0)
            {
                    if(this.currentInputQueue != null)
            {
                goto label_21;
            }
            
            }
            
            }
            
            label_20:
            if((MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance.IsWordRequired(submittedWord:  val_16)) != false)
            {
                    if((MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance.HasWordBeenSubmitted(submittedWord:  val_16)) == false)
            {
                goto label_30;
            }
            
            }
            
            if(this.OnWordProcessed != null)
            {
                    this.OnWordProcessed.Invoke(arg1:  false, arg2:  val_16);
            }
            
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonUIController>.Instance.ShowFlyoutStatus(message:  System.String.Format(format:  this.flyoutMessageWrongWordSubmitted, arg0:  val_16));
            label_62:
            var val_18 = 0;
            label_40:
            if(val_18 >= this.flyoutMessageWrongWordSubmitted)
            {
                goto label_36;
            }
            
            if(this.flyoutMessageWrongWordSubmitted <= val_18)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            System.String.__il2cppRuntimeField_byval_arg + 72.ChangeState(incomingState:  0);
            val_18 = val_18 + 1;
            if(this.currentInputQueue != null)
            {
                goto label_40;
            }
            
            label_36:
            this.currentInputQueue.Clear();
            return;
            label_30:
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance.MarkWordAsFound(submittedWord:  val_16);
            this.RemoveSlotsFromGrid(slotsToRemove:  this.currentInputQueue);
            if(this.OnWordProcessed != null)
            {
                    this.OnWordProcessed.Invoke(arg1:  true, arg2:  val_16);
            }
            
            SLC.Minigames.WordBalloon.WordBalloonManager val_11 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if((val_11.<RemainingWords>k__BackingField) <= 0)
            {
                goto label_50;
            }
            
            if(this.GetSolvableSlotSequence() != null)
            {
                goto label_62;
            }
            
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonUIController>.Instance.ShowFlyoutStatus(message:  this.flyoutMessageNoMovesLeft);
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance.EndGame();
            goto label_62;
            label_50:
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance.CompleteLevel();
            goto label_62;
        }
        private void RemoveSlotsFromGrid(System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> slotsToRemove)
        {
            UnityEngine.Object val_30;
            var val_31;
            System.Comparison<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> val_33;
            var val_34;
            UnityEngine.Object val_35;
            UnityEngine.Object val_36;
            UnityEngine.Object val_37;
            UnityEngine.Object val_38;
            UnityEngine.Object val_39;
            val_30 = 1152921505032724480;
            val_31 = null;
            val_31 = null;
            val_33 = WordBalloonGrid.<>c.<>9__28_0;
            if(val_33 == null)
            {
                    System.Comparison<SLC.Minigames.WordBalloon.WordBalloonLetterSlot> val_1 = null;
                val_33 = val_1;
                val_1 = new System.Comparison<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>(object:  WordBalloonGrid.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordBalloonGrid.<>c::<RemoveSlotsFromGrid>b__28_0(SLC.Minigames.WordBalloon.WordBalloonLetterSlot obj1, SLC.Minigames.WordBalloon.WordBalloonLetterSlot obj2));
                WordBalloonGrid.<>c.<>9__28_0 = val_33;
            }
            
            slotsToRemove.Sort(comparison:  val_1);
            if(1152921510062986752 >= 1)
            {
                    var val_33 = 0;
                if(1152921510062986752 <= val_33)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(("java.lang.Short".__il2cppRuntimeField_38 == 0) && ("java.lang.Short".__il2cppRuntimeField_40 == 0))
            {
                    do
            {
                if("java.lang.Short".__il2cppRuntimeField_28 != 0)
            {
                    mem2[0] = "java.lang.Short".__il2cppRuntimeField_30;
            }
            
                if("java.lang.Short".__il2cppRuntimeField_30 != 0)
            {
                    mem2[0] = "java.lang.Short".__il2cppRuntimeField_28;
            }
            
                val_35 = 0;
                if("java.lang.Short".__il2cppRuntimeField_28 != 0)
            {
                    val_35 = mem["java.lang.Short".__il2cppRuntimeField_28 + 64];
                val_35 = "java.lang.Short".__il2cppRuntimeField_28 + 64;
            }
            
                val_36 = 0;
                if("java.lang.Short".__il2cppRuntimeField_30 != 0)
            {
                    val_36 = mem["java.lang.Short".__il2cppRuntimeField_30 + 64];
                val_36 = "java.lang.Short".__il2cppRuntimeField_30 + 64;
            }
            
                val_30 = val_36;
            }
            while((val_35 != 0) || (val_30 != 0));
            
                new System.Collections.Generic.List<System.Int32>().Add(item:  "java.lang.Short".__il2cppRuntimeField_18 - (("java.lang.Short".__il2cppRuntimeField_18 / this.initialColumnCount) * this.initialColumnCount)>>0&0xFFFFFFFF);
            }
            else
            {
                    if("java.lang.Short".__il2cppRuntimeField_40 != 0)
            {
                    mem2[0] = "java.lang.Short".__il2cppRuntimeField_38;
            }
            
                if("java.lang.Short".__il2cppRuntimeField_38 != 0)
            {
                    mem2[0] = "java.lang.Short".__il2cppRuntimeField_40;
            }
            
                do
            {
                if("java.lang.Short".__il2cppRuntimeField_40 != 0)
            {
                    mem2[0] = "java.lang.Short".__il2cppRuntimeField_28;
                mem2[0] = "java.lang.Short".__il2cppRuntimeField_30;
                mem2[0] = ("java.lang.Short".__il2cppRuntimeField_40 + 32 - 1);
            }
            
                if("java.lang.Short".__il2cppRuntimeField_28 != 0)
            {
                    mem2[0] = "java.lang.Short".__il2cppRuntimeField_40;
            }
            
                if("java.lang.Short".__il2cppRuntimeField_30 != 0)
            {
                    mem2[0] = "java.lang.Short".__il2cppRuntimeField_40;
            }
            
                val_37 = 0;
                if("java.lang.Short".__il2cppRuntimeField_40 != 0)
            {
                    val_37 = mem["java.lang.Short".__il2cppRuntimeField_40 + 64];
                val_37 = "java.lang.Short".__il2cppRuntimeField_40 + 64;
            }
            
                val_38 = 0;
                if("java.lang.Short".__il2cppRuntimeField_28 != 0)
            {
                    val_38 = mem["java.lang.Short".__il2cppRuntimeField_28 + 64];
                val_38 = "java.lang.Short".__il2cppRuntimeField_28 + 64;
            }
            
                val_39 = 0;
                if("java.lang.Short".__il2cppRuntimeField_30 != 0)
            {
                    val_39 = mem["java.lang.Short".__il2cppRuntimeField_30 + 64];
                val_39 = "java.lang.Short".__il2cppRuntimeField_30 + 64;
            }
            
                val_30 = val_39;
            }
            while(((val_38 != 0) || (val_30 != 0)) || (val_37 != 0));
            
            }
            
                val_33 = val_33 + 1;
                do
            {
                val_34 = 4 - 4;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                bool val_24 = this.letterSlotCollection.Remove(key:  UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32 + 24);
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                UnityEngine.Object.Destroy(obj:  UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32 + 32 + 72.gameObject);
                if(null <= val_34)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                UnityEngine.Object.Destroy(obj:  UnityEngine.Object.__il2cppRuntimeField_byval_arg.gameObject);
                val_30 = 4 + 1;
            }
            while((val_30 - 4) < null);
            
            }
            
            if(null >= 1)
            {
                    val_30 = 1152921519852040768;
                val_34 = 1152921519852041792;
                var val_34 = 8;
                do
            {
                var val_28 = val_34 - 8;
                if(val_28 >= null)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                UnityEngine.Object.Destroy(obj:  this.gridColumnCollection.Item[UnityEngine.Object.__il2cppRuntimeField_byval_arg].gameObject);
                if(val_28 >= null)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                bool val_31 = this.gridColumnCollection.Remove(key:  UnityEngine.Object.__il2cppRuntimeField_byval_arg);
                val_34 = val_34 + 1;
            }
            while((val_34 - 7) < null);
            
            }
            
            if(this.OnGridChanged == null)
            {
                    return;
            }
            
            this.OnGridChanged.Invoke();
        }
        public void CreateGrid(System.Collections.Generic.List<string> letterTileData, int columnLimit)
        {
            System.Collections.Generic.Dictionary<System.Int32, UnityEngine.UI.VerticalLayoutGroup> val_23;
            System.Collections.Generic.Dictionary<System.Int32, SLC.Minigames.WordBalloon.WordBalloonLetterSlot> val_24;
            int val_25;
            var val_26;
            var val_27;
            bool val_23 = true;
            this.initialColumnCount = columnLimit;
            if()
            {
                    var val_22 = 0;
                do
            {
                val_23 = this.gridColumnCollection;
                if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_24 = val_23;
                val_25 = val_22;
                val_24.Add(key:  0, value:  this.CreateGridColumn());
                val_22 = val_22 + 1;
            }
            while(val_22 < columnLimit);
            
            }
            
            if(letterTileData == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_23 >= 1)
            {
                    var val_25 = 0;
                do
            {
                if(val_25 >= val_23)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_25 = 0;
                val_23 = val_23 + 0;
                if((System.String.IsNullOrEmpty(value:  (true + 0) + 32)) != true)
            {
                    float val_24 = 0f;
                val_24 = val_24 / (float)columnLimit;
                val_24 = 0;
                int val_4 = UnityEngine.Mathf.FloorToInt(f:  val_24);
                if(this.gridColumnCollection == null)
            {
                    throw new NullReferenceException();
            }
            
                val_23 = val_25 - ((val_25 / columnLimit) * columnLimit);
                val_25 = val_23;
                UnityEngine.UI.VerticalLayoutGroup val_6 = this.gridColumnCollection.Item[val_25];
                if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
                SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_9 = this.CreateLetterSlot(uid:  val_23 + (val_4 * columnLimit), colId:  val_23, rowId:  val_4, parent:  val_6.transform);
                if(val_25 >= this.gridColumnCollection)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_25 = val_9;
                if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_9.letterTile = this.CreateLetterTile(slot:  val_25, letterValue:  System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_byval_arg);
                val_24 = this.letterSlotCollection;
                if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_25 = val_9.<Uid>k__BackingField;
                val_24.Add(key:  val_25, value:  val_9);
            }
            
                val_25 = val_25 + 1;
            }
            while(val_25 < null);
            
            }
            
            val_24 = this.letterSlotCollection;
            if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_11 = val_24.GetEnumerator();
            goto label_17;
            label_23:
            val_23 = 9733424;
            int val_13 = val_23 - ((val_23 / columnLimit) * columnLimit);
            if(val_13 != 0)
            {
                    SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_14 = this.GetSlotFromUid(id:  9733423);
            }
            else
            {
                    val_26 = 0;
            }
            
            if(val_13 == (columnLimit - 1))
            {
                    val_27 = 0;
            }
            else
            {
                    SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_16 = this.GetSlotFromUid(id:  val_23 + 1);
            }
            
            SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_20 = this.GetSlotFromUid(id:  val_23 + columnLimit);
            mem[56] = this.GetSlotFromUid(id:  val_23 - columnLimit);
            mem[40] = val_26;
            label_17:
            if(0.MoveNext() == true)
            {
                goto label_23;
            }
            
            0.Dispose();
        }
        private SLC.Minigames.WordBalloon.WordBalloonLetterSlot CreateLetterSlot(int uid, int colId, int rowId, UnityEngine.Transform parent)
        {
            UnityEngine.GameObject val_1 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.letterSlotPrefab, parent:  parent);
            val_1.name = "LetterSlot_" + uid;
            SLC.Minigames.WordBalloon.WordBalloonLetterSlot val_3 = val_1.GetComponent<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>();
            val_3.Initialize(uId:  uid, _colId:  colId, _rowId:  rowId);
            return val_3;
        }
        private SLC.Minigames.WordBalloon.WordBalloonLetterTile CreateLetterTile(SLC.Minigames.WordBalloon.WordBalloonLetterSlot slot, string letterValue)
        {
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.letterTilePrefab, parent:  this.letterTileParent.transform);
            val_2.name = System.String.Format(format:  "LetterTile_{0}{1}", arg0:  slot.<Uid>k__BackingField, arg1:  letterValue);
            SLC.Minigames.WordBalloon.WordBalloonLetterTile val_4 = val_2.GetComponent<SLC.Minigames.WordBalloon.WordBalloonLetterTile>();
            val_4.Initialize(slotToAttachTo:  slot, letter:  letterValue);
            return val_4;
        }
        private UnityEngine.UI.VerticalLayoutGroup CreateGridColumn()
        {
            return UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.gridColumnPrefab, parent:  this.letterSlotGridParent.transform).GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        }
        public void ClearGrid()
        {
            var val_3;
            var val_4;
            var val_11;
            var val_12;
            Dictionary.Enumerator<TKey, TValue> val_1 = this.letterSlotCollection.GetEnumerator();
            label_7:
            val_11 = public System.Boolean Dictionary.Enumerator<System.Int32, SLC.Minigames.WordBalloon.WordBalloonLetterSlot>::MoveNext();
            if(val_3.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_12 = mem[val_4 + 72];
            val_12 = val_4 + 72;
            if(val_12 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_12.gameObject);
            UnityEngine.Object.Destroy(obj:  val_4.gameObject);
            goto label_7;
            label_2:
            val_3.Dispose();
            this.letterSlotCollection.Clear();
            Dictionary.Enumerator<TKey, TValue> val_8 = this.gridColumnCollection.GetEnumerator();
            label_14:
            val_11 = public System.Boolean Dictionary.Enumerator<System.Int32, UnityEngine.UI.VerticalLayoutGroup>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_10;
            }
            
            val_12 = 0;
            if(val_12 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_12.gameObject);
            goto label_14;
            label_10:
            0.Dispose();
            this.gridColumnCollection.Clear();
        }
        public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.isInputModeOn = true;
        }
        public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.isInputModeOn = false;
            SLC.Minigames.WordBalloon.WordBalloonManager val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if((val_1.<MinigameState>k__BackingField) != 1)
            {
                    return;
            }
            
            this.ResolveInput();
        }
        public WordBalloonGrid()
        {
            this.flyoutMessageNoMovesLeft = "<b><size=90>No Moves Left</size></b>\nPlan ahead to identify every word!";
            this.flyoutMessageWrongWordSubmitted = "{0} is not used in this level";
            this.gridColumnCollection = new System.Collections.Generic.Dictionary<System.Int32, UnityEngine.UI.VerticalLayoutGroup>();
            this.letterSlotCollection = new System.Collections.Generic.Dictionary<System.Int32, SLC.Minigames.WordBalloon.WordBalloonLetterSlot>();
            this.currentInputQueue = new System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordBalloonLetterSlot>();
        }
    
    }

}
