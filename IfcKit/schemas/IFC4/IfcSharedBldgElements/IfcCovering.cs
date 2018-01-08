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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("71cd9964-d26e-4857-81b8-de24c4651a85")]
	public partial class IfcCovering : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCoveringTypeEnum? _PredefinedType;
	
		[InverseProperty("RelatedCoverings")] 
		ISet<IfcRelCoversSpaces> _CoversSpaces = new HashSet<IfcRelCoversSpaces>();
	
		[InverseProperty("RelatedCoverings")] 
		ISet<IfcRelCoversBldgElements> _CoversElements = new HashSet<IfcRelCoversBldgElements>();
	
	
		[Description(@"<EPM-HTML>
	Predefined types to define the particular type of the covering. There may be property set definitions available for each predefined type.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcCoveringType</em> is assigned, providing its own <em>IfcCoveringType.PredefinedType</em>.</blockquote>
	</EPM-HTML>")]
		public IfcCoveringTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("<EPM-HTML>\r\nReference to the objectified relationship that handles the relationsh" +
	    "ip of the covering to the covered space.\r\n</EPM-HTML>")]
		public ISet<IfcRelCoversSpaces> CoversSpaces { get { return this._CoversSpaces; } }
	
		[Description("<EPM-HTML>\r\nReference to the objectified relationship that handles the relationsh" +
	    "ip of the covering to the covered element.\r\n<blockquote class=\"change-ifc2x4\">IF" +
	    "C4 CHANGE  Renamed into <em>CoversElements</em> for consistency.\r\n</blockquote>\r" +
	    "\n</EPM-HTML>\r\n")]
		public ISet<IfcRelCoversBldgElements> CoversElements { get { return this._CoversElements; } }
	
	
	}
	
}
