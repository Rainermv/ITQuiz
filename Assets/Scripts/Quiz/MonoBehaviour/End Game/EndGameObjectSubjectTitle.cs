using UnityEngine;
using System.Collections;

namespace Quiz{
	[System.Serializable]
	[AddComponentMenu("Atomic/Quiz/End Game/End Game Subject Title")]
	public class EndGameObjectSubjectTitle : EndGameObject {
			
		protected override void Display(bool display){
				
			if (!Data.GetInstance().ShowSubjectScore){
			
				base.Display(false);
				return;
			}
			
			
			
		}
	}
}
