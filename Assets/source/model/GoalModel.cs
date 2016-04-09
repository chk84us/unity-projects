using System.Collections;
using System;

[Serializable]
public class GoalModel {

	public int id;
	public string name;
	public bool completed;
	public int totalTasks;
	public int completedTasks;

	public GoalModel(int id, string name, int totalTasks, int completedTasks, bool completed) {
		this.id = id;
		this.name = name;
		this.totalTasks = totalTasks;
		this.completedTasks = completedTasks;
		this.completed = completed;
	}

}
