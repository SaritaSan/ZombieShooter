using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    //Si choca con un trigger y su Tag es Weapon, va a desactivar el objeto
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
        {
            other.gameObject.SetActive(false);
        }

    }
   
}
