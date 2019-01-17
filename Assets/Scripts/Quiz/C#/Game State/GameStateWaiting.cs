using UnityEngine;
using System.Collections;

namespace Quiz{
	public class GameStateWaiting : GameState {
	
		float waiting_time = 5f;
		float waiting_timer;
		
		//bool button_switch = false;
		
		
		
		public override GameState OnStart(QuizMain game_instance){
			ResetTimer();
			
			game_instance.SwitchSprites();
			game_instance.ShowAnswer();
			game_instance.SwitchButtons(true);		
			
			game_instance.Pause(true);	
			
			return null;
		}
	
		public override GameState OnUpdate(QuizMain game_instance){
		
			TickTimer();
		
			if (waiting_timer <= 0){
			
				return AdvanceGame (game_instance);
			}
				
		
			return null;
		
		}
		
		public override GameState OnInput(QuizMain game_instance, Action input){
			
			
			if (input == Action.Next){

				return AdvanceGame (game_instance);
			}
			
			return null;
			
		}

		
		/////////////////////////////////////////////////////////////////////////////////////////
		
		private void ResetTimer(){
			waiting_timer = waiting_time;
		}
		
		private void TickTimer(){
			waiting_timer -= Time.deltaTime;
		}
		
		private GameState AdvanceGame(QuizMain game_instance){
			
			game_instance.Pause(false);
			game_instance.Advance();
			
			if (game_instance.IsEndGame())
				return new GameStateFinish();	
						
			game_instance.SwitchButtons(false);
			return new GameStateInput();
		
		}
		
//		private void SwitchButtons(bool button_switch, Game game_instance){
//			
//			game_instance.SetButtonEnable(Action.Hint, !button_switch);
//			game_instance.SetButtonEnable(Action.Remove, !button_switch);
//			game_instance.SetButtonEnable(Action.Skip, !button_switch);
//			game_instance.SetButtonEnable(Action.Next, button_switch);
//			
//			//button_switch = !button_switch;
//			
//		}
		
	
		
		
	}
}
