using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchcontroller : MonoBehaviour
{
    
    // status game true we play false we loose
    // Start is called before the first frame update
    //void Start()
    //{
    //    poolObj = PoolObj.Instance;
    //}

   
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown((0))) // using in editor.
        {
            Debug.Log("srartGetMouseButtonDown");

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("hitting " + hit.collider.tag);
                GameObject touchedObject = hit.collider.gameObject;
                switch (touchedObject.tag)
                {
                    case "zombe_0":
                        Debug.Log("rey touch : " + touchedObject.tag);
                        //poolObj.ReturnFromPool("Enemy");
                        touchedObject.SetActive(false);
                        break;
                    case "human":
                        Debug.Log("rey touch : " + touchedObject.tag);
                        //poolObj.ReturnFromPool("Human");
                        touchedObject.SetActive(false);
                       
                        break;
                    default:
                        break;
                }
            }

        }
#endif
        if (Input.touchCount > 0)
        {
            Debug.Log("srart.touchCount");
            //We should have hit something with a 2D Physics collider!
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            var touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit hitInformation = Physics.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            if (hitInformation.collider != null)
            {
                Debug.Log("hitting " + hitInformation.collider.tag);
                GameObject touchedObject = hitInformation.collider.gameObject;
                switch (touchedObject.tag)
                {
                    case "zombe_0":
                        Debug.Log("rey touch " + touchedObject.tag);
                        
                        break;
                    case "human":
                        Debug.Log("rey touch " + touchedObject.tag);
                        
                        break;
                    default:
                        break;
                }

            }
        }

    }
}
