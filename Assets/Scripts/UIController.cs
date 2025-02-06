using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    //Activa y desactiva lo imagen de las balas, el grupo
    [SerializeField]
    private GameObject _bulletsUI;

    [SerializeField]
    private Text _bulletsText;

    public Text BulletsText
    {
        get
        {
            return _bulletsText;
        }
    }


    public void ShowBulletsUI(bool show)
    {
        _bulletsUI.SetActive(show);
    }
}
