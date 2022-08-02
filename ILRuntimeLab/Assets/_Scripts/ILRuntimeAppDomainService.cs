using ILRuntime.Runtime.Enviorment;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Bear
{
    public class ILRuntimeAppDomainService
    {
        public AppDomain app = new AppDomain();

        //public void Load(M caller,string address, System.Action DOnFinishLoading) {
        //    MonoBehaviour.StartCoroutine(CoLoad(address,DOnFinishLoading));
        //}
        public void Load(string address,System.Action DOnFinishLoading) {
            UnityWebRequest request = UnityWebRequest.Get(address);
            byte[] dllfileByte;

            request.SendWebRequest().completed += (asycnOperator) => {
                if (!string.IsNullOrEmpty(request.error))
                {
                    Debug.LogError($"Cannot load from address {address}");
                }
                else
                {
                    dllfileByte = request.downloadHandler.data;
                    request.Dispose();

                    MemoryStream fs = new MemoryStream(dllfileByte);
                    app.LoadAssembly(fs);

                    DOnFinishLoading?.Invoke();
                }
            };

           

            //app.Invoke("HotFix_Project.InstanceClass", "StaticFunTest", null, null);
        }

        public void LoadAddressable(string address) { 

        }

       
    }
}
