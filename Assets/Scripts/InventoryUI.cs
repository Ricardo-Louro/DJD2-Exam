using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private int            spacing; 
    [SerializeField] private GameObject     inventoryIcon;
    private List<GameObject>                UIList; 
    private PlayerInventory                 playerInventory;
    public bool                             updateUI;

    private void Start()
    {
        UIList = new List<GameObject>();
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        updateUI = true;
    }

    private void Update()
    {
        if(updateUI)
        {
            if(UIList.Count > 0)
            {
                int count = UIList.Count;
                for(int i = 0; i < count; i++)
                {
                    Destroy(UIList[i]);
                }
                UIList.Clear();
            }

            if(playerInventory._spriteInventory.Count > 0)
            {
                int index = 0;

                foreach(Sprite sprite in playerInventory._spriteInventory)
                {
                    GameObject icon = Instantiate(inventoryIcon, gameObject.transform);
                    icon.GetComponent<Image>().sprite = sprite;
                    Vector3 currentPos = icon.GetComponent<RectTransform>().anchoredPosition;
                    icon.GetComponent<RectTransform>().anchoredPosition = new Vector3(currentPos[0] + spacing * index,
                                                                                      currentPos[1],
                                                                                      currentPos[2]);
                    UIList.Add(icon);

                    index++;
                }
            }
            updateUI = false;
        }
    }
}
