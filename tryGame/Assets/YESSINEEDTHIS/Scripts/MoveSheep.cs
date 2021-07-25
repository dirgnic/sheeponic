using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSheep : MonoBehaviour
{
    public Rigidbody rb23;
    private int q = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     //   if (q % 100 == 0)
   //     { 
        rb23.AddForce(0, 0, 1000 * Time.deltaTime);
   
     //   }
     //   else if (q % 43 == 0)
      //  {
        //    rb23.AddForce(0, 1000 * Time.deltaTime, 0, 0);
    //    }
        q++;
    }
}
