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

void printContainer(Dictionary<string, Object> container, string parentKey = "")
{
    foreach (var kvp in container)
    {
        string currentKey = string.IsNullOrEmpty(parentKey) ? kvp.Key : $"{parentKey}/{kvp.Key}";

        if (kvp.Value is Dictionary<string, Object> next)
        {
            printContainer(next, currentKey);
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

printContainer(container);

foreach (var kvp in containerFlat)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}