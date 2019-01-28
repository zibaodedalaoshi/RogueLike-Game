using UnityEngine;
using UnityEngine.SceneManagement;

public class movieTest : MonoBehaviour {

    //电影纹理  
    public MovieTexture movTexture;
    public AudioSource audioSource;
    public string LevelToLoad;
    void Start()
    {
        //设置电影纹理播放模式为循环  
        movTexture.loop = false;

        movTexture.Play();

    }

    void OnGUI()
    {
        //绘制电影纹理  
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture, ScaleMode.StretchToFill);
        if (!movTexture.isPlaying)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
  /*  public void OnPlay()
    {
        movTexture.Play();
        // audioSource.Play();  
    }
    public void OnPause()
    {
        movTexture.Pause();
        // audioSource.Pause();  
    }
    public void OnStop()
    {
        movTexture.Stop();
        // audioSource.Stop();  
    }
    */
}
