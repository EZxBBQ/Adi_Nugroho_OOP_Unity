using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveUI : MonoBehaviour
{
    private CombatManager combatManager;
    private UIDocument uiDocument;
    private VisualElement root;
    private Label waveNumber;


    // Start is called before the first frame update
    void Start()
    {
        combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();

        uiDocument = this.GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
        waveNumber = root.Q<Label>("WaveNumber");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waveNumber.text = combatManager.waveNumber.ToString();
    }
}
