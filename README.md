# BlendoBot.Core
## A Discord bot framework for .NET 6.0
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/BlendoBot/BlendoBot.Core/Tests)
![Nuget](https://img.shields.io/nuget/v/BlendoBot.Core)

BlendoBot is a Discord bot framework intended for easy implementation of new functionalities and commands. It currently uses [DSharpPlus](https://github.com/DSharpPlus/DSharpPlus) to operate with Discord, but it also has its own interfaces and common code functionality to allow front-ends to easily add and remove functionality from the bot.

### What do I do with this?
`BlendoBot.Core` is published to the BlendoBot NuGet. This module exposes interfaces and basic classes that can be used by other BlendoBot modules. If you're developing your own BlendoBot functionality, your projects should always include this NuGet package. To add the package to your project, add the NuGet feed `https://nuget.pkg.github.com/BlendoBot/index.json` to your project, and use the latest stable version of `BlendoBot.Core`.

Also see [BlendoBot.Frontend](https://github.com/BlendoBot/BlendoBot.Frontend) for an example implementation, and [BlendoBot.Live](https://github.com/BlendoBot/BlendoBot.Live) for a live deployment.