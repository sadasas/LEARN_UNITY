using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// cubic type 1 x 1
/// </summary>
public class OneOneCubic : Cubic
{
   

    public override void SetPos(Vector3 pos)
    {
      /*  MeshFilter mf = GetComponent<MeshFilter>();
        Vector3 fixPos = new Vector3(pos.x, pos.y + mf.sharedMesh.bounds.center.y, pos.z);*/
        transform.position = pos;
    }
    public override void Changetransparency(float transparency)
    {

        if (mRenderer == null) return;
        //Debug.Log("change color");
        Color color = mRenderer.material.color;
        color.a = transparency;
        mRenderer.material.color = color;

        base.Changetransparency(transparency);
    }

    private void OnMouseDrag()
    {
        UserControll.instance.DragMouse(this);
        Debug.Log("drag");
    }
    private void OnMouseUp()
    {
        UserControll.instance.EndDrag(this);
    }


}
