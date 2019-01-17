using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quiz{

	[System.Serializable]
	[AddComponentMenu("Atomic/Quiz/End Game/End Game Manager")]
	public class EndGameManager : MonoBehaviour, ISerializationCallbackReceiver {
	
		public EndGameObject[] Children;
		
		[SerializeField]
		public float[] Timers;
		
		private bool doonce = true;
		//public int[]		   Timers;
	
		//public List<GameObject[]> Batches;
	
		// Use this for initialization
		void Awake () {
			Data.GetInstance().UpdateScore();
		}
		
		void Start(){
		
			//this.transform.parent = FindObjectOfType<Canvas>().transform;
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		void ISerializationCallbackReceiver.OnBeforeSerialize(){
			
			Timers = new float[Children.Length];
			
			int i = 0;
			foreach (EndGameObject child in Children){
				Timers[i++] = child.Timer;
			}
		}
		
		void ISerializationCallbackReceiver.OnAfterDeserialize(){
			
			if (doonce == false) return;
			
			int i = 0;
			foreach (EndGameObject child in Children){
				child.Timer = Timers[i++];
			}
			doonce = false;
			
		}
	}
}
