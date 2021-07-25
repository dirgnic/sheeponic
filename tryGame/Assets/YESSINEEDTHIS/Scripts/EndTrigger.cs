using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    //  void Start()
    //  {

    //  }
 //   public GameManager gameManager;

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("player") == true)
        {
            SceneManager.LoadScene(3);
        }


    }
}
