using UnityEngine;
using System.Collections;
using Atomic;

namespace Quiz{

	[AddComponentMenu("Atomic/Quiz/Out Game/Config Button")]
	public class ConfigButton : Atomic.OutButton {
	
		public QuizConfig config;
		
		protected override void SendEvent(){
			
			Data.GetInstance().SetConfig(config);		
			EventManager.GetInstance().ReadEvent(ButtonEvent.Start);
		}
	}
}
