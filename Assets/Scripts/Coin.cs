using UnityEngine;

public class Coin : MonoBehaviour

{
    private GameManager gameManager;
    public AudioClip coinSound;
    public GameObject collectEffect;
    public GameObject collectEffect1;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
          }

   private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        gameManager.AddCoin();

        if (coinSound != null)
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
        }
        Instantiate(
    collectEffect,
    transform.position,
    Quaternion.identity);
    Instantiate(
    collectEffect1,
    transform.position,
    Quaternion.identity);

        Destroy(gameObject);
    }
}
}