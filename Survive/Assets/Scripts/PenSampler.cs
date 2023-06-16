using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PenSampler : MonoBehaviour
{

    public float wallPen = 100.0f;

    private Vector3 endPoint;

    private Vector3? penPoint;

    private Vector3? impactPoint;

    public float penAmount = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   UpdatePen();
    }

    public void UpdatePen()
    {

        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;

        while (penAmount > 0)

        {

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("we hit");

                
                    impactPoint = hit.point;
                    Ray penray = new Ray(hit.point + ray.direction * wallPen, -ray.direction);
                    RaycastHit penHit;
                    if (hit.collider.Raycast(penray, out penHit, wallPen))
                    {
                        penPoint = penHit.point;
                        endPoint = this.transform.position + this.transform.forward * 1000;
                        Ray newRay = new Ray(penHit.point, endPoint);
                        ray = newRay;
                        penAmount -= 20.0f;
                    }


                    //else
                    //{
                    //    endPoint = impactPoint.Value + ray.direction * wallPen;
                    //    penPoint = null;
                    //    impactPoint = null;
                    //}
                

            }




            else
            {
                break;
            }
        }

    }  
    

 
    private void OnDrawGizmos()
    {

        UpdatePen();

        if (!penPoint.HasValue || !impactPoint.HasValue)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(this.transform.position, endPoint);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(this.transform.position, impactPoint.Value);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(impactPoint.Value, penPoint.Value);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(penPoint.Value, endPoint);
        }
    }
}
