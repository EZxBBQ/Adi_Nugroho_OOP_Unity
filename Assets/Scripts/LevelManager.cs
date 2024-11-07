using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Awake()
    {

    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
       animator.SetTrigger("TransitionStart");
       yield return new WaitForSeconds(1f);
       SceneManager.LoadSceneAsync(sceneName);
       Player.instance.transform.position = new Vector3(0, 0, 0);
       animator.SetTrigger("TransitionEnd");
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
