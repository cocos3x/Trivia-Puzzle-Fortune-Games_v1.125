using UnityEngine;

namespace SLC.Minigames.WordMemory
{
    public class CardItem : MyButton
    {
        // Fields
        private UnityEngine.UI.Text label;
        private UnityEngine.UI.Image back;
        private UnityEngine.UI.Image face;
        private UnityEngine.GameObject content;
        private int index;
        private bool faceUp;
        
        // Methods
        public void Init(int _index, string _word)
        {
            this.index = _index;
            this.FaceDown();
        }
        public void FaceDown()
        {
            this.back.enabled = true;
            this.faceUp = false;
        }
        public void FaceUp()
        {
            this.back.enabled = false;
            this.faceUp = true;
        }
        public override void OnButtonClick()
        {
            if(this.faceUp == true)
            {
                    return;
            }
            
            SLC.Minigames.WordMemory.WordMemoryManager val_1 = MonoSingleton<SLC.Minigames.WordMemory.WordMemoryManager>.Instance;
            if((val_1.<Locked>k__BackingField) != false)
            {
                    return;
            }
            
            if(val_1.canPlay == false)
            {
                    return;
            }
            
            this.FaceUp();
            MonoSingleton<SLC.Minigames.WordMemory.WordMemoryManager>.Instance.FaceUpCard(index:  this.index);
        }
        public void Hide()
        {
            if(this.content != null)
            {
                    this.content.SetActive(value:  false);
                return;
            }
            
            throw new NullReferenceException();
        }
        private void Update()
        {
        
        }
        public CardItem()
        {
        
        }
    
    }

}
