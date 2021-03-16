using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

namespace Assets.Scripts.UI
{
    public class PanelDown : PanelBase<PanelDown>, ISimuPanel
    {
        public InputField inputField_get;
        public InputField inputField_post;
        public Button button_get;
        public Button button_post;
        public Button button_postForm;
        public Text text_Result;
        // Start is called before the first frame update
        void Start()
        {
            CVManager.Instance.addressNode.OnAddressConfigChange += SetPanelDown;
            CVManager.Instance.webRequesetServer.OnPostRequest += SetResultText;
            CVManager.Instance.webRequesetServer.OnGetRequest += SetResultText;
            inputField_get.onValueChanged.AddListener((string value) =>
            {
                CVManager.Instance.webRequesetServer.getAddress = value;
            });
            inputField_post.onValueChanged.AddListener((string value) =>
            {
                CVManager.Instance.webRequesetServer.postAddress = value;
            });
            button_get?.onClick.AddListener(() =>
            {
                Debug.Log("click get");
                StartCoroutine(CVManager.Instance.webRequesetServer.GetWebRequest());
            });
            button_post.onClick.AddListener(() =>
            {
                StartCoroutine(CVManager.Instance.webRequesetServer.PostWebRequest("{\"light_id\":\"light_3\",\"color\":3,\"remain\":30}"));
            });
            button_postForm.onClick.AddListener(() =>
            {
                StartCoroutine(CVManager.Instance.webRequesetServer.PostWebRequest_Form(new TrafficLightData("traffic",1,30)));
            });
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void SetPanelDown(AddressConfig config)
        {
            inputField_get.text = config.getTrafficAddress.ToString();
            inputField_post.text = config.postTrafficAddress.ToString();
        }
        private void SetResultText(string content)
        {
            Debug.Log(content);
            text_Result.text = content;
        }
    }
}
