using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCam : MonoBehaviour
{
	public Camera PlayerCam;
	public Camera MapView;

	public void OverHeadView()
	{
		PlayerCam.enabled = false;
		MapView.enabled = true;
	}
	public void FPSview()
	{
		PlayerCam.enabled = true;
		MapView.enabled = false;

	}
}
