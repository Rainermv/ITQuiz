using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quiz{
	
	[System.Serializable]
	[AddComponentMenu("Atomic/Quiz/Widget/Tracker Counter")]
	public class WidgetTrackerCounter : WidgetTracker {
	
		
		public GameObject obj_ref;
		
		private List<GameObject> counters = new List<GameObject>();
		
		//public int max_width;
		public float Size;
			
		public override void Awake(){
			base.Awake ();			
		}
		
		public override void Start () {
			
			base.Start ();
			
		}
		
		public override void Update ()
		{
			base.Update();
		}
		
		public override void DisplayValue(){
		
		
			if (value > last_value){
				//mesh.text = (Title + value.ToString(Cases));
				
				for (int i = last_value; i < value; i++){
										
					counters.Add ((GameObject)Instantiate (obj_ref));
					
					counters[i].transform.parent = transform;
					counters[i].transform.position = transform.position;
	
				}
							
				
			}
			
			else if (value < last_value){
				//mesh.text = (Title + value.ToString(Cases));
				
				for (int i = value; i < last_value; i++){
					
					if (i < counters.Count){
						Destroy(counters[i]);
						counters.RemoveAt (i);
					}
					
				}
								
			}
			
			for ( int i = 0; i < counters.Count; i++){
				
				RepositionIcon(i, counters.Count);
			
			}
			
			last_value = value;
					 
		} 
				
		void RepositionIcon(int iterator, int icon_count){
			//float distance = ((float)size/(float)icons);
			float pos_x = (float)iterator * ((float)Size/(float)icon_count) - (float) Size*0.5f;
			float pos_y = 0;
			
			counters[iterator].transform.localPosition = new Vector2(pos_x,pos_y);
			//question_icon_list.Add ((GameObject)Instantiate (obj_ref,new Vector2 (pos_x,pos_y), Quaternion.identity));
			
		}
	}
}
