using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    
    public void GoToScene2()
    {
        SceneManager.LoadScene("GameScreen");
    }

}
