using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CharacterController2D : MonoBehaviour
{

	public GameObject[] MainPlayer;
	private GameObject currentPlayer, previousPlayer;
	//public bool foundDan = false;
	public float threshold = 0.1f; // 滾輪速度閾值

	[SerializeField] private int iCharcaterCount = 0;
	public Camera cam;
	public LayerMask mask;

	void Update()
	{
		ChangeCharacter();
		MagicDetect();
	}
	void CheckMeet()
    {
		currentPlayer = MainPlayer[0];
		//if (Eammon.instance.scenePassWord == "gate")
		//{
		//	foundDan = true;
		//}
	}
	void ChangeCharacter()
	{
		if (Eammon.instance.foundDan == false)
		{
			CheckMeet();
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				iCharcaterCount++;
				if (iCharcaterCount >= MainPlayer.Length)
				{
					iCharcaterCount = 0;
				}
				previousPlayer = currentPlayer;
				currentPlayer = null;
			}
		}

		switch (iCharcaterCount)
		{
			case 0: //Eammmon
				{
					if (currentPlayer == null) { currentPlayer = MainPlayer[0]; Debug.Log(currentPlayer.name); }
					currentPlayer.gameObject.SendMessage("Activate");
					if(previousPlayer != null)previousPlayer.gameObject.SendMessage("Deactivate");
                }
				break;
			case 1: //Dan
				{
					if (currentPlayer == null) { currentPlayer = MainPlayer[1]; Debug.Log(currentPlayer.name); }
                    currentPlayer.gameObject.SendMessage("Activate");
                    previousPlayer.gameObject.SendMessage("Deactivate");
				}
				break;
			default:
				break;
		}
	}

	void MagicDetect()
	{
		int layerMask = 1 << LayerMask.NameToLayer("Interactive");
		var worldPoint = GetMouseWorldPoint();
		RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, layerMask);
        //DegugDraw3Axis(worldPoint);

		if (Input.GetKey(KeyCode.E) && hit.collider != null)
		{
			String activeObj = hit.transform.name;
			GameObject hitObj = GameObject.Find(activeObj);
			//Debug.Log("hit.collider.name:" + hit.collider.name);

			if (iCharcaterCount == 0)
			{
                if (hitObj.GetComponent<ObjectController>().isFlowable)
                {
					//TimeControl
					float scroll = Input.GetAxis("Mouse ScrollWheel");

					if (Mathf.Abs(scroll) >= threshold)
					{
						//Debug.Log(scroll);
						currentPlayer.gameObject.SendMessage("MagicTimeReverseSpeedUp"); //跑動畫
						hitObj.SendMessage("ControlTime", scroll); //傳至ObjectController
					}

					//TimePause
					if (Input.GetMouseButtonDown(1))
					{
						Debug.Log("hit.collider.name:" + hit.collider.name + "PauseTime");
						currentPlayer.gameObject.SendMessage("MagicTimeStop"); //跑動畫
						hitObj.SendMessage("PauseTime"); //傳至ObjectController
					}
				}
			}

			if (iCharcaterCount == 1)
			{
				if (hitObj.GetComponent<ObjectController>().isDragable)
				{
					if (Input.GetMouseButtonDown(0)) //跑動畫
					{
						currentPlayer.gameObject.SendMessage("Magic");
						Debug.Log("hit.collider.name:" + hit.collider.name + "Drag");
					}
					if (Input.GetMouseButton(0))
					{
						StartCoroutine(Drag(hit.collider));
					}
				}
			}
		}
		
	}

	Vector3 GetMouseWorldPoint()
	{
		var mousePosition = Input.mousePosition;
		mousePosition.z = -cam.transform.position.z;
		var worldPoint = cam.ScreenToWorldPoint(mousePosition);
		return worldPoint;
	}
	IEnumerator Drag(Collider2D collider)
	{
		var obj = collider.gameObject;
		var dragPoint = obj.transform.position;
		var beginMousePoint = GetMouseWorldPoint();

		while (Input.GetMouseButton(0))
		{
			var worldPoint = GetMouseWorldPoint();
			obj.transform.position = dragPoint - beginMousePoint + worldPoint;

			yield return null;
		}
	}
	
}


