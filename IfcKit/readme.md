IfcKit
======

This folder contains a toolkit for implementing IFC, and the IFC schema itself represented as C# code. See inner folders for further specifics. 

All files within may be edited directly, and other representations will be automatically generated to match. 
Schema changes may be made in C# files, and corresponding Java, EXPRESS, XSD, XMI, RDF, and documentation will be automatically updated. 
Example changes may be made in .ifcxml files, and other corresponding files in other encodings will be automatically updated.

* **schemas**: contains IFC schemas, documentation, and UML diagrams (as C# code, HTML, and SVG) that can be edited.
* **exchanges**: contains IFC model view definitions (as mvdXML or C# code)
* **figures**: images referenced in documentation for schemas and exchanges
* **examples**: example files referenced in documentation for schemas and exchanges
* **formats**: contains code for reading/writing data in various formats, including STEP, XML, JSON, and others.
* **utilities**: contains code for converting, validating, and publishing data definitions.
