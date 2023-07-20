using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void StartGame(){
        SceneManager.LoadScene("Game");
    }

    private void ShowTickOatTwoText(bool show){
        transform.Find("TickOatTwo text").gameObject.SetActive(show);
    }

    private void ShowWildTicTacToeText(bool show){
        transform.Find("Wild tic-tac-toe text").gameObject.SetActive(show);
    }

    private void ShowPlayerNumber(bool show){
        transform.Find("PlayerNumber").gameObject.SetActive(show);
    }
    private void ShowGameTypes(bool show){
        transform.Find("GameTypes").gameObject.SetActive(show);
    }

    public void TicTacToe(){
        GameOptions.GameType = GameType.TicTacToe;
        ShowGameTypes(false);
        ShowPlayerNumber(true);
    }

    public void TickOatTwo(){
        GameOptions.GameType = GameType.TickOatTwo;
        ShowGameTypes(false);
        ShowPlayerNumber(true);
    }

    public void WildTicTacToe(){
        GameOptions.GameType = GameType.WildTicTacToe;
        ShowGameTypes(false);
        ShowPlayerNumber(true);
    }

    public void TickOatTwoInfo(){
        ShowGameTypes(false);
        ShowTickOatTwoText(true);
    }

    public void CloseTickOatTwoInfo(){
        ShowTickOatTwoText(false);
        ShowGameTypes(true);
    }

    public void CloseWildTicTacToeInfo(){
        ShowWildTicTacToeText(false);
        ShowGameTypes(true);
    }

    public void WildTicTacToeInfo(){
        ShowGameTypes(false);
        ShowWildTicTacToeText(true);
    }

    public void SinglePlayerSelected(){
        GameOptions.SinglePlayer = true;
        StartGame();
    }

    public void MultiPlayerSelected(){
        GameOptions.SinglePlayer = false;
        StartGame();
    }

    public void PlayerSelectBack(){
        ShowPlayerNumber(false);
        ShowGameTypes(true);
    }
}
