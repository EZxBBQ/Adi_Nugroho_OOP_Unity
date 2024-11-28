using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesLeftUI : MonoBehaviour
{
    private CombatManager combatManager;
    private UIDocument uiDocument;
    private VisualElement root;
    private Label enemyAmount;


    // Start is called before the first frame update
    void Start()
    {
        combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();

        uiDocument = this.GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
        enemyAmount = root.Q<Label>("EnemyAmount");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyAmount.text = combatManager.totalEnemies.ToString();
    }
}
