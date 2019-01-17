using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace Quiz{
	[CustomEditor(typeof(ConfigButton))]
	public class OutButtonConfigInspector : Editor 
	{	
		List<bool> fold = new List<bool>();
		ConfigButton Target;
	
		void OnEnable(){
			GetTarget ();
			int num = Target.config.QuestionLists.Count;
			for (int i = 0; i < num; i++)
				fold.Add (true);
		}
		
		public void GetTarget(){
				if (Target == null)
					Target = (ConfigButton)target;
		}
		
		public override void OnInspectorGUI()
		{
			//DrawDefaultInspector();
			Target = (ConfigButton)target;
			
			QuizConfig config = Target.config;
			
			config.ShowSubjectScore = EditorGUILayout.Toggle("Show subject score", config.ShowSubjectScore);
			
			
			//int i = 0;
			for (int i = 0; i < config.QuestionLists.Count; i++){
				
					EditorGUILayout.BeginHorizontal();
					{
					
						fold[i] = EditorGUILayout.Foldout(fold[i], "Question List " + (i+1).ToString());						
						if (GUILayout.Button("x")){
							config.QuestionLists.RemoveAt (i);
							fold.RemoveAt(i);
							break;
						}
					}
					EditorGUILayout.EndHorizontal();
					
				if (fold[i]){
					
					EditorGUILayout.BeginHorizontal();
					{
							//EditorGUILayout.LabelField("List "+ i++);
						config.QuestionLists[i].ListSize = EditorGUILayout.IntField(config.QuestionLists[i].ListSize);
						config.QuestionLists[i].ListDifficulty = (Difficulty)EditorGUILayout.EnumPopup(config.QuestionLists[i].ListDifficulty );
						config.QuestionLists[i].Uniform = EditorGUILayout.Toggle("Uniform",config.QuestionLists[i].Uniform);
												
					}
					EditorGUILayout.EndHorizontal();
									
					//List<string> subjects =  config.QuestionLists[i].ListSubjects;
					for (int j = 0; j < config.QuestionLists[i].ListSubjects.Count; j++){
					
						EditorGUILayout.BeginHorizontal();
						{
							config.QuestionLists[i].ListSubjects[j] = EditorGUILayout.TextField(config.QuestionLists[i].ListSubjects[j]);
							if (GUILayout.Button("X")) {
								config.QuestionLists[i].ListSubjects.RemoveAt (j);
								break;	
							}
						
						}
						EditorGUILayout.EndHorizontal();
					}
					
					if (GUILayout.Button("Add Subject")){
						config.QuestionLists[i].ListSubjects.Add ("Default");
						
					}
				}
								
				EditorGUILayout.Space();
								
			}
			
			if (GUILayout.Button("Add Question List")){
				config.QuestionLists.Add (new QuestionListConfig(5,Difficulty.Easy,new List<string>{"Default"}));
				fold.Add(true);
			}
			
		}
		
		
	}
	
	
	
}