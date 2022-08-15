using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public WordManager WordManager;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit collider");
        Word collidedWord = collision.gameObject.GetComponent<Word>() as Word;

        if (collidedWord)
        {
            Debug.Log(collidedWord.word + "Hit collider");
        }
    }
}
