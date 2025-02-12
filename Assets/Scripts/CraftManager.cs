using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public GameObject CraftPanel;
    public bool isOpend;

    void Update()
    {

    }

    public void OpenCraftPanel(GameObject CraftPane)
    {
        isOpend = !isOpend;
        if (isOpend)
        {
            CraftPanel.SetActive(true);
        }
        else CraftPanel.SetActive(false);
    }
}
