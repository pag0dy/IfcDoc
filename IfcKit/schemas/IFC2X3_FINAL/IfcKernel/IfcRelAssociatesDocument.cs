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
	[Guid("d40d6e07-fca6-44d6-8ff0-7428d418bb6a")]
	public partial class IfcRelAssociatesDocument : IfcRelAssociates
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDocumentSelect _RelatingDocument;
	
	
		public IfcRelAssociatesDocument()
		{
		}
	
		public IfcRelAssociatesDocument(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcRoot[] __RelatedObjects, IfcDocumentSelect __RelatingDocument)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects)
		{
			this._RelatingDocument = __RelatingDocument;
		}
	
		[Description("Document information or reference which is applied to the objects.")]
		public IfcDocumentSelect RelatingDocument { get { return this._RelatingDocument; } set { this._RelatingDocument = value;} }
	
	
	}
	
}
