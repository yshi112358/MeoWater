using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;
using Game.Neko;

namespace Game.NekoDebug
{
	public class DebugNekoCollision : MonoBehaviour
	{
		private ReactiveCollection<NekoData> _nekoCollisionList => GetComponent<NekoCollisionList>().nekoCollisionList;
		void Awake()
		{
			var lineList = new List<GameObject>();
			this.UpdateAsObservable()
				.TakeUntilDisable(this.gameObject)
				.Subscribe(_ =>
				{
					foreach (var nekoData in _nekoCollisionList)
					{
						Vector3[] positions = new Vector3[]{
							(nekoData.gameObject.transform.GetChild(0).position+nekoData.gameObject.transform.GetChild(4).position)/2f,          // 開始点
							(transform.GetChild(0).position+transform.GetChild(4).position)/2f               // 終了点
						};
						lineList.Where(line => line.name == nekoData.gameObject.GetInstanceID().ToString()).First().GetComponent<LineRenderer>().SetPositions(positions);
					}
				}, () =>
				{
					lineList.ForEach(line => Destroy(line));
					Debug.Log("Oncompleted");
				});
			_nekoCollisionList.ObserveAdd()
				.Subscribe(nekoData =>
				{
					var line = new GameObject();
					line.name = nekoData.Value.gameObject.GetInstanceID().ToString();
					lineList.Add(line);
					var linerend = line.gameObject.AddComponent<LineRenderer>();
					linerend.startWidth = 0.1f;                   // 開始点の太さを0.1にする
					linerend.endWidth = 0.1f;
					linerend.sortingOrder = 10;

				})
				.AddTo(this);
			_nekoCollisionList.ObserveRemove()
				.Subscribe(nekoData =>
				{
					var line = lineList.Where(line => line.name == nekoData.Value.gameObject.GetInstanceID().ToString()).First();
					lineList.Remove(line);
					Destroy(line);
				})
				.AddTo(this);
		}
	}
}