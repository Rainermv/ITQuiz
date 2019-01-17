using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Quiz{

	[AddComponentMenu("Atomic/Quiz/Answer Button")]
	public class AnswerButton : MonoBehaviour{
	
		public int option;
		
		public Sprite correct_answer;
		public Sprite incorrect_answer;	
		public Sprite disabled;	
		private Sprite regular;
		
		private Renderer[] renderers;
		private SpriteRenderer spr_renderer;
		private Text text_component;
		//private Collider2D collider;
		
		public string Text{
			get{return text_component.text;}
			set{text_component.text = value;}
		}

		protected void Awake(){
			renderers 		= GetComponentsInChildren<Renderer>();
			spr_renderer 	= GetComponentInChildren<SpriteRenderer>();
			text_component		= GetComponentInChildren<Text>();
			if (text_component == null) Debug.LogWarning("No text display found in " + this.name);
			//collider 		= GetComponentInChildren<Collider2D>();
			regular = spr_renderer.sprite;
		}
		
		void OnMouseDown(){

			foreach (Renderer rend in renderers)
				rend.material.color = Color.gray;
				
		}
		
		void OnMouseUp(){
			SendMessageUpwards("Answer",option);
			
			foreach (Renderer rend in renderers)
				rend.material.color = Color.white;
		}
		
		public void Display(Answer answer_object){
		
			this.text_component.text = answer_object.Text;
			this.option = answer_object.Index;
					
		}	
		
		public void Reset(){
			gameObject.SetActive (true);
			spr_renderer.sprite = regular;
			collider2D.enabled = true;
			
		}
		
		public void Enable(bool en){
			gameObject.SetActive (en);
			collider2D.enabled = false;
		}
		
		public void ChangeSpriteAnswer(bool correct){
			spr_renderer.sprite = (correct? correct_answer : incorrect_answer);
			collider2D.enabled = false;
			
		}	
		
				
		
		
	}
}
