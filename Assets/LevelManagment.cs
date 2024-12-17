using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class LevelManagment : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Levels { OutsideClinic, InsideClinic, Lair}
    public Levels levelToLoad;
    public float waitTime;

    public DialogueSystemController dmanager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        dmanager.StopAllConversations();
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        yield return new WaitForSeconds(waitTime);

        switch (levelToLoad)
        {
            case Levels.OutsideClinic:
                SceneManager.LoadScene("Clinic");
                break;

            case Levels.InsideClinic:
                SceneManager.LoadScene("Inside Clinic");
                break;

            case Levels.Lair:
                SceneManager.LoadScene("Lair");
                break;
        }
    }
}
