using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SIPlayer : MonoBehaviour, CityBombCondition
{
    GameObject siPlayer;
    [SerializeField] float speed;
    Action gameState;
    Transform tempPos;
    [SerializeField] GameObject ammoprefap;
    public SIEnemyAI enemyAIMirror;
    [SerializeField] int playerHP;
    bool canHit = true;
    [SerializeField] GameObject playerSprite;
    [SerializeField] TMP_Text playerHPText;

    List<GameObject> hpUIList = new();
    [SerializeField] GameObject hpPanal, hpPicPrefab;
    [SerializeField] AudioClip shotSound, getHitSound;

    private void Awake()
    {
        siPlayer = this.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerHP; i++)
        {
            hpUIList.Add(Instantiate(hpPicPrefab, hpPanal.transform));
        }
        gameState = WaitForStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != null)
            gameState();
        playerHPText.text = playerHP.ToString();
    }

    void MiniGameRun()
    {
        tempPos = siPlayer.transform;

        tempPos.Translate(new Vector2((Input.GetAxisRaw("Horizontal") * speed) * Time.deltaTime, (Input.GetAxisRaw("Vertical") * speed) * Time.deltaTime));

        tempPos.position = new Vector2(Mathf.Clamp(tempPos.position.x, -8f, 8f), Mathf.Clamp(tempPos.position.y, -4f, 4f));

        siPlayer.transform.position = tempPos.position;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotAmmo();
        }

        enemyAIMirror.EnemyMove();
    }

    void WaitForStart()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeState(MiniGameRun);
            enemyAIMirror.ShotAmmo();
            SIGameManager.Instance.StartGame();
        }
    }

    void ChangeState(Action state)
    {
        gameState = state;
    }

    void ShotAmmo()
    {
        GameObject temp = Instantiate(ammoprefap, siPlayer.transform.position, siPlayer.transform.rotation);
        temp.tag = "PlayerObj";
        temp.gameObject.GetComponent<SIAmmo>().ammoFrom = "PlayerObj";
        SIGameManager.Instance.PlaySound(shotSound);
    }

    public void IsHit()
    {
        LossHP();
    }

    void LossHP()
    {
        if (canHit)
        {
            canHit = false;
            playerHP -= 1;
            SIGameManager.Instance.PlaySound(getHitSound);
            if (playerHP < 0)
            {
                OnLose();
            }
            else
            {
                hpUIList[playerHP].SetActive(false);
                StartCoroutine(FlashHP());
            }
        }
    }

    IEnumerator FlashHP()
    {
        for (int i = 0; i < 5; i++)
        {
            playerSprite.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            playerSprite.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
        canHit = true;
    }

    void OnLose()
    {
        enemyAIMirror.StopAllCoroutines();
        SIGameManager.Instance.StopGame();
        StartCoroutine(JustWait());
        //play dies ani
    }

    void Nothing()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SIGameManager.Instance.LoadScene(1);
        }
    }

    public void EndGame()
    {
        enemyAIMirror.StopAllCoroutines();
        SIGameManager.Instance.StopGame();
        StartCoroutine(JustWait());
    }

    IEnumerator JustWait()
    {
        ChangeState(null);
        yield return new WaitForSeconds(2f);
        ChangeState(Nothing);
    }
}
