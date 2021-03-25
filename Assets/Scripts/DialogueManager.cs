using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;
    float timer = 0;
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        StartDialogue("Hi my name is Wiebe and we welcome you to our organisation!n" +
            "We are glad to see you stand strong to work for ocean sustainability.n" +
            "To complete your registration and become an official partner of our organisation, you should pick up our organisation's flag!n" +
            "Use your minimap in the upper left corner to guide you there!n" +
            "You can go get it at the warehouse!");
    }

    public void StartDialogue(string dialogue)
    {
        uiManager.dialoguePanel.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogue));
    }

    public IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            if (dialogueText.text.Length > 2) {
                string s = dialogueText.text.Substring(dialogueText.text.Length - 2);
                if (s == ".n" || s == "!n")
                {
                    dialogueText.text = "";
                }
                Debug.Log(s);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator ShowDialogueScreen(float seconds)
    {

        uiManager.dialoguePanel.SetActive(false);
        yield return new WaitForSeconds(seconds);
    }
}
