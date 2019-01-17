using UnityEngine;
using System.Collections;

namespace Quiz{
	[System.Serializable]
	[AddComponentMenu("Atomic/Quiz/End Game/End Game Subject")]
	public class EndGameObjectSubject : EndGameObject {
	
		public int subject_index;
		public string cases;
		
		protected override void Display(bool display){
				
			if (!Data.GetInstance().ShowSubjectScore){
			
				base.Display(false);
				return;
			}
			
		
			SubjectCounter counter = Data.GetInstance().GetSubjectCounter(subject_index);
					
			//Debug.Log (display);
			if (counter != null && display == true){
				
				GetComponent<TextMesh>().text = (counter.subject + " " + counter.count);
				//Debug.Log (GetComponent<TextMesh>().text);
				renderer.enabled = true;
			}
			
			else renderer.enabled = false;
			
			
		}
	}
}
