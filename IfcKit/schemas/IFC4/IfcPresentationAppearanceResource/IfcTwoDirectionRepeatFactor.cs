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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("b2bb2a68-fb2a-4433-8c18-c96411974f69")]
	public partial class IfcTwoDirectionRepeatFactor : IfcOneDirectionRepeatFactor
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcVector _SecondRepeatFactor;
	
	
		[Description("A vector which specifies the relative positioning of tiles in the second directio" +
	    "n.")]
		public IfcVector SecondRepeatFactor { get { return this._SecondRepeatFactor; } set { this._SecondRepeatFactor = value;} }
	
	
	}
	
}
