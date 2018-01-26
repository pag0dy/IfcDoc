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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("57c11bcb-98a6-432c-af6d-cb98d7020755")]
	public partial class IfcFaceBound : IfcTopologicalRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcLoop _Bound;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _Orientation;
	
	
		public IfcFaceBound()
		{
		}
	
		public IfcFaceBound(IfcLoop __Bound, IfcBoolean __Orientation)
		{
			this._Bound = __Bound;
			this._Orientation = __Orientation;
		}
	
		[Description("The loop which will be used as a face boundary.\r\n")]
		public IfcLoop Bound { get { return this._Bound; } set { this._Bound = value;} }
	
		[Description("This indicated whether (TRUE) or not (FALSE) the loop has the same sense when use" +
	    "d to bound the face as when first defined. If sense is FALSE the senses of all i" +
	    "ts component oriented edges are implicitly reversed when used in the face.\r\n")]
		public IfcBoolean Orientation { get { return this._Orientation; } set { this._Orientation = value;} }
	
	
	}
	
}
