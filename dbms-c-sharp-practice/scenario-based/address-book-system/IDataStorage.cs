using System.Collections.Generic;

namespace AddressBookSystem
{
    internal interface IDataStorage
    {
        void Save(List<Contact> contacts);
        List<Contact> Load();
    }
}
