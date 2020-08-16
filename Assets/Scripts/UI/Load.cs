using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour {

    public string sceneToLoad;

    public Image bar;

    public Text progress;

    void Start() {
        StartCoroutine(this.LoadAsync());
    }

    IEnumerator LoadAsync() {
        AsyncOperation scene = SceneManager.LoadSceneAsync(this.sceneToLoad);
        while(scene.progress < 1) {
            float progress = scene.progress;
            float percentage = progress * 100;
            this.progress.text = (int) percentage + "%";
            this.bar.fillAmount = Mathf.Lerp(this.bar.fillAmount, progress, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
