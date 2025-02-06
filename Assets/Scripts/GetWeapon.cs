using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    private Gun _weapon;

    //Popiedad par acceder a la variable _weapon
    public Gun Weapon
    {
        get{return _weapon;}
    }

    [SerializeField]
    private Transform _gunPivot;

//Activa y desactiva la imagen de la bala
    private UIController _uiController;

    private void Start()
    {
        _uiController = gameObject.GetComponent<UIController>();
        _uiController.ShowBulletsUI(false);
    }
    // -

    //Si choca con un trigger y su Tag es Weapon, va a desactivar el objeto
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon") && _weapon == null)
        {
            GrabWeapon(other.transform);
        }

    }  
   private void GrabWeapon(Transform weapon)
   {
        weapon.GetComponent<Rotate>().IsRotating = false;
        weapon.GetComponent<BoxCollider>().enabled = false;
        weapon.SetParent(_gunPivot);
        weapon.localPosition = Vector3.zero;
        weapon.localRotation = Quaternion.identity;
        _weapon = weapon.GetComponent<Gun>();
        _weapon.PickUpWeapon(this);
        gameObject.GetComponent<UIController>().ShowBulletsUI(true);
   }

   public void RemoveWeapon()
   {
    Destroy(_weapon.gameObject);
    _weapon = null;
    gameObject.GetComponent<UIController>().ShowBulletsUI(false);

   }
}
