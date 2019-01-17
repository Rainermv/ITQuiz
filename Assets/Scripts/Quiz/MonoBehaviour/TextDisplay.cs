using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Quiz{
	
	public enum DisplayType {Hint, Answer, Subject, Question}
	
	
	[AddComponentMenu("Atomic/Quiz/Text Display")]
	public class TextDisplay : MonoBehaviour{
		
		public DisplayType display_type;
		public bool reset_display_state;
		public string display_text;
		
		private Text text_component;
		
		void Awake(){
		
			text_component = GetComponent<Text>();
			if (text_component == null) Debug.LogWarning("No text display found in " + this.name);
		
		}
		
		public void Reset(){
			gameObject.SetActive(reset_display_state);
			
		}
		
		public void DisplayObject (Question question_object){
		
			switch (display_type){
				
			case DisplayType.Hint:   Display (question_object.GetHint(Random.Range (0,question_object.HintCount))); break;
			case DisplayType.Answer: Display (question_object.GetAnswer(0)); break;
			case DisplayType.Question: Display (question_object.Text); break;
			case DisplayType.Subject: Display (question_object.Subject); break;
			
			} 
			
			//hint_text.Display (question_object.GetHint(Random.Range (0,question_object.HintCount)));
			//			answer_text.Display (question_object.GetAnswer(0));
			//			subject_text.Display (question_object.Subjects.ToArray());
		
		}
		
		public void Display(string text){
			//Debug.Log ("first " + display_type + " " + text);
			
			text_component.text = display_text + " " + text;
					
			//Debug.Log ("second " + this.Text);
	
			//this.SetWordWidth();
			
			//Debug.Log ("third " + this.Text);
			
		}
		
		public void DisplayArray(string[] text_array){
			
			text_component.text = display_text;
			
			foreach (string text in text_array)
				text_component.text += " " + text;
			
			//this.SetWordWidth();
			
		}
		
		public void DisplayNull(){
			text_component.text = "";
		}
		
		public void SetEnabled(DisplayType t, bool enable){
			if (display_type == t)
				gameObject.SetActive(enable); 
		}
		
	}
}
