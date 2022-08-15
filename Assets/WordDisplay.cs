using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fallSpeed = 3f;
    public bool wordAtBottomOfScreen = false;

    public void SetWord(string word)
    {
        text = GetComponent<TextMeshProUGUI>();
        text.SetText(word);

        fallSpeed = Random.Range(3f, 5f);
    }
  
    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    public bool DisplayOnScreen()
    {
        float currentYPosition = Camera.main.WorldToViewportPoint(transform.position).y;
        return currentYPosition < 1.0f && currentYPosition > 0f;
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);

        float currentYPosition = Camera.main.WorldToViewportPoint(transform.position).y;
        if(currentYPosition < 0f)
        {
            wordAtBottomOfScreen = true;
            RemoveWord();
        }
    }

}
