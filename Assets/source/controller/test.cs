using UnityEngine;
using System.Collections.Generic;
using utils;
using System.IO;

public class test : MonoBehaviour {

	private const string fileName = "goals.json";
	private const string dataFolderName = "data";
	string[] paths;

	// Use this for initialization
	void Start () {

//		Serialization example
//		new JsonIo ().SerializeData(createTestGoals(), getFilePath());

//		Deserialization example
		foreach (GoalModel g in readData().goalList) {
			Debug.Log ("ID = " + g.id);
			Debug.Log ("Name = " + g.name);
			Debug.Log ("Completed = " + g.completed);
		}
	}

	private GoalListWrapperModel createTestGoals() {
		List<GoalModel> goalList = new List<GoalModel> ();
		goalList.Add (new GoalModel (1, "Test goal 1", 10, 3, false));
		goalList.Add (new GoalModel (2, "Test goal 2", 1, 1, false));
		goalList.Add (new GoalModel (3, "Test goal 3", 5, 0, false));

		GoalListWrapperModel goalsListWrapper = new GoalListWrapperModel();
		goalsListWrapper.goalList = goalList;
		return goalsListWrapper;
	}

	private GoalListWrapperModel readData() {
		return new JsonIo ().
			DeserializeData<GoalListWrapperModel>(File.ReadAllText(getFilePath()));
	}

	private string getFilePath() {
		paths = new string[3];
		paths [0] = Application.dataPath;
		paths [1] = dataFolderName;
		paths [2] = fileName;
		return string.Join(Path.DirectorySeparatorChar.ToString(), paths);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
