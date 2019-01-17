using UnityEngine;
using System.Collections;

namespace Quiz{
	public abstract class Widget : MonoBehaviour {
		
		protected Data game_data;
		
		public virtual void Awake(){
			game_data = Data.GetInstance();
		}
		// Use this for initialization
		public virtual void Start () {
		
		}
		
		// Update is called once per frame
		public virtual void Update () {
		
		}
		
		
	}
}
