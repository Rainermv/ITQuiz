using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Quiz{
	public class QuestionReaderTxt {
	
		//private static List<string> subjects =  new List<string>();
//			
//			public static string[] Subjects{
//				get{return subjects.ToArray();}
//			}
//			
//			public static void AddSubject(string subject){
//			
//				if (!subjects.Contains(subject))
//					subjects.Add (subject);
//			}
//			
		
		
		public static Question[] ReadQuestions(TextAsset content)
		{
			List<Question> questions = new List<Question>();
		
			
			using (StringReader reader = new StringReader(content.text))
			{
			
				Question new_question =  null;// = new Question();
				
				string current_subject = "Default";
				Difficulty current_difficulty = Difficulty.Easy;
						
				string line;
				while ((line = reader.ReadLine()) != null) 
				{					
					string[] parts = line.Split (' ');
					
					for (int i=0; i<parts.Length; i++){
					
						
						if (parts[i] == "//"){ //|| parts[i] ==  "\t"){
							break;
						}			
						
						
						// SET DIFFICULTY
						if ((parts[i] == "#D"|| parts[i] == "\t#D") && new_question != null){
							
							
							if (parts[i+1] == "Easy"){
								current_difficulty = Difficulty.Easy;
							
							}
							else if (parts[i+1] == "Medium"){
								current_difficulty = Difficulty.Medium;
								
							}
							else if (parts[i+1] == "Hard"){
								current_difficulty = Difficulty.Hard;
								
							}
							
							
						}
						
						// ADD A NEW QUESTION
						if (parts[i] == "#Q" || parts[i] == "\t#Q" ) {
							new_question = new Question();
						
							new_question.Text = ReadSentence (parts, i+1);
							new_question.difficulty = current_difficulty;
							new_question.AddSubject(current_subject);

							questions.Add(new_question);
							
							//new_question.DoDebug();
							
													
						}
						
						// ADD A NEW ANSWER
						if ((parts[i] == "#A"|| parts[i] == "\t#A") && new_question != null){
							
							new_question.AddAnswer(ReadSentence(parts, i+1));
							
							
						}
						
						// ADD A NEW HINT
						if ((parts[i] == "#H"|| parts[i] == "\t#H") && new_question != null){
							
							new_question.AddHint(ReadSentence(parts, i+1));
	
						}
						
						
						// ADD A NEW SUBJECT
						if ((parts[i] == "#S"|| parts[i] == "\t#S")){
							
														
							current_subject = ReadSentence(parts,i+1);
							
													
//							string[] words = ReadWords(parts, i+1);
//							
//							foreach (string word in words){
//								new_question.AddSubject(word);
//								//AddSubject (word);
//							}
							
							
						}
						
						
					}
				}
			}
			
//			foreach (Question q in questions)
//				q.DoDebug();
			//questions[0].DoDebug();
			
			return questions.ToArray();
		}
		
		private static string[] ReadWords(string[] text, int ind){
			string[] words = new string[ text.Length - ind ];
			
			int i = 0;
			while (ind < text.Length){
				words[i++] = text[ind++];
			}
			
			return words;
			
		}
		
		private static string ReadSentence(string[] text,int ind){
			//int j = ind+1;
			string question = string.Empty;
			while (ind < text.Length){
				question += (text[ind]);
				if (ind != text.Length-1) question += " ";
				ind++;
			} 
			
			return question;
		}
	}
}
