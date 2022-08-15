# Nukitashi MT tools
## What is this?
A collection of tools to help translate Nukitashi. This includes:

- Tools to pack/unpack data files in `.WAR` format (images, texts etc...)
- Tools to pack/unpack images in `.S25` format
- Tool to parse the dialogues from all the text files, which might help in translating the lines individually, either manually or using a MT tool such as Google Translate or DeepL.

## How does it work?
For more information regarding the first two tools (.WAR and .S25), refer to other repos such as [here](https://github.com/MishaIac/Shiina-Rio-TL-Tools).

Regarding the tool that parses the dialogues, it iterates over every `.txt` file in the specified folder, reads every line one by one, and checks wether it is an actual dialogue (does not start with any reserved character) or a script event (usually starts with either a `$` or `;;`). An example of a script would be drawing a specific spirte, or playing a certain audio.

## Sounds great, where do I start?
The repo is divided into two folders:
1. `tools`

     `.WARC` and `.S25` packers/unpackers in `.exe` format. Source code can be found in other repos such as [here](https://github.com/MishaIac/Shiina-Rio-TL-Tools).

     - Run `WARC_unpack.exe <WAR file>` to unpack a `.WAR` file. This creates a new folder with the extracted data, and also an `.idx` file in the current directory.

     - Run `WARC_pack.exe <WAR file>` to repack an extracted folder to a `.WAR` file. The `.idx` file should also be present.

     - Same applies to `.S25` tool.

2. `text-translator`

    A simple C# project to parse and/or auto-translate the dialogues. Modify the `App.config` file according to your needs and run the project:

    ```
    <add key="SourcePath" value="<txt-files-folder-input>"/>
    <add key="DesPath" value="<txt-files-folder-output>"/>
    ```

    Google Translate config (tested, but the translation is crap!!)
    ```
	<add key="ProjectId" value="<google-project-id>"/>
	<add key="ServiceAccountPath" value="<path-to-google-service-account-json>"/>
    ```

    DeepL config (not tested)
    ```
    <add key="DeepLAuthKey" value="<deepl-auth-key>"/>
    ```

    Depending on which MT tool you choose, make sure to use the proper `ITranslator` implementation in `Translators` package.
