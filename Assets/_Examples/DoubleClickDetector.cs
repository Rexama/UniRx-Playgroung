using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _Examples
{
    public class DoubleClickDetector : MonoBehaviour
    {
        private void Start()
        {
            var clickStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));

            clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
                .Where(x => x.Count >= 2)
                .Subscribe(x => OnDoubleClick());
        }
        
        private void OnDoubleClick()
        {
            Debug.Log("DoubleClick Detected!");
        }
    }
}