using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheEndUI : MonoBehaviour
{
    public Text windowtext;
    public GameObject endWindow;
    public void showBadEnd()
    {
        windowtext.text = "Ваша миссия провалена. Отчет о ваших действиях будет отправлен в компанию “Апертурная наука”, чтобы ученые оттуда учли ошибки, совершенные во время Вашего создания, и больше их не повторили.";
        endWindow.SetActive(true);

    }

    public void showHappyEnd()
    {
        windowtext.text = "Поздравляем! Вы успешно добрались до новой планеты, ведь большая часть экипажа осталась в живых, а проблемы на корабле не вызвали у Вас больших затруднений. Человечество сделало еще один шаг в сторону колонизации космоса, а Вы справились со своей главной задачей.";
        endWindow.SetActive(true);
    }
}
