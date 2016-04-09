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
		JsonIo io = new JsonIo ();
		setupFilePaths ();
		GoalListWrapperModel goalsListWrapper = new GoalListWrapperModel();
		List<GoalModel> goalList = new List<GoalModel> ();
		goalList.Add (new GoalModel (1, "Test goal 1", 10, 3, false));
		goalList.Add (new GoalModel (2, "Test goal 2", 1, 1, false));
		goalList.Add (new GoalModel (3, "Test goal 3", 5, 0, false));
		goalsListWrapper.goalList = goalList;
		string fullFilePath = string.Join(Path.DirectorySeparatorChar.ToString(), paths);
		io.SerializeData(goalsListWrapper, fullFilePath);
	}

	private void setupFilePaths() {
		paths = new string[3];
		paths [0] = Application.dataPath;
		paths [1] = dataFolderName;
		paths [2] = fileName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
