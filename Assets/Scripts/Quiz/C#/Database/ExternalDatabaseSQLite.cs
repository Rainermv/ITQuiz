using UnityEngine;
using System.Data;
using System.Collections;
using System.Collections.Generic;
//using Mono.Data.SqliteClient;
//using Finisar.SQLite;
using Mono.Data.Sqlite;


namespace Quiz{
public class ExternalDatabaseSQLite : ExternalDatabase {

		string table_name 			= "QuizResults";
		string file_name			= "Results.db";
		
		//IDbCommand _command;
		
		
//		private SQLiteConnection sql_connection;
//		private SQLiteCommand sql_command;
				
		string sql;
		
		//string table_name = "QuizTable";
		//IDbCommand _command 		= _connection .CreateCommand();
				
		
		public override void Open(Data data){
		
//			sql_connection = new SQLiteConnection
//				("Data Source=" + table_name + ".db;Version=3;New=False;Compress=True;"); 
//			
//						
//			sql_connection.Open(); 
							
			// BUILDING TABLE
			string name 			= "name VARCHAR(20), ";
			string score 			= "score INT, ";
			string progress			= "last_question INT, ";
			string tokens 			= "tokens INT, ";
			string skip 			= "skips INT, ";
			string hint 			= "hints INT, ";
			string remove			= "removes INT, ";
			string answers			= "answers INT, ";
			string right_answers	= "right_answers INT, ";
			string wrong_answers	= "wrong_answers INT, ";
			string total_time 		= "total_game_time FLOAT, ";
			
			string[] subjects 		= data.Subjects;
						
			sql = BuildTableSql (name,score,progress,tokens, skip, hint, remove, answers,right_answers,wrong_answers,total_time,subjects);
			
			IDbConnection _connection;
			string connection_string = "URI=file:" + Application.dataPath + "/" + file_name;
			Debug.Log (connection_string);
			_connection = (IDbConnection) new SqliteConnection(connection_string);
			_connection.Open(); 
			
			IDbCommand IDbCommand = _connection.CreateCommand();
			
			IDbCommand.CommandText = sql;
			Debug.Log ("Execution command: " + sql);
			IDbCommand.ExecuteNonQuery();

//			sql_command = sql_connection.CreateCommand(); 
//			sql_command.CommandText = sql; 
//			sql_command.ExecuteNonQuery(); 
			
			_connection.Close(); 
		
			
			
		}
		
		private string BuildTableSql(string n, string sc, string p, string t, string s, string h, string r, string a, string ra, string wa, string tt, string[] subjects){
			
			string sql = "create table if not exists " + table_name + " (" + n + sc + p + t + s + h + r + a + ra + wa + tt;
			
			int i = 0;
			foreach (string subject in subjects){
				sql += subject + " INT";
				
				if (i++ < subjects.Length-1) sql+= ", ";
				else sql += " )"; 
			}
			
			return sql;
		
		}
		
		
		public override void SaveData (Data data)
		{
			string name			= data.PlayerName;
			int score			= data.Points;
			int tokens			= data.Tokens;
			int skips			= data.SkipActions;
			int hints			= data.HintActions;
			int removes			= data.RemoveActions;
			int last_question	= data.Progress;
			int answers			= data.RightAnswers + data.WrongAnswers;
			int right_answers	= data.RightAnswers;
			int wrong_answers	= data.WrongAnswers;
			
			float total_game_time 	= data.GameTimer;
						
			List<SubjectCounter> subject_counters = data.SubjectCounters;
			
			
			string sql = "INSERT INTO " + table_name + "(name, score, tokens, skips, hints, removes, last_question, answers, right_answers, wrong_answers, total_game_time";
			
			int i = 0;
			foreach (SubjectCounter subject_counter in subject_counters){
				if (i == 0) sql+= ", ";
				
				sql += subject_counter.subject;
				
				if (i < subject_counters.Count-1) sql+= ", ";
				
				i++;
			
			}
			sql += ") "; 
			
			
			sql += "VALUES (" + "'" + name + "', " + score + ", " + tokens + ", " + skips + ", " + hints 
				+ ", "+ removes + ", " + last_question + ", " + answers + ", " + right_answers 
				+ ", " + wrong_answers + ", " + total_game_time;
					
					
			i = 0;
			foreach (SubjectCounter subject_counter in subject_counters){
				if (i == 0) sql+= ", ";
				
				sql += subject_counter.count;
				
				if (i < subject_counters.Count-1) sql+= ", ";
				
				i++;
	
			}
			
			sql += ") ";
			
			UnityEngine.Debug.Log(sql);
			
			IDbConnection _connection;			
			_connection = (IDbConnection) new SqliteConnection("URI=file:" + Application.dataPath + "/" + file_name);
			_connection.Open(); 
			
			IDbCommand IDbCommand = _connection.CreateCommand();
			
			IDbCommand.CommandText = sql;
			IDbCommand.ExecuteNonQuery();

			_connection.Close(); 
			
//			
//			sql_connection = new SQLiteConnection
//				("Data Source=" + table_name + ".db;Version=3;New=False;Compress=True;"); 
//			
//			
//			sql_connection.Open(); 
//			
//			sql_command = sql_connection.CreateCommand(); 
//			sql_command.CommandText = sql; 
//			sql_command.ExecuteNonQuery(); 
//			
//			sql_connection.Close(); 
//			
//			//			_command.CommandText = sql;
//			_command.ExecuteNonQuery();

		}
		
		public override void Close(){
		
			//_reader.Close();
			//_reader = null;
//			
//			if (_command != null){
//				_command.Dispose();
//				_command = null;
//			}
//			if (_connection != null){
//				_connection .Close();
//				_connection = null;
//			}
		
		}
		
		
	}
}