using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/Database")]

public class ItemDatabaseOS : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();         //ItemSO�� ����Ʈ�� ���� �Ѵ�.

    //ĳ���� ���� ����
    private Dictionary<int, ItemSO> itemsById;              //ID�� �������� ã�� ���� ĳ��
    private Dictionary<string, ItemSO> itemsByName;         //�̸����� ������ ã��

    public void Initialize()
    {
        itemsById = new Dictionary<int, ItemSO>();          //���� ���� �߱� ������ Dictionary�Ҵ�
        itemsByName = new Dictionary<string, ItemSO>();

        foreach(var item in items)                          //items ����Ʈ�� ���� �Ǿ� �ִ°��� ������ Dictionary�� �Է��Ѵ�.
        {
            itemsById[item.id] = item;
            itemsByName[item.name] = item;
        }
    }

    //ID�� ������ ã��
    public ItemSO GetItemById(int id)
    {
        if(itemsById == null)                               //ItemById�� ĳ���� �Ǿ� ���� �ʴٸ� �ʱ�ȭ �Ѵ�.
        {
            Initialize();
        }


        if(itemsById.TryGetValue(id, out ItemSO item))      //id ���� ã�Ƽ� ItemSO�� ���� �Ѵ�.
        {
            return item;
        }

        return null;                                        //���� ��� Null
    }

    //�̸����� ������ ã��
    public ItemSO GetItemByName(string name)
    {
        if (itemsByName == null)                               //itemsByName�� ĳ���� �Ǿ� ���� �ʴٸ� �ʱ�ȭ �Ѵ�.
        {
            Initialize();
        }


        if (itemsByName.TryGetValue(name, out ItemSO item))     //�̸� ���� ã�Ƽ� ItemSO�� ���� �Ѵ�.
        {
            return item;
        }

        return null;                                            //���� ��� Null
    }

    //Ÿ������ ������ ���͸�
    public List<ItemSO> GetItemByType(ItemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
