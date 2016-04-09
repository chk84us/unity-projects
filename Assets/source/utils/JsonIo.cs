using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace utils {

	public class JsonIo {
		private const string fileName = "goals.json";
		private const string dataFolderName = "data";
		string[] paths;

		public void SerializeData () {
			
			setupFilePaths ();
			GoalListWrapperModel goalsListWrapper = new GoalListWrapperModel();

			List<GoalModel> goalList = new List<GoalModel> ();
			goalList.Add (new GoalModel (1, "Test goal 1", 10, 3, false));
			goalList.Add (new GoalModel (2, "Test goal 2", 1, 1, false));
			goalList.Add (new GoalModel (3, "Test goal 3", 5, 0, false));

			goalsListWrapper.goalList = goalList;
			string fullFilePath = string.Join(Path.DirectorySeparatorChar.ToString(), paths);

			string jsonGoalList = JsonUtility.ToJson(goalsListWrapper, true);
			File.WriteAllText (fullFilePath, jsonGoalList);
		}

		public void DeserializeData () {
			//TODO 
		}

		private void setupFilePaths() {
			paths = new string[3];
			paths [0] = Application.dataPath;
			paths [1] = dataFolderName;
			paths [2] = fileName;
		}
	}
}
