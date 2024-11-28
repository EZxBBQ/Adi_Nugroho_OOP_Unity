using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthUI : MonoBehaviour
{
    private GameObject player;
    private GameObject ship;
    private HealthComponent healthComponent;

    private UIDocument uiDocument;
    private VisualElement root;
    private Label playerHealth;
    

    void Start()
    {
        player = GameObject.Find("Player");
        ship = player.transform.Find("Ship").gameObject;
        healthComponent = ship.GetComponent<HealthComponent>();

        uiDocument = this.GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
        playerHealth = root.Q<Label>("PlayerHealth");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerHealth.text = healthComponent.getHealth().ToString();
    }
}
