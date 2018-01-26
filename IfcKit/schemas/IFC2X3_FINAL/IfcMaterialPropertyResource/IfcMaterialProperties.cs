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

using BuildingSmart.IFC.IfcMaterialResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	[Guid("24d16034-dc7a-4fb4-b385-c881130622bb")]
	public abstract partial class IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcMaterial _Material;
	
	
		public IfcMaterialProperties()
		{
		}
	
		public IfcMaterialProperties(IfcMaterial __Material)
		{
			this._Material = __Material;
		}
	
		[Description("Reference to the material to which the set of properties is assigned.")]
		public IfcMaterial Material { get { return this._Material; } set { this._Material = value;} }
	
	
	}
	
}
