using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word : MonoBehaviour
{
    public string word;

    private int typeIndex;

    private WordDisplay display;

    public Word()
    {
        typeIndex = 0;
    }

    public void SetWordAndWordDisplay(string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        display = _display;
        display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if(wordTyped)
        {
            display.RemoveWord();
        }

        return wordTyped;
    }

    public bool WordOnScreen()
    {
        return display.DisplayOnScreen();
    }

    public bool WordAtBottomOfScreen()
    {
        return display.wordAtBottomOfScreen;
    }
}
