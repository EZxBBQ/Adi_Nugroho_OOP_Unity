using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator animator;
    public static Player instance;

    void Awake() 
    {
        if (this != instance && instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        playerMovement.Move();
        
    }

    void LateUpdate() 
    {
        animator.SetBool("isMoving", playerMovement.IsMoving());
        playerMovement.MoveBound();
    }
}
