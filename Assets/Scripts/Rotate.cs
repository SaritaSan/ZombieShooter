using UnityEngine;

public class Rotate : MonoBehaviour
{
    //Nos va a permitir cambiar la velocidad de la rotacion en la ventana de Inspector
    [SerializeField]
    private float _rotateSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    //Le da la iindicacion al objeto, manda a llamar al objeto, los valores de transformacion, especificando que va a ser la rotacion
    void Update()
    {
        gameObject.transform.Rotate(0f, _rotateSpeed*Time.deltaTime,0f);
    }
}
