﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehaviour : MonoBehaviour, IPointerExitHandler
{
	public void OnPointerExit (PointerEventData eventData) 
	{
		gameObject.SetActive (false);
		gameObject.SetActive (true);
	}

	//This was the only way I found to deactivate the animation in absolutely no delay with another animation already on - Zx
}