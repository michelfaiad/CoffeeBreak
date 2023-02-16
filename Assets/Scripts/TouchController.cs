using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if(Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform.gameObject.CompareTag("Click"))
                    {
                        hit.transform.gameObject.GetComponent<ClickItemBehaviour>().HitMe();
                    } 
                    else if (hit.transform.gameObject.CompareTag("PowerUp"))
                    {
                        hit.transform.gameObject.GetComponent<PowerUpBehaviour>().HitMe();
                    }
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position + touch.deltaPosition);

                //Debug.Log("magnitude " + touch.deltaPosition.x);
                if (Mathf.Abs(touch.deltaPosition.x) > 5)
                {                    
                    if (Physics.Raycast(ray, out hit, 100f))
                    {
                        if (hit.transform.gameObject.CompareTag("Slash"))
                        {
                            hit.transform.gameObject.GetComponent<ClickItemBehaviour>().HitMe();
                        }
                    }
                }
            }
        }
    }
}
