using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// base all cubic to managed position , tranparency, show popup indicator
/// </summary>
public abstract class Cubic : MonoBehaviour
{
    [SerializeField] int size;
    [SerializeField] GameObject indicatorHUD;
    protected MeshRenderer mRenderer;
    protected GameObject currentIndicator;


    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        //Debug.Log(mRenderer.material);
    }
    public abstract void SetPos(Vector3 pos);

    public virtual void Changetransparency(float transparency)
    {
        SetIndicator(transparency == 1f ? false : true);

    }

    public virtual void SetIndicator(bool param)
    {
        if (param && currentIndicator==null) currentIndicator = Instantiate(indicatorHUD, transform.position, Quaternion.LookRotation(Camera.main.transform.forward,Vector3.up),transform);
        else if (!param) Destroy(currentIndicator);
        
    }
    
}
