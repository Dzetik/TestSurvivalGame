using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class InventoryManager : MonoBehaviour
{
    public bool isOpend;
    public GameObject UIPanel;
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public int distance;
    public Transform playerPoint;
    public GameObject CraftPanel;
    public bool isOpendCraft;

    void Start()
    {
        CraftPanel.SetActive(false);
        for (int i = 0; i < InventoryPanel.childCount; i++)
        {
            slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
        }
        UIPanel.SetActive(false);
    }

    void Update()
    {
        /*if (isOpendCraft && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F)))
        {
            isOpendCraft = !isOpendCraft;
            isOpend = !isOpend;
            UIPanel.SetActive(false);
            CraftPanel.SetActive(false);
            Debug.Log("Крафт закрыт");
            return;
        }*/

        if (Input.GetKeyDown(KeyCode.F))
        {
            isOpend = !isOpend;
            if (isOpend)
            {
                UIPanel.SetActive(true);
            }
            else UIPanel.SetActive(false);
        }

        RaycastHit2D hit = Physics2D.Raycast(playerPoint.position, Vector2.right * playerPoint.localScale.x, distance);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hit) // если луч попал во что-то
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null) // если на объекте висит скрипт item
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.gameObject.GetComponent<Forge>() != null)
                {
                    isOpendCraft = !isOpendCraft;
                    isOpend = !isOpend;
                    if (isOpendCraft)
                    {
                        UIPanel.SetActive(true);
                        CraftPanel.SetActive(true);
                        Debug.Log("Крафт открыт");
                    }
                    else
                    {
                        UIPanel.SetActive(false);
                        CraftPanel.SetActive(false);
                        Debug.Log("Крафт закрыт");
                    }

                    /*UIPanel.SetActive(true);
                    isOpend = true;
                    CraftPanel.SetActive(true);
                    isOpendCraft = true;
                    Debug.Log("Крафт открыт");*/
                }
            }
            //else Debug.DrawLine(playerPoint.position, playerPoint.position + Vector3.right * playerPoint.localScale.x * distance, Color.red);
        }

    }

    /*public void OpenCraftPanel()
    {
        bool flag = true;
        while (flag)
        {
            UIPanel.SetActive(true);
            CraftPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)) flag = false;
        }

        UIPanel.SetActive(false);
        CraftPanel.SetActive(false);

    }*/

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                slot.itemAmountText.text = slot.amount.ToString();
                return;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
    }

}
