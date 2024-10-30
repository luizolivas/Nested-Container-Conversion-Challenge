
Dictionary<string, Object> container =
    new Dictionary<string, Object>();


container.Add("one", new Dictionary<string, Object>
{
    { "two", 3 },
    { "four", new List<int> [5,6,7] },
});
container.Add("eight", new Dictionary<string, Object>
{
    { "nine",  new Dictionary<string, Object>
        {
            { "ten",11 }
        }
    }
});




foreach (KeyValuePair<string, Object> kvp in container)
{
    Console.WriteLine("Key = {0}, Value = {1}",
        kvp.Key, kvp.Value);
}
