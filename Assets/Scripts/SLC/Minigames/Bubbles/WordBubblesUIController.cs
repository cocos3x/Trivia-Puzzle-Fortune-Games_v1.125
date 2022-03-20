using UnityEngine;

namespace SLC.Minigames.Bubbles
{
    public class WordBubblesUIController : MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>
    {
        // Fields
        private UnityEngine.GameObject container;
        private UnityEngine.GameObject ChosenWordContent;
        private SLC.Minigames.Bubbles.WordBubblesBubble[] chosenBubbleElements;
        private UnityEngine.UI.Text levelTitle;
        private UnityEngine.GameObject hand;
        private UnityEngine.GameObject checkMark;
        private UnityEngine.GameObject BubbleElementsContent;
        private UnityEngine.Transform[] BubbleElementsPos;
        private UnityEngine.GameObject BubbleElementPrefab;
        private SLC.Minigames.Bubbles.WordBubblesBubble[] BubbleElements;
        private UnityEngine.UI.Slider TimerSlider;
        private UnityEngine.UI.Image[] Lives;
        private UnityEngine.Color[] ElementColors;
        private System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesBubble> chosenBubbleQueue;
        private bool initialized;
        
        // Methods
        public override void InitMonoSingleton()
        {
            this.InitMonoSingleton();
            this.Initialize();
        }
        private void Initialize()
        {
            if(this.initialized == true)
            {
                    return;
            }
            
            this.BubbleElements = new SLC.Minigames.Bubbles.WordBubblesBubble[0];
            var val_7 = 4;
            label_15:
            if((val_7 - 4) >= this.BubbleElementsPos.Length)
            {
                goto label_4;
            }
            
            this.BubbleElements[0] = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.BubbleElementPrefab.gameObject, parent:  this.BubbleElementsPos[0]).GetComponent<SLC.Minigames.Bubbles.WordBubblesBubble>();
            val_7 = val_7 + 1;
            if(this.BubbleElementsPos != null)
            {
                goto label_15;
            }
            
            throw new NullReferenceException();
            label_4:
            this.hand.SetActive(value:  true);
            this.initialized = true;
        }
        public void StartLevel(SLC.Minigames.Bubbles.WordBubblesLevel currentLevel)
        {
            if(this.initialized != true)
            {
                    this.Initialize();
            }
            
            this.ResetUI();
            SLC.Minigames.Bubbles.WordBubblesController val_1 = MonoSingleton<SLC.Minigames.Bubbles.WordBubblesController>.Instance;
            if((val_1.<toturalLevel>k__BackingField) != true)
            {
                    this.hand.SetActive(value:  false);
            }
            
            var val_15 = 0;
            label_27:
            if(val_15 >= (currentLevel.<Elements>k__BackingField))
            {
                goto label_9;
            }
            
            do
            {
            
            }
            while((this.BubbleElements[(long)UnityEngine.Random.Range(min:  0, max:  this.BubbleElements.Length)].gameObject.activeSelf) == true);
            
            if(val_15 >= this.BubbleElements.Length)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.BubbleElements[(long)UnityEngine.Random.Range(min:  0, max:  this.BubbleElements.Length)].Setup(text:  this.BubbleElements[(long)UnityEngine.Random.Range(min:  0, max:  this.BubbleElements.Length)][val_15], c:  new UnityEngine.Color() {r = this.ElementColors[(long)UnityEngine.Random.Range(min:  0, max:  this.ElementColors.Length)], g = this.ElementColors[(long)UnityEngine.Random.Range(min:  0, max:  this.ElementColors.Length)], b = this.ElementColors[(long)UnityEngine.Random.Range(min:  0, max:  this.ElementColors.Length)], a = this.ElementColors[(long)UnityEngine.Random.Range(min:  0, max:  this.ElementColors.Length)]}, index:  0);
            this.BubbleElements[(long)UnityEngine.Random.Range(min:  0, max:  this.BubbleElements.Length)].gameObject.SetActive(value:  true);
            val_15 = val_15 + 1;
            if((currentLevel.<Elements>k__BackingField) != null)
            {
                goto label_27;
            }
            
            label_9:
            this.container.SetActive(value:  true);
        }
        public void SetTimerSlider(float value)
        {
            if(this.TimerSlider != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public void ToggleUI(bool state)
        {
            if(this.container != null)
            {
                    this.container.SetActive(value:  state);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ChooseWordElement(SLC.Minigames.Bubbles.WordBubblesBubble bubble)
        {
            var val_2;
            var val_3;
            var val_9;
            var val_10;
            if(W9 < this.chosenBubbleElements.Length)
            {
                goto label_3;
            }
            
            List.Enumerator<T> val_1 = this.chosenBubbleQueue.GetEnumerator();
            label_7:
            val_9 = public System.Boolean List.Enumerator<SLC.Minigames.Bubbles.WordBubblesBubble>::MoveNext();
            if(val_3.MoveNext() == false)
            {
                goto label_4;
            }
            
            val_10 = val_2;
            if(val_10 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = 0;
            UnityEngine.GameObject val_5 = val_10.gameObject;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_5.SetActive(value:  true);
            goto label_7;
            label_4:
            val_3.Dispose();
            this.chosenBubbleQueue.Clear();
            label_3:
            this.chosenBubbleQueue.Add(item:  bubble);
            bubble.gameObject.SetActive(value:  false);
            this.ValidWord();
            MonoSingleton<SLC.Minigames.Bubbles.WordBubblesController>.Instance.CheckTotural();
            this.UpdateChosenBubblesUI();
        }
        public void TurnBackWordElement(WordBubblesBubbleSelect select)
        {
            SLC.Minigames.Bubbles.WordBubblesBubble val_5;
            System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesBubble> val_6;
            var val_7;
            val_6 = this.chosenBubbleQueue;
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_1 = val_6.GetEnumerator();
            label_5:
            val_7 = public System.Boolean List.Enumerator<SLC.Minigames.Bubbles.WordBubblesBubble>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_5 = 0;
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(select == null)
            {
                    throw new NullReferenceException();
            }
            
            if(1 != W9)
            {
                goto label_5;
            }
            
            val_7 = 0;
            UnityEngine.GameObject val_3 = val_5.gameObject;
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_3.SetActive(value:  true);
            bool val_4 = this.chosenBubbleQueue.Remove(item:  val_5);
            label_2:
            0.Dispose();
            this.ValidWord();
            this.UpdateChosenBubblesUI();
        }
        private void UpdateChosenBubblesUI()
        {
            System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesBubble> val_3;
            var val_4;
            var val_7 = 4;
            do
            {
                var val_1 = val_7 - 4;
                if(val_1 >= (this.chosenBubbleElements.Length << ))
            {
                    return;
            }
            
                val_3 = this.chosenBubbleQueue;
                SLC.Minigames.Bubbles.WordBubblesBubble val_4 = this.chosenBubbleElements[0];
                if(val_1 < this.chosenBubbleElements.Length)
            {
                    if(val_1 >= this.chosenBubbleElements.Length)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                SLC.Minigames.Bubbles.WordBubblesBubble val_5 = this.chosenBubbleElements[0];
                val_3 = this.chosenBubbleElements[0].<Text>k__BackingField;
                if(val_1 >= this.chosenBubbleElements.Length)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(val_1 >= this.chosenBubbleElements.Length)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_4.Setup(text:  val_3, c:  new UnityEngine.Color() {r = V8.16B, g = V9.16B, b = V11.16B, a = V10.16B}, index:  0);
                UnityEngine.GameObject val_2 = this.chosenBubbleElements[0].gameObject;
                val_4 = 1;
            }
            else
            {
                    val_4 = 0;
            }
            
                val_4.gameObject.SetActive(value:  false);
                val_7 = val_7 + 1;
            }
            while(this.chosenBubbleElements != null);
            
            throw new NullReferenceException();
        }
        private void ValidWord()
        {
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            List.Enumerator<T> val_2 = this.chosenBubbleQueue.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Text.StringBuilder val_4 = val_1.Append(value:  41868256);
            goto label_5;
            label_2:
            0.Dispose();
            if((MonoSingleton<SLC.Minigames.Bubbles.WordBubblesController>.Instance.SubmitWords(word:  val_1)) == false)
            {
                    return;
            }
            
            this.chosenBubbleQueue.Clear();
            this.UpdateChosenBubblesUI();
        }
        public void PointTo(int bubbleIndex)
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ActuralPoint(bubbleIndex:  bubbleIndex));
            if(this.chosenBubbleElements.Length < 1)
            {
                    return;
            }
            
            var val_5 = 0;
            do
            {
                this.chosenBubbleElements[val_5].GetComponent<UnityEngine.UI.Button>().enabled = false;
                val_5 = val_5 + 1;
            }
            while(val_5 < this.chosenBubbleElements.Length);
        
        }
        private System.Collections.IEnumerator ActuralPoint(int bubbleIndex)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .bubbleIndex = bubbleIndex;
            return (System.Collections.IEnumerator)new WordBubblesUIController.<ActuralPoint>d__25();
        }
        public void LevelComplete(bool victory)
        {
            this.BubbleElementsContent.SetActive(value:  false);
            this.ChosenWordContent.SetActive(value:  false);
            this.checkMark.SetActive(value:  victory);
        }
        public void ResetUI()
        {
            if(this.BubbleElements.Length >= 1)
            {
                    var val_7 = 0;
                do
            {
                SLC.Minigames.Bubbles.WordBubblesBubble val_6 = this.BubbleElements[val_7];
                val_6.gameObject.SetActive(value:  false);
                val_6.GetComponent<UnityEngine.UI.Button>().enabled = true;
                val_7 = val_7 + 1;
            }
            while(val_7 < this.BubbleElements.Length);
            
            }
            
            if(this.chosenBubbleElements.Length >= 1)
            {
                    var val_9 = 0;
                do
            {
                SLC.Minigames.Bubbles.WordBubblesBubble val_8 = this.chosenBubbleElements[val_9];
                val_8.gameObject.SetActive(value:  false);
                val_8.GetComponent<UnityEngine.UI.Button>().enabled = true;
                val_9 = val_9 + 1;
            }
            while(val_9 < this.chosenBubbleElements.Length);
            
            }
            
            this.checkMark.SetActive(value:  false);
            this.BubbleElementsContent.SetActive(value:  true);
            this.ChosenWordContent.SetActive(value:  true);
            this.chosenBubbleQueue = new System.Collections.Generic.List<SLC.Minigames.Bubbles.WordBubblesBubble>();
            goto typeof(UnityEngine.UI.Slider).__il2cppRuntimeField_420;
        }
        public void UpdateLives(int count)
        {
            var val_3 = 0;
            label_7:
            if(val_3 >= (this.Lives.Length << ))
            {
                    return;
            }
            
            UnityEngine.UI.Image val_3 = this.Lives[val_3];
            if(val_3 >= (long)count)
            {
                goto label_3;
            }
            
            UnityEngine.Color val_1 = UnityEngine.Color.red;
            if(val_3 != null)
            {
                goto label_4;
            }
            
            label_3:
            UnityEngine.Color val_2 = UnityEngine.Color.gray;
            label_4:
            val_3.color = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a};
            val_3 = val_3 + 1;
            if(this.Lives != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
        }
        public WordBubblesUIController()
        {
        
        }
    
    }

}
