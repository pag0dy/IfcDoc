// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcRelCoversSpaces : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  Relationship to the space object that is covered.  </EPM-HTML>")]
		[Required()]
		public IfcSpace RelatedSpace { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Relationship to the set of coverings covering this space.  ")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcCovering> RelatedCoverings { get; protected set; }
	
	
		public IfcRelCoversSpaces(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSpace __RelatedSpace, IfcCovering[] __RelatedCoverings)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatedSpace = __RelatedSpace;
			this.RelatedCoverings = new HashSet<IfcCovering>(__RelatedCoverings);
		}
	
	
	}
	
}
