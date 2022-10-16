# AutoTranslate
***Work in progress...very early alpha.***

Automatically translate string resources files into other languages.

## The Power
This application aims to use several translation providers to provide the easiest experience possible. [LibreTranslate GitHub](https://github.com/LibreTranslate/LibreTranslate), website can be found [here](https://libretranslate.com/) is one of the providers (buy an API key or deploy your own server (see GitHub for how to do that)). Additionally AWS Translate can be used as a provider but you will need your own credentials. Other providers will be added in the future.

## Usage
This application aims to keep is self free and MIT licensed. The various translations providers will need credentials so we recommend deploying your own LibreTranslate instance and connecting to that for free.

## Translation Providers
[CTranslate2](https://github.com/OpenNMT/CTranslate2) with trained models (looking to use M2M-100) (offline, unlimited)

[Argos Translate](https://github.com/argosopentech/argos-translate) (offline, unlimited)

[LibreTranslate GitHub](https://github.com/LibreTranslate/LibreTranslate), website can be found [here](https://libretranslate.com/) (offline (self hosted) and online, unlimited and limited based on location or self hosting)

[AWS Translate](https://aws.amazon.com/translate/) but you will need an AWS account (online) (limited)

[Google Translate](https://translate.google.com/) (online, limited)

[Bing Translate](https://www.bing.com/translator) (online, limited)

[Azure Translate](https://azure.microsoft.com/en-us/products/cognitive-services/translator/) but you will need an Azure account (online, limited)
