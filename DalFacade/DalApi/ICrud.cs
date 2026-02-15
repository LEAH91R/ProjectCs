

using DO;

namespace DalApi
{
   public  interface ICrud<T>
    {
        int Create(T t);
        T? Read(int id);
<<<<<<< HEAD
        T? Read(Func<T?,bool> filter);
        List<T?> ReadAll(Func<T, bool>? filter = null); // stage 2
=======
        T? Read(Func<T, bool> filter);
        List<T?> ReadAll(Func<T, bool>? filter = null);
>>>>>>> d46e9f8b71c4a2a8f0d2c4a4f8c4cea0a668c973
        void Update(T t);
        void Delete(int id);
    }
}
