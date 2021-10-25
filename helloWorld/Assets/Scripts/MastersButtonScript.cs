using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastersButtonScript : MonoBehaviour
{
	public GameObject photonController;

	public void OnClick()
	{
		Debug.Log("Button click!");
		photonController.GetComponent<SampleScene>().PushMasterButton();
		transform.gameObject.SetActive(false);
	}
}
