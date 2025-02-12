using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseActivity : MonoBehaviour
{
    public Collider2D other;
    public ChooseActivity(Collider2D obj)
    {
        other = obj;
    }

    public void ChooseInteract()
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
        }
    }
}
