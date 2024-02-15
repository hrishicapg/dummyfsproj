// For more information see https://aka.ms/fsharp-console-apps
open FSharp.Configuration
open System
open System.Reflection
open System.IO
open YamlDotNet.Serialization
open YamlDotNet.Serialization.NamingConventions
open Newtonsoft.Json
open Newtonsoft.Json.Linq


[<Literal>]
let yamlFile = "/app/logix-ai.yml"

let logixAIFile = new FileStream("./default-project.yml", FileMode.Open, FileAccess.Read)
let stream = new StreamReader(logixAIFile)
let deserializer = (new DeserializerBuilder()).WithNamingConvention(CamelCaseNamingConvention.Instance).Build()
let yamlObject = deserializer.Deserialize(stream);

let json = JsonConvert.SerializeObject(yamlObject);
let jsonObject = JObject.Parse(json);
jsonObject.Property("kind").Remove()

// let js = new JsonSerializer();
// let w = new StringWriter();
// js.Serialize(w, yamlObject);

// printfn "%O\n\n%O" (Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)) (Environment.CurrentDirectory)
// let jsonText = "{"+w.ToString().Substring(25);

printfn "%O\n\n\n%O" (yamlObject.GetType()) (jsonObject)