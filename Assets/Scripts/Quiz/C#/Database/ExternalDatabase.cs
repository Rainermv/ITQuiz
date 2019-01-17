using System.Collections;


namespace Quiz{
public abstract class ExternalDatabase {

	public abstract void Open(Data data);
	
	public abstract void SaveData(Data data);
	
	public abstract void Close();
}
}
