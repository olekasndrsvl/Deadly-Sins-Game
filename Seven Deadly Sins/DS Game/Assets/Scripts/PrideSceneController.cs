using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrideSceneController : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject SplashImage;
    public HitBox PlayerHitbox;
    public GameObject Enemy;
    public GameObject tips;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public GameObject Dialog3;
    public GameObject _WinningDialog;
    public GameObject _LosingDialog;
    public GameObject _Died_Dialog;
    int dialognumber = 1;
    int dialog1;
    int dialog2;
    int dialog3;
    
    void PauseIt()
    {
        PlayerHitbox.gameObject.transform.parent.GetComponent<PlayerControllerForJoyStick>().IsPaused = false;
        Enemy.GetComponent<EnemyScript>().IsPaused = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        tips.GetComponent<TMP_Text>().text = "Это будет тяжелая борьба с самим собой Морт!";
        if (PlayerPrefs.HasKey("DialogNumber"))
        {
            dialognumber = PlayerPrefs.GetInt("DialogNumber");
        }
        else
        {
            PlayerPrefs.SetInt("DialogNumber", 1);
        }

        if (PlayerPrefs.HasKey("EnemyDamage"))
        {
            Enemy.GetComponent<EnemyScript>().DamageAmount = PlayerPrefs.GetInt("EnemyDamage");
        }
        else
        {
            PlayerPrefs.SetInt("EnemyDamage", Enemy.GetComponent<EnemyScript>().DamageAmount);
        }

        if (dialognumber > 1)
        {
            SplashImage.SetActive(false);
        }


    }
    public void FirstFight()
    {
        Dialog1.SetActive(false);
        if(dialog1 > 0)
        {
            Enemy.GetComponent<EnemyScript>().DamageAmount += 20;
            Enemy.GetComponent<EnemyScript>().HealthPoints =100;
            PlayerHitbox.HealthPoints =100;
            PlayerPrefs.SetInt("EnemyDamage", Enemy.GetComponent<EnemyScript>().DamageAmount);
            PlayerHitbox.gameObject.transform.parent.position = Vector3.zero;
            dialognumber++;
            PlayerPrefs.SetInt("DialogNumber", dialognumber);

            PauseIt();
        }
        else
        {
            
            LosingDialog(Dialog1);
        }

    }
    public void SecondFight()
    {
        Dialog2.SetActive(false);
        if (dialog2 > 0)
        {
            Enemy.GetComponent<EnemyScript>().DamageAmount += 20;
            PlayerPrefs.SetInt("EnemyDamage", Enemy.GetComponent<EnemyScript>().DamageAmount);
            Enemy.GetComponent<EnemyScript>().HealthPoints = 100;
            PlayerHitbox.HealthPoints = 100;
            PlayerHitbox.gameObject.transform.parent.position = Vector3.zero;
            dialognumber++;
            PlayerPrefs.SetInt("DialogNumber", dialognumber);
            PauseIt();
        }
        else
        {
          
            LosingDialog(Dialog2);
        }

    }
    public void ThirdFight()
    {
        Dialog3.SetActive(false);

        if (dialog3 > 0)
        {
            tips.GetComponent<TMP_Text>().text = "Ты выбрал неверный путь, мой друг! Твое ненасытное желание побеждать всех и каждого сыграло с тобой злую шутку...";
            Enemy.GetComponent<EnemyScript>().DamageAmount = 100;
            //PlayerPrefs.SetInt("EnemyDamage", Enemy.GetComponent<EnemyScript>().DamageAmount);
            Enemy.GetComponent<EnemyScript>().HealthPoints = 100;
            PlayerHitbox.HealthPoints = 100;
            PlayerHitbox.gameObject.transform.parent.position = Vector3.zero;
            dialognumber++;
            
            PauseIt();

        }
        else
        {
            
            _WinningDialog.SetActive(true);
            

        }

    }
    public void LosingDialog(GameObject dial)
    {
        
        dial.SetActive(false);
        _LosingDialog.SetActive(true);
       
    }

    public void FinallDialog()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene("DistributionScene", LoadSceneMode.Single);
    }

    public void Replay()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (PlayerHitbox.HealthPoints < 0)
        {
            PauseIt();
            PlayerHitbox.HealthPoints = 1;
            _Died_Dialog.SetActive(true);
            
        }


        if (Enemy.GetComponent<EnemyScript>().HealthPoints <= 0)
        {
            switch(dialognumber)
            {
                case 1:
                    Enemy.GetComponent<EnemyScript>().HealthPoints = 1;
                    Dialog1.SetActive(true);
                    PlayerHitbox.HealthPoints = 100;
                    Enemy.GetComponent<EnemyScript>().IsPaused = true;
                   PlayerHitbox.gameObject.transform.parent.GetComponent<PlayerControllerForJoyStick>().IsPaused = true;
                    break;
                case 2:
                    Enemy.GetComponent<EnemyScript>().HealthPoints = 1;
                    Dialog2.SetActive(true);
                    PlayerHitbox.HealthPoints = 100;
                    Enemy.GetComponent<EnemyScript>().IsPaused = true;
                    PlayerHitbox.gameObject.transform.parent.GetComponent<PlayerControllerForJoyStick>().IsPaused = true;
                    break;
                case 3:
                    Enemy.GetComponent<EnemyScript>().HealthPoints = 1;
                    Dialog3.SetActive(true);
                    PlayerHitbox.HealthPoints = 100;
                    Enemy.GetComponent<EnemyScript>().IsPaused = true;
                    PlayerHitbox.gameObject.transform.parent.GetComponent<PlayerControllerForJoyStick>().IsPaused = true;
                    break;
                case 4:
                    break;


            }
        }

        dialog1 = Dialog1.GetComponent<Dialog>().DialogResult;
        dialog2 = Dialog2.GetComponent<Dialog>().DialogResult;
        dialog3 = Dialog3.GetComponent<Dialog>().DialogResult;
       
    }
}
