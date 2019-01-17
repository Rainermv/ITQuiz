using UnityEngine;
using System.Collections;

namespace Quiz{

	[System.Serializable]
	public abstract class EndGameObjectTyped : EndGameObject {
	
		public enum EndGameType {RightA, WrongA, Token, Score, Subject, SubjectCount}
		
		public EndGameType type;
		protected Data game_data;
	
		protected virtual void Awake(){
			game_data = Data.GetInstance();
			//text = GetComponent<TextMesh>();
		}
		
		
		protected override void Display(bool display){
			
			base.Display(display);
			
			if (display == true){
			
				//int value = 0;
				//string cases = "00";
				
				switch (type){
				case EndGameType.RightA: UpdateValue(game_data.RightAnswers); break;
				case EndGameType.WrongA: UpdateValue(game_data.WrongAnswers); break;
				case EndGameType.Token:  UpdateValue(game_data.Tokens); break;
				case EndGameType.Score:  UpdateValue(game_data.Points); break;
//				case EndGameType.Subject: 
//					string subject = game_data.GetSubjectCounter(0).subject;
//					UpdateValue(game_data.GetSubjectCounter(0).subject); break;
//				case EndGameType.SubjectCount: UpdateValue(game_data.GetSubjectCounter(0).count); break;
					
				}			
				
				
			}
			
		}
		
		protected virtual void UpdateValue(int value){
			return;
		}
		
		protected virtual void UpdateValue(string value){
			return;
		}
	}
}
