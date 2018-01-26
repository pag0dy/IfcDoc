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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("a5aff9ec-1a7c-4fad-98f6-8993b3c19b0c")]
	public partial class IfcFaceBound : IfcTopologicalRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcLoop _Bound;
	
		[DataMember(Order=1)] 
		[Required()]
		Boolean _Orientation;
	
	
		public IfcFaceBound()
		{
		}
	
		public IfcFaceBound(IfcLoop __Bound, Boolean __Orientation)
		{
			this._Bound = __Bound;
			this._Orientation = __Orientation;
		}
	
		[Description("The loop which will be used as a face boundary.\r\n")]
		public IfcLoop Bound { get { return this._Bound; } set { this._Bound = value;} }
	
		[Description("This indicated whether (TRUE) or not (FALSE) the loop has the same sense when use" +
	    "d to bound the face as when first defined. If sense is FALSE the senses of all i" +
	    "ts component oriented edges are implicitly reversed when used in the face.\r\n")]
		public Boolean Orientation { get { return this._Orientation; } set { this._Orientation = value;} }
	
	
	}
	
}
