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
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcQuantityResource
{
	[Guid("cd63ae14-6967-4acf-b92c-2b33caddf894")]
	public abstract partial class IfcPhysicalSimpleQuantity : IfcPhysicalQuantity
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcNamedUnit")]
		IfcNamedUnit _Unit;
	
	
		[Description("Optional assignment of a unit. If no unit is given, then the global unit assignme" +
	    "nt, as established at the IfcProject, applies to the quantity measures.")]
		public IfcNamedUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
	
	}
	
}
