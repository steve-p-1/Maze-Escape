using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private bool DropBehaviour = false;
    public static ISpawnEntities SpawnStrategy = SpawnRandomStrategy.Instance;
    [SerializeField] TMP_Text DropBehaviourText;
    public static LoadScene Instance { get; set; }
    [SerializeField] Canvas instrustionsCanvas;
    private bool isInstructionsShown = false;

    private void Awake()
    {
        PlayerPrefs.SetString("DropBehaviour", "False"); //reset to default

            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
    }


    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    // can't input classes in editor directly. this makes it easier to go between scenes as well
    public void CollectEntityStrategy(string anEntitySpawnStrategy)
    {
        PlayerPrefs.SetString("entitySpawnStrategy", anEntitySpawnStrategy);
    }


    public void ChangeDropBehaviour() //probably should do British spelling here
    {
        DropBehaviour = !DropBehaviour;
        PlayerPrefs.SetString("DropBehaviour", DropBehaviour.ToString());
        Debug.Log(DropBehaviour.ToString());
        DropBehaviourText.text = "Use Moving Pickups? " + DropBehaviour.ToString();
    }

    public void ToggleInstructions()
    {
        //toggle instructions being shown
        isInstructionsShown = !isInstructionsShown;
        instrustionsCanvas.gameObject.SetActive(isInstructionsShown);
    }
}
