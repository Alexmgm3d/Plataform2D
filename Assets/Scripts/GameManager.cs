using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefarb;

    [Header("Enimies")]
    public List<GameObject> enimies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
   
  
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;


    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
    }



    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefarb);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();
    }
} 