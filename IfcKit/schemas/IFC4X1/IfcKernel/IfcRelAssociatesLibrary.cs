// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("023ad93b-f1e9-4695-9464-50b0caeabeba")]
	public partial class IfcRelAssociatesLibrary : IfcRelAssociates
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcLibrarySelect _RelatingLibrary;
	
	
		public IfcRelAssociatesLibrary()
		{
		}
	
		public IfcRelAssociatesLibrary(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcDefinitionSelect[] __RelatedObjects, IfcLibrarySelect __RelatingLibrary)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects)
		{
			this._RelatingLibrary = __RelatingLibrary;
		}
	
		[Description("Reference to a library, from which the definition of the property set is taken.")]
		public IfcLibrarySelect RelatingLibrary { get { return this._RelatingLibrary; } set { this._RelatingLibrary = value;} }
	
	
	}
	
}
