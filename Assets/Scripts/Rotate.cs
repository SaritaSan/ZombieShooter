using UnityEngine;

public class Rotate : MonoBehaviour
{
    //Nos va a permitir cambiar la velocidad de la rotacion en la ventana de Inspector
    [SerializeField]
    private float _rotateSpeed = 5;

    [SerializeField]
    private bool _isRotating = true;

    public bool IsRotating
    {
        get{return _isRotating;}
        set{_isRotating = value;}
    }


    void Update()
    {
        RotateWeapon();
    }

    //Le da la iindicacion al objeto, manda a llamar al objeto, los valores de transformacion, especificando que va a ser la rotacion
    private void RotateWeapon()
    {
        if(_isRotating)
        {
            gameObject.transform.Rotate(0f, _rotateSpeed*Time.deltaTime,0f);

        }
    }
}
