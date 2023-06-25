using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();
    [SerializeField] private Weapon _currentWeapon;

    [SerializeField] private List<GameObject> _allWeapons = new List<GameObject>();

    private int _currentWeaponNum = 0;

    private int _currentHp;
    private Animator _animator;

    public int Coins { get; private set; }

    public event Action<int, int> HpChanged;
    public event Action<int> CoinsChanged;

    private void Start()
    {
        _currentHp = _maxHp;
        ChangeWeapon(weapons[_currentWeaponNum]);
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();

        for (int i = 0; i < transform.childCount; i++)
            _allWeapons.Add(transform.GetChild(i).gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _currentWeapon.Shoot();

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _currentWeapon.StopShoot();

        }
    }

    public void GetDamage(int damage)
    {
        _currentHp -= damage;

        HpChanged?.Invoke(_currentHp, _maxHp);
        if (_currentHp <= 0)
            Destroy(gameObject);
    }

    public void AddCoins(int coins)
    {
        Coins += coins;
        CoinsChanged?.Invoke(Coins);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Coins -= weapon.Price;
        CoinsChanged?.Invoke(Coins);
        weapons.Add(weapon);
    }

    public void SwitchWeapon()
    {
        _allWeapons[_currentWeaponNum].SetActive(false);

        _currentWeaponNum++;

        if (_currentWeaponNum >= weapons.Count)
            _currentWeaponNum = 0;
        else if (_currentWeaponNum < 0)
            _currentWeaponNum = weapons.Count;

        ChangeWeapon(weapons[_currentWeaponNum]);
        _allWeapons[_currentWeaponNum].SetActive(true);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
