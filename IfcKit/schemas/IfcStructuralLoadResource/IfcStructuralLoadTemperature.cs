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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	public partial class IfcStructuralLoadTemperature : IfcStructuralLoadStatic
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Temperature change which affects the complete section of the structural member, or the uniform portion of a non-uniform temperature change.    <blockquote class=\"note\">NOTE&nbsp; A positive value describes an increase in temperature.  I.e. a positive constant temperature change causes elongation of a member, or compression in the member if there are respective restraints.</blockquote>")]
		public IfcThermodynamicTemperatureMeasure? DeltaTConstant { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Non-uniform temperature change, specified as the difference of the temperature change at the outer fibre of the positive y direction minus the temperature change at the outer fibre of the negative y direction of the analysis member.    <blockquote class=\"note\">NOTE&nbsp; A positive non-uniform temperature change in y induces a negative curvature of the member about z, or a positive bending moment about z if there are respective restraints.  y and z are local member axes.</blockquote>")]
		public IfcThermodynamicTemperatureMeasure? DeltaTY { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Non-uniform temperature change, specified as the difference of the temperature change at the outer fibre of the positive z direction minus the temperature change at the outer fibre of the negative z direction of the analysis member.    <blockquote class=\"note\">NOTE&nbsp; A positive non-uniform temperature change in z induces a positive curvature of the member about y, or a negative bending moment about y if there are respective restraints.  y and z are local member axes.</small></blockquote>")]
		public IfcThermodynamicTemperatureMeasure? DeltaTZ { get; set; }
	
	
		public IfcStructuralLoadTemperature(IfcLabel? __Name, IfcThermodynamicTemperatureMeasure? __DeltaTConstant, IfcThermodynamicTemperatureMeasure? __DeltaTY, IfcThermodynamicTemperatureMeasure? __DeltaTZ)
			: base(__Name)
		{
			this.DeltaTConstant = __DeltaTConstant;
			this.DeltaTY = __DeltaTY;
			this.DeltaTZ = __DeltaTZ;
		}
	
	
	}
	
}
