using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{ 
  public float anim = 0.5F; // Время ожидания (в секундах) перед переходом на следующий уровень
  public float waitTime = 20; // Время ожидания (в секундах) перед переходом на следующий уровень

    private bool hasLoadedNextLevel = false; // Флаг, чтобы убедиться, что следующий уровень загружен только один раз

    public GameObject circleIN; // Ссылка на объект CircleIN
    private VideoPlayer videoPlayer; // Ссылка на компонент VideoPlayer

    void Start()
    {
        // Находим компонент VideoPlayer на объекте SplashImageHolder
        GameObject splashImageHolder = GameObject.Find("SplashImageHolder");
        videoPlayer = splashImageHolder.GetComponent<VideoPlayer>();

        // Выключаем анимацию CircleIN при старте
        if (circleIN != null)
        {
            circleIN.SetActive(false);
        }

        // Подписываемся на события VideoPlayer
        videoPlayer.loopPointReached += OnVideoLoopPointReached;
        videoPlayer.prepareCompleted += OnVideoPrepareCompleted;

        StartCoroutine(WaitForLevel());
    }

    void OnVideoLoopPointReached(VideoPlayer player)
    {
        // Анимация CircleIN запускается при достижении конца видео
        // PlayCircleINAnimation();
    }

    void OnVideoPrepareCompleted(VideoPlayer player)
    {
        // Анимация CircleIN запускается перед началом воспроизведения видео
        // PlayCircleINAnimation();
    }

    void PlayCircleINAnimation()
    {
        // Включаем анимацию CircleIN
        if (circleIN != null)
        {
            circleIN.SetActive(true);
        }
    }

    IEnumerator WaitForLevel()
    {
        yield return new WaitForSeconds(waitTime);
        PlayCircleINAnimation();
        yield return new WaitForSeconds(0.2F+anim);
        // Останавливаем воспроизведение видео перед загрузкой новой сцены
        videoPlayer.Stop();

        // Загружаем уровень с индексом 1
        SceneManager.LoadScene(1);
    }

    private void OnDestroy()
    {
        // Отписываем обработчики событий при уничтожении объекта,
        // чтобы избежать возможных утечек памяти
        videoPlayer.loopPointReached -= OnVideoLoopPointReached;
        videoPlayer.prepareCompleted -= OnVideoPrepareCompleted;
    }
}
