using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

namespace Assets.Scripts.UI
{
    public class PanelAddressSetting : PanelBase<PanelAddressSetting>, ISimuPanel
    {
        public InputField inputField_get;
        public InputField inputField_post;
        public Action<string> OnSetGetAddress;
        public Action<string> OnSetPostAddress;
        // Start is called before the first frame update
        void Start()
        {
            inputField_get.onValueChanged.AddListener((string value) =>
            {
                OnSetGetAddress.Invoke(value);
            });
            inputField_post.onValueChanged.AddListener((string value) =>
            {
                OnSetPostAddress.Invoke(value);
            });
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void SetAddressPanel(string getTrafficAddress,string postTrafficAddress)
        {
            inputField_get.text = getTrafficAddress.ToString();
            inputField_post.text = postTrafficAddress.ToString();
        }
        private void SetResultText(string content)
        {
            Debug.Log(content);
            PanelNotice.Instance.SetNotice(content);
        }
    }
}
