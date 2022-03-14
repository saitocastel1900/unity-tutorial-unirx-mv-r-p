using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
　実体を保持
 */
namespace UniRx.MVRP
{
    public class Model : MonoBehaviour
    {
        [SerializeField] private IntReactiveProperty _current = new IntReactiveProperty(0);

        public IReadOnlyReactiveProperty<int> Current => _current;

        public void UpdateCount(int value)
        {
            _current.Value = Mathf.Clamp(value, 0, 100);
        }
    }
}
