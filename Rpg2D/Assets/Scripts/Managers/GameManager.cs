using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private IGameState _currentState; // estado atual do game

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);// persiste entre as cenas
        }
        else
        {
            Destroy(gameObject); // garante que so tenha 1 instância    
        }
    }

    private void Start()
    {
        ChangeState(new MenuState());
    }

    public void ChangeState(IGameState newState)
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter();
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.Update();
        }
    }
}
