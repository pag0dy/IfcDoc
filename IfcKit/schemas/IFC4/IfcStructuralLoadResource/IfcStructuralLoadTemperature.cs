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

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("a5520d12-ec69-4ee1-85ae-cce5fdfdec16")]
	public partial class IfcStructuralLoadTemperature : IfcStructuralLoadStatic
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _DeltaTConstant;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _DeltaTY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _DeltaTZ;
	
	
		[Description(@"<EPM-HTML>
	
	Temperature change which affects the complete section of the structural member, or the uniform portion of a non-uniform temperature change.
	
	<blockquote class=""note"">NOTE&nbsp; A positive value describes an increase in temperature.  I.e. a positive constant temperature change causes elongation of a member, or compression in the member if there are respective restraints.</blockquote>
	
	</EPM-HTML>")]
		public IfcThermodynamicTemperatureMeasure? DeltaTConstant { get { return this._DeltaTConstant; } set { this._DeltaTConstant = value;} }
	
		[Description(@"<EPM-HTML>
	
	Non-uniform temperature change, specified as the difference of the temperature change at the outer fibre of the positive y direction minus the temperature change at the outer fibre of the negative y direction of the analysis member.
	
	<blockquote class=""note"">NOTE&nbsp; A positive non-uniform temperature change in y induces a negative curvature of the member about z, or a positive bending moment about z if there are respective restraints.  y and z are local member axes.</blockquote>
	
	</EPM-HTML>")]
		public IfcThermodynamicTemperatureMeasure? DeltaTY { get { return this._DeltaTY; } set { this._DeltaTY = value;} }
	
		[Description(@"<EPM-HTML>
	
	Non-uniform temperature change, specified as the difference of the temperature change at the outer fibre of the positive z direction minus the temperature change at the outer fibre of the negative z direction of the analysis member.
	
	<blockquote class=""note"">NOTE&nbsp; A positive non-uniform temperature change in z induces a positive curvature of the member about y, or a negative bending moment about y if there are respective restraints.  y and z are local member axes.</small></blockquote>
	
	</EPM-HTML>")]
		public IfcThermodynamicTemperatureMeasure? DeltaTZ { get { return this._DeltaTZ; } set { this._DeltaTZ = value;} }
	
	
	}
	
}
