using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Quiz{

	[AddComponentMenu("Atomic/Quiz/Out Game/Question Loader")]
	public class QuestionLoader : MonoBehaviour {
		
		public bool LoadBySql;
		
		public TextAsset questions_txt;
		public string sql_table;
		
		private Data game_data;
		
		//private Question[] question_list;
		
	
		// Use this for initialization
		void Start () {
			game_data = Data.GetInstance();
			
			//if (questions_txt != null)
			//{
				if (game_data.Library == null){
				
					if (LoadBySql == true) 
							game_data.InitLibrary(QuestionReaderSql.ReadQuestions(sql_table));
					else
							game_data.InitLibrary(QuestionReaderTxt.ReadQuestions(questions_txt));
						//
				}
				
				return;
			//}
			//else
		//		Debug.LogError("Question file not referenced in Loader");
		}
//		
//		void Update(){
//			
//			if (Application.loadedLevelName == "Game"){
//			
//				Game game_component = GameObject.FindGameObjectWithTag("Game").AddComponent<Game>();
//				game_component.Init (question_list);
//			
//			}
//		
//		}
		
		
		
	}
}