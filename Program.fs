// For more information see https://aka.ms/fsharp-console-apps
open FSharp.Configuration
open System
open System.Reflection
open System.IO
open YamlDotNet.Serialization
open YamlDotNet.Serialization.NamingConventions
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Serilog


[<Literal>]
let yamlFile = "/app/logix-ai.yml"

let loadYAMLAndConvertToJSON filePath =
    let file = new FileStream(filePath, FileMode.Open, FileAccess.Read)
    let streamReader = new StreamReader(file)
    let yamlText = File.ReadAllText(filePath)
    let deserializer = (new DeserializerBuilder()).Build()
    let yamlObject = deserializer.Deserialize<obj>(yamlText);
    printf "%O\n\n" (streamReader.ReadToEnd())
    let json = JsonConvert.SerializeObject(yamlObject, Formatting.Indented);
    let jsonObject = JObject.Parse(json);
    // // printf "%s" (jsonObject["name"].ToString())
    // jsonObject.Property("kind").Remove()
    printf "%O" jsonObject
    jsonObject

let findLatestEve dirPath=
    let mutable latestEveVerison = None
    if not(Directory.Exists(dirPath)) then
        Log.Logger.Error("Could not find directoryPath {directoryPath}", dirPath)
        None
    else
        let mutable files = Directory.GetFiles(dirPath, "*.yml")
        files <-  Array.concat [files;  Directory.GetFiles(dirPath, "*.yaml") ]
        for file in files do
            let json = loadYAMLAndConvertToJSON file
            if(json["kind"].ToString() = "eve-os-latest-version") then
                latestEveVerison <- Some (json["version"].ToString())
        latestEveVerison

let iterateYamlFiles directoryPath =
    if (Directory.Exists(directoryPath) = false) then
        Log.Logger.Error("Could not find directoryPath {directoryPath}", directoryPath)
        [||]
    else
        let mutable files = Directory.GetFiles(directoryPath, "*.yml")
        files <-  Array.concat [files;  Directory.GetFiles(directoryPath, "*.yaml") ]
        Array.map (fun elem -> loadYAMLAndConvertToJSON elem) files

loadYAMLAndConvertToJSON "./default-project.yml" |> ignore
// let jsonData = iterateYamlFiles "./"

// jsonData |> Array.iter (fun x -> printf "%O" x)

// printf "%O" (findLatestEve "./")


// let js = new JsonSerializer();
// let w = new StringWriter();
// js.Serialize(w, yamlObject);

// printfn "%O\n\n%O" (Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)) (Environment.CurrentDirectory)
// let jsonText = "{"+w.ToString().Substring(25);


// Log.Logger.Information("File path: {jsonObject}", jsonObject)
// Log.Logger.Information("Data: {jsonObject}", jsonData)