using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceCave : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string targetSceneName = "Cave";

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
