using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component, IPoolable
{
    [SerializeField] private T _prefabObject; // Prefab del objeto a gestionar
    [SerializeField] private GameObject _objectContainer;
    [SerializeField] private int _initialAmount = 3; // Cantidad inicial de objetos en el pool

    private Queue<T> pool = new Queue<T>();

    private void Start()
    {
        pool.Clear();
        //Inicializamos el pool con objetos ya instanciados
        for (int i = 0; i < _initialAmount; i++)
        {
            CreateObject();
        }
    }

    public T GetObject()
    {
        if (!gameObject.activeInHierarchy) return null;

        if (pool.Count <= 0)
        {
            CreateObject();
        }

        T objeto = pool.Dequeue();
        // Asignar el pool si el objeto es PirateEnemyBase
        if (objeto is PirateEnemyBase enemy)
        {
            enemy.SetPool(this as ObjectPool<PirateEnemyBase>);
        }
        objeto.Activate();
        return objeto;
    }

    public void ReturnObject(T objeto)
    {
        objeto.Deactivate(); // Desactivamos el objeto antes de devolverlo al pool
        //objeto.gameObject.SetActive(false);
        pool.Enqueue(objeto); // Lo volvemos a agregar al pool
    }

    private void OnDisable()
    {
        // Limpiamos el pool cuando el objeto que lo contiene se desactiva
        pool.Clear();
    }

    private void CreateObject()
    {
        T nuevoObjeto = Instantiate(_prefabObject);
        // Asignar el pool si el objeto es PirateEnemyBase
        if (nuevoObjeto is PirateEnemyBase enemy)
        {
            enemy.SetPool(this as ObjectPool<PirateEnemyBase>);
        }
        nuevoObjeto.Deactivate();
        pool.Enqueue(nuevoObjeto);
        nuevoObjeto.transform.SetParent(_objectContainer.transform);
    }


}
