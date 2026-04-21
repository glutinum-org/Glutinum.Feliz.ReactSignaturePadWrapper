module EasyBuild.Commands.Release

open Spectre.Console.Cli
open SimpleExec
open EasyBuild.Workspace
open System.Text.RegularExpressions
open System.IO
open BlackFox.CommandLine
open EasyBuild.Tools.DotNet
open EasyBuild.Tools.Git
open EasyBuild.Commands.Demo
open EasyBuild.Commands.Publish

type ReleaseSettings() =
    inherit CommandSettings()

type ReleaseCommand() =
    inherit Command<ReleaseSettings>()
    interface ICommandLimiter<ReleaseSettings>

    override __.Execute(context, settings) =

        Command.Run(
            "dotnet",
            CmdLine.empty
            |> CmdLine.appendRaw "shipit"
            |> CmdLine.appendPrefix "--mode" "local"
            |> CmdLine.toString
        )

        DemoCommand().Execute(context, DemoSettings()) |> ignore

        // Clean up the src/bin folder
        if Directory.Exists VirtualWorkspace.src.bin.``.`` then
            Directory.Delete(VirtualWorkspace.src.bin.``.``, true)

        let nupkgPath =
            DotNet.pack(
                workingDirectory = Workspace.src.``.``
            )

        DotNet.nugetPush nupkgPath

        Git.addAll ()

        let versionRegex = Regex("## (?<version>.*) - .*")

        let newVersion =
            Workspace.``CHANGELOG.md``
            |> File.ReadAllLines
            |> Seq.skipWhile (fun line ->
                versionRegex.IsMatch line |> not
            )
            |> Seq.head
            |> versionRegex.Match
            |> fun m -> m.Groups.["version"].Value

        Git.commitRelease newVersion
        Git.push ()

        PublishCommand().Execute(context, PublishSettings(SkipBuild = true)) |> ignore

        0
