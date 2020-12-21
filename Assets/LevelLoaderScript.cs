using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoaderScript : MonoBehaviour
{
    public float transitionTime = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadLevel(int index)
    {
        StartCoroutine(LoadLevelCoroutine(index));
    }
    public IEnumerator LoadLevelCoroutine(int index)
    {


        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);

    }
}
