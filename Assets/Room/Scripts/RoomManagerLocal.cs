using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManagerLocal : MonoBehaviour {

    static public RoomManagerLocal instance { get; set; }

    public GameObject switchObject;
    public GameObject damageShip;

    [Header("Animator StartGame")]
    public Animator anim;

    //Проверка на чек( перенести в методы)
    private bool check = true;
    private bool checkLamp = true;
    private bool onLamp = true;

    [Header("Lights")]
    public GameObject mainLight;
    public GameObject lampLight;

    [Header("Rooms")]
	public GameObject OldScene;
	public GameObject NewScene;

    // Use this for initialization
    void Start () {
        Application.runInBackground = true;
        instance = this;
        StartCoroutine(StartGameCour());
	}


    #region Objects

    public void LightOnOff()
    {
        if (check == true)
        {
            Debug.Log("Light on");
            mainLight.SetActive(false);
            check = false;
            switchObject.transform.eulerAngles = new Vector3(-70, 0, 0);
            damageShip.SetActive(true);
            SoundManager.PlaySound("swith");
        }
        else
        {
            mainLight.SetActive(true);
            check = true;
            switchObject.transform.eulerAngles = new Vector3(-90, 0, 0);
            damageShip.SetActive(false);
            SoundManager.PlaySound("swith");
        }
    }

    public void LampLight()
    {
        if (checkLamp == true)
        {
            checkLamp = false;
            lampLight.SetActive(false);
        }
        else
        {
            checkLamp = true;
            lampLight.SetActive(true);
        }
    }

    public void Magnitola(bool check)
    {
        if (check == false)
        {
            SoundManager.PlaySound("magnitola");
            StartCoroutine(PlayVoice());
            check = true;
        }
        else
        {
            SoundManager.PlaySound("magnitola");
            SoundManager.StopSound("12 апреля 1961г");
            check = false;
        }
    }

    public void OpenSafe()
    {
        GameObject.Find("Seyf_door").transform.eulerAngles = new Vector3(-90f, 0f, -80f); //Тестовая строка
        //Запуск анимации кнопки
        //Запуск анимации приоткрытия двери сейфа
    }

    public void DenideSafe()
    {
        //Нету доступа до сейфа
        //Анимация кнопки, вызов звука
    }


    public void Phone(string nameSound)
    {
        Debug.Log(nameSound);
        SoundManager.PlaySound(nameSound);
    }

    #endregion


    #region Coroutine

    IEnumerator StartGameCour()
    {
        SoundManager.PlaySound("г1 легенда");
        yield return new WaitForSeconds(166);//166 секунд 
        StartCoroutine(NewRoom());
        StopCoroutine(StartGameCour());
    }

    IEnumerator NewRoom()
    {
        anim.SetTrigger("start");
        SoundManager.PlaySound("8549");
        OldScene.SetActive(false);
        yield return new WaitForSeconds(2);
        NewScene.SetActive(true);
        StopCoroutine(NewRoom());
    }

    IEnumerator PlayVoice()
    {
        SoundManager.PlaySound("12 апреля 1961г");
        yield return new WaitForSeconds(104);
        SoundManager.PlaySound("magnitola");
        StopCoroutine(PlayVoice());
    }

    #endregion

}
