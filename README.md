The **BI/public** branch in this fork of this code is managed by [Business Integrations Ltd](https://github.com/BusinessIntegrations).

A changelog is appended at the end of this file. Further information on our coding standards and approach are detailed [here](https://businessintegrations.github.io/).

***

# Vandelay Industries - Fine Latex Products - A module for Orchard CMS that does lots of stuff

## Favicon

This feature adds a favicon configuration page to site settings.
Favicons should be stored into a favicon subfolder of the media folder.

2017-07-25 Andy Mason: Removed all extra features that are not relevant to FavIcons

***

## Business Integrations Changelog

1. Module rework 2018-04-04
   * Code was completely reworked to strip out all extraneous features and code. (Sorry Bertrand!)
   * Enabled multiple FavIcon definitions to be defined and persisted
   * Reuse existing table but persists a JSON string containing all the definitions instead of single media path.
   * Enabled persistence and configuration of the Rel/Type fields to allow for expanded options.
   * Provided a suggestion list of available values for:
     * Rel field. (icon, apple-touch-icon etc)
     * Type field. (image/icon, image/x-icon etc)
   * Code tidy
   * Update readme.md
2. Introduced Controller 2018-05-04
   * Amended module to use admin menu / controller instead of driver / site settings menu.
   * Added permission in order to view menu / manage settings.
   * Added basic caching of business data. 
   * Rationalised string constants, updated module version, updated placement info, general code tidy etc.
