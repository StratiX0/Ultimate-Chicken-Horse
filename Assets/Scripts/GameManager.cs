using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Properties;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float time = 0;
    public TextMeshProUGUI timeText;
    [SerializeField] GameObject playerPrefab;
    private GameObject _player;
    public Player playerScript;
    
    public static GameManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _player = Instantiate(playerPrefab, new Vector3(-20, 0.5f, 0), Quaternion.identity);
        playerScript = _player.GetComponent<Player>();
        timeText = GameObject.Find("Time Value").GetComponent<TextMeshProUGUI>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Death() && !Finish())
        {
            UpdateTime();
        }
        
        if (_player != null && Death())
        {
            playerScript.playerTransform.DetachChildren();
            Destroy(_player);
        }
    }
    
    public void UpdateTime()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F2");
    }
    
    public bool Finish()
    {
        if (playerScript.inFinish)
        {
            return true;
        }
        return false;
    }

    public bool Death()
    {
        if (playerScript.inDeath)
        {
            return true;
        }
        return false;
    }
}
