using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz{

	public class Data {
	
		private QuestionLibrary library = null;
	
		private QuizConfig config;
		
		private string player_name;
	
		private int points;
		private int tokens;
		private int progress;
		private int right_answers;
		private int wrong_answers;
		
		private int skip_actions;
		private int hint_actions;
		private int remove_actions;
		
		private float question_timer;
		private float question_time_limit;
		
		private float game_timer;
		
		private bool show_subject_score;
		
		private List<SubjectCounter> subject_counters = new List<SubjectCounter>();
		private string[] subjects;
		//private List<int> subject_counter;
		
		private bool pause;
		
		private int _max_progress;
				
		// SINGLETON
		private static Data instance;
		
		private Data(){
		
			Points = 0;
			tokens = 0;
			progress = 0;
			//_max_progress = -1;
			right_answers = 0;
			wrong_answers = 0;
			
			
			player_name = "Anonymous";
		}
	
		public static Data GetInstance(){
			if (instance == null){
				instance = new Data();
			}
			
			
			return instance;
		}
		
		//////////
		
		// PUBLIC 
		
		public string PlayerName{ get {return player_name;} 	set {player_name = value;}}					
		public int Points		{ get {return points;} 			set {points = Mathf.Clamp(value,0,10000);}}
		public int Tokens		{ get {return tokens;} 			set {tokens = value;}}
		public int Progress		{ get {return progress;} 		set {progress = value;}}
		public int MaxProgress	{ get {return _max_progress;} 	set {_max_progress = value;}}
		public int RightAnswers	{ get {return right_answers;} 	set {right_answers = value;}}
		public int WrongAnswers	{ get {return wrong_answers;} 	set {wrong_answers = value;}}
		
		public int SkipActions	{ get { return skip_actions;}	set{skip_actions = value;}}
		public int HintActions	{ get { return hint_actions;}	set{hint_actions = value;}}
		public int RemoveActions{ get { return remove_actions;}	set{remove_actions = value;}}
		
		
		public float QuestionTimer		{ get {return question_timer;}		set {question_timer = value;}}
		public float QuestionTimerLimit	{ get {return question_time_limit;} 		set {question_time_limit = value;}}
		public float GameTimer		{ get {return game_timer;}		set {game_timer = value;}}
		public bool Pause		{ get {return pause;} 			set {pause = value;}}
		public string[] Subjects{ get {return subjects;}		set {subjects = value;}}
		
		public bool ShowSubjectScore { get {return show_subject_score;}}
		
		public QuizConfig GetConfig(){
			return config;
		}
		
		public QuestionLibrary Library{
			get{return library;}
			//set{library = value;}
			
		}
		
		public List<SubjectCounter> SubjectCounters{
			get{return subject_counters;}
		}
		
		public SubjectCounter GetSubjectCounter(int index){
		
			if (subject_counters.Count > index)
				return subject_counters[index];
			return null;
		}
		
		
		// Init the library before anything
		public void InitLibrary(Question[] question_list){
			
			library = new QuestionLibrary(question_list);
			
			subjects = library.GetSubjects();
			SetSubjectcounter(subjects);
			
			//_max_progress = question_list.Length-1;
		}	
		
		// config the match data before starting a match
		public void SetConfig(QuizConfig c){
			
			config = c;
			
			//_max_progress = config.GetTotalQuestions();
			question_time_limit = config.TimeLimit;
			tokens = config.Tokens;
			
			show_subject_score = c.ShowSubjectScore;
			
			//DebugSubjects ();
			
			//			foreach (QuestionListConfig qlistconfig in c.QuestionLists){
			//				AddSubjects(qlistconfig.ListSubjects.ToArray());
			//			}
		}
					
		public void Advance(){
		Debug.Log ("Advance " + progress + "/" + _max_progress);
			if (progress < _max_progress)
				progress++;
	
		}
		
//		
		public void SetSubjectcounter(string[] subjects){
		
			foreach (string subj in subjects){
			
				subject_counters.Add (new SubjectCounter(subj));
			}		
		}		
		
		public void CountSubject(string subject){
		
			foreach (SubjectCounter subj_counter in subject_counters){
				if (subject == subj_counter.subject){
					subj_counter.count++;
					return;
				}
			}
						
		}
		
		public void CountSubjects(string[] subjects){
			
			foreach (string subj in subjects){
				CountSubject (subj);
			}
			
		}
		
		private void ResetSubjectCounters(){
			
			foreach (SubjectCounter counter in subject_counters){
			
				counter.count = 0;
			
			}
			
		}
		
		public void AddTokens(int value){
			tokens += value;
		}
		
		public bool SubtractTokens(int value){
			if (tokens >= value){
				tokens -= value;
				return true;
			}
			
			return false;
		}
		
		public void UpdateScore(){
			Points = (right_answers*100) - (wrong_answers*50) + (tokens * 25);
		}
		
		public static void Reset(){
			instance.Points = 0;
			instance.tokens = 0;
			instance.progress = 0;
			//_max_progress = -1;
			instance.right_answers = 0;
			instance.wrong_answers = 0;
			instance.player_name = "Anonymous";
			
			instance.GameTimer = 0;
			
			//instance.subject_counters.Clear();
			instance.ResetSubjectCounters();
			instance.library.Reset();
			
			Report.Finish();
		}
		
		// PRIVATE
		
//		private bool SubjectExists(string subj){
//			foreach (SubjectCounter subj_counter in subject_counters)
//				if (subj == subj_counter.subject)
//					return true;
//			
//			return false;
//			
//			
//		}
		
//		private string[] GetSubjects(){
//		
//			return QuestionReader.Subjects;
//			
//		}
		
		private void DebugSubjects(){
			
			Debug.Log ("Debugging subjects");
			foreach (SubjectCounter counter in SubjectCounters){
				Debug.Log (counter.subject);
			}

		}
		
	
	
	}
	
}
