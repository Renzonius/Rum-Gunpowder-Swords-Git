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
        if (!gameObject.activeInHierarchy) return null; // Evita generar si el GameObject est� desactivado

        if (pool.Count <= 0)
        {
            // Si no hay objetos disponibles en el pool, creamos uno nuevo
            CreateObject();
        }

        T objeto = pool.Dequeue();
        objeto.Activate(); // Activamos el objeto antes de devolverlo
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
        // Instanciamos un nuevo objeto y lo desactivamos
        T nuevoObjeto = Instantiate(_prefabObject);
        nuevoObjeto.Deactivate();
        pool.Enqueue(nuevoObjeto); // Lo agregamos al pool
        nuevoObjeto.transform.SetParent(_objectContainer.transform);
    }

}
