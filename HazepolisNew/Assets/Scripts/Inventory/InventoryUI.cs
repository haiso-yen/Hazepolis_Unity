using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InventoryUI : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    public RectTransform bagPanelAni;
    int animaflag = 0;
    InventoryUIItem itemContainer { get; set; }
    //bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        //inventoryPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && animaflag == 0)
        {
            //menuIsActive = !menuIsActive;
            //inventoryPanel.gameObject.SetActive(menuIsActive);
            bagapear();
            animaflag++;
        }
        else if (Input.GetKeyDown(KeyCode.B) && animaflag == 1) { bagdissapear(); animaflag--; }
    }
    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
        emptyItem.transform.localScale = new Vector3(1, 1, 1);
    }
    //======================animation=========================
    public void bagdissapear()
    {
        bagPanelAni.DOAnchorPos(new Vector2(45, -1200), 0.23f);
    }
    public void bagapear()
    {
        bagPanelAni.DOAnchorPos(new Vector2(45, -5), 0.15f);
    }
}
