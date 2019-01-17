using UnityEngine;
using System.Collections;

namespace Quiz{
	public class GameStateSetup : GameState {
	
		public override GameState OnStart(QuizMain game_instance){
			
			Data game_data = Data.GetInstance();
			QuizConfig config = game_data.GetConfig ();
			
			Debug.Log ("config question lists " + config.QuestionLists.Count);
			
			foreach (QuestionListConfig qlist in config.QuestionLists){
				game_instance.AddToList(qlist.ListSize, qlist.ListDifficulty, qlist.ListSubjects.ToArray(), qlist.Uniform);
				//game_data.ReportSubjects(
			}
			
			foreach (int special_index in config.SpecialQuestions){
				game_instance.SetSpecial(special_index);
			}
			
			
			
			game_instance.SetButtonEnable(Action.Next, false);
			
			game_data.MaxProgress = game_instance.QuestionListSize;
			
			return null;
		}
		
	public override GameState OnUpdate(QuizMain game_instance){
		
			return new GameStateInput();
	}
		
	}
}
