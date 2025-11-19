using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{

    public string targetSceneName = "mihouse";

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            print("Switching Scene to " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

