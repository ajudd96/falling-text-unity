using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public WordSpawner wordSpawner;

    private bool hasActiveWord;
    private Word activeWord;

    public void AddWord()
    {
        Word word = gameObject.AddComponent<Word>();
        word.SetWordAndWordDisplay(WordGenerator.GetRandomWord(), 
                                    wordSpawner.SpawnWord());

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if(hasActiveWord)
        {
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        } else
        {
            foreach(Word word in words)
            {
                if(word.GetNextLetter() == letter && word.WordOnScreen())
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }

    private void Update()
    {
        words.RemoveAll(word => word.WordAtBottomOfScreen());
    }
}
