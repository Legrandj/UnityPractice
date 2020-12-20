using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DasterTextScript : MonoBehaviour
{
    public float delay;
    string[] lines ={"Why hello there! It is my pleasure to make your acquaintance",
                    "I would like to introduce myself as Daster, knight and defender of the people",
                    "But enough about me. You seem quite lost, and not from around here. What's your name?"};
    string currentLine = "";
    int counter = 0;
    public TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator slowReadLine(string line)
    {
        for (int i = 0; i < line.Length + 1; i++)
        {
            currentLine = line.Substring(0, i);
            if (this == null) { print("NUll"); }
            text.text = currentLine;
            yield return new WaitForSeconds(delay);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (counter < lines.Length && Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            StartCoroutine(slowReadLine(lines[counter++]));
        }
    }
}
