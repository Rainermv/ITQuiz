using UnityEngine;
using System.Collections;

namespace Quiz{
	public class GameStateInput : GameState {
	
		int action_remove = 3;
		bool action_hint = true;
	
		public override GameState OnStart(QuizMain game_instance){
			
			game_instance.ResetQuestionTimer();
			game_instance.DisplayQuestion(Data.GetInstance().Progress);
			
			return null;
		}
		public override GameState OnUpdate(QuizMain game_instance){
			
			if (!game_instance.CheckTimer())
				return new GameStateFinish();
			
			return null;
		}
		
		public override GameState OnInput(QuizMain game_instance, Action input){
		
			
			switch (input){
			case Action.Hint:
				if (!action_hint) break;
				action_hint = false;	
				game_instance.ActionHint(); 		return null;
			case Action.Skip: 			game_instance.ActionSkip (); 		return null;
			case Action.Remove:
				if (action_remove <= 0) break; 	
				action_remove--;	
				game_instance.ActionRemove ();		return null;
			case Action.AnswerRight: 	game_instance.ActionAnswerRight ();	return new GameStateWaiting();
			case Action.AnswerWrong: 	game_instance.ActionAnswerWrong ();	return new GameStateWaiting();
							
			}
			
			return null;
				
		}
	}
}
