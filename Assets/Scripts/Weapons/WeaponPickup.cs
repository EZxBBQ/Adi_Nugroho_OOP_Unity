using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;
    private Weapon weapon;
    public static Weapon currentWeapon;

    void Awake()
    {
        weapon = Instantiate(weaponHolder, transform.position, Quaternion.identity, transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false);
        }
        else
        {
            Debug.LogError("Weapon is null");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (currentWeapon != null && currentWeapon != weapon)
            {
                TurnVisual(false, currentWeapon);
                currentWeapon.transform.SetParent(transform, false);
                currentWeapon.transform.position = transform.position;
            }

            currentWeapon = weapon;
            TurnVisual(true);
            weapon.transform.SetParent(other.transform, false);
            weapon.transform.position = other.transform.position;
        }
    }

    void TurnVisual(bool on)
    {
        foreach(var component in weapon.GetComponents<Component>())
        {
            if (component is Renderer renderer)
            {
                renderer.enabled = on;
            }
            else if (component is Collider collider)
            {
                collider.enabled = on;
            }
            else if (component is Behaviour behaviour)
            {
                behaviour.enabled = on;
            }
        }
    }
    void TurnVisual(bool on, Weapon weapon)
    {
        foreach(var component in weapon.GetComponents<Component>())
        {
            if (component is Renderer renderer)
            {
                renderer.enabled = on;
            }
            else if (component is Collider collider)
            {
                collider.enabled = on;
            }
            else if (component is Behaviour behaviour)
            {
                behaviour.enabled = on;
            }
        }
    }
}
