using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOmitir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Omitir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
