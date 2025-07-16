module CLIArgs

open Argu

[<HelpFlags([|"--help"; "-h"|])>]
type CLIArgs =
    | [<Unique; Mandatory; AltCommandLine("-v")>] Version of string
    | [<Unique; Mandatory; AltCommandLine("-o")>] OutputPath of string
    | [<Unique; AltCommandLine("-on")>] OutputName of string
    | [<Unique; >] Verbose

    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Version _     -> "Mandatory. The version string of the generated profile"
            | OutputPath _  -> "Mandatory. Path of the output"
            | Verbose       -> "Use verbose error messages (with full error stack). Disabled by default."
            | OutputName _  -> "alternatively set a file name for the output. Default is 'profile_generated.md'"

    static member createParser() =

        let errorHandler = ProcessExiter(colorizer = function ErrorCode.HelpText -> None | _ -> Some System.ConsoleColor.Red)

        ArgumentParser.Create<CLIArgs>(programName = "generate_profile", errorHandler = errorHandler)