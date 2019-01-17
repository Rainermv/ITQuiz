using UnityEngine;
using System.Collections;

namespace Quiz{
	
	[System.Serializable]	
	[AddComponentMenu("Atomic/Quiz/Widget/Tracker Text")]
	public class WidgetTrackerText : WidgetTracker {
	
		//public ValueToTrack track;
		public string Title;
		public string Cases;
		
		//protected int value;
		//protected int last_value;
		
		private TextMesh mesh;
	
		public override void Awake(){
			base.Awake ();
			mesh = GetComponent<TextMesh>();
		}
		
		public override void Start () {
			base.Start ();
			
		}
		
		// Update is called once per frame
		public override void Update () {
			base.Update ();
			
		}
		
		public override void DisplayValue(){
				mesh.text = (Title + value.ToString(Cases));
				last_value = value;
				
			
		}
	}
}
