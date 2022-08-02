using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bear
{
    public class ILRuntimeHelloWorldTestor : MonoBehaviour
    {
        ILRuntimeAppDomainService app = new ILRuntimeAppDomainService();
        private void Awake()
        {
            string address = "file:///" + Application.streamingAssetsPath + "/HotFix_Project.dll";
            app.Load(address, () => {
                app.app.Invoke("HotFix_Project.InstanceClass", "StaticFunTest", null, null);
            });
        }
    }
}