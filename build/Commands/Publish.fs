module EasyBuild.Commands.Publish

open Spectre.Console.Cli
open SimpleExec
open EasyBuild.Workspace
open EasyBuild.Commands.Demo
open BlackFox.CommandLine
open EasyBuild.Tools.GhPages

type PublishSettings() =
    inherit CommandSettings()

    [<CommandOption("--skip-build")>]
    member val SkipBuild = false with get, set

type PublishCommand() =
    inherit Command<PublishSettings>()
    interface ICommandLimiter<PublishSettings>

    override __.Execute(context, settings) =

        if not settings.SkipBuild then
            DemoCommand().Execute(context, DemoSettings()) |> ignore

        GhPages.run(
            dist = VirtualWorkspace.demo.dist.``.``
        )

        0
