using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Quiz{

	[System.Serializable]
	[AddComponentMenu("Atomic/Quiz/End Game/Number Object")]
	public class EndGameNumberObject : EndGameObjectTyped {
		
		//public EndGameType type;
		
		//private Data game_data;
		//private TextMesh text;
		
		private Text text_render;
		public string cases;
		
		protected override void Awake(){
			game_data = Data.GetInstance();
			text_render = GetComponent<Text>();
			//text = GetComponent<TextMesh>();
		}
		
		protected override void UpdateValue(int value){
			
			StartCoroutine(WriteValue(value));
			//tmesh.text = value.ToString(cases);
		}
		
		IEnumerator WriteValue(int target_value){
		
			float value = 0;
			float starting_value = 0;
						
			for (float timer = 0; timer <= (int)target_value; timer += Time.deltaTime){
				
				value = Mathf.Lerp (starting_value,(float)target_value, timer);
				text_render.text = value.ToString(cases);
				
				yield return 0;		
			}
			
			text_render.text = target_value.ToString(cases);
			
		}
	}
}
