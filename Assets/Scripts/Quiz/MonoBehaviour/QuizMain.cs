using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quiz{

	
	

	[AddComponentMenu("Atomic/Quiz/Main")]
	public class QuizMain : MonoBehaviour, Atomic.IEventListener {
	
		//public TextAsset question_file;
	
		//private List<Question> question_library = null;
		//private QuestionLibrary library = new QuestionLibrary();
		private List<Question> question_list = new List<Question>();
		private ActionButton[] button_array;
		private Widget[] widgets;
		
		//private QuestionContainer 		question_container = null;
		private AnswerButton[] 		answer_containers 	= null;
		private TextDisplay[]	displays			= null;
		
		private Data game_data = Data.GetInstance();
		
		private WidgetProgressBar progress_bar;

		private GameState state;
		
		private int option_remover;
		
		public int QuestionListSize{
			get{return question_list.Count;}
		}

			
		void Awake(){
			FindChildren ();
			
			
		}
		
		void FindChildren(){
			//question_container 	=  	GetComponentInChildren<QuestionContainer>();
			progress_bar 		= 	GetComponentInChildren<WidgetProgressBar>();
			button_array 		=	GetComponentsInChildren<ActionButton>();
			
			answer_containers 	= GetComponentsInChildren<AnswerButton>();
			displays 			= GetComponentsInChildren<TextDisplay>();
			
		}

		
		void ChangeState(GameState _state){
			
			state = _state;
			StateFunction(state.OnStart(this));
	
		}
		
		void StateFunction(GameState _state){
			
			if (_state != null){
				ChangeState(_state);
			}
			
		}

		// Use this for initialization
		void Start(){
			
			//LoadQuestions(questions);
			
			ChangeState (new GameStateSetup());
			//			
			InitProgressBar();
			
			StartQuestionTimer ();
			StartGameTimer();
			
			Report.Init();
			
			Atomic.EventManager.GetInstance().AddListener(this);
			
		}
		
		
		
		public void InitProgressBar(){
			progress_bar.Init(ref question_list);
		}
		
		void Update(){
		
			StateFunction(state.OnUpdate (this));
		
		}
	
		public void SetSpecial(int num){
			
			//num = Mathf.Clamp (num,0,question_list.Count);
			if (num >= question_list.Count)
				return;
			
			question_list[num].Special = true;
		
		}

		public void AddToList(int number_of_questions, Difficulty difficulty_filter, string[] subject_filter, bool uniform){
		
			List<Question> final_list = new List<Question>();
			
			Debug.Log ("Adding questions to list...");
			
			if (uniform){
				
				int questions_for_subject = number_of_questions / subject_filter.Length;
				
				Debug.Log ("QFS : " + questions_for_subject + " " + number_of_questions + "/" + subject_filter.Length);
				
				foreach (string subject in subject_filter){
					
					List<Question> temp_list = new List<Question>();
					
					game_data.Library.FilterQuestions (ref temp_list, difficulty_filter, subject);
					RandomizeQuestions (ref temp_list);
					CutQuestions(ref temp_list, questions_for_subject);
					
					final_list.AddRange(temp_list);
				}
			}
			
			else 
				game_data.Library.FilterQuestions (ref final_list, difficulty_filter, subject_filter);
				
			Debug.Log ("Final list size is " + final_list.Count);
						
			
			RandomizeQuestions (ref final_list);
			CutQuestions(ref final_list, number_of_questions);
			question_list.AddRange(final_list);
			
			
		 
		 } 
		 
		void CutQuestions(ref List<Question> questions, int size){
		 		
			for (int i = questions.Count - 1; i >= 0; i--)
			{
				if (i > size-1){
					questions[i] = null;
					questions.RemoveAt(i);
						
				}
				else {
					return;
				}
			}
		 
		 }
		 
		void RandomlyDistributeQuestionsBySubject(ref List<Question> questions, int total_number_of_questions){
		
			for (int i = 0; i < questions.Count; i++){
			
				
				
			}
		
		}
		
		
//		To shuffle an array a of n elements (indices 0..n-1):
//			for i from n − 1 downto 1 do
//				j ← random integer with 0 ≤ j ≤ i
//				exchange a[j] and a[i]
		void RandomizeQuestions(ref List<Question> questions){
			
			//List<Question> question_temp = new List<Question>();
			
			//for (int i = question_list.Count; i >= 1; i--){
			for (int i = 0; i < questions.Count; i++){
			
				int j = Random.Range(i,questions.Count);
				
				
				Question q_temp = questions[j];
				//q_temp.DoDebug();
				questions[j] = questions[i];
				questions[i] = q_temp;
			
			}
			
		
		}
		
		void ResetChildren(){
			//question_container.Reset();
			
			option_remover = 1;
			
			foreach (AnswerButton ans in answer_containers){
				ans.Reset();
			}
			
			foreach (TextDisplay dis in displays){
				dis.Reset();
			}
			//ResetButtons();
			
		
		}

		
		public void DisplayQuestion(int index){
		
			ResetChildren();
			
			if (question_list.Count > index && question_list[index] != null){
				
				
				//int index = Random.Range(0, asked_questions.Count);
				//question_container.Display(question_list[index]);
				DisplayChildren(question_list[index]);
				DisplayAnswers(question_list[index]);
			}
		
		}
		
		public void DisplayQuestion(Question new_question){
			ResetChildren();
			
			DisplayChildren(new_question);
			DisplayAnswers(new_question);
				
			
		}
		
		private void DisplayChildren(Question question_object){
			
			foreach (TextDisplay dis in displays){
				dis.DisplayObject(question_object);
			}
		}
		
		private void DisplayAnswers(Question question_object){
			for (int i = 0; i < answer_containers.Length; i++){
				
				answer_containers[i].Text = question_object.GetAnswer(i);
				answer_containers[i].option = i;
				
			}
			
			RandAnswers();
			
			
		}
		

		
		private void RandAnswers(){
			
			for (int i = 0; i < answer_containers.Length; i++){
				
				int j = Random.Range(i,answer_containers.Length);
				
				
				AnswerButton a_temp = answer_containers[j];
				//q_temp.DoDebug();
				answer_containers[j] = answer_containers[i];
				answer_containers[i] = a_temp;
				
			}
			
		}
		
		public void Answer(int ans){
			//Debug.Log ("Right Anser = " + question_container.RightAnswer);
			SendMessageUpwards("Input", (ans== 0? Action.AnswerRight : Action.AnswerWrong ));			
		}

		public void Input(Action act){
			
			StateFunction(state.OnInput(this, act));
		
		}
		
				
		public void ActionAnswerRight(){
			
			int question_index = game_data.Progress;
			
			
				
			if (question_list[question_index].Special == true) 
				game_data.Tokens += 1;
				
			
			game_data.Points+= 100;
			game_data.CountSubject(question_list[question_index].Subject);
			game_data.RightAnswers++;

		}

		
		public void ActionAnswerWrong(){
			game_data.Points -= 50;
			game_data.WrongAnswers++;
		}

		public void ActionSkip(){
		
			if (game_data.SubtractTokens(1)){		
			    SkipQuestion();
			    game_data.SkipActions++;
			    }

		}
		
		public void ActionRemove(){
			if (game_data.SubtractTokens(1)){	
				DisableAnswer();
				game_data.RemoveActions++;
				}
			
		}
		
		private void DisableAnswer(){
			
			for (int i = 0; i < answer_containers.Length; i++){
				if (answer_containers[i].option == option_remover){
					answer_containers[i].Enable (false);
					
				}
				
			}
			
			option_remover++;
			
		}
		
		public void ActionHint(){
			if (game_data.SubtractTokens(1)){		
				SetDisplayEnabled(DisplayType.Hint, true);
				game_data.HintActions++;
				}
		}
		
		
		void SkipQuestion(){
			Difficulty diff = question_list[game_data.Progress].difficulty;
			string subj = question_list[game_data.Progress].Subject;

			// try to find a similar question with the same difficulty
			Question next_question = game_data.Library.GetNextAvailable(diff,subj);
			
			if (next_question != null)
				DisplayQuestion(next_question);
			// if such question cannot be found, display a random question
			else
				DisplayQuestion (game_data.Library.GetRandomQuestion());
		}
		
		public void Advance(){
			game_data.Advance();
			//NextQuestion();
		}
		
		public void SwitchSprites(){
			foreach (AnswerButton answer_container in answer_containers){
				answer_container.ChangeSpriteAnswer(answer_container.option == 0);
			}
		}
		
		public void SetButtonEnable(Action action_to_enable, bool enable){
			foreach (ActionButton but in button_array){
				if (but.action == action_to_enable)
					but.SetGameObjectActive(enable);
			}
		}
		
		public void SwitchButtons(bool button_switch){
			
			SetButtonEnable(Action.Hint, 	!button_switch);
			SetButtonEnable(Action.Remove, 	!button_switch);
			SetButtonEnable(Action.Skip, 	!button_switch);
			SetButtonEnable(Action.Next, 	 button_switch);
			
			//button_switch = !button_switch;
			
		}
		
		public void DisableButtons(){
		
			SetButtonEnable(Action.Hint, false);
			SetButtonEnable(Action.Remove, false);
			SetButtonEnable(Action.Skip, false);
			SetButtonEnable(Action.Next, false);
		}
		
		public void DisplayFinish(){
		
			DisableButtons ();	
			//question_container.DisplayFinish();
			
			for (int i = 0; i < answer_containers.Length; i++){
				answer_containers[i].Enable(false);
				answer_containers[i].Text = "";
			}
			
			foreach (TextDisplay dis in displays){
				dis.DisplayNull();
			}
			
			//GameObject.FindGameObjectWithTag("Finish").SendMessage("Enable", true);
			FindObjectOfType<EndGameSpawner>().SendMessage("Enable",true);
		
		}
		
		public bool IsEndGame(){
		
			return (game_data.Progress >= game_data.MaxProgress);
		
		}
		
		public void SetDisplayEnabled(DisplayType type, bool enabled){
			foreach (TextDisplay dis in displays){
				dis.SetEnabled(type, enabled);
			}
		}
		
		public void ShowAnswer(){
			SetDisplayEnabled(DisplayType.Answer, true);
		}
		
		public void StartQuestionTimer(){
			StartCoroutine(TickQuestionTimer());
		}
		
		public void StartGameTimer(){
			StartCoroutine(TickStartGameTimer());
		}
		
		public void Pause(bool pause){
			game_data.Pause = pause;
		}
		
		public void ResetQuestionTimer(){
			game_data.QuestionTimer = game_data.QuestionTimerLimit;
		}
		
		public bool CheckTimer(){
			return (game_data.QuestionTimer > 0);
		}
		
		IEnumerator TickQuestionTimer(){
			
			while(true){
				
				if (!game_data.Pause)
					game_data.QuestionTimer -= Time.deltaTime;
				
				yield return 0;
				
			}

		}
		
		IEnumerator TickStartGameTimer(){
			
			while(true){
				
				if (!game_data.Pause)
					game_data.GameTimer += Time.deltaTime;
				
				yield return 0;
				
			}
			
		}
		
		void Atomic.IEventListener.ListenEvent(Atomic.ButtonEvent ev){
		
			
			StateFunction(state.OnInput(this, ev));
		}
		
		

				
	}
}
