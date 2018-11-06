using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Transform jumpWaypoint;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float angle;
    [SerializeField] private GameObject rope;
    [SerializeField] private GameObject shadow;
    [SerializeField] private List<AudioClip> deathClips;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            audioSource.clip = deathClips[Random.Range(0, deathClips.Count)];
            audioSource.loop = false;
            audioSource.PlayOneShot(audioSource.clip);
            StartCoroutine("PlayDeathAnimation");
        }
    }

    private IEnumerator PlayDeathAnimation()
    {
        GetComponent<PlayerInput>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        rope.SetActive(false);
        shadow.SetActive(false);

        Sequence seq = DOTween.Sequence();

        seq.Insert(0f, transform.DOJump(jumpWaypoint.position, jumpPower, 1, jumpDuration, false));
        seq.Insert(0f, transform.DORotate(new Vector3(0f, 0f, angle), jumpDuration, RotateMode.FastBeyond360));

        seq.Play();

        yield return seq.WaitForCompletion();

        FindObjectOfType<GameManager>().LoseGame();
    }
}
