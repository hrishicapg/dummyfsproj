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


// [<Literal>]
// let yamlFile = "/app/logix-ai.yml"

// let convertBoolString(json: JObject) =
//     let tokens = json.Children()
//     for token in tokens do
//         printf "%O\n" (token)
//     let enumerator =tokens.GetEnumerator()
//     for property in json do
        // printf "%O: %O" property.Key property.Value


    // json.Properties()
    // |> Seq.iter (fun prop ->
    //     match prop.Value with
    //     | :? JValue as jv ->
    //         match jv.Value with
    //         | :? string as s when s.ToLower() = "true" || s.ToLower() = "false" -> prop.Value <- new JValue(true)
    //         | _ -> ()
    //     | _ -> ()
    // )
    // printf "%s" (System.Convert.ToString(json))
    // json

// let loadYAMLAndConvertToJSON filePath =
//     let file = new FileStream(filePath, FileMode.Open, FileAccess.Read)
//     let streamReader = new StreamReader(file)
//     // let yamlText = File.ReadAllText(filePath)
//     // let deserializer = (new DeserializerBuilder()).Build()
//     let yamlObject = (new Deserializer()).Deserialize(streamReader);
//     // printf "%O\n\n" (streamReader.ReadToEnd())
//     // let serializer = (new SerializerBuilder()).JsonCompatible().Build();
//     let json = JsonConvert.SerializeObject(yamlObject);
//     let jsonObject = JObject.Parse(json);
//     convertBoolString jsonObject |> ignore
//     // // printf "%s" (jsonObject["name"].ToString())
//     // jsonObject.Property("kind").Remove()
//     // printf "%O" jsonObject
//     jsonObject

// let findLatestEve dirPath=
//     let mutable latestEveVerison = None
//     if not(Directory.Exists(dirPath)) then
//         Log.Logger.Error("Could not find directoryPath {directoryPath}", dirPath)
//         None
//     else
//         let mutable files = Directory.GetFiles(dirPath, "*.yml")
//         files <-  Array.concat [files;  Directory.GetFiles(dirPath, "*.yaml") ]
//         for file in files do
//             let json = loadYAMLAndConvertToJSON file
//             if(json["kind"].ToString() = "eve-os-latest-version") then
//                 latestEveVerison <- Some (json["version"].ToString())
//         latestEveVerison

// let iterateYamlFiles directoryPath =
//     if (Directory.Exists(directoryPath) = false) then
//         Log.Logger.Error("Could not find directoryPath {directoryPath}", directoryPath)
//         [||]
//     else
//         let mutable files = Directory.GetFiles(directoryPath, "*.yml")
//         files <-  Array.concat [files;  Directory.GetFiles(directoryPath, "*.yaml") ]
//         Array.map (fun elem -> loadYAMLAndConvertToJSON elem) files
// 
// loadYAMLAndConvertToJSON "./default-project.yml" |> ignore
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

let os = Environment.OSVersion; 
let opSys = new OperatingSystem(os.Platform, os.Version); 

printf "%O\n%O" os opSys