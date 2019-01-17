using UnityEngine;
using UnityEditor;
using System.Collections;


namespace Quiz{
	[CustomEditor(typeof(EndGameManager))]
	public class EndGameManagerInspector : Editor 
	{	
		//EndGameObject[] Children;
		
		void OnEnable(){
			
		}
		
		public override void OnInspectorGUI()
		{
			//DrawDefaultInspector();
			EndGameManager Target = (EndGameManager)target;
			
			Target.Children = Target.GetComponentsInChildren<EndGameObject>();
			
			EditorGUILayout.BeginHorizontal();
			
				EditorGUILayout.LabelField("Child");
				EditorGUILayout.LabelField("Spawning time");
			
			EditorGUILayout.EndHorizontal();
			
			foreach (EndGameObject child in Target.Children){
				
				EditorGUILayout.BeginHorizontal();
				
					EditorGUILayout.LabelField(child.gameObject.name);
					child.Timer = EditorGUILayout.FloatField(child.Timer);
								
				EditorGUILayout.EndHorizontal();
			
			}
		
			
		}
		
		
	}
	
	
	
}