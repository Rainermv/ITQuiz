using UnityEngine;
using System.Collections;

namespace Quiz{

	[AddComponentMenu("Atomic/Quiz/Action Button")]
	public class ActionButton : MonoBehaviour {
	
		public Action action;
		
		void OnEnable(){
			renderer.material.color = Color.white;
		}
	
		void OnMouseDown(){
			renderer.material.color = Color.gray;
			
			
		}
		
		void OnMouseUp(){
			SendMessageUpwards("Input",action);
			renderer.material.color = Color.white;
		}

		public void SetGameObjectActive(bool active){
			gameObject.SetActive(active);
		}
		
		
	}
}
