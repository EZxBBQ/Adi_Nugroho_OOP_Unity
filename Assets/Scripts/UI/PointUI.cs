using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointUI : MonoBehaviour
{
    private CombatManager combatManager;

    private UIDocument uiDocument;
    private VisualElement root;
    private Label pointAquired;
    private static int point = 0;

    public static int getPoint()
    {
        return point;
    }

    // Start is called before the first frame update
    void Start()
    {
        combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();

        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
        pointAquired = root.Q<Label>("PointAquired");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pointAquired.text = point.ToString();
    }

    public void AquirePoint(Enemy enemy)
    {
        point += enemy.level;
    }
}
