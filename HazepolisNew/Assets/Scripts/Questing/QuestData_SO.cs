using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Quest Data")]
public class QuestData_SO : ScriptableObject
{
	[System.Serializable]
	public class QuestRequire
	{
		public string name;
		public int requireAmount;
		public int currentAmount;
	}

	[TextArea]
	public string questName;
	[TextArea]
	public string description;

	//�ݭn�T�إ��ȧ��������A�Anpc�~�|�����P������
	public bool isStarted;
	public bool isComplete;
	public bool isFinished;

	public List<QuestRequire> questRequires = new List<QuestRequire>();
	public List<InventoryUIItem> rewards = new List<InventoryUIItem>();

}