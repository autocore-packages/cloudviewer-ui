using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Scripts.UI
{
    public struct PanelTrafficLightData
    {
        public string name;
        public int color;
        public int time;
    }

    public class PanelTrafficLight : PanelBase<PanelTrafficLight>, ISimuPanel
    {
        private PanelTrafficLightData panelData;

        public Text text_name;
        public Button button_set;
        public Toggle toggle_R;
        public Toggle toggle_Y;
        public Toggle toggle_g;
        public Text text_setscends;
        public InputField inputField_Scends;
        public TrafficLight trafficLight;

        public Image image_color;
        public Text text_second;

        public Action<PanelTrafficLightData> OnSetTraffic;

        private void Start()
        {
            button_set.onClick.AddListener(PostTraffic);
        }
        private void PostTraffic()
        {
            panelData.name = text_name.text;
            panelData.time = int.Parse(inputField_Scends.text);
            if (toggle_R.isOn) panelData.color = 1;
            else if (toggle_g.isOn) panelData.color = 2;
            else if (toggle_Y.isOn) panelData.color = 3;
            OnSetTraffic.Invoke(panelData);
        }
        void InitPanel(PanelTrafficLightData data)
        {
            SetPanelActive(true);
            panelData = data;
            text_name.text = panelData.name;
            inputField_Scends.text = panelData.time.ToString();
            switch (panelData.color)
            {
                case 0:
                    break;
                case 1:
                    toggle_R.isOn = true;
                    break;
                case 2:
                    toggle_g.isOn = true;
                    break;
                case 3:
                    toggle_Y.isOn = true;
                    break;
                default:
                    break;
            }
        }

    }
}
