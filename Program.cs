// diverso da foreach(var line in await ReadLinesAsync("got.json"))

await foreach (var line in ReadLinesAsync("got.json"))
{
    Console.WriteLine(line);
}

async IAsyncEnumerable<string> ReadLinesAsync(string path)
{
    using var stream = new StreamReader(File.OpenRead(path));
    string? line;
    while ((line = await stream.ReadLineAsync()) != null)
    {
        await Task.Delay(500);
        yield return line;
    }
}
