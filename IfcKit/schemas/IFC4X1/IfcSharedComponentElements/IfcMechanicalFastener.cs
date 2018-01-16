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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	[Guid("3f389407-9e81-4218-8102-56eb71651146")]
	public partial class IfcMechanicalFastener : IfcElementComponent
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _NominalDiameter;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _NominalLength;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcMechanicalFastenerTypeEnum? _PredefinedType;
	
	
		[Description("The nominal diameter describing the cross-section size of the fastener type.\r\n<bl" +
	    "ockquote class=\"deprecated\">Deprecated in IFC4</blockquote>")]
		public IfcPositiveLengthMeasure? NominalDiameter { get { return this._NominalDiameter; } set { this._NominalDiameter = value;} }
	
		[Description("The nominal length describing the longitudinal dimensions of the fastener type.\r\n" +
	    "<blockquote class=\"deprecated\">Deprecated in IFC4</blockquote>")]
		public IfcPositiveLengthMeasure? NominalLength { get { return this._NominalLength; } set { this._NominalLength = value;} }
	
		[Description("Subtype of mechanical fastener")]
		public IfcMechanicalFastenerTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
