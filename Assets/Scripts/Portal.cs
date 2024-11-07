using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    Vector2 newPosition;


    void Start()
    {
        ChangePosition();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

        if (Vector2.Distance(newPosition, transform.position) < 0.5f)
        {
            ChangePosition();
        }

        if (WeaponPickup.currentWeapon != null)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().LevelManager.LoadScene("Main");
        }
    }

    void ChangePosition()
    {
        newPosition = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f));
    }
}
