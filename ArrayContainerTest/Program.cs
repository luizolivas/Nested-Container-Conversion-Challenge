using System.IO;







Dictionary<string, Object> container =
    new Dictionary<string, Object>();





container.Add("one", new Dictionary<string, Object>
{
    { "two", 3 },
    { "four", new List<Object> {5,6,7} },
});
container.Add("eight", new Dictionary<string, Object>
{
    { "nine",  new Dictionary<string, Object>
        {
            { "ten",11 }
        }
    }
});


Dictionary<string, Object> containerFlat =
    new Dictionary<string, Object>();

void FlattenContainer(Dictionary<string, Object> container, string parentKey = "")
{
    foreach (var kvp in container)
    {
        string currentKey = string.IsNullOrEmpty(parentKey) ? kvp.Key : $"{parentKey}/{kvp.Key}";

        if (kvp.Value is Dictionary<string, Object> next)
        {
            FlattenContainer(next, currentKey);
        }
        else if (kvp.Value is List<Object> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                containerFlat[$"{currentKey}/{i}"] = list[i];
            }
        }
        else
        {
            containerFlat.Add(currentKey, (kvp.Value));
        }
    }
}

FlattenContainer(container);

Dictionary<string, Object> containerUnflated =
    new Dictionary<string, Object>();

void UnflattenContainer(Dictionary<string, Object> containerFlat)
{
    foreach (var kvp in containerFlat)
    {
        string[] parts = kvp.Key.Split('/');
        object value = kvp.Value;

        Dictionary<string, Object> currentContainer = containerUnflated;

        for (int i = 0; i < parts.Length; i++)
        {
            string part = parts[i];

            if (i == parts.Length - 1)
            {
                if (int.TryParse(part, out int index))
                {
                    if (!(currentContainer.ContainsKey(parts[i - 1]) && currentContainer[parts[i - 1]] is List<object> list))
                    {
                        list = new List<object>();
                        currentContainer[parts[i - 1]] = list;
                    }
                    list.Insert(index, value);
                }
                else
                {
                    currentContainer[part] = value;
                }
            }
            else
            {
                if (!currentContainer.ContainsKey(part) || !(currentContainer[part] is Dictionary<string, Object> nextContainer))
                {
                    nextContainer = new Dictionary<string, Object>();
                    currentContainer[part] = nextContainer;
                }

                currentContainer = nextContainer;
            }
        }
    }

}



//foreach (var kvp in containerFlat)
//{
//    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
//}

UnflattenContainer(containerFlat);

//foreach (var kvp in containerUnflated)
//{
//    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
//}


static void PrintDictionary(Dictionary<string, Object> dict, int indent = 0)
{
    string indentSpaces = new string(' ', indent);

    foreach (var kvp in dict)
    {
        Console.Write(indentSpaces + kvp.Key + ": ");
        if (kvp.Value is Dictionary<string, Object> nestedDict)
        {
            Console.WriteLine();
            PrintDictionary((Dictionary<string, Object>)kvp.Value, indent + 4);
        }
        else if (kvp.Value is List<Object> list)
        {
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }
        else
        {
            Console.WriteLine(kvp.Value);
        }
    }
}



PrintDictionary(containerUnflated);
