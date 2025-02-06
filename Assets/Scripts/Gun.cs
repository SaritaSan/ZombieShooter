using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    private    GetWeapon _getWeapon;
    public void Shoot()
    {
        if(_currentBulletsNumber == 0)
        {
            if(_totalBulletsNumber == 0)
            {
                RemoveWeapon();
            }
            return;
        }
        _weaponAnimator.Play("Shoot", -1, 0f);
        GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);
        _currentBulletsNumber--;
        UpdateBulletsText();
    }

    private void RemoveWeapon()
    {
        _getWeapon.RemoveWeapon();
        _getWeapon = null;

    }
    
    public void PickUpWeapon(GetWeapon getWeapon)
    {
        _getWeapon = getWeapon;
        _totalBulletsNumber = _maxBulletsNumber;
        _currentBulletsNumber = _cartridgeBulletsNumber;
        _weaponAnimator.Play("GetWeapon");
        UpdateBulletsText();
    }

    public void Reload()
    {
        if(_currentBulletsNumber == _cartridgeBulletsNumber || _totalBulletsNumber == 0)
        {
            return;
        }

        int bulletNeeded = _cartridgeBulletsNumber - _currentBulletsNumber;

        if(_totalBulletsNumber >= _cartridgeBulletsNumber)
        {
            _currentBulletsNumber = bulletNeeded;
        }

        else if(_totalBulletsNumber > 0)
        {
            _currentBulletsNumber = _totalBulletsNumber;
        }
        _totalBulletsNumber -= _currentBulletsNumber;
        UpdateBulletsText();

        _weaponAnimator.Play("Reload");
    }

    private void UpdateBulletsText()
    {
        if(_bulletText == null)
        {
            _bulletText = _getWeapon.GetComponent<UIController>().BulletsText;
        }
        _bulletText.text = _currentBulletsNumber + "/" + _totalBulletsNumber;
    }

}
