
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    [SerializeField] Rigidbody bulletPrefab;
    [SerializeField] Transform launcherPos;
    [SerializeField]  Slider  aimSlider;

    [SerializeField] float defaultshootPower;


    float _shootPower;
    bool _beingcharging;

    private void OnEnable()
    {
        GameEvents.ChargingPressed += Charging;
        GameEvents.ShootPressed += Shoot;

        _shootPower = defaultshootPower;

     
    }

    private void OnDisable()
    {
        GameEvents.ShootPressed -= Shoot;
        GameEvents.ChargingPressed -= Charging;
    }

    void Shoot()
    {   
        _beingcharging = false;
    
        //calculate
        float _forward = Mathf.Clamp(_shootPower, 0, 50);
        float _upward = Mathf.Clamp(_forward, 0, 40)/10;
        
        Rigidbody _bullet = Instantiate(bulletPrefab, launcherPos.position, Quaternion.identity) as Rigidbody;
      
        _bullet.velocity = transform.forward * _forward  + transform.up *_upward;
        
       
    }

    void Charging()
    {
        _beingcharging = true;
    }

    private void Update()
    {
        if (_beingcharging)
        {
            _shootPower += 1f/2.5f;

        }
        else _shootPower = defaultshootPower;
        aimSlider.value = _shootPower;

    }

}
