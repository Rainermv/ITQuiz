using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Quiz{
	[AddComponentMenu("Atomic/Quiz/End Game/Spawner")]
	public class EndGameSpawner : MonoBehaviour {
	
		public GameObject end_game_prefab;
		
		// Use this for initialization
		void Start () {
		
			
					
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		public void Enable(bool enable){
			
			GameObject endgameobj = (GameObject)Instantiate(end_game_prefab);
			
			endgameobj.transform.position = transform.position;
			
			Destroy (gameObject);
		}
	}
}
