using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Forge", menuName = "Inventory/Forge")]
public class ForgeScriptableObject : ScriptableObject
{
    public string forgeName;
    public GameObject forgePrefab;
    //public GameObject forgeInterfacePanel;

}
