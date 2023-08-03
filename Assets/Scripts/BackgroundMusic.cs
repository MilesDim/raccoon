using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] musicTracks;
    public float musicVolume = 0.5f;
    private AudioSource audioSource;


   private void Awake()
{
    audioSource = GetComponent<AudioSource>();
}

    private void Start()
    {
        ShuffleMusicTracks();

        // Инициализируем audioSource (если он не был инициализирован в Awake)
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        // Проверяем, есть ли треки в массиве, и только тогда начинаем воспроизведение
        if (musicTracks.Length > 0)
            PlayNextTrack();
    }

    private void ShuffleMusicTracks()
    {
        // Производим случайное перемешивание массива с музыкальными треками
        for (int i = 0; i < musicTracks.Length; i++)
        {
            int randomIndex = Random.Range(i, musicTracks.Length);
            AudioClip temp = musicTracks[i];
            musicTracks[i] = musicTracks[randomIndex];
            musicTracks[randomIndex] = temp;
        }
    }

   public void PlayNextTrack()
{
    // Проверяем, играет ли уже музыка
    if (!audioSource.isPlaying)
    {
        // Воспроизводим следующий трек из массива
        if (musicTracks.Length > 0)
        {
            AudioClip trackToPlay = musicTracks[0];
            audioSource.clip = trackToPlay;
            audioSource.Play();

            // После окончания трека вызываем метод для воспроизведения следующего
            StartCoroutine(PlayNextTrackAfterDelay(trackToPlay.length));
        }
    }
}


    private System.Collections.IEnumerator PlayNextTrackAfterDelay(float delay)
    {
        // Ждем окончания текущего трека
        yield return new WaitForSeconds(delay);

        // Удаляем воспроизведенный трек из массива
        if (musicTracks.Length > 1)
        {
            musicTracks = musicTracks[1..];
            // Воспроизводим следующий трек
            PlayNextTrack();
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}

