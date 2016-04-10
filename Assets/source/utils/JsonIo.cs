using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace utils {

	public class JsonIo {
		
		public void SerializeData (System.Object dataObject, string path) {
			File.WriteAllText (path, JsonUtility.ToJson(dataObject, true));
		}

		public T DeserializeData<T> (string json) {
			return JsonUtility.FromJson<T>(json);
		}
	}
}
