using UnityEngine;
using UnityEngine.SceneManagement;

public class cave : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string targetSceneName = "Pueblo";

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
