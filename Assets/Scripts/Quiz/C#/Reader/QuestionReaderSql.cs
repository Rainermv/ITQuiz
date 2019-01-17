using UnityEngine;
using System.Data;
using System.Collections;
using System.Collections.Generic;
//using Mono.Data.SqliteClient;
//using Finisar.SQLite;
using Mono.Data.Sqlite;

namespace Quiz{
	public static class QuestionReaderSql{
	
		public static Question[] ReadQuestions(string table_name){
		
			List<Question> questions = new List<Question>();
			
			string sql = "select * from Questions order by Question";
			
			IDbConnection _connection;			
			_connection = (IDbConnection) new SqliteConnection("URI=file:" + Application.dataPath + "/sampledb.sqlite");
			_connection.Open(); 
			
			IDbCommand IDbCommand = _connection.CreateCommand();
			
			IDbCommand.CommandText = sql;
			IDataReader _reader = IDbCommand.ExecuteReader();
			
			_connection.Close(); 
			

			while (_reader.Read()){
			
				//Debug.Log("Question: " + _reader["Question"] + "\t" + "Subject: " + _reader["Subject"]);
				
				Question quest = 	new Question();
				
				quest.Text =		_reader["Question"] as string;
				quest.AddSubject(	_reader["Subject"] as string);
				quest.AddHint(		_reader["Hint"] as string);
				quest.difficulty = 	(Difficulty)_reader["Difficulty"];
				
				quest.AddAnswer(	_reader["Answer 1"] as string);
				quest.AddAnswer(	_reader["Answer 2"] as string);
				quest.AddAnswer(	_reader["Answer 3"] as string);
				quest.AddAnswer(	_reader["Answer 4"] as string);
				
				questions.Add (quest);
				
			}
//			
//			if (_command != null){
//				_command.Dispose();
//				_command = null;
//			}
//			if (_connection != null){
//				_connection .Close();
//				_connection = null;
//			}			
			
			Debug.Log (questions.Count);
			
			return questions.ToArray();
			
			
			
		
		}
	}

}
