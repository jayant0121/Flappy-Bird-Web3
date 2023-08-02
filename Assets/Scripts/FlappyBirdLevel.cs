using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FlappyBirdLevel : MonoBehaviour
{
    public TMP_Text Score;
    public bool InstructionScreen = false;
    public GameObject Instruction,StartingMenu,DeathPanel,GameMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && InstructionScreen)
        {
            Instruction.SetActive(false);
            LevelSpawner.StartGameBtn();
        }
        Score.text = "Score: "+BirdMovement.Score.ToString();
           
    }
    public void Replay()
    {
        SceneManager.LoadScene("FlappyBird");
    }
    void Start(){
        StartingMenu.SetActive(true);
        Instruction.SetActive(false);
        DeathPanel.SetActive(false);
        GameMenu.SetActive(false);
    }
    public void OpenGameMenuPanel()
    {
        StartingMenu.SetActive(false);
        Instruction.SetActive(false);
        DeathPanel.SetActive(false);
        GameMenu.SetActive(true);
    }
    public void OpenInstructionPanel(){
        InstructionScreen = true;
        StartingMenu.SetActive(false);
        Instruction.SetActive(true);
        DeathPanel.SetActive(false);
        GameMenu.SetActive(false);
    }


}

