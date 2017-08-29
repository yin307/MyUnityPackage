using System;


public interface IMission
{
	void reward();
	void addDone(int value);
	bool isDone();
	string getProgress();
}


