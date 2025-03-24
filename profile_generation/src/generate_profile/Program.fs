module Main

let [<Literal>] ARC_WORKFLOW_REQUIREMENTS = """[[ARC_WORKFLOW_REQUIREMENTS]]"""
let [<Literal>] WORKFLOW_PROTOCOL_REQUIREMENTS = """[[WORKFLOW_PROTOCOL_REQUIREMENTS]]"""
let [<Literal>] ARC_RUN_REQUIREMENTS = """[[ARC_RUN_REQUIREMENTS]]"""
let [<Literal>] WORKFLOW_INVOCATION_REQUIREMENTS = """[[WORKFLOW_INVOCATION_REQUIREMENTS]]"""
let [<Literal>] DATASET_PROFILE_REQUIREMENTS = """[[DATASET_PROFILE_REQUIREMENTS]]"""
let [<Literal>] FORMAL_PARAMETER_PROFILE_REQUIREMENTS = """[[FORMAL_PARAMETER_PROFILE_REQUIREMENTS]]"""
let [<Literal>] PROPERTY_VALUE_PROFILE_REQUIREMENTS = """[[PROPERTY_VALUE_PROFILE_REQUIREMENTS]]"""
let [<Literal>] SOFTWARE_APPLICATION_PROFILE_REQUIREMENTS = """[[SOFTWARE_APPLICATION_PROFILE_REQUIREMENTS]]"""

open System.IO
open Argu
open Spectre.Console
open CLIArgs

module internal EmbeddedResource = 

    open System.Reflection
    open System.IO

    let assembly = Assembly.GetExecutingAssembly()

    let load file = 
        use str = assembly.GetManifestResourceStream($"generate_profile.{file}")
        use r = new StreamReader(str)
        r.ReadToEnd()

let template = EmbeddedResource.load("profile_template.md")

[<EntryPoint>]
let main argv =

    let parser = CLIArgs.createParser()

    try
        let args = parser.ParseCommandLine()

        let verbose = args.TryGetResult(CLIArgs.Verbose) |> Option.isSome

        let outPath = args.GetResult(CLIArgs.OutputPath)
        
        let outName = args.TryGetResult(CLIArgs.OutputName) |> Option.defaultValue "profile_generated.md"

        let outPath = Path.Combine(outPath, outName)

        template
            .Replace(ARC_WORKFLOW_REQUIREMENTS, Domain.generateProfileTable ARCWorkflow.profile)
            .Replace(WORKFLOW_PROTOCOL_REQUIREMENTS, Domain.generateProfileTable WorkflowProtocol.profile)
            .Replace(ARC_RUN_REQUIREMENTS, Domain.generateProfileTable ARCRun.profile)
            .Replace(WORKFLOW_INVOCATION_REQUIREMENTS, Domain.generateProfileTable WorkflowInvocation.profile)
            .Replace(DATASET_PROFILE_REQUIREMENTS, Domain.generateProfileTable Dataset.profile)
            .Replace(FORMAL_PARAMETER_PROFILE_REQUIREMENTS, Domain.generateProfileTable FormalParameter.profile)
            .Replace(PROPERTY_VALUE_PROFILE_REQUIREMENTS, Domain.generateProfileTable PropertyValue.profile)
            .Replace(SOFTWARE_APPLICATION_PROFILE_REQUIREMENTS, Domain.generateProfileTable SoftwareApplication.profile)
            |> fun p -> File.WriteAllText(outPath, p)

        0

    with
        | :? ArguParseException as ex ->
            match ex.ErrorCode with
            | ErrorCode.HelpText  -> 
                (parser.PrintUsage()) |> AnsiConsole.MarkupLine
                0 // printing usage is not an error

            | ErrorCode.CommandLine ->
                "[red]Argument parsing error:[/]" |> AnsiConsole.MarkupLine
                AnsiConsole.WriteException(ex) // might want to add verbosity level to hide this
                1

            | _ -> 
                "[red]Internal Error:[/]" |> AnsiConsole.MarkupLine
                AnsiConsole.WriteException(ex) // might want to add verbosity level to hide this
                1
        | ex ->
            "[red]Internal Error:[/]" |> AnsiConsole.MarkupLine
            AnsiConsole.WriteException(ex) // might want to add verbosity level to hide this

            1
            
