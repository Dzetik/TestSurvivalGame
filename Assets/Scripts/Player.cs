using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 5f;
    private Rigidbody2D rb;
    private Transform playerPoint;
    //public int distance; 
    //private ChooseActivity chooseActivity;

    //private float distance = 25;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
        //chooseActivity = GetComponent<ChooseActivity>();
    }

    //попадания по объекту справа от игрока
    private void Update()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
        if (hit) // если луч попал во что-то
        {
            if (hit.collider.gameObject.GetComponent<Item>() != null)
            {
                InventoryManager.AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
            }
            
            Debug.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance, Color.green);
            Debug.Log("Передо мной " + hit.transform.name + " на позиции " + transform.position);
        }
        else Debug.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance, Color.red);*/
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }

        inputVector = inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * (Time.fixedDeltaTime * movingSpeed));

    }

    /*public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            ChooseActivity handler = new ChooseActivity(other);
            handler.ChooseInteract();
        }
    }*/
    

}

