using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CharacterController2D : MonoBehaviour
{

	public GameObject[] MainPlayer;
	private GameObject currentPlayer, previousPlayer;
	public float threshold = 0.1f; // 滾輪速度閾值

	[SerializeField] private int iCharcaterCount = 0;
	public Camera cam;
	public LayerMask mask;

	[Range(0.0f, 100.0f)]
	public float m_Damping = 0.1f;

	[Range(0.0f, 100.0f)]
	public float m_Frequency = 100.0f;

	public bool m_DrawDragLine = true;
	public Color m_Color = Color.cyan;

	private TargetJoint2D m_TargetJoint;

	void Update()
	{
		ChangeCharacter();
		MagicDetect();
	}
	void ChangeCharacter()
	{
		if (Eammon.instance.foundDan == false)
		{
			currentPlayer = MainPlayer[0];
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
		//RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, layerMask);
		var collider = Physics2D.OverlapPoint(worldPoint, layerMask);

		if (collider != null)
		{
			String activeObj = collider.transform.name;
			GameObject hitObj = GameObject.Find(activeObj);

			if (iCharcaterCount == 0)
			{
                if (hitObj.GetComponent<ObjectController>().isFlowable)
                {
					//TimeControl
					float scroll = Input.GetAxis("Mouse ScrollWheel");

					if (Mathf.Abs(scroll) >= threshold)
					{
						currentPlayer.gameObject.SendMessage("MagicTimeReverseSpeedUp"); //跑動畫
						hitObj.SendMessage("ControlTime", scroll); //傳至ObjectController
					}

					//TimePause
					if (Input.GetMouseButtonDown(1))
					{
						Debug.Log("hit.collider.name:" + collider.name + "PauseTime");
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

						// Fetch the first collider.
						// NOTE: We could do this for multiple colliders.
						//var collider = hitObj.GetComponent<Collider2D>();
						if (!collider)
							return;

						// Fetch the collider body.
						var body = collider.attachedRigidbody;
						if (!body)
							return;

                        // Add a target joint to the Rigidbody2D GameObject.
                        if (!m_TargetJoint)
                        {
							m_TargetJoint = hitObj.AddComponent<TargetJoint2D>();
							m_TargetJoint.dampingRatio = m_Damping;
							m_TargetJoint.frequency = 1000;
						}
						// Attach the anchor to the local-point where we clicked.
						m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint(worldPoint);

					}
					// Update the joint target.
					if (m_TargetJoint)
					{
						m_TargetJoint.target =  worldPoint;

						// Draw the line between the target and the joint anchor.
						if (m_DrawDragLine)
							Debug.DrawLine(m_TargetJoint.transform.TransformPoint(m_TargetJoint.anchor), worldPoint, m_Color);
					}
					//if (Input.GetMouseButton(0))
					//{
					//	StartCoroutine(Drag(hit.collider));
					//}
				}
			}
			if (Input.GetMouseButtonUp(0))
			{
				Destroy(m_TargetJoint);
				m_TargetJoint = null;
				//return;
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


