using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

    public WordDisplay SpawnWord()
    {
        Vector3 randomPostion = new Vector3(Random.Range(-70, 70f), 55f);

        GameObject wordObj = Instantiate(wordPrefab, transform.TransformVector(randomPostion), Quaternion.identity, wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
