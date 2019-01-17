using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quiz{
	
	public enum Difficulty {Easy, Medium, Hard};

	public class Question {
		private bool _available = true;
		private string text;
		private Difficulty _difficulty;
		private List<string> answers = new List<string>();
		private List<string> hints = new List<string>();
		private string subject;
		//private List<string> subjects = new List<string>();
		//private List<Answer> answers = new List<Answer>();
		//private List<Hint> hints = new List<Hint>();
		//private List<Subject> subjects = new List<Subject>();
		
		private bool special;
				
		public bool Special{
			set{special = value;}
			get{return special;}
		}
		
		
		public string Text{
			set{text = value;}
			get{return text;}
		}
		
		public Difficulty difficulty{
			set{_difficulty = value;}
			get{return _difficulty;}
		}
		
		public string Subject{
			get{return subject;}
		}
		
		public bool Available{
			get{return _available;} set{_available = value;}
		}
		
		public int HintCount { get{return hints.Count;}}
		
		public int AnswerCount { get{return answers.Count;}}
		
		//public int SubjectCount { get{return subjects.Count;}}
		
		public string GetAnswer(int i){
			return answers[i];
		}
		
		public string GetHint(int i){
			if (hints.Count > i)
				return hints[i];
			return "";
		}
		
		
		
		public void AddAnswer(string text){
			//Answer n_answer = new Answer();
			//n_answer.Text = text;
			//n_answer.Index = AnswerCount;
			answers.Add(text);
		}
		
		public void AddHint(string text){
			//Hint n_hint = new Hint();
			//n_hint.Text = text;
			hints.Add(text);
		}
		
		public void AddSubject(string text){
			//Subject n_subject = new Subject();
			//n_subject.Text = text;
			subject = text;
		}
		
		public bool HaveSubject(string[] subjects){
		
			foreach (string s in subjects){
				if (s == subject) return true;
			}
			
			return false;
			
		
		}
		
//		public bool IsDifficulty(string[] other_subjects){
//			
//			int i = 0;
//			foreach (string subj in other_subjects){
//				
//				if (subj == subjects[i++].Text)
//					return true;
//				
//			}
//			
//			return false;
//			
//		}
		
		public void DoDebug(){
			
			Debug.Log("Question: " + Text);
			
			Debug.Log ("Difficulty: " + difficulty);
			
			Debug.Log ("Subject: " + subject);
			
			
			foreach (string answer in answers){
				Debug.Log ("Answer: " + answer);	
			}
			
			foreach (string hint in hints){
				Debug.Log ("Hint: " + hint);	
			}
			
			
		}
	}


}
