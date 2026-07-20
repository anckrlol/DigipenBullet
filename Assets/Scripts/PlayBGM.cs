using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [SerializeField] AudioClip bgm;
    AudioSource bgmPlayer;
    SceneLoader sceneLoader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmPlayer = GetComponent<AudioSource>();
        bgmPlayer.clip = bgm;
        bgmPlayer.loop = true;
        bgmPlayer.Play();
    }

    public void PlaySong(){
        bgmPlayer.clip = bgm;
        bgmPlayer.Play();
    }
}
