using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            print("Switching Scene to " + nextSceneIndex);

       
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
