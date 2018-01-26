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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("4c89d8a9-83af-4f5e-a23f-edddfe96ad48")]
	public partial class IfcRelCoversSpaces : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSpace _RelatedSpace;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcCovering> _RelatedCoverings = new HashSet<IfcCovering>();
	
	
		public IfcRelCoversSpaces()
		{
		}
	
		public IfcRelCoversSpaces(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSpace __RelatedSpace, IfcCovering[] __RelatedCoverings)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatedSpace = __RelatedSpace;
			this._RelatedCoverings = new HashSet<IfcCovering>(__RelatedCoverings);
		}
	
		[Description("<EPM-HTML>\r\nRelationship to the space object that is covered.\r\n</EPM-HTML>")]
		public IfcSpace RelatedSpace { get { return this._RelatedSpace; } set { this._RelatedSpace = value;} }
	
		[Description("Relationship to the set of coverings covering this space.\r\n")]
		public ISet<IfcCovering> RelatedCoverings { get { return this._RelatedCoverings; } }
	
	
	}
	
}
