using UnityEngine;
using System.Collections;

namespace Quiz{
	public class GameState {
	
		public virtual GameState OnStart(QuizMain game_instance){
			return null;
		}
		public virtual GameState OnInput(QuizMain game_instance, Action input){
			return null;
		}
		
		public virtual GameState OnInput(QuizMain game_instance, Atomic.ButtonEvent input){
			//return null;
			
			if (input == Atomic.ButtonEvent.Menu)
				Data.Reset ();
			
			return null;
			
		}
		
		public virtual GameState OnUpdate(QuizMain game_instance){
			return null;
		}
		//protected abstract GameState OnUpdate(Game game_instance);
		//protected abstract GameState OnFinish(Game game_instance);
	}
}