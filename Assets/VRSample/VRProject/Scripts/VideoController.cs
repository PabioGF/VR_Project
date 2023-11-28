using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject button;
    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(true);
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
        if(videoPlayer.isPrepared)
        {
            button.SetActive(false);
            videoPlayer.Play();
        }
    }

}
