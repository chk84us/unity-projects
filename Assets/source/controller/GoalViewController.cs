using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using utils;
using System.IO;

public class GoalViewController : MonoBehaviour {

	public GameObject GoalCellPrefab;

	string[] paths;
	private const string fileName = "goals.json";
	private const string dataFolderName = "data";

	private List<string> percentages;
	private List<GameObject> goalCellList;

	void Start () {
		percentages = new List<string> ();
		goalCellList = new List<GameObject> ();

		GoalListWrapperModel goals = getObjectFromJson();
		foreach(GoalModel g in goals.goalList) {
			GameObject goalCell = Instantiate<GameObject> (GoalCellPrefab);
			goalCell.name = "Goal" + g.id;
			goalCell.transform.parent = this.transform;
			goalCell.transform.localScale = Vector3.one;
			goalCellList.Add (goalCell);

			getObjectiveTextComponent (goalCell).text = g.id + ": " + g.name;
			transform.Find (goalCell.name + "/Objective/objectiveText").GetComponent<Text> ().fontSize = 30;
			float completedPercent = ((float)g.completedTasks/ (float)g.totalTasks);

			getProgressImage (goalCell).fillAmount = completedPercent;
			getCompletedProgress (goalCell).text = (completedPercent * 100).ToString ("F") + "%";
		}
	}

	Text getObjectiveTextComponent (GameObject goalCell){
		return transform.Find (goalCell.name + "/Objective/objectiveText").GetComponent<Text> ();
	}

	Image getProgressImage (GameObject goalCell){
		return transform.Find (goalCell.name + "/Objective/progress").GetComponent<Image> ();
	}

	Text getCompletedProgress (GameObject goalCell){
		return transform.Find (goalCell.name + "/Objective/progress/fill/completedPercent").GetComponent<Text> ();
	}

	void Update () {
	
	}

	private GoalListWrapperModel getObjectFromJson() {
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
}
