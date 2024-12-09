using UnityEngine;
using System.Collections;



    public class ChildColliderLeft : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
            
                
            }

            if (collision.gameObject.CompareTag("Platform"))
            {
            
            GlobalData.GlobalDataCarrier.LandedLeft = true;
            }

    }
    }
