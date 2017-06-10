using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarController : MonoBehaviour
{
    public GameObject _calendarPanel;
    public Text _yearNumText;
    public Text _monthNumText;

    public GameObject _item;

    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    private DateTime _dateTime;
    public static CalendarController _calendarInstance;
	//public Text _target;

    void Start()
    {
        _calendarInstance = this;
        Vector3 startPos = _item.transform.localPosition;
        _dateItems.Clear();
        _dateItems.Add(_item);

        for (int i = 1; i < _totalDateNum; i++)
        {
            GameObject item = GameObject.Instantiate(_item) as GameObject;
            item.name = "Item" + (i + 1).ToString();
            item.transform.SetParent(_item.transform.parent);
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
			item.transform.localPosition = new Vector3((i % 7) * 110 + startPos.x, startPos.y - (i / 7) * 110, startPos.z);

            _dateItems.Add(item);
        }

        _dateTime = DateTime.Now;

        CreateCalendar();

        //_calendarPanel.SetActive(false);
    }

	void CreateCalendar()
    {
        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);


        int date = 0;
        for (int i = 0; i < _totalDateNum; i++)
        {
            Text label = _dateItems[i].GetComponentInChildren<Text>();
			Button ButtonDisable = _dateItems[i].GetComponent<Button>();
            _dateItems[i].SetActive(false);

            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);

				//print (thatDay.Month +"---"+ _dateTime.Month  +"--////--"+  thatDay.Day +"---"+  _dateTime.Day);
				if (thatDay.Month == firstDay.Month) {
					_dateItems [i].SetActive (true);
					//DateTime ThatDayCheck = new DateTime (thatDay.Year, thatDay.Month, thatDay.Day);
					//DateTime DateTimeCheck = new DateTime (_dateTime.Year, _dateTime.Month, _dateTime.Day);
					if (thatDay.Year <= DateTime.Now.Year && thatDay.Month <= DateTime.Now.Month  && thatDay.Day <= DateTime.Now.Day) {
						label.text = "[" + (date + 1).ToString () + "]";
						Destroy (ButtonDisable);
					} else if(thatDay.Year <= DateTime.Now.Year && thatDay.Month < DateTime.Now.Month){
						label.text = "[" + (date + 1).ToString () + "]";
						Destroy (ButtonDisable);
					} else if(thatDay.Year < DateTime.Now.Year){
						label.text = "[" + (date + 1).ToString () + "]";
						Destroy (ButtonDisable);
					}else {
						label.text = (date + 1).ToString ();
					}
					print ("1nd" + thatDay.Month+ " ---///--- "+ DateTime.Now.Month);
					date++;
				}
            }
        }
        _yearNumText.text = _dateTime.Year.ToString();
		_monthNumText.text = _dateTime.Month.ToString ();
		string _NameOfMonth = _monthNumText.text;
		if(_monthNumText.text == "1"){
			_NameOfMonth = "January";
		} else if(_monthNumText.text == "2"){
			_NameOfMonth = "February";
		} else if(_monthNumText.text == "3"){
			_NameOfMonth = "March";
		} else if(_monthNumText.text == "4"){
			_NameOfMonth = "April";
		} else if(_monthNumText.text == "5"){
			_NameOfMonth = "May";
		} else if(_monthNumText.text == "6"){
			_NameOfMonth = "June";
		} else if(_monthNumText.text == "7"){
			_NameOfMonth = "July";
		} else if(_monthNumText.text == "8"){
			_NameOfMonth = "August";
		} else if(_monthNumText.text == "9"){
			_NameOfMonth = "September";
		} else if(_monthNumText.text == "10"){
			_NameOfMonth = "October";
		} else if(_monthNumText.text == "11"){
			_NameOfMonth = "November";
		} else if(_monthNumText.text == "12"){
			_NameOfMonth = "December";
		}
		_monthNumText.text = _NameOfMonth;
		//print ("_NameOfMonth"+_NameOfMonth);
    }

    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }

        return 0;
    }
    public void YearPrev()
    {
        _dateTime = _dateTime.AddYears(-1);
        CreateCalendar();
    }

    public void YearNext()
    {
        _dateTime = _dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        _dateTime = _dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        _dateTime = _dateTime.AddMonths(1);
        CreateCalendar();
    }

    public void ShowCalendar(Text target)
    {
        _calendarPanel.SetActive(true);
       // _target = target;
        //_calendarPanel.transform.position = new Vector3(4,114,0);
    }

    
    public void OnDateItemClick(string day)
    {
		print(" Year " +  _yearNumText.text + " Month " + MonthName(_monthNumText.text)+ " Day "  + day);
        //_calendarPanel.SetActive(false);
    }

	//change numberMonth to nameMonth
	string MonthName(string _NumbMonth){
		string _NameOfMonth = _NumbMonth;
		if(_monthNumText.text == "1"){
			_NameOfMonth = "January";
		} else if(_monthNumText.text == "2"){
			_NameOfMonth = "February";
		} else if(_monthNumText.text == "3"){
			_NameOfMonth = "March";
		} else if(_monthNumText.text == "4"){
			_NameOfMonth = "April";
		} else if(_monthNumText.text == "5"){
			_NameOfMonth = "May";
		} else if(_monthNumText.text == "6"){
			_NameOfMonth = "June";
		} else if(_monthNumText.text == "7"){
			_NameOfMonth = "July";
		} else if(_monthNumText.text == "8"){
			_NameOfMonth = "August";
		} else if(_monthNumText.text == "9"){
			_NameOfMonth = "September";
		} else if(_monthNumText.text == "10"){
			_NameOfMonth = "October";
		} else if(_monthNumText.text == "11"){
			_NameOfMonth = "November";
		} else if(_monthNumText.text == "12"){
			_NameOfMonth = "December";
		}

		return _NameOfMonth;
	}
}
