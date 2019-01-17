using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Quiz{
	
	[System.Serializable]
	[AddComponentMenu("Atomic/Quiz/End Game/End Game Generic Object")]
	public class EndGameObject : MonoBehaviour{
	
		[SerializeField]
		private float timer;
		
		public float Timer{
			get{return timer;}
			set{timer = value;}
		}
		
		
		// Use this for initialization
		protected virtual void Start () {
			
			Display(false);
			StartCoroutine(DisplayTimer());
			
		}
		
		IEnumerator DisplayTimer()
		{
			for (float i = 0; i < timer; i += Time.deltaTime)
				yield return 0;
				
			Display(true);
			
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		protected virtual void Display(bool display){
			
			if (renderer != null)
				renderer.enabled = display;
			
			if (GetComponent<Text>() != null)
				GetComponent<Text>().enabled = display;
				
		}
		
		
	}
}
