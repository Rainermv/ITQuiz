using UnityEngine;
using System.Collections;

namespace Atomic{

	[AddComponentMenu("Atomic/Generic/Credits/Roll Credits")]
	public class RollCredits : MonoBehaviour {
	
		public Vector3  Move;
		
		// Update is called once per frame
		void Update () {
	
			transform.Translate (Move * Time.deltaTime);
		
		}
	}
}
