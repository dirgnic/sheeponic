using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public Image[] liveArr;
 //  public GameObject selector;
  //  [SerializeField]
   public int lives = 3;
   public void onCollisioooon()
   {
        if (lives > 0)
        {
            lives--;
            Debug.Log("There are " + lives + " left");
            var t = liveArr[lives].color;
            t.a = 0f;
            liveArr[lives].color = t;
            Debug.Log(t.a);

        }
        if(lives==0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
