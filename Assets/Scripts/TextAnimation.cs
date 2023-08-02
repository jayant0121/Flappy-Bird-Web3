using UnityEngine;
using TMPro;
using System.Collections;

public class TextAnimation : MonoBehaviour
{
    public TMP_Text textObject;
    public bool st2done = false;
    public FlappyBirdLevel fp1;
    int i=0;
    
    public GameObject[] soundPrefabs;
    public string sentence1= "Have you ever felt like life is too tough?";
    public string sentence2 = "People around me tried to deter me, tried to derail my path, my goals";
    void Start()
    {
        fp1 = GameObject.Find("FlappyBirdLevel").GetComponent<FlappyBirdLevel>();
    }
    public void Statement1()
    {
        StartCoroutine(TypeSentence(sentence1)); 
    }
    IEnumerator TypeSentence (string sentence){
        textObject.text = "";
        GameObject.Instantiate(soundPrefabs[i++],transform.position,transform.rotation);
        foreach(char letter in sentence.ToCharArray()){
            textObject.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
        yield return new WaitForSeconds(1);
        if(!st2done)
        {
            st2done = true;
            StartCoroutine(TypeSentence(sentence2));
        }
        else{
            yield return new WaitForSeconds(0.8f);
            fp1.OpenGameMenuPanel();
            StopCoroutine(TypeSentence(sentence2));
        }
    }
}
