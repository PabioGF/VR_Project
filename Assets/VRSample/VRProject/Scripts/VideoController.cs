using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject playButton;
    public GameObject pauseButton;

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(true);
        pauseButton.SetActive(false);
        videoPlayer.Prepare();
        //videoPlayer.frame = 0;
        //videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    public void PlayVideo()
    {
        if(videoPlayer.isPrepared && !videoPlayer.isPlaying)
        {
            playButton.SetActive(false);
            pauseButton.SetActive(true);
            videoPlayer.Play();
            
        }
    }

    public void PauseVideo()
    {
        if (videoPlayer.isPrepared && videoPlayer.isPlaying)
        {
            playButton.SetActive(true);
            pauseButton.SetActive(false);
            videoPlayer.Pause();

        }
    }

}
