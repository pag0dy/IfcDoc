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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("d7038275-a6b7-4293-86c1-f69337a29534")]
	public partial class IfcRelCoversSpaces : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcSpace _RelatingSpace;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcCovering> _RelatedCoverings = new HashSet<IfcCovering>();
	
	
		public IfcRelCoversSpaces()
		{
		}
	
		public IfcRelCoversSpaces(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSpace __RelatingSpace, IfcCovering[] __RelatedCoverings)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingSpace = __RelatingSpace;
			this._RelatedCoverings = new HashSet<IfcCovering>(__RelatedCoverings);
		}
	
		[Description("Relationship to the space object that is covered.\r\n<blockquote class=\"change-ifc2" +
	    "x4\">IFC4 CHANGE&nbsp; The attribute name has been changed from <em>RelatedSpace<" +
	    "/em> to <em>RelatingSpace</em> with upward compatibility for file based exchange" +
	    ".</blockquote>")]
		public IfcSpace RelatingSpace { get { return this._RelatingSpace; } set { this._RelatingSpace = value;} }
	
		[Description("Relationship to the set of coverings covering that cover surfaces of this space.\r" +
	    "\n")]
		public ISet<IfcCovering> RelatedCoverings { get { return this._RelatedCoverings; } }
	
	
	}
	
}
