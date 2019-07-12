using System;

namespace ExpertSystem
{
    interface IRulePartCollection<T>
    {
        int Count { get; }

        Guid Add(T item) ;

        bool Remove(T item);

        bool Remove(Guid ID);
    }
}