using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    [SerializeField] private Text _weaponText;
    [SerializeField] private Text _gameoverText;
    [SerializeField] private Text _restartText;
    [SerializeField] private Text _winGameText;
    [SerializeField] HealthController _healthController;
    [SerializeField] GameManager _gameManager;
    [SerializeField] BossFight _bossFight;
    
    // Start is called before the first frame update
    void Start()
    {
        _weaponText.text = "Weapon: " + 1;
        _gameoverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _winGameText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameOver();
    }

    public void updateWeapon(int currWeapon)
    {
        _weaponText.text = "Weapon: " + currWeapon.ToString();
    }

    public void gameOver()
    {
        if (_healthController.playerHealth <= 0)
        {
            _gameoverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            _gameManager.GameOver();
        }
    }

    public void winGame()
    {
        if (_bossFight.currentHealth < 1)
        {
            _winGameText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            _gameManager.GameOver();
        }
    }
}
