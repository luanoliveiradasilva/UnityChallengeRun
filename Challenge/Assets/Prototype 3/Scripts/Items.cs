using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Items : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveDuration;
    [SerializeField] private float intervalPause;

    [Header("Audio")]
    [SerializeField] private AudioClip coinSound;
    private Vector3 upPos;
    private Vector3 downPos;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        MoveItens();
    }

    private void MoveItens()
    {
        upPos = transform.position + Vector3.up * moveDistance;
        downPos = transform.position;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveY(upPos.y, moveDuration).SetEase(Ease.InOutQuad));

        sequence.AppendInterval(intervalPause);

        sequence.Append(transform.DOMoveY(downPos.y, moveDuration).SetEase(Ease.InOutQuad));

        sequence.SetLoops(-1, LoopType.Restart);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(coinSound, 1.0f);
            StartCoroutine(nameof(WaitSoundAnimation));
        }

    }

    IEnumerator WaitSoundAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}