using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private PointScript pointCounter;
    [SerializeField] private GameObject regularPointCounter;

    // private bool onDeathScreen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        // Makes the camera not move anymore
        Camera.main.transform.parent.GetComponent<CameraMoveScript>().beginMovement = false;

        regularPointCounter.SetActive(false);

        deathScreen.SetActive(true);

        // onDeathScreen = true;

        pointCounter.SavePoints();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Test Scene");
    }

    /*
    public void PauseGame()
    {
        if (!onDeathScreen)
        {

        }
    }

    private void SwitchTime()
    {

    }
    */
}
