using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrideSceneController : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject SplashImage;
    public GameObject HP_text;
    public GameObject Enemy_HP_text;
    public GameObject player;
    public PlayerAttack PlayerHitbox;
    public Enemy enemy;
    public GameObject Enemy;
    public GameObject tips;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public GameObject Dialog3;
    public GameObject _WinningDialog;
    public GameObject _LosingDialog;
    public GameObject _Died_Dialog;
    int dialognumber = 1;
    int dialog1Result;
    int dialog2Result;
    int dialog3Result;
    
    void Resume()
    {
        enemy.IsPaused = false;
    }

    void Pause()
    {
        enemy.IsPaused = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TipConrtrollerScript.TipsTextMessage = "Это будет тяжелая борьба с самим собой Морт!";
        TipConrtrollerScript.IsNewTextAdded = true;
        
        
        dialognumber = PlayerPrefs.GetInt("DialogNumber",1);
        enemy.damageAmount = PlayerPrefs.GetInt("EnemyDamage",enemy.damageAmount);
        enemy.startTimeBetweenAttacks = PlayerPrefs.GetFloat("EnemyDelay", enemy.startTimeBetweenAttacks);
        PlayerHitbox.startTimeBetweenAttacks = PlayerPrefs.GetFloat("PlayerStartTime", PlayerHitbox.startTimeBetweenAttacks);
        
        if (dialognumber > 1)
        {
            SplashImage.SetActive(false);
        }


    }
   
    public void LosingDialog(GameObject dial)
    {
        dial.SetActive(false);
        _LosingDialog.SetActive(true);
       
    }

    public void FinalDialog()
    {
        LoadingScreen.SetActive(true);
        PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted",0) + 1);
        SceneManager.LoadScene("DistributionScene", LoadSceneMode.Single);
    }

    public void Replay()
    {
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("IsItRespawn", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        // Health points refresh
        HP_text.GetComponent<TMP_Text>().text = "Здоровье: "+PlayerHitbox.health.ToString();
        Enemy_HP_text.GetComponent<TMP_Text>().text = enemy.health.ToString();
        
        //Dialog result refesh
        dialog1Result = Dialog1.GetComponent<Dialog>().DialogResult;
        dialog2Result = Dialog2.GetComponent<Dialog>().DialogResult;
        dialog3Result = Dialog3.GetComponent<Dialog>().DialogResult;
        
        
        //Player died
        if (PlayerHitbox.health <= 0)
        {
            Pause();
            PlayerHitbox.health = 0;
            _Died_Dialog.SetActive(true);
        }

        // Enemy died
        if (enemy.health <= 0)
        {
            switch(dialognumber)
            {
                case 1:
                    enemy.health = 0;
                    Dialog1.SetActive(true);
                    Pause();
                    break;
                case 2:
                    enemy.health = 0;
                    Dialog2.SetActive(true);
                    Pause();
                    break;
                case 3:
                    enemy.health = 0;
                    Dialog3.SetActive(true);
                    Pause();
                    break;
            }
        }
    }
    
    
    //Кнопки закрытия диалогов
     public void FirstFight()
    {
        TipConrtrollerScript.TipsTextMessage= "Ты на верном пути, Морт!";
        TipConrtrollerScript.IsNewTextAdded = true;
        
        Dialog1.SetActive(false);
        if(dialog1Result > 0)
        {
            
            enemy.damageAmount = 20;
            enemy.startTimeBetweenAttacks = 2f;
            enemy.health = 100;
            PlayerPrefs.SetInt("EnemyDamage", enemy.damageAmount);
            PlayerPrefs.SetFloat("EnemyDelay", enemy.startTimeBetweenAttacks);
            
            player.transform.position = new Vector3(2, -1 , player.transform.position.z);
            PlayerHitbox.health =100;
            PlayerHitbox.startTimeBetweenAttacks = 1.5f;
            PlayerPrefs.SetFloat("PlayerStartTime", PlayerHitbox.startTimeBetweenAttacks);
            
            dialognumber++;
            PlayerPrefs.SetInt("DialogNumber", dialognumber);

            Resume();
        }
        else
        {
            
            LosingDialog(Dialog1);
        }

    }
    public void SecondFight()
    {
        TipConrtrollerScript.TipsTextMessage= "Ты на верном пути, Морт!";
        TipConrtrollerScript.IsNewTextAdded = true;
        
        
        Dialog2.SetActive(false);
        if (dialog2Result > 0)
        {
           
         
            enemy.damageAmount = 25;
            enemy.startTimeBetweenAttacks = 1.8f;
            enemy.health = 100;
            PlayerPrefs.SetInt("EnemyDamage", enemy.damageAmount);
            PlayerPrefs.SetFloat("EnemyDelay", enemy.startTimeBetweenAttacks);
            
            PlayerHitbox.health = 100;
            player.transform.position = new Vector3(2, -1, player.transform.position.z);
            PlayerHitbox.startTimeBetweenAttacks = 0.2f;
            PlayerPrefs.SetFloat("PlayerStartTime", PlayerHitbox.startTimeBetweenAttacks);
            
            dialognumber++;
            PlayerPrefs.SetInt("DialogNumber", dialognumber);
            Resume();
        }
        else
        {
          
            LosingDialog(Dialog2);
        }

    }
    public void ThirdFight()
    {
        Dialog3.SetActive(false);

        if (dialog3Result > 0)
        {
            
            TipConrtrollerScript.TipsTextMessage= "Ты выбрал неверный путь, мой друг! Твое ненасытное желание побеждать всех и каждого сыграло с тобой злую шутку...";
            TipConrtrollerScript.IsNewTextAdded = true;
            
            enemy.damageAmount = 50;
            enemy.startTimeBetweenAttacks = 0.4f;
            enemy.health = 100;
            
            PlayerHitbox.health = 100;
            PlayerHitbox.startTimeBetweenAttacks = 3f;
            player.transform.position = new Vector3(2, -1, player.transform.position.z);
            
            dialognumber++;
            
            Resume();

        }
        else
        {
            dialognumber++;
            _WinningDialog.SetActive(true);
            

        }

    }
}
