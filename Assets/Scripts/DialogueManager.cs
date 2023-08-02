using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject startGamePanel,StartingMenu; 
    public Queue<string> sentences;
    public GameObject[] soundPrefabs;
    int i= 0;
    public TMP_Text dialogueText;
    public TMP_Text dialogueName;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue){
        dialogueName.text = dialogue.name;
        Debug.Log("Starting Conversation with" + dialogue.name);
        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        GameObject.Instantiate(soundPrefabs[i++],transform.position,transform.rotation);
        StopAllCoroutines(); 
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    void EndDialogue()
    {
        startGamePanel.SetActive(true);
        StartingMenu.SetActive(false);
    }
}
