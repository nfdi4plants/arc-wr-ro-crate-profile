module CLIArgs

open Argu

[<HelpFlags([|"--help"; "-h"|])>]
type CLIArgs =
    | [<Unique>] Verbose
    | [<Unique; AltCommandLine("-o")>] OutputPath of string
    | [<Unique; AltCommandLine("-on")>] OutputName of string

    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Verbose         -> "Use verbose error messages (with full error stack)."
            | OutputPath _      -> "path of the output"
            | OutputName _      -> "alternatively set a file name for the output. Default is 'profile_generated.md'"

    static member createParser() =

        let errorHandler = ProcessExiter(colorizer = function ErrorCode.HelpText -> None | _ -> Some System.ConsoleColor.Red)

        ArgumentParser.Create<CLIArgs>(programName = "generate_profile", errorHandler = errorHandler)