using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;

public class UIKeys : MonoBehaviour {

	public PostProcessingProfile[] PPProfiles;
	public GameObject FPC;

	// Use this for initialization
	void Start () {

		PostProcessingBehaviour ppb = Camera.main.GetComponent<PostProcessingBehaviour>();
		ppb.profile = PPProfiles[0];
		RenderSettings.fogDensity = 0.05f;
		RenderSettings.fogColor = new Color (0.0156f, 0.0470f, 0.055f,1f);
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Screen.fullScreen = false;
			Cursor.visible = true;
		}


	}

}
