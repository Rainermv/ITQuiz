using UnityEngine;
using System.Collections;

namespace Quiz{
	public enum ValueToTrack {Score, Tokens, Time}
	
	[System.Serializable]
	public abstract class WidgetTracker : Widget {
	
		public ValueToTrack track = ValueToTrack.Score;
		
//		public string Title;
//		public string Cases;
		
		protected int value;
		protected int last_value;
		
//		private TextMesh mesh;
	
		public override void Awake(){
			base.Awake ();
		}
//		
		public override void Start () {
			base.Start ();
			//value = data.Tokens;
			value = 0;
			last_value = 0;
			
			DisplayValue ();
			
		}
		
		// Update is called once per frame
		public override void Update () {
				
			switch (track){
				case ValueToTrack.Score : 	value = game_data.Points; break;
				case ValueToTrack.Tokens :	value = game_data.Tokens; break;
				case ValueToTrack.Time : 	
					value = (int)game_data.QuestionTimer; break;
			}
			//value = data.Points;
					
			if (value != last_value)
				DisplayValue ();
			
		}
		
		public abstract void DisplayValue();
			
		
	}
}
