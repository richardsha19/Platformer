using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public GameObject person;
    public Player player;
    public TMP_Text scoreText;
    //private int coinCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        //coinCounter = player.GetCoinCounter();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.GetCoinCounter());
        //scoreText.text = (coinCounter + player.GetCoinCounter()).ToString();
        //scoreText.text = Player.coinCounter.ToString();
    }
}
