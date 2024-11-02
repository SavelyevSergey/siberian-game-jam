using UnityEngine;

namespace Core.Singleton
{
	public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance                 = new GameObject().AddComponent<T>();
					_instance.gameObject.name = $"Singleton_{_instance.GetType().Name}";
				}

				return _instance;
			}
		}
	}
}