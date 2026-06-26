{
    _availableReaders = new List<IfileReader>
    {
        new TextFileReader()
        new TextFileReader(),
        new CsvFileReader(),
        new JsonFileReader(),
        new XmlFileReader()

        // TODO: Register CsvFileReader, JsonFileReader,XmlFileReader here
    };   
}