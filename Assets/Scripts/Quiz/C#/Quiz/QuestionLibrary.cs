using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quiz{
	public class QuestionLibrary {
	
		private Question[] question_library = null;
		
		public QuestionLibrary(Question[] question_list){
			
			question_library = question_list;
			
		}
		
		public Question[] Questions{
			get{return question_library;}
		}
		
		public string[] GetSubjects(){
			
			List <string> subjects = new List <string>();
			                               
	    	foreach (Question question in question_library){
	    		if (!subjects.Contains(question.Subject))
				    subjects.Add (question.Subject);

			}
	       
	   		return subjects.ToArray();
	    }

	
		
		
		public bool IsEmpty{
			get{ return (question_library == null);}
		}
		
		public void FilterQuestions (ref List<Question> filtered_questions, Difficulty difficulty,string[] subjects){
			
			//List<Question> filtered_questions = new List<Question>();
			
			Debug.Log ("Filtering: " + difficulty);
			
			int count = 0;
			foreach (Question quest in question_library){
				
				if (quest.difficulty == difficulty && quest.HaveSubject(subjects)) 
				{
					quest.Available = false;
					filtered_questions.Add (quest);	
					count++;
				}
				
			} 
			
			Debug.Log("Found " + count + " questions of specified filter"); 

		}
		
		public void FilterQuestions (ref List<Question> filtered_questions, Difficulty difficulty,string subject){
			
			//List<Question> filtered_questions = new List<Question>();
			
			Debug.Log ("Filtering: " + difficulty + " " + subject + " in " + question_library.Length);
			
			int count = 0;
			foreach (Question quest in question_library){
			
				Debug.Log ("||" + quest.difficulty + "||" + difficulty + "||");
				Debug.Log ("||" + quest.Subject + "||" + subject + "||");
				
				if (quest.difficulty == difficulty && quest.Subject == subject) 
				{
					quest.Available = false;
					filtered_questions.Add (quest);	
					count++;
				}
				
			} 
			
			Debug.Log("Found " + count + " questions of specified filter"); 
			
		}
		
				
		
		public Question GetNextAvailable(Difficulty difficulty, string subject){
		
			foreach (Question quest in question_library){
				
				if (quest.difficulty == difficulty && quest.Subject == subject && quest.Available) 
				{
					quest.Available = false;
					return quest;	
				}
				
			}
			
			// if no questions found, return null
			return null;
		
		}
		
		public Question GetRandomQuestion(){
		
			int index = Random.Range (0, question_library.Length);
			
			return GetQuestion (index);
		}
		
		public Question GetQuestion (int index){
		
			question_library[index].Available = false;
			
			return question_library[index];
		}
		
		public void Reset(){
			foreach (Question quest in question_library){
				quest.Available = true;
			}
		}
		
	}
}
