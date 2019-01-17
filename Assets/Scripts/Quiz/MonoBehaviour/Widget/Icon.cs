using UnityEngine;
using System.Collections;

namespace Quiz{
	
	[AddComponentMenu("Atomic/Quiz/Widget/Icon")]
	public class Icon : MonoBehaviour {
	
		//bool special = false;
		
		public Sprite special_sprite;
		
		private SpriteRenderer spr_renderer;
		
		// Use this for initialization
		void Start () {
		
			spr_renderer = GetComponent<SpriteRenderer>();
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		public void SetSpecial(){
		
			//special = true;
			
			if (spr_renderer != null && special_sprite != null){
				
				spr_renderer.sprite = special_sprite;
			
			}
			else
				renderer.material.color = Color.magenta;
		
		}
	}
}
