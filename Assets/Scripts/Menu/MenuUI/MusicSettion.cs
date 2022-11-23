using UnityEngine;
using UnityEngine.UI;

public class MusicSettion : MonoBehaviour
{
    public Sprite[] sound;
    public Image mus;
    private bool MUSactive;
    void Start()
    {
        MusSet();
    }

    void Update()
    {
        MusSet();
    }
    private void MusSet()
    {
        if (PlayerPrefs.HasKey("music"))
        {
            AudioListener.pause = PlayerPrefs.GetInt("music") == 1 ? true : false;
            mus.sprite = sound[PlayerPrefs.GetInt("music")];
        }
        else
        {
            MUSactive = true;
        }
    }
    public void MusClick()
    {

        if (MUSactive)
        {
            mus.sprite = sound[0];
            AudioListener.pause = false;
        }
        else
        {
            mus.sprite = sound[1];
            AudioListener.pause = true;
        }

        PlayerPrefs.SetInt("music", MUSactive ? 1 : 0);
        PlayerPrefs.Save();
        MUSactive = !MUSactive;
    }

}
