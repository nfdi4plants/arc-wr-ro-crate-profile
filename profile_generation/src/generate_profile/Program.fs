module Main

let [<Literal>] ARC_WORKFLOW_REQUIREMENTS = """[[ARC_WORKFLOW_REQUIREMENTS]]"""
let [<Literal>] WORKFLOW_PROTOCOL_REQUIREMENTS = """[[WORKFLOW_PROTOCOL_REQUIREMENTS]]"""
let [<Literal>] ARC_RUN_REQUIREMENTS = """[[ARC_RUN_REQUIREMENTS]]"""
let [<Literal>] WORKFLOW_INVOCATION_REQUIREMENTS = """[[WORKFLOW_INVOCATION_REQUIREMENTS]]"""
let [<Literal>] DATASET_PROFILE_REQUIREMENTS = """[[DATASET_PROFILE_REQUIREMENTS]]"""
let [<Literal>] FORMAL_PARAMETER_PROFILE_REQUIREMENTS = """[[FORMAL_PARAMETER_PROFILE_REQUIREMENTS]]"""
let [<Literal>] PROPERTY_VALUE_PROFILE_REQUIREMENTS = """[[PROPERTY_VALUE_PROFILE_REQUIREMENTS]]"""
let [<Literal>] SOFTWARE_APPLICATION_PROFILE_REQUIREMENTS = """[[SOFTWARE_APPLICATION_PROFILE_REQUIREMENTS]]"""
let [<Literal>] WP_MINIMAL_JSON = """[[WP_MINIMAL_JSON]]"""
let [<Literal>] WPI_MINIMAL_JSON = """[[WPI_MINIMAL_JSON]]"""
let [<Literal>] WP_MINIMAL_METADATA_JSON = """[[WP_MINIMAL_METADATA_JSON]]"""
let [<Literal>] WPI_MINIMAL_METADATA_JSON = """[[WPI_MINIMAL_METADATA_JSON]]"""
let [<Literal>] WP_WRCOMPLIANT_JSON = """[[WP_WRCOMPLIANT_JSON]]"""
let [<Literal>] WPI_WRCOMPLIANT_JSON = """[[WPI_WRCOMPLIANT_JSON]]"""

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
            .Replace(ARC_WORKFLOW_REQUIREMENTS, Domain.generateProfileTable false ARCWorkflow.profile)
            .Replace(WORKFLOW_PROTOCOL_REQUIREMENTS, Domain.generateProfileTable true WorkflowProtocol.profile)
            .Replace(ARC_RUN_REQUIREMENTS, Domain.generateProfileTable false ARCRun.profile)
            .Replace(WORKFLOW_INVOCATION_REQUIREMENTS, Domain.generateProfileTable true WorkflowInvocation.profile)
            .Replace(DATASET_PROFILE_REQUIREMENTS, Domain.generateProfileTable true Dataset.profile)
            .Replace(FORMAL_PARAMETER_PROFILE_REQUIREMENTS, Domain.generateProfileTable true FormalParameter.profile)
            .Replace(PROPERTY_VALUE_PROFILE_REQUIREMENTS, Domain.generateProfileTable true PropertyValue.profile)
            .Replace(SOFTWARE_APPLICATION_PROFILE_REQUIREMENTS, Domain.generateProfileTable true SoftwareApplication.profile)
            .Replace(WP_MINIMAL_JSON, EmbeddedResource.load("examples.wp_minimal.json"))
            .Replace(WPI_MINIMAL_JSON, EmbeddedResource.load("examples.wpi_minimal.json"))
            .Replace(WP_MINIMAL_METADATA_JSON, EmbeddedResource.load("examples.wp_minimal_metadata.json"))
            .Replace(WPI_MINIMAL_METADATA_JSON, EmbeddedResource.load("examples.wpi_minimal_metadata.json"))
            .Replace(WP_WRCOMPLIANT_JSON, EmbeddedResource.load("examples.wp_workflowrun-compliant.json"))
            .Replace(WPI_WRCOMPLIANT_JSON, EmbeddedResource.load("examples.wpi_workflowrun-compliant.json"))
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
            
