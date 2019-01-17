using UnityEngine;
using System.Collections;

namespace Atomic{

	[AddComponentMenu("Atomic/Generic/Interface/Out Button")]
	public class OutButton : MonoBehaviour {
	
		public ButtonEvent button_event;
		
		private bool over = false;
		private bool pressed = false;
		
		public bool Over { get{ return over;} set { over = value;}}
		public bool Pressed { get{ return pressed;} set { pressed = value;}}
				
		
		public virtual void OnEnable(){
			pressed = false;
			over = false;
			SetColor (Color.white);
		}
		
		public virtual void MouseOver(){ 
			over = true;
			
			if (!pressed)
				SetColor (Color.gray);
		}
		
		public virtual void MouseExit(){ 
			over = false;
			
			if (!pressed)
				SetColor (Color.gray);
		}
		
		public virtual void OnMouseDown(){
			pressed = true;
			
			SetColor (new Color(0.2f,0.2f,0.2f));
		}
		
		public virtual void OnMouseUp(){
			pressed = false;
			SendEvent();
			
			
			
			if (!over)
				SetColor (Color.white);
		
		}
		
		protected void SetColor(Color new_color){
		
			renderer.material.color = new_color;
		}
		
		protected virtual void SendEvent(){
			EventManager.GetInstance().ReadEvent(button_event);
		}
		
		
		
		
		
	}
}
