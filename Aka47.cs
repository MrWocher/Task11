using UnityEngine;

public class Aka47 : Weapon
{
    [SerializeField] private bool _startShooting = false;
    private float _timeAfterLastShoot = 0f;

    private void Update()
    {
        if (_startShooting)
        {
            _timeAfterLastShoot += Time.deltaTime;

            if (_timeAfterLastShoot >= FireRate)
            {
                CreateBullet();
                _timeAfterLastShoot = 0f;
            }
        }
    }

    public override void Shoot()
    {
        _startShooting = true;
        _timeAfterLastShoot = FireRate;
    }

    private void CreateBullet()
    {
        Bullet bullet = Instantiate(Bullet);
        bullet.Initialize(ShootPoint.position, Quaternion.identity, Damage);
    }

    public override void StopShoot()
    {
        _startShooting = false;
    }
}
