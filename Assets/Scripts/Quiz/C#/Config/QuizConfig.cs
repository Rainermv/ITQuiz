using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quiz{
	[System.Serializable]
	public class QuizConfig{
		
		private int 		tokens 				= 5; 	
		private float 		time_limit			= 61; 		
		private int[]		special_questions	= new int[]{3,7,11}; 
		
		[SerializeField]
		private bool 		show_subject_score;
		
		public List<QuestionListConfig> QuestionLists = new List<QuestionListConfig>();
		
		public int 		Tokens 				{get{return tokens;}}
		public float 	TimeLimit  			{get{return time_limit;}}
		public int[] 	SpecialQuestions 	{get{return special_questions;}}
		
		public bool 	ShowSubjectScore 	{set{show_subject_score = value;} 
											 get{return show_subject_score;}}
		
		public int GetTotalQuestions(){
			int count = 0;
			foreach (QuestionListConfig ql in QuestionLists)
				count += ql.ListSize;
			return count;
			
		}
				
		
		
		
}
}
