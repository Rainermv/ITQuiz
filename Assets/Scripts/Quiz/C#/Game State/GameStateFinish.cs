using UnityEngine;
using System.Collections;

namespace Quiz{
	public class GameStateFinish : GameState {
	
		float time = 20f;
	
		public override GameState OnStart(QuizMain game_instance){
			
			game_instance.Pause(true);	
			game_instance.DisplayFinish();
			
			Report.Save ();
									
			return null;
		}
		void TickTimer(){
						
			if (time > 0){
				time-= Time.deltaTime;
			}
			else{
				//Data.Reset ();
				Data.Reset ();
				
								
				Atomic.EventManager.GetInstance().LoadScene("Menu");
			}
			
		}
//		public virtual GameState OnInput(Game game_instance, Action input){
//			return null;
//		}
		public override GameState OnUpdate(QuizMain game_instance){
			TickTimer();
			
			return null;
		}
		
		//protected abstract GameState OnUpdate(Game game_instance);
		//protected abstract GameState OnFinish(Game game_instance);
	}
}