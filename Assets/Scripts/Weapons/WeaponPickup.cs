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
    private Vector3 weaponOffset = new Vector3(0, 0.5f, 0);

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
            Vector3 newPosition = other.transform.position + weaponOffset;
            newPosition.z = 2;
            weapon.transform.position = newPosition;
        }
    }

    void TurnVisual(bool on)
    {
        weapon.GameObject().SetActive(on);
    }
    void TurnVisual(bool on, Weapon weapon)
    {
        weapon.GameObject().SetActive(on);
    }
}
