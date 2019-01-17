using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Atomic{
	public class EventManager {
	
		private static EventManager instance;
		
		private List<IEventListener> listeners = new List<IEventListener>();
				
		private EventManager(){
		
		}
		
		public static EventManager GetInstance(){
		
			if (instance == null)
				instance = new EventManager();
				
			return instance;
		
		}
		
		public void ReadEvent(ButtonEvent new_event){
				
			string scene = string.Empty;
				
			switch (new_event){
				case ButtonEvent.Start: 	scene = "Game"; break;
				case ButtonEvent.Menu: 		scene = "Menu"; break;
				case ButtonEvent.Credits: 	scene = "Credits"; break;
				
			}
			
			
			if (scene != string.Empty){
				ReportEvent (new_event);
				LoadScene(scene);
			}
		
		}
		

		
		public void LoadScene(string name){
			
			Application.LoadLevel(name);
		}
		
		
		
		public void AddListener(IEventListener listener){
		
			if (!listeners.Contains(listener))
				listeners.Add (listener);
		}
		
		public void ReportEvent(ButtonEvent ev){
			foreach (IEventListener listener in listeners){
				
				listener.ListenEvent(ev);						
			}
		}
		
	}
}
