IFC formats
===========

This folder contains C# code for reading and writing IFC data. Such data may be captured as files, in memory, or through web services using the .NET Stream class.

Serializers follow established .NET conventions, where there is a constructor for defining the schema to be serialized (which may build a cache at the time the constructor is called), and functions for reading and writing.
The serializers within may support any schema, not just IFC. For IFC data, the top-level _IfcProject_ class must be used, which then pulls in all data within a graph that can be traversed starting from the single IfcProject instance.
Code for using serializers works as follows.

**// 1. choose a transport** (e.g. file, web, memory):

`Stream stream = new FileStream(“myfile.ifc”);`


**// 2. choose a schema** (e.g. IFC2x3, IFC4, IFC4x1):

`Type type = typeof(IFC4x1::BuildingSmart.IFC.IfcKernel.IfcProject); `

**// 3. choose a format** (e.g. STEP, XML, JSON, SQLite):

`Serializer f = new StepSerializer(type);`


**// read, write, manipulate data:**

`IfcProject proj = (IfcProject)f.ReadObject(stream); // read data`

`f.WriteObject(stream, proj); // write data`
