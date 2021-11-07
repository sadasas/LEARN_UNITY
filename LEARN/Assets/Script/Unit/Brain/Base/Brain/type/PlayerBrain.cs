
using UnityEngine;


[RequireComponent(typeof(Rigidbody),typeof(UnitEvent), typeof(UnitInventory))]
[RequireComponent(typeof(UnitShoot),typeof(UnitHealth))]

public class PlayerBrain : Brain
{
    //private
    Rigidbody rb;
    UnitEvent unitEvent;
    Vector3 move;


    public TypeBrain brain;

    [Header("Movement")]
    [Space(10)]
    [SerializeField] float speed;
    [SerializeField] float smoothRotate;
   
    public override void Starting()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        unitEvent = this.gameObject.GetComponent<UnitEvent>();
        GetComponent<UnitShoot>().typeShoot = brain.shoot;

        brain.skill.Starting();
    }

    public override void Think()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Steer();
        Shoot();

        brain.skill.SkillOne();
    }

    void Steer()
    {
        if (move.magnitude < 0.1f) return;
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
        rb.MoveRotation(Quaternion.Lerp(rb.rotation, Quaternion.LookRotation(move), smoothRotate));

    }
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            unitEvent.shootEvent?.Invoke(1);
        }
    }
}
