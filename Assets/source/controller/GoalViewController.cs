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

	private List<float> percentages;
	private List<GameObject> goalCellList;

	public float transitionSpeed = 1f;
	public float startTime = 1.0f;

	void Start () {
		goalCellList = new List<GameObject> ();
		percentages = new List<float> ();
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
			percentages.Add (completedPercent);
//			getProgressImage (goalCell).fillAmount = completedPercent;
//			getCompletedProgress (goalCell).text = (completedPercent * 100).ToString ("F") + "%";
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
		var count = 0;
		foreach (var item in goalCellList) {
			var t = 0f;
			t += Time.deltaTime * 1; //This will increment tParam based on Time.deltaTime multiplied by a speed multiplier
			getProgressImage (item).fillAmount = Mathf.Lerp (0f, percentages[count++], (Time.time - startTime) * transitionSpeed);
			getProgressImage (item).color = Color.Lerp(Color.red, Color.green, percentages[count-1]);
			getCompletedProgress (item).text = (Mathf.Lerp(0, percentages[count-1], (Time.time - startTime) * transitionSpeed)*100).ToString ("F") + "%";
		}

//		RenderSettings.skybox.SetFloat("_Exposure", Mathf.Sin(Time.time * Mathf.Deg2Rad * 100) + 1);
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
