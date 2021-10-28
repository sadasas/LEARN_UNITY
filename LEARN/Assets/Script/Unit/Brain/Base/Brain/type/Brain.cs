
using UnityEngine;




public abstract class Brain :MonoBehaviour
{
   
    public Transform target { get; set; }
    public abstract void Think();
    public abstract void Starting();

    private void Start()
    {
        Starting();
    }
    private void Update()
    {
        Think();
    }

}
