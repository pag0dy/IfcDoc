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
	[Guid("4bd9bd82-20ff-4504-bb85-feccfdfe7377")]
	public partial class IfcRelAssociatesClassification : IfcRelAssociates
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcClassificationSelect _RelatingClassification;
	
	
		public IfcRelAssociatesClassification()
		{
		}
	
		public IfcRelAssociatesClassification(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcDefinitionSelect[] __RelatedObjects, IfcClassificationSelect __RelatingClassification)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects)
		{
			this._RelatingClassification = __RelatingClassification;
		}
	
		[Description("Classification applied to the objects.")]
		public IfcClassificationSelect RelatingClassification { get { return this._RelatingClassification; } set { this._RelatingClassification = value;} }
	
	
	}
	
}
