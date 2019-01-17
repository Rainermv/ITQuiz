using UnityEngine;
using System.Collections;

using System.Collections.Generic;

namespace Quiz{

	[AddComponentMenu("Atomic/Quiz/Widget/Progress Bar")]
	public class WidgetProgressBar : Widget {
	
		//private Data game_data;
		
		public GameObject question_icon_reference;
		public GameObject end_icon_reference;
		public GameObject arrow_reference;
		
		public int size;
		
		private List<GameObject> question_icon_list = new List<GameObject>();
		private GameObject arrow;	
		
		
		public void Init (ref List<Question> question_list){
		
			if (question_list.Count == 0){
				Debug.LogError("Can't build Progress Bar Widget -Question List Empty");
				return;
			}

			int icon_count = question_list.Count;
			
			for (int i = 0; i < icon_count; i++){
	
				InstantiateIcon(question_icon_reference,i,icon_count);
				
				if (question_list[i].Special)
					question_icon_list[i].SendMessage("SetSpecial");
			
			}
			
			InstantiateIcon(end_icon_reference,icon_count,icon_count);	
			InstantiateArrow();
				
		}
		
		// Update is called once per frame
		public override void Update () {
			
			if (question_icon_list.Count > 0){
				float x = question_icon_list[game_data.Progress].transform.position.x;
				float y = transform.position.y +0.2f;
				
				arrow.transform.position = (new Vector2(x,y));
			}
		
		}
		
		void InstantiateIcon(GameObject obj_ref, int iterator, int icon_count){
			//float distance = ((float)size/(float)icons);
			float pos_x = (float)iterator * ((float)size/(float)icon_count) - (float) size*0.5f;
			float pos_y = transform.position.y;
			question_icon_list.Add ((GameObject)Instantiate (obj_ref,new Vector2 (pos_x,pos_y), Quaternion.identity));
					
		}
		
		void InstantiateArrow(){
		
			arrow = (GameObject)Instantiate (arrow_reference);
		
		}
		
	
	}
}
