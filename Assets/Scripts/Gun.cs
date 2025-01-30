using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _bulletPivot;

    [SerializeField]
    private Animator _weaponAnimator;

    private Text _bulletText;

    //Numero de balas
    private int _maxBulletsNumber = 20;
    //Npumero de balas dentro de cada cartucho
    [SerializeField]
    private int _cartridgeBulletsNumber = 5;
    private int _totalBulletsNumber = 0;
    private int _currentBulletsNumber = 0;

    public void Shoot()
    {
        _weaponAnimator.Play("Shoot", -1, 0f);
        GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);
        _currentBulletsNumber--;
        UpdateBulletsText();
    }
    
    public void PickUpWeapon()
    {
        _totalBulletsNumber = _maxBulletsNumber;
        _currentBulletsNumber = _cartridgeBulletsNumber;
        _weaponAnimator.Play("GetWeapon");
        UpdateBulletsText();
    }

    public void Reload()
    {
        if(_totalBulletsNumber > 0)
        {
            _currentBulletsNumber = _cartridgeBulletsNumber;
        }

        else if(_totalBulletsNumber > 0)
        {
            _currentBulletsNumber = _totalBulletsNumber;
        }
        _totalBulletsNumber -= _currentBulletsNumber;
        UpdateBulletsText();
    }

    private void UpdateBulletsText()
    {
        if(_bulletText == null)
        {
            _bulletText = GameObject.Find("BulletText").GetComponent<Text>();
        }
        _bulletText.text = _currentBulletsNumber + "/" + _totalBulletsNumber;
    }

}
