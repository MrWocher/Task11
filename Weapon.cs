using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected int Damage;
    [SerializeField] protected float FireRate;

    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected Transform ShootPoint;

    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBought;

    public string Label => Name;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBought => _isBought;

    public abstract void Shoot();

    public abstract void StopShoot();

    public void Buy()
    {
        _isBought = true;
    }
}
