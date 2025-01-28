using UnityEngine;

public class Fire : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<GetWeapon>().Weapon?.Shoot();
        }
    }
}
