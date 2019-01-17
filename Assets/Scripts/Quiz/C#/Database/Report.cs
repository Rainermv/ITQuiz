//using UnityEngine;
using System.Collections;

namespace Quiz{
	public static class Report {
		
		private static ExternalDatabase db = new ExternalDatabaseSQLite();
		
		//private static ExternalDatabase db = new ExternalDatabaseSQLitePlugin();
		
		public static void Init(){
			
			if (db != null)
				db.Open (Data.GetInstance());
			
		}
		
		public static void Save(){
			
			if (db != null)
				db.SaveData(Data.GetInstance());
		}
		
		public static void Finish(){
			
			if (db != null)
				db.Close();
		}
		
		//public abstract void 
	}
}
