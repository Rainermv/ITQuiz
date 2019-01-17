using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Quiz{
	
	[System.Serializable]
	public class QuestionListConfig{
	
		public int 			ListSize;
		public Difficulty 	ListDifficulty;
		public bool			Uniform;
		public List<string>	ListSubjects = new List<string>();
				
		public QuestionListConfig(int LSize, Difficulty LDiff, List<string> LSubj){
		
			this.ListSize 		= LSize;
			this.ListDifficulty	= LDiff;
			this.ListSubjects	= LSubj;
			
		}
	
	}

	
}
