using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private int score = 0;
    public int Score
    {
        get { return score; }
    }

    private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
    }

    private Vector3 direction;
    
    [SerializeField] private GameObject particleEffect;


    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        direction = Vector3.zero;
        isDead = false;
        gameController.ScoreInGameRefresh();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDead)
        {
            if(direction == Vector3.forward && !isDead)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            score++;
            gameController.ScoreInGameRefresh();
            Instantiate(particleEffect, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Tile")
        {
            RaycastHit hit;

            Ray downRay = new Ray(transform.position, Vector3.down);

            if(!Physics.Raycast(downRay, out hit))
            {
                isDead = true;
            }
        }
    }

}
