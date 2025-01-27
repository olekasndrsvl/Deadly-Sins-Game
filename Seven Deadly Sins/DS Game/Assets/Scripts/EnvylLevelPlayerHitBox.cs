using System.Collections;
using TMPro;
using UnityEngine;

public class EnvylLevelPlayerHitBox : MonoBehaviour
{
     
    public string Deb;
    public int HealthPoints;
    public int DamageAmount=10;
    public GameObject HP_text;
    public Animator AtackAnimator;
    public AudioClip[] HitButtonSounds;
    private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Deb = collision.tag;
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.transform.Find("HitBox").GetComponent<BetterVersionOfMprtScript>().HealthPoints-=DamageAmount;
        }
    }
    IEnumerator Hint(float sec)
    {
        AtackAnimator.SetBool("IsFighting",true);
        transform.localPosition = new Vector3(5, 0, 0);
        yield return new WaitForSeconds(sec);
        transform.localPosition = new Vector3(0,0,0);
        AtackAnimator.SetBool("IsFighting",false);
    }
    public void OnActionButtonClicked()
    {
        PlayHitButtonSound();
        StartCoroutine(Hint(.5f));
    }
    private void PlayHitButtonSound()
    {
        if (HitButtonSounds.Length > 0 && audioSource != null)
        {
            int soundIndex = Random.Range(0, HitButtonSounds.Length);
            audioSource.PlayOneShot(HitButtonSounds[soundIndex]);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthPoints = 100;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource не найден на объекте HitBox!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        HP_text.GetComponent<TMP_Text>().text = "Здоровье: "+HealthPoints.ToString();

        //if (HealthPoints <= 0)
        //{

        //    //TODO: activate dialog
          
        //}
    }
}
